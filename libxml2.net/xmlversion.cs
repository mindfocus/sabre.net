using System.Runtime.InteropServices;
using System.Security;

namespace libxml
{
    public unsafe partial class xmlversion
    {
        private const string lib = "/usr/local/Cellar/libxml2/2.9.9_2/lib/libxml2.2.dylib";

        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCheckVersion")]
            internal static extern void XmlCheckVersion(int version);
        }

        public static void XmlCheckVersion(int version)
        {
            __Internal.XmlCheckVersion(version);
        }
    }
}