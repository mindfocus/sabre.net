using System;
using System.Runtime.InteropServices;
using System.Security;

namespace libxml
{
    public unsafe class xmlIO
    {
        private const string lib = "/usr/local/Cellar/libxml2/2.9.9_2/lib/libxml2.2.dylib";

        public struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlCleanupInputCallbacks")]
            internal static extern void XmlCleanupInputCallbacks();

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlPopInputCallbacks")]
            internal static extern int XmlPopInputCallbacks();

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlRegisterDefaultInputCallbacks")]
            internal static extern void XmlRegisterDefaultInputCallbacks();

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlAllocParserInputBuffer")]
            internal static extern IntPtr XmlAllocParserInputBuffer(XmlCharEncoding enc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlParserInputBufferCreateFilename")]
            internal static extern IntPtr XmlParserInputBufferCreateFilename([MarshalAs(UnmanagedType.LPUTF8Str)] string URI, XmlCharEncoding enc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlParserInputBufferCreateFile")]
            internal static extern IntPtr XmlParserInputBufferCreateFile(IntPtr file, XmlCharEncoding enc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlParserInputBufferCreateFd")]
            internal static extern IntPtr XmlParserInputBufferCreateFd(int fd, XmlCharEncoding enc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlParserInputBufferCreateMem")]
            internal static extern IntPtr XmlParserInputBufferCreateMem([MarshalAs(UnmanagedType.LPUTF8Str)] string mem, int size, XmlCharEncoding enc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlParserInputBufferCreateStatic")]
            internal static extern IntPtr XmlParserInputBufferCreateStatic([MarshalAs(UnmanagedType.LPUTF8Str)] string mem, int size, XmlCharEncoding enc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlParserInputBufferCreateIO")]
            internal static extern IntPtr XmlParserInputBufferCreateIO(IntPtr ioread, IntPtr ioclose, IntPtr ioctx, XmlCharEncoding enc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlParserInputBufferRead")]
            internal static extern int XmlParserInputBufferRead(IntPtr @in, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlParserInputBufferGrow")]
            internal static extern int XmlParserInputBufferGrow(IntPtr @in, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlParserInputBufferPush")]
            internal static extern int XmlParserInputBufferPush(IntPtr @in, int len, [MarshalAs(UnmanagedType.LPUTF8Str)] string buf);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlFreeParserInputBuffer")]
            internal static extern void XmlFreeParserInputBuffer(IntPtr @in);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlParserGetDirectory")]
            internal static extern sbyte* XmlParserGetDirectory([MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlRegisterInputCallbacks")]
            internal static extern int XmlRegisterInputCallbacks(IntPtr matchFunc, IntPtr openFunc, IntPtr readFunc, IntPtr closeFunc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="__xmlParserInputBufferCreateFilename")]
            internal static extern IntPtr __xmlParserInputBufferCreateFilename([MarshalAs(UnmanagedType.LPUTF8Str)] string URI, XmlCharEncoding enc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlCleanupOutputCallbacks")]
            internal static extern void XmlCleanupOutputCallbacks();

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlRegisterDefaultOutputCallbacks")]
            internal static extern void XmlRegisterDefaultOutputCallbacks();

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlAllocOutputBuffer")]
            internal static extern IntPtr XmlAllocOutputBuffer(IntPtr encoder);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlOutputBufferCreateFilename")]
            internal static extern IntPtr XmlOutputBufferCreateFilename([MarshalAs(UnmanagedType.LPUTF8Str)] string URI, IntPtr encoder, int compression);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlOutputBufferCreateFile")]
            internal static extern IntPtr XmlOutputBufferCreateFile(IntPtr file, IntPtr encoder);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlOutputBufferCreateBuffer")]
            internal static extern IntPtr XmlOutputBufferCreateBuffer(IntPtr buffer, IntPtr encoder);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlOutputBufferCreateFd")]
            internal static extern IntPtr XmlOutputBufferCreateFd(int fd, IntPtr encoder);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlOutputBufferCreateIO")]
            internal static extern IntPtr XmlOutputBufferCreateIO(IntPtr iowrite, IntPtr ioclose, IntPtr ioctx, IntPtr encoder);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlOutputBufferGetContent")]
            internal static extern byte* XmlOutputBufferGetContent(IntPtr @out);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlOutputBufferGetSize")]
            internal static extern uint XmlOutputBufferGetSize(IntPtr @out);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlOutputBufferWrite")]
            internal static extern int XmlOutputBufferWrite(IntPtr @out, int len, [MarshalAs(UnmanagedType.LPUTF8Str)] string buf);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlOutputBufferWriteString")]
            internal static extern int XmlOutputBufferWriteString(IntPtr @out, [MarshalAs(UnmanagedType.LPUTF8Str)] string str);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlOutputBufferWriteEscape")]
            internal static extern int XmlOutputBufferWriteEscape(IntPtr @out, byte* str, IntPtr escaping);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlOutputBufferFlush")]
            internal static extern int XmlOutputBufferFlush(IntPtr @out);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlOutputBufferClose")]
            internal static extern int XmlOutputBufferClose(IntPtr @out);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlRegisterOutputCallbacks")]
            internal static extern int XmlRegisterOutputCallbacks(IntPtr matchFunc, IntPtr openFunc, IntPtr writeFunc, IntPtr closeFunc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="__xmlOutputBufferCreateFilename")]
            internal static extern IntPtr __xmlOutputBufferCreateFilename([MarshalAs(UnmanagedType.LPUTF8Str)] string URI, IntPtr encoder, int compression);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlRegisterHTTPPostCallbacks")]
            internal static extern void XmlRegisterHTTPPostCallbacks();

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlCheckHTTPInput")]
            internal static extern IntPtr XmlCheckHTTPInput(IntPtr ctxt, IntPtr ret);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlNoNetExternalEntityLoader")]
            internal static extern IntPtr XmlNoNetExternalEntityLoader([MarshalAs(UnmanagedType.LPUTF8Str)] string URL, [MarshalAs(UnmanagedType.LPUTF8Str)] string ID, IntPtr ctxt);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlNormalizeWindowsPath")]
            internal static extern byte* XmlNormalizeWindowsPath(byte* path);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlCheckFilename")]
            internal static extern int XmlCheckFilename([MarshalAs(UnmanagedType.LPUTF8Str)] string path);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlFileMatch")]
            internal static extern int XmlFileMatch([MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlFileOpen")]
            internal static extern IntPtr XmlFileOpen([MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlFileRead")]
            internal static extern int XmlFileRead(IntPtr context, sbyte* buffer, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlFileClose")]
            internal static extern int XmlFileClose(IntPtr context);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlIOHTTPMatch")]
            internal static extern int XmlIOHTTPMatch([MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlIOHTTPOpen")]
            internal static extern IntPtr XmlIOHTTPOpen([MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlIOHTTPOpenW")]
            internal static extern IntPtr XmlIOHTTPOpenW([MarshalAs(UnmanagedType.LPUTF8Str)] string post_uri, int compression);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlIOHTTPRead")]
            internal static extern int XmlIOHTTPRead(IntPtr context, sbyte* buffer, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlIOHTTPClose")]
            internal static extern int XmlIOHTTPClose(IntPtr context);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlIOFTPMatch")]
            internal static extern int XmlIOFTPMatch([MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlIOFTPOpen")]
            internal static extern IntPtr XmlIOFTPOpen([MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlIOFTPRead")]
            internal static extern int XmlIOFTPRead(IntPtr context, sbyte* buffer, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlIOFTPClose")]
            internal static extern int XmlIOFTPClose(IntPtr context);
        }

        public static void XmlCleanupInputCallbacks()
        {
            __Internal.XmlCleanupInputCallbacks();
        }

        public static int XmlPopInputCallbacks()
        {
            var __ret = __Internal.XmlPopInputCallbacks();
            return __ret;
        }

        public static void XmlRegisterDefaultInputCallbacks()
        {
            __Internal.XmlRegisterDefaultInputCallbacks();
        }

        public static XmlParserInputBuffer XmlAllocParserInputBuffer(XmlCharEncoding enc)
        {
            var __ret = __Internal.XmlAllocParserInputBuffer(enc);
            XmlParserInputBuffer __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (XmlParserInputBuffer.NativeToManagedMap.ContainsKey(__ret))
                __result0 = XmlParserInputBuffer.NativeToManagedMap[__ret];
            else __result0 = XmlParserInputBuffer.__CreateInstance(__ret);
            return __result0;
        }

        public static XmlParserInputBuffer XmlParserInputBufferCreateFilename(string URI, XmlCharEncoding enc)
        {
            var __ret = __Internal.XmlParserInputBufferCreateFilename(URI, enc);
            XmlParserInputBuffer __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (XmlParserInputBuffer.NativeToManagedMap.ContainsKey(__ret))
                __result0 = XmlParserInputBuffer.NativeToManagedMap[__ret];
            else __result0 = XmlParserInputBuffer.__CreateInstance(__ret);
            return __result0;
        }

        public static XmlParserInputBuffer XmlParserInputBufferCreateFile(IntPtr file, XmlCharEncoding enc)
        {
            var __ret = __Internal.XmlParserInputBufferCreateFile(file, enc);
            XmlParserInputBuffer __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (XmlParserInputBuffer.NativeToManagedMap.ContainsKey(__ret))
                __result0 = XmlParserInputBuffer.NativeToManagedMap[__ret];
            else __result0 = XmlParserInputBuffer.__CreateInstance(__ret);
            return __result0;
        }

        public static XmlParserInputBuffer XmlParserInputBufferCreateFd(int fd, XmlCharEncoding enc)
        {
            var __ret = __Internal.XmlParserInputBufferCreateFd(fd, enc);
            XmlParserInputBuffer __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (XmlParserInputBuffer.NativeToManagedMap.ContainsKey(__ret))
                __result0 = XmlParserInputBuffer.NativeToManagedMap[__ret];
            else __result0 = XmlParserInputBuffer.__CreateInstance(__ret);
            return __result0;
        }

        public static XmlParserInputBuffer XmlParserInputBufferCreateMem(string mem, int size, XmlCharEncoding enc)
        {
            var __ret = __Internal.XmlParserInputBufferCreateMem(mem, size, enc);
            XmlParserInputBuffer __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (XmlParserInputBuffer.NativeToManagedMap.ContainsKey(__ret))
                __result0 = XmlParserInputBuffer.NativeToManagedMap[__ret];
            else __result0 = XmlParserInputBuffer.__CreateInstance(__ret);
            return __result0;
        }

        public static XmlParserInputBuffer XmlParserInputBufferCreateStatic(string mem, int size, XmlCharEncoding enc)
        {
            var __ret = __Internal.XmlParserInputBufferCreateStatic(mem, size, enc);
            XmlParserInputBuffer __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (XmlParserInputBuffer.NativeToManagedMap.ContainsKey(__ret))
                __result0 = XmlParserInputBuffer.NativeToManagedMap[__ret];
            else __result0 = XmlParserInputBuffer.__CreateInstance(__ret);
            return __result0;
        }

        public static XmlParserInputBuffer XmlParserInputBufferCreateIO(XmlInputReadCallback ioread, XmlInputCloseCallback ioclose, IntPtr ioctx, XmlCharEncoding enc)
        {
            var __arg0 = ioread == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(ioread);
            var __arg1 = ioclose == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(ioclose);
            var __ret = __Internal.XmlParserInputBufferCreateIO(__arg0, __arg1, ioctx, enc);
            XmlParserInputBuffer __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (XmlParserInputBuffer.NativeToManagedMap.ContainsKey(__ret))
                __result0 = XmlParserInputBuffer.NativeToManagedMap[__ret];
            else __result0 = XmlParserInputBuffer.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlParserInputBufferRead(XmlParserInputBuffer @in, int len)
        {
            var __arg0 = ReferenceEquals(@in, null) ? IntPtr.Zero : @in.__Instance;
            var __ret = __Internal.XmlParserInputBufferRead(__arg0, len);
            return __ret;
        }

        public static int XmlParserInputBufferGrow(XmlParserInputBuffer @in, int len)
        {
            var __arg0 = ReferenceEquals(@in, null) ? IntPtr.Zero : @in.__Instance;
            var __ret = __Internal.XmlParserInputBufferGrow(__arg0, len);
            return __ret;
        }

        public static int XmlParserInputBufferPush(XmlParserInputBuffer @in, int len, string buf)
        {
            var __arg0 = ReferenceEquals(@in, null) ? IntPtr.Zero : @in.__Instance;
            var __ret = __Internal.XmlParserInputBufferPush(__arg0, len, buf);
            return __ret;
        }

        public static void XmlFreeParserInputBuffer(XmlParserInputBuffer @in)
        {
            var __arg0 = ReferenceEquals(@in, null) ? IntPtr.Zero : @in.__Instance;
            __Internal.XmlFreeParserInputBuffer(__arg0);
        }

        public static sbyte* XmlParserGetDirectory(string filename)
        {
            var __ret = __Internal.XmlParserGetDirectory(filename);
            return __ret;
        }

        public static int XmlRegisterInputCallbacks(XmlInputMatchCallback matchFunc, XmlInputOpenCallback openFunc, XmlInputReadCallback readFunc, XmlInputCloseCallback closeFunc)
        {
            var __arg0 = matchFunc == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(matchFunc);
            var __arg1 = openFunc == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(openFunc);
            var __arg2 = readFunc == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(readFunc);
            var __arg3 = closeFunc == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(closeFunc);
            var __ret = __Internal.XmlRegisterInputCallbacks(__arg0, __arg1, __arg2, __arg3);
            return __ret;
        }

        public static XmlParserInputBuffer __xmlParserInputBufferCreateFilename(string URI, XmlCharEncoding enc)
        {
            var __ret = __Internal.__xmlParserInputBufferCreateFilename(URI, enc);
            XmlParserInputBuffer __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (XmlParserInputBuffer.NativeToManagedMap.ContainsKey(__ret))
                __result0 = XmlParserInputBuffer.NativeToManagedMap[__ret];
            else __result0 = XmlParserInputBuffer.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlCleanupOutputCallbacks()
        {
            __Internal.XmlCleanupOutputCallbacks();
        }

        public static void XmlRegisterDefaultOutputCallbacks()
        {
            __Internal.XmlRegisterDefaultOutputCallbacks();
        }

        public static XmlOutputBuffer XmlAllocOutputBuffer(XmlCharEncodingHandler encoder)
        {
            var __arg0 = ReferenceEquals(encoder, null) ? IntPtr.Zero : encoder.__Instance;
            var __ret = __Internal.XmlAllocOutputBuffer(__arg0);
            XmlOutputBuffer __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (XmlOutputBuffer.NativeToManagedMap.ContainsKey(__ret))
                __result0 = XmlOutputBuffer.NativeToManagedMap[__ret];
            else __result0 = XmlOutputBuffer.__CreateInstance(__ret);
            return __result0;
        }

        public static XmlOutputBuffer XmlOutputBufferCreateFilename(string URI, XmlCharEncodingHandler encoder, int compression)
        {
            var __arg1 = ReferenceEquals(encoder, null) ? IntPtr.Zero : encoder.__Instance;
            var __ret = __Internal.XmlOutputBufferCreateFilename(URI, __arg1, compression);
            XmlOutputBuffer __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (XmlOutputBuffer.NativeToManagedMap.ContainsKey(__ret))
                __result0 = XmlOutputBuffer.NativeToManagedMap[__ret];
            else __result0 = XmlOutputBuffer.__CreateInstance(__ret);
            return __result0;
        }

        public static XmlOutputBuffer XmlOutputBufferCreateFile(IntPtr file, XmlCharEncodingHandler encoder)
        {
            var __arg1 = ReferenceEquals(encoder, null) ? IntPtr.Zero : encoder.__Instance;
            var __ret = __Internal.XmlOutputBufferCreateFile(file, __arg1);
            XmlOutputBuffer __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (XmlOutputBuffer.NativeToManagedMap.ContainsKey(__ret))
                __result0 = XmlOutputBuffer.NativeToManagedMap[__ret];
            else __result0 = XmlOutputBuffer.__CreateInstance(__ret);
            return __result0;
        }

        public static XmlOutputBuffer XmlOutputBufferCreateBuffer(XmlBuffer buffer, XmlCharEncodingHandler encoder)
        {
            var __arg0 = ReferenceEquals(buffer, null) ? IntPtr.Zero : buffer.__Instance;
            var __arg1 = ReferenceEquals(encoder, null) ? IntPtr.Zero : encoder.__Instance;
            var __ret = __Internal.XmlOutputBufferCreateBuffer(__arg0, __arg1);
            XmlOutputBuffer __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (XmlOutputBuffer.NativeToManagedMap.ContainsKey(__ret))
                __result0 = XmlOutputBuffer.NativeToManagedMap[__ret];
            else __result0 = XmlOutputBuffer.__CreateInstance(__ret);
            return __result0;
        }

        public static XmlOutputBuffer XmlOutputBufferCreateFd(int fd, XmlCharEncodingHandler encoder)
        {
            var __arg1 = ReferenceEquals(encoder, null) ? IntPtr.Zero : encoder.__Instance;
            var __ret = __Internal.XmlOutputBufferCreateFd(fd, __arg1);
            XmlOutputBuffer __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (XmlOutputBuffer.NativeToManagedMap.ContainsKey(__ret))
                __result0 = XmlOutputBuffer.NativeToManagedMap[__ret];
            else __result0 = XmlOutputBuffer.__CreateInstance(__ret);
            return __result0;
        }

        public static XmlOutputBuffer XmlOutputBufferCreateIO(XmlOutputWriteCallback iowrite, XmlOutputCloseCallback ioclose, IntPtr ioctx, XmlCharEncodingHandler encoder)
        {
            var __arg0 = iowrite == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(iowrite);
            var __arg1 = ioclose == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(ioclose);
            var __arg3 = ReferenceEquals(encoder, null) ? IntPtr.Zero : encoder.__Instance;
            var __ret = __Internal.XmlOutputBufferCreateIO(__arg0, __arg1, ioctx, __arg3);
            XmlOutputBuffer __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (XmlOutputBuffer.NativeToManagedMap.ContainsKey(__ret))
                __result0 = XmlOutputBuffer.NativeToManagedMap[__ret];
            else __result0 = XmlOutputBuffer.__CreateInstance(__ret);
            return __result0;
        }

        public static byte* XmlOutputBufferGetContent(XmlOutputBuffer @out)
        {
            var __arg0 = ReferenceEquals(@out, null) ? IntPtr.Zero : @out.__Instance;
            var __ret = __Internal.XmlOutputBufferGetContent(__arg0);
            return __ret;
        }

        public static uint XmlOutputBufferGetSize(XmlOutputBuffer @out)
        {
            var __arg0 = ReferenceEquals(@out, null) ? IntPtr.Zero : @out.__Instance;
            var __ret = __Internal.XmlOutputBufferGetSize(__arg0);
            return __ret;
        }

        public static int XmlOutputBufferWrite(XmlOutputBuffer @out, int len, string buf)
        {
            var __arg0 = ReferenceEquals(@out, null) ? IntPtr.Zero : @out.__Instance;
            var __ret = __Internal.XmlOutputBufferWrite(__arg0, len, buf);
            return __ret;
        }

        public static int XmlOutputBufferWriteString(XmlOutputBuffer @out, string str)
        {
            var __arg0 = ReferenceEquals(@out, null) ? IntPtr.Zero : @out.__Instance;
            var __ret = __Internal.XmlOutputBufferWriteString(__arg0, str);
            return __ret;
        }

        public static int XmlOutputBufferWriteEscape(XmlOutputBuffer @out, byte* str, XmlCharEncodingOutputFunc escaping)
        {
            var __arg0 = ReferenceEquals(@out, null) ? IntPtr.Zero : @out.__Instance;
            var __arg2 = escaping == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(escaping);
            var __ret = __Internal.XmlOutputBufferWriteEscape(__arg0, str, __arg2);
            return __ret;
        }

        public static int XmlOutputBufferFlush(XmlOutputBuffer @out)
        {
            var __arg0 = ReferenceEquals(@out, null) ? IntPtr.Zero : @out.__Instance;
            var __ret = __Internal.XmlOutputBufferFlush(__arg0);
            return __ret;
        }

        public static int XmlOutputBufferClose(XmlOutputBuffer @out)
        {
            var __arg0 = ReferenceEquals(@out, null) ? IntPtr.Zero : @out.__Instance;
            var __ret = __Internal.XmlOutputBufferClose(__arg0);
            return __ret;
        }

        public static int XmlRegisterOutputCallbacks(XmlOutputMatchCallback matchFunc, XmlOutputOpenCallback openFunc, XmlOutputWriteCallback writeFunc, XmlOutputCloseCallback closeFunc)
        {
            var __arg0 = matchFunc == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(matchFunc);
            var __arg1 = openFunc == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(openFunc);
            var __arg2 = writeFunc == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(writeFunc);
            var __arg3 = closeFunc == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(closeFunc);
            var __ret = __Internal.XmlRegisterOutputCallbacks(__arg0, __arg1, __arg2, __arg3);
            return __ret;
        }

        public static XmlOutputBuffer __xmlOutputBufferCreateFilename(string URI, XmlCharEncodingHandler encoder, int compression)
        {
            var __arg1 = ReferenceEquals(encoder, null) ? IntPtr.Zero : encoder.__Instance;
            var __ret = __Internal.__xmlOutputBufferCreateFilename(URI, __arg1, compression);
            XmlOutputBuffer __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (XmlOutputBuffer.NativeToManagedMap.ContainsKey(__ret))
                __result0 = XmlOutputBuffer.NativeToManagedMap[__ret];
            else __result0 = XmlOutputBuffer.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlRegisterHTTPPostCallbacks()
        {
            __Internal.XmlRegisterHTTPPostCallbacks();
        }

        public static XmlParserInput XmlCheckHTTPInput(XmlParserCtxt ctxt, XmlParserInput ret)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(ret, null) ? IntPtr.Zero : ret.__Instance;
            var __ret = __Internal.XmlCheckHTTPInput(__arg0, __arg1);
            XmlParserInput __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (XmlParserInput.NativeToManagedMap.ContainsKey(__ret))
                __result0 = XmlParserInput.NativeToManagedMap[__ret];
            else __result0 = XmlParserInput.__CreateInstance(__ret);
            return __result0;
        }

        public static XmlParserInput XmlNoNetExternalEntityLoader(string URL, string ID, XmlParserCtxt ctxt)
        {
            var __arg2 = ReferenceEquals(ctxt, null) ? IntPtr.Zero : ctxt.__Instance;
            var __ret = __Internal.XmlNoNetExternalEntityLoader(URL, ID, __arg2);
            XmlParserInput __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (XmlParserInput.NativeToManagedMap.ContainsKey(__ret))
                __result0 = XmlParserInput.NativeToManagedMap[__ret];
            else __result0 = XmlParserInput.__CreateInstance(__ret);
            return __result0;
        }

        public static byte* XmlNormalizeWindowsPath(byte* path)
        {
            var __ret = __Internal.XmlNormalizeWindowsPath(path);
            return __ret;
        }

        public static int XmlCheckFilename(string path)
        {
            var __ret = __Internal.XmlCheckFilename(path);
            return __ret;
        }

        /// <summary>Default 'file://' protocol callbacks</summary>
        public static int XmlFileMatch(string filename)
        {
            var __ret = __Internal.XmlFileMatch(filename);
            return __ret;
        }

        public static IntPtr XmlFileOpen(string filename)
        {
            var __ret = __Internal.XmlFileOpen(filename);
            return __ret;
        }

        public static int XmlFileRead(IntPtr context, sbyte* buffer, int len)
        {
            var __ret = __Internal.XmlFileRead(context, buffer, len);
            return __ret;
        }

        public static int XmlFileClose(IntPtr context)
        {
            var __ret = __Internal.XmlFileClose(context);
            return __ret;
        }

        public static int XmlIOHTTPMatch(string filename)
        {
            var __ret = __Internal.XmlIOHTTPMatch(filename);
            return __ret;
        }

        public static IntPtr XmlIOHTTPOpen(string filename)
        {
            var __ret = __Internal.XmlIOHTTPOpen(filename);
            return __ret;
        }

        public static IntPtr XmlIOHTTPOpenW(string post_uri, int compression)
        {
            var __ret = __Internal.XmlIOHTTPOpenW(post_uri, compression);
            return __ret;
        }

        public static int XmlIOHTTPRead(IntPtr context, sbyte* buffer, int len)
        {
            var __ret = __Internal.XmlIOHTTPRead(context, buffer, len);
            return __ret;
        }

        public static int XmlIOHTTPClose(IntPtr context)
        {
            var __ret = __Internal.XmlIOHTTPClose(context);
            return __ret;
        }

        public static int XmlIOFTPMatch(string filename)
        {
            var __ret = __Internal.XmlIOFTPMatch(filename);
            return __ret;
        }

        public static IntPtr XmlIOFTPOpen(string filename)
        {
            var __ret = __Internal.XmlIOFTPOpen(filename);
            return __ret;
        }

        public static int XmlIOFTPRead(IntPtr context, sbyte* buffer, int len)
        {
            var __ret = __Internal.XmlIOFTPRead(context, buffer, len);
            return __ret;
        }

        public static int XmlIOFTPClose(IntPtr context)
        {
            var __ret = __Internal.XmlIOFTPClose(context);
            return __ret;
        }
    }
}