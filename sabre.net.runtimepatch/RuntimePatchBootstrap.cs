using Pchp.Core;

namespace Nextsharp.Sabre.RuntimePatch;

[PhpExtension("nextsharp_sabre_runtime")]
public static class RuntimePatchBootstrap
{
    public static bool nextsharp_sabre_runtime_patch_bootstrap()
    {
#if DEBUG_PATCH
        #region debug-point D:bootstrap
        DateTimeModifyPatch.ReportDebug("D", "RuntimePatchBootstrap.nextsharp_sabre_runtime_patch_bootstrap", "entered php bootstrap");
        #endregion
#endif
        DateTimeModifyPatch.EnsureApplied();
        return true;
    }
}
