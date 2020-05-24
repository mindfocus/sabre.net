using System.Runtime.InteropServices;
using System.Security;

namespace libxml
{
    /// <summary>
    /// <para>xmlMallocFunc:</para>
    /// <para>the size requested in bytes</para>
    /// </summary>
    /// <remarks>
    /// <para>Signature for a malloc() implementation.</para>
    /// <para>Returns a pointer to the newly allocated block or NULL in case of error.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate global::System.IntPtr XmlMallocFunc(uint size);
}