using Pchp.Core;
using System.Runtime.CompilerServices;

[assembly: PhpExtension("nextsharp_sabre_runtime")]

internal static class NextsharpSabreRuntimeModuleInitializer
{
    [ModuleInitializer]
    internal static void Initialize()
    {
        // 注意：这里不再自动调用 DateTimeModifyPatch.EnsureApplied()。
        // 运行时补丁的装配已统一约定为“显式前置调用”
        // \nextsharp_sabre_runtime_patch_bootstrap()（PHP 路径）或
        // RuntimePatchBootstrap.nextsharp_sabre_runtime_patch_bootstrap()（C# 路径）。
        // 模块初始化器的执行时机在“第一次 modify 调用前”无法保证，曾导致补丁未生效，
        // 因此自动装配路径已被放弃。详见 ADAPTATION.md。
#if DEBUG_PATCH
        #region debug-point D:module-initializer
        Nextsharp.Sabre.RuntimePatch.DateTimeModifyPatch.ReportDebug("D", "NextsharpSabreRuntimeModuleInitializer.Initialize", "module loaded (auto-apply intentionally disabled)");
        #endregion
#endif
    }
}
