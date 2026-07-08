using HarmonyLib;
using Pchp.Core;
using System;
using System.Linq;
using System.Reflection;
#if DEBUG_PATCH
using System.IO;
#endif
using PeachpieDateTime = Pchp.Library.DateTime.DateTime;
using PeachpieDateTimeImmutable = Pchp.Library.DateTime.DateTimeImmutable;

namespace Nextsharp.Sabre.RuntimePatch;

/// <summary>
/// 对 PeachPie 的 DateTime::modify / DateTimeImmutable::modify 做运行时补丁。
///
/// 目标：不修改 PeachPie 源码，仅修正相对日期表达式的参考时间。
/// PeachPie 当前实现把 modify 字符串按“现在”解析，而 PHP 语义应以当前对象时间为基准。
/// </summary>
internal static class DateTimeModifyPatch
{
    private static bool _applied;
    private static readonly object SyncRoot = new();

    public static void EnsureApplied()
    {
        lock (SyncRoot)
        {
            if (_applied)
            {
                return;
            }

            var harmony = new Harmony("nextsharp.sabre.datetime_modify");
            Apply(harmony);
            _applied = true;
        }
    }

    private static void Apply(Harmony harmony)
    {
        var mutable = typeof(PeachpieDateTime).GetMethod(
            "modify",
            BindingFlags.Public | BindingFlags.Instance,
            binder: null,
            types: new[] { typeof(Context), typeof(string) },
            modifiers: null);

        var immutable = typeof(PeachpieDateTimeImmutable).GetMethod(
            "modify",
            BindingFlags.Public | BindingFlags.Instance,
            binder: null,
            types: new[] { typeof(Context), typeof(string) },
            modifiers: null);

        var mutablePrefix = typeof(DateTimeModifyPatch).GetMethod(
            nameof(PrefixDateTimeModify),
            BindingFlags.NonPublic | BindingFlags.Static);

        var immutablePrefix = typeof(DateTimeModifyPatch).GetMethod(
            nameof(PrefixDateTimeImmutableModify),
            BindingFlags.NonPublic | BindingFlags.Static);

        if (mutable != null && mutablePrefix != null)
        {
            harmony.Patch(mutable, prefix: new HarmonyMethod(mutablePrefix));
        }

        if (immutable != null && immutablePrefix != null)
        {
            harmony.Patch(immutable, prefix: new HarmonyMethod(immutablePrefix));
        }
    }

    private static bool PrefixDateTimeModify(
        PeachpieDateTime __instance,
        Context ctx,
        string modify,
        ref PeachpieDateTime __result)
    {
        if (!TryParseAgainstCurrentValue(__instance, modify, out var newValue))
        {
            return true;
        }

        GetValueField(__instance).SetValue(__instance, newValue);
        __result = __instance;
        return false;
    }

    private static bool PrefixDateTimeImmutableModify(
        PeachpieDateTimeImmutable __instance,
        Context ctx,
        string modify,
        ref PeachpieDateTimeImmutable __result)
    {
        if (!TryParseAgainstCurrentValue(__instance, modify, out var newValue))
        {
            return true;
        }

        var ctor = typeof(PeachpieDateTimeImmutable).GetConstructor(
            BindingFlags.Instance | BindingFlags.NonPublic,
            binder: null,
            types: new[] { GetDateTimeValueType() },
            modifiers: null);

        if (ctor == null)
        {
            return true;
        }

        __result = (PeachpieDateTimeImmutable)ctor.Invoke(new[] { newValue });
        return false;
    }

