using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using libxml;

namespace ConsoleApp1
{
    class Program
    {
        private const string lib = "/usr/local/Cellar/libxml2/2.9.9_2/lib/libxml2.2.dylib";
        [SuppressUnmanagedCodeSecurity]
        [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
            EntryPoint="xmlFreeMutex")]
        internal static extern void XmlFreeMutex(IntPtr tok);
        [SuppressUnmanagedCodeSecurity]
        [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
            EntryPoint="xmlGetThreadId")]
        internal static extern int XmlGetThreadId();

        [SuppressUnmanagedCodeSecurity]
        [DllImport(lib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlBufCreate")]
        internal static extern IntPtr xmlBufCreate();

        [SuppressUnmanagedCodeSecurity]
        [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
            EntryPoint="xmlIsMainThread")]
        internal static extern int XmlIsMainThread();

        [SuppressUnmanagedCodeSecurity]
        [DllImport(lib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlNewTextWriter")]
        internal static extern IntPtr xmlNewTextWriter(IntPtr outputPtr);
        [SuppressUnmanagedCodeSecurity]
        [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
            EntryPoint="xmlBufferCreate")]
        internal static extern global::System.IntPtr XmlBufferCreate();
        [SuppressUnmanagedCodeSecurity]
        [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
            EntryPoint="xmlNewTextWriterMemory")]
        internal static extern IntPtr XmlNewTextWriterMemory(IntPtr buf, int compression);
        [SuppressUnmanagedCodeSecurity]
        [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
            EntryPoint="xmlBufferFree")]
        internal static extern void XmlBufferFree(global::System.IntPtr buf);

        static void Main(string[] args)
        {
            var platform = Environment.OSVersion;
            var mac = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
            // var writer = new MockXmlWriter();
            // writer.open_memory();
            // writer.startDocument();
            // writer.endDocument();
            // var result = writer.output_memory();
            // Console.WriteLine($"Hello World! {result} {XmlIsMainThread()} {XmlGetThreadId()} ");
        }
    }
}