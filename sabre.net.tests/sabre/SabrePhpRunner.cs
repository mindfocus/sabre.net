using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Pchp.Core;

namespace sabre.net.tests.sabre
{
    internal static class SabrePhpRunner
    {
        private static readonly Context.IScriptingProvider Provider = Context.DefaultScriptingProvider;
        private static readonly string TestTempDir = InitTestTempDir();

        private static string InitTestTempDir()
        {
            var dir = Path.Combine(TestContext.CurrentContext.WorkDirectory, "_sabre_peachpie_test_tmp");
            Directory.CreateDirectory(dir);
            return Path.GetFullPath(dir);
        }

        public static string RunInPeachpie(string phpCode)
        {
            var outputStream = new MemoryStream();
            var tmpFile = Path.Combine(TestTempDir, "test_" + Guid.NewGuid().ToString("N") + ".php");
            var source = NormalizePhpCode(phpCode);

            using (var ctx = Context.CreateEmpty())
            {
                ctx.RootPath = ctx.WorkingDirectory = TestTempDir;
                ctx.Output = new StreamWriter(outputStream, Encoding.UTF8) { AutoFlush = true };
                ctx.OutputStream = outputStream;

                var script = Provider.CreateScript(new Context.ScriptOptions
                {
                    Context = ctx,
                    IsSubmission = false,
                    EmitDebugInformation = true,
                    Location = new Location(tmpFile, 0, 0),
                    AdditionalReferences = GetAdditionalReferences(),
                }, source);

                try
                {
                    script.Evaluate(ctx, ctx.Globals, null);
                }
                catch (ScriptDiedException ex)
                {
                    ex.ProcessStatus(ctx);
                }
            }

            outputStream.Position = 0;
            return new StreamReader(outputStream, Encoding.UTF8).ReadToEnd();
        }

        public static string RunInNativePhp(string phpCode)
        {
            var tmpFile = Path.Combine(Path.GetTempPath(), "sabre_test_" + Guid.NewGuid().ToString("N") + ".php");
            var source = NormalizePhpCode(phpCode);
            try
            {
                File.WriteAllText(tmpFile, source, new UTF8Encoding(false));

                var psi = new ProcessStartInfo("php", $"-d display_errors=Off -d log_errors=Off -d error_reporting=0 \"{tmpFile}\"")
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    StandardOutputEncoding = Encoding.UTF8,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = Path.GetTempPath(),
                };

                using var process = Process.Start(psi);
                var output = process!.StandardOutput.ReadToEnd();
                var error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrEmpty(error) && string.IsNullOrEmpty(output))
                {
                    return "[PHP ERROR] " + error.Trim();
                }

                return output;
            }
            finally
            {
                try
                {
                    File.Delete(tmpFile);
                }
                catch
                {
                }
            }
        }

        private static string NormalizePhpCode(string phpCode)
        {
            if (phpCode == null)
            {
                return "<?php";
            }

            var trimmed = phpCode.TrimStart();
            if (trimmed.StartsWith("<?php", StringComparison.Ordinal))
            {
                return phpCode;
            }

            return "<?php\n" + phpCode;
        }

        private static string[] GetAdditionalReferences()
        {
            var runtimeAsm = typeof(Context).Assembly;
            var baseDir = Path.GetDirectoryName(runtimeAsm.Location)!;
            var sabreAsm = typeof(Sabre.Uri.Version).Assembly.Location;
            var sabreDir = Path.GetDirectoryName(sabreAsm)!;
            var runtimePatchAsm = Path.Combine(sabreDir, "sabre.net.runtimepatch.dll");

            return new[]
            {
                runtimeAsm.Location,
                Path.Combine(baseDir, "Peachpie.Library.dll"),
                sabreAsm,
                runtimePatchAsm,
            }.Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
        }
    }
}