    private static bool TryParseAgainstCurrentValue(object instance, string modify, out object newValue)
    {
        newValue = null!;

        if (string.IsNullOrWhiteSpace(modify))
        {
            return false;
        }

        try
        {
            var currentValue = GetValueField(instance).GetValue(instance);
            if (currentValue == null)
            {
                return false;
            }

            var valueType = currentValue.GetType();
            var currentLocalTime = (System.DateTime)valueType.GetProperty("LocalTime")!.GetValue(currentValue)!;
            var currentLocalTimeZone = (TimeZoneInfo)valueType.GetProperty("LocalTimeZone")!.GetValue(currentValue)!;

            var dateInfoType = typeof(PeachpieDateTime).Assembly.GetType("Pchp.Library.DateTime.DateInfo", throwOnError: true)!;
            var parse = dateInfoType.GetMethod(
                "Parse",
                BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic,
                binder: null,
                types: new[] { typeof(string), typeof(System.DateTime), typeof(TimeZoneInfo).MakeByRefType(), typeof(string).MakeByRefType() },
                modifiers: null);

            if (parse == null)
            {
                return false;
            }

            var args = new object?[] { modify.Trim(), currentLocalTime, currentLocalTimeZone, null };
            var parsedLocalTime = (System.DateTime)parse.Invoke(null, args)!;
            var parsedLocalTimeZone = (TimeZoneInfo)args[2]!;
            var error = args[3] as string;

            if (!string.IsNullOrEmpty(error))
            {
                return false;
            }

            var ctor = GetDateTimeValueType().GetConstructors(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(m =>
                {
                    var ps = m.GetParameters();
                    return ps.Length == 2
                        && ps[0].ParameterType == typeof(System.DateTime)
                        && ps[1].ParameterType == typeof(TimeZoneInfo);
                });

            if (ctor == null)
            {
                return false;
            }

            newValue = ctor.Invoke(new object?[] { parsedLocalTime, parsedLocalTimeZone });
            return true;
        }
        catch (Exception)
        {
            newValue = null!;
            return false;
        }
    }

    private static FieldInfo GetValueField(object instance)
    {
        return instance.GetType().GetField("_value", BindingFlags.Instance | BindingFlags.NonPublic)!;
    }

    private static Type GetDateTimeValueType()
    {
        return typeof(PeachpieDateTime).Assembly.GetType("Pchp.Library.DateTime.DateTimeValue", throwOnError: true)!;
    }

#if DEBUG_PATCH
    #region debug-point D:reporting（仅 DEBUG_PATCH 构建参与编译）
    // 调试插桩：启用后会向本地 debug server 同步上报补丁装配链路事件。
    // 默认 Release 不编译，避免 modify 热路径上每次都触发同步 HTTP。
    internal const string DebugSessionId = "sabre-modify-patch";
    internal const string DebugRunId = "post-fix";
    private static readonly System.Net.Http.HttpClient DebugHttpClient = CreateDebugHttpClient();

    internal static void ReportDebug(string hypothesisId, string location, string msg, object data = null)
    {
        try
        {
            var payload = System.Text.Json.JsonSerializer.Serialize(new
            {
                sessionId = DebugSessionId,
                runId = DebugRunId,
                hypothesisId,
                location,
                msg = "[DEBUG] " + msg,
                data = data ?? new { },
                ts = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
            });

            using var content = new System.Net.Http.StringContent(payload, System.Text.Encoding.UTF8, "application/json");
            DebugHttpClient.PostAsync(GetDebugServerUrl(), content).GetAwaiter().GetResult();
        }
        catch
        {
        }
    }

    private static System.Net.Http.HttpClient CreateDebugHttpClient()
    {
        return new System.Net.Http.HttpClient
        {
            Timeout = TimeSpan.FromMilliseconds(800),
        };
    }

    private static string GetDebugServerUrl()
    {
        try
        {
            var envPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), ".dbg", DebugSessionId + ".env");
            if (System.IO.File.Exists(envPath))
            {
                foreach (var line in System.IO.File.ReadAllLines(envPath))
                {
                    if (line.StartsWith("DEBUG_SERVER_URL=", StringComparison.Ordinal))
                    {
                        return line.Substring("DEBUG_SERVER_URL=".Length).Trim();
                    }
                }
            }
        }
        catch
        {
        }

        return "http://127.0.0.1:7777/event";
    }
    #endregion
#endif
}
