using System;
using System.Runtime.InteropServices;
using System.Security;

namespace libxml
{
    /// <summary>
    /// <para>xmlInputMatchCallback:</para>
    /// <para>the filename or URI</para>
    /// </summary>
    /// <remarks>
    /// <para>Callback used in the I/O Input API to detect if the current handler</para>
    /// <para>can provide input fonctionnalities for this resource.</para>
    /// <para>Returns 1 if yes and 0 if another Input module should be used</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate int XmlInputMatchCallback([MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

    /// <summary>
    /// <para>xmlInputOpenCallback:</para>
    /// <para>the filename or URI</para>
    /// </summary>
    /// <remarks>
    /// <para>Callback used in the I/O Input API to open the resource</para>
    /// <para>Returns an Input context or NULL in case or error</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate global::System.IntPtr XmlInputOpenCallback([MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

    /// <summary>
    /// <para>xmlInputReadCallback:</para>
    /// <para>an Input context</para>
    /// <para>the buffer to store data read</para>
    /// <para>the length of the buffer in bytes</para>
    /// </summary>
    /// <remarks>
    /// <para>Callback used in the I/O Input API to read the resource</para>
    /// <para>Returns the number of bytes read or -1 in case of error</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate int XmlInputReadCallback(global::System.IntPtr context, sbyte* buffer, int len);

    /// <summary>
    /// <para>xmlInputCloseCallback:</para>
    /// <para>an Input context</para>
    /// </summary>
    /// <remarks>
    /// <para>Callback used in the I/O Input API to close the resource</para>
    /// <para>Returns 0 or -1 in case of error</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate int XmlInputCloseCallback(global::System.IntPtr context);

    /// <summary>
    /// <para>xmlOutputMatchCallback:</para>
    /// <para>the filename or URI</para>
    /// </summary>
    /// <remarks>
    /// <para>Callback used in the I/O Output API to detect if the current handler</para>
    /// <para>can provide output fonctionnalities for this resource.</para>
    /// <para>Returns 1 if yes and 0 if another Output module should be used</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate int XmlOutputMatchCallback([MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

    /// <summary>
    /// <para>xmlOutputOpenCallback:</para>
    /// <para>the filename or URI</para>
    /// </summary>
    /// <remarks>
    /// <para>Callback used in the I/O Output API to open the resource</para>
    /// <para>Returns an Output context or NULL in case or error</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate global::System.IntPtr XmlOutputOpenCallback([MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

    /// <summary>
    /// <para>xmlOutputWriteCallback:</para>
    /// <para>an Output context</para>
    /// <para>the buffer of data to write</para>
    /// <para>the length of the buffer in bytes</para>
    /// </summary>
    /// <remarks>
    /// <para>Callback used in the I/O Output API to write to the resource</para>
    /// <para>Returns the number of bytes written or -1 in case of error</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate int XmlOutputWriteCallback(global::System.IntPtr context, [MarshalAs(UnmanagedType.LPUTF8Str)] string buffer, int len);

    /// <summary>
    /// <para>xmlOutputCloseCallback:</para>
    /// <para>an Output context</para>
    /// </summary>
    /// <remarks>
    /// <para>Callback used in the I/O Output API to close the resource</para>
    /// <para>Returns 0 or -1 in case of error</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate int XmlOutputCloseCallback(global::System.IntPtr context);

    public unsafe partial class XmlParserInputBuffer : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 36)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr context;

            [FieldOffset(4)]
            internal global::System.IntPtr readcallback;

            [FieldOffset(8)]
            internal global::System.IntPtr closecallback;

            [FieldOffset(12)]
            internal global::System.IntPtr encoder;

            [FieldOffset(16)]
            internal global::System.IntPtr buffer;

            [FieldOffset(20)]
            internal global::System.IntPtr raw;

            [FieldOffset(24)]
            internal int compressed;

            [FieldOffset(28)]
            internal int error;

            [FieldOffset(32)]
            internal uint rawconsumed;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN21_xmlParserInputBufferC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlParserInputBuffer> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlParserInputBuffer>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlParserInputBuffer __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlParserInputBuffer(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlParserInputBuffer __CreateInstance(global::libxml.XmlParserInputBuffer.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlParserInputBuffer(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlParserInputBuffer.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlParserInputBuffer.__Internal));
            *(global::libxml.XmlParserInputBuffer.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlParserInputBuffer(global::libxml.XmlParserInputBuffer.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlParserInputBuffer(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlParserInputBuffer()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlParserInputBuffer.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlParserInputBuffer(global::libxml.XmlParserInputBuffer _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlParserInputBuffer.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlParserInputBuffer.__Internal*) __Instance) = *((global::libxml.XmlParserInputBuffer.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlParserInputBuffer __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public global::System.IntPtr Context
        {
            get
            {
                return ((global::libxml.XmlParserInputBuffer.__Internal*) __Instance)->context;
            }

            set
            {
                ((global::libxml.XmlParserInputBuffer.__Internal*)__Instance)->context = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlInputReadCallback Readcallback
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlParserInputBuffer.__Internal*) __Instance)->readcallback;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlInputReadCallback) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlInputReadCallback));
            }

            set
            {
                ((global::libxml.XmlParserInputBuffer.__Internal*)__Instance)->readcallback = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.XmlInputCloseCallback Closecallback
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlParserInputBuffer.__Internal*) __Instance)->closecallback;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlInputCloseCallback) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlInputCloseCallback));
            }

            set
            {
                ((global::libxml.XmlParserInputBuffer.__Internal*)__Instance)->closecallback = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.XmlCharEncodingHandler Encoder
        {
            get
            {
                global::libxml.XmlCharEncodingHandler __result0;
                if (((global::libxml.XmlParserInputBuffer.__Internal*) __Instance)->encoder == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlCharEncodingHandler.NativeToManagedMap.ContainsKey(((global::libxml.XmlParserInputBuffer.__Internal*) __Instance)->encoder))
                    __result0 = (global::libxml.XmlCharEncodingHandler) global::libxml.XmlCharEncodingHandler.NativeToManagedMap[((global::libxml.XmlParserInputBuffer.__Internal*) __Instance)->encoder];
                else __result0 = global::libxml.XmlCharEncodingHandler.__CreateInstance(((global::libxml.XmlParserInputBuffer.__Internal*) __Instance)->encoder);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlParserInputBuffer.__Internal*)__Instance)->encoder = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlBuf Buffer
        {
            get
            {
                global::libxml.XmlBuf __result0;
                if (((global::libxml.XmlParserInputBuffer.__Internal*) __Instance)->buffer == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlBuf.NativeToManagedMap.ContainsKey(((global::libxml.XmlParserInputBuffer.__Internal*) __Instance)->buffer))
                    __result0 = (global::libxml.XmlBuf) global::libxml.XmlBuf.NativeToManagedMap[((global::libxml.XmlParserInputBuffer.__Internal*) __Instance)->buffer];
                else __result0 = global::libxml.XmlBuf.__CreateInstance(((global::libxml.XmlParserInputBuffer.__Internal*) __Instance)->buffer);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlParserInputBuffer.__Internal*)__Instance)->buffer = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlBuf Raw
        {
            get
            {
                global::libxml.XmlBuf __result0;
                if (((global::libxml.XmlParserInputBuffer.__Internal*) __Instance)->raw == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlBuf.NativeToManagedMap.ContainsKey(((global::libxml.XmlParserInputBuffer.__Internal*) __Instance)->raw))
                    __result0 = (global::libxml.XmlBuf) global::libxml.XmlBuf.NativeToManagedMap[((global::libxml.XmlParserInputBuffer.__Internal*) __Instance)->raw];
                else __result0 = global::libxml.XmlBuf.__CreateInstance(((global::libxml.XmlParserInputBuffer.__Internal*) __Instance)->raw);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlParserInputBuffer.__Internal*)__Instance)->raw = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public int Compressed
        {
            get
            {
                return ((global::libxml.XmlParserInputBuffer.__Internal*) __Instance)->compressed;
            }

            set
            {
                ((global::libxml.XmlParserInputBuffer.__Internal*)__Instance)->compressed = value;
            }
        }

        public int Error
        {
            get
            {
                return ((global::libxml.XmlParserInputBuffer.__Internal*) __Instance)->error;
            }

            set
            {
                ((global::libxml.XmlParserInputBuffer.__Internal*)__Instance)->error = value;
            }
        }

        public uint Rawconsumed
        {
            get
            {
                return ((global::libxml.XmlParserInputBuffer.__Internal*) __Instance)->rawconsumed;
            }

            set
            {
                ((global::libxml.XmlParserInputBuffer.__Internal*)__Instance)->rawconsumed = value;
            }
        }
    }

    /// <summary>xmlChar:</summary>
    /// <remarks>
    /// <para>This is a basic byte in an UTF-8 encoded string.</para>
    /// <para>It's unsigned allowing to pinpoint case where char * are assigned</para>
    /// <para>to xmlChar * (possibly making serialization back impossible).</para>
    /// </remarks>
    public unsafe partial class xmlstring
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlStrdup")]
            internal static extern byte* XmlStrdup(byte* cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlStrndup")]
            internal static extern byte* XmlStrndup(byte* cur, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCharStrndup")]
            internal static extern byte* XmlCharStrndup([MarshalAs(UnmanagedType.LPUTF8Str)] string cur, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCharStrdup")]
            internal static extern byte* XmlCharStrdup([MarshalAs(UnmanagedType.LPUTF8Str)] string cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlStrsub")]
            internal static extern byte* XmlStrsub(byte* str, int start, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlStrchr")]
            internal static extern byte* XmlStrchr(byte* str, byte val);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlStrstr")]
            internal static extern byte* XmlStrstr(byte* str, byte* val);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlStrcasestr")]
            internal static extern byte* XmlStrcasestr(byte* str, byte* val);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlStrcmp")]
            internal static extern int XmlStrcmp(byte* str1, byte* str2);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlStrncmp")]
            internal static extern int XmlStrncmp(byte* str1, byte* str2, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlStrcasecmp")]
            internal static extern int XmlStrcasecmp(byte* str1, byte* str2);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlStrncasecmp")]
            internal static extern int XmlStrncasecmp(byte* str1, byte* str2, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlStrEqual")]
            internal static extern int XmlStrEqual(byte* str1, byte* str2);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlStrQEqual")]
            internal static extern int XmlStrQEqual(byte* pref, byte* name, byte* str);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlStrlen")]
            internal static extern int XmlStrlen(byte* str);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlStrcat")]
            internal static extern byte* XmlStrcat(byte* cur, byte* add);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlStrncat")]
            internal static extern byte* XmlStrncat(byte* cur, byte* add, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlStrncatNew")]
            internal static extern byte* XmlStrncatNew(byte* str1, byte* str2, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlStrPrintf")]
            internal static extern int XmlStrPrintf(byte* buf, int len, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetUTF8Char")]
            internal static extern int XmlGetUTF8Char(byte* utf, int* len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCheckUTF8")]
            internal static extern int XmlCheckUTF8(byte* utf);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlUTF8Strsize")]
            internal static extern int XmlUTF8Strsize(byte* utf, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlUTF8Strndup")]
            internal static extern byte* XmlUTF8Strndup(byte* utf, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlUTF8Strpos")]
            internal static extern byte* XmlUTF8Strpos(byte* utf, int pos);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlUTF8Strloc")]
            internal static extern int XmlUTF8Strloc(byte* utf, byte* utfchar);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlUTF8Strsub")]
            internal static extern byte* XmlUTF8Strsub(byte* utf, int start, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlUTF8Strlen")]
            internal static extern int XmlUTF8Strlen(byte* utf);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlUTF8Size")]
            internal static extern int XmlUTF8Size(byte* utf);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlUTF8Charcmp")]
            internal static extern int XmlUTF8Charcmp(byte* utf1, byte* utf2);
        }

        public static byte* XmlStrdup(byte* cur)
        {
            var __ret = __Internal.XmlStrdup(cur);
            return __ret;
        }

        public static byte* XmlStrndup(byte* cur, int len)
        {
            var __ret = __Internal.XmlStrndup(cur, len);
            return __ret;
        }

        public static byte* XmlCharStrndup(string cur, int len)
        {
            var __ret = __Internal.XmlCharStrndup(cur, len);
            return __ret;
        }

        public static byte* XmlCharStrdup(string cur)
        {
            var __ret = __Internal.XmlCharStrdup(cur);
            return __ret;
        }

        public static byte* XmlStrsub(byte* str, int start, int len)
        {
            var __ret = __Internal.XmlStrsub(str, start, len);
            return __ret;
        }

        public static byte* XmlStrchr(byte* str, byte val)
        {
            var __ret = __Internal.XmlStrchr(str, val);
            return __ret;
        }

        public static byte* XmlStrstr(byte* str, byte* val)
        {
            var __ret = __Internal.XmlStrstr(str, val);
            return __ret;
        }

        public static byte* XmlStrcasestr(byte* str, byte* val)
        {
            var __ret = __Internal.XmlStrcasestr(str, val);
            return __ret;
        }

        public static int XmlStrcmp(byte* str1, byte* str2)
        {
            var __ret = __Internal.XmlStrcmp(str1, str2);
            return __ret;
        }

        public static int XmlStrncmp(byte* str1, byte* str2, int len)
        {
            var __ret = __Internal.XmlStrncmp(str1, str2, len);
            return __ret;
        }

        public static int XmlStrcasecmp(byte* str1, byte* str2)
        {
            var __ret = __Internal.XmlStrcasecmp(str1, str2);
            return __ret;
        }

        public static int XmlStrncasecmp(byte* str1, byte* str2, int len)
        {
            var __ret = __Internal.XmlStrncasecmp(str1, str2, len);
            return __ret;
        }

        public static int XmlStrEqual(byte* str1, byte* str2)
        {
            var __ret = __Internal.XmlStrEqual(str1, str2);
            return __ret;
        }

        public static int XmlStrQEqual(byte* pref, byte* name, byte* str)
        {
            var __ret = __Internal.XmlStrQEqual(pref, name, str);
            return __ret;
        }

        public static int XmlStrlen(byte* str)
        {
            var __ret = __Internal.XmlStrlen(str);
            return __ret;
        }

        public static byte* XmlStrcat(byte* cur, byte* add)
        {
            var __ret = __Internal.XmlStrcat(cur, add);
            return __ret;
        }

        public static byte* XmlStrncat(byte* cur, byte* add, int len)
        {
            var __ret = __Internal.XmlStrncat(cur, add, len);
            return __ret;
        }

        public static byte* XmlStrncatNew(byte* str1, byte* str2, int len)
        {
            var __ret = __Internal.XmlStrncatNew(str1, str2, len);
            return __ret;
        }

        public static int XmlStrPrintf(byte* buf, int len, string msg)
        {
            var __ret = __Internal.XmlStrPrintf(buf, len, msg);
            return __ret;
        }

        public static int XmlGetUTF8Char(byte* utf, ref int len)
        {
            fixed (int* __len1 = &len)
            {
                var __arg1 = __len1;
                var __ret = __Internal.XmlGetUTF8Char(utf, __arg1);
                return __ret;
            }
        }

        public static int XmlCheckUTF8(byte* utf)
        {
            var __ret = __Internal.XmlCheckUTF8(utf);
            return __ret;
        }

        public static int XmlUTF8Strsize(byte* utf, int len)
        {
            var __ret = __Internal.XmlUTF8Strsize(utf, len);
            return __ret;
        }

        public static byte* XmlUTF8Strndup(byte* utf, int len)
        {
            var __ret = __Internal.XmlUTF8Strndup(utf, len);
            return __ret;
        }

        public static byte* XmlUTF8Strpos(byte* utf, int pos)
        {
            var __ret = __Internal.XmlUTF8Strpos(utf, pos);
            return __ret;
        }

        public static int XmlUTF8Strloc(byte* utf, byte* utfchar)
        {
            var __ret = __Internal.XmlUTF8Strloc(utf, utfchar);
            return __ret;
        }

        public static byte* XmlUTF8Strsub(byte* utf, int start, int len)
        {
            var __ret = __Internal.XmlUTF8Strsub(utf, start, len);
            return __ret;
        }

        public static int XmlUTF8Strlen(byte* utf)
        {
            var __ret = __Internal.XmlUTF8Strlen(utf);
            return __ret;
        }

        public static int XmlUTF8Size(byte* utf)
        {
            var __ret = __Internal.XmlUTF8Size(utf);
            return __ret;
        }

        public static int XmlUTF8Charcmp(byte* utf1, byte* utf2)
        {
            var __ret = __Internal.XmlUTF8Charcmp(utf1, utf2);
            return __ret;
        }
    }

    public enum XmlElementType : uint
    {
        XML_ELEMENT_NODE = 1,
        XML_ATTRIBUTE_NODE = 2,
        XML_TEXT_NODE = 3,
        XML_CDATA_SECTION_NODE = 4,
        XML_ENTITY_REF_NODE = 5,
        XML_ENTITY_NODE = 6,
        XML_PI_NODE = 7,
        XML_COMMENT_NODE = 8,
        XML_DOCUMENT_NODE = 9,
        XML_DOCUMENT_TYPE_NODE = 10,
        XML_DOCUMENT_FRAG_NODE = 11,
        XML_NOTATION_NODE = 12,
        XML_HTML_DOCUMENT_NODE = 13,
        XML_DTD_NODE = 14,
        XML_ELEMENT_DECL = 15,
        XML_ATTRIBUTE_DECL = 16,
        XML_ENTITY_DECL = 17,
        XML_NAMESPACE_DECL = 18,
        XML_XINCLUDE_START = 19,
        XML_XINCLUDE_END = 20,
        XML_DOCB_DOCUMENT_NODE = 21
    }

    /// <summary>xmlAttributeType:</summary>
    /// <remarks>A DTD Attribute type definition.</remarks>
    public enum XmlAttributeType : uint
    {
        XML_ATTRIBUTE_CDATA = 1,
        XML_ATTRIBUTE_ID = 2,
        XML_ATTRIBUTE_IDREF = 3,
        XML_ATTRIBUTE_IDREFS = 4,
        XML_ATTRIBUTE_ENTITY = 5,
        XML_ATTRIBUTE_ENTITIES = 6,
        XML_ATTRIBUTE_NMTOKEN = 7,
        XML_ATTRIBUTE_NMTOKENS = 8,
        XML_ATTRIBUTE_ENUMERATION = 9,
        XML_ATTRIBUTE_NOTATION = 10
    }

    /// <summary>xmlElementContentType:</summary>
    /// <remarks>Possible definitions of element content types.</remarks>
    public enum XmlElementContentType : uint
    {
        XML_ELEMENT_CONTENT_PCDATA = 1,
        XML_ELEMENT_CONTENT_ELEMENT = 2,
        XML_ELEMENT_CONTENT_SEQ = 3,
        XML_ELEMENT_CONTENT_OR = 4
    }

    /// <summary>xmlElementContentOccur:</summary>
    /// <remarks>Possible definitions of element content occurrences.</remarks>
    public enum XmlElementContentOccur : uint
    {
        XML_ELEMENT_CONTENT_ONCE = 1,
        XML_ELEMENT_CONTENT_OPT = 2,
        XML_ELEMENT_CONTENT_MULT = 3,
        XML_ELEMENT_CONTENT_PLUS = 4
    }

    /// <summary>xmlBufferAllocationScheme:</summary>
    /// <remarks>
    /// <para>A buffer allocation scheme can be defined to either match exactly the</para>
    /// <para>need or double it's allocated size each time it is found too small.</para>
    /// </remarks>
    public enum XmlBufferAllocationScheme : uint
    {
        XML_BUFFER_ALLOC_DOUBLEIT = 0,
        XML_BUFFER_ALLOC_EXACT = 1,
        XML_BUFFER_ALLOC_IMMUTABLE = 2,
        XML_BUFFER_ALLOC_IO = 3,
        XML_BUFFER_ALLOC_HYBRID = 4,
        XML_BUFFER_ALLOC_BOUNDED = 5
    }

    /// <summary>xmlAttributeDefault:</summary>
    /// <remarks>A DTD Attribute default definition.</remarks>
    public enum XmlAttributeDefault : uint
    {
        XML_ATTRIBUTE_NONE = 1,
        XML_ATTRIBUTE_REQUIRED = 2,
        XML_ATTRIBUTE_IMPLIED = 3,
        XML_ATTRIBUTE_FIXED = 4
    }

    /// <summary>xmlElementTypeVal:</summary>
    /// <remarks>The different possibilities for an element content type.</remarks>
    public enum XmlElementTypeVal : uint
    {
        XML_ELEMENT_TYPE_UNDEFINED = 0,
        XML_ELEMENT_TYPE_EMPTY = 1,
        XML_ELEMENT_TYPE_ANY = 2,
        XML_ELEMENT_TYPE_MIXED = 3,
        XML_ELEMENT_TYPE_ELEMENT = 4
    }

    /// <summary>xmlDocProperty</summary>
    /// <remarks>
    /// <para>Set of properties of the document as found by the parser</para>
    /// <para>Some of them are linked to similary named xmlParserOption</para>
    /// </remarks>
    [Flags]
    public enum XmlDocProperties : uint
    {
        XML_DOC_WELLFORMED = 1,
        XML_DOC_NSVALID = 2,
        XML_DOC_OLD10 = 4,
        XML_DOC_DTDVALID = 8,
        XML_DOC_XINCLUDE = 16,
        XML_DOC_USERBUILT = 32,
        XML_DOC_INTERNAL = 64,
        XML_DOC_HTML = 128
    }

    /// <summary>xmlBuf:</summary>
    /// <remarks>A buffer structure, new one, the actual structure internals are not public</remarks>
    /// <summary>xmlBufPtr:</summary>
    /// <remarks>
    /// <para>A pointer to a buffer structure, the actual structure internals are not</para>
    /// <para>public</para>
    /// </remarks>
    /// <summary>xmlNs:</summary>
    /// <remarks>
    /// <para>An XML namespace.</para>
    /// <para>Note that prefix == NULL is valid, it defines the default namespace</para>
    /// <para>within the subtree (until overridden).</para>
    /// <para>xmlNsType is unified with xmlElementType.</para>
    /// </remarks>
    /// <summary>xmlAttributeType:</summary>
    /// <remarks>A DTD Attribute type definition.</remarks>
    /// <summary>xmlEnumeration:</summary>
    /// <remarks>List structure used when there is an enumeration in DTDs.</remarks>
    /// <summary>xmlElementContentType:</summary>
    /// <remarks>Possible definitions of element content types.</remarks>
    /// <summary>xmlElementContentOccur:</summary>
    /// <remarks>Possible definitions of element content occurrences.</remarks>
    /// <summary>xmlElementContent:</summary>
    /// <remarks>
    /// <para>An XML Element content as stored after parsing an element definition</para>
    /// <para>in a DTD.</para>
    /// </remarks>
    /// <summary>xmlDoc:</summary>
    /// <remarks>An XML document.</remarks>
    /// <summary>xmlNode:</summary>
    /// <remarks>A node in an XML tree.</remarks>
    /// <summary>xmlAttr:</summary>
    /// <remarks>An attribute on an XML node.</remarks>
    /// <summary>xmlBufferAllocationScheme:</summary>
    /// <remarks>
    /// <para>A buffer allocation scheme can be defined to either match exactly the</para>
    /// <para>need or double it's allocated size each time it is found too small.</para>
    /// </remarks>
    /// <summary>xmlBuffer:</summary>
    /// <remarks>
    /// <para>A buffer structure, this old construct is limited to 2GB and</para>
    /// <para>is being deprecated, use API with xmlBuf instead</para>
    /// </remarks>
    /// <summary>xmlNotation:</summary>
    /// <remarks>A DTD Notation definition.</remarks>
    /// <summary>xmlAttributeDefault:</summary>
    /// <remarks>A DTD Attribute default definition.</remarks>
    /// <summary>xmlAttribute:</summary>
    /// <remarks>An Attribute declaration in a DTD.</remarks>
    /// <summary>xmlElementTypeVal:</summary>
    /// <remarks>The different possibilities for an element content type.</remarks>
    /// <summary>xmlElement:</summary>
    /// <remarks>An XML Element declaration from a DTD.</remarks>
    /// <summary>xmlDtd:</summary>
    /// <remarks>
    /// <para>An XML DTD, as defined by&lt;&gt;!DOCTYPE ... There is actually one for</para>
    /// <para>the internal subset and for the external subset.</para>
    /// </remarks>
    /// <summary>xmlID:</summary>
    /// <remarks>An XML ID instance.</remarks>
    /// <summary>xmlRef:</summary>
    /// <remarks>An XML IDREF instance.</remarks>
    /// <summary>xmlDocProperty</summary>
    /// <remarks>
    /// <para>Set of properties of the document as found by the parser</para>
    /// <para>Some of them are linked to similary named xmlParserOption</para>
    /// </remarks>
    /// <summary>
    /// <para>xmlDOMWrapAcquireNsFunction:</para>
    /// <para>a DOM wrapper context</para>
    /// <para>the context node (element or attribute)</para>
    /// <para>the requested namespace name</para>
    /// <para>the requested namespace prefix</para>
    /// </summary>
    /// <remarks>
    /// <para>A function called to acquire namespaces (xmlNs) from the wrapper.</para>
    /// <para>Returns an xmlNsPtr or NULL in case of an error.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate global::System.IntPtr XmlDOMWrapAcquireNsFunction(global::System.IntPtr ctxt, global::System.IntPtr node, byte* nsName, byte* nsPrefix);

    public unsafe partial class XmlBuf
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public partial struct __Internal
        {
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlBuf> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlBuf>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlBuf __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlBuf(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlBuf __CreateInstance(global::libxml.XmlBuf.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlBuf(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlBuf.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlBuf.__Internal));
            *(global::libxml.XmlBuf.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlBuf(global::libxml.XmlBuf.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlBuf(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }
    }

    public unsafe partial class XmlNotation : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 12)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr name;

            [FieldOffset(4)]
            internal global::System.IntPtr PublicID;

            [FieldOffset(8)]
            internal global::System.IntPtr SystemID;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN12_xmlNotationC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlNotation> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlNotation>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlNotation __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlNotation(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlNotation __CreateInstance(global::libxml.XmlNotation.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlNotation(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlNotation.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlNotation.__Internal));
            *(global::libxml.XmlNotation.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlNotation(global::libxml.XmlNotation.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlNotation(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlNotation()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlNotation.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlNotation(global::libxml.XmlNotation _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlNotation.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlNotation.__Internal*) __Instance) = *((global::libxml.XmlNotation.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlNotation __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public byte* Name
        {
            get
            {
                return (byte*) ((global::libxml.XmlNotation.__Internal*) __Instance)->name;
            }

            set
            {
                ((global::libxml.XmlNotation.__Internal*)__Instance)->name = (global::System.IntPtr) value;
            }
        }

        public byte* PublicID
        {
            get
            {
                return (byte*) ((global::libxml.XmlNotation.__Internal*) __Instance)->PublicID;
            }

            set
            {
                ((global::libxml.XmlNotation.__Internal*)__Instance)->PublicID = (global::System.IntPtr) value;
            }
        }

        public byte* SystemID
        {
            get
            {
                return (byte*) ((global::libxml.XmlNotation.__Internal*) __Instance)->SystemID;
            }

            set
            {
                ((global::libxml.XmlNotation.__Internal*)__Instance)->SystemID = (global::System.IntPtr) value;
            }
        }
    }

    public unsafe partial class XmlEnumeration : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 8)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr next;

            [FieldOffset(4)]
            internal global::System.IntPtr name;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN15_xmlEnumerationC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlEnumeration> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlEnumeration>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlEnumeration __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlEnumeration(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlEnumeration __CreateInstance(global::libxml.XmlEnumeration.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlEnumeration(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlEnumeration.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlEnumeration.__Internal));
            *(global::libxml.XmlEnumeration.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlEnumeration(global::libxml.XmlEnumeration.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlEnumeration(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlEnumeration()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlEnumeration.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlEnumeration(global::libxml.XmlEnumeration _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlEnumeration.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlEnumeration.__Internal*) __Instance) = *((global::libxml.XmlEnumeration.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlEnumeration __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public global::libxml.XmlEnumeration Next
        {
            get
            {
                global::libxml.XmlEnumeration __result0;
                if (((global::libxml.XmlEnumeration.__Internal*) __Instance)->next == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlEnumeration.NativeToManagedMap.ContainsKey(((global::libxml.XmlEnumeration.__Internal*) __Instance)->next))
                    __result0 = (global::libxml.XmlEnumeration) global::libxml.XmlEnumeration.NativeToManagedMap[((global::libxml.XmlEnumeration.__Internal*) __Instance)->next];
                else __result0 = global::libxml.XmlEnumeration.__CreateInstance(((global::libxml.XmlEnumeration.__Internal*) __Instance)->next);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlEnumeration.__Internal*)__Instance)->next = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public byte* Name
        {
            get
            {
                return (byte*) ((global::libxml.XmlEnumeration.__Internal*) __Instance)->name;
            }

            set
            {
                ((global::libxml.XmlEnumeration.__Internal*)__Instance)->name = (global::System.IntPtr) value;
            }
        }
    }

    public unsafe partial class XmlAttribute : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 64)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr _private;

            [FieldOffset(4)]
            internal global::libxml.XmlElementType type;

            [FieldOffset(8)]
            internal global::System.IntPtr name;

            [FieldOffset(12)]
            internal global::System.IntPtr children;

            [FieldOffset(16)]
            internal global::System.IntPtr last;

            [FieldOffset(20)]
            internal global::System.IntPtr parent;

            [FieldOffset(24)]
            internal global::System.IntPtr next;

            [FieldOffset(28)]
            internal global::System.IntPtr prev;

            [FieldOffset(32)]
            internal global::System.IntPtr doc;

            [FieldOffset(36)]
            internal global::System.IntPtr nexth;

            [FieldOffset(40)]
            internal global::libxml.XmlAttributeType atype;

            [FieldOffset(44)]
            internal global::libxml.XmlAttributeDefault def;

            [FieldOffset(48)]
            internal global::System.IntPtr defaultValue;

            [FieldOffset(52)]
            internal global::System.IntPtr tree;

            [FieldOffset(56)]
            internal global::System.IntPtr prefix;

            [FieldOffset(60)]
            internal global::System.IntPtr elem;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN13_xmlAttributeC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlAttribute> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlAttribute>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlAttribute __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlAttribute(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlAttribute __CreateInstance(global::libxml.XmlAttribute.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlAttribute(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlAttribute.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlAttribute.__Internal));
            *(global::libxml.XmlAttribute.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlAttribute(global::libxml.XmlAttribute.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlAttribute(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlAttribute()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlAttribute.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlAttribute(global::libxml.XmlAttribute _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlAttribute.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlAttribute.__Internal*) __Instance) = *((global::libxml.XmlAttribute.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlAttribute __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public global::System.IntPtr Private
        {
            get
            {
                return ((global::libxml.XmlAttribute.__Internal*) __Instance)->_private;
            }

            set
            {
                ((global::libxml.XmlAttribute.__Internal*)__Instance)->_private = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlElementType Type
        {
            get
            {
                return ((global::libxml.XmlAttribute.__Internal*) __Instance)->type;
            }

            set
            {
                ((global::libxml.XmlAttribute.__Internal*)__Instance)->type = value;
            }
        }

        public byte* Name
        {
            get
            {
                return (byte*) ((global::libxml.XmlAttribute.__Internal*) __Instance)->name;
            }

            set
            {
                ((global::libxml.XmlAttribute.__Internal*)__Instance)->name = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlNode Children
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlAttribute.__Internal*) __Instance)->children == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlAttribute.__Internal*) __Instance)->children))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlAttribute.__Internal*) __Instance)->children];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlAttribute.__Internal*) __Instance)->children);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlAttribute.__Internal*)__Instance)->children = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNode Last
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlAttribute.__Internal*) __Instance)->last == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlAttribute.__Internal*) __Instance)->last))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlAttribute.__Internal*) __Instance)->last];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlAttribute.__Internal*) __Instance)->last);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlAttribute.__Internal*)__Instance)->last = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlDtd Parent
        {
            get
            {
                global::libxml.XmlDtd __result0;
                if (((global::libxml.XmlAttribute.__Internal*) __Instance)->parent == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlDtd.NativeToManagedMap.ContainsKey(((global::libxml.XmlAttribute.__Internal*) __Instance)->parent))
                    __result0 = (global::libxml.XmlDtd) global::libxml.XmlDtd.NativeToManagedMap[((global::libxml.XmlAttribute.__Internal*) __Instance)->parent];
                else __result0 = global::libxml.XmlDtd.__CreateInstance(((global::libxml.XmlAttribute.__Internal*) __Instance)->parent);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlAttribute.__Internal*)__Instance)->parent = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNode Next
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlAttribute.__Internal*) __Instance)->next == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlAttribute.__Internal*) __Instance)->next))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlAttribute.__Internal*) __Instance)->next];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlAttribute.__Internal*) __Instance)->next);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlAttribute.__Internal*)__Instance)->next = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNode Prev
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlAttribute.__Internal*) __Instance)->prev == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlAttribute.__Internal*) __Instance)->prev))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlAttribute.__Internal*) __Instance)->prev];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlAttribute.__Internal*) __Instance)->prev);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlAttribute.__Internal*)__Instance)->prev = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlDoc Doc
        {
            get
            {
                global::libxml.XmlDoc __result0;
                if (((global::libxml.XmlAttribute.__Internal*) __Instance)->doc == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(((global::libxml.XmlAttribute.__Internal*) __Instance)->doc))
                    __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[((global::libxml.XmlAttribute.__Internal*) __Instance)->doc];
                else __result0 = global::libxml.XmlDoc.__CreateInstance(((global::libxml.XmlAttribute.__Internal*) __Instance)->doc);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlAttribute.__Internal*)__Instance)->doc = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlAttribute Nexth
        {
            get
            {
                global::libxml.XmlAttribute __result0;
                if (((global::libxml.XmlAttribute.__Internal*) __Instance)->nexth == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlAttribute.NativeToManagedMap.ContainsKey(((global::libxml.XmlAttribute.__Internal*) __Instance)->nexth))
                    __result0 = (global::libxml.XmlAttribute) global::libxml.XmlAttribute.NativeToManagedMap[((global::libxml.XmlAttribute.__Internal*) __Instance)->nexth];
                else __result0 = global::libxml.XmlAttribute.__CreateInstance(((global::libxml.XmlAttribute.__Internal*) __Instance)->nexth);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlAttribute.__Internal*)__Instance)->nexth = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlAttributeType Atype
        {
            get
            {
                return ((global::libxml.XmlAttribute.__Internal*) __Instance)->atype;
            }

            set
            {
                ((global::libxml.XmlAttribute.__Internal*)__Instance)->atype = value;
            }
        }

        public global::libxml.XmlAttributeDefault Def
        {
            get
            {
                return ((global::libxml.XmlAttribute.__Internal*) __Instance)->def;
            }

            set
            {
                ((global::libxml.XmlAttribute.__Internal*)__Instance)->def = value;
            }
        }

        public byte* DefaultValue
        {
            get
            {
                return (byte*) ((global::libxml.XmlAttribute.__Internal*) __Instance)->defaultValue;
            }

            set
            {
                ((global::libxml.XmlAttribute.__Internal*)__Instance)->defaultValue = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlEnumeration Tree
        {
            get
            {
                global::libxml.XmlEnumeration __result0;
                if (((global::libxml.XmlAttribute.__Internal*) __Instance)->tree == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlEnumeration.NativeToManagedMap.ContainsKey(((global::libxml.XmlAttribute.__Internal*) __Instance)->tree))
                    __result0 = (global::libxml.XmlEnumeration) global::libxml.XmlEnumeration.NativeToManagedMap[((global::libxml.XmlAttribute.__Internal*) __Instance)->tree];
                else __result0 = global::libxml.XmlEnumeration.__CreateInstance(((global::libxml.XmlAttribute.__Internal*) __Instance)->tree);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlAttribute.__Internal*)__Instance)->tree = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public byte* Prefix
        {
            get
            {
                return (byte*) ((global::libxml.XmlAttribute.__Internal*) __Instance)->prefix;
            }

            set
            {
                ((global::libxml.XmlAttribute.__Internal*)__Instance)->prefix = (global::System.IntPtr) value;
            }
        }

        public byte* Elem
        {
            get
            {
                return (byte*) ((global::libxml.XmlAttribute.__Internal*) __Instance)->elem;
            }

            set
            {
                ((global::libxml.XmlAttribute.__Internal*)__Instance)->elem = (global::System.IntPtr) value;
            }
        }
    }

    public unsafe partial class XmlElementContent : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 28)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::libxml.XmlElementContentType type;

            [FieldOffset(4)]
            internal global::libxml.XmlElementContentOccur ocur;

            [FieldOffset(8)]
            internal global::System.IntPtr name;

            [FieldOffset(12)]
            internal global::System.IntPtr c1;

            [FieldOffset(16)]
            internal global::System.IntPtr c2;

            [FieldOffset(20)]
            internal global::System.IntPtr parent;

            [FieldOffset(24)]
            internal global::System.IntPtr prefix;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN18_xmlElementContentC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlElementContent> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlElementContent>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlElementContent __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlElementContent(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlElementContent __CreateInstance(global::libxml.XmlElementContent.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlElementContent(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlElementContent.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlElementContent.__Internal));
            *(global::libxml.XmlElementContent.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlElementContent(global::libxml.XmlElementContent.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlElementContent(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlElementContent()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlElementContent.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlElementContent(global::libxml.XmlElementContent _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlElementContent.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlElementContent.__Internal*) __Instance) = *((global::libxml.XmlElementContent.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlElementContent __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public global::libxml.XmlElementContentType Type
        {
            get
            {
                return ((global::libxml.XmlElementContent.__Internal*) __Instance)->type;
            }

            set
            {
                ((global::libxml.XmlElementContent.__Internal*)__Instance)->type = value;
            }
        }

        public global::libxml.XmlElementContentOccur Ocur
        {
            get
            {
                return ((global::libxml.XmlElementContent.__Internal*) __Instance)->ocur;
            }

            set
            {
                ((global::libxml.XmlElementContent.__Internal*)__Instance)->ocur = value;
            }
        }

        public byte* Name
        {
            get
            {
                return (byte*) ((global::libxml.XmlElementContent.__Internal*) __Instance)->name;
            }

            set
            {
                ((global::libxml.XmlElementContent.__Internal*)__Instance)->name = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlElementContent C1
        {
            get
            {
                global::libxml.XmlElementContent __result0;
                if (((global::libxml.XmlElementContent.__Internal*) __Instance)->c1 == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlElementContent.NativeToManagedMap.ContainsKey(((global::libxml.XmlElementContent.__Internal*) __Instance)->c1))
                    __result0 = (global::libxml.XmlElementContent) global::libxml.XmlElementContent.NativeToManagedMap[((global::libxml.XmlElementContent.__Internal*) __Instance)->c1];
                else __result0 = global::libxml.XmlElementContent.__CreateInstance(((global::libxml.XmlElementContent.__Internal*) __Instance)->c1);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlElementContent.__Internal*)__Instance)->c1 = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlElementContent C2
        {
            get
            {
                global::libxml.XmlElementContent __result0;
                if (((global::libxml.XmlElementContent.__Internal*) __Instance)->c2 == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlElementContent.NativeToManagedMap.ContainsKey(((global::libxml.XmlElementContent.__Internal*) __Instance)->c2))
                    __result0 = (global::libxml.XmlElementContent) global::libxml.XmlElementContent.NativeToManagedMap[((global::libxml.XmlElementContent.__Internal*) __Instance)->c2];
                else __result0 = global::libxml.XmlElementContent.__CreateInstance(((global::libxml.XmlElementContent.__Internal*) __Instance)->c2);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlElementContent.__Internal*)__Instance)->c2 = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlElementContent Parent
        {
            get
            {
                global::libxml.XmlElementContent __result0;
                if (((global::libxml.XmlElementContent.__Internal*) __Instance)->parent == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlElementContent.NativeToManagedMap.ContainsKey(((global::libxml.XmlElementContent.__Internal*) __Instance)->parent))
                    __result0 = (global::libxml.XmlElementContent) global::libxml.XmlElementContent.NativeToManagedMap[((global::libxml.XmlElementContent.__Internal*) __Instance)->parent];
                else __result0 = global::libxml.XmlElementContent.__CreateInstance(((global::libxml.XmlElementContent.__Internal*) __Instance)->parent);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlElementContent.__Internal*)__Instance)->parent = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public byte* Prefix
        {
            get
            {
                return (byte*) ((global::libxml.XmlElementContent.__Internal*) __Instance)->prefix;
            }

            set
            {
                ((global::libxml.XmlElementContent.__Internal*)__Instance)->prefix = (global::System.IntPtr) value;
            }
        }
    }

    public unsafe partial class XmlElement : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 56)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr _private;

            [FieldOffset(4)]
            internal global::libxml.XmlElementType type;

            [FieldOffset(8)]
            internal global::System.IntPtr name;

            [FieldOffset(12)]
            internal global::System.IntPtr children;

            [FieldOffset(16)]
            internal global::System.IntPtr last;

            [FieldOffset(20)]
            internal global::System.IntPtr parent;

            [FieldOffset(24)]
            internal global::System.IntPtr next;

            [FieldOffset(28)]
            internal global::System.IntPtr prev;

            [FieldOffset(32)]
            internal global::System.IntPtr doc;

            [FieldOffset(36)]
            internal global::libxml.XmlElementTypeVal etype;

            [FieldOffset(40)]
            internal global::System.IntPtr content;

            [FieldOffset(44)]
            internal global::System.IntPtr attributes;

            [FieldOffset(48)]
            internal global::System.IntPtr prefix;

            [FieldOffset(52)]
            internal global::System.IntPtr contModel;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN11_xmlElementC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlElement> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlElement>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlElement __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlElement(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlElement __CreateInstance(global::libxml.XmlElement.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlElement(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlElement.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlElement.__Internal));
            *(global::libxml.XmlElement.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlElement(global::libxml.XmlElement.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlElement(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlElement()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlElement.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlElement(global::libxml.XmlElement _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlElement.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlElement.__Internal*) __Instance) = *((global::libxml.XmlElement.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlElement __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public global::System.IntPtr Private
        {
            get
            {
                return ((global::libxml.XmlElement.__Internal*) __Instance)->_private;
            }

            set
            {
                ((global::libxml.XmlElement.__Internal*)__Instance)->_private = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlElementType Type
        {
            get
            {
                return ((global::libxml.XmlElement.__Internal*) __Instance)->type;
            }

            set
            {
                ((global::libxml.XmlElement.__Internal*)__Instance)->type = value;
            }
        }

        public byte* Name
        {
            get
            {
                return (byte*) ((global::libxml.XmlElement.__Internal*) __Instance)->name;
            }

            set
            {
                ((global::libxml.XmlElement.__Internal*)__Instance)->name = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlNode Children
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlElement.__Internal*) __Instance)->children == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlElement.__Internal*) __Instance)->children))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlElement.__Internal*) __Instance)->children];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlElement.__Internal*) __Instance)->children);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlElement.__Internal*)__Instance)->children = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNode Last
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlElement.__Internal*) __Instance)->last == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlElement.__Internal*) __Instance)->last))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlElement.__Internal*) __Instance)->last];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlElement.__Internal*) __Instance)->last);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlElement.__Internal*)__Instance)->last = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlDtd Parent
        {
            get
            {
                global::libxml.XmlDtd __result0;
                if (((global::libxml.XmlElement.__Internal*) __Instance)->parent == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlDtd.NativeToManagedMap.ContainsKey(((global::libxml.XmlElement.__Internal*) __Instance)->parent))
                    __result0 = (global::libxml.XmlDtd) global::libxml.XmlDtd.NativeToManagedMap[((global::libxml.XmlElement.__Internal*) __Instance)->parent];
                else __result0 = global::libxml.XmlDtd.__CreateInstance(((global::libxml.XmlElement.__Internal*) __Instance)->parent);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlElement.__Internal*)__Instance)->parent = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNode Next
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlElement.__Internal*) __Instance)->next == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlElement.__Internal*) __Instance)->next))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlElement.__Internal*) __Instance)->next];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlElement.__Internal*) __Instance)->next);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlElement.__Internal*)__Instance)->next = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNode Prev
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlElement.__Internal*) __Instance)->prev == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlElement.__Internal*) __Instance)->prev))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlElement.__Internal*) __Instance)->prev];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlElement.__Internal*) __Instance)->prev);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlElement.__Internal*)__Instance)->prev = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlDoc Doc
        {
            get
            {
                global::libxml.XmlDoc __result0;
                if (((global::libxml.XmlElement.__Internal*) __Instance)->doc == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(((global::libxml.XmlElement.__Internal*) __Instance)->doc))
                    __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[((global::libxml.XmlElement.__Internal*) __Instance)->doc];
                else __result0 = global::libxml.XmlDoc.__CreateInstance(((global::libxml.XmlElement.__Internal*) __Instance)->doc);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlElement.__Internal*)__Instance)->doc = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlElementTypeVal Etype
        {
            get
            {
                return ((global::libxml.XmlElement.__Internal*) __Instance)->etype;
            }

            set
            {
                ((global::libxml.XmlElement.__Internal*)__Instance)->etype = value;
            }
        }

        public global::libxml.XmlElementContent Content
        {
            get
            {
                global::libxml.XmlElementContent __result0;
                if (((global::libxml.XmlElement.__Internal*) __Instance)->content == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlElementContent.NativeToManagedMap.ContainsKey(((global::libxml.XmlElement.__Internal*) __Instance)->content))
                    __result0 = (global::libxml.XmlElementContent) global::libxml.XmlElementContent.NativeToManagedMap[((global::libxml.XmlElement.__Internal*) __Instance)->content];
                else __result0 = global::libxml.XmlElementContent.__CreateInstance(((global::libxml.XmlElement.__Internal*) __Instance)->content);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlElement.__Internal*)__Instance)->content = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlAttribute Attributes
        {
            get
            {
                global::libxml.XmlAttribute __result0;
                if (((global::libxml.XmlElement.__Internal*) __Instance)->attributes == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlAttribute.NativeToManagedMap.ContainsKey(((global::libxml.XmlElement.__Internal*) __Instance)->attributes))
                    __result0 = (global::libxml.XmlAttribute) global::libxml.XmlAttribute.NativeToManagedMap[((global::libxml.XmlElement.__Internal*) __Instance)->attributes];
                else __result0 = global::libxml.XmlAttribute.__CreateInstance(((global::libxml.XmlElement.__Internal*) __Instance)->attributes);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlElement.__Internal*)__Instance)->attributes = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public byte* Prefix
        {
            get
            {
                return (byte*) ((global::libxml.XmlElement.__Internal*) __Instance)->prefix;
            }

            set
            {
                ((global::libxml.XmlElement.__Internal*)__Instance)->prefix = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlRegexp ContModel
        {
            get
            {
                global::libxml.XmlRegexp __result0;
                if (((global::libxml.XmlElement.__Internal*) __Instance)->contModel == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlRegexp.NativeToManagedMap.ContainsKey(((global::libxml.XmlElement.__Internal*) __Instance)->contModel))
                    __result0 = (global::libxml.XmlRegexp) global::libxml.XmlRegexp.NativeToManagedMap[((global::libxml.XmlElement.__Internal*) __Instance)->contModel];
                else __result0 = global::libxml.XmlRegexp.__CreateInstance(((global::libxml.XmlElement.__Internal*) __Instance)->contModel);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlElement.__Internal*)__Instance)->contModel = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }
    }

    public unsafe partial class XmlNs : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 24)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr next;

            [FieldOffset(4)]
            internal global::libxml.XmlElementType type;

            [FieldOffset(8)]
            internal global::System.IntPtr href;

            [FieldOffset(12)]
            internal global::System.IntPtr prefix;

            [FieldOffset(16)]
            internal global::System.IntPtr _private;

            [FieldOffset(20)]
            internal global::System.IntPtr context;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN6_xmlNsC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlNs> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlNs>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlNs __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlNs(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlNs __CreateInstance(global::libxml.XmlNs.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlNs(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlNs.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlNs.__Internal));
            *(global::libxml.XmlNs.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlNs(global::libxml.XmlNs.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlNs(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlNs()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlNs.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlNs(global::libxml.XmlNs _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlNs.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlNs.__Internal*) __Instance) = *((global::libxml.XmlNs.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlNs __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public global::libxml.XmlNs Next
        {
            get
            {
                global::libxml.XmlNs __result0;
                if (((global::libxml.XmlNs.__Internal*) __Instance)->next == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNs.NativeToManagedMap.ContainsKey(((global::libxml.XmlNs.__Internal*) __Instance)->next))
                    __result0 = (global::libxml.XmlNs) global::libxml.XmlNs.NativeToManagedMap[((global::libxml.XmlNs.__Internal*) __Instance)->next];
                else __result0 = global::libxml.XmlNs.__CreateInstance(((global::libxml.XmlNs.__Internal*) __Instance)->next);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlNs.__Internal*)__Instance)->next = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlElementType Type
        {
            get
            {
                return ((global::libxml.XmlNs.__Internal*) __Instance)->type;
            }

            set
            {
                ((global::libxml.XmlNs.__Internal*)__Instance)->type = value;
            }
        }

        public byte* Href
        {
            get
            {
                return (byte*) ((global::libxml.XmlNs.__Internal*) __Instance)->href;
            }

            set
            {
                ((global::libxml.XmlNs.__Internal*)__Instance)->href = (global::System.IntPtr) value;
            }
        }

        public byte* Prefix
        {
            get
            {
                return (byte*) ((global::libxml.XmlNs.__Internal*) __Instance)->prefix;
            }

            set
            {
                ((global::libxml.XmlNs.__Internal*)__Instance)->prefix = (global::System.IntPtr) value;
            }
        }

        public global::System.IntPtr Private
        {
            get
            {
                return ((global::libxml.XmlNs.__Internal*) __Instance)->_private;
            }

            set
            {
                ((global::libxml.XmlNs.__Internal*)__Instance)->_private = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlDoc Context
        {
            get
            {
                global::libxml.XmlDoc __result0;
                if (((global::libxml.XmlNs.__Internal*) __Instance)->context == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(((global::libxml.XmlNs.__Internal*) __Instance)->context))
                    __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[((global::libxml.XmlNs.__Internal*) __Instance)->context];
                else __result0 = global::libxml.XmlDoc.__CreateInstance(((global::libxml.XmlNs.__Internal*) __Instance)->context);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlNs.__Internal*)__Instance)->context = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }
    }

    public unsafe partial class XmlDtd : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 64)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr _private;

            [FieldOffset(4)]
            internal global::libxml.XmlElementType type;

            [FieldOffset(8)]
            internal global::System.IntPtr name;

            [FieldOffset(12)]
            internal global::System.IntPtr children;

            [FieldOffset(16)]
            internal global::System.IntPtr last;

            [FieldOffset(20)]
            internal global::System.IntPtr parent;

            [FieldOffset(24)]
            internal global::System.IntPtr next;

            [FieldOffset(28)]
            internal global::System.IntPtr prev;

            [FieldOffset(32)]
            internal global::System.IntPtr doc;

            [FieldOffset(36)]
            internal global::System.IntPtr notations;

            [FieldOffset(40)]
            internal global::System.IntPtr elements;

            [FieldOffset(44)]
            internal global::System.IntPtr attributes;

            [FieldOffset(48)]
            internal global::System.IntPtr entities;

            [FieldOffset(52)]
            internal global::System.IntPtr ExternalID;

            [FieldOffset(56)]
            internal global::System.IntPtr SystemID;

            [FieldOffset(60)]
            internal global::System.IntPtr pentities;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN7_xmlDtdC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlDtd> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlDtd>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlDtd __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlDtd(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlDtd __CreateInstance(global::libxml.XmlDtd.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlDtd(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlDtd.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlDtd.__Internal));
            *(global::libxml.XmlDtd.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlDtd(global::libxml.XmlDtd.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlDtd(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlDtd()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlDtd.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlDtd(global::libxml.XmlDtd _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlDtd.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlDtd.__Internal*) __Instance) = *((global::libxml.XmlDtd.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlDtd __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public global::System.IntPtr Private
        {
            get
            {
                return ((global::libxml.XmlDtd.__Internal*) __Instance)->_private;
            }

            set
            {
                ((global::libxml.XmlDtd.__Internal*)__Instance)->_private = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlElementType Type
        {
            get
            {
                return ((global::libxml.XmlDtd.__Internal*) __Instance)->type;
            }

            set
            {
                ((global::libxml.XmlDtd.__Internal*)__Instance)->type = value;
            }
        }

        public byte* Name
        {
            get
            {
                return (byte*) ((global::libxml.XmlDtd.__Internal*) __Instance)->name;
            }

            set
            {
                ((global::libxml.XmlDtd.__Internal*)__Instance)->name = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlNode Children
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlDtd.__Internal*) __Instance)->children == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlDtd.__Internal*) __Instance)->children))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlDtd.__Internal*) __Instance)->children];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlDtd.__Internal*) __Instance)->children);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlDtd.__Internal*)__Instance)->children = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNode Last
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlDtd.__Internal*) __Instance)->last == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlDtd.__Internal*) __Instance)->last))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlDtd.__Internal*) __Instance)->last];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlDtd.__Internal*) __Instance)->last);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlDtd.__Internal*)__Instance)->last = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlDoc Parent
        {
            get
            {
                global::libxml.XmlDoc __result0;
                if (((global::libxml.XmlDtd.__Internal*) __Instance)->parent == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(((global::libxml.XmlDtd.__Internal*) __Instance)->parent))
                    __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[((global::libxml.XmlDtd.__Internal*) __Instance)->parent];
                else __result0 = global::libxml.XmlDoc.__CreateInstance(((global::libxml.XmlDtd.__Internal*) __Instance)->parent);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlDtd.__Internal*)__Instance)->parent = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNode Next
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlDtd.__Internal*) __Instance)->next == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlDtd.__Internal*) __Instance)->next))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlDtd.__Internal*) __Instance)->next];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlDtd.__Internal*) __Instance)->next);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlDtd.__Internal*)__Instance)->next = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNode Prev
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlDtd.__Internal*) __Instance)->prev == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlDtd.__Internal*) __Instance)->prev))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlDtd.__Internal*) __Instance)->prev];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlDtd.__Internal*) __Instance)->prev);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlDtd.__Internal*)__Instance)->prev = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlDoc Doc
        {
            get
            {
                global::libxml.XmlDoc __result0;
                if (((global::libxml.XmlDtd.__Internal*) __Instance)->doc == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(((global::libxml.XmlDtd.__Internal*) __Instance)->doc))
                    __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[((global::libxml.XmlDtd.__Internal*) __Instance)->doc];
                else __result0 = global::libxml.XmlDoc.__CreateInstance(((global::libxml.XmlDtd.__Internal*) __Instance)->doc);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlDtd.__Internal*)__Instance)->doc = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::System.IntPtr Notations
        {
            get
            {
                return ((global::libxml.XmlDtd.__Internal*) __Instance)->notations;
            }

            set
            {
                ((global::libxml.XmlDtd.__Internal*)__Instance)->notations = (global::System.IntPtr) value;
            }
        }

        public global::System.IntPtr Elements
        {
            get
            {
                return ((global::libxml.XmlDtd.__Internal*) __Instance)->elements;
            }

            set
            {
                ((global::libxml.XmlDtd.__Internal*)__Instance)->elements = (global::System.IntPtr) value;
            }
        }

        public global::System.IntPtr Attributes
        {
            get
            {
                return ((global::libxml.XmlDtd.__Internal*) __Instance)->attributes;
            }

            set
            {
                ((global::libxml.XmlDtd.__Internal*)__Instance)->attributes = (global::System.IntPtr) value;
            }
        }

        public global::System.IntPtr Entities
        {
            get
            {
                return ((global::libxml.XmlDtd.__Internal*) __Instance)->entities;
            }

            set
            {
                ((global::libxml.XmlDtd.__Internal*)__Instance)->entities = (global::System.IntPtr) value;
            }
        }

        public byte* ExternalID
        {
            get
            {
                return (byte*) ((global::libxml.XmlDtd.__Internal*) __Instance)->ExternalID;
            }

            set
            {
                ((global::libxml.XmlDtd.__Internal*)__Instance)->ExternalID = (global::System.IntPtr) value;
            }
        }

        public byte* SystemID
        {
            get
            {
                return (byte*) ((global::libxml.XmlDtd.__Internal*) __Instance)->SystemID;
            }

            set
            {
                ((global::libxml.XmlDtd.__Internal*)__Instance)->SystemID = (global::System.IntPtr) value;
            }
        }

        public global::System.IntPtr Pentities
        {
            get
            {
                return ((global::libxml.XmlDtd.__Internal*) __Instance)->pentities;
            }

            set
            {
                ((global::libxml.XmlDtd.__Internal*)__Instance)->pentities = (global::System.IntPtr) value;
            }
        }
    }

    public unsafe partial class XmlAttr : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 48)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr _private;

            [FieldOffset(4)]
            internal global::libxml.XmlElementType type;

            [FieldOffset(8)]
            internal global::System.IntPtr name;

            [FieldOffset(12)]
            internal global::System.IntPtr children;

            [FieldOffset(16)]
            internal global::System.IntPtr last;

            [FieldOffset(20)]
            internal global::System.IntPtr parent;

            [FieldOffset(24)]
            internal global::System.IntPtr next;

            [FieldOffset(28)]
            internal global::System.IntPtr prev;

            [FieldOffset(32)]
            internal global::System.IntPtr doc;

            [FieldOffset(36)]
            internal global::System.IntPtr ns;

            [FieldOffset(40)]
            internal global::libxml.XmlAttributeType atype;

            [FieldOffset(44)]
            internal global::System.IntPtr psvi;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN8_xmlAttrC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlAttr> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlAttr>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlAttr __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlAttr(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlAttr __CreateInstance(global::libxml.XmlAttr.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlAttr(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlAttr.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlAttr.__Internal));
            *(global::libxml.XmlAttr.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlAttr(global::libxml.XmlAttr.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlAttr(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlAttr()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlAttr.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlAttr(global::libxml.XmlAttr _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlAttr.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlAttr.__Internal*) __Instance) = *((global::libxml.XmlAttr.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlAttr __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public global::System.IntPtr Private
        {
            get
            {
                return ((global::libxml.XmlAttr.__Internal*) __Instance)->_private;
            }

            set
            {
                ((global::libxml.XmlAttr.__Internal*)__Instance)->_private = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlElementType Type
        {
            get
            {
                return ((global::libxml.XmlAttr.__Internal*) __Instance)->type;
            }

            set
            {
                ((global::libxml.XmlAttr.__Internal*)__Instance)->type = value;
            }
        }

        public byte* Name
        {
            get
            {
                return (byte*) ((global::libxml.XmlAttr.__Internal*) __Instance)->name;
            }

            set
            {
                ((global::libxml.XmlAttr.__Internal*)__Instance)->name = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlNode Children
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlAttr.__Internal*) __Instance)->children == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlAttr.__Internal*) __Instance)->children))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlAttr.__Internal*) __Instance)->children];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlAttr.__Internal*) __Instance)->children);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlAttr.__Internal*)__Instance)->children = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNode Last
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlAttr.__Internal*) __Instance)->last == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlAttr.__Internal*) __Instance)->last))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlAttr.__Internal*) __Instance)->last];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlAttr.__Internal*) __Instance)->last);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlAttr.__Internal*)__Instance)->last = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNode Parent
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlAttr.__Internal*) __Instance)->parent == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlAttr.__Internal*) __Instance)->parent))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlAttr.__Internal*) __Instance)->parent];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlAttr.__Internal*) __Instance)->parent);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlAttr.__Internal*)__Instance)->parent = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlAttr Next
        {
            get
            {
                global::libxml.XmlAttr __result0;
                if (((global::libxml.XmlAttr.__Internal*) __Instance)->next == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlAttr.NativeToManagedMap.ContainsKey(((global::libxml.XmlAttr.__Internal*) __Instance)->next))
                    __result0 = (global::libxml.XmlAttr) global::libxml.XmlAttr.NativeToManagedMap[((global::libxml.XmlAttr.__Internal*) __Instance)->next];
                else __result0 = global::libxml.XmlAttr.__CreateInstance(((global::libxml.XmlAttr.__Internal*) __Instance)->next);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlAttr.__Internal*)__Instance)->next = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlAttr Prev
        {
            get
            {
                global::libxml.XmlAttr __result0;
                if (((global::libxml.XmlAttr.__Internal*) __Instance)->prev == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlAttr.NativeToManagedMap.ContainsKey(((global::libxml.XmlAttr.__Internal*) __Instance)->prev))
                    __result0 = (global::libxml.XmlAttr) global::libxml.XmlAttr.NativeToManagedMap[((global::libxml.XmlAttr.__Internal*) __Instance)->prev];
                else __result0 = global::libxml.XmlAttr.__CreateInstance(((global::libxml.XmlAttr.__Internal*) __Instance)->prev);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlAttr.__Internal*)__Instance)->prev = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlDoc Doc
        {
            get
            {
                global::libxml.XmlDoc __result0;
                if (((global::libxml.XmlAttr.__Internal*) __Instance)->doc == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(((global::libxml.XmlAttr.__Internal*) __Instance)->doc))
                    __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[((global::libxml.XmlAttr.__Internal*) __Instance)->doc];
                else __result0 = global::libxml.XmlDoc.__CreateInstance(((global::libxml.XmlAttr.__Internal*) __Instance)->doc);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlAttr.__Internal*)__Instance)->doc = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNs Ns
        {
            get
            {
                global::libxml.XmlNs __result0;
                if (((global::libxml.XmlAttr.__Internal*) __Instance)->ns == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNs.NativeToManagedMap.ContainsKey(((global::libxml.XmlAttr.__Internal*) __Instance)->ns))
                    __result0 = (global::libxml.XmlNs) global::libxml.XmlNs.NativeToManagedMap[((global::libxml.XmlAttr.__Internal*) __Instance)->ns];
                else __result0 = global::libxml.XmlNs.__CreateInstance(((global::libxml.XmlAttr.__Internal*) __Instance)->ns);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlAttr.__Internal*)__Instance)->ns = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlAttributeType Atype
        {
            get
            {
                return ((global::libxml.XmlAttr.__Internal*) __Instance)->atype;
            }

            set
            {
                ((global::libxml.XmlAttr.__Internal*)__Instance)->atype = value;
            }
        }

        public global::System.IntPtr Psvi
        {
            get
            {
                return ((global::libxml.XmlAttr.__Internal*) __Instance)->psvi;
            }

            set
            {
                ((global::libxml.XmlAttr.__Internal*)__Instance)->psvi = (global::System.IntPtr) value;
            }
        }
    }

    public unsafe partial class XmlID : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 24)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr next;

            [FieldOffset(4)]
            internal global::System.IntPtr value;

            [FieldOffset(8)]
            internal global::System.IntPtr attr;

            [FieldOffset(12)]
            internal global::System.IntPtr name;

            [FieldOffset(16)]
            internal int lineno;

            [FieldOffset(20)]
            internal global::System.IntPtr doc;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN6_xmlIDC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlID> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlID>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlID __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlID(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlID __CreateInstance(global::libxml.XmlID.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlID(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlID.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlID.__Internal));
            *(global::libxml.XmlID.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlID(global::libxml.XmlID.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlID(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlID()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlID.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlID(global::libxml.XmlID _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlID.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlID.__Internal*) __Instance) = *((global::libxml.XmlID.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlID __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public global::libxml.XmlID Next
        {
            get
            {
                global::libxml.XmlID __result0;
                if (((global::libxml.XmlID.__Internal*) __Instance)->next == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlID.NativeToManagedMap.ContainsKey(((global::libxml.XmlID.__Internal*) __Instance)->next))
                    __result0 = (global::libxml.XmlID) global::libxml.XmlID.NativeToManagedMap[((global::libxml.XmlID.__Internal*) __Instance)->next];
                else __result0 = global::libxml.XmlID.__CreateInstance(((global::libxml.XmlID.__Internal*) __Instance)->next);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlID.__Internal*)__Instance)->next = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public byte* Value
        {
            get
            {
                return (byte*) ((global::libxml.XmlID.__Internal*) __Instance)->value;
            }

            set
            {
                ((global::libxml.XmlID.__Internal*)__Instance)->value = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlAttr Attr
        {
            get
            {
                global::libxml.XmlAttr __result0;
                if (((global::libxml.XmlID.__Internal*) __Instance)->attr == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlAttr.NativeToManagedMap.ContainsKey(((global::libxml.XmlID.__Internal*) __Instance)->attr))
                    __result0 = (global::libxml.XmlAttr) global::libxml.XmlAttr.NativeToManagedMap[((global::libxml.XmlID.__Internal*) __Instance)->attr];
                else __result0 = global::libxml.XmlAttr.__CreateInstance(((global::libxml.XmlID.__Internal*) __Instance)->attr);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlID.__Internal*)__Instance)->attr = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public byte* Name
        {
            get
            {
                return (byte*) ((global::libxml.XmlID.__Internal*) __Instance)->name;
            }

            set
            {
                ((global::libxml.XmlID.__Internal*)__Instance)->name = (global::System.IntPtr) value;
            }
        }

        public int Lineno
        {
            get
            {
                return ((global::libxml.XmlID.__Internal*) __Instance)->lineno;
            }

            set
            {
                ((global::libxml.XmlID.__Internal*)__Instance)->lineno = value;
            }
        }

        public global::libxml.XmlDoc Doc
        {
            get
            {
                global::libxml.XmlDoc __result0;
                if (((global::libxml.XmlID.__Internal*) __Instance)->doc == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(((global::libxml.XmlID.__Internal*) __Instance)->doc))
                    __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[((global::libxml.XmlID.__Internal*) __Instance)->doc];
                else __result0 = global::libxml.XmlDoc.__CreateInstance(((global::libxml.XmlID.__Internal*) __Instance)->doc);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlID.__Internal*)__Instance)->doc = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }
    }

    public unsafe partial class XmlRef : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 20)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr next;

            [FieldOffset(4)]
            internal global::System.IntPtr value;

            [FieldOffset(8)]
            internal global::System.IntPtr attr;

            [FieldOffset(12)]
            internal global::System.IntPtr name;

            [FieldOffset(16)]
            internal int lineno;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN7_xmlRefC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlRef> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlRef>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlRef __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlRef(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlRef __CreateInstance(global::libxml.XmlRef.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlRef(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlRef.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlRef.__Internal));
            *(global::libxml.XmlRef.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlRef(global::libxml.XmlRef.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlRef(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlRef()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlRef.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlRef(global::libxml.XmlRef _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlRef.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlRef.__Internal*) __Instance) = *((global::libxml.XmlRef.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlRef __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public global::libxml.XmlRef Next
        {
            get
            {
                global::libxml.XmlRef __result0;
                if (((global::libxml.XmlRef.__Internal*) __Instance)->next == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlRef.NativeToManagedMap.ContainsKey(((global::libxml.XmlRef.__Internal*) __Instance)->next))
                    __result0 = (global::libxml.XmlRef) global::libxml.XmlRef.NativeToManagedMap[((global::libxml.XmlRef.__Internal*) __Instance)->next];
                else __result0 = global::libxml.XmlRef.__CreateInstance(((global::libxml.XmlRef.__Internal*) __Instance)->next);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlRef.__Internal*)__Instance)->next = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public byte* Value
        {
            get
            {
                return (byte*) ((global::libxml.XmlRef.__Internal*) __Instance)->value;
            }

            set
            {
                ((global::libxml.XmlRef.__Internal*)__Instance)->value = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlAttr Attr
        {
            get
            {
                global::libxml.XmlAttr __result0;
                if (((global::libxml.XmlRef.__Internal*) __Instance)->attr == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlAttr.NativeToManagedMap.ContainsKey(((global::libxml.XmlRef.__Internal*) __Instance)->attr))
                    __result0 = (global::libxml.XmlAttr) global::libxml.XmlAttr.NativeToManagedMap[((global::libxml.XmlRef.__Internal*) __Instance)->attr];
                else __result0 = global::libxml.XmlAttr.__CreateInstance(((global::libxml.XmlRef.__Internal*) __Instance)->attr);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlRef.__Internal*)__Instance)->attr = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public byte* Name
        {
            get
            {
                return (byte*) ((global::libxml.XmlRef.__Internal*) __Instance)->name;
            }

            set
            {
                ((global::libxml.XmlRef.__Internal*)__Instance)->name = (global::System.IntPtr) value;
            }
        }

        public int Lineno
        {
            get
            {
                return ((global::libxml.XmlRef.__Internal*) __Instance)->lineno;
            }

            set
            {
                ((global::libxml.XmlRef.__Internal*)__Instance)->lineno = value;
            }
        }
    }

    public unsafe partial class XmlNode : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 60)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr _private;

            [FieldOffset(4)]
            internal global::libxml.XmlElementType type;

            [FieldOffset(8)]
            internal global::System.IntPtr name;

            [FieldOffset(12)]
            internal global::System.IntPtr children;

            [FieldOffset(16)]
            internal global::System.IntPtr last;

            [FieldOffset(20)]
            internal global::System.IntPtr parent;

            [FieldOffset(24)]
            internal global::System.IntPtr next;

            [FieldOffset(28)]
            internal global::System.IntPtr prev;

            [FieldOffset(32)]
            internal global::System.IntPtr doc;

            [FieldOffset(36)]
            internal global::System.IntPtr ns;

            [FieldOffset(40)]
            internal global::System.IntPtr content;

            [FieldOffset(44)]
            internal global::System.IntPtr properties;

            [FieldOffset(48)]
            internal global::System.IntPtr nsDef;

            [FieldOffset(52)]
            internal global::System.IntPtr psvi;

            [FieldOffset(56)]
            internal ushort line;

            [FieldOffset(58)]
            internal ushort extra;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN8_xmlNodeC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlNode> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlNode>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlNode __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlNode(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlNode __CreateInstance(global::libxml.XmlNode.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlNode(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlNode.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlNode.__Internal));
            *(global::libxml.XmlNode.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlNode(global::libxml.XmlNode.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlNode(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlNode()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlNode.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlNode(global::libxml.XmlNode _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlNode.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlNode.__Internal*) __Instance) = *((global::libxml.XmlNode.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlNode __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public global::System.IntPtr Private
        {
            get
            {
                return ((global::libxml.XmlNode.__Internal*) __Instance)->_private;
            }

            set
            {
                ((global::libxml.XmlNode.__Internal*)__Instance)->_private = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlElementType Type
        {
            get
            {
                return ((global::libxml.XmlNode.__Internal*) __Instance)->type;
            }

            set
            {
                ((global::libxml.XmlNode.__Internal*)__Instance)->type = value;
            }
        }

        public byte* Name
        {
            get
            {
                return (byte*) ((global::libxml.XmlNode.__Internal*) __Instance)->name;
            }

            set
            {
                ((global::libxml.XmlNode.__Internal*)__Instance)->name = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlNode Children
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlNode.__Internal*) __Instance)->children == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlNode.__Internal*) __Instance)->children))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlNode.__Internal*) __Instance)->children];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlNode.__Internal*) __Instance)->children);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlNode.__Internal*)__Instance)->children = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNode Last
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlNode.__Internal*) __Instance)->last == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlNode.__Internal*) __Instance)->last))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlNode.__Internal*) __Instance)->last];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlNode.__Internal*) __Instance)->last);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlNode.__Internal*)__Instance)->last = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNode Parent
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlNode.__Internal*) __Instance)->parent == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlNode.__Internal*) __Instance)->parent))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlNode.__Internal*) __Instance)->parent];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlNode.__Internal*) __Instance)->parent);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlNode.__Internal*)__Instance)->parent = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNode Next
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlNode.__Internal*) __Instance)->next == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlNode.__Internal*) __Instance)->next))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlNode.__Internal*) __Instance)->next];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlNode.__Internal*) __Instance)->next);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlNode.__Internal*)__Instance)->next = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNode Prev
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlNode.__Internal*) __Instance)->prev == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlNode.__Internal*) __Instance)->prev))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlNode.__Internal*) __Instance)->prev];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlNode.__Internal*) __Instance)->prev);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlNode.__Internal*)__Instance)->prev = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlDoc Doc
        {
            get
            {
                global::libxml.XmlDoc __result0;
                if (((global::libxml.XmlNode.__Internal*) __Instance)->doc == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(((global::libxml.XmlNode.__Internal*) __Instance)->doc))
                    __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[((global::libxml.XmlNode.__Internal*) __Instance)->doc];
                else __result0 = global::libxml.XmlDoc.__CreateInstance(((global::libxml.XmlNode.__Internal*) __Instance)->doc);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlNode.__Internal*)__Instance)->doc = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNs Ns
        {
            get
            {
                global::libxml.XmlNs __result0;
                if (((global::libxml.XmlNode.__Internal*) __Instance)->ns == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNs.NativeToManagedMap.ContainsKey(((global::libxml.XmlNode.__Internal*) __Instance)->ns))
                    __result0 = (global::libxml.XmlNs) global::libxml.XmlNs.NativeToManagedMap[((global::libxml.XmlNode.__Internal*) __Instance)->ns];
                else __result0 = global::libxml.XmlNs.__CreateInstance(((global::libxml.XmlNode.__Internal*) __Instance)->ns);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlNode.__Internal*)__Instance)->ns = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public byte* Content
        {
            get
            {
                return (byte*) ((global::libxml.XmlNode.__Internal*) __Instance)->content;
            }

            set
            {
                ((global::libxml.XmlNode.__Internal*)__Instance)->content = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlAttr Properties
        {
            get
            {
                global::libxml.XmlAttr __result0;
                if (((global::libxml.XmlNode.__Internal*) __Instance)->properties == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlAttr.NativeToManagedMap.ContainsKey(((global::libxml.XmlNode.__Internal*) __Instance)->properties))
                    __result0 = (global::libxml.XmlAttr) global::libxml.XmlAttr.NativeToManagedMap[((global::libxml.XmlNode.__Internal*) __Instance)->properties];
                else __result0 = global::libxml.XmlAttr.__CreateInstance(((global::libxml.XmlNode.__Internal*) __Instance)->properties);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlNode.__Internal*)__Instance)->properties = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNs NsDef
        {
            get
            {
                global::libxml.XmlNs __result0;
                if (((global::libxml.XmlNode.__Internal*) __Instance)->nsDef == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNs.NativeToManagedMap.ContainsKey(((global::libxml.XmlNode.__Internal*) __Instance)->nsDef))
                    __result0 = (global::libxml.XmlNs) global::libxml.XmlNs.NativeToManagedMap[((global::libxml.XmlNode.__Internal*) __Instance)->nsDef];
                else __result0 = global::libxml.XmlNs.__CreateInstance(((global::libxml.XmlNode.__Internal*) __Instance)->nsDef);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlNode.__Internal*)__Instance)->nsDef = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::System.IntPtr Psvi
        {
            get
            {
                return ((global::libxml.XmlNode.__Internal*) __Instance)->psvi;
            }

            set
            {
                ((global::libxml.XmlNode.__Internal*)__Instance)->psvi = (global::System.IntPtr) value;
            }
        }

        public ushort Line
        {
            get
            {
                return ((global::libxml.XmlNode.__Internal*) __Instance)->line;
            }

            set
            {
                ((global::libxml.XmlNode.__Internal*)__Instance)->line = value;
            }
        }

        public ushort Extra
        {
            get
            {
                return ((global::libxml.XmlNode.__Internal*) __Instance)->extra;
            }

            set
            {
                ((global::libxml.XmlNode.__Internal*)__Instance)->extra = value;
            }
        }
    }

    public unsafe partial class XmlDoc : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 96)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr _private;

            [FieldOffset(4)]
            internal global::libxml.XmlElementType type;

            [FieldOffset(8)]
            internal global::System.IntPtr name;

            [FieldOffset(12)]
            internal global::System.IntPtr children;

            [FieldOffset(16)]
            internal global::System.IntPtr last;

            [FieldOffset(20)]
            internal global::System.IntPtr parent;

            [FieldOffset(24)]
            internal global::System.IntPtr next;

            [FieldOffset(28)]
            internal global::System.IntPtr prev;

            [FieldOffset(32)]
            internal global::System.IntPtr doc;

            [FieldOffset(36)]
            internal int compression;

            [FieldOffset(40)]
            internal int standalone;

            [FieldOffset(44)]
            internal global::System.IntPtr intSubset;

            [FieldOffset(48)]
            internal global::System.IntPtr extSubset;

            [FieldOffset(52)]
            internal global::System.IntPtr oldNs;

            [FieldOffset(56)]
            internal global::System.IntPtr version;

            [FieldOffset(60)]
            internal global::System.IntPtr encoding;

            [FieldOffset(64)]
            internal global::System.IntPtr ids;

            [FieldOffset(68)]
            internal global::System.IntPtr refs;

            [FieldOffset(72)]
            internal global::System.IntPtr URL;

            [FieldOffset(76)]
            internal int charset;

            [FieldOffset(80)]
            internal global::System.IntPtr dict;

            [FieldOffset(84)]
            internal global::System.IntPtr psvi;

            [FieldOffset(88)]
            internal int parseFlags;

            [FieldOffset(92)]
            internal int properties;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN7_xmlDocC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlDoc> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlDoc>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlDoc __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlDoc(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlDoc __CreateInstance(global::libxml.XmlDoc.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlDoc(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlDoc.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlDoc.__Internal));
            *(global::libxml.XmlDoc.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlDoc(global::libxml.XmlDoc.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlDoc(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlDoc()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlDoc.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlDoc(global::libxml.XmlDoc _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlDoc.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlDoc.__Internal*) __Instance) = *((global::libxml.XmlDoc.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlDoc __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public global::System.IntPtr Private
        {
            get
            {
                return ((global::libxml.XmlDoc.__Internal*) __Instance)->_private;
            }

            set
            {
                ((global::libxml.XmlDoc.__Internal*)__Instance)->_private = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlElementType Type
        {
            get
            {
                return ((global::libxml.XmlDoc.__Internal*) __Instance)->type;
            }

            set
            {
                ((global::libxml.XmlDoc.__Internal*)__Instance)->type = value;
            }
        }

        public sbyte* Name
        {
            get
            {
                return (sbyte*) ((global::libxml.XmlDoc.__Internal*) __Instance)->name;
            }

            set
            {
                ((global::libxml.XmlDoc.__Internal*)__Instance)->name = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlNode Children
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlDoc.__Internal*) __Instance)->children == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlDoc.__Internal*) __Instance)->children))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlDoc.__Internal*) __Instance)->children];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlDoc.__Internal*) __Instance)->children);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlDoc.__Internal*)__Instance)->children = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNode Last
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlDoc.__Internal*) __Instance)->last == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlDoc.__Internal*) __Instance)->last))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlDoc.__Internal*) __Instance)->last];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlDoc.__Internal*) __Instance)->last);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlDoc.__Internal*)__Instance)->last = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNode Parent
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlDoc.__Internal*) __Instance)->parent == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlDoc.__Internal*) __Instance)->parent))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlDoc.__Internal*) __Instance)->parent];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlDoc.__Internal*) __Instance)->parent);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlDoc.__Internal*)__Instance)->parent = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNode Next
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlDoc.__Internal*) __Instance)->next == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlDoc.__Internal*) __Instance)->next))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlDoc.__Internal*) __Instance)->next];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlDoc.__Internal*) __Instance)->next);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlDoc.__Internal*)__Instance)->next = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNode Prev
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlDoc.__Internal*) __Instance)->prev == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlDoc.__Internal*) __Instance)->prev))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlDoc.__Internal*) __Instance)->prev];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlDoc.__Internal*) __Instance)->prev);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlDoc.__Internal*)__Instance)->prev = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlDoc Doc
        {
            get
            {
                global::libxml.XmlDoc __result0;
                if (((global::libxml.XmlDoc.__Internal*) __Instance)->doc == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(((global::libxml.XmlDoc.__Internal*) __Instance)->doc))
                    __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[((global::libxml.XmlDoc.__Internal*) __Instance)->doc];
                else __result0 = global::libxml.XmlDoc.__CreateInstance(((global::libxml.XmlDoc.__Internal*) __Instance)->doc);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlDoc.__Internal*)__Instance)->doc = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public int Compression
        {
            get
            {
                return ((global::libxml.XmlDoc.__Internal*) __Instance)->compression;
            }

            set
            {
                ((global::libxml.XmlDoc.__Internal*)__Instance)->compression = value;
            }
        }

        public int Standalone
        {
            get
            {
                return ((global::libxml.XmlDoc.__Internal*) __Instance)->standalone;
            }

            set
            {
                ((global::libxml.XmlDoc.__Internal*)__Instance)->standalone = value;
            }
        }

        public global::libxml.XmlDtd IntSubset
        {
            get
            {
                global::libxml.XmlDtd __result0;
                if (((global::libxml.XmlDoc.__Internal*) __Instance)->intSubset == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlDtd.NativeToManagedMap.ContainsKey(((global::libxml.XmlDoc.__Internal*) __Instance)->intSubset))
                    __result0 = (global::libxml.XmlDtd) global::libxml.XmlDtd.NativeToManagedMap[((global::libxml.XmlDoc.__Internal*) __Instance)->intSubset];
                else __result0 = global::libxml.XmlDtd.__CreateInstance(((global::libxml.XmlDoc.__Internal*) __Instance)->intSubset);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlDoc.__Internal*)__Instance)->intSubset = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlDtd ExtSubset
        {
            get
            {
                global::libxml.XmlDtd __result0;
                if (((global::libxml.XmlDoc.__Internal*) __Instance)->extSubset == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlDtd.NativeToManagedMap.ContainsKey(((global::libxml.XmlDoc.__Internal*) __Instance)->extSubset))
                    __result0 = (global::libxml.XmlDtd) global::libxml.XmlDtd.NativeToManagedMap[((global::libxml.XmlDoc.__Internal*) __Instance)->extSubset];
                else __result0 = global::libxml.XmlDtd.__CreateInstance(((global::libxml.XmlDoc.__Internal*) __Instance)->extSubset);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlDoc.__Internal*)__Instance)->extSubset = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNs OldNs
        {
            get
            {
                global::libxml.XmlNs __result0;
                if (((global::libxml.XmlDoc.__Internal*) __Instance)->oldNs == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNs.NativeToManagedMap.ContainsKey(((global::libxml.XmlDoc.__Internal*) __Instance)->oldNs))
                    __result0 = (global::libxml.XmlNs) global::libxml.XmlNs.NativeToManagedMap[((global::libxml.XmlDoc.__Internal*) __Instance)->oldNs];
                else __result0 = global::libxml.XmlNs.__CreateInstance(((global::libxml.XmlDoc.__Internal*) __Instance)->oldNs);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlDoc.__Internal*)__Instance)->oldNs = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public byte* Version
        {
            get
            {
                return (byte*) ((global::libxml.XmlDoc.__Internal*) __Instance)->version;
            }

            set
            {
                ((global::libxml.XmlDoc.__Internal*)__Instance)->version = (global::System.IntPtr) value;
            }
        }

        public byte* Encoding
        {
            get
            {
                return (byte*) ((global::libxml.XmlDoc.__Internal*) __Instance)->encoding;
            }

            set
            {
                ((global::libxml.XmlDoc.__Internal*)__Instance)->encoding = (global::System.IntPtr) value;
            }
        }

        public global::System.IntPtr Ids
        {
            get
            {
                return ((global::libxml.XmlDoc.__Internal*) __Instance)->ids;
            }

            set
            {
                ((global::libxml.XmlDoc.__Internal*)__Instance)->ids = (global::System.IntPtr) value;
            }
        }

        public global::System.IntPtr Refs
        {
            get
            {
                return ((global::libxml.XmlDoc.__Internal*) __Instance)->refs;
            }

            set
            {
                ((global::libxml.XmlDoc.__Internal*)__Instance)->refs = (global::System.IntPtr) value;
            }
        }

        public byte* URL
        {
            get
            {
                return (byte*) ((global::libxml.XmlDoc.__Internal*) __Instance)->URL;
            }

            set
            {
                ((global::libxml.XmlDoc.__Internal*)__Instance)->URL = (global::System.IntPtr) value;
            }
        }

        public int Charset
        {
            get
            {
                return ((global::libxml.XmlDoc.__Internal*) __Instance)->charset;
            }

            set
            {
                ((global::libxml.XmlDoc.__Internal*)__Instance)->charset = value;
            }
        }

        public global::libxml.XmlDict Dict
        {
            get
            {
                global::libxml.XmlDict __result0;
                if (((global::libxml.XmlDoc.__Internal*) __Instance)->dict == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlDict.NativeToManagedMap.ContainsKey(((global::libxml.XmlDoc.__Internal*) __Instance)->dict))
                    __result0 = (global::libxml.XmlDict) global::libxml.XmlDict.NativeToManagedMap[((global::libxml.XmlDoc.__Internal*) __Instance)->dict];
                else __result0 = global::libxml.XmlDict.__CreateInstance(((global::libxml.XmlDoc.__Internal*) __Instance)->dict);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlDoc.__Internal*)__Instance)->dict = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::System.IntPtr Psvi
        {
            get
            {
                return ((global::libxml.XmlDoc.__Internal*) __Instance)->psvi;
            }

            set
            {
                ((global::libxml.XmlDoc.__Internal*)__Instance)->psvi = (global::System.IntPtr) value;
            }
        }

        public int ParseFlags
        {
            get
            {
                return ((global::libxml.XmlDoc.__Internal*) __Instance)->parseFlags;
            }

            set
            {
                ((global::libxml.XmlDoc.__Internal*)__Instance)->parseFlags = value;
            }
        }

        public int Properties
        {
            get
            {
                return ((global::libxml.XmlDoc.__Internal*) __Instance)->properties;
            }

            set
            {
                ((global::libxml.XmlDoc.__Internal*)__Instance)->properties = value;
            }
        }
    }

    /// <summary>xmlDOMWrapCtxt:</summary>
    /// <remarks>Context for DOM wrapper-operations.</remarks>
    public unsafe partial class XmlDOMWrapCtxt : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr _private;

            [FieldOffset(4)]
            internal int type;

            [FieldOffset(8)]
            internal global::System.IntPtr namespaceMap;

            [FieldOffset(12)]
            internal global::System.IntPtr getNsForNodeFunc;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN15_xmlDOMWrapCtxtC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlDOMWrapCtxt> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlDOMWrapCtxt>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlDOMWrapCtxt __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlDOMWrapCtxt(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlDOMWrapCtxt __CreateInstance(global::libxml.XmlDOMWrapCtxt.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlDOMWrapCtxt(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlDOMWrapCtxt.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlDOMWrapCtxt.__Internal));
            *(global::libxml.XmlDOMWrapCtxt.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlDOMWrapCtxt(global::libxml.XmlDOMWrapCtxt.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlDOMWrapCtxt(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlDOMWrapCtxt()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlDOMWrapCtxt.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlDOMWrapCtxt(global::libxml.XmlDOMWrapCtxt _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlDOMWrapCtxt.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlDOMWrapCtxt.__Internal*) __Instance) = *((global::libxml.XmlDOMWrapCtxt.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlDOMWrapCtxt __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public global::System.IntPtr Private
        {
            get
            {
                return ((global::libxml.XmlDOMWrapCtxt.__Internal*) __Instance)->_private;
            }

            set
            {
                ((global::libxml.XmlDOMWrapCtxt.__Internal*)__Instance)->_private = (global::System.IntPtr) value;
            }
        }

        public int Type
        {
            get
            {
                return ((global::libxml.XmlDOMWrapCtxt.__Internal*) __Instance)->type;
            }

            set
            {
                ((global::libxml.XmlDOMWrapCtxt.__Internal*)__Instance)->type = value;
            }
        }

        public global::System.IntPtr NamespaceMap
        {
            get
            {
                return ((global::libxml.XmlDOMWrapCtxt.__Internal*) __Instance)->namespaceMap;
            }

            set
            {
                ((global::libxml.XmlDOMWrapCtxt.__Internal*)__Instance)->namespaceMap = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlDOMWrapAcquireNsFunction GetNsForNodeFunc
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlDOMWrapCtxt.__Internal*) __Instance)->getNsForNodeFunc;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlDOMWrapAcquireNsFunction) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlDOMWrapAcquireNsFunction));
            }

            set
            {
                ((global::libxml.XmlDOMWrapCtxt.__Internal*)__Instance)->getNsForNodeFunc = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }
    }

    public unsafe partial class tree
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufContent")]
            internal static extern byte* XmlBufContent(global::System.IntPtr buf);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufEnd")]
            internal static extern byte* XmlBufEnd(global::System.IntPtr buf);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufUse")]
            internal static extern uint XmlBufUse(global::System.IntPtr buf);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufShrink")]
            internal static extern uint XmlBufShrink(global::System.IntPtr buf, uint len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidateNCName")]
            internal static extern int XmlValidateNCName(byte* value, int space);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidateQName")]
            internal static extern int XmlValidateQName(byte* value, int space);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidateName")]
            internal static extern int XmlValidateName(byte* value, int space);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidateNMToken")]
            internal static extern int XmlValidateNMToken(byte* value, int space);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBuildQName")]
            internal static extern byte* XmlBuildQName(byte* ncname, byte* prefix, byte* memory, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSplitQName2")]
            internal static extern byte* XmlSplitQName2(byte* name, byte** prefix);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSplitQName3")]
            internal static extern byte* XmlSplitQName3(byte* name, int* len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSetBufferAllocationScheme")]
            internal static extern void XmlSetBufferAllocationScheme(global::libxml.XmlBufferAllocationScheme scheme);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetBufferAllocationScheme")]
            internal static extern global::libxml.XmlBufferAllocationScheme XmlGetBufferAllocationScheme();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufferCreate")]
            internal static extern global::System.IntPtr XmlBufferCreate();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufferCreateSize")]
            internal static extern global::System.IntPtr XmlBufferCreateSize(uint size);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufferCreateStatic")]
            internal static extern global::System.IntPtr XmlBufferCreateStatic(global::System.IntPtr mem, uint size);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufferResize")]
            internal static extern int XmlBufferResize(global::System.IntPtr buf, uint size);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufferFree")]
            internal static extern void XmlBufferFree(global::System.IntPtr buf);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufferDump")]
            internal static extern int XmlBufferDump(global::System.IntPtr file, global::System.IntPtr buf);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufferAdd")]
            internal static extern int XmlBufferAdd(global::System.IntPtr buf, byte* str, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufferAddHead")]
            internal static extern int XmlBufferAddHead(global::System.IntPtr buf, byte* str, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufferCat")]
            internal static extern int XmlBufferCat(global::System.IntPtr buf, byte* str);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufferCCat")]
            internal static extern int XmlBufferCCat(global::System.IntPtr buf, [MarshalAs(UnmanagedType.LPUTF8Str)] string str);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufferShrink")]
            internal static extern int XmlBufferShrink(global::System.IntPtr buf, uint len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufferGrow")]
            internal static extern int XmlBufferGrow(global::System.IntPtr buf, uint len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufferEmpty")]
            internal static extern void XmlBufferEmpty(global::System.IntPtr buf);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufferContent")]
            internal static extern byte* XmlBufferContent(global::System.IntPtr buf);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufferDetach")]
            internal static extern byte* XmlBufferDetach(global::System.IntPtr buf);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufferSetAllocationScheme")]
            internal static extern void XmlBufferSetAllocationScheme(global::System.IntPtr buf, global::libxml.XmlBufferAllocationScheme scheme);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufferLength")]
            internal static extern int XmlBufferLength(global::System.IntPtr buf);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCreateIntSubset")]
            internal static extern global::System.IntPtr XmlCreateIntSubset(global::System.IntPtr doc, byte* name, byte* ExternalID, byte* SystemID);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewDtd")]
            internal static extern global::System.IntPtr XmlNewDtd(global::System.IntPtr doc, byte* name, byte* ExternalID, byte* SystemID);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetIntSubset")]
            internal static extern global::System.IntPtr XmlGetIntSubset(global::System.IntPtr doc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlFreeDtd")]
            internal static extern void XmlFreeDtd(global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewGlobalNs")]
            internal static extern global::System.IntPtr XmlNewGlobalNs(global::System.IntPtr doc, byte* href, byte* prefix);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewNs")]
            internal static extern global::System.IntPtr XmlNewNs(global::System.IntPtr node, byte* href, byte* prefix);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlFreeNs")]
            internal static extern void XmlFreeNs(global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlFreeNsList")]
            internal static extern void XmlFreeNsList(global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewDoc")]
            internal static extern global::System.IntPtr XmlNewDoc(byte* version);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlFreeDoc")]
            internal static extern void XmlFreeDoc(global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewDocProp")]
            internal static extern global::System.IntPtr XmlNewDocProp(global::System.IntPtr doc, byte* name, byte* value);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewProp")]
            internal static extern global::System.IntPtr XmlNewProp(global::System.IntPtr node, byte* name, byte* value);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewNsProp")]
            internal static extern global::System.IntPtr XmlNewNsProp(global::System.IntPtr node, global::System.IntPtr ns, byte* name, byte* value);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewNsPropEatName")]
            internal static extern global::System.IntPtr XmlNewNsPropEatName(global::System.IntPtr node, global::System.IntPtr ns, byte* name, byte* value);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlFreePropList")]
            internal static extern void XmlFreePropList(global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlFreeProp")]
            internal static extern void XmlFreeProp(global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCopyProp")]
            internal static extern global::System.IntPtr XmlCopyProp(global::System.IntPtr target, global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCopyPropList")]
            internal static extern global::System.IntPtr XmlCopyPropList(global::System.IntPtr target, global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCopyDtd")]
            internal static extern global::System.IntPtr XmlCopyDtd(global::System.IntPtr dtd);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCopyDoc")]
            internal static extern global::System.IntPtr XmlCopyDoc(global::System.IntPtr doc, int recursive);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewDocNode")]
            internal static extern global::System.IntPtr XmlNewDocNode(global::System.IntPtr doc, global::System.IntPtr ns, byte* name, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewDocNodeEatName")]
            internal static extern global::System.IntPtr XmlNewDocNodeEatName(global::System.IntPtr doc, global::System.IntPtr ns, byte* name, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewNode")]
            internal static extern global::System.IntPtr XmlNewNode(global::System.IntPtr ns, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewNodeEatName")]
            internal static extern global::System.IntPtr XmlNewNodeEatName(global::System.IntPtr ns, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewChild")]
            internal static extern global::System.IntPtr XmlNewChild(global::System.IntPtr parent, global::System.IntPtr ns, byte* name, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewDocText")]
            internal static extern global::System.IntPtr XmlNewDocText(global::System.IntPtr doc, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewText")]
            internal static extern global::System.IntPtr XmlNewText(byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewDocPI")]
            internal static extern global::System.IntPtr XmlNewDocPI(global::System.IntPtr doc, byte* name, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewPI")]
            internal static extern global::System.IntPtr XmlNewPI(byte* name, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewDocTextLen")]
            internal static extern global::System.IntPtr XmlNewDocTextLen(global::System.IntPtr doc, byte* content, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewTextLen")]
            internal static extern global::System.IntPtr XmlNewTextLen(byte* content, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewDocComment")]
            internal static extern global::System.IntPtr XmlNewDocComment(global::System.IntPtr doc, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewComment")]
            internal static extern global::System.IntPtr XmlNewComment(byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewCDataBlock")]
            internal static extern global::System.IntPtr XmlNewCDataBlock(global::System.IntPtr doc, byte* content, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewCharRef")]
            internal static extern global::System.IntPtr XmlNewCharRef(global::System.IntPtr doc, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewReference")]
            internal static extern global::System.IntPtr XmlNewReference(global::System.IntPtr doc, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCopyNode")]
            internal static extern global::System.IntPtr XmlCopyNode(global::System.IntPtr node, int recursive);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDocCopyNode")]
            internal static extern global::System.IntPtr XmlDocCopyNode(global::System.IntPtr node, global::System.IntPtr doc, int recursive);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDocCopyNodeList")]
            internal static extern global::System.IntPtr XmlDocCopyNodeList(global::System.IntPtr doc, global::System.IntPtr node);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCopyNodeList")]
            internal static extern global::System.IntPtr XmlCopyNodeList(global::System.IntPtr node);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewTextChild")]
            internal static extern global::System.IntPtr XmlNewTextChild(global::System.IntPtr parent, global::System.IntPtr ns, byte* name, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewDocRawNode")]
            internal static extern global::System.IntPtr XmlNewDocRawNode(global::System.IntPtr doc, global::System.IntPtr ns, byte* name, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewDocFragment")]
            internal static extern global::System.IntPtr XmlNewDocFragment(global::System.IntPtr doc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetLineNo")]
            internal static extern int XmlGetLineNo(global::System.IntPtr node);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetNodePath")]
            internal static extern byte* XmlGetNodePath(global::System.IntPtr node);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDocGetRootElement")]
            internal static extern global::System.IntPtr XmlDocGetRootElement(global::System.IntPtr doc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetLastChild")]
            internal static extern global::System.IntPtr XmlGetLastChild(global::System.IntPtr parent);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNodeIsText")]
            internal static extern int XmlNodeIsText(global::System.IntPtr node);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlIsBlankNode")]
            internal static extern int XmlIsBlankNode(global::System.IntPtr node);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDocSetRootElement")]
            internal static extern global::System.IntPtr XmlDocSetRootElement(global::System.IntPtr doc, global::System.IntPtr root);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNodeSetName")]
            internal static extern void XmlNodeSetName(global::System.IntPtr cur, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAddChild")]
            internal static extern global::System.IntPtr XmlAddChild(global::System.IntPtr parent, global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAddChildList")]
            internal static extern global::System.IntPtr XmlAddChildList(global::System.IntPtr parent, global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlReplaceNode")]
            internal static extern global::System.IntPtr XmlReplaceNode(global::System.IntPtr old, global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAddPrevSibling")]
            internal static extern global::System.IntPtr XmlAddPrevSibling(global::System.IntPtr cur, global::System.IntPtr elem);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAddSibling")]
            internal static extern global::System.IntPtr XmlAddSibling(global::System.IntPtr cur, global::System.IntPtr elem);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAddNextSibling")]
            internal static extern global::System.IntPtr XmlAddNextSibling(global::System.IntPtr cur, global::System.IntPtr elem);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlUnlinkNode")]
            internal static extern void XmlUnlinkNode(global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlTextMerge")]
            internal static extern global::System.IntPtr XmlTextMerge(global::System.IntPtr first, global::System.IntPtr second);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlTextConcat")]
            internal static extern int XmlTextConcat(global::System.IntPtr node, byte* content, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlFreeNodeList")]
            internal static extern void XmlFreeNodeList(global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlFreeNode")]
            internal static extern void XmlFreeNode(global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSetTreeDoc")]
            internal static extern void XmlSetTreeDoc(global::System.IntPtr tree, global::System.IntPtr doc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSetListDoc")]
            internal static extern void XmlSetListDoc(global::System.IntPtr list, global::System.IntPtr doc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSearchNs")]
            internal static extern global::System.IntPtr XmlSearchNs(global::System.IntPtr doc, global::System.IntPtr node, byte* nameSpace);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSearchNsByHref")]
            internal static extern global::System.IntPtr XmlSearchNsByHref(global::System.IntPtr doc, global::System.IntPtr node, byte* href);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetNsList")]
            internal static extern global::System.IntPtr XmlGetNsList(global::System.IntPtr doc, global::System.IntPtr node);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSetNs")]
            internal static extern void XmlSetNs(global::System.IntPtr node, global::System.IntPtr ns);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCopyNamespace")]
            internal static extern global::System.IntPtr XmlCopyNamespace(global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCopyNamespaceList")]
            internal static extern global::System.IntPtr XmlCopyNamespaceList(global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSetProp")]
            internal static extern global::System.IntPtr XmlSetProp(global::System.IntPtr node, byte* name, byte* value);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSetNsProp")]
            internal static extern global::System.IntPtr XmlSetNsProp(global::System.IntPtr node, global::System.IntPtr ns, byte* name, byte* value);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetNoNsProp")]
            internal static extern byte* XmlGetNoNsProp(global::System.IntPtr node, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetProp")]
            internal static extern byte* XmlGetProp(global::System.IntPtr node, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHasProp")]
            internal static extern global::System.IntPtr XmlHasProp(global::System.IntPtr node, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHasNsProp")]
            internal static extern global::System.IntPtr XmlHasNsProp(global::System.IntPtr node, byte* name, byte* nameSpace);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetNsProp")]
            internal static extern byte* XmlGetNsProp(global::System.IntPtr node, byte* name, byte* nameSpace);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlStringGetNodeList")]
            internal static extern global::System.IntPtr XmlStringGetNodeList(global::System.IntPtr doc, byte* value);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlStringLenGetNodeList")]
            internal static extern global::System.IntPtr XmlStringLenGetNodeList(global::System.IntPtr doc, byte* value, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNodeListGetString")]
            internal static extern byte* XmlNodeListGetString(global::System.IntPtr doc, global::System.IntPtr list, int inLine);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNodeListGetRawString")]
            internal static extern byte* XmlNodeListGetRawString(global::System.IntPtr doc, global::System.IntPtr list, int inLine);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNodeSetContent")]
            internal static extern void XmlNodeSetContent(global::System.IntPtr cur, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNodeSetContentLen")]
            internal static extern void XmlNodeSetContentLen(global::System.IntPtr cur, byte* content, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNodeAddContent")]
            internal static extern void XmlNodeAddContent(global::System.IntPtr cur, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNodeAddContentLen")]
            internal static extern void XmlNodeAddContentLen(global::System.IntPtr cur, byte* content, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNodeGetContent")]
            internal static extern byte* XmlNodeGetContent(global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNodeBufGetContent")]
            internal static extern int XmlNodeBufGetContent(global::System.IntPtr buffer, global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufGetNodeContent")]
            internal static extern int XmlBufGetNodeContent(global::System.IntPtr buf, global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNodeGetLang")]
            internal static extern byte* XmlNodeGetLang(global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNodeGetSpacePreserve")]
            internal static extern int XmlNodeGetSpacePreserve(global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNodeSetLang")]
            internal static extern void XmlNodeSetLang(global::System.IntPtr cur, byte* lang);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNodeSetSpacePreserve")]
            internal static extern void XmlNodeSetSpacePreserve(global::System.IntPtr cur, int val);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNodeGetBase")]
            internal static extern byte* XmlNodeGetBase(global::System.IntPtr doc, global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNodeSetBase")]
            internal static extern void XmlNodeSetBase(global::System.IntPtr cur, byte* uri);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlRemoveProp")]
            internal static extern int XmlRemoveProp(global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlUnsetNsProp")]
            internal static extern int XmlUnsetNsProp(global::System.IntPtr node, global::System.IntPtr ns, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlUnsetProp")]
            internal static extern int XmlUnsetProp(global::System.IntPtr node, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufferWriteCHAR")]
            internal static extern void XmlBufferWriteCHAR(global::System.IntPtr buf, byte* @string);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufferWriteChar")]
            internal static extern void XmlBufferWriteChar(global::System.IntPtr buf, [MarshalAs(UnmanagedType.LPUTF8Str)] string @string);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufferWriteQuotedString")]
            internal static extern void XmlBufferWriteQuotedString(global::System.IntPtr buf, byte* @string);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAttrSerializeTxtContent")]
            internal static extern void XmlAttrSerializeTxtContent(global::System.IntPtr buf, global::System.IntPtr doc, global::System.IntPtr attr, byte* @string);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlReconciliateNs")]
            internal static extern int XmlReconciliateNs(global::System.IntPtr doc, global::System.IntPtr tree);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDocDumpFormatMemory")]
            internal static extern void XmlDocDumpFormatMemory(global::System.IntPtr cur, byte** mem, int* size, int format);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDocDumpMemory")]
            internal static extern void XmlDocDumpMemory(global::System.IntPtr cur, byte** mem, int* size);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDocDumpMemoryEnc")]
            internal static extern void XmlDocDumpMemoryEnc(global::System.IntPtr out_doc, byte** doc_txt_ptr, int* doc_txt_len, [MarshalAs(UnmanagedType.LPUTF8Str)] string txt_encoding);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDocDumpFormatMemoryEnc")]
            internal static extern void XmlDocDumpFormatMemoryEnc(global::System.IntPtr out_doc, byte** doc_txt_ptr, int* doc_txt_len, [MarshalAs(UnmanagedType.LPUTF8Str)] string txt_encoding, int format);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDocFormatDump")]
            internal static extern int XmlDocFormatDump(global::System.IntPtr f, global::System.IntPtr cur, int format);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDocDump")]
            internal static extern int XmlDocDump(global::System.IntPtr f, global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlElemDump")]
            internal static extern void XmlElemDump(global::System.IntPtr f, global::System.IntPtr doc, global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSaveFile")]
            internal static extern int XmlSaveFile([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSaveFormatFile")]
            internal static extern int XmlSaveFormatFile([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, global::System.IntPtr cur, int format);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlBufNodeDump")]
            internal static extern uint XmlBufNodeDump(global::System.IntPtr buf, global::System.IntPtr doc, global::System.IntPtr cur, int level, int format);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNodeDump")]
            internal static extern int XmlNodeDump(global::System.IntPtr buf, global::System.IntPtr doc, global::System.IntPtr cur, int level, int format);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSaveFileTo")]
            internal static extern int XmlSaveFileTo(global::System.IntPtr buf, global::System.IntPtr cur, [MarshalAs(UnmanagedType.LPUTF8Str)] string encoding);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSaveFormatFileTo")]
            internal static extern int XmlSaveFormatFileTo(global::System.IntPtr buf, global::System.IntPtr cur, [MarshalAs(UnmanagedType.LPUTF8Str)] string encoding, int format);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNodeDumpOutput")]
            internal static extern void XmlNodeDumpOutput(global::System.IntPtr buf, global::System.IntPtr doc, global::System.IntPtr cur, int level, int format, [MarshalAs(UnmanagedType.LPUTF8Str)] string encoding);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSaveFormatFileEnc")]
            internal static extern int XmlSaveFormatFileEnc([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, global::System.IntPtr cur, [MarshalAs(UnmanagedType.LPUTF8Str)] string encoding, int format);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSaveFileEnc")]
            internal static extern int XmlSaveFileEnc([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, global::System.IntPtr cur, [MarshalAs(UnmanagedType.LPUTF8Str)] string encoding);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlIsXHTML")]
            internal static extern int XmlIsXHTML(byte* systemID, byte* publicID);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetDocCompressMode")]
            internal static extern int XmlGetDocCompressMode(global::System.IntPtr doc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSetDocCompressMode")]
            internal static extern void XmlSetDocCompressMode(global::System.IntPtr doc, int mode);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetCompressMode")]
            internal static extern int XmlGetCompressMode();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSetCompressMode")]
            internal static extern void XmlSetCompressMode(int mode);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDOMWrapNewCtxt")]
            internal static extern global::System.IntPtr XmlDOMWrapNewCtxt();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDOMWrapFreeCtxt")]
            internal static extern void XmlDOMWrapFreeCtxt(global::System.IntPtr ctxt);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDOMWrapReconcileNamespaces")]
            internal static extern int XmlDOMWrapReconcileNamespaces(global::System.IntPtr ctxt, global::System.IntPtr elem, int options);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDOMWrapAdoptNode")]
            internal static extern int XmlDOMWrapAdoptNode(global::System.IntPtr ctxt, global::System.IntPtr sourceDoc, global::System.IntPtr node, global::System.IntPtr destDoc, global::System.IntPtr destParent, int options);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDOMWrapRemoveNode")]
            internal static extern int XmlDOMWrapRemoveNode(global::System.IntPtr ctxt, global::System.IntPtr doc, global::System.IntPtr node, int options);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDOMWrapCloneNode")]
            internal static extern int XmlDOMWrapCloneNode(global::System.IntPtr ctxt, global::System.IntPtr sourceDoc, global::System.IntPtr node, global::System.IntPtr clonedNode, global::System.IntPtr destDoc, global::System.IntPtr destParent, int deep, int options);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlChildElementCount")]
            internal static extern uint XmlChildElementCount(global::System.IntPtr parent);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNextElementSibling")]
            internal static extern global::System.IntPtr XmlNextElementSibling(global::System.IntPtr node);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlFirstElementChild")]
            internal static extern global::System.IntPtr XmlFirstElementChild(global::System.IntPtr parent);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlLastElementChild")]
            internal static extern global::System.IntPtr XmlLastElementChild(global::System.IntPtr parent);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlPreviousElementSibling")]
            internal static extern global::System.IntPtr XmlPreviousElementSibling(global::System.IntPtr node);
        }

        public static byte* XmlBufContent(global::libxml.XmlBuf buf)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __ret = __Internal.XmlBufContent(__arg0);
            return __ret;
        }

        public static byte* XmlBufEnd(global::libxml.XmlBuf buf)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __ret = __Internal.XmlBufEnd(__arg0);
            return __ret;
        }

        public static uint XmlBufUse(global::libxml.XmlBuf buf)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __ret = __Internal.XmlBufUse(__arg0);
            return __ret;
        }

        public static uint XmlBufShrink(global::libxml.XmlBuf buf, uint len)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __ret = __Internal.XmlBufShrink(__arg0, len);
            return __ret;
        }

        public static int XmlValidateNCName(byte* value, int space)
        {
            var __ret = __Internal.XmlValidateNCName(value, space);
            return __ret;
        }

        public static int XmlValidateQName(byte* value, int space)
        {
            var __ret = __Internal.XmlValidateQName(value, space);
            return __ret;
        }

        public static int XmlValidateName(byte* value, int space)
        {
            var __ret = __Internal.XmlValidateName(value, space);
            return __ret;
        }

        public static int XmlValidateNMToken(byte* value, int space)
        {
            var __ret = __Internal.XmlValidateNMToken(value, space);
            return __ret;
        }

        public static byte* XmlBuildQName(byte* ncname, byte* prefix, byte* memory, int len)
        {
            var __ret = __Internal.XmlBuildQName(ncname, prefix, memory, len);
            return __ret;
        }

        public static byte* XmlSplitQName2(byte* name, byte** prefix)
        {
            var __ret = __Internal.XmlSplitQName2(name, prefix);
            return __ret;
        }

        public static byte* XmlSplitQName3(byte* name, ref int len)
        {
            fixed (int* __len1 = &len)
            {
                var __arg1 = __len1;
                var __ret = __Internal.XmlSplitQName3(name, __arg1);
                return __ret;
            }
        }

        public static void XmlSetBufferAllocationScheme(global::libxml.XmlBufferAllocationScheme scheme)
        {
            __Internal.XmlSetBufferAllocationScheme(scheme);
        }

        public static global::libxml.XmlBufferAllocationScheme XmlGetBufferAllocationScheme()
        {
            var __ret = __Internal.XmlGetBufferAllocationScheme();
            return __ret;
        }

        public static global::libxml.XmlBuffer XmlBufferCreate()
        {
            var __ret = __Internal.XmlBufferCreate();
            global::libxml.XmlBuffer __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlBuffer.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlBuffer) global::libxml.XmlBuffer.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlBuffer.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlBuffer XmlBufferCreateSize(uint size)
        {
            var __ret = __Internal.XmlBufferCreateSize(size);
            global::libxml.XmlBuffer __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlBuffer.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlBuffer) global::libxml.XmlBuffer.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlBuffer.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlBuffer XmlBufferCreateStatic(global::System.IntPtr mem, uint size)
        {
            var __ret = __Internal.XmlBufferCreateStatic(mem, size);
            global::libxml.XmlBuffer __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlBuffer.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlBuffer) global::libxml.XmlBuffer.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlBuffer.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlBufferResize(global::libxml.XmlBuffer buf, uint size)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __ret = __Internal.XmlBufferResize(__arg0, size);
            return __ret;
        }

        public static void XmlBufferFree(global::libxml.XmlBuffer buf)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            __Internal.XmlBufferFree(__arg0);
        }

        public static int XmlBufferDump(global::System.IntPtr file, global::libxml.XmlBuffer buf)
        {
            var __arg1 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __ret = __Internal.XmlBufferDump(file, __arg1);
            return __ret;
        }

        public static int XmlBufferAdd(global::libxml.XmlBuffer buf, byte* str, int len)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __ret = __Internal.XmlBufferAdd(__arg0, str, len);
            return __ret;
        }

        public static int XmlBufferAddHead(global::libxml.XmlBuffer buf, byte* str, int len)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __ret = __Internal.XmlBufferAddHead(__arg0, str, len);
            return __ret;
        }

        public static int XmlBufferCat(global::libxml.XmlBuffer buf, byte* str)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __ret = __Internal.XmlBufferCat(__arg0, str);
            return __ret;
        }

        public static int XmlBufferCCat(global::libxml.XmlBuffer buf, string str)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __ret = __Internal.XmlBufferCCat(__arg0, str);
            return __ret;
        }

        public static int XmlBufferShrink(global::libxml.XmlBuffer buf, uint len)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __ret = __Internal.XmlBufferShrink(__arg0, len);
            return __ret;
        }

        public static int XmlBufferGrow(global::libxml.XmlBuffer buf, uint len)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __ret = __Internal.XmlBufferGrow(__arg0, len);
            return __ret;
        }

        public static void XmlBufferEmpty(global::libxml.XmlBuffer buf)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            __Internal.XmlBufferEmpty(__arg0);
        }

        public static byte* XmlBufferContent(global::libxml.XmlBuffer buf)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __ret = __Internal.XmlBufferContent(__arg0);
            return __ret;
        }

        public static byte* XmlBufferDetach(global::libxml.XmlBuffer buf)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __ret = __Internal.XmlBufferDetach(__arg0);
            return __ret;
        }

        public static void XmlBufferSetAllocationScheme(global::libxml.XmlBuffer buf, global::libxml.XmlBufferAllocationScheme scheme)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            __Internal.XmlBufferSetAllocationScheme(__arg0, scheme);
        }

        public static int XmlBufferLength(global::libxml.XmlBuffer buf)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __ret = __Internal.XmlBufferLength(__arg0);
            return __ret;
        }

        public static global::libxml.XmlDtd XmlCreateIntSubset(global::libxml.XmlDoc doc, byte* name, byte* ExternalID, byte* SystemID)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlCreateIntSubset(__arg0, name, ExternalID, SystemID);
            global::libxml.XmlDtd __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDtd.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDtd) global::libxml.XmlDtd.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDtd.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDtd XmlNewDtd(global::libxml.XmlDoc doc, byte* name, byte* ExternalID, byte* SystemID)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlNewDtd(__arg0, name, ExternalID, SystemID);
            global::libxml.XmlDtd __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDtd.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDtd) global::libxml.XmlDtd.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDtd.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDtd XmlGetIntSubset(global::libxml.XmlDoc doc)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlGetIntSubset(__arg0);
            global::libxml.XmlDtd __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDtd.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDtd) global::libxml.XmlDtd.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDtd.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlFreeDtd(global::libxml.XmlDtd cur)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            __Internal.XmlFreeDtd(__arg0);
        }

        public static global::libxml.XmlNs XmlNewGlobalNs(global::libxml.XmlDoc doc, byte* href, byte* prefix)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlNewGlobalNs(__arg0, href, prefix);
            global::libxml.XmlNs __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNs.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNs) global::libxml.XmlNs.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNs.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNs XmlNewNs(global::libxml.XmlNode node, byte* href, byte* prefix)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlNewNs(__arg0, href, prefix);
            global::libxml.XmlNs __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNs.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNs) global::libxml.XmlNs.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNs.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlFreeNs(global::libxml.XmlNs cur)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            __Internal.XmlFreeNs(__arg0);
        }

        public static void XmlFreeNsList(global::libxml.XmlNs cur)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            __Internal.XmlFreeNsList(__arg0);
        }

        public static global::libxml.XmlDoc XmlNewDoc(byte* version)
        {
            var __ret = __Internal.XmlNewDoc(version);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlFreeDoc(global::libxml.XmlDoc cur)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            __Internal.XmlFreeDoc(__arg0);
        }

        public static global::libxml.XmlAttr XmlNewDocProp(global::libxml.XmlDoc doc, byte* name, byte* value)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlNewDocProp(__arg0, name, value);
            global::libxml.XmlAttr __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAttr.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAttr) global::libxml.XmlAttr.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAttr.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlAttr XmlNewProp(global::libxml.XmlNode node, byte* name, byte* value)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlNewProp(__arg0, name, value);
            global::libxml.XmlAttr __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAttr.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAttr) global::libxml.XmlAttr.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAttr.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlAttr XmlNewNsProp(global::libxml.XmlNode node, global::libxml.XmlNs ns, byte* name, byte* value)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __arg1 = ReferenceEquals(ns, null) ? global::System.IntPtr.Zero : ns.__Instance;
            var __ret = __Internal.XmlNewNsProp(__arg0, __arg1, name, value);
            global::libxml.XmlAttr __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAttr.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAttr) global::libxml.XmlAttr.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAttr.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlAttr XmlNewNsPropEatName(global::libxml.XmlNode node, global::libxml.XmlNs ns, byte* name, byte* value)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __arg1 = ReferenceEquals(ns, null) ? global::System.IntPtr.Zero : ns.__Instance;
            var __ret = __Internal.XmlNewNsPropEatName(__arg0, __arg1, name, value);
            global::libxml.XmlAttr __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAttr.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAttr) global::libxml.XmlAttr.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAttr.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlFreePropList(global::libxml.XmlAttr cur)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            __Internal.XmlFreePropList(__arg0);
        }

        public static void XmlFreeProp(global::libxml.XmlAttr cur)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            __Internal.XmlFreeProp(__arg0);
        }

        public static global::libxml.XmlAttr XmlCopyProp(global::libxml.XmlNode target, global::libxml.XmlAttr cur)
        {
            var __arg0 = ReferenceEquals(target, null) ? global::System.IntPtr.Zero : target.__Instance;
            var __arg1 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlCopyProp(__arg0, __arg1);
            global::libxml.XmlAttr __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAttr.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAttr) global::libxml.XmlAttr.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAttr.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlAttr XmlCopyPropList(global::libxml.XmlNode target, global::libxml.XmlAttr cur)
        {
            var __arg0 = ReferenceEquals(target, null) ? global::System.IntPtr.Zero : target.__Instance;
            var __arg1 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlCopyPropList(__arg0, __arg1);
            global::libxml.XmlAttr __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAttr.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAttr) global::libxml.XmlAttr.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAttr.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDtd XmlCopyDtd(global::libxml.XmlDtd dtd)
        {
            var __arg0 = ReferenceEquals(dtd, null) ? global::System.IntPtr.Zero : dtd.__Instance;
            var __ret = __Internal.XmlCopyDtd(__arg0);
            global::libxml.XmlDtd __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDtd.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDtd) global::libxml.XmlDtd.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDtd.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDoc XmlCopyDoc(global::libxml.XmlDoc doc, int recursive)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlCopyDoc(__arg0, recursive);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlNewDocNode(global::libxml.XmlDoc doc, global::libxml.XmlNs ns, byte* name, byte* content)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg1 = ReferenceEquals(ns, null) ? global::System.IntPtr.Zero : ns.__Instance;
            var __ret = __Internal.XmlNewDocNode(__arg0, __arg1, name, content);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlNewDocNodeEatName(global::libxml.XmlDoc doc, global::libxml.XmlNs ns, byte* name, byte* content)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg1 = ReferenceEquals(ns, null) ? global::System.IntPtr.Zero : ns.__Instance;
            var __ret = __Internal.XmlNewDocNodeEatName(__arg0, __arg1, name, content);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlNewNode(global::libxml.XmlNs ns, byte* name)
        {
            var __arg0 = ReferenceEquals(ns, null) ? global::System.IntPtr.Zero : ns.__Instance;
            var __ret = __Internal.XmlNewNode(__arg0, name);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlNewNodeEatName(global::libxml.XmlNs ns, byte* name)
        {
            var __arg0 = ReferenceEquals(ns, null) ? global::System.IntPtr.Zero : ns.__Instance;
            var __ret = __Internal.XmlNewNodeEatName(__arg0, name);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlNewChild(global::libxml.XmlNode parent, global::libxml.XmlNs ns, byte* name, byte* content)
        {
            var __arg0 = ReferenceEquals(parent, null) ? global::System.IntPtr.Zero : parent.__Instance;
            var __arg1 = ReferenceEquals(ns, null) ? global::System.IntPtr.Zero : ns.__Instance;
            var __ret = __Internal.XmlNewChild(__arg0, __arg1, name, content);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlNewDocText(global::libxml.XmlDoc doc, byte* content)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlNewDocText(__arg0, content);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlNewText(byte* content)
        {
            var __ret = __Internal.XmlNewText(content);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlNewDocPI(global::libxml.XmlDoc doc, byte* name, byte* content)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlNewDocPI(__arg0, name, content);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlNewPI(byte* name, byte* content)
        {
            var __ret = __Internal.XmlNewPI(name, content);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlNewDocTextLen(global::libxml.XmlDoc doc, byte* content, int len)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlNewDocTextLen(__arg0, content, len);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlNewTextLen(byte* content, int len)
        {
            var __ret = __Internal.XmlNewTextLen(content, len);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlNewDocComment(global::libxml.XmlDoc doc, byte* content)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlNewDocComment(__arg0, content);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlNewComment(byte* content)
        {
            var __ret = __Internal.XmlNewComment(content);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlNewCDataBlock(global::libxml.XmlDoc doc, byte* content, int len)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlNewCDataBlock(__arg0, content, len);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlNewCharRef(global::libxml.XmlDoc doc, byte* name)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlNewCharRef(__arg0, name);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlNewReference(global::libxml.XmlDoc doc, byte* name)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlNewReference(__arg0, name);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlCopyNode(global::libxml.XmlNode node, int recursive)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlCopyNode(__arg0, recursive);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlDocCopyNode(global::libxml.XmlNode node, global::libxml.XmlDoc doc, int recursive)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlDocCopyNode(__arg0, __arg1, recursive);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlDocCopyNodeList(global::libxml.XmlDoc doc, global::libxml.XmlNode node)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg1 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlDocCopyNodeList(__arg0, __arg1);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlCopyNodeList(global::libxml.XmlNode node)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlCopyNodeList(__arg0);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlNewTextChild(global::libxml.XmlNode parent, global::libxml.XmlNs ns, byte* name, byte* content)
        {
            var __arg0 = ReferenceEquals(parent, null) ? global::System.IntPtr.Zero : parent.__Instance;
            var __arg1 = ReferenceEquals(ns, null) ? global::System.IntPtr.Zero : ns.__Instance;
            var __ret = __Internal.XmlNewTextChild(__arg0, __arg1, name, content);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlNewDocRawNode(global::libxml.XmlDoc doc, global::libxml.XmlNs ns, byte* name, byte* content)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg1 = ReferenceEquals(ns, null) ? global::System.IntPtr.Zero : ns.__Instance;
            var __ret = __Internal.XmlNewDocRawNode(__arg0, __arg1, name, content);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlNewDocFragment(global::libxml.XmlDoc doc)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlNewDocFragment(__arg0);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlGetLineNo(global::libxml.XmlNode node)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlGetLineNo(__arg0);
            return __ret;
        }

        public static byte* XmlGetNodePath(global::libxml.XmlNode node)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlGetNodePath(__arg0);
            return __ret;
        }

        public static global::libxml.XmlNode XmlDocGetRootElement(global::libxml.XmlDoc doc)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlDocGetRootElement(__arg0);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlGetLastChild(global::libxml.XmlNode parent)
        {
            var __arg0 = ReferenceEquals(parent, null) ? global::System.IntPtr.Zero : parent.__Instance;
            var __ret = __Internal.XmlGetLastChild(__arg0);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlNodeIsText(global::libxml.XmlNode node)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlNodeIsText(__arg0);
            return __ret;
        }

        public static int XmlIsBlankNode(global::libxml.XmlNode node)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlIsBlankNode(__arg0);
            return __ret;
        }

        public static global::libxml.XmlNode XmlDocSetRootElement(global::libxml.XmlDoc doc, global::libxml.XmlNode root)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg1 = ReferenceEquals(root, null) ? global::System.IntPtr.Zero : root.__Instance;
            var __ret = __Internal.XmlDocSetRootElement(__arg0, __arg1);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlNodeSetName(global::libxml.XmlNode cur, byte* name)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            __Internal.XmlNodeSetName(__arg0, name);
        }

        public static global::libxml.XmlNode XmlAddChild(global::libxml.XmlNode parent, global::libxml.XmlNode cur)
        {
            var __arg0 = ReferenceEquals(parent, null) ? global::System.IntPtr.Zero : parent.__Instance;
            var __arg1 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlAddChild(__arg0, __arg1);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlAddChildList(global::libxml.XmlNode parent, global::libxml.XmlNode cur)
        {
            var __arg0 = ReferenceEquals(parent, null) ? global::System.IntPtr.Zero : parent.__Instance;
            var __arg1 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlAddChildList(__arg0, __arg1);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlReplaceNode(global::libxml.XmlNode old, global::libxml.XmlNode cur)
        {
            var __arg0 = ReferenceEquals(old, null) ? global::System.IntPtr.Zero : old.__Instance;
            var __arg1 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlReplaceNode(__arg0, __arg1);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlAddPrevSibling(global::libxml.XmlNode cur, global::libxml.XmlNode elem)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __arg1 = ReferenceEquals(elem, null) ? global::System.IntPtr.Zero : elem.__Instance;
            var __ret = __Internal.XmlAddPrevSibling(__arg0, __arg1);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlAddSibling(global::libxml.XmlNode cur, global::libxml.XmlNode elem)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __arg1 = ReferenceEquals(elem, null) ? global::System.IntPtr.Zero : elem.__Instance;
            var __ret = __Internal.XmlAddSibling(__arg0, __arg1);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlAddNextSibling(global::libxml.XmlNode cur, global::libxml.XmlNode elem)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __arg1 = ReferenceEquals(elem, null) ? global::System.IntPtr.Zero : elem.__Instance;
            var __ret = __Internal.XmlAddNextSibling(__arg0, __arg1);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlUnlinkNode(global::libxml.XmlNode cur)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            __Internal.XmlUnlinkNode(__arg0);
        }

        public static global::libxml.XmlNode XmlTextMerge(global::libxml.XmlNode first, global::libxml.XmlNode second)
        {
            var __arg0 = ReferenceEquals(first, null) ? global::System.IntPtr.Zero : first.__Instance;
            var __arg1 = ReferenceEquals(second, null) ? global::System.IntPtr.Zero : second.__Instance;
            var __ret = __Internal.XmlTextMerge(__arg0, __arg1);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlTextConcat(global::libxml.XmlNode node, byte* content, int len)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlTextConcat(__arg0, content, len);
            return __ret;
        }

        public static void XmlFreeNodeList(global::libxml.XmlNode cur)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            __Internal.XmlFreeNodeList(__arg0);
        }

        public static void XmlFreeNode(global::libxml.XmlNode cur)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            __Internal.XmlFreeNode(__arg0);
        }

        public static void XmlSetTreeDoc(global::libxml.XmlNode tree, global::libxml.XmlDoc doc)
        {
            var __arg0 = ReferenceEquals(tree, null) ? global::System.IntPtr.Zero : tree.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            __Internal.XmlSetTreeDoc(__arg0, __arg1);
        }

        public static void XmlSetListDoc(global::libxml.XmlNode list, global::libxml.XmlDoc doc)
        {
            var __arg0 = ReferenceEquals(list, null) ? global::System.IntPtr.Zero : list.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            __Internal.XmlSetListDoc(__arg0, __arg1);
        }

        public static global::libxml.XmlNs XmlSearchNs(global::libxml.XmlDoc doc, global::libxml.XmlNode node, byte* nameSpace)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg1 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlSearchNs(__arg0, __arg1, nameSpace);
            global::libxml.XmlNs __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNs.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNs) global::libxml.XmlNs.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNs.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNs XmlSearchNsByHref(global::libxml.XmlDoc doc, global::libxml.XmlNode node, byte* href)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg1 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlSearchNsByHref(__arg0, __arg1, href);
            global::libxml.XmlNs __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNs.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNs) global::libxml.XmlNs.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNs.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNs XmlGetNsList(global::libxml.XmlDoc doc, global::libxml.XmlNode node)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg1 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlGetNsList(__arg0, __arg1);
            global::System.IntPtr ____ret = __ret == global::System.IntPtr.Zero ? global::System.IntPtr.Zero : new global::System.IntPtr(*(void**) __ret);
            global::libxml.XmlNs __result0;
            if (____ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNs.NativeToManagedMap.ContainsKey(____ret))
                __result0 = (global::libxml.XmlNs) global::libxml.XmlNs.NativeToManagedMap[____ret];
            else __result0 = global::libxml.XmlNs.__CreateInstance(____ret);
            return __result0;
        }

        public static void XmlSetNs(global::libxml.XmlNode node, global::libxml.XmlNs ns)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __arg1 = ReferenceEquals(ns, null) ? global::System.IntPtr.Zero : ns.__Instance;
            __Internal.XmlSetNs(__arg0, __arg1);
        }

        public static global::libxml.XmlNs XmlCopyNamespace(global::libxml.XmlNs cur)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlCopyNamespace(__arg0);
            global::libxml.XmlNs __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNs.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNs) global::libxml.XmlNs.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNs.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNs XmlCopyNamespaceList(global::libxml.XmlNs cur)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlCopyNamespaceList(__arg0);
            global::libxml.XmlNs __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNs.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNs) global::libxml.XmlNs.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNs.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlAttr XmlSetProp(global::libxml.XmlNode node, byte* name, byte* value)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlSetProp(__arg0, name, value);
            global::libxml.XmlAttr __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAttr.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAttr) global::libxml.XmlAttr.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAttr.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlAttr XmlSetNsProp(global::libxml.XmlNode node, global::libxml.XmlNs ns, byte* name, byte* value)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __arg1 = ReferenceEquals(ns, null) ? global::System.IntPtr.Zero : ns.__Instance;
            var __ret = __Internal.XmlSetNsProp(__arg0, __arg1, name, value);
            global::libxml.XmlAttr __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAttr.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAttr) global::libxml.XmlAttr.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAttr.__CreateInstance(__ret);
            return __result0;
        }

        public static byte* XmlGetNoNsProp(global::libxml.XmlNode node, byte* name)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlGetNoNsProp(__arg0, name);
            return __ret;
        }

        public static byte* XmlGetProp(global::libxml.XmlNode node, byte* name)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlGetProp(__arg0, name);
            return __ret;
        }

        public static global::libxml.XmlAttr XmlHasProp(global::libxml.XmlNode node, byte* name)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlHasProp(__arg0, name);
            global::libxml.XmlAttr __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAttr.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAttr) global::libxml.XmlAttr.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAttr.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlAttr XmlHasNsProp(global::libxml.XmlNode node, byte* name, byte* nameSpace)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlHasNsProp(__arg0, name, nameSpace);
            global::libxml.XmlAttr __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAttr.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAttr) global::libxml.XmlAttr.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAttr.__CreateInstance(__ret);
            return __result0;
        }

        public static byte* XmlGetNsProp(global::libxml.XmlNode node, byte* name, byte* nameSpace)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlGetNsProp(__arg0, name, nameSpace);
            return __ret;
        }

        public static global::libxml.XmlNode XmlStringGetNodeList(global::libxml.XmlDoc doc, byte* value)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlStringGetNodeList(__arg0, value);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlStringLenGetNodeList(global::libxml.XmlDoc doc, byte* value, int len)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlStringLenGetNodeList(__arg0, value, len);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static byte* XmlNodeListGetString(global::libxml.XmlDoc doc, global::libxml.XmlNode list, int inLine)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg1 = ReferenceEquals(list, null) ? global::System.IntPtr.Zero : list.__Instance;
            var __ret = __Internal.XmlNodeListGetString(__arg0, __arg1, inLine);
            return __ret;
        }

        public static byte* XmlNodeListGetRawString(global::libxml.XmlDoc doc, global::libxml.XmlNode list, int inLine)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg1 = ReferenceEquals(list, null) ? global::System.IntPtr.Zero : list.__Instance;
            var __ret = __Internal.XmlNodeListGetRawString(__arg0, __arg1, inLine);
            return __ret;
        }

        public static void XmlNodeSetContent(global::libxml.XmlNode cur, byte* content)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            __Internal.XmlNodeSetContent(__arg0, content);
        }

        public static void XmlNodeSetContentLen(global::libxml.XmlNode cur, byte* content, int len)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            __Internal.XmlNodeSetContentLen(__arg0, content, len);
        }

        public static void XmlNodeAddContent(global::libxml.XmlNode cur, byte* content)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            __Internal.XmlNodeAddContent(__arg0, content);
        }

        public static void XmlNodeAddContentLen(global::libxml.XmlNode cur, byte* content, int len)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            __Internal.XmlNodeAddContentLen(__arg0, content, len);
        }

        public static byte* XmlNodeGetContent(global::libxml.XmlNode cur)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlNodeGetContent(__arg0);
            return __ret;
        }

        public static int XmlNodeBufGetContent(global::libxml.XmlBuffer buffer, global::libxml.XmlNode cur)
        {
            var __arg0 = ReferenceEquals(buffer, null) ? global::System.IntPtr.Zero : buffer.__Instance;
            var __arg1 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlNodeBufGetContent(__arg0, __arg1);
            return __ret;
        }

        public static int XmlBufGetNodeContent(global::libxml.XmlBuf buf, global::libxml.XmlNode cur)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __arg1 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlBufGetNodeContent(__arg0, __arg1);
            return __ret;
        }

        public static byte* XmlNodeGetLang(global::libxml.XmlNode cur)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlNodeGetLang(__arg0);
            return __ret;
        }

        public static int XmlNodeGetSpacePreserve(global::libxml.XmlNode cur)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlNodeGetSpacePreserve(__arg0);
            return __ret;
        }

        public static void XmlNodeSetLang(global::libxml.XmlNode cur, byte* lang)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            __Internal.XmlNodeSetLang(__arg0, lang);
        }

        public static void XmlNodeSetSpacePreserve(global::libxml.XmlNode cur, int val)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            __Internal.XmlNodeSetSpacePreserve(__arg0, val);
        }

        public static byte* XmlNodeGetBase(global::libxml.XmlDoc doc, global::libxml.XmlNode cur)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg1 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlNodeGetBase(__arg0, __arg1);
            return __ret;
        }

        public static void XmlNodeSetBase(global::libxml.XmlNode cur, byte* uri)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            __Internal.XmlNodeSetBase(__arg0, uri);
        }

        public static int XmlRemoveProp(global::libxml.XmlAttr cur)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlRemoveProp(__arg0);
            return __ret;
        }

        public static int XmlUnsetNsProp(global::libxml.XmlNode node, global::libxml.XmlNs ns, byte* name)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __arg1 = ReferenceEquals(ns, null) ? global::System.IntPtr.Zero : ns.__Instance;
            var __ret = __Internal.XmlUnsetNsProp(__arg0, __arg1, name);
            return __ret;
        }

        public static int XmlUnsetProp(global::libxml.XmlNode node, byte* name)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlUnsetProp(__arg0, name);
            return __ret;
        }

        public static void XmlBufferWriteCHAR(global::libxml.XmlBuffer buf, byte* @string)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            __Internal.XmlBufferWriteCHAR(__arg0, @string);
        }

        public static void XmlBufferWriteChar(global::libxml.XmlBuffer buf, string @string)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            __Internal.XmlBufferWriteChar(__arg0, @string);
        }

        public static void XmlBufferWriteQuotedString(global::libxml.XmlBuffer buf, byte* @string)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            __Internal.XmlBufferWriteQuotedString(__arg0, @string);
        }

        public static void XmlAttrSerializeTxtContent(global::libxml.XmlBuffer buf, global::libxml.XmlDoc doc, global::libxml.XmlAttr attr, byte* @string)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg2 = ReferenceEquals(attr, null) ? global::System.IntPtr.Zero : attr.__Instance;
            __Internal.XmlAttrSerializeTxtContent(__arg0, __arg1, __arg2, @string);
        }

        public static int XmlReconciliateNs(global::libxml.XmlDoc doc, global::libxml.XmlNode tree)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg1 = ReferenceEquals(tree, null) ? global::System.IntPtr.Zero : tree.__Instance;
            var __ret = __Internal.XmlReconciliateNs(__arg0, __arg1);
            return __ret;
        }

        public static void XmlDocDumpFormatMemory(global::libxml.XmlDoc cur, byte** mem, ref int size, int format)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            fixed (int* __size2 = &size)
            {
                var __arg2 = __size2;
                __Internal.XmlDocDumpFormatMemory(__arg0, mem, __arg2, format);
            }
        }

        public static void XmlDocDumpMemory(global::libxml.XmlDoc cur, byte** mem, ref int size)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            fixed (int* __size2 = &size)
            {
                var __arg2 = __size2;
                __Internal.XmlDocDumpMemory(__arg0, mem, __arg2);
            }
        }

        public static void XmlDocDumpMemoryEnc(global::libxml.XmlDoc out_doc, byte** doc_txt_ptr, ref int doc_txt_len, string txt_encoding)
        {
            var __arg0 = ReferenceEquals(out_doc, null) ? global::System.IntPtr.Zero : out_doc.__Instance;
            fixed (int* __doc_txt_len2 = &doc_txt_len)
            {
                var __arg2 = __doc_txt_len2;
                __Internal.XmlDocDumpMemoryEnc(__arg0, doc_txt_ptr, __arg2, txt_encoding);
            }
        }

        public static void XmlDocDumpFormatMemoryEnc(global::libxml.XmlDoc out_doc, byte** doc_txt_ptr, ref int doc_txt_len, string txt_encoding, int format)
        {
            var __arg0 = ReferenceEquals(out_doc, null) ? global::System.IntPtr.Zero : out_doc.__Instance;
            fixed (int* __doc_txt_len2 = &doc_txt_len)
            {
                var __arg2 = __doc_txt_len2;
                __Internal.XmlDocDumpFormatMemoryEnc(__arg0, doc_txt_ptr, __arg2, txt_encoding, format);
            }
        }

        public static int XmlDocFormatDump(global::System.IntPtr f, global::libxml.XmlDoc cur, int format)
        {
            var __arg1 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlDocFormatDump(f, __arg1, format);
            return __ret;
        }

        public static int XmlDocDump(global::System.IntPtr f, global::libxml.XmlDoc cur)
        {
            var __arg1 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlDocDump(f, __arg1);
            return __ret;
        }

        public static void XmlElemDump(global::System.IntPtr f, global::libxml.XmlDoc doc, global::libxml.XmlNode cur)
        {
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg2 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            __Internal.XmlElemDump(f, __arg1, __arg2);
        }

        public static int XmlSaveFile(string filename, global::libxml.XmlDoc cur)
        {
            var __arg1 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlSaveFile(filename, __arg1);
            return __ret;
        }

        public static int XmlSaveFormatFile(string filename, global::libxml.XmlDoc cur, int format)
        {
            var __arg1 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlSaveFormatFile(filename, __arg1, format);
            return __ret;
        }

        public static uint XmlBufNodeDump(global::libxml.XmlBuf buf, global::libxml.XmlDoc doc, global::libxml.XmlNode cur, int level, int format)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg2 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlBufNodeDump(__arg0, __arg1, __arg2, level, format);
            return __ret;
        }

        public static int XmlNodeDump(global::libxml.XmlBuffer buf, global::libxml.XmlDoc doc, global::libxml.XmlNode cur, int level, int format)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg2 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlNodeDump(__arg0, __arg1, __arg2, level, format);
            return __ret;
        }

        public static int XmlSaveFileTo(global::libxml.XmlOutputBuffer buf, global::libxml.XmlDoc cur, string encoding)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __arg1 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlSaveFileTo(__arg0, __arg1, encoding);
            return __ret;
        }

        public static int XmlSaveFormatFileTo(global::libxml.XmlOutputBuffer buf, global::libxml.XmlDoc cur, string encoding, int format)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __arg1 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlSaveFormatFileTo(__arg0, __arg1, encoding, format);
            return __ret;
        }

        public static void XmlNodeDumpOutput(global::libxml.XmlOutputBuffer buf, global::libxml.XmlDoc doc, global::libxml.XmlNode cur, int level, int format, string encoding)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg2 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            __Internal.XmlNodeDumpOutput(__arg0, __arg1, __arg2, level, format, encoding);
        }

        public static int XmlSaveFormatFileEnc(string filename, global::libxml.XmlDoc cur, string encoding, int format)
        {
            var __arg1 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlSaveFormatFileEnc(filename, __arg1, encoding, format);
            return __ret;
        }

        public static int XmlSaveFileEnc(string filename, global::libxml.XmlDoc cur, string encoding)
        {
            var __arg1 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlSaveFileEnc(filename, __arg1, encoding);
            return __ret;
        }

        public static int XmlIsXHTML(byte* systemID, byte* publicID)
        {
            var __ret = __Internal.XmlIsXHTML(systemID, publicID);
            return __ret;
        }

        public static int XmlGetDocCompressMode(global::libxml.XmlDoc doc)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlGetDocCompressMode(__arg0);
            return __ret;
        }

        public static void XmlSetDocCompressMode(global::libxml.XmlDoc doc, int mode)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            __Internal.XmlSetDocCompressMode(__arg0, mode);
        }

        public static int XmlGetCompressMode()
        {
            var __ret = __Internal.XmlGetCompressMode();
            return __ret;
        }

        public static void XmlSetCompressMode(int mode)
        {
            __Internal.XmlSetCompressMode(mode);
        }

        public static global::libxml.XmlDOMWrapCtxt XmlDOMWrapNewCtxt()
        {
            var __ret = __Internal.XmlDOMWrapNewCtxt();
            global::libxml.XmlDOMWrapCtxt __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDOMWrapCtxt.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDOMWrapCtxt) global::libxml.XmlDOMWrapCtxt.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDOMWrapCtxt.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlDOMWrapFreeCtxt(global::libxml.XmlDOMWrapCtxt ctxt)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            __Internal.XmlDOMWrapFreeCtxt(__arg0);
        }

        public static int XmlDOMWrapReconcileNamespaces(global::libxml.XmlDOMWrapCtxt ctxt, global::libxml.XmlNode elem, int options)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(elem, null) ? global::System.IntPtr.Zero : elem.__Instance;
            var __ret = __Internal.XmlDOMWrapReconcileNamespaces(__arg0, __arg1, options);
            return __ret;
        }

        public static int XmlDOMWrapAdoptNode(global::libxml.XmlDOMWrapCtxt ctxt, global::libxml.XmlDoc sourceDoc, global::libxml.XmlNode node, global::libxml.XmlDoc destDoc, global::libxml.XmlNode destParent, int options)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(sourceDoc, null) ? global::System.IntPtr.Zero : sourceDoc.__Instance;
            var __arg2 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __arg3 = ReferenceEquals(destDoc, null) ? global::System.IntPtr.Zero : destDoc.__Instance;
            var __arg4 = ReferenceEquals(destParent, null) ? global::System.IntPtr.Zero : destParent.__Instance;
            var __ret = __Internal.XmlDOMWrapAdoptNode(__arg0, __arg1, __arg2, __arg3, __arg4, options);
            return __ret;
        }

        public static int XmlDOMWrapRemoveNode(global::libxml.XmlDOMWrapCtxt ctxt, global::libxml.XmlDoc doc, global::libxml.XmlNode node, int options)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg2 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlDOMWrapRemoveNode(__arg0, __arg1, __arg2, options);
            return __ret;
        }

        public static int XmlDOMWrapCloneNode(global::libxml.XmlDOMWrapCtxt ctxt, global::libxml.XmlDoc sourceDoc, global::libxml.XmlNode node, global::libxml.XmlNode clonedNode, global::libxml.XmlDoc destDoc, global::libxml.XmlNode destParent, int deep, int options)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(sourceDoc, null) ? global::System.IntPtr.Zero : sourceDoc.__Instance;
            var __arg2 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var ____arg3 = ReferenceEquals(clonedNode, null) ? global::System.IntPtr.Zero : clonedNode.__Instance;
            var __arg3 = new global::System.IntPtr(&____arg3);
            var __arg4 = ReferenceEquals(destDoc, null) ? global::System.IntPtr.Zero : destDoc.__Instance;
            var __arg5 = ReferenceEquals(destParent, null) ? global::System.IntPtr.Zero : destParent.__Instance;
            var __ret = __Internal.XmlDOMWrapCloneNode(__arg0, __arg1, __arg2, __arg3, __arg4, __arg5, deep, options);
            return __ret;
        }

        public static uint XmlChildElementCount(global::libxml.XmlNode parent)
        {
            var __arg0 = ReferenceEquals(parent, null) ? global::System.IntPtr.Zero : parent.__Instance;
            var __ret = __Internal.XmlChildElementCount(__arg0);
            return __ret;
        }

        public static global::libxml.XmlNode XmlNextElementSibling(global::libxml.XmlNode node)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlNextElementSibling(__arg0);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlFirstElementChild(global::libxml.XmlNode parent)
        {
            var __arg0 = ReferenceEquals(parent, null) ? global::System.IntPtr.Zero : parent.__Instance;
            var __ret = __Internal.XmlFirstElementChild(__arg0);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlLastElementChild(global::libxml.XmlNode parent)
        {
            var __arg0 = ReferenceEquals(parent, null) ? global::System.IntPtr.Zero : parent.__Instance;
            var __ret = __Internal.XmlLastElementChild(__arg0);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNode XmlPreviousElementSibling(global::libxml.XmlNode node)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlPreviousElementSibling(__arg0);
            global::libxml.XmlNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNode.__CreateInstance(__ret);
            return __result0;
        }
    }

    public enum XmlExpNodeType : uint
    {
        XML_EXP_EMPTY = 0,
        XML_EXP_FORBID = 1,
        XML_EXP_ATOM = 2,
        XML_EXP_SEQ = 3,
        XML_EXP_OR = 4,
        XML_EXP_COUNT = 5
    }

    /// <summary>xmlRegexpPtr:</summary>
    /// <remarks>
    /// <para>A libxml regular expression, they can actually be far more complex</para>
    /// <para>thank the POSIX regex expressions.</para>
    /// </remarks>
    /// <summary>xmlRegExecCtxtPtr:</summary>
    /// <remarks>A libxml progressive regular expression evaluation context</remarks>
    /// <summary>
    /// <para>xmlRegExecCallbacks:</para>
    /// <para>the regular expression context</para>
    /// <para>the current token string</para>
    /// <para>transition data</para>
    /// <para>input data</para>
    /// </summary>
    /// <remarks>Callback function when doing a transition in the automata</remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void XmlRegExecCallbacks(global::System.IntPtr exec, byte* token, global::System.IntPtr transdata, global::System.IntPtr inputdata);

    public unsafe partial class XmlRegexp
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public partial struct __Internal
        {
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlRegexp> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlRegexp>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlRegexp __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlRegexp(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlRegexp __CreateInstance(global::libxml.XmlRegexp.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlRegexp(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlRegexp.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlRegexp.__Internal));
            *(global::libxml.XmlRegexp.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlRegexp(global::libxml.XmlRegexp.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlRegexp(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }
    }

    public unsafe partial class XmlRegExecCtxt
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public partial struct __Internal
        {
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlRegExecCtxt> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlRegExecCtxt>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlRegExecCtxt __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlRegExecCtxt(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlRegExecCtxt __CreateInstance(global::libxml.XmlRegExecCtxt.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlRegExecCtxt(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlRegExecCtxt.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlRegExecCtxt.__Internal));
            *(global::libxml.XmlRegExecCtxt.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlRegExecCtxt(global::libxml.XmlRegExecCtxt.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlRegExecCtxt(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }
    }

    public unsafe partial class XmlExpCtxt
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public partial struct __Internal
        {
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlExpCtxt> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlExpCtxt>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlExpCtxt __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlExpCtxt(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlExpCtxt __CreateInstance(global::libxml.XmlExpCtxt.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlExpCtxt(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlExpCtxt.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlExpCtxt.__Internal));
            *(global::libxml.XmlExpCtxt.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlExpCtxt(global::libxml.XmlExpCtxt.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlExpCtxt(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }
    }

    public unsafe partial class XmlExpNode
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public partial struct __Internal
        {
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlExpNode> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlExpNode>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlExpNode __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlExpNode(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlExpNode __CreateInstance(global::libxml.XmlExpNode.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlExpNode(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlExpNode.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlExpNode.__Internal));
            *(global::libxml.XmlExpNode.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlExpNode(global::libxml.XmlExpNode.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlExpNode(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }
    }

    public unsafe partial class xmlregexp
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlRegexpCompile")]
            internal static extern global::System.IntPtr XmlRegexpCompile(byte* regexp);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlRegFreeRegexp")]
            internal static extern void XmlRegFreeRegexp(global::System.IntPtr regexp);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlRegexpExec")]
            internal static extern int XmlRegexpExec(global::System.IntPtr comp, byte* value);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlRegexpPrint")]
            internal static extern void XmlRegexpPrint(global::System.IntPtr output, global::System.IntPtr regexp);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlRegexpIsDeterminist")]
            internal static extern int XmlRegexpIsDeterminist(global::System.IntPtr comp);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlRegNewExecCtxt")]
            internal static extern global::System.IntPtr XmlRegNewExecCtxt(global::System.IntPtr comp, global::System.IntPtr callback, global::System.IntPtr data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlRegFreeExecCtxt")]
            internal static extern void XmlRegFreeExecCtxt(global::System.IntPtr exec);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlRegExecPushString")]
            internal static extern int XmlRegExecPushString(global::System.IntPtr exec, byte* value, global::System.IntPtr data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlRegExecPushString2")]
            internal static extern int XmlRegExecPushString2(global::System.IntPtr exec, byte* value, byte* value2, global::System.IntPtr data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlRegExecNextValues")]
            internal static extern int XmlRegExecNextValues(global::System.IntPtr exec, int* nbval, int* nbneg, byte** values, int* terminal);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlRegExecErrInfo")]
            internal static extern int XmlRegExecErrInfo(global::System.IntPtr exec, byte** @string, int* nbval, int* nbneg, byte** values, int* terminal);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlExpFreeCtxt")]
            internal static extern void XmlExpFreeCtxt(global::System.IntPtr ctxt);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlExpNewCtxt")]
            internal static extern global::System.IntPtr XmlExpNewCtxt(int maxNodes, global::System.IntPtr dict);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlExpCtxtNbNodes")]
            internal static extern int XmlExpCtxtNbNodes(global::System.IntPtr ctxt);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlExpCtxtNbCons")]
            internal static extern int XmlExpCtxtNbCons(global::System.IntPtr ctxt);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlExpFree")]
            internal static extern void XmlExpFree(global::System.IntPtr ctxt, global::System.IntPtr expr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlExpRef")]
            internal static extern void XmlExpRef(global::System.IntPtr expr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlExpParse")]
            internal static extern global::System.IntPtr XmlExpParse(global::System.IntPtr ctxt, [MarshalAs(UnmanagedType.LPUTF8Str)] string expr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlExpNewAtom")]
            internal static extern global::System.IntPtr XmlExpNewAtom(global::System.IntPtr ctxt, byte* name, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlExpNewOr")]
            internal static extern global::System.IntPtr XmlExpNewOr(global::System.IntPtr ctxt, global::System.IntPtr left, global::System.IntPtr right);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlExpNewSeq")]
            internal static extern global::System.IntPtr XmlExpNewSeq(global::System.IntPtr ctxt, global::System.IntPtr left, global::System.IntPtr right);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlExpNewRange")]
            internal static extern global::System.IntPtr XmlExpNewRange(global::System.IntPtr ctxt, global::System.IntPtr subset, int min, int max);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlExpIsNillable")]
            internal static extern int XmlExpIsNillable(global::System.IntPtr expr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlExpMaxToken")]
            internal static extern int XmlExpMaxToken(global::System.IntPtr expr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlExpGetLanguage")]
            internal static extern int XmlExpGetLanguage(global::System.IntPtr ctxt, global::System.IntPtr expr, byte** langList, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlExpGetStart")]
            internal static extern int XmlExpGetStart(global::System.IntPtr ctxt, global::System.IntPtr expr, byte** tokList, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlExpStringDerive")]
            internal static extern global::System.IntPtr XmlExpStringDerive(global::System.IntPtr ctxt, global::System.IntPtr expr, byte* str, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlExpExpDerive")]
            internal static extern global::System.IntPtr XmlExpExpDerive(global::System.IntPtr ctxt, global::System.IntPtr expr, global::System.IntPtr sub);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlExpSubsume")]
            internal static extern int XmlExpSubsume(global::System.IntPtr ctxt, global::System.IntPtr expr, global::System.IntPtr sub);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlExpDump")]
            internal static extern void XmlExpDump(global::System.IntPtr buf, global::System.IntPtr expr);
        }

        public static global::libxml.XmlRegexp XmlRegexpCompile(byte* regexp)
        {
            var __ret = __Internal.XmlRegexpCompile(regexp);
            global::libxml.XmlRegexp __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlRegexp.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlRegexp) global::libxml.XmlRegexp.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlRegexp.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlRegFreeRegexp(global::libxml.XmlRegexp regexp)
        {
            var __arg0 = ReferenceEquals(regexp, null) ? global::System.IntPtr.Zero : regexp.__Instance;
            __Internal.XmlRegFreeRegexp(__arg0);
        }

        public static int XmlRegexpExec(global::libxml.XmlRegexp comp, byte* value)
        {
            var __arg0 = ReferenceEquals(comp, null) ? global::System.IntPtr.Zero : comp.__Instance;
            var __ret = __Internal.XmlRegexpExec(__arg0, value);
            return __ret;
        }

        public static void XmlRegexpPrint(global::System.IntPtr output, global::libxml.XmlRegexp regexp)
        {
            var __arg1 = ReferenceEquals(regexp, null) ? global::System.IntPtr.Zero : regexp.__Instance;
            __Internal.XmlRegexpPrint(output, __arg1);
        }

        public static int XmlRegexpIsDeterminist(global::libxml.XmlRegexp comp)
        {
            var __arg0 = ReferenceEquals(comp, null) ? global::System.IntPtr.Zero : comp.__Instance;
            var __ret = __Internal.XmlRegexpIsDeterminist(__arg0);
            return __ret;
        }

        public static global::libxml.XmlRegExecCtxt XmlRegNewExecCtxt(global::libxml.XmlRegexp comp, global::libxml.XmlRegExecCallbacks callback, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(comp, null) ? global::System.IntPtr.Zero : comp.__Instance;
            var __arg1 = callback == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(callback);
            var __ret = __Internal.XmlRegNewExecCtxt(__arg0, __arg1, data);
            global::libxml.XmlRegExecCtxt __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlRegExecCtxt.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlRegExecCtxt) global::libxml.XmlRegExecCtxt.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlRegExecCtxt.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlRegFreeExecCtxt(global::libxml.XmlRegExecCtxt exec)
        {
            var __arg0 = ReferenceEquals(exec, null) ? global::System.IntPtr.Zero : exec.__Instance;
            __Internal.XmlRegFreeExecCtxt(__arg0);
        }

        public static int XmlRegExecPushString(global::libxml.XmlRegExecCtxt exec, byte* value, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(exec, null) ? global::System.IntPtr.Zero : exec.__Instance;
            var __ret = __Internal.XmlRegExecPushString(__arg0, value, data);
            return __ret;
        }

        public static int XmlRegExecPushString2(global::libxml.XmlRegExecCtxt exec, byte* value, byte* value2, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(exec, null) ? global::System.IntPtr.Zero : exec.__Instance;
            var __ret = __Internal.XmlRegExecPushString2(__arg0, value, value2, data);
            return __ret;
        }

        public static int XmlRegExecNextValues(global::libxml.XmlRegExecCtxt exec, ref int nbval, ref int nbneg, byte** values, ref int terminal)
        {
            var __arg0 = ReferenceEquals(exec, null) ? global::System.IntPtr.Zero : exec.__Instance;
            fixed (int* __nbval1 = &nbval)
            {
                var __arg1 = __nbval1;
                fixed (int* __nbneg2 = &nbneg)
                {
                    var __arg2 = __nbneg2;
                    fixed (int* __terminal4 = &terminal)
                    {
                        var __arg4 = __terminal4;
                        var __ret = __Internal.XmlRegExecNextValues(__arg0, __arg1, __arg2, values, __arg4);
                        return __ret;
                    }
                }
            }
        }

        public static int XmlRegExecErrInfo(global::libxml.XmlRegExecCtxt exec, byte** @string, ref int nbval, ref int nbneg, byte** values, ref int terminal)
        {
            var __arg0 = ReferenceEquals(exec, null) ? global::System.IntPtr.Zero : exec.__Instance;
            fixed (int* __nbval2 = &nbval)
            {
                var __arg2 = __nbval2;
                fixed (int* __nbneg3 = &nbneg)
                {
                    var __arg3 = __nbneg3;
                    fixed (int* __terminal5 = &terminal)
                    {
                        var __arg5 = __terminal5;
                        var __ret = __Internal.XmlRegExecErrInfo(__arg0, @string, __arg2, __arg3, values, __arg5);
                        return __ret;
                    }
                }
            }
        }

        public static void XmlExpFreeCtxt(global::libxml.XmlExpCtxt ctxt)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            __Internal.XmlExpFreeCtxt(__arg0);
        }

        public static global::libxml.XmlExpCtxt XmlExpNewCtxt(int maxNodes, global::libxml.XmlDict dict)
        {
            var __arg1 = ReferenceEquals(dict, null) ? global::System.IntPtr.Zero : dict.__Instance;
            var __ret = __Internal.XmlExpNewCtxt(maxNodes, __arg1);
            global::libxml.XmlExpCtxt __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlExpCtxt.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlExpCtxt) global::libxml.XmlExpCtxt.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlExpCtxt.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlExpCtxtNbNodes(global::libxml.XmlExpCtxt ctxt)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __ret = __Internal.XmlExpCtxtNbNodes(__arg0);
            return __ret;
        }

        public static int XmlExpCtxtNbCons(global::libxml.XmlExpCtxt ctxt)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __ret = __Internal.XmlExpCtxtNbCons(__arg0);
            return __ret;
        }

        public static void XmlExpFree(global::libxml.XmlExpCtxt ctxt, global::libxml.XmlExpNode expr)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(expr, null) ? global::System.IntPtr.Zero : expr.__Instance;
            __Internal.XmlExpFree(__arg0, __arg1);
        }

        public static void XmlExpRef(global::libxml.XmlExpNode expr)
        {
            var __arg0 = ReferenceEquals(expr, null) ? global::System.IntPtr.Zero : expr.__Instance;
            __Internal.XmlExpRef(__arg0);
        }

        public static global::libxml.XmlExpNode XmlExpParse(global::libxml.XmlExpCtxt ctxt, string expr)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __ret = __Internal.XmlExpParse(__arg0, expr);
            global::libxml.XmlExpNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlExpNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlExpNode) global::libxml.XmlExpNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlExpNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlExpNode XmlExpNewAtom(global::libxml.XmlExpCtxt ctxt, byte* name, int len)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __ret = __Internal.XmlExpNewAtom(__arg0, name, len);
            global::libxml.XmlExpNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlExpNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlExpNode) global::libxml.XmlExpNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlExpNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlExpNode XmlExpNewOr(global::libxml.XmlExpCtxt ctxt, global::libxml.XmlExpNode left, global::libxml.XmlExpNode right)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(left, null) ? global::System.IntPtr.Zero : left.__Instance;
            var __arg2 = ReferenceEquals(right, null) ? global::System.IntPtr.Zero : right.__Instance;
            var __ret = __Internal.XmlExpNewOr(__arg0, __arg1, __arg2);
            global::libxml.XmlExpNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlExpNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlExpNode) global::libxml.XmlExpNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlExpNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlExpNode XmlExpNewSeq(global::libxml.XmlExpCtxt ctxt, global::libxml.XmlExpNode left, global::libxml.XmlExpNode right)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(left, null) ? global::System.IntPtr.Zero : left.__Instance;
            var __arg2 = ReferenceEquals(right, null) ? global::System.IntPtr.Zero : right.__Instance;
            var __ret = __Internal.XmlExpNewSeq(__arg0, __arg1, __arg2);
            global::libxml.XmlExpNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlExpNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlExpNode) global::libxml.XmlExpNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlExpNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlExpNode XmlExpNewRange(global::libxml.XmlExpCtxt ctxt, global::libxml.XmlExpNode subset, int min, int max)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(subset, null) ? global::System.IntPtr.Zero : subset.__Instance;
            var __ret = __Internal.XmlExpNewRange(__arg0, __arg1, min, max);
            global::libxml.XmlExpNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlExpNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlExpNode) global::libxml.XmlExpNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlExpNode.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlExpIsNillable(global::libxml.XmlExpNode expr)
        {
            var __arg0 = ReferenceEquals(expr, null) ? global::System.IntPtr.Zero : expr.__Instance;
            var __ret = __Internal.XmlExpIsNillable(__arg0);
            return __ret;
        }

        public static int XmlExpMaxToken(global::libxml.XmlExpNode expr)
        {
            var __arg0 = ReferenceEquals(expr, null) ? global::System.IntPtr.Zero : expr.__Instance;
            var __ret = __Internal.XmlExpMaxToken(__arg0);
            return __ret;
        }

        public static int XmlExpGetLanguage(global::libxml.XmlExpCtxt ctxt, global::libxml.XmlExpNode expr, byte** langList, int len)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(expr, null) ? global::System.IntPtr.Zero : expr.__Instance;
            var __ret = __Internal.XmlExpGetLanguage(__arg0, __arg1, langList, len);
            return __ret;
        }

        public static int XmlExpGetStart(global::libxml.XmlExpCtxt ctxt, global::libxml.XmlExpNode expr, byte** tokList, int len)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(expr, null) ? global::System.IntPtr.Zero : expr.__Instance;
            var __ret = __Internal.XmlExpGetStart(__arg0, __arg1, tokList, len);
            return __ret;
        }

        public static global::libxml.XmlExpNode XmlExpStringDerive(global::libxml.XmlExpCtxt ctxt, global::libxml.XmlExpNode expr, byte* str, int len)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(expr, null) ? global::System.IntPtr.Zero : expr.__Instance;
            var __ret = __Internal.XmlExpStringDerive(__arg0, __arg1, str, len);
            global::libxml.XmlExpNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlExpNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlExpNode) global::libxml.XmlExpNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlExpNode.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlExpNode XmlExpExpDerive(global::libxml.XmlExpCtxt ctxt, global::libxml.XmlExpNode expr, global::libxml.XmlExpNode sub)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(expr, null) ? global::System.IntPtr.Zero : expr.__Instance;
            var __arg2 = ReferenceEquals(sub, null) ? global::System.IntPtr.Zero : sub.__Instance;
            var __ret = __Internal.XmlExpExpDerive(__arg0, __arg1, __arg2);
            global::libxml.XmlExpNode __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlExpNode.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlExpNode) global::libxml.XmlExpNode.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlExpNode.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlExpSubsume(global::libxml.XmlExpCtxt ctxt, global::libxml.XmlExpNode expr, global::libxml.XmlExpNode sub)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(expr, null) ? global::System.IntPtr.Zero : expr.__Instance;
            var __arg2 = ReferenceEquals(sub, null) ? global::System.IntPtr.Zero : sub.__Instance;
            var __ret = __Internal.XmlExpSubsume(__arg0, __arg1, __arg2);
            return __ret;
        }

        public static void XmlExpDump(global::libxml.XmlBuffer buf, global::libxml.XmlExpNode expr)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __arg1 = ReferenceEquals(expr, null) ? global::System.IntPtr.Zero : expr.__Instance;
            __Internal.XmlExpDump(__arg0, __arg1);
        }
    }

    public unsafe partial class XmlDict
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public partial struct __Internal
        {
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlDict> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlDict>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlDict __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlDict(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlDict __CreateInstance(global::libxml.XmlDict.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlDict(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlDict.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlDict.__Internal));
            *(global::libxml.XmlDict.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlDict(global::libxml.XmlDict.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlDict(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }
    }

    public unsafe partial class dict
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlInitializeDict")]
            internal static extern int XmlInitializeDict();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDictCreate")]
            internal static extern global::System.IntPtr XmlDictCreate();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDictSetLimit")]
            internal static extern uint XmlDictSetLimit(global::System.IntPtr dict, uint limit);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDictGetUsage")]
            internal static extern uint XmlDictGetUsage(global::System.IntPtr dict);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDictCreateSub")]
            internal static extern global::System.IntPtr XmlDictCreateSub(global::System.IntPtr sub);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDictReference")]
            internal static extern int XmlDictReference(global::System.IntPtr dict);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDictFree")]
            internal static extern void XmlDictFree(global::System.IntPtr dict);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDictLookup")]
            internal static extern byte* XmlDictLookup(global::System.IntPtr dict, byte* name, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDictExists")]
            internal static extern byte* XmlDictExists(global::System.IntPtr dict, byte* name, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDictQLookup")]
            internal static extern byte* XmlDictQLookup(global::System.IntPtr dict, byte* prefix, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDictOwns")]
            internal static extern int XmlDictOwns(global::System.IntPtr dict, byte* str);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDictSize")]
            internal static extern int XmlDictSize(global::System.IntPtr dict);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDictCleanup")]
            internal static extern void XmlDictCleanup();
        }

        public static int XmlInitializeDict()
        {
            var __ret = __Internal.XmlInitializeDict();
            return __ret;
        }

        public static global::libxml.XmlDict XmlDictCreate()
        {
            var __ret = __Internal.XmlDictCreate();
            global::libxml.XmlDict __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDict.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDict) global::libxml.XmlDict.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDict.__CreateInstance(__ret);
            return __result0;
        }

        public static uint XmlDictSetLimit(global::libxml.XmlDict dict, uint limit)
        {
            var __arg0 = ReferenceEquals(dict, null) ? global::System.IntPtr.Zero : dict.__Instance;
            var __ret = __Internal.XmlDictSetLimit(__arg0, limit);
            return __ret;
        }

        public static uint XmlDictGetUsage(global::libxml.XmlDict dict)
        {
            var __arg0 = ReferenceEquals(dict, null) ? global::System.IntPtr.Zero : dict.__Instance;
            var __ret = __Internal.XmlDictGetUsage(__arg0);
            return __ret;
        }

        public static global::libxml.XmlDict XmlDictCreateSub(global::libxml.XmlDict sub)
        {
            var __arg0 = ReferenceEquals(sub, null) ? global::System.IntPtr.Zero : sub.__Instance;
            var __ret = __Internal.XmlDictCreateSub(__arg0);
            global::libxml.XmlDict __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDict.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDict) global::libxml.XmlDict.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDict.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlDictReference(global::libxml.XmlDict dict)
        {
            var __arg0 = ReferenceEquals(dict, null) ? global::System.IntPtr.Zero : dict.__Instance;
            var __ret = __Internal.XmlDictReference(__arg0);
            return __ret;
        }

        public static void XmlDictFree(global::libxml.XmlDict dict)
        {
            var __arg0 = ReferenceEquals(dict, null) ? global::System.IntPtr.Zero : dict.__Instance;
            __Internal.XmlDictFree(__arg0);
        }

        public static byte* XmlDictLookup(global::libxml.XmlDict dict, byte* name, int len)
        {
            var __arg0 = ReferenceEquals(dict, null) ? global::System.IntPtr.Zero : dict.__Instance;
            var __ret = __Internal.XmlDictLookup(__arg0, name, len);
            return __ret;
        }

        public static byte* XmlDictExists(global::libxml.XmlDict dict, byte* name, int len)
        {
            var __arg0 = ReferenceEquals(dict, null) ? global::System.IntPtr.Zero : dict.__Instance;
            var __ret = __Internal.XmlDictExists(__arg0, name, len);
            return __ret;
        }

        public static byte* XmlDictQLookup(global::libxml.XmlDict dict, byte* prefix, byte* name)
        {
            var __arg0 = ReferenceEquals(dict, null) ? global::System.IntPtr.Zero : dict.__Instance;
            var __ret = __Internal.XmlDictQLookup(__arg0, prefix, name);
            return __ret;
        }

        public static int XmlDictOwns(global::libxml.XmlDict dict, byte* str)
        {
            var __arg0 = ReferenceEquals(dict, null) ? global::System.IntPtr.Zero : dict.__Instance;
            var __ret = __Internal.XmlDictOwns(__arg0, str);
            return __ret;
        }

        public static int XmlDictSize(global::libxml.XmlDict dict)
        {
            var __arg0 = ReferenceEquals(dict, null) ? global::System.IntPtr.Zero : dict.__Instance;
            var __ret = __Internal.XmlDictSize(__arg0);
            return __ret;
        }

        public static void XmlDictCleanup()
        {
            __Internal.XmlDictCleanup();
        }
    }

    /// <summary>
    /// <para>xmlHashDeallocator:</para>
    /// <para>the data in the hash</para>
    /// </summary>
    /// <remarks>Callback to free data from a hash.</remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void XmlHashDeallocator(global::System.IntPtr payload, byte* name);

    /// <summary>
    /// <para>xmlHashCopier:</para>
    /// <para>the data in the hash</para>
    /// </summary>
    /// <remarks>
    /// <para>Callback to copy data from a hash.</para>
    /// <para>Returns a copy of the data or NULL in case of error.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate global::System.IntPtr XmlHashCopier(global::System.IntPtr payload, byte* name);

    /// <summary>
    /// <para>xmlHashScanner:</para>
    /// <para>the data in the hash</para>
    /// </summary>
    /// <remarks>
    /// <para>:  extra scannner data</para>
    /// <para>Callback when scanning data in a hash with the simple scanner.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void XmlHashScanner(global::System.IntPtr payload, global::System.IntPtr data, byte* name);

    /// <summary>
    /// <para>xmlHashScannerFull:</para>
    /// <para>the data in the hash</para>
    /// </summary>
    /// <remarks>
    /// <para>:  extra scannner data</para>
    /// <para>Callback when scanning data in a hash with the full scanner.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void XmlHashScannerFull(global::System.IntPtr payload, global::System.IntPtr data, byte* name, byte* name2, byte* name3);

    public unsafe partial class XmlHashTable
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public partial struct __Internal
        {
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlHashTable> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlHashTable>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlHashTable __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlHashTable(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlHashTable __CreateInstance(global::libxml.XmlHashTable.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlHashTable(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlHashTable.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlHashTable.__Internal));
            *(global::libxml.XmlHashTable.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlHashTable(global::libxml.XmlHashTable.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlHashTable(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }
    }

    public unsafe partial class hash
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashCreate")]
            internal static extern global::System.IntPtr XmlHashCreate(int size);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashCreateDict")]
            internal static extern global::System.IntPtr XmlHashCreateDict(int size, global::System.IntPtr dict);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashFree")]
            internal static extern void XmlHashFree(global::System.IntPtr table, global::System.IntPtr f);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashDefaultDeallocator")]
            internal static extern void XmlHashDefaultDeallocator(global::System.IntPtr entry, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashAddEntry")]
            internal static extern int XmlHashAddEntry(global::System.IntPtr table, byte* name, global::System.IntPtr userdata);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashUpdateEntry")]
            internal static extern int XmlHashUpdateEntry(global::System.IntPtr table, byte* name, global::System.IntPtr userdata, global::System.IntPtr f);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashAddEntry2")]
            internal static extern int XmlHashAddEntry2(global::System.IntPtr table, byte* name, byte* name2, global::System.IntPtr userdata);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashUpdateEntry2")]
            internal static extern int XmlHashUpdateEntry2(global::System.IntPtr table, byte* name, byte* name2, global::System.IntPtr userdata, global::System.IntPtr f);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashAddEntry3")]
            internal static extern int XmlHashAddEntry3(global::System.IntPtr table, byte* name, byte* name2, byte* name3, global::System.IntPtr userdata);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashUpdateEntry3")]
            internal static extern int XmlHashUpdateEntry3(global::System.IntPtr table, byte* name, byte* name2, byte* name3, global::System.IntPtr userdata, global::System.IntPtr f);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashRemoveEntry")]
            internal static extern int XmlHashRemoveEntry(global::System.IntPtr table, byte* name, global::System.IntPtr f);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashRemoveEntry2")]
            internal static extern int XmlHashRemoveEntry2(global::System.IntPtr table, byte* name, byte* name2, global::System.IntPtr f);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashRemoveEntry3")]
            internal static extern int XmlHashRemoveEntry3(global::System.IntPtr table, byte* name, byte* name2, byte* name3, global::System.IntPtr f);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashLookup")]
            internal static extern global::System.IntPtr XmlHashLookup(global::System.IntPtr table, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashLookup2")]
            internal static extern global::System.IntPtr XmlHashLookup2(global::System.IntPtr table, byte* name, byte* name2);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashLookup3")]
            internal static extern global::System.IntPtr XmlHashLookup3(global::System.IntPtr table, byte* name, byte* name2, byte* name3);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashQLookup")]
            internal static extern global::System.IntPtr XmlHashQLookup(global::System.IntPtr table, byte* name, byte* prefix);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashQLookup2")]
            internal static extern global::System.IntPtr XmlHashQLookup2(global::System.IntPtr table, byte* name, byte* prefix, byte* name2, byte* prefix2);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashQLookup3")]
            internal static extern global::System.IntPtr XmlHashQLookup3(global::System.IntPtr table, byte* name, byte* prefix, byte* name2, byte* prefix2, byte* name3, byte* prefix3);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashCopy")]
            internal static extern global::System.IntPtr XmlHashCopy(global::System.IntPtr table, global::System.IntPtr f);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashSize")]
            internal static extern int XmlHashSize(global::System.IntPtr table);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashScan")]
            internal static extern void XmlHashScan(global::System.IntPtr table, global::System.IntPtr f, global::System.IntPtr data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashScan3")]
            internal static extern void XmlHashScan3(global::System.IntPtr table, byte* name, byte* name2, byte* name3, global::System.IntPtr f, global::System.IntPtr data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashScanFull")]
            internal static extern void XmlHashScanFull(global::System.IntPtr table, global::System.IntPtr f, global::System.IntPtr data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHashScanFull3")]
            internal static extern void XmlHashScanFull3(global::System.IntPtr table, byte* name, byte* name2, byte* name3, global::System.IntPtr f, global::System.IntPtr data);
        }

        public static global::libxml.XmlHashTable XmlHashCreate(int size)
        {
            var __ret = __Internal.XmlHashCreate(size);
            global::libxml.XmlHashTable __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlHashTable.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlHashTable) global::libxml.XmlHashTable.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlHashTable.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlHashTable XmlHashCreateDict(int size, global::libxml.XmlDict dict)
        {
            var __arg1 = ReferenceEquals(dict, null) ? global::System.IntPtr.Zero : dict.__Instance;
            var __ret = __Internal.XmlHashCreateDict(size, __arg1);
            global::libxml.XmlHashTable __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlHashTable.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlHashTable) global::libxml.XmlHashTable.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlHashTable.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlHashFree(global::libxml.XmlHashTable table, global::libxml.XmlHashDeallocator f)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __arg1 = f == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(f);
            __Internal.XmlHashFree(__arg0, __arg1);
        }

        public static void XmlHashDefaultDeallocator(global::System.IntPtr entry, byte* name)
        {
            __Internal.XmlHashDefaultDeallocator(entry, name);
        }

        public static int XmlHashAddEntry(global::libxml.XmlHashTable table, byte* name, global::System.IntPtr userdata)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __ret = __Internal.XmlHashAddEntry(__arg0, name, userdata);
            return __ret;
        }

        public static int XmlHashUpdateEntry(global::libxml.XmlHashTable table, byte* name, global::System.IntPtr userdata, global::libxml.XmlHashDeallocator f)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __arg3 = f == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(f);
            var __ret = __Internal.XmlHashUpdateEntry(__arg0, name, userdata, __arg3);
            return __ret;
        }

        public static int XmlHashAddEntry2(global::libxml.XmlHashTable table, byte* name, byte* name2, global::System.IntPtr userdata)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __ret = __Internal.XmlHashAddEntry2(__arg0, name, name2, userdata);
            return __ret;
        }

        public static int XmlHashUpdateEntry2(global::libxml.XmlHashTable table, byte* name, byte* name2, global::System.IntPtr userdata, global::libxml.XmlHashDeallocator f)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __arg4 = f == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(f);
            var __ret = __Internal.XmlHashUpdateEntry2(__arg0, name, name2, userdata, __arg4);
            return __ret;
        }

        public static int XmlHashAddEntry3(global::libxml.XmlHashTable table, byte* name, byte* name2, byte* name3, global::System.IntPtr userdata)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __ret = __Internal.XmlHashAddEntry3(__arg0, name, name2, name3, userdata);
            return __ret;
        }

        public static int XmlHashUpdateEntry3(global::libxml.XmlHashTable table, byte* name, byte* name2, byte* name3, global::System.IntPtr userdata, global::libxml.XmlHashDeallocator f)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __arg5 = f == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(f);
            var __ret = __Internal.XmlHashUpdateEntry3(__arg0, name, name2, name3, userdata, __arg5);
            return __ret;
        }

        public static int XmlHashRemoveEntry(global::libxml.XmlHashTable table, byte* name, global::libxml.XmlHashDeallocator f)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __arg2 = f == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(f);
            var __ret = __Internal.XmlHashRemoveEntry(__arg0, name, __arg2);
            return __ret;
        }

        public static int XmlHashRemoveEntry2(global::libxml.XmlHashTable table, byte* name, byte* name2, global::libxml.XmlHashDeallocator f)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __arg3 = f == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(f);
            var __ret = __Internal.XmlHashRemoveEntry2(__arg0, name, name2, __arg3);
            return __ret;
        }

        public static int XmlHashRemoveEntry3(global::libxml.XmlHashTable table, byte* name, byte* name2, byte* name3, global::libxml.XmlHashDeallocator f)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __arg4 = f == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(f);
            var __ret = __Internal.XmlHashRemoveEntry3(__arg0, name, name2, name3, __arg4);
            return __ret;
        }

        public static global::System.IntPtr XmlHashLookup(global::libxml.XmlHashTable table, byte* name)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __ret = __Internal.XmlHashLookup(__arg0, name);
            return __ret;
        }

        public static global::System.IntPtr XmlHashLookup2(global::libxml.XmlHashTable table, byte* name, byte* name2)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __ret = __Internal.XmlHashLookup2(__arg0, name, name2);
            return __ret;
        }

        public static global::System.IntPtr XmlHashLookup3(global::libxml.XmlHashTable table, byte* name, byte* name2, byte* name3)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __ret = __Internal.XmlHashLookup3(__arg0, name, name2, name3);
            return __ret;
        }

        public static global::System.IntPtr XmlHashQLookup(global::libxml.XmlHashTable table, byte* name, byte* prefix)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __ret = __Internal.XmlHashQLookup(__arg0, name, prefix);
            return __ret;
        }

        public static global::System.IntPtr XmlHashQLookup2(global::libxml.XmlHashTable table, byte* name, byte* prefix, byte* name2, byte* prefix2)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __ret = __Internal.XmlHashQLookup2(__arg0, name, prefix, name2, prefix2);
            return __ret;
        }

        public static global::System.IntPtr XmlHashQLookup3(global::libxml.XmlHashTable table, byte* name, byte* prefix, byte* name2, byte* prefix2, byte* name3, byte* prefix3)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __ret = __Internal.XmlHashQLookup3(__arg0, name, prefix, name2, prefix2, name3, prefix3);
            return __ret;
        }

        public static global::libxml.XmlHashTable XmlHashCopy(global::libxml.XmlHashTable table, global::libxml.XmlHashCopier f)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __arg1 = f == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(f);
            var __ret = __Internal.XmlHashCopy(__arg0, __arg1);
            global::libxml.XmlHashTable __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlHashTable.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlHashTable) global::libxml.XmlHashTable.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlHashTable.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlHashSize(global::libxml.XmlHashTable table)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __ret = __Internal.XmlHashSize(__arg0);
            return __ret;
        }

        public static void XmlHashScan(global::libxml.XmlHashTable table, global::libxml.XmlHashScanner f, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __arg1 = f == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(f);
            __Internal.XmlHashScan(__arg0, __arg1, data);
        }

        public static void XmlHashScan3(global::libxml.XmlHashTable table, byte* name, byte* name2, byte* name3, global::libxml.XmlHashScanner f, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __arg4 = f == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(f);
            __Internal.XmlHashScan3(__arg0, name, name2, name3, __arg4, data);
        }

        public static void XmlHashScanFull(global::libxml.XmlHashTable table, global::libxml.XmlHashScannerFull f, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __arg1 = f == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(f);
            __Internal.XmlHashScanFull(__arg0, __arg1, data);
        }

        public static void XmlHashScanFull3(global::libxml.XmlHashTable table, byte* name, byte* name2, byte* name3, global::libxml.XmlHashScannerFull f, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __arg4 = f == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(f);
            __Internal.XmlHashScanFull3(__arg0, name, name2, name3, __arg4, data);
        }
    }

    /// <summary>xmlParserInputState:</summary>
    /// <remarks>
    /// <para>The parser is now working also as a state based parser.</para>
    /// <para>The recursive one use the state info for entities processing.</para>
    /// </remarks>
    public enum XmlParserInputState
    {
        XML_PARSER_EOF = -1,
        XML_PARSER_START = 0,
        XML_PARSER_MISC = 1,
        XML_PARSER_PI = 2,
        XML_PARSER_DTD = 3,
        XML_PARSER_PROLOG = 4,
        XML_PARSER_COMMENT = 5,
        XML_PARSER_START_TAG = 6,
        XML_PARSER_CONTENT = 7,
        XML_PARSER_CDATA_SECTION = 8,
        XML_PARSER_END_TAG = 9,
        XML_PARSER_ENTITY_DECL = 10,
        XML_PARSER_ENTITY_VALUE = 11,
        XML_PARSER_ATTRIBUTE_VALUE = 12,
        XML_PARSER_SYSTEM_LITERAL = 13,
        XML_PARSER_EPILOG = 14,
        XML_PARSER_IGNORE = 15,
        XML_PARSER_PUBLIC_LITERAL = 16
    }

    /// <summary>xmlParserMode:</summary>
    /// <remarks>A parser can operate in various modes</remarks>
    public enum XmlParserMode : uint
    {
        XML_PARSE_UNKNOWN = 0,
        XML_PARSE_DOM = 1,
        XML_PARSE_SAX = 2,
        XML_PARSE_PUSH_DOM = 3,
        XML_PARSE_PUSH_SAX = 4,
        XML_PARSE_READER = 5
    }

    /// <summary>xmlParserOption:</summary>
    /// <remarks>
    /// <para>This is the set of XML parser options that can be passed down</para>
    /// <para>to the xmlReadDoc() and similar calls.</para>
    /// </remarks>
    [Flags]
    public enum XmlParserOption : uint
    {
        XML_PARSE_RECOVER = 1,
        XML_PARSE_NOENT = 2,
        XML_PARSE_DTDLOAD = 4,
        XML_PARSE_DTDATTR = 8,
        XML_PARSE_DTDVALID = 16,
        XML_PARSE_NOERROR = 32,
        XML_PARSE_NOWARNING = 64,
        XML_PARSE_PEDANTIC = 128,
        XML_PARSE_NOBLANKS = 256,
        XML_PARSE_SAX1 = 512,
        XML_PARSE_XINCLUDE = 1024,
        XML_PARSE_NONET = 2048,
        XML_PARSE_NODICT = 4096,
        XML_PARSE_NSCLEAN = 8192,
        XML_PARSE_NOCDATA = 16384,
        XML_PARSE_NOXINCNODE = 32768,
        XML_PARSE_COMPACT = 65536,
        XML_PARSE_OLD10 = 131072,
        XML_PARSE_NOBASEFIX = 262144,
        XML_PARSE_HUGE = 524288,
        XML_PARSE_OLDSAX = 1048576,
        XML_PARSE_IGNORE_ENC = 2097152,
        XML_PARSE_BIG_LINES = 4194304
    }

    /// <summary>xmlFeature:</summary>
    /// <remarks>
    /// <para>Used to examine the existance of features that can be enabled</para>
    /// <para>or disabled at compile-time.</para>
    /// <para>They used to be called XML_FEATURE_xxx but this clashed with Expat</para>
    /// </remarks>
    public enum XmlFeature : uint
    {
        XML_WITH_THREAD = 1,
        XML_WITH_TREE = 2,
        XML_WITH_OUTPUT = 3,
        XML_WITH_PUSH = 4,
        XML_WITH_READER = 5,
        XML_WITH_PATTERN = 6,
        XML_WITH_WRITER = 7,
        XML_WITH_SAX1 = 8,
        XML_WITH_FTP = 9,
        XML_WITH_HTTP = 10,
        XML_WITH_VALID = 11,
        XML_WITH_HTML = 12,
        XML_WITH_LEGACY = 13,
        XML_WITH_C14N = 14,
        XML_WITH_CATALOG = 15,
        XML_WITH_XPATH = 16,
        XML_WITH_XPTR = 17,
        XML_WITH_XINCLUDE = 18,
        XML_WITH_ICONV = 19,
        XML_WITH_ISO8859X = 20,
        XML_WITH_UNICODE = 21,
        XML_WITH_REGEXP = 22,
        XML_WITH_AUTOMATA = 23,
        XML_WITH_EXPR = 24,
        XML_WITH_SCHEMAS = 25,
        XML_WITH_SCHEMATRON = 26,
        XML_WITH_MODULES = 27,
        XML_WITH_DEBUG = 28,
        XML_WITH_DEBUG_MEM = 29,
        XML_WITH_DEBUG_RUN = 30,
        XML_WITH_ZLIB = 31,
        XML_WITH_ICU = 32,
        XML_WITH_LZMA = 33,
        XML_WITH_NONE = 99999
    }

    /// <summary>
    /// <para>xmlParserInputDeallocate:</para>
    /// <para>the string to deallocate</para>
    /// </summary>
    /// <remarks>Callback for freeing some parser input allocations.</remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void XmlParserInputDeallocate(byte* str);

    /// <summary>
    /// <para>internalSubsetSAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// </summary>
    /// <remarks>
    /// <para>the external ID</para>
    /// <para>the SYSTEM ID (e.g. filename or URL)</para>
    /// <para>Callback on internal subset declaration.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void InternalSubsetSAXFunc(global::System.IntPtr ctx, byte* name, byte* ExternalID, byte* SystemID);

    /// <summary>
    /// <para>isStandaloneSAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// </summary>
    /// <remarks>
    /// <para>Is this document tagged standalone?</para>
    /// <para>Returns 1 if true</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate int IsStandaloneSAXFunc(global::System.IntPtr ctx);

    /// <summary>
    /// <para>hasInternalSubsetSAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// </summary>
    /// <remarks>
    /// <para>Does this document has an internal subset.</para>
    /// <para>Returns 1 if true</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate int HasInternalSubsetSAXFunc(global::System.IntPtr ctx);

    /// <summary>
    /// <para>hasExternalSubsetSAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// </summary>
    /// <remarks>
    /// <para>Does this document has an external subset?</para>
    /// <para>Returns 1 if true</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate int HasExternalSubsetSAXFunc(global::System.IntPtr ctx);

    /// <summary>
    /// <para>resolveEntitySAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// <para>The public ID of the entity</para>
    /// <para>The system ID of the entity</para>
    /// </summary>
    /// <remarks>
    /// <para>Callback:</para>
    /// <para>The entity loader, to control the loading of external entities,</para>
    /// <para>the application can either:</para>
    /// <para>- override this resolveEntity() callback in the SAX block</para>
    /// <para>- or better use the xmlSetExternalEntityLoader() function to</para>
    /// <para>set up it's own entity resolution routine</para>
    /// <para>Returns the xmlParserInputPtr if inlined or NULL for DOM behaviour.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate global::System.IntPtr ResolveEntitySAXFunc(global::System.IntPtr ctx, byte* publicId, byte* systemId);

    /// <summary>
    /// <para>getEntitySAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// </summary>
    /// <remarks>
    /// <para>Get an entity by name.</para>
    /// <para>Returns the xmlEntityPtr if found.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate global::System.IntPtr GetEntitySAXFunc(global::System.IntPtr ctx, byte* name);

    /// <summary>
    /// <para>entityDeclSAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// </summary>
    /// <remarks>
    /// <para>the entity type</para>
    /// <para>The public ID of the entity</para>
    /// <para>The system ID of the entity</para>
    /// <para>the entity value (without processing).</para>
    /// <para>An entity definition has been parsed.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void EntityDeclSAXFunc(global::System.IntPtr ctx, byte* name, int type, byte* publicId, byte* systemId, byte* content);

    /// <summary>
    /// <para>notationDeclSAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// </summary>
    /// <remarks>
    /// <para>The public ID of the entity</para>
    /// <para>The system ID of the entity</para>
    /// <para>What to do when a notation declaration has been parsed.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void NotationDeclSAXFunc(global::System.IntPtr ctx, byte* name, byte* publicId, byte* systemId);

    /// <summary>
    /// <para>attributeDeclSAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// <para>the name of the element</para>
    /// <para>the attribute name</para>
    /// <para>the attribute type</para>
    /// </summary>
    /// <remarks>
    /// <para>the attribute default value</para>
    /// <para>the tree of enumerated value set</para>
    /// <para>An attribute definition has been parsed.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void AttributeDeclSAXFunc(global::System.IntPtr ctx, byte* elem, byte* fullname, int type, int def, byte* defaultValue, global::System.IntPtr tree);

    /// <summary>
    /// <para>elementDeclSAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// </summary>
    /// <remarks>
    /// <para>the element type</para>
    /// <para>the element value tree</para>
    /// <para>An element definition has been parsed.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void ElementDeclSAXFunc(global::System.IntPtr ctx, byte* name, int type, global::System.IntPtr content);

    /// <summary>
    /// <para>unparsedEntityDeclSAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// </summary>
    /// <remarks>
    /// <para>The public ID of the entity</para>
    /// <para>The system ID of the entity</para>
    /// <para>the name of the notation</para>
    /// <para>What to do when an unparsed entity declaration is parsed.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void UnparsedEntityDeclSAXFunc(global::System.IntPtr ctx, byte* name, byte* publicId, byte* systemId, byte* notationName);

    /// <summary>
    /// <para>setDocumentLocatorSAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// <para>A SAX Locator</para>
    /// </summary>
    /// <remarks>
    /// <para>Receive the document locator at startup, actually xmlDefaultSAXLocator.</para>
    /// <para>Everything is available on the context, so this is useless in our case.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void SetDocumentLocatorSAXFunc(global::System.IntPtr ctx, global::System.IntPtr loc);

    /// <summary>
    /// <para>startDocumentSAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// </summary>
    /// <remarks>Called when the document start being processed.</remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void StartDocumentSAXFunc(global::System.IntPtr ctx);

    /// <summary>
    /// <para>endDocumentSAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// </summary>
    /// <remarks>Called when the document end has been detected.</remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void EndDocumentSAXFunc(global::System.IntPtr ctx);

    /// <summary>
    /// <para>startElementSAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// </summary>
    /// <remarks>
    /// <para>An array of name/value attributes pairs, NULL terminated</para>
    /// <para>Called when an opening tag has been processed.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void StartElementSAXFunc(global::System.IntPtr ctx, byte* name, byte** atts);

    /// <summary>
    /// <para>endElementSAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// </summary>
    /// <remarks>Called when the end of an element has been detected.</remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void EndElementSAXFunc(global::System.IntPtr ctx, byte* name);

    /// <summary>
    /// <para>referenceSAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// </summary>
    /// <remarks>Called when an entity reference is detected.</remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void ReferenceSAXFunc(global::System.IntPtr ctx, byte* name);

    /// <summary>
    /// <para>charactersSAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// <para>a xmlChar string</para>
    /// <para>the number of xmlChar</para>
    /// </summary>
    /// <remarks>Receiving some chars from the parser.</remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void CharactersSAXFunc(global::System.IntPtr ctx, byte* ch, int len);

    /// <summary>
    /// <para>ignorableWhitespaceSAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// <para>a xmlChar string</para>
    /// <para>the number of xmlChar</para>
    /// </summary>
    /// <remarks>
    /// <para>Receiving some ignorable whitespaces from the parser.</para>
    /// <para>UNUSED: by default the DOM building will use characters.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void IgnorableWhitespaceSAXFunc(global::System.IntPtr ctx, byte* ch, int len);

    /// <summary>
    /// <para>processingInstructionSAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// <para>the target name</para>
    /// </summary>
    /// <remarks>
    /// <para>: the PI data's</para>
    /// <para>A processing instruction has been parsed.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void ProcessingInstructionSAXFunc(global::System.IntPtr ctx, byte* target, byte* data);

    /// <summary>
    /// <para>commentSAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// <para>the comment content</para>
    /// </summary>
    /// <remarks>A comment has been parsed.</remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void CommentSAXFunc(global::System.IntPtr ctx, byte* value);

    /// <summary>
    /// <para>warningSAXFunc:</para>
    /// <para>an XML parser context</para>
    /// </summary>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void WarningSAXFunc(global::System.IntPtr ctx, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

    /// <summary>
    /// <para>errorSAXFunc:</para>
    /// <para>an XML parser context</para>
    /// </summary>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void ErrorSAXFunc(global::System.IntPtr ctx, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

    /// <summary>
    /// <para>fatalErrorSAXFunc:</para>
    /// <para>an XML parser context</para>
    /// </summary>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void FatalErrorSAXFunc(global::System.IntPtr ctx, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

    /// <summary>
    /// <para>getParameterEntitySAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// </summary>
    /// <remarks>
    /// <para>Get a parameter entity by name.</para>
    /// <para>Returns the xmlEntityPtr if found.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate global::System.IntPtr GetParameterEntitySAXFunc(global::System.IntPtr ctx, byte* name);

    /// <summary>
    /// <para>cdataBlockSAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// <para>The pcdata content</para>
    /// <para>the block length</para>
    /// </summary>
    /// <remarks>Called when a pcdata block has been parsed.</remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void CdataBlockSAXFunc(global::System.IntPtr ctx, byte* value, int len);

    /// <summary>
    /// <para>externalSubsetSAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// </summary>
    /// <remarks>
    /// <para>the external ID</para>
    /// <para>the SYSTEM ID (e.g. filename or URL)</para>
    /// <para>Callback on external subset declaration.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void ExternalSubsetSAXFunc(global::System.IntPtr ctx, byte* name, byte* ExternalID, byte* SystemID);

    /// <summary>
    /// <para>startElementNsSAX2Func:</para>
    /// <para>the user data (XML parser context)</para>
    /// <para>the local name of the element</para>
    /// <para>the element namespace prefix if available</para>
    /// <para>the element namespace name if available</para>
    /// <para> <c>_namespaces:</c> number of namespace definitions on that node</para>
    /// </summary>
    /// <remarks>
    /// <para> <c>_attributes:</c> the number of attributes on that node</para>
    /// <para> <c>_defaulted:</c> the number of defaulted attributes. The defaulted</para>
    /// <para>ones are at the end of the array</para>
    /// <para>pointer to the array of (localname/prefix/URI/value/end)</para>
    /// <para>attribute values.</para>
    /// <para>SAX2 callback when an element start has been detected by the parser.</para>
    /// <para>It provides the namespace informations for the element, as well as</para>
    /// <para>the new namespace declarations on the element.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void StartElementNsSAX2Func(global::System.IntPtr ctx, byte* localname, byte* prefix, byte* URI, int nb_namespaces, byte** namespaces, int nb_attributes, int nb_defaulted, byte** attributes);

    /// <summary>
    /// <para>endElementNsSAX2Func:</para>
    /// <para>the user data (XML parser context)</para>
    /// <para>the local name of the element</para>
    /// <para>the element namespace prefix if available</para>
    /// <para>the element namespace name if available</para>
    /// </summary>
    /// <remarks>
    /// <para>SAX2 callback when an element end has been detected by the parser.</para>
    /// <para>It provides the namespace informations for the element.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void EndElementNsSAX2Func(global::System.IntPtr ctx, byte* localname, byte* prefix, byte* URI);

    /// <summary>xmlParserNodeInfo:</summary>
    /// <remarks>
    /// <para>The parser can be asked to collect Node informations, i.e. at what</para>
    /// <para>place in the file they were detected.</para>
    /// <para>NOTE: This is off by default and not very well tested.</para>
    /// </remarks>
    /// <summary>xmlParserInputState:</summary>
    /// <remarks>
    /// <para>The parser is now working also as a state based parser.</para>
    /// <para>The recursive one use the state info for entities processing.</para>
    /// </remarks>
    /// <summary>xmlParserMode:</summary>
    /// <remarks>A parser can operate in various modes</remarks>
    /// <summary>
    /// <para>attributeSAXFunc:</para>
    /// <para>the user data (XML parser context)</para>
    /// </summary>
    /// <remarks>
    /// <para>The attribute value</para>
    /// <para>Handle an attribute that has been read by the parser.</para>
    /// <para>The default handling is to convert the attribute into an</para>
    /// <para>DOM subtree and past it in a new xmlAttr element added to</para>
    /// <para>the element.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void AttributeSAXFunc(global::System.IntPtr ctx, byte* name, byte* value);

    /// <summary>
    /// <para>xmlExternalEntityLoader:</para>
    /// <para>The System ID of the resource requested</para>
    /// <para>The Public ID of the resource requested</para>
    /// <para>the XML parser context</para>
    /// </summary>
    /// <remarks>
    /// <para>External entity loaders types.</para>
    /// <para>Returns the entity input parser.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate global::System.IntPtr XmlExternalEntityLoader([MarshalAs(UnmanagedType.LPUTF8Str)] string URL, [MarshalAs(UnmanagedType.LPUTF8Str)] string ID, global::System.IntPtr context);

    /// <summary>xmlParserOption:</summary>
    /// <remarks>
    /// <para>This is the set of XML parser options that can be passed down</para>
    /// <para>to the xmlReadDoc() and similar calls.</para>
    /// </remarks>
    /// <summary>xmlFeature:</summary>
    /// <remarks>
    /// <para>Used to examine the existance of features that can be enabled</para>
    /// <para>or disabled at compile-time.</para>
    /// <para>They used to be called XML_FEATURE_xxx but this clashed with Expat</para>
    /// </remarks>
    public unsafe partial class XmlParserInput : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 60)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr buf;

            [FieldOffset(4)]
            internal global::System.IntPtr filename;

            [FieldOffset(8)]
            internal global::System.IntPtr directory;

            [FieldOffset(12)]
            internal global::System.IntPtr @base;

            [FieldOffset(16)]
            internal global::System.IntPtr cur;

            [FieldOffset(20)]
            internal global::System.IntPtr end;

            [FieldOffset(24)]
            internal int length;

            [FieldOffset(28)]
            internal int line;

            [FieldOffset(32)]
            internal int col;

            [FieldOffset(36)]
            internal uint consumed;

            [FieldOffset(40)]
            internal global::System.IntPtr free;

            [FieldOffset(44)]
            internal global::System.IntPtr encoding;

            [FieldOffset(48)]
            internal global::System.IntPtr version;

            [FieldOffset(52)]
            internal int standalone;

            [FieldOffset(56)]
            internal int id;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN15_xmlParserInputC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlParserInput> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlParserInput>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlParserInput __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlParserInput(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlParserInput __CreateInstance(global::libxml.XmlParserInput.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlParserInput(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlParserInput.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlParserInput.__Internal));
            *(global::libxml.XmlParserInput.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlParserInput(global::libxml.XmlParserInput.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlParserInput(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlParserInput()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlParserInput.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlParserInput(global::libxml.XmlParserInput _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlParserInput.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlParserInput.__Internal*) __Instance) = *((global::libxml.XmlParserInput.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlParserInput __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public global::libxml.XmlParserInputBuffer Buf
        {
            get
            {
                global::libxml.XmlParserInputBuffer __result0;
                if (((global::libxml.XmlParserInput.__Internal*) __Instance)->buf == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlParserInputBuffer.NativeToManagedMap.ContainsKey(((global::libxml.XmlParserInput.__Internal*) __Instance)->buf))
                    __result0 = (global::libxml.XmlParserInputBuffer) global::libxml.XmlParserInputBuffer.NativeToManagedMap[((global::libxml.XmlParserInput.__Internal*) __Instance)->buf];
                else __result0 = global::libxml.XmlParserInputBuffer.__CreateInstance(((global::libxml.XmlParserInput.__Internal*) __Instance)->buf);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlParserInput.__Internal*)__Instance)->buf = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public string Filename
        {
            get
            {
                if (((global::libxml.XmlParserInput.__Internal*) __Instance)->filename == global::System.IntPtr.Zero)
                    return default(string);
                var __retPtr = (byte*) ((global::libxml.XmlParserInput.__Internal*) __Instance)->filename;
                int __length = 0;
                while (*(__retPtr++) != 0) __length += sizeof(byte);
                return global::System.Text.Encoding.UTF8.GetString((byte*) ((global::libxml.XmlParserInput.__Internal*) __Instance)->filename, __length);
            }

            set
            {
                byte[] __bytes0 = global::System.Text.Encoding.UTF8.GetBytes(value);
                fixed (byte* __bytePtr0 = __bytes0)
                {
                    ((global::libxml.XmlParserInput.__Internal*)__Instance)->filename = (global::System.IntPtr) new global::System.IntPtr(__bytePtr0);
                }
            }
        }

        public string Directory
        {
            get
            {
                if (((global::libxml.XmlParserInput.__Internal*) __Instance)->directory == global::System.IntPtr.Zero)
                    return default(string);
                var __retPtr = (byte*) ((global::libxml.XmlParserInput.__Internal*) __Instance)->directory;
                int __length = 0;
                while (*(__retPtr++) != 0) __length += sizeof(byte);
                return global::System.Text.Encoding.UTF8.GetString((byte*) ((global::libxml.XmlParserInput.__Internal*) __Instance)->directory, __length);
            }

            set
            {
                byte[] __bytes0 = global::System.Text.Encoding.UTF8.GetBytes(value);
                fixed (byte* __bytePtr0 = __bytes0)
                {
                    ((global::libxml.XmlParserInput.__Internal*)__Instance)->directory = (global::System.IntPtr) new global::System.IntPtr(__bytePtr0);
                }
            }
        }

        public byte* Base
        {
            get
            {
                return (byte*) ((global::libxml.XmlParserInput.__Internal*) __Instance)->@base;
            }

            set
            {
                ((global::libxml.XmlParserInput.__Internal*)__Instance)->@base = (global::System.IntPtr) value;
            }
        }

        public byte* Cur
        {
            get
            {
                return (byte*) ((global::libxml.XmlParserInput.__Internal*) __Instance)->cur;
            }

            set
            {
                ((global::libxml.XmlParserInput.__Internal*)__Instance)->cur = (global::System.IntPtr) value;
            }
        }

        public byte* End
        {
            get
            {
                return (byte*) ((global::libxml.XmlParserInput.__Internal*) __Instance)->end;
            }

            set
            {
                ((global::libxml.XmlParserInput.__Internal*)__Instance)->end = (global::System.IntPtr) value;
            }
        }

        public int Length
        {
            get
            {
                return ((global::libxml.XmlParserInput.__Internal*) __Instance)->length;
            }

            set
            {
                ((global::libxml.XmlParserInput.__Internal*)__Instance)->length = value;
            }
        }

        public int Line
        {
            get
            {
                return ((global::libxml.XmlParserInput.__Internal*) __Instance)->line;
            }

            set
            {
                ((global::libxml.XmlParserInput.__Internal*)__Instance)->line = value;
            }
        }

        public int Col
        {
            get
            {
                return ((global::libxml.XmlParserInput.__Internal*) __Instance)->col;
            }

            set
            {
                ((global::libxml.XmlParserInput.__Internal*)__Instance)->col = value;
            }
        }

        public uint Consumed
        {
            get
            {
                return ((global::libxml.XmlParserInput.__Internal*) __Instance)->consumed;
            }

            set
            {
                ((global::libxml.XmlParserInput.__Internal*)__Instance)->consumed = value;
            }
        }

        public global::libxml.XmlParserInputDeallocate Free
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlParserInput.__Internal*) __Instance)->free;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlParserInputDeallocate) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlParserInputDeallocate));
            }

            set
            {
                ((global::libxml.XmlParserInput.__Internal*)__Instance)->free = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public byte* Encoding
        {
            get
            {
                return (byte*) ((global::libxml.XmlParserInput.__Internal*) __Instance)->encoding;
            }

            set
            {
                ((global::libxml.XmlParserInput.__Internal*)__Instance)->encoding = (global::System.IntPtr) value;
            }
        }

        public byte* Version
        {
            get
            {
                return (byte*) ((global::libxml.XmlParserInput.__Internal*) __Instance)->version;
            }

            set
            {
                ((global::libxml.XmlParserInput.__Internal*)__Instance)->version = (global::System.IntPtr) value;
            }
        }

        public int Standalone
        {
            get
            {
                return ((global::libxml.XmlParserInput.__Internal*) __Instance)->standalone;
            }

            set
            {
                ((global::libxml.XmlParserInput.__Internal*)__Instance)->standalone = value;
            }
        }

        public int Id
        {
            get
            {
                return ((global::libxml.XmlParserInput.__Internal*) __Instance)->id;
            }

            set
            {
                ((global::libxml.XmlParserInput.__Internal*)__Instance)->id = value;
            }
        }
    }

    public unsafe partial class XmlParserNodeInfo : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 20)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr node;

            [FieldOffset(4)]
            internal uint begin_pos;

            [FieldOffset(8)]
            internal uint begin_line;

            [FieldOffset(12)]
            internal uint end_pos;

            [FieldOffset(16)]
            internal uint end_line;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN18_xmlParserNodeInfoC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlParserNodeInfo> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlParserNodeInfo>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlParserNodeInfo __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlParserNodeInfo(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlParserNodeInfo __CreateInstance(global::libxml.XmlParserNodeInfo.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlParserNodeInfo(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlParserNodeInfo.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlParserNodeInfo.__Internal));
            *(global::libxml.XmlParserNodeInfo.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlParserNodeInfo(global::libxml.XmlParserNodeInfo.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlParserNodeInfo(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlParserNodeInfo()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlParserNodeInfo.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlParserNodeInfo(global::libxml.XmlParserNodeInfo _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlParserNodeInfo.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlParserNodeInfo.__Internal*) __Instance) = *((global::libxml.XmlParserNodeInfo.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlParserNodeInfo __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public global::libxml.XmlNode Node
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlParserNodeInfo.__Internal*) __Instance)->node == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlParserNodeInfo.__Internal*) __Instance)->node))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlParserNodeInfo.__Internal*) __Instance)->node];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlParserNodeInfo.__Internal*) __Instance)->node);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlParserNodeInfo.__Internal*)__Instance)->node = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public uint BeginPos
        {
            get
            {
                return ((global::libxml.XmlParserNodeInfo.__Internal*) __Instance)->begin_pos;
            }

            set
            {
                ((global::libxml.XmlParserNodeInfo.__Internal*)__Instance)->begin_pos = value;
            }
        }

        public uint BeginLine
        {
            get
            {
                return ((global::libxml.XmlParserNodeInfo.__Internal*) __Instance)->begin_line;
            }

            set
            {
                ((global::libxml.XmlParserNodeInfo.__Internal*)__Instance)->begin_line = value;
            }
        }

        public uint EndPos
        {
            get
            {
                return ((global::libxml.XmlParserNodeInfo.__Internal*) __Instance)->end_pos;
            }

            set
            {
                ((global::libxml.XmlParserNodeInfo.__Internal*)__Instance)->end_pos = value;
            }
        }

        public uint EndLine
        {
            get
            {
                return ((global::libxml.XmlParserNodeInfo.__Internal*) __Instance)->end_line;
            }

            set
            {
                ((global::libxml.XmlParserNodeInfo.__Internal*)__Instance)->end_line = value;
            }
        }
    }

    public unsafe partial class XmlParserNodeInfoSeq : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 12)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal uint maximum;

            [FieldOffset(4)]
            internal uint length;

            [FieldOffset(8)]
            internal global::System.IntPtr buffer;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN21_xmlParserNodeInfoSeqC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlParserNodeInfoSeq> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlParserNodeInfoSeq>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlParserNodeInfoSeq __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlParserNodeInfoSeq(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlParserNodeInfoSeq __CreateInstance(global::libxml.XmlParserNodeInfoSeq.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlParserNodeInfoSeq(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlParserNodeInfoSeq.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlParserNodeInfoSeq.__Internal));
            *(global::libxml.XmlParserNodeInfoSeq.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlParserNodeInfoSeq(global::libxml.XmlParserNodeInfoSeq.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlParserNodeInfoSeq(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlParserNodeInfoSeq()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlParserNodeInfoSeq.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlParserNodeInfoSeq(global::libxml.XmlParserNodeInfoSeq _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlParserNodeInfoSeq.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlParserNodeInfoSeq.__Internal*) __Instance) = *((global::libxml.XmlParserNodeInfoSeq.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlParserNodeInfoSeq __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public uint Maximum
        {
            get
            {
                return ((global::libxml.XmlParserNodeInfoSeq.__Internal*) __Instance)->maximum;
            }

            set
            {
                ((global::libxml.XmlParserNodeInfoSeq.__Internal*)__Instance)->maximum = value;
            }
        }

        public uint Length
        {
            get
            {
                return ((global::libxml.XmlParserNodeInfoSeq.__Internal*) __Instance)->length;
            }

            set
            {
                ((global::libxml.XmlParserNodeInfoSeq.__Internal*)__Instance)->length = value;
            }
        }

        public global::libxml.XmlParserNodeInfo Buffer
        {
            get
            {
                global::libxml.XmlParserNodeInfo __result0;
                if (((global::libxml.XmlParserNodeInfoSeq.__Internal*) __Instance)->buffer == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlParserNodeInfo.NativeToManagedMap.ContainsKey(((global::libxml.XmlParserNodeInfoSeq.__Internal*) __Instance)->buffer))
                    __result0 = (global::libxml.XmlParserNodeInfo) global::libxml.XmlParserNodeInfo.NativeToManagedMap[((global::libxml.XmlParserNodeInfoSeq.__Internal*) __Instance)->buffer];
                else __result0 = global::libxml.XmlParserNodeInfo.__CreateInstance(((global::libxml.XmlParserNodeInfoSeq.__Internal*) __Instance)->buffer);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlParserNodeInfoSeq.__Internal*)__Instance)->buffer = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }
    }

    /// <summary>xmlParserCtxt:</summary>
    /// <remarks>
    /// <para>The parser context.</para>
    /// <para>NOTE This doesn't completely define the parser state, the (current ?)</para>
    /// <para>design of the parser uses recursive function calls since this allow</para>
    /// <para>and easy mapping from the production rules of the specification</para>
    /// <para>to the actual code. The drawback is that the actual function call</para>
    /// <para>also reflect the parser state. However most of the parsing routines</para>
    /// <para>takes as the only argument the parser context pointer, so migrating</para>
    /// <para>to a state based parser for progressive parsing shouldn't be too hard.</para>
    /// </remarks>
    public unsafe partial class XmlParserCtxt : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 472)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr sax;

            [FieldOffset(4)]
            internal global::System.IntPtr userData;

            [FieldOffset(8)]
            internal global::System.IntPtr myDoc;

            [FieldOffset(12)]
            internal int wellFormed;

            [FieldOffset(16)]
            internal int replaceEntities;

            [FieldOffset(20)]
            internal global::System.IntPtr version;

            [FieldOffset(24)]
            internal global::System.IntPtr encoding;

            [FieldOffset(28)]
            internal int standalone;

            [FieldOffset(32)]
            internal int html;

            [FieldOffset(36)]
            internal global::System.IntPtr input;

            [FieldOffset(40)]
            internal int inputNr;

            [FieldOffset(44)]
            internal int inputMax;

            [FieldOffset(48)]
            internal global::System.IntPtr inputTab;

            [FieldOffset(52)]
            internal global::System.IntPtr node;

            [FieldOffset(56)]
            internal int nodeNr;

            [FieldOffset(60)]
            internal int nodeMax;

            [FieldOffset(64)]
            internal global::System.IntPtr nodeTab;

            [FieldOffset(68)]
            internal int record_info;

            [FieldOffset(72)]
            internal global::libxml.XmlParserNodeInfoSeq.__Internal node_seq;

            [FieldOffset(84)]
            internal int errNo;

            [FieldOffset(88)]
            internal int hasExternalSubset;

            [FieldOffset(92)]
            internal int hasPErefs;

            [FieldOffset(96)]
            internal int external;

            [FieldOffset(100)]
            internal int valid;

            [FieldOffset(104)]
            internal int validate;

            [FieldOffset(108)]
            internal global::libxml.XmlValidCtxt.__Internal vctxt;

            [FieldOffset(172)]
            internal global::libxml.XmlParserInputState instate;

            [FieldOffset(176)]
            internal int token;

            [FieldOffset(180)]
            internal global::System.IntPtr directory;

            [FieldOffset(184)]
            internal global::System.IntPtr name;

            [FieldOffset(188)]
            internal int nameNr;

            [FieldOffset(192)]
            internal int nameMax;

            [FieldOffset(196)]
            internal global::System.IntPtr nameTab;

            [FieldOffset(200)]
            internal int nbChars;

            [FieldOffset(204)]
            internal int checkIndex;

            [FieldOffset(208)]
            internal int keepBlanks;

            [FieldOffset(212)]
            internal int disableSAX;

            [FieldOffset(216)]
            internal int inSubset;

            [FieldOffset(220)]
            internal global::System.IntPtr intSubName;

            [FieldOffset(224)]
            internal global::System.IntPtr extSubURI;

            [FieldOffset(228)]
            internal global::System.IntPtr extSubSystem;

            [FieldOffset(232)]
            internal global::System.IntPtr space;

            [FieldOffset(236)]
            internal int spaceNr;

            [FieldOffset(240)]
            internal int spaceMax;

            [FieldOffset(244)]
            internal global::System.IntPtr spaceTab;

            [FieldOffset(248)]
            internal int depth;

            [FieldOffset(252)]
            internal global::System.IntPtr entity;

            [FieldOffset(256)]
            internal int charset;

            [FieldOffset(260)]
            internal int nodelen;

            [FieldOffset(264)]
            internal int nodemem;

            [FieldOffset(268)]
            internal int pedantic;

            [FieldOffset(272)]
            internal global::System.IntPtr _private;

            [FieldOffset(276)]
            internal int loadsubset;

            [FieldOffset(280)]
            internal int linenumbers;

            [FieldOffset(284)]
            internal global::System.IntPtr catalogs;

            [FieldOffset(288)]
            internal int recovery;

            [FieldOffset(292)]
            internal int progressive;

            [FieldOffset(296)]
            internal global::System.IntPtr dict;

            [FieldOffset(300)]
            internal global::System.IntPtr atts;

            [FieldOffset(304)]
            internal int maxatts;

            [FieldOffset(308)]
            internal int docdict;

            [FieldOffset(312)]
            internal global::System.IntPtr str_xml;

            [FieldOffset(316)]
            internal global::System.IntPtr str_xmlns;

            [FieldOffset(320)]
            internal global::System.IntPtr str_xml_ns;

            [FieldOffset(324)]
            internal int sax2;

            [FieldOffset(328)]
            internal int nsNr;

            [FieldOffset(332)]
            internal int nsMax;

            [FieldOffset(336)]
            internal global::System.IntPtr nsTab;

            [FieldOffset(340)]
            internal global::System.IntPtr attallocs;

            [FieldOffset(344)]
            internal global::System.IntPtr pushTab;

            [FieldOffset(348)]
            internal global::System.IntPtr attsDefault;

            [FieldOffset(352)]
            internal global::System.IntPtr attsSpecial;

            [FieldOffset(356)]
            internal int nsWellFormed;

            [FieldOffset(360)]
            internal int options;

            [FieldOffset(364)]
            internal int dictNames;

            [FieldOffset(368)]
            internal int freeElemsNr;

            [FieldOffset(372)]
            internal global::System.IntPtr freeElems;

            [FieldOffset(376)]
            internal int freeAttrsNr;

            [FieldOffset(380)]
            internal global::System.IntPtr freeAttrs;

            [FieldOffset(384)]
            internal global::libxml.XmlError.__Internal lastError;

            [FieldOffset(436)]
            internal global::libxml.XmlParserMode parseMode;

            [FieldOffset(440)]
            internal uint nbentities;

            [FieldOffset(444)]
            internal uint sizeentities;

            [FieldOffset(448)]
            internal global::System.IntPtr nodeInfo;

            [FieldOffset(452)]
            internal int nodeInfoNr;

            [FieldOffset(456)]
            internal int nodeInfoMax;

            [FieldOffset(460)]
            internal global::System.IntPtr nodeInfoTab;

            [FieldOffset(464)]
            internal int input_id;

            [FieldOffset(468)]
            internal uint sizeentcopy;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN14_xmlParserCtxtC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlParserCtxt> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlParserCtxt>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlParserCtxt __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlParserCtxt(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlParserCtxt __CreateInstance(global::libxml.XmlParserCtxt.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlParserCtxt(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlParserCtxt.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlParserCtxt.__Internal));
            *(global::libxml.XmlParserCtxt.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlParserCtxt(global::libxml.XmlParserCtxt.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlParserCtxt(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlParserCtxt()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlParserCtxt.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlParserCtxt(global::libxml.XmlParserCtxt _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlParserCtxt.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlParserCtxt.__Internal*) __Instance) = *((global::libxml.XmlParserCtxt.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlParserCtxt __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public global::libxml.XmlSAXHandler Sax
        {
            get
            {
                global::libxml.XmlSAXHandler __result0;
                if (((global::libxml.XmlParserCtxt.__Internal*) __Instance)->sax == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlSAXHandler.NativeToManagedMap.ContainsKey(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->sax))
                    __result0 = (global::libxml.XmlSAXHandler) global::libxml.XmlSAXHandler.NativeToManagedMap[((global::libxml.XmlParserCtxt.__Internal*) __Instance)->sax];
                else __result0 = global::libxml.XmlSAXHandler.__CreateInstance(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->sax);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->sax = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::System.IntPtr UserData
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->userData;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->userData = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlDoc MyDoc
        {
            get
            {
                global::libxml.XmlDoc __result0;
                if (((global::libxml.XmlParserCtxt.__Internal*) __Instance)->myDoc == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->myDoc))
                    __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[((global::libxml.XmlParserCtxt.__Internal*) __Instance)->myDoc];
                else __result0 = global::libxml.XmlDoc.__CreateInstance(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->myDoc);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->myDoc = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public int WellFormed
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->wellFormed;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->wellFormed = value;
            }
        }

        public int ReplaceEntities
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->replaceEntities;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->replaceEntities = value;
            }
        }

        public byte* Version
        {
            get
            {
                return (byte*) ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->version;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->version = (global::System.IntPtr) value;
            }
        }

        public byte* Encoding
        {
            get
            {
                return (byte*) ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->encoding;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->encoding = (global::System.IntPtr) value;
            }
        }

        public int Standalone
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->standalone;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->standalone = value;
            }
        }

        public int Html
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->html;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->html = value;
            }
        }

        public global::libxml.XmlParserInput Input
        {
            get
            {
                global::libxml.XmlParserInput __result0;
                if (((global::libxml.XmlParserCtxt.__Internal*) __Instance)->input == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlParserInput.NativeToManagedMap.ContainsKey(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->input))
                    __result0 = (global::libxml.XmlParserInput) global::libxml.XmlParserInput.NativeToManagedMap[((global::libxml.XmlParserCtxt.__Internal*) __Instance)->input];
                else __result0 = global::libxml.XmlParserInput.__CreateInstance(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->input);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->input = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public int InputNr
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->inputNr;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->inputNr = value;
            }
        }

        public int InputMax
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->inputMax;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->inputMax = value;
            }
        }

        public global::libxml.XmlParserInput InputTab
        {
            get
            {
                global::libxml.XmlParserInput __result0;
                if (((global::libxml.XmlParserCtxt.__Internal*) __Instance)->inputTab == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlParserInput.NativeToManagedMap.ContainsKey(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->inputTab))
                    __result0 = (global::libxml.XmlParserInput) global::libxml.XmlParserInput.NativeToManagedMap[((global::libxml.XmlParserCtxt.__Internal*) __Instance)->inputTab];
                else __result0 = global::libxml.XmlParserInput.__CreateInstance(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->inputTab);
                return __result0;
            }

            set
            {
                var __value = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->inputTab = new global::System.IntPtr(&__value);
            }
        }

        public global::libxml.XmlNode Node
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlParserCtxt.__Internal*) __Instance)->node == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->node))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlParserCtxt.__Internal*) __Instance)->node];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->node);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->node = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public int NodeNr
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nodeNr;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->nodeNr = value;
            }
        }

        public int NodeMax
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nodeMax;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->nodeMax = value;
            }
        }

        public global::libxml.XmlNode NodeTab
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nodeTab == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nodeTab))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nodeTab];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nodeTab);
                return __result0;
            }

            set
            {
                var __value = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->nodeTab = new global::System.IntPtr(&__value);
            }
        }

        public int RecordInfo
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->record_info;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->record_info = value;
            }
        }

        public global::libxml.XmlParserNodeInfoSeq NodeSeq
        {
            get
            {
                return global::libxml.XmlParserNodeInfoSeq.__CreateInstance(new global::System.IntPtr(&((global::libxml.XmlParserCtxt.__Internal*) __Instance)->node_seq));
            }

            set
            {
                if (ReferenceEquals(value, null))
                    throw new global::System.ArgumentNullException("value", "Cannot be null because it is passed by value.");
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->node_seq = *(global::libxml.XmlParserNodeInfoSeq.__Internal*) value.__Instance;
            }
        }

        public int ErrNo
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->errNo;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->errNo = value;
            }
        }

        public int HasExternalSubset
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->hasExternalSubset;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->hasExternalSubset = value;
            }
        }

        public int HasPErefs
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->hasPErefs;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->hasPErefs = value;
            }
        }

        public int External
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->external;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->external = value;
            }
        }

        public int Valid
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->valid;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->valid = value;
            }
        }

        public int Validate
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->validate;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->validate = value;
            }
        }

        public global::libxml.XmlValidCtxt Vctxt
        {
            get
            {
                return global::libxml.XmlValidCtxt.__CreateInstance(new global::System.IntPtr(&((global::libxml.XmlParserCtxt.__Internal*) __Instance)->vctxt));
            }

            set
            {
                if (ReferenceEquals(value, null))
                    throw new global::System.ArgumentNullException("value", "Cannot be null because it is passed by value.");
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->vctxt = *(global::libxml.XmlValidCtxt.__Internal*) value.__Instance;
            }
        }

        public global::libxml.XmlParserInputState Instate
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->instate;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->instate = value;
            }
        }

        public int Token
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->token;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->token = value;
            }
        }

        public sbyte* Directory
        {
            get
            {
                return (sbyte*) ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->directory;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->directory = (global::System.IntPtr) value;
            }
        }

        public byte* Name
        {
            get
            {
                return (byte*) ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->name;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->name = (global::System.IntPtr) value;
            }
        }

        public int NameNr
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nameNr;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->nameNr = value;
            }
        }

        public int NameMax
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nameMax;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->nameMax = value;
            }
        }

        public byte** NameTab
        {
            get
            {
                return (byte**) ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nameTab;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->nameTab = (global::System.IntPtr) value;
            }
        }

        public int NbChars
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nbChars;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->nbChars = value;
            }
        }

        public int CheckIndex
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->checkIndex;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->checkIndex = value;
            }
        }

        public int KeepBlanks
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->keepBlanks;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->keepBlanks = value;
            }
        }

        public int DisableSAX
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->disableSAX;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->disableSAX = value;
            }
        }

        public int InSubset
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->inSubset;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->inSubset = value;
            }
        }

        public byte* IntSubName
        {
            get
            {
                return (byte*) ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->intSubName;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->intSubName = (global::System.IntPtr) value;
            }
        }

        public byte* ExtSubURI
        {
            get
            {
                return (byte*) ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->extSubURI;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->extSubURI = (global::System.IntPtr) value;
            }
        }

        public byte* ExtSubSystem
        {
            get
            {
                return (byte*) ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->extSubSystem;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->extSubSystem = (global::System.IntPtr) value;
            }
        }

        public int* Space
        {
            get
            {
                return (int*) ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->space;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->space = (global::System.IntPtr) value;
            }
        }

        public int SpaceNr
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->spaceNr;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->spaceNr = value;
            }
        }

        public int SpaceMax
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->spaceMax;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->spaceMax = value;
            }
        }

        public int* SpaceTab
        {
            get
            {
                return (int*) ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->spaceTab;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->spaceTab = (global::System.IntPtr) value;
            }
        }

        public int Depth
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->depth;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->depth = value;
            }
        }

        public global::libxml.XmlParserInput Entity
        {
            get
            {
                global::libxml.XmlParserInput __result0;
                if (((global::libxml.XmlParserCtxt.__Internal*) __Instance)->entity == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlParserInput.NativeToManagedMap.ContainsKey(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->entity))
                    __result0 = (global::libxml.XmlParserInput) global::libxml.XmlParserInput.NativeToManagedMap[((global::libxml.XmlParserCtxt.__Internal*) __Instance)->entity];
                else __result0 = global::libxml.XmlParserInput.__CreateInstance(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->entity);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->entity = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public int Charset
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->charset;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->charset = value;
            }
        }

        public int Nodelen
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nodelen;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->nodelen = value;
            }
        }

        public int Nodemem
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nodemem;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->nodemem = value;
            }
        }

        public int Pedantic
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->pedantic;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->pedantic = value;
            }
        }

        public global::System.IntPtr Private
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->_private;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->_private = (global::System.IntPtr) value;
            }
        }

        public int Loadsubset
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->loadsubset;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->loadsubset = value;
            }
        }

        public int Linenumbers
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->linenumbers;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->linenumbers = value;
            }
        }

        public global::System.IntPtr Catalogs
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->catalogs;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->catalogs = (global::System.IntPtr) value;
            }
        }

        public int Recovery
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->recovery;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->recovery = value;
            }
        }

        public int Progressive
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->progressive;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->progressive = value;
            }
        }

        public global::libxml.XmlDict Dict
        {
            get
            {
                global::libxml.XmlDict __result0;
                if (((global::libxml.XmlParserCtxt.__Internal*) __Instance)->dict == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlDict.NativeToManagedMap.ContainsKey(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->dict))
                    __result0 = (global::libxml.XmlDict) global::libxml.XmlDict.NativeToManagedMap[((global::libxml.XmlParserCtxt.__Internal*) __Instance)->dict];
                else __result0 = global::libxml.XmlDict.__CreateInstance(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->dict);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->dict = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public byte** Atts
        {
            get
            {
                return (byte**) ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->atts;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->atts = (global::System.IntPtr) value;
            }
        }

        public int Maxatts
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->maxatts;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->maxatts = value;
            }
        }

        public int Docdict
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->docdict;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->docdict = value;
            }
        }

        public byte* StrXml
        {
            get
            {
                return (byte*) ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->str_xml;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->str_xml = (global::System.IntPtr) value;
            }
        }

        public byte* StrXmlns
        {
            get
            {
                return (byte*) ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->str_xmlns;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->str_xmlns = (global::System.IntPtr) value;
            }
        }

        public byte* StrXmlNs
        {
            get
            {
                return (byte*) ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->str_xml_ns;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->str_xml_ns = (global::System.IntPtr) value;
            }
        }

        public int Sax2
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->sax2;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->sax2 = value;
            }
        }

        public int NsNr
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nsNr;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->nsNr = value;
            }
        }

        public int NsMax
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nsMax;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->nsMax = value;
            }
        }

        public byte** NsTab
        {
            get
            {
                return (byte**) ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nsTab;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->nsTab = (global::System.IntPtr) value;
            }
        }

        public int* Attallocs
        {
            get
            {
                return (int*) ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->attallocs;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->attallocs = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlHashTable AttsDefault
        {
            get
            {
                global::libxml.XmlHashTable __result0;
                if (((global::libxml.XmlParserCtxt.__Internal*) __Instance)->attsDefault == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlHashTable.NativeToManagedMap.ContainsKey(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->attsDefault))
                    __result0 = (global::libxml.XmlHashTable) global::libxml.XmlHashTable.NativeToManagedMap[((global::libxml.XmlParserCtxt.__Internal*) __Instance)->attsDefault];
                else __result0 = global::libxml.XmlHashTable.__CreateInstance(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->attsDefault);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->attsDefault = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlHashTable AttsSpecial
        {
            get
            {
                global::libxml.XmlHashTable __result0;
                if (((global::libxml.XmlParserCtxt.__Internal*) __Instance)->attsSpecial == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlHashTable.NativeToManagedMap.ContainsKey(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->attsSpecial))
                    __result0 = (global::libxml.XmlHashTable) global::libxml.XmlHashTable.NativeToManagedMap[((global::libxml.XmlParserCtxt.__Internal*) __Instance)->attsSpecial];
                else __result0 = global::libxml.XmlHashTable.__CreateInstance(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->attsSpecial);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->attsSpecial = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public int NsWellFormed
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nsWellFormed;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->nsWellFormed = value;
            }
        }

        public int Options
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->options;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->options = value;
            }
        }

        public int DictNames
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->dictNames;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->dictNames = value;
            }
        }

        public int FreeElemsNr
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->freeElemsNr;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->freeElemsNr = value;
            }
        }

        public global::libxml.XmlNode FreeElems
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlParserCtxt.__Internal*) __Instance)->freeElems == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->freeElems))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlParserCtxt.__Internal*) __Instance)->freeElems];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->freeElems);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->freeElems = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public int FreeAttrsNr
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->freeAttrsNr;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->freeAttrsNr = value;
            }
        }

        public global::libxml.XmlAttr FreeAttrs
        {
            get
            {
                global::libxml.XmlAttr __result0;
                if (((global::libxml.XmlParserCtxt.__Internal*) __Instance)->freeAttrs == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlAttr.NativeToManagedMap.ContainsKey(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->freeAttrs))
                    __result0 = (global::libxml.XmlAttr) global::libxml.XmlAttr.NativeToManagedMap[((global::libxml.XmlParserCtxt.__Internal*) __Instance)->freeAttrs];
                else __result0 = global::libxml.XmlAttr.__CreateInstance(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->freeAttrs);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->freeAttrs = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlError LastError
        {
            get
            {
                return global::libxml.XmlError.__CreateInstance(new global::System.IntPtr(&((global::libxml.XmlParserCtxt.__Internal*) __Instance)->lastError));
            }

            set
            {
                if (ReferenceEquals(value, null))
                    throw new global::System.ArgumentNullException("value", "Cannot be null because it is passed by value.");
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->lastError = *(global::libxml.XmlError.__Internal*) value.__Instance;
            }
        }

        public global::libxml.XmlParserMode ParseMode
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->parseMode;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->parseMode = value;
            }
        }

        public uint Nbentities
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nbentities;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->nbentities = value;
            }
        }

        public uint Sizeentities
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->sizeentities;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->sizeentities = value;
            }
        }

        public global::libxml.XmlParserNodeInfo NodeInfo
        {
            get
            {
                global::libxml.XmlParserNodeInfo __result0;
                if (((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nodeInfo == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlParserNodeInfo.NativeToManagedMap.ContainsKey(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nodeInfo))
                    __result0 = (global::libxml.XmlParserNodeInfo) global::libxml.XmlParserNodeInfo.NativeToManagedMap[((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nodeInfo];
                else __result0 = global::libxml.XmlParserNodeInfo.__CreateInstance(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nodeInfo);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->nodeInfo = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public int NodeInfoNr
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nodeInfoNr;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->nodeInfoNr = value;
            }
        }

        public int NodeInfoMax
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nodeInfoMax;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->nodeInfoMax = value;
            }
        }

        public global::libxml.XmlParserNodeInfo NodeInfoTab
        {
            get
            {
                global::libxml.XmlParserNodeInfo __result0;
                if (((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nodeInfoTab == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlParserNodeInfo.NativeToManagedMap.ContainsKey(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nodeInfoTab))
                    __result0 = (global::libxml.XmlParserNodeInfo) global::libxml.XmlParserNodeInfo.NativeToManagedMap[((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nodeInfoTab];
                else __result0 = global::libxml.XmlParserNodeInfo.__CreateInstance(((global::libxml.XmlParserCtxt.__Internal*) __Instance)->nodeInfoTab);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->nodeInfoTab = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public int InputId
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->input_id;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->input_id = value;
            }
        }

        public uint Sizeentcopy
        {
            get
            {
                return ((global::libxml.XmlParserCtxt.__Internal*) __Instance)->sizeentcopy;
            }

            set
            {
                ((global::libxml.XmlParserCtxt.__Internal*)__Instance)->sizeentcopy = value;
            }
        }
    }

    /// <summary>xmlSAXLocator:</summary>
    /// <remarks>A SAX Locator.</remarks>
    public unsafe partial class XmlSAXLocator : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr getPublicId;

            [FieldOffset(4)]
            internal global::System.IntPtr getSystemId;

            [FieldOffset(8)]
            internal global::System.IntPtr getLineNumber;

            [FieldOffset(12)]
            internal global::System.IntPtr getColumnNumber;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN14_xmlSAXLocatorC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlSAXLocator> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlSAXLocator>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlSAXLocator __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlSAXLocator(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlSAXLocator __CreateInstance(global::libxml.XmlSAXLocator.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlSAXLocator(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlSAXLocator.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlSAXLocator.__Internal));
            *(global::libxml.XmlSAXLocator.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlSAXLocator(global::libxml.XmlSAXLocator.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlSAXLocator(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlSAXLocator()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlSAXLocator.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlSAXLocator(global::libxml.XmlSAXLocator _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlSAXLocator.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlSAXLocator.__Internal*) __Instance) = *((global::libxml.XmlSAXLocator.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlSAXLocator __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public global::libxml.Delegates.Func_bytePtr_IntPtr GetPublicId
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXLocator.__Internal*) __Instance)->getPublicId;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.Delegates.Func_bytePtr_IntPtr) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.Delegates.Func_bytePtr_IntPtr));
            }

            set
            {
                ((global::libxml.XmlSAXLocator.__Internal*)__Instance)->getPublicId = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.Delegates.Func_bytePtr_IntPtr GetSystemId
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXLocator.__Internal*) __Instance)->getSystemId;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.Delegates.Func_bytePtr_IntPtr) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.Delegates.Func_bytePtr_IntPtr));
            }

            set
            {
                ((global::libxml.XmlSAXLocator.__Internal*)__Instance)->getSystemId = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.Delegates.Func_int_IntPtr GetLineNumber
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXLocator.__Internal*) __Instance)->getLineNumber;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.Delegates.Func_int_IntPtr) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.Delegates.Func_int_IntPtr));
            }

            set
            {
                ((global::libxml.XmlSAXLocator.__Internal*)__Instance)->getLineNumber = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.Delegates.Func_int_IntPtr GetColumnNumber
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXLocator.__Internal*) __Instance)->getColumnNumber;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.Delegates.Func_int_IntPtr) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.Delegates.Func_int_IntPtr));
            }

            set
            {
                ((global::libxml.XmlSAXLocator.__Internal*)__Instance)->getColumnNumber = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }
    }

    public unsafe partial class XmlSAXHandler : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 128)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr internalSubset;

            [FieldOffset(4)]
            internal global::System.IntPtr isStandalone;

            [FieldOffset(8)]
            internal global::System.IntPtr hasInternalSubset;

            [FieldOffset(12)]
            internal global::System.IntPtr hasExternalSubset;

            [FieldOffset(16)]
            internal global::System.IntPtr resolveEntity;

            [FieldOffset(20)]
            internal global::System.IntPtr getEntity;

            [FieldOffset(24)]
            internal global::System.IntPtr entityDecl;

            [FieldOffset(28)]
            internal global::System.IntPtr notationDecl;

            [FieldOffset(32)]
            internal global::System.IntPtr attributeDecl;

            [FieldOffset(36)]
            internal global::System.IntPtr elementDecl;

            [FieldOffset(40)]
            internal global::System.IntPtr unparsedEntityDecl;

            [FieldOffset(44)]
            internal global::System.IntPtr setDocumentLocator;

            [FieldOffset(48)]
            internal global::System.IntPtr startDocument;

            [FieldOffset(52)]
            internal global::System.IntPtr endDocument;

            [FieldOffset(56)]
            internal global::System.IntPtr startElement;

            [FieldOffset(60)]
            internal global::System.IntPtr endElement;

            [FieldOffset(64)]
            internal global::System.IntPtr reference;

            [FieldOffset(68)]
            internal global::System.IntPtr characters;

            [FieldOffset(72)]
            internal global::System.IntPtr ignorableWhitespace;

            [FieldOffset(76)]
            internal global::System.IntPtr processingInstruction;

            [FieldOffset(80)]
            internal global::System.IntPtr comment;

            [FieldOffset(84)]
            internal global::System.IntPtr warning;

            [FieldOffset(88)]
            internal global::System.IntPtr error;

            [FieldOffset(92)]
            internal global::System.IntPtr fatalError;

            [FieldOffset(96)]
            internal global::System.IntPtr getParameterEntity;

            [FieldOffset(100)]
            internal global::System.IntPtr cdataBlock;

            [FieldOffset(104)]
            internal global::System.IntPtr externalSubset;

            [FieldOffset(108)]
            internal uint initialized;

            [FieldOffset(112)]
            internal global::System.IntPtr _private;

            [FieldOffset(116)]
            internal global::System.IntPtr startElementNs;

            [FieldOffset(120)]
            internal global::System.IntPtr endElementNs;

            [FieldOffset(124)]
            internal global::System.IntPtr serror;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN14_xmlSAXHandlerC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlSAXHandler> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlSAXHandler>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlSAXHandler __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlSAXHandler(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlSAXHandler __CreateInstance(global::libxml.XmlSAXHandler.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlSAXHandler(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlSAXHandler.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlSAXHandler.__Internal));
            *(global::libxml.XmlSAXHandler.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlSAXHandler(global::libxml.XmlSAXHandler.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlSAXHandler(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlSAXHandler()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlSAXHandler.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlSAXHandler(global::libxml.XmlSAXHandler _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlSAXHandler.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlSAXHandler.__Internal*) __Instance) = *((global::libxml.XmlSAXHandler.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlSAXHandler __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public global::libxml.InternalSubsetSAXFunc InternalSubset
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->internalSubset;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.InternalSubsetSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.InternalSubsetSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->internalSubset = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.IsStandaloneSAXFunc IsStandalone
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->isStandalone;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.IsStandaloneSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.IsStandaloneSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->isStandalone = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.HasInternalSubsetSAXFunc HasInternalSubset
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->hasInternalSubset;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.HasInternalSubsetSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.HasInternalSubsetSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->hasInternalSubset = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.HasExternalSubsetSAXFunc HasExternalSubset
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->hasExternalSubset;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.HasExternalSubsetSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.HasExternalSubsetSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->hasExternalSubset = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.ResolveEntitySAXFunc ResolveEntity
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->resolveEntity;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.ResolveEntitySAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.ResolveEntitySAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->resolveEntity = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.GetEntitySAXFunc GetEntity
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->getEntity;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.GetEntitySAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.GetEntitySAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->getEntity = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.EntityDeclSAXFunc EntityDecl
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->entityDecl;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.EntityDeclSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.EntityDeclSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->entityDecl = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.NotationDeclSAXFunc NotationDecl
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->notationDecl;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.NotationDeclSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.NotationDeclSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->notationDecl = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.AttributeDeclSAXFunc AttributeDecl
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->attributeDecl;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.AttributeDeclSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.AttributeDeclSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->attributeDecl = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.ElementDeclSAXFunc ElementDecl
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->elementDecl;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.ElementDeclSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.ElementDeclSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->elementDecl = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.UnparsedEntityDeclSAXFunc UnparsedEntityDecl
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->unparsedEntityDecl;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.UnparsedEntityDeclSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.UnparsedEntityDeclSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->unparsedEntityDecl = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.SetDocumentLocatorSAXFunc SetDocumentLocator
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->setDocumentLocator;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.SetDocumentLocatorSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.SetDocumentLocatorSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->setDocumentLocator = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.StartDocumentSAXFunc StartDocument
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->startDocument;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.StartDocumentSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.StartDocumentSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->startDocument = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.EndDocumentSAXFunc EndDocument
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->endDocument;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.EndDocumentSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.EndDocumentSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->endDocument = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.StartElementSAXFunc StartElement
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->startElement;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.StartElementSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.StartElementSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->startElement = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.EndElementSAXFunc EndElement
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->endElement;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.EndElementSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.EndElementSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->endElement = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.ReferenceSAXFunc Reference
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->reference;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.ReferenceSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.ReferenceSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->reference = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.CharactersSAXFunc Characters
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->characters;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.CharactersSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.CharactersSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->characters = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.IgnorableWhitespaceSAXFunc IgnorableWhitespace
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->ignorableWhitespace;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.IgnorableWhitespaceSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.IgnorableWhitespaceSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->ignorableWhitespace = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.ProcessingInstructionSAXFunc ProcessingInstruction
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->processingInstruction;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.ProcessingInstructionSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.ProcessingInstructionSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->processingInstruction = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.CommentSAXFunc Comment
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->comment;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.CommentSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.CommentSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->comment = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.WarningSAXFunc Warning
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->warning;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.WarningSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.WarningSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->warning = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.ErrorSAXFunc Error
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->error;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.ErrorSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.ErrorSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->error = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.FatalErrorSAXFunc FatalError
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->fatalError;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.FatalErrorSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.FatalErrorSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->fatalError = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.GetParameterEntitySAXFunc GetParameterEntity
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->getParameterEntity;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.GetParameterEntitySAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.GetParameterEntitySAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->getParameterEntity = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.CdataBlockSAXFunc CdataBlock
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->cdataBlock;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.CdataBlockSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.CdataBlockSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->cdataBlock = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.ExternalSubsetSAXFunc ExternalSubset
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->externalSubset;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.ExternalSubsetSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.ExternalSubsetSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->externalSubset = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public uint Initialized
        {
            get
            {
                return ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->initialized;
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->initialized = value;
            }
        }

        public global::System.IntPtr Private
        {
            get
            {
                return ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->_private;
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->_private = (global::System.IntPtr) value;
            }
        }

        public global::libxml.StartElementNsSAX2Func StartElementNs
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->startElementNs;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.StartElementNsSAX2Func) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.StartElementNsSAX2Func));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->startElementNs = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.EndElementNsSAX2Func EndElementNs
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->endElementNs;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.EndElementNsSAX2Func) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.EndElementNsSAX2Func));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->endElementNs = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.XmlStructuredErrorFunc Serror
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandler.__Internal*) __Instance)->serror;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlStructuredErrorFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlStructuredErrorFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandler.__Internal*)__Instance)->serror = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }
    }

    public unsafe partial class XmlSAXHandlerV1 : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 112)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr internalSubset;

            [FieldOffset(4)]
            internal global::System.IntPtr isStandalone;

            [FieldOffset(8)]
            internal global::System.IntPtr hasInternalSubset;

            [FieldOffset(12)]
            internal global::System.IntPtr hasExternalSubset;

            [FieldOffset(16)]
            internal global::System.IntPtr resolveEntity;

            [FieldOffset(20)]
            internal global::System.IntPtr getEntity;

            [FieldOffset(24)]
            internal global::System.IntPtr entityDecl;

            [FieldOffset(28)]
            internal global::System.IntPtr notationDecl;

            [FieldOffset(32)]
            internal global::System.IntPtr attributeDecl;

            [FieldOffset(36)]
            internal global::System.IntPtr elementDecl;

            [FieldOffset(40)]
            internal global::System.IntPtr unparsedEntityDecl;

            [FieldOffset(44)]
            internal global::System.IntPtr setDocumentLocator;

            [FieldOffset(48)]
            internal global::System.IntPtr startDocument;

            [FieldOffset(52)]
            internal global::System.IntPtr endDocument;

            [FieldOffset(56)]
            internal global::System.IntPtr startElement;

            [FieldOffset(60)]
            internal global::System.IntPtr endElement;

            [FieldOffset(64)]
            internal global::System.IntPtr reference;

            [FieldOffset(68)]
            internal global::System.IntPtr characters;

            [FieldOffset(72)]
            internal global::System.IntPtr ignorableWhitespace;

            [FieldOffset(76)]
            internal global::System.IntPtr processingInstruction;

            [FieldOffset(80)]
            internal global::System.IntPtr comment;

            [FieldOffset(84)]
            internal global::System.IntPtr warning;

            [FieldOffset(88)]
            internal global::System.IntPtr error;

            [FieldOffset(92)]
            internal global::System.IntPtr fatalError;

            [FieldOffset(96)]
            internal global::System.IntPtr getParameterEntity;

            [FieldOffset(100)]
            internal global::System.IntPtr cdataBlock;

            [FieldOffset(104)]
            internal global::System.IntPtr externalSubset;

            [FieldOffset(108)]
            internal uint initialized;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN16_xmlSAXHandlerV1C2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlSAXHandlerV1> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlSAXHandlerV1>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlSAXHandlerV1 __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlSAXHandlerV1(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlSAXHandlerV1 __CreateInstance(global::libxml.XmlSAXHandlerV1.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlSAXHandlerV1(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlSAXHandlerV1.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlSAXHandlerV1.__Internal));
            *(global::libxml.XmlSAXHandlerV1.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlSAXHandlerV1(global::libxml.XmlSAXHandlerV1.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlSAXHandlerV1(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlSAXHandlerV1()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlSAXHandlerV1.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlSAXHandlerV1(global::libxml.XmlSAXHandlerV1 _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlSAXHandlerV1.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance) = *((global::libxml.XmlSAXHandlerV1.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlSAXHandlerV1 __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public global::libxml.InternalSubsetSAXFunc InternalSubset
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->internalSubset;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.InternalSubsetSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.InternalSubsetSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->internalSubset = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.IsStandaloneSAXFunc IsStandalone
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->isStandalone;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.IsStandaloneSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.IsStandaloneSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->isStandalone = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.HasInternalSubsetSAXFunc HasInternalSubset
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->hasInternalSubset;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.HasInternalSubsetSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.HasInternalSubsetSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->hasInternalSubset = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.HasExternalSubsetSAXFunc HasExternalSubset
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->hasExternalSubset;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.HasExternalSubsetSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.HasExternalSubsetSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->hasExternalSubset = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.ResolveEntitySAXFunc ResolveEntity
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->resolveEntity;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.ResolveEntitySAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.ResolveEntitySAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->resolveEntity = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.GetEntitySAXFunc GetEntity
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->getEntity;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.GetEntitySAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.GetEntitySAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->getEntity = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.EntityDeclSAXFunc EntityDecl
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->entityDecl;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.EntityDeclSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.EntityDeclSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->entityDecl = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.NotationDeclSAXFunc NotationDecl
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->notationDecl;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.NotationDeclSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.NotationDeclSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->notationDecl = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.AttributeDeclSAXFunc AttributeDecl
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->attributeDecl;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.AttributeDeclSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.AttributeDeclSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->attributeDecl = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.ElementDeclSAXFunc ElementDecl
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->elementDecl;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.ElementDeclSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.ElementDeclSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->elementDecl = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.UnparsedEntityDeclSAXFunc UnparsedEntityDecl
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->unparsedEntityDecl;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.UnparsedEntityDeclSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.UnparsedEntityDeclSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->unparsedEntityDecl = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.SetDocumentLocatorSAXFunc SetDocumentLocator
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->setDocumentLocator;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.SetDocumentLocatorSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.SetDocumentLocatorSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->setDocumentLocator = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.StartDocumentSAXFunc StartDocument
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->startDocument;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.StartDocumentSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.StartDocumentSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->startDocument = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.EndDocumentSAXFunc EndDocument
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->endDocument;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.EndDocumentSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.EndDocumentSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->endDocument = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.StartElementSAXFunc StartElement
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->startElement;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.StartElementSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.StartElementSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->startElement = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.EndElementSAXFunc EndElement
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->endElement;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.EndElementSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.EndElementSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->endElement = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.ReferenceSAXFunc Reference
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->reference;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.ReferenceSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.ReferenceSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->reference = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.CharactersSAXFunc Characters
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->characters;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.CharactersSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.CharactersSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->characters = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.IgnorableWhitespaceSAXFunc IgnorableWhitespace
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->ignorableWhitespace;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.IgnorableWhitespaceSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.IgnorableWhitespaceSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->ignorableWhitespace = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.ProcessingInstructionSAXFunc ProcessingInstruction
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->processingInstruction;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.ProcessingInstructionSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.ProcessingInstructionSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->processingInstruction = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.CommentSAXFunc Comment
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->comment;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.CommentSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.CommentSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->comment = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.WarningSAXFunc Warning
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->warning;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.WarningSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.WarningSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->warning = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.ErrorSAXFunc Error
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->error;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.ErrorSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.ErrorSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->error = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.FatalErrorSAXFunc FatalError
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->fatalError;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.FatalErrorSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.FatalErrorSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->fatalError = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.GetParameterEntitySAXFunc GetParameterEntity
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->getParameterEntity;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.GetParameterEntitySAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.GetParameterEntitySAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->getParameterEntity = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.CdataBlockSAXFunc CdataBlock
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->cdataBlock;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.CdataBlockSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.CdataBlockSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->cdataBlock = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.ExternalSubsetSAXFunc ExternalSubset
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->externalSubset;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.ExternalSubsetSAXFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.ExternalSubsetSAXFunc));
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->externalSubset = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public uint Initialized
        {
            get
            {
                return ((global::libxml.XmlSAXHandlerV1.__Internal*) __Instance)->initialized;
            }

            set
            {
                ((global::libxml.XmlSAXHandlerV1.__Internal*)__Instance)->initialized = value;
            }
        }
    }

    public unsafe partial class parser
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlInitParser")]
            internal static extern void XmlInitParser();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCleanupParser")]
            internal static extern void XmlCleanupParser();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParserInputRead")]
            internal static extern int XmlParserInputRead(global::System.IntPtr @in, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParserInputGrow")]
            internal static extern int XmlParserInputGrow(global::System.IntPtr @in, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParseDoc")]
            internal static extern global::System.IntPtr XmlParseDoc(byte* cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParseFile")]
            internal static extern global::System.IntPtr XmlParseFile([MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParseMemory")]
            internal static extern global::System.IntPtr XmlParseMemory([MarshalAs(UnmanagedType.LPUTF8Str)] string buffer, int size);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSubstituteEntitiesDefault")]
            internal static extern int XmlSubstituteEntitiesDefault(int val);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlKeepBlanksDefault")]
            internal static extern int XmlKeepBlanksDefault(int val);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlStopParser")]
            internal static extern void XmlStopParser(global::System.IntPtr ctxt);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlPedanticParserDefault")]
            internal static extern int XmlPedanticParserDefault(int val);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlLineNumbersDefault")]
            internal static extern int XmlLineNumbersDefault(int val);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlRecoverDoc")]
            internal static extern global::System.IntPtr XmlRecoverDoc(byte* cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlRecoverMemory")]
            internal static extern global::System.IntPtr XmlRecoverMemory([MarshalAs(UnmanagedType.LPUTF8Str)] string buffer, int size);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlRecoverFile")]
            internal static extern global::System.IntPtr XmlRecoverFile([MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParseDocument")]
            internal static extern int XmlParseDocument(global::System.IntPtr ctxt);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParseExtParsedEnt")]
            internal static extern int XmlParseExtParsedEnt(global::System.IntPtr ctxt);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAXUserParseFile")]
            internal static extern int XmlSAXUserParseFile(global::System.IntPtr sax, global::System.IntPtr user_data, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAXUserParseMemory")]
            internal static extern int XmlSAXUserParseMemory(global::System.IntPtr sax, global::System.IntPtr user_data, [MarshalAs(UnmanagedType.LPUTF8Str)] string buffer, int size);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAXParseDoc")]
            internal static extern global::System.IntPtr XmlSAXParseDoc(global::System.IntPtr sax, byte* cur, int recovery);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAXParseMemory")]
            internal static extern global::System.IntPtr XmlSAXParseMemory(global::System.IntPtr sax, [MarshalAs(UnmanagedType.LPUTF8Str)] string buffer, int size, int recovery);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAXParseMemoryWithData")]
            internal static extern global::System.IntPtr XmlSAXParseMemoryWithData(global::System.IntPtr sax, [MarshalAs(UnmanagedType.LPUTF8Str)] string buffer, int size, int recovery, global::System.IntPtr data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAXParseFile")]
            internal static extern global::System.IntPtr XmlSAXParseFile(global::System.IntPtr sax, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename, int recovery);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAXParseFileWithData")]
            internal static extern global::System.IntPtr XmlSAXParseFileWithData(global::System.IntPtr sax, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename, int recovery, global::System.IntPtr data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAXParseEntity")]
            internal static extern global::System.IntPtr XmlSAXParseEntity(global::System.IntPtr sax, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParseEntity")]
            internal static extern global::System.IntPtr XmlParseEntity([MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAXParseDTD")]
            internal static extern global::System.IntPtr XmlSAXParseDTD(global::System.IntPtr sax, byte* ExternalID, byte* SystemID);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParseDTD")]
            internal static extern global::System.IntPtr XmlParseDTD(byte* ExternalID, byte* SystemID);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlIOParseDTD")]
            internal static extern global::System.IntPtr XmlIOParseDTD(global::System.IntPtr sax, global::System.IntPtr input, global::libxml.XmlCharEncoding enc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParseBalancedChunkMemory")]
            internal static extern int XmlParseBalancedChunkMemory(global::System.IntPtr doc, global::System.IntPtr sax, global::System.IntPtr user_data, int depth, byte* @string, global::System.IntPtr lst);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParseInNodeContext")]
            internal static extern global::libxml.XmlParserErrors XmlParseInNodeContext(global::System.IntPtr node, [MarshalAs(UnmanagedType.LPUTF8Str)] string data, int datalen, int options, global::System.IntPtr lst);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParseBalancedChunkMemoryRecover")]
            internal static extern int XmlParseBalancedChunkMemoryRecover(global::System.IntPtr doc, global::System.IntPtr sax, global::System.IntPtr user_data, int depth, byte* @string, global::System.IntPtr lst, int recover);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParseExternalEntity")]
            internal static extern int XmlParseExternalEntity(global::System.IntPtr doc, global::System.IntPtr sax, global::System.IntPtr user_data, int depth, byte* URL, byte* ID, global::System.IntPtr lst);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParseCtxtExternalEntity")]
            internal static extern int XmlParseCtxtExternalEntity(global::System.IntPtr ctx, byte* URL, byte* ID, global::System.IntPtr lst);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewParserCtxt")]
            internal static extern global::System.IntPtr XmlNewParserCtxt();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlInitParserCtxt")]
            internal static extern int XmlInitParserCtxt(global::System.IntPtr ctxt);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlClearParserCtxt")]
            internal static extern void XmlClearParserCtxt(global::System.IntPtr ctxt);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlFreeParserCtxt")]
            internal static extern void XmlFreeParserCtxt(global::System.IntPtr ctxt);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSetupParserForBuffer")]
            internal static extern void XmlSetupParserForBuffer(global::System.IntPtr ctxt, byte* buffer, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCreateDocParserCtxt")]
            internal static extern global::System.IntPtr XmlCreateDocParserCtxt(byte* cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetFeaturesList")]
            internal static extern int XmlGetFeaturesList(int* len, sbyte** result);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetFeature")]
            internal static extern int XmlGetFeature(global::System.IntPtr ctxt, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, global::System.IntPtr result);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSetFeature")]
            internal static extern int XmlSetFeature(global::System.IntPtr ctxt, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, global::System.IntPtr value);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCreatePushParserCtxt")]
            internal static extern global::System.IntPtr XmlCreatePushParserCtxt(global::System.IntPtr sax, global::System.IntPtr user_data, [MarshalAs(UnmanagedType.LPUTF8Str)] string chunk, int size, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParseChunk")]
            internal static extern int XmlParseChunk(global::System.IntPtr ctxt, [MarshalAs(UnmanagedType.LPUTF8Str)] string chunk, int size, int terminate);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCreateIOParserCtxt")]
            internal static extern global::System.IntPtr XmlCreateIOParserCtxt(global::System.IntPtr sax, global::System.IntPtr user_data, global::System.IntPtr ioread, global::System.IntPtr ioclose, global::System.IntPtr ioctx, global::libxml.XmlCharEncoding enc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewIOInputStream")]
            internal static extern global::System.IntPtr XmlNewIOInputStream(global::System.IntPtr ctxt, global::System.IntPtr input, global::libxml.XmlCharEncoding enc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParserFindNodeInfo")]
            internal static extern global::System.IntPtr XmlParserFindNodeInfo(global::System.IntPtr ctxt, global::System.IntPtr node);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlInitNodeInfoSeq")]
            internal static extern void XmlInitNodeInfoSeq(global::System.IntPtr seq);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlClearNodeInfoSeq")]
            internal static extern void XmlClearNodeInfoSeq(global::System.IntPtr seq);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParserFindNodeInfoIndex")]
            internal static extern uint XmlParserFindNodeInfoIndex(global::System.IntPtr seq, global::System.IntPtr node);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParserAddNodeInfo")]
            internal static extern void XmlParserAddNodeInfo(global::System.IntPtr ctxt, global::System.IntPtr info);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSetExternalEntityLoader")]
            internal static extern void XmlSetExternalEntityLoader(global::System.IntPtr f);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetExternalEntityLoader")]
            internal static extern global::System.IntPtr XmlGetExternalEntityLoader();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlLoadExternalEntity")]
            internal static extern global::System.IntPtr XmlLoadExternalEntity([MarshalAs(UnmanagedType.LPUTF8Str)] string URL, [MarshalAs(UnmanagedType.LPUTF8Str)] string ID, global::System.IntPtr ctxt);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlByteConsumed")]
            internal static extern int XmlByteConsumed(global::System.IntPtr ctxt);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCtxtReset")]
            internal static extern void XmlCtxtReset(global::System.IntPtr ctxt);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCtxtResetPush")]
            internal static extern int XmlCtxtResetPush(global::System.IntPtr ctxt, [MarshalAs(UnmanagedType.LPUTF8Str)] string chunk, int size, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename, [MarshalAs(UnmanagedType.LPUTF8Str)] string encoding);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCtxtUseOptions")]
            internal static extern int XmlCtxtUseOptions(global::System.IntPtr ctxt, int options);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlReadDoc")]
            internal static extern global::System.IntPtr XmlReadDoc(byte* cur, [MarshalAs(UnmanagedType.LPUTF8Str)] string URL, [MarshalAs(UnmanagedType.LPUTF8Str)] string encoding, int options);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlReadFile")]
            internal static extern global::System.IntPtr XmlReadFile([MarshalAs(UnmanagedType.LPUTF8Str)] string URL, [MarshalAs(UnmanagedType.LPUTF8Str)] string encoding, int options);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlReadMemory")]
            internal static extern global::System.IntPtr XmlReadMemory([MarshalAs(UnmanagedType.LPUTF8Str)] string buffer, int size, [MarshalAs(UnmanagedType.LPUTF8Str)] string URL, [MarshalAs(UnmanagedType.LPUTF8Str)] string encoding, int options);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlReadFd")]
            internal static extern global::System.IntPtr XmlReadFd(int fd, [MarshalAs(UnmanagedType.LPUTF8Str)] string URL, [MarshalAs(UnmanagedType.LPUTF8Str)] string encoding, int options);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlReadIO")]
            internal static extern global::System.IntPtr XmlReadIO(global::System.IntPtr ioread, global::System.IntPtr ioclose, global::System.IntPtr ioctx, [MarshalAs(UnmanagedType.LPUTF8Str)] string URL, [MarshalAs(UnmanagedType.LPUTF8Str)] string encoding, int options);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCtxtReadDoc")]
            internal static extern global::System.IntPtr XmlCtxtReadDoc(global::System.IntPtr ctxt, byte* cur, [MarshalAs(UnmanagedType.LPUTF8Str)] string URL, [MarshalAs(UnmanagedType.LPUTF8Str)] string encoding, int options);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCtxtReadFile")]
            internal static extern global::System.IntPtr XmlCtxtReadFile(global::System.IntPtr ctxt, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename, [MarshalAs(UnmanagedType.LPUTF8Str)] string encoding, int options);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCtxtReadMemory")]
            internal static extern global::System.IntPtr XmlCtxtReadMemory(global::System.IntPtr ctxt, [MarshalAs(UnmanagedType.LPUTF8Str)] string buffer, int size, [MarshalAs(UnmanagedType.LPUTF8Str)] string URL, [MarshalAs(UnmanagedType.LPUTF8Str)] string encoding, int options);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCtxtReadFd")]
            internal static extern global::System.IntPtr XmlCtxtReadFd(global::System.IntPtr ctxt, int fd, [MarshalAs(UnmanagedType.LPUTF8Str)] string URL, [MarshalAs(UnmanagedType.LPUTF8Str)] string encoding, int options);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCtxtReadIO")]
            internal static extern global::System.IntPtr XmlCtxtReadIO(global::System.IntPtr ctxt, global::System.IntPtr ioread, global::System.IntPtr ioclose, global::System.IntPtr ioctx, [MarshalAs(UnmanagedType.LPUTF8Str)] string URL, [MarshalAs(UnmanagedType.LPUTF8Str)] string encoding, int options);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlHasFeature")]
            internal static extern int XmlHasFeature(global::libxml.XmlFeature feature);
        }

        public static void XmlInitParser()
        {
            __Internal.XmlInitParser();
        }

        public static void XmlCleanupParser()
        {
            __Internal.XmlCleanupParser();
        }

        public static int XmlParserInputRead(global::libxml.XmlParserInput @in, int len)
        {
            var __arg0 = ReferenceEquals(@in, null) ? global::System.IntPtr.Zero : @in.__Instance;
            var __ret = __Internal.XmlParserInputRead(__arg0, len);
            return __ret;
        }

        public static int XmlParserInputGrow(global::libxml.XmlParserInput @in, int len)
        {
            var __arg0 = ReferenceEquals(@in, null) ? global::System.IntPtr.Zero : @in.__Instance;
            var __ret = __Internal.XmlParserInputGrow(__arg0, len);
            return __ret;
        }

        public static global::libxml.XmlDoc XmlParseDoc(byte* cur)
        {
            var __ret = __Internal.XmlParseDoc(cur);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDoc XmlParseFile(string filename)
        {
            var __ret = __Internal.XmlParseFile(filename);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDoc XmlParseMemory(string buffer, int size)
        {
            var __ret = __Internal.XmlParseMemory(buffer, size);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlSubstituteEntitiesDefault(int val)
        {
            var __ret = __Internal.XmlSubstituteEntitiesDefault(val);
            return __ret;
        }

        public static int XmlKeepBlanksDefault(int val)
        {
            var __ret = __Internal.XmlKeepBlanksDefault(val);
            return __ret;
        }

        public static void XmlStopParser(global::libxml.XmlParserCtxt ctxt)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            __Internal.XmlStopParser(__arg0);
        }

        public static int XmlPedanticParserDefault(int val)
        {
            var __ret = __Internal.XmlPedanticParserDefault(val);
            return __ret;
        }

        public static int XmlLineNumbersDefault(int val)
        {
            var __ret = __Internal.XmlLineNumbersDefault(val);
            return __ret;
        }

        public static global::libxml.XmlDoc XmlRecoverDoc(byte* cur)
        {
            var __ret = __Internal.XmlRecoverDoc(cur);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDoc XmlRecoverMemory(string buffer, int size)
        {
            var __ret = __Internal.XmlRecoverMemory(buffer, size);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDoc XmlRecoverFile(string filename)
        {
            var __ret = __Internal.XmlRecoverFile(filename);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlParseDocument(global::libxml.XmlParserCtxt ctxt)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __ret = __Internal.XmlParseDocument(__arg0);
            return __ret;
        }

        public static int XmlParseExtParsedEnt(global::libxml.XmlParserCtxt ctxt)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __ret = __Internal.XmlParseExtParsedEnt(__arg0);
            return __ret;
        }

        public static int XmlSAXUserParseFile(global::libxml.XmlSAXHandler sax, global::System.IntPtr user_data, string filename)
        {
            var __arg0 = ReferenceEquals(sax, null) ? global::System.IntPtr.Zero : sax.__Instance;
            var __ret = __Internal.XmlSAXUserParseFile(__arg0, user_data, filename);
            return __ret;
        }

        public static int XmlSAXUserParseMemory(global::libxml.XmlSAXHandler sax, global::System.IntPtr user_data, string buffer, int size)
        {
            var __arg0 = ReferenceEquals(sax, null) ? global::System.IntPtr.Zero : sax.__Instance;
            var __ret = __Internal.XmlSAXUserParseMemory(__arg0, user_data, buffer, size);
            return __ret;
        }

        public static global::libxml.XmlDoc XmlSAXParseDoc(global::libxml.XmlSAXHandler sax, byte* cur, int recovery)
        {
            var __arg0 = ReferenceEquals(sax, null) ? global::System.IntPtr.Zero : sax.__Instance;
            var __ret = __Internal.XmlSAXParseDoc(__arg0, cur, recovery);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDoc XmlSAXParseMemory(global::libxml.XmlSAXHandler sax, string buffer, int size, int recovery)
        {
            var __arg0 = ReferenceEquals(sax, null) ? global::System.IntPtr.Zero : sax.__Instance;
            var __ret = __Internal.XmlSAXParseMemory(__arg0, buffer, size, recovery);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDoc XmlSAXParseMemoryWithData(global::libxml.XmlSAXHandler sax, string buffer, int size, int recovery, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(sax, null) ? global::System.IntPtr.Zero : sax.__Instance;
            var __ret = __Internal.XmlSAXParseMemoryWithData(__arg0, buffer, size, recovery, data);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDoc XmlSAXParseFile(global::libxml.XmlSAXHandler sax, string filename, int recovery)
        {
            var __arg0 = ReferenceEquals(sax, null) ? global::System.IntPtr.Zero : sax.__Instance;
            var __ret = __Internal.XmlSAXParseFile(__arg0, filename, recovery);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDoc XmlSAXParseFileWithData(global::libxml.XmlSAXHandler sax, string filename, int recovery, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(sax, null) ? global::System.IntPtr.Zero : sax.__Instance;
            var __ret = __Internal.XmlSAXParseFileWithData(__arg0, filename, recovery, data);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDoc XmlSAXParseEntity(global::libxml.XmlSAXHandler sax, string filename)
        {
            var __arg0 = ReferenceEquals(sax, null) ? global::System.IntPtr.Zero : sax.__Instance;
            var __ret = __Internal.XmlSAXParseEntity(__arg0, filename);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDoc XmlParseEntity(string filename)
        {
            var __ret = __Internal.XmlParseEntity(filename);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDtd XmlSAXParseDTD(global::libxml.XmlSAXHandler sax, byte* ExternalID, byte* SystemID)
        {
            var __arg0 = ReferenceEquals(sax, null) ? global::System.IntPtr.Zero : sax.__Instance;
            var __ret = __Internal.XmlSAXParseDTD(__arg0, ExternalID, SystemID);
            global::libxml.XmlDtd __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDtd.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDtd) global::libxml.XmlDtd.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDtd.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDtd XmlParseDTD(byte* ExternalID, byte* SystemID)
        {
            var __ret = __Internal.XmlParseDTD(ExternalID, SystemID);
            global::libxml.XmlDtd __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDtd.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDtd) global::libxml.XmlDtd.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDtd.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDtd XmlIOParseDTD(global::libxml.XmlSAXHandler sax, global::libxml.XmlParserInputBuffer input, global::libxml.XmlCharEncoding enc)
        {
            var __arg0 = ReferenceEquals(sax, null) ? global::System.IntPtr.Zero : sax.__Instance;
            var __arg1 = ReferenceEquals(input, null) ? global::System.IntPtr.Zero : input.__Instance;
            var __ret = __Internal.XmlIOParseDTD(__arg0, __arg1, enc);
            global::libxml.XmlDtd __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDtd.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDtd) global::libxml.XmlDtd.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDtd.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlParseBalancedChunkMemory(global::libxml.XmlDoc doc, global::libxml.XmlSAXHandler sax, global::System.IntPtr user_data, int depth, byte* @string, global::libxml.XmlNode lst)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg1 = ReferenceEquals(sax, null) ? global::System.IntPtr.Zero : sax.__Instance;
            var ____arg5 = ReferenceEquals(lst, null) ? global::System.IntPtr.Zero : lst.__Instance;
            var __arg5 = new global::System.IntPtr(&____arg5);
            var __ret = __Internal.XmlParseBalancedChunkMemory(__arg0, __arg1, user_data, depth, @string, __arg5);
            return __ret;
        }

        public static global::libxml.XmlParserErrors XmlParseInNodeContext(global::libxml.XmlNode node, string data, int datalen, int options, global::libxml.XmlNode lst)
        {
            var __arg0 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var ____arg4 = ReferenceEquals(lst, null) ? global::System.IntPtr.Zero : lst.__Instance;
            var __arg4 = new global::System.IntPtr(&____arg4);
            var __ret = __Internal.XmlParseInNodeContext(__arg0, data, datalen, options, __arg4);
            return __ret;
        }

        public static int XmlParseBalancedChunkMemoryRecover(global::libxml.XmlDoc doc, global::libxml.XmlSAXHandler sax, global::System.IntPtr user_data, int depth, byte* @string, global::libxml.XmlNode lst, int recover)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg1 = ReferenceEquals(sax, null) ? global::System.IntPtr.Zero : sax.__Instance;
            var ____arg5 = ReferenceEquals(lst, null) ? global::System.IntPtr.Zero : lst.__Instance;
            var __arg5 = new global::System.IntPtr(&____arg5);
            var __ret = __Internal.XmlParseBalancedChunkMemoryRecover(__arg0, __arg1, user_data, depth, @string, __arg5, recover);
            return __ret;
        }

        public static int XmlParseExternalEntity(global::libxml.XmlDoc doc, global::libxml.XmlSAXHandler sax, global::System.IntPtr user_data, int depth, byte* URL, byte* ID, global::libxml.XmlNode lst)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg1 = ReferenceEquals(sax, null) ? global::System.IntPtr.Zero : sax.__Instance;
            var ____arg6 = ReferenceEquals(lst, null) ? global::System.IntPtr.Zero : lst.__Instance;
            var __arg6 = new global::System.IntPtr(&____arg6);
            var __ret = __Internal.XmlParseExternalEntity(__arg0, __arg1, user_data, depth, URL, ID, __arg6);
            return __ret;
        }

        public static int XmlParseCtxtExternalEntity(global::libxml.XmlParserCtxt ctx, byte* URL, byte* ID, global::libxml.XmlNode lst)
        {
            var __arg0 = ReferenceEquals(ctx, null) ? global::System.IntPtr.Zero : ctx.__Instance;
            var ____arg3 = ReferenceEquals(lst, null) ? global::System.IntPtr.Zero : lst.__Instance;
            var __arg3 = new global::System.IntPtr(&____arg3);
            var __ret = __Internal.XmlParseCtxtExternalEntity(__arg0, URL, ID, __arg3);
            return __ret;
        }

        public static global::libxml.XmlParserCtxt XmlNewParserCtxt()
        {
            var __ret = __Internal.XmlNewParserCtxt();
            global::libxml.XmlParserCtxt __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlParserCtxt.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlParserCtxt) global::libxml.XmlParserCtxt.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlParserCtxt.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlInitParserCtxt(global::libxml.XmlParserCtxt ctxt)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __ret = __Internal.XmlInitParserCtxt(__arg0);
            return __ret;
        }

        public static void XmlClearParserCtxt(global::libxml.XmlParserCtxt ctxt)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            __Internal.XmlClearParserCtxt(__arg0);
        }

        public static void XmlFreeParserCtxt(global::libxml.XmlParserCtxt ctxt)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            __Internal.XmlFreeParserCtxt(__arg0);
        }

        public static void XmlSetupParserForBuffer(global::libxml.XmlParserCtxt ctxt, byte* buffer, string filename)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            __Internal.XmlSetupParserForBuffer(__arg0, buffer, filename);
        }

        public static global::libxml.XmlParserCtxt XmlCreateDocParserCtxt(byte* cur)
        {
            var __ret = __Internal.XmlCreateDocParserCtxt(cur);
            global::libxml.XmlParserCtxt __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlParserCtxt.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlParserCtxt) global::libxml.XmlParserCtxt.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlParserCtxt.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlGetFeaturesList(ref int len, sbyte** result)
        {
            fixed (int* __len0 = &len)
            {
                var __arg0 = __len0;
                var __ret = __Internal.XmlGetFeaturesList(__arg0, result);
                return __ret;
            }
        }

        public static int XmlGetFeature(global::libxml.XmlParserCtxt ctxt, string name, global::System.IntPtr result)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __ret = __Internal.XmlGetFeature(__arg0, name, result);
            return __ret;
        }

        public static int XmlSetFeature(global::libxml.XmlParserCtxt ctxt, string name, global::System.IntPtr value)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __ret = __Internal.XmlSetFeature(__arg0, name, value);
            return __ret;
        }

        public static global::libxml.XmlParserCtxt XmlCreatePushParserCtxt(global::libxml.XmlSAXHandler sax, global::System.IntPtr user_data, string chunk, int size, string filename)
        {
            var __arg0 = ReferenceEquals(sax, null) ? global::System.IntPtr.Zero : sax.__Instance;
            var __ret = __Internal.XmlCreatePushParserCtxt(__arg0, user_data, chunk, size, filename);
            global::libxml.XmlParserCtxt __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlParserCtxt.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlParserCtxt) global::libxml.XmlParserCtxt.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlParserCtxt.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlParseChunk(global::libxml.XmlParserCtxt ctxt, string chunk, int size, int terminate)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __ret = __Internal.XmlParseChunk(__arg0, chunk, size, terminate);
            return __ret;
        }

        public static global::libxml.XmlParserCtxt XmlCreateIOParserCtxt(global::libxml.XmlSAXHandler sax, global::System.IntPtr user_data, global::libxml.XmlInputReadCallback ioread, global::libxml.XmlInputCloseCallback ioclose, global::System.IntPtr ioctx, global::libxml.XmlCharEncoding enc)
        {
            var __arg0 = ReferenceEquals(sax, null) ? global::System.IntPtr.Zero : sax.__Instance;
            var __arg2 = ioread == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(ioread);
            var __arg3 = ioclose == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(ioclose);
            var __ret = __Internal.XmlCreateIOParserCtxt(__arg0, user_data, __arg2, __arg3, ioctx, enc);
            global::libxml.XmlParserCtxt __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlParserCtxt.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlParserCtxt) global::libxml.XmlParserCtxt.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlParserCtxt.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlParserInput XmlNewIOInputStream(global::libxml.XmlParserCtxt ctxt, global::libxml.XmlParserInputBuffer input, global::libxml.XmlCharEncoding enc)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(input, null) ? global::System.IntPtr.Zero : input.__Instance;
            var __ret = __Internal.XmlNewIOInputStream(__arg0, __arg1, enc);
            global::libxml.XmlParserInput __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlParserInput.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlParserInput) global::libxml.XmlParserInput.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlParserInput.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlParserNodeInfo XmlParserFindNodeInfo(global::libxml.XmlParserCtxt ctxt, global::libxml.XmlNode node)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlParserFindNodeInfo(__arg0, __arg1);
            global::libxml.XmlParserNodeInfo __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlParserNodeInfo.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlParserNodeInfo) global::libxml.XmlParserNodeInfo.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlParserNodeInfo.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlInitNodeInfoSeq(global::libxml.XmlParserNodeInfoSeq seq)
        {
            var __arg0 = ReferenceEquals(seq, null) ? global::System.IntPtr.Zero : seq.__Instance;
            __Internal.XmlInitNodeInfoSeq(__arg0);
        }

        public static void XmlClearNodeInfoSeq(global::libxml.XmlParserNodeInfoSeq seq)
        {
            var __arg0 = ReferenceEquals(seq, null) ? global::System.IntPtr.Zero : seq.__Instance;
            __Internal.XmlClearNodeInfoSeq(__arg0);
        }

        public static uint XmlParserFindNodeInfoIndex(global::libxml.XmlParserNodeInfoSeq seq, global::libxml.XmlNode node)
        {
            var __arg0 = ReferenceEquals(seq, null) ? global::System.IntPtr.Zero : seq.__Instance;
            var __arg1 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlParserFindNodeInfoIndex(__arg0, __arg1);
            return __ret;
        }

        public static void XmlParserAddNodeInfo(global::libxml.XmlParserCtxt ctxt, global::libxml.XmlParserNodeInfo info)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(info, null) ? global::System.IntPtr.Zero : info.__Instance;
            __Internal.XmlParserAddNodeInfo(__arg0, __arg1);
        }

        public static void XmlSetExternalEntityLoader(global::libxml.XmlExternalEntityLoader f)
        {
            var __arg0 = f == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(f);
            __Internal.XmlSetExternalEntityLoader(__arg0);
        }

        public static global::libxml.XmlExternalEntityLoader XmlGetExternalEntityLoader()
        {
            var __ret = __Internal.XmlGetExternalEntityLoader();
            var __ptr0 = __ret;
            return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlExternalEntityLoader) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlExternalEntityLoader));
        }

        public static global::libxml.XmlParserInput XmlLoadExternalEntity(string URL, string ID, global::libxml.XmlParserCtxt ctxt)
        {
            var __arg2 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __ret = __Internal.XmlLoadExternalEntity(URL, ID, __arg2);
            global::libxml.XmlParserInput __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlParserInput.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlParserInput) global::libxml.XmlParserInput.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlParserInput.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlByteConsumed(global::libxml.XmlParserCtxt ctxt)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __ret = __Internal.XmlByteConsumed(__arg0);
            return __ret;
        }

        public static void XmlCtxtReset(global::libxml.XmlParserCtxt ctxt)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            __Internal.XmlCtxtReset(__arg0);
        }

        public static int XmlCtxtResetPush(global::libxml.XmlParserCtxt ctxt, string chunk, int size, string filename, string encoding)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __ret = __Internal.XmlCtxtResetPush(__arg0, chunk, size, filename, encoding);
            return __ret;
        }

        public static int XmlCtxtUseOptions(global::libxml.XmlParserCtxt ctxt, int options)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __ret = __Internal.XmlCtxtUseOptions(__arg0, options);
            return __ret;
        }

        public static global::libxml.XmlDoc XmlReadDoc(byte* cur, string URL, string encoding, int options)
        {
            var __ret = __Internal.XmlReadDoc(cur, URL, encoding, options);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDoc XmlReadFile(string URL, string encoding, int options)
        {
            var __ret = __Internal.XmlReadFile(URL, encoding, options);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDoc XmlReadMemory(string buffer, int size, string URL, string encoding, int options)
        {
            var __ret = __Internal.XmlReadMemory(buffer, size, URL, encoding, options);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDoc XmlReadFd(int fd, string URL, string encoding, int options)
        {
            var __ret = __Internal.XmlReadFd(fd, URL, encoding, options);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDoc XmlReadIO(global::libxml.XmlInputReadCallback ioread, global::libxml.XmlInputCloseCallback ioclose, global::System.IntPtr ioctx, string URL, string encoding, int options)
        {
            var __arg0 = ioread == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(ioread);
            var __arg1 = ioclose == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(ioclose);
            var __ret = __Internal.XmlReadIO(__arg0, __arg1, ioctx, URL, encoding, options);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDoc XmlCtxtReadDoc(global::libxml.XmlParserCtxt ctxt, byte* cur, string URL, string encoding, int options)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __ret = __Internal.XmlCtxtReadDoc(__arg0, cur, URL, encoding, options);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDoc XmlCtxtReadFile(global::libxml.XmlParserCtxt ctxt, string filename, string encoding, int options)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __ret = __Internal.XmlCtxtReadFile(__arg0, filename, encoding, options);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDoc XmlCtxtReadMemory(global::libxml.XmlParserCtxt ctxt, string buffer, int size, string URL, string encoding, int options)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __ret = __Internal.XmlCtxtReadMemory(__arg0, buffer, size, URL, encoding, options);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDoc XmlCtxtReadFd(global::libxml.XmlParserCtxt ctxt, int fd, string URL, string encoding, int options)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __ret = __Internal.XmlCtxtReadFd(__arg0, fd, URL, encoding, options);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlDoc XmlCtxtReadIO(global::libxml.XmlParserCtxt ctxt, global::libxml.XmlInputReadCallback ioread, global::libxml.XmlInputCloseCallback ioclose, global::System.IntPtr ioctx, string URL, string encoding, int options)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ioread == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(ioread);
            var __arg2 = ioclose == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(ioclose);
            var __ret = __Internal.XmlCtxtReadIO(__arg0, __arg1, __arg2, ioctx, URL, encoding, options);
            global::libxml.XmlDoc __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlDoc.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlHasFeature(global::libxml.XmlFeature feature)
        {
            var __ret = __Internal.XmlHasFeature(feature);
            return __ret;
        }
    }

    /// <summary>xmlErrorLevel:</summary>
    /// <remarks>Indicates the level of an error</remarks>
    public enum XmlErrorLevel : uint
    {
        XML_ERR_NONE = 0,
        XML_ERR_WARNING = 1,
        XML_ERR_ERROR = 2,
        XML_ERR_FATAL = 3
    }

    /// <summary>xmlErrorDomain:</summary>
    /// <remarks>Indicates where an error may have come from</remarks>
    public enum XmlErrorDomain : uint
    {
        XML_FROM_NONE = 0,
        XML_FROM_PARSER = 1,
        XML_FROM_TREE = 2,
        XML_FROM_NAMESPACE = 3,
        XML_FROM_DTD = 4,
        XML_FROM_HTML = 5,
        XML_FROM_MEMORY = 6,
        XML_FROM_OUTPUT = 7,
        XML_FROM_IO = 8,
        XML_FROM_FTP = 9,
        XML_FROM_HTTP = 10,
        XML_FROM_XINCLUDE = 11,
        XML_FROM_XPATH = 12,
        XML_FROM_XPOINTER = 13,
        XML_FROM_REGEXP = 14,
        XML_FROM_DATATYPE = 15,
        XML_FROM_SCHEMASP = 16,
        XML_FROM_SCHEMASV = 17,
        XML_FROM_RELAXNGP = 18,
        XML_FROM_RELAXNGV = 19,
        XML_FROM_CATALOG = 20,
        XML_FROM_C14N = 21,
        XML_FROM_XSLT = 22,
        XML_FROM_VALID = 23,
        XML_FROM_CHECK = 24,
        XML_FROM_WRITER = 25,
        XML_FROM_MODULE = 26,
        XML_FROM_I18N = 27,
        XML_FROM_SCHEMATRONV = 28,
        XML_FROM_BUFFER = 29,
        XML_FROM_URI = 30
    }

    /// <summary>xmlParserError:</summary>
    /// <remarks>This is an error that the XML (or HTML) parser can generate</remarks>
    public enum XmlParserErrors : uint
    {
        XML_ERR_OK = 0,
        XML_ERR_INTERNAL_ERROR = 1,
        XML_ERR_NO_MEMORY = 2,
        XML_ERR_DOCUMENT_START = 3,
        XML_ERR_DOCUMENT_EMPTY = 4,
        XML_ERR_DOCUMENT_END = 5,
        XML_ERR_INVALID_HEX_CHARREF = 6,
        XML_ERR_INVALID_DEC_CHARREF = 7,
        XML_ERR_INVALID_CHARREF = 8,
        XML_ERR_INVALID_CHAR = 9,
        XML_ERR_CHARREF_AT_EOF = 10,
        XML_ERR_CHARREF_IN_PROLOG = 11,
        XML_ERR_CHARREF_IN_EPILOG = 12,
        XML_ERR_CHARREF_IN_DTD = 13,
        XML_ERR_ENTITYREF_AT_EOF = 14,
        XML_ERR_ENTITYREF_IN_PROLOG = 15,
        XML_ERR_ENTITYREF_IN_EPILOG = 16,
        XML_ERR_ENTITYREF_IN_DTD = 17,
        XML_ERR_PEREF_AT_EOF = 18,
        XML_ERR_PEREF_IN_PROLOG = 19,
        XML_ERR_PEREF_IN_EPILOG = 20,
        XML_ERR_PEREF_IN_INT_SUBSET = 21,
        XML_ERR_ENTITYREF_NO_NAME = 22,
        XML_ERR_ENTITYREF_SEMICOL_MISSING = 23,
        XML_ERR_PEREF_NO_NAME = 24,
        XML_ERR_PEREF_SEMICOL_MISSING = 25,
        XML_ERR_UNDECLARED_ENTITY = 26,
        XML_WAR_UNDECLARED_ENTITY = 27,
        XML_ERR_UNPARSED_ENTITY = 28,
        XML_ERR_ENTITY_IS_EXTERNAL = 29,
        XML_ERR_ENTITY_IS_PARAMETER = 30,
        XML_ERR_UNKNOWN_ENCODING = 31,
        XML_ERR_UNSUPPORTED_ENCODING = 32,
        XML_ERR_STRING_NOT_STARTED = 33,
        XML_ERR_STRING_NOT_CLOSED = 34,
        XML_ERR_NS_DECL_ERROR = 35,
        XML_ERR_ENTITY_NOT_STARTED = 36,
        XML_ERR_ENTITY_NOT_FINISHED = 37,
        XML_ERR_LT_IN_ATTRIBUTE = 38,
        XML_ERR_ATTRIBUTE_NOT_STARTED = 39,
        XML_ERR_ATTRIBUTE_NOT_FINISHED = 40,
        XML_ERR_ATTRIBUTE_WITHOUT_VALUE = 41,
        XML_ERR_ATTRIBUTE_REDEFINED = 42,
        XML_ERR_LITERAL_NOT_STARTED = 43,
        XML_ERR_LITERAL_NOT_FINISHED = 44,
        XML_ERR_COMMENT_NOT_FINISHED = 45,
        XML_ERR_PI_NOT_STARTED = 46,
        XML_ERR_PI_NOT_FINISHED = 47,
        XML_ERR_NOTATION_NOT_STARTED = 48,
        XML_ERR_NOTATION_NOT_FINISHED = 49,
        XML_ERR_ATTLIST_NOT_STARTED = 50,
        XML_ERR_ATTLIST_NOT_FINISHED = 51,
        XML_ERR_MIXED_NOT_STARTED = 52,
        XML_ERR_MIXED_NOT_FINISHED = 53,
        XML_ERR_ELEMCONTENT_NOT_STARTED = 54,
        XML_ERR_ELEMCONTENT_NOT_FINISHED = 55,
        XML_ERR_XMLDECL_NOT_STARTED = 56,
        XML_ERR_XMLDECL_NOT_FINISHED = 57,
        XML_ERR_CONDSEC_NOT_STARTED = 58,
        XML_ERR_CONDSEC_NOT_FINISHED = 59,
        XML_ERR_EXT_SUBSET_NOT_FINISHED = 60,
        XML_ERR_DOCTYPE_NOT_FINISHED = 61,
        XML_ERR_MISPLACED_CDATA_END = 62,
        XML_ERR_CDATA_NOT_FINISHED = 63,
        XML_ERR_RESERVED_XML_NAME = 64,
        XML_ERR_SPACE_REQUIRED = 65,
        XML_ERR_SEPARATOR_REQUIRED = 66,
        XML_ERR_NMTOKEN_REQUIRED = 67,
        XML_ERR_NAME_REQUIRED = 68,
        XML_ERR_PCDATA_REQUIRED = 69,
        XML_ERR_URI_REQUIRED = 70,
        XML_ERR_PUBID_REQUIRED = 71,
        XML_ERR_LT_REQUIRED = 72,
        XML_ERR_GT_REQUIRED = 73,
        XML_ERR_LTSLASH_REQUIRED = 74,
        XML_ERR_EQUAL_REQUIRED = 75,
        XML_ERR_TAG_NAME_MISMATCH = 76,
        XML_ERR_TAG_NOT_FINISHED = 77,
        XML_ERR_STANDALONE_VALUE = 78,
        XML_ERR_ENCODING_NAME = 79,
        XML_ERR_HYPHEN_IN_COMMENT = 80,
        XML_ERR_INVALID_ENCODING = 81,
        XML_ERR_EXT_ENTITY_STANDALONE = 82,
        XML_ERR_CONDSEC_INVALID = 83,
        XML_ERR_VALUE_REQUIRED = 84,
        XML_ERR_NOT_WELL_BALANCED = 85,
        XML_ERR_EXTRA_CONTENT = 86,
        XML_ERR_ENTITY_CHAR_ERROR = 87,
        XML_ERR_ENTITY_PE_INTERNAL = 88,
        XML_ERR_ENTITY_LOOP = 89,
        XML_ERR_ENTITY_BOUNDARY = 90,
        XML_ERR_INVALID_URI = 91,
        XML_ERR_URI_FRAGMENT = 92,
        XML_WAR_CATALOG_PI = 93,
        XML_ERR_NO_DTD = 94,
        XML_ERR_CONDSEC_INVALID_KEYWORD = 95,
        XML_ERR_VERSION_MISSING = 96,
        XML_WAR_UNKNOWN_VERSION = 97,
        XML_WAR_LANG_VALUE = 98,
        XML_WAR_NS_URI = 99,
        XML_WAR_NS_URI_RELATIVE = 100,
        XML_ERR_MISSING_ENCODING = 101,
        XML_WAR_SPACE_VALUE = 102,
        XML_ERR_NOT_STANDALONE = 103,
        XML_ERR_ENTITY_PROCESSING = 104,
        XML_ERR_NOTATION_PROCESSING = 105,
        XML_WAR_NS_COLUMN = 106,
        XML_WAR_ENTITY_REDEFINED = 107,
        XML_ERR_UNKNOWN_VERSION = 108,
        XML_ERR_VERSION_MISMATCH = 109,
        XML_ERR_NAME_TOO_LONG = 110,
        XML_ERR_USER_STOP = 111,
        XML_NS_ERR_XML_NAMESPACE = 200,
        XML_NS_ERR_UNDEFINED_NAMESPACE = 201,
        XML_NS_ERR_QNAME = 202,
        XML_NS_ERR_ATTRIBUTE_REDEFINED = 203,
        XML_NS_ERR_EMPTY = 204,
        XML_NS_ERR_COLON = 205,
        XML_DTD_ATTRIBUTE_DEFAULT = 500,
        XML_DTD_ATTRIBUTE_REDEFINED = 501,
        XML_DTD_ATTRIBUTE_VALUE = 502,
        XML_DTD_CONTENT_ERROR = 503,
        XML_DTD_CONTENT_MODEL = 504,
        XML_DTD_CONTENT_NOT_DETERMINIST = 505,
        XML_DTD_DIFFERENT_PREFIX = 506,
        XML_DTD_ELEM_DEFAULT_NAMESPACE = 507,
        XML_DTD_ELEM_NAMESPACE = 508,
        XML_DTD_ELEM_REDEFINED = 509,
        XML_DTD_EMPTY_NOTATION = 510,
        XML_DTD_ENTITY_TYPE = 511,
        XML_DTD_ID_FIXED = 512,
        XML_DTD_ID_REDEFINED = 513,
        XML_DTD_ID_SUBSET = 514,
        XML_DTD_INVALID_CHILD = 515,
        XML_DTD_INVALID_DEFAULT = 516,
        XML_DTD_LOAD_ERROR = 517,
        XML_DTD_MISSING_ATTRIBUTE = 518,
        XML_DTD_MIXED_CORRUPT = 519,
        XML_DTD_MULTIPLE_ID = 520,
        XML_DTD_NO_DOC = 521,
        XML_DTD_NO_DTD = 522,
        XML_DTD_NO_ELEM_NAME = 523,
        XML_DTD_NO_PREFIX = 524,
        XML_DTD_NO_ROOT = 525,
        XML_DTD_NOTATION_REDEFINED = 526,
        XML_DTD_NOTATION_VALUE = 527,
        XML_DTD_NOT_EMPTY = 528,
        XML_DTD_NOT_PCDATA = 529,
        XML_DTD_NOT_STANDALONE = 530,
        XML_DTD_ROOT_NAME = 531,
        XML_DTD_STANDALONE_WHITE_SPACE = 532,
        XML_DTD_UNKNOWN_ATTRIBUTE = 533,
        XML_DTD_UNKNOWN_ELEM = 534,
        XML_DTD_UNKNOWN_ENTITY = 535,
        XML_DTD_UNKNOWN_ID = 536,
        XML_DTD_UNKNOWN_NOTATION = 537,
        XML_DTD_STANDALONE_DEFAULTED = 538,
        XML_DTD_XMLID_VALUE = 539,
        XML_DTD_XMLID_TYPE = 540,
        XML_DTD_DUP_TOKEN = 541,
        XML_HTML_STRUCURE_ERROR = 800,
        XML_HTML_UNKNOWN_TAG = 801,
        XML_RNGP_ANYNAME_ATTR_ANCESTOR = 1000,
        XML_RNGP_ATTR_CONFLICT = 1001,
        XML_RNGP_ATTRIBUTE_CHILDREN = 1002,
        XML_RNGP_ATTRIBUTE_CONTENT = 1003,
        XML_RNGP_ATTRIBUTE_EMPTY = 1004,
        XML_RNGP_ATTRIBUTE_NOOP = 1005,
        XML_RNGP_CHOICE_CONTENT = 1006,
        XML_RNGP_CHOICE_EMPTY = 1007,
        XML_RNGP_CREATE_FAILURE = 1008,
        XML_RNGP_DATA_CONTENT = 1009,
        XML_RNGP_DEF_CHOICE_AND_INTERLEAVE = 1010,
        XML_RNGP_DEFINE_CREATE_FAILED = 1011,
        XML_RNGP_DEFINE_EMPTY = 1012,
        XML_RNGP_DEFINE_MISSING = 1013,
        XML_RNGP_DEFINE_NAME_MISSING = 1014,
        XML_RNGP_ELEM_CONTENT_EMPTY = 1015,
        XML_RNGP_ELEM_CONTENT_ERROR = 1016,
        XML_RNGP_ELEMENT_EMPTY = 1017,
        XML_RNGP_ELEMENT_CONTENT = 1018,
        XML_RNGP_ELEMENT_NAME = 1019,
        XML_RNGP_ELEMENT_NO_CONTENT = 1020,
        XML_RNGP_ELEM_TEXT_CONFLICT = 1021,
        XML_RNGP_EMPTY = 1022,
        XML_RNGP_EMPTY_CONSTRUCT = 1023,
        XML_RNGP_EMPTY_CONTENT = 1024,
        XML_RNGP_EMPTY_NOT_EMPTY = 1025,
        XML_RNGP_ERROR_TYPE_LIB = 1026,
        XML_RNGP_EXCEPT_EMPTY = 1027,
        XML_RNGP_EXCEPT_MISSING = 1028,
        XML_RNGP_EXCEPT_MULTIPLE = 1029,
        XML_RNGP_EXCEPT_NO_CONTENT = 1030,
        XML_RNGP_EXTERNALREF_EMTPY = 1031,
        XML_RNGP_EXTERNAL_REF_FAILURE = 1032,
        XML_RNGP_EXTERNALREF_RECURSE = 1033,
        XML_RNGP_FORBIDDEN_ATTRIBUTE = 1034,
        XML_RNGP_FOREIGN_ELEMENT = 1035,
        XML_RNGP_GRAMMAR_CONTENT = 1036,
        XML_RNGP_GRAMMAR_EMPTY = 1037,
        XML_RNGP_GRAMMAR_MISSING = 1038,
        XML_RNGP_GRAMMAR_NO_START = 1039,
        XML_RNGP_GROUP_ATTR_CONFLICT = 1040,
        XML_RNGP_HREF_ERROR = 1041,
        XML_RNGP_INCLUDE_EMPTY = 1042,
        XML_RNGP_INCLUDE_FAILURE = 1043,
        XML_RNGP_INCLUDE_RECURSE = 1044,
        XML_RNGP_INTERLEAVE_ADD = 1045,
        XML_RNGP_INTERLEAVE_CREATE_FAILED = 1046,
        XML_RNGP_INTERLEAVE_EMPTY = 1047,
        XML_RNGP_INTERLEAVE_NO_CONTENT = 1048,
        XML_RNGP_INVALID_DEFINE_NAME = 1049,
        XML_RNGP_INVALID_URI = 1050,
        XML_RNGP_INVALID_VALUE = 1051,
        XML_RNGP_MISSING_HREF = 1052,
        XML_RNGP_NAME_MISSING = 1053,
        XML_RNGP_NEED_COMBINE = 1054,
        XML_RNGP_NOTALLOWED_NOT_EMPTY = 1055,
        XML_RNGP_NSNAME_ATTR_ANCESTOR = 1056,
        XML_RNGP_NSNAME_NO_NS = 1057,
        XML_RNGP_PARAM_FORBIDDEN = 1058,
        XML_RNGP_PARAM_NAME_MISSING = 1059,
        XML_RNGP_PARENTREF_CREATE_FAILED = 1060,
        XML_RNGP_PARENTREF_NAME_INVALID = 1061,
        XML_RNGP_PARENTREF_NO_NAME = 1062,
        XML_RNGP_PARENTREF_NO_PARENT = 1063,
        XML_RNGP_PARENTREF_NOT_EMPTY = 1064,
        XML_RNGP_PARSE_ERROR = 1065,
        XML_RNGP_PAT_ANYNAME_EXCEPT_ANYNAME = 1066,
        XML_RNGP_PAT_ATTR_ATTR = 1067,
        XML_RNGP_PAT_ATTR_ELEM = 1068,
        XML_RNGP_PAT_DATA_EXCEPT_ATTR = 1069,
        XML_RNGP_PAT_DATA_EXCEPT_ELEM = 1070,
        XML_RNGP_PAT_DATA_EXCEPT_EMPTY = 1071,
        XML_RNGP_PAT_DATA_EXCEPT_GROUP = 1072,
        XML_RNGP_PAT_DATA_EXCEPT_INTERLEAVE = 1073,
        XML_RNGP_PAT_DATA_EXCEPT_LIST = 1074,
        XML_RNGP_PAT_DATA_EXCEPT_ONEMORE = 1075,
        XML_RNGP_PAT_DATA_EXCEPT_REF = 1076,
        XML_RNGP_PAT_DATA_EXCEPT_TEXT = 1077,
        XML_RNGP_PAT_LIST_ATTR = 1078,
        XML_RNGP_PAT_LIST_ELEM = 1079,
        XML_RNGP_PAT_LIST_INTERLEAVE = 1080,
        XML_RNGP_PAT_LIST_LIST = 1081,
        XML_RNGP_PAT_LIST_REF = 1082,
        XML_RNGP_PAT_LIST_TEXT = 1083,
        XML_RNGP_PAT_NSNAME_EXCEPT_ANYNAME = 1084,
        XML_RNGP_PAT_NSNAME_EXCEPT_NSNAME = 1085,
        XML_RNGP_PAT_ONEMORE_GROUP_ATTR = 1086,
        XML_RNGP_PAT_ONEMORE_INTERLEAVE_ATTR = 1087,
        XML_RNGP_PAT_START_ATTR = 1088,
        XML_RNGP_PAT_START_DATA = 1089,
        XML_RNGP_PAT_START_EMPTY = 1090,
        XML_RNGP_PAT_START_GROUP = 1091,
        XML_RNGP_PAT_START_INTERLEAVE = 1092,
        XML_RNGP_PAT_START_LIST = 1093,
        XML_RNGP_PAT_START_ONEMORE = 1094,
        XML_RNGP_PAT_START_TEXT = 1095,
        XML_RNGP_PAT_START_VALUE = 1096,
        XML_RNGP_PREFIX_UNDEFINED = 1097,
        XML_RNGP_REF_CREATE_FAILED = 1098,
        XML_RNGP_REF_CYCLE = 1099,
        XML_RNGP_REF_NAME_INVALID = 1100,
        XML_RNGP_REF_NO_DEF = 1101,
        XML_RNGP_REF_NO_NAME = 1102,
        XML_RNGP_REF_NOT_EMPTY = 1103,
        XML_RNGP_START_CHOICE_AND_INTERLEAVE = 1104,
        XML_RNGP_START_CONTENT = 1105,
        XML_RNGP_START_EMPTY = 1106,
        XML_RNGP_START_MISSING = 1107,
        XML_RNGP_TEXT_EXPECTED = 1108,
        XML_RNGP_TEXT_HAS_CHILD = 1109,
        XML_RNGP_TYPE_MISSING = 1110,
        XML_RNGP_TYPE_NOT_FOUND = 1111,
        XML_RNGP_TYPE_VALUE = 1112,
        XML_RNGP_UNKNOWN_ATTRIBUTE = 1113,
        XML_RNGP_UNKNOWN_COMBINE = 1114,
        XML_RNGP_UNKNOWN_CONSTRUCT = 1115,
        XML_RNGP_UNKNOWN_TYPE_LIB = 1116,
        XML_RNGP_URI_FRAGMENT = 1117,
        XML_RNGP_URI_NOT_ABSOLUTE = 1118,
        XML_RNGP_VALUE_EMPTY = 1119,
        XML_RNGP_VALUE_NO_CONTENT = 1120,
        XML_RNGP_XMLNS_NAME = 1121,
        XML_RNGP_XML_NS = 1122,
        XML_XPATH_EXPRESSION_OK = 1200,
        XML_XPATH_NUMBER_ERROR = 1201,
        XML_XPATH_UNFINISHED_LITERAL_ERROR = 1202,
        XML_XPATH_START_LITERAL_ERROR = 1203,
        XML_XPATH_VARIABLE_REF_ERROR = 1204,
        XML_XPATH_UNDEF_VARIABLE_ERROR = 1205,
        XML_XPATH_INVALID_PREDICATE_ERROR = 1206,
        XML_XPATH_EXPR_ERROR = 1207,
        XML_XPATH_UNCLOSED_ERROR = 1208,
        XML_XPATH_UNKNOWN_FUNC_ERROR = 1209,
        XML_XPATH_INVALID_OPERAND = 1210,
        XML_XPATH_INVALID_TYPE = 1211,
        XML_XPATH_INVALID_ARITY = 1212,
        XML_XPATH_INVALID_CTXT_SIZE = 1213,
        XML_XPATH_INVALID_CTXT_POSITION = 1214,
        XML_XPATH_MEMORY_ERROR = 1215,
        XML_XPTR_SYNTAX_ERROR = 1216,
        XML_XPTR_RESOURCE_ERROR = 1217,
        XML_XPTR_SUB_RESOURCE_ERROR = 1218,
        XML_XPATH_UNDEF_PREFIX_ERROR = 1219,
        XML_XPATH_ENCODING_ERROR = 1220,
        XML_XPATH_INVALID_CHAR_ERROR = 1221,
        XML_TREE_INVALID_HEX = 1300,
        XML_TREE_INVALID_DEC = 1301,
        XML_TREE_UNTERMINATED_ENTITY = 1302,
        XML_TREE_NOT_UTF8 = 1303,
        XML_SAVE_NOT_UTF8 = 1400,
        XML_SAVE_CHAR_INVALID = 1401,
        XML_SAVE_NO_DOCTYPE = 1402,
        XML_SAVE_UNKNOWN_ENCODING = 1403,
        XML_REGEXP_COMPILE_ERROR = 1450,
        XML_IO_UNKNOWN = 1500,
        XML_IO_EACCES = 1501,
        XML_IO_EAGAIN = 1502,
        XML_IO_EBADF = 1503,
        XML_IO_EBADMSG = 1504,
        XML_IO_EBUSY = 1505,
        XML_IO_ECANCELED = 1506,
        XML_IO_ECHILD = 1507,
        XML_IO_EDEADLK = 1508,
        XML_IO_EDOM = 1509,
        XML_IO_EEXIST = 1510,
        XML_IO_EFAULT = 1511,
        XML_IO_EFBIG = 1512,
        XML_IO_EINPROGRESS = 1513,
        XML_IO_EINTR = 1514,
        XML_IO_EINVAL = 1515,
        XML_IO_EIO = 1516,
        XML_IO_EISDIR = 1517,
        XML_IO_EMFILE = 1518,
        XML_IO_EMLINK = 1519,
        XML_IO_EMSGSIZE = 1520,
        XML_IO_ENAMETOOLONG = 1521,
        XML_IO_ENFILE = 1522,
        XML_IO_ENODEV = 1523,
        XML_IO_ENOENT = 1524,
        XML_IO_ENOEXEC = 1525,
        XML_IO_ENOLCK = 1526,
        XML_IO_ENOMEM = 1527,
        XML_IO_ENOSPC = 1528,
        XML_IO_ENOSYS = 1529,
        XML_IO_ENOTDIR = 1530,
        XML_IO_ENOTEMPTY = 1531,
        XML_IO_ENOTSUP = 1532,
        XML_IO_ENOTTY = 1533,
        XML_IO_ENXIO = 1534,
        XML_IO_EPERM = 1535,
        XML_IO_EPIPE = 1536,
        XML_IO_ERANGE = 1537,
        XML_IO_EROFS = 1538,
        XML_IO_ESPIPE = 1539,
        XML_IO_ESRCH = 1540,
        XML_IO_ETIMEDOUT = 1541,
        XML_IO_EXDEV = 1542,
        XML_IO_NETWORK_ATTEMPT = 1543,
        XML_IO_ENCODER = 1544,
        XML_IO_FLUSH = 1545,
        XML_IO_WRITE = 1546,
        XML_IO_NO_INPUT = 1547,
        XML_IO_BUFFER_FULL = 1548,
        XML_IO_LOAD_ERROR = 1549,
        XML_IO_ENOTSOCK = 1550,
        XML_IO_EISCONN = 1551,
        XML_IO_ECONNREFUSED = 1552,
        XML_IO_ENETUNREACH = 1553,
        XML_IO_EADDRINUSE = 1554,
        XML_IO_EALREADY = 1555,
        XML_IO_EAFNOSUPPORT = 1556,
        XML_XINCLUDE_RECURSION = 1600,
        XML_XINCLUDE_PARSE_VALUE = 1601,
        XML_XINCLUDE_ENTITY_DEF_MISMATCH = 1602,
        XML_XINCLUDE_NO_HREF = 1603,
        XML_XINCLUDE_NO_FALLBACK = 1604,
        XML_XINCLUDE_HREF_URI = 1605,
        XML_XINCLUDE_TEXT_FRAGMENT = 1606,
        XML_XINCLUDE_TEXT_DOCUMENT = 1607,
        XML_XINCLUDE_INVALID_CHAR = 1608,
        XML_XINCLUDE_BUILD_FAILED = 1609,
        XML_XINCLUDE_UNKNOWN_ENCODING = 1610,
        XML_XINCLUDE_MULTIPLE_ROOT = 1611,
        XML_XINCLUDE_XPTR_FAILED = 1612,
        XML_XINCLUDE_XPTR_RESULT = 1613,
        XML_XINCLUDE_INCLUDE_IN_INCLUDE = 1614,
        XML_XINCLUDE_FALLBACKS_IN_INCLUDE = 1615,
        XML_XINCLUDE_FALLBACK_NOT_IN_INCLUDE = 1616,
        XML_XINCLUDE_DEPRECATED_NS = 1617,
        XML_XINCLUDE_FRAGMENT_ID = 1618,
        XML_CATALOG_MISSING_ATTR = 1650,
        XML_CATALOG_ENTRY_BROKEN = 1651,
        XML_CATALOG_PREFER_VALUE = 1652,
        XML_CATALOG_NOT_CATALOG = 1653,
        XML_CATALOG_RECURSION = 1654,
        XML_SCHEMAP_PREFIX_UNDEFINED = 1700,
        XML_SCHEMAP_ATTRFORMDEFAULT_VALUE = 1701,
        XML_SCHEMAP_ATTRGRP_NONAME_NOREF = 1702,
        XML_SCHEMAP_ATTR_NONAME_NOREF = 1703,
        XML_SCHEMAP_COMPLEXTYPE_NONAME_NOREF = 1704,
        XML_SCHEMAP_ELEMFORMDEFAULT_VALUE = 1705,
        XML_SCHEMAP_ELEM_NONAME_NOREF = 1706,
        XML_SCHEMAP_EXTENSION_NO_BASE = 1707,
        XML_SCHEMAP_FACET_NO_VALUE = 1708,
        XML_SCHEMAP_FAILED_BUILD_IMPORT = 1709,
        XML_SCHEMAP_GROUP_NONAME_NOREF = 1710,
        XML_SCHEMAP_IMPORT_NAMESPACE_NOT_URI = 1711,
        XML_SCHEMAP_IMPORT_REDEFINE_NSNAME = 1712,
        XML_SCHEMAP_IMPORT_SCHEMA_NOT_URI = 1713,
        XML_SCHEMAP_INVALID_BOOLEAN = 1714,
        XML_SCHEMAP_INVALID_ENUM = 1715,
        XML_SCHEMAP_INVALID_FACET = 1716,
        XML_SCHEMAP_INVALID_FACET_VALUE = 1717,
        XML_SCHEMAP_INVALID_MAXOCCURS = 1718,
        XML_SCHEMAP_INVALID_MINOCCURS = 1719,
        XML_SCHEMAP_INVALID_REF_AND_SUBTYPE = 1720,
        XML_SCHEMAP_INVALID_WHITE_SPACE = 1721,
        XML_SCHEMAP_NOATTR_NOREF = 1722,
        XML_SCHEMAP_NOTATION_NO_NAME = 1723,
        XML_SCHEMAP_NOTYPE_NOREF = 1724,
        XML_SCHEMAP_REF_AND_SUBTYPE = 1725,
        XML_SCHEMAP_RESTRICTION_NONAME_NOREF = 1726,
        XML_SCHEMAP_SIMPLETYPE_NONAME = 1727,
        XML_SCHEMAP_TYPE_AND_SUBTYPE = 1728,
        XML_SCHEMAP_UNKNOWN_ALL_CHILD = 1729,
        XML_SCHEMAP_UNKNOWN_ANYATTRIBUTE_CHILD = 1730,
        XML_SCHEMAP_UNKNOWN_ATTR_CHILD = 1731,
        XML_SCHEMAP_UNKNOWN_ATTRGRP_CHILD = 1732,
        XML_SCHEMAP_UNKNOWN_ATTRIBUTE_GROUP = 1733,
        XML_SCHEMAP_UNKNOWN_BASE_TYPE = 1734,
        XML_SCHEMAP_UNKNOWN_CHOICE_CHILD = 1735,
        XML_SCHEMAP_UNKNOWN_COMPLEXCONTENT_CHILD = 1736,
        XML_SCHEMAP_UNKNOWN_COMPLEXTYPE_CHILD = 1737,
        XML_SCHEMAP_UNKNOWN_ELEM_CHILD = 1738,
        XML_SCHEMAP_UNKNOWN_EXTENSION_CHILD = 1739,
        XML_SCHEMAP_UNKNOWN_FACET_CHILD = 1740,
        XML_SCHEMAP_UNKNOWN_FACET_TYPE = 1741,
        XML_SCHEMAP_UNKNOWN_GROUP_CHILD = 1742,
        XML_SCHEMAP_UNKNOWN_IMPORT_CHILD = 1743,
        XML_SCHEMAP_UNKNOWN_LIST_CHILD = 1744,
        XML_SCHEMAP_UNKNOWN_NOTATION_CHILD = 1745,
        XML_SCHEMAP_UNKNOWN_PROCESSCONTENT_CHILD = 1746,
        XML_SCHEMAP_UNKNOWN_REF = 1747,
        XML_SCHEMAP_UNKNOWN_RESTRICTION_CHILD = 1748,
        XML_SCHEMAP_UNKNOWN_SCHEMAS_CHILD = 1749,
        XML_SCHEMAP_UNKNOWN_SEQUENCE_CHILD = 1750,
        XML_SCHEMAP_UNKNOWN_SIMPLECONTENT_CHILD = 1751,
        XML_SCHEMAP_UNKNOWN_SIMPLETYPE_CHILD = 1752,
        XML_SCHEMAP_UNKNOWN_TYPE = 1753,
        XML_SCHEMAP_UNKNOWN_UNION_CHILD = 1754,
        XML_SCHEMAP_ELEM_DEFAULT_FIXED = 1755,
        XML_SCHEMAP_REGEXP_INVALID = 1756,
        XML_SCHEMAP_FAILED_LOAD = 1757,
        XML_SCHEMAP_NOTHING_TO_PARSE = 1758,
        XML_SCHEMAP_NOROOT = 1759,
        XML_SCHEMAP_REDEFINED_GROUP = 1760,
        XML_SCHEMAP_REDEFINED_TYPE = 1761,
        XML_SCHEMAP_REDEFINED_ELEMENT = 1762,
        XML_SCHEMAP_REDEFINED_ATTRGROUP = 1763,
        XML_SCHEMAP_REDEFINED_ATTR = 1764,
        XML_SCHEMAP_REDEFINED_NOTATION = 1765,
        XML_SCHEMAP_FAILED_PARSE = 1766,
        XML_SCHEMAP_UNKNOWN_PREFIX = 1767,
        XML_SCHEMAP_DEF_AND_PREFIX = 1768,
        XML_SCHEMAP_UNKNOWN_INCLUDE_CHILD = 1769,
        XML_SCHEMAP_INCLUDE_SCHEMA_NOT_URI = 1770,
        XML_SCHEMAP_INCLUDE_SCHEMA_NO_URI = 1771,
        XML_SCHEMAP_NOT_SCHEMA = 1772,
        XML_SCHEMAP_UNKNOWN_MEMBER_TYPE = 1773,
        XML_SCHEMAP_INVALID_ATTR_USE = 1774,
        XML_SCHEMAP_RECURSIVE = 1775,
        XML_SCHEMAP_SUPERNUMEROUS_LIST_ITEM_TYPE = 1776,
        XML_SCHEMAP_INVALID_ATTR_COMBINATION = 1777,
        XML_SCHEMAP_INVALID_ATTR_INLINE_COMBINATION = 1778,
        XML_SCHEMAP_MISSING_SIMPLETYPE_CHILD = 1779,
        XML_SCHEMAP_INVALID_ATTR_NAME = 1780,
        XML_SCHEMAP_REF_AND_CONTENT = 1781,
        XML_SCHEMAP_CT_PROPS_CORRECT_1 = 1782,
        XML_SCHEMAP_CT_PROPS_CORRECT_2 = 1783,
        XML_SCHEMAP_CT_PROPS_CORRECT_3 = 1784,
        XML_SCHEMAP_CT_PROPS_CORRECT_4 = 1785,
        XML_SCHEMAP_CT_PROPS_CORRECT_5 = 1786,
        XML_SCHEMAP_DERIVATION_OK_RESTRICTION_1 = 1787,
        XML_SCHEMAP_DERIVATION_OK_RESTRICTION_2_1_1 = 1788,
        XML_SCHEMAP_DERIVATION_OK_RESTRICTION_2_1_2 = 1789,
        XML_SCHEMAP_DERIVATION_OK_RESTRICTION_2_2 = 1790,
        XML_SCHEMAP_DERIVATION_OK_RESTRICTION_3 = 1791,
        XML_SCHEMAP_WILDCARD_INVALID_NS_MEMBER = 1792,
        XML_SCHEMAP_INTERSECTION_NOT_EXPRESSIBLE = 1793,
        XML_SCHEMAP_UNION_NOT_EXPRESSIBLE = 1794,
        XML_SCHEMAP_SRC_IMPORT_3_1 = 1795,
        XML_SCHEMAP_SRC_IMPORT_3_2 = 1796,
        XML_SCHEMAP_DERIVATION_OK_RESTRICTION_4_1 = 1797,
        XML_SCHEMAP_DERIVATION_OK_RESTRICTION_4_2 = 1798,
        XML_SCHEMAP_DERIVATION_OK_RESTRICTION_4_3 = 1799,
        XML_SCHEMAP_COS_CT_EXTENDS_1_3 = 1800,
        XML_SCHEMAV_NOROOT = 1801,
        XML_SCHEMAV_UNDECLAREDELEM = 1802,
        XML_SCHEMAV_NOTTOPLEVEL = 1803,
        XML_SCHEMAV_MISSING = 1804,
        XML_SCHEMAV_WRONGELEM = 1805,
        XML_SCHEMAV_NOTYPE = 1806,
        XML_SCHEMAV_NOROLLBACK = 1807,
        XML_SCHEMAV_ISABSTRACT = 1808,
        XML_SCHEMAV_NOTEMPTY = 1809,
        XML_SCHEMAV_ELEMCONT = 1810,
        XML_SCHEMAV_HAVEDEFAULT = 1811,
        XML_SCHEMAV_NOTNILLABLE = 1812,
        XML_SCHEMAV_EXTRACONTENT = 1813,
        XML_SCHEMAV_INVALIDATTR = 1814,
        XML_SCHEMAV_INVALIDELEM = 1815,
        XML_SCHEMAV_NOTDETERMINIST = 1816,
        XML_SCHEMAV_CONSTRUCT = 1817,
        XML_SCHEMAV_INTERNAL = 1818,
        XML_SCHEMAV_NOTSIMPLE = 1819,
        XML_SCHEMAV_ATTRUNKNOWN = 1820,
        XML_SCHEMAV_ATTRINVALID = 1821,
        XML_SCHEMAV_VALUE = 1822,
        XML_SCHEMAV_FACET = 1823,
        XML_SCHEMAV_CVC_DATATYPE_VALID_1_2_1 = 1824,
        XML_SCHEMAV_CVC_DATATYPE_VALID_1_2_2 = 1825,
        XML_SCHEMAV_CVC_DATATYPE_VALID_1_2_3 = 1826,
        XML_SCHEMAV_CVC_TYPE_3_1_1 = 1827,
        XML_SCHEMAV_CVC_TYPE_3_1_2 = 1828,
        XML_SCHEMAV_CVC_FACET_VALID = 1829,
        XML_SCHEMAV_CVC_LENGTH_VALID = 1830,
        XML_SCHEMAV_CVC_MINLENGTH_VALID = 1831,
        XML_SCHEMAV_CVC_MAXLENGTH_VALID = 1832,
        XML_SCHEMAV_CVC_MININCLUSIVE_VALID = 1833,
        XML_SCHEMAV_CVC_MAXINCLUSIVE_VALID = 1834,
        XML_SCHEMAV_CVC_MINEXCLUSIVE_VALID = 1835,
        XML_SCHEMAV_CVC_MAXEXCLUSIVE_VALID = 1836,
        XML_SCHEMAV_CVC_TOTALDIGITS_VALID = 1837,
        XML_SCHEMAV_CVC_FRACTIONDIGITS_VALID = 1838,
        XML_SCHEMAV_CVC_PATTERN_VALID = 1839,
        XML_SCHEMAV_CVC_ENUMERATION_VALID = 1840,
        XML_SCHEMAV_CVC_COMPLEX_TYPE_2_1 = 1841,
        XML_SCHEMAV_CVC_COMPLEX_TYPE_2_2 = 1842,
        XML_SCHEMAV_CVC_COMPLEX_TYPE_2_3 = 1843,
        XML_SCHEMAV_CVC_COMPLEX_TYPE_2_4 = 1844,
        XML_SCHEMAV_CVC_ELT_1 = 1845,
        XML_SCHEMAV_CVC_ELT_2 = 1846,
        XML_SCHEMAV_CVC_ELT_3_1 = 1847,
        XML_SCHEMAV_CVC_ELT_3_2_1 = 1848,
        XML_SCHEMAV_CVC_ELT_3_2_2 = 1849,
        XML_SCHEMAV_CVC_ELT_4_1 = 1850,
        XML_SCHEMAV_CVC_ELT_4_2 = 1851,
        XML_SCHEMAV_CVC_ELT_4_3 = 1852,
        XML_SCHEMAV_CVC_ELT_5_1_1 = 1853,
        XML_SCHEMAV_CVC_ELT_5_1_2 = 1854,
        XML_SCHEMAV_CVC_ELT_5_2_1 = 1855,
        XML_SCHEMAV_CVC_ELT_5_2_2_1 = 1856,
        XML_SCHEMAV_CVC_ELT_5_2_2_2_1 = 1857,
        XML_SCHEMAV_CVC_ELT_5_2_2_2_2 = 1858,
        XML_SCHEMAV_CVC_ELT_6 = 1859,
        XML_SCHEMAV_CVC_ELT_7 = 1860,
        XML_SCHEMAV_CVC_ATTRIBUTE_1 = 1861,
        XML_SCHEMAV_CVC_ATTRIBUTE_2 = 1862,
        XML_SCHEMAV_CVC_ATTRIBUTE_3 = 1863,
        XML_SCHEMAV_CVC_ATTRIBUTE_4 = 1864,
        XML_SCHEMAV_CVC_COMPLEX_TYPE_3_1 = 1865,
        XML_SCHEMAV_CVC_COMPLEX_TYPE_3_2_1 = 1866,
        XML_SCHEMAV_CVC_COMPLEX_TYPE_3_2_2 = 1867,
        XML_SCHEMAV_CVC_COMPLEX_TYPE_4 = 1868,
        XML_SCHEMAV_CVC_COMPLEX_TYPE_5_1 = 1869,
        XML_SCHEMAV_CVC_COMPLEX_TYPE_5_2 = 1870,
        XML_SCHEMAV_ELEMENT_CONTENT = 1871,
        XML_SCHEMAV_DOCUMENT_ELEMENT_MISSING = 1872,
        XML_SCHEMAV_CVC_COMPLEX_TYPE_1 = 1873,
        XML_SCHEMAV_CVC_AU = 1874,
        XML_SCHEMAV_CVC_TYPE_1 = 1875,
        XML_SCHEMAV_CVC_TYPE_2 = 1876,
        XML_SCHEMAV_CVC_IDC = 1877,
        XML_SCHEMAV_CVC_WILDCARD = 1878,
        XML_SCHEMAV_MISC = 1879,
        XML_XPTR_UNKNOWN_SCHEME = 1900,
        XML_XPTR_CHILDSEQ_START = 1901,
        XML_XPTR_EVAL_FAILED = 1902,
        XML_XPTR_EXTRA_OBJECTS = 1903,
        XML_C14N_CREATE_CTXT = 1950,
        XML_C14N_REQUIRES_UTF8 = 1951,
        XML_C14N_CREATE_STACK = 1952,
        XML_C14N_INVALID_NODE = 1953,
        XML_C14N_UNKNOW_NODE = 1954,
        XML_C14N_RELATIVE_NAMESPACE = 1955,
        XML_FTP_PASV_ANSWER = 2000,
        XML_FTP_EPSV_ANSWER = 2001,
        XML_FTP_ACCNT = 2002,
        XML_FTP_URL_SYNTAX = 2003,
        XML_HTTP_URL_SYNTAX = 2020,
        XML_HTTP_USE_IP = 2021,
        XML_HTTP_UNKNOWN_HOST = 2022,
        XML_SCHEMAP_SRC_SIMPLE_TYPE_1 = 3000,
        XML_SCHEMAP_SRC_SIMPLE_TYPE_2 = 3001,
        XML_SCHEMAP_SRC_SIMPLE_TYPE_3 = 3002,
        XML_SCHEMAP_SRC_SIMPLE_TYPE_4 = 3003,
        XML_SCHEMAP_SRC_RESOLVE = 3004,
        XML_SCHEMAP_SRC_RESTRICTION_BASE_OR_SIMPLETYPE = 3005,
        XML_SCHEMAP_SRC_LIST_ITEMTYPE_OR_SIMPLETYPE = 3006,
        XML_SCHEMAP_SRC_UNION_MEMBERTYPES_OR_SIMPLETYPES = 3007,
        XML_SCHEMAP_ST_PROPS_CORRECT_1 = 3008,
        XML_SCHEMAP_ST_PROPS_CORRECT_2 = 3009,
        XML_SCHEMAP_ST_PROPS_CORRECT_3 = 3010,
        XML_SCHEMAP_COS_ST_RESTRICTS_1_1 = 3011,
        XML_SCHEMAP_COS_ST_RESTRICTS_1_2 = 3012,
        XML_SCHEMAP_COS_ST_RESTRICTS_1_3_1 = 3013,
        XML_SCHEMAP_COS_ST_RESTRICTS_1_3_2 = 3014,
        XML_SCHEMAP_COS_ST_RESTRICTS_2_1 = 3015,
        XML_SCHEMAP_COS_ST_RESTRICTS_2_3_1_1 = 3016,
        XML_SCHEMAP_COS_ST_RESTRICTS_2_3_1_2 = 3017,
        XML_SCHEMAP_COS_ST_RESTRICTS_2_3_2_1 = 3018,
        XML_SCHEMAP_COS_ST_RESTRICTS_2_3_2_2 = 3019,
        XML_SCHEMAP_COS_ST_RESTRICTS_2_3_2_3 = 3020,
        XML_SCHEMAP_COS_ST_RESTRICTS_2_3_2_4 = 3021,
        XML_SCHEMAP_COS_ST_RESTRICTS_2_3_2_5 = 3022,
        XML_SCHEMAP_COS_ST_RESTRICTS_3_1 = 3023,
        XML_SCHEMAP_COS_ST_RESTRICTS_3_3_1 = 3024,
        XML_SCHEMAP_COS_ST_RESTRICTS_3_3_1_2 = 3025,
        XML_SCHEMAP_COS_ST_RESTRICTS_3_3_2_2 = 3026,
        XML_SCHEMAP_COS_ST_RESTRICTS_3_3_2_1 = 3027,
        XML_SCHEMAP_COS_ST_RESTRICTS_3_3_2_3 = 3028,
        XML_SCHEMAP_COS_ST_RESTRICTS_3_3_2_4 = 3029,
        XML_SCHEMAP_COS_ST_RESTRICTS_3_3_2_5 = 3030,
        XML_SCHEMAP_COS_ST_DERIVED_OK_2_1 = 3031,
        XML_SCHEMAP_COS_ST_DERIVED_OK_2_2 = 3032,
        XML_SCHEMAP_S4S_ELEM_NOT_ALLOWED = 3033,
        XML_SCHEMAP_S4S_ELEM_MISSING = 3034,
        XML_SCHEMAP_S4S_ATTR_NOT_ALLOWED = 3035,
        XML_SCHEMAP_S4S_ATTR_MISSING = 3036,
        XML_SCHEMAP_S4S_ATTR_INVALID_VALUE = 3037,
        XML_SCHEMAP_SRC_ELEMENT_1 = 3038,
        XML_SCHEMAP_SRC_ELEMENT_2_1 = 3039,
        XML_SCHEMAP_SRC_ELEMENT_2_2 = 3040,
        XML_SCHEMAP_SRC_ELEMENT_3 = 3041,
        XML_SCHEMAP_P_PROPS_CORRECT_1 = 3042,
        XML_SCHEMAP_P_PROPS_CORRECT_2_1 = 3043,
        XML_SCHEMAP_P_PROPS_CORRECT_2_2 = 3044,
        XML_SCHEMAP_E_PROPS_CORRECT_2 = 3045,
        XML_SCHEMAP_E_PROPS_CORRECT_3 = 3046,
        XML_SCHEMAP_E_PROPS_CORRECT_4 = 3047,
        XML_SCHEMAP_E_PROPS_CORRECT_5 = 3048,
        XML_SCHEMAP_E_PROPS_CORRECT_6 = 3049,
        XML_SCHEMAP_SRC_INCLUDE = 3050,
        XML_SCHEMAP_SRC_ATTRIBUTE_1 = 3051,
        XML_SCHEMAP_SRC_ATTRIBUTE_2 = 3052,
        XML_SCHEMAP_SRC_ATTRIBUTE_3_1 = 3053,
        XML_SCHEMAP_SRC_ATTRIBUTE_3_2 = 3054,
        XML_SCHEMAP_SRC_ATTRIBUTE_4 = 3055,
        XML_SCHEMAP_NO_XMLNS = 3056,
        XML_SCHEMAP_NO_XSI = 3057,
        XML_SCHEMAP_COS_VALID_DEFAULT_1 = 3058,
        XML_SCHEMAP_COS_VALID_DEFAULT_2_1 = 3059,
        XML_SCHEMAP_COS_VALID_DEFAULT_2_2_1 = 3060,
        XML_SCHEMAP_COS_VALID_DEFAULT_2_2_2 = 3061,
        XML_SCHEMAP_CVC_SIMPLE_TYPE = 3062,
        XML_SCHEMAP_COS_CT_EXTENDS_1_1 = 3063,
        XML_SCHEMAP_SRC_IMPORT_1_1 = 3064,
        XML_SCHEMAP_SRC_IMPORT_1_2 = 3065,
        XML_SCHEMAP_SRC_IMPORT_2 = 3066,
        XML_SCHEMAP_SRC_IMPORT_2_1 = 3067,
        XML_SCHEMAP_SRC_IMPORT_2_2 = 3068,
        XML_SCHEMAP_INTERNAL = 3069,
        XML_SCHEMAP_NOT_DETERMINISTIC = 3070,
        XML_SCHEMAP_SRC_ATTRIBUTE_GROUP_1 = 3071,
        XML_SCHEMAP_SRC_ATTRIBUTE_GROUP_2 = 3072,
        XML_SCHEMAP_SRC_ATTRIBUTE_GROUP_3 = 3073,
        XML_SCHEMAP_MG_PROPS_CORRECT_1 = 3074,
        XML_SCHEMAP_MG_PROPS_CORRECT_2 = 3075,
        XML_SCHEMAP_SRC_CT_1 = 3076,
        XML_SCHEMAP_DERIVATION_OK_RESTRICTION_2_1_3 = 3077,
        XML_SCHEMAP_AU_PROPS_CORRECT_2 = 3078,
        XML_SCHEMAP_A_PROPS_CORRECT_2 = 3079,
        XML_SCHEMAP_C_PROPS_CORRECT = 3080,
        XML_SCHEMAP_SRC_REDEFINE = 3081,
        XML_SCHEMAP_SRC_IMPORT = 3082,
        XML_SCHEMAP_WARN_SKIP_SCHEMA = 3083,
        XML_SCHEMAP_WARN_UNLOCATED_SCHEMA = 3084,
        XML_SCHEMAP_WARN_ATTR_REDECL_PROH = 3085,
        XML_SCHEMAP_WARN_ATTR_POINTLESS_PROH = 3086,
        XML_SCHEMAP_AG_PROPS_CORRECT = 3087,
        XML_SCHEMAP_COS_CT_EXTENDS_1_2 = 3088,
        XML_SCHEMAP_AU_PROPS_CORRECT = 3089,
        XML_SCHEMAP_A_PROPS_CORRECT_3 = 3090,
        XML_SCHEMAP_COS_ALL_LIMITED = 3091,
        XML_SCHEMATRONV_ASSERT = 4000,
        XML_SCHEMATRONV_REPORT = 4001,
        XML_MODULE_OPEN = 4900,
        XML_MODULE_CLOSE = 4901,
        XML_CHECK_FOUND_ELEMENT = 5000,
        XML_CHECK_FOUND_ATTRIBUTE = 5001,
        XML_CHECK_FOUND_TEXT = 5002,
        XML_CHECK_FOUND_CDATA = 5003,
        XML_CHECK_FOUND_ENTITYREF = 5004,
        XML_CHECK_FOUND_ENTITY = 5005,
        XML_CHECK_FOUND_PI = 5006,
        XML_CHECK_FOUND_COMMENT = 5007,
        XML_CHECK_FOUND_DOCTYPE = 5008,
        XML_CHECK_FOUND_FRAGMENT = 5009,
        XML_CHECK_FOUND_NOTATION = 5010,
        XML_CHECK_UNKNOWN_NODE = 5011,
        XML_CHECK_ENTITY_TYPE = 5012,
        XML_CHECK_NO_PARENT = 5013,
        XML_CHECK_NO_DOC = 5014,
        XML_CHECK_NO_NAME = 5015,
        XML_CHECK_NO_ELEM = 5016,
        XML_CHECK_WRONG_DOC = 5017,
        XML_CHECK_NO_PREV = 5018,
        XML_CHECK_WRONG_PREV = 5019,
        XML_CHECK_NO_NEXT = 5020,
        XML_CHECK_WRONG_NEXT = 5021,
        XML_CHECK_NOT_DTD = 5022,
        XML_CHECK_NOT_ATTR = 5023,
        XML_CHECK_NOT_ATTR_DECL = 5024,
        XML_CHECK_NOT_ELEM_DECL = 5025,
        XML_CHECK_NOT_ENTITY_DECL = 5026,
        XML_CHECK_NOT_NS_DECL = 5027,
        XML_CHECK_NO_HREF = 5028,
        XML_CHECK_WRONG_PARENT = 5029,
        XML_CHECK_NS_SCOPE = 5030,
        XML_CHECK_NS_ANCESTOR = 5031,
        XML_CHECK_NOT_UTF8 = 5032,
        XML_CHECK_NO_DICT = 5033,
        XML_CHECK_NOT_NCNAME = 5034,
        XML_CHECK_OUTSIDE_DICT = 5035,
        XML_CHECK_WRONG_NAME = 5036,
        XML_CHECK_NAME_NOT_NULL = 5037,
        XML_I18N_NO_NAME = 6000,
        XML_I18N_NO_HANDLER = 6001,
        XML_I18N_EXCESS_HANDLER = 6002,
        XML_I18N_CONV_FAILED = 6003,
        XML_I18N_NO_OUTPUT = 6004,
        XML_BUF_OVERFLOW = 7000
    }

    /// <summary>xmlErrorLevel:</summary>
    /// <remarks>Indicates the level of an error</remarks>
    /// <summary>xmlError:</summary>
    /// <remarks>An XML Error instance.</remarks>
    /// <summary>
    /// <para>xmlStructuredErrorFunc:</para>
    /// <para>user provided data for the error callback</para>
    /// <para>the error being raised.</para>
    /// </summary>
    /// <remarks>
    /// <para>Signature of the function to use when there is an error and</para>
    /// <para>the module handles the new error reporting mechanism.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void XmlStructuredErrorFunc(global::System.IntPtr userData, global::System.IntPtr error);

    /// <summary>xmlErrorDomain:</summary>
    /// <remarks>Indicates where an error may have come from</remarks>
    /// <summary>xmlParserError:</summary>
    /// <remarks>This is an error that the XML (or HTML) parser can generate</remarks>
    /// <summary>
    /// <para>xmlGenericErrorFunc:</para>
    /// <para>a parsing context</para>
    /// </summary>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void XmlGenericErrorFunc(global::System.IntPtr ctx, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

    public unsafe partial class XmlError : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 52)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal int domain;

            [FieldOffset(4)]
            internal int code;

            [FieldOffset(8)]
            internal global::System.IntPtr message;

            [FieldOffset(12)]
            internal global::libxml.XmlErrorLevel level;

            [FieldOffset(16)]
            internal global::System.IntPtr file;

            [FieldOffset(20)]
            internal int line;

            [FieldOffset(24)]
            internal global::System.IntPtr str1;

            [FieldOffset(28)]
            internal global::System.IntPtr str2;

            [FieldOffset(32)]
            internal global::System.IntPtr str3;

            [FieldOffset(36)]
            internal int int1;

            [FieldOffset(40)]
            internal int int2;

            [FieldOffset(44)]
            internal global::System.IntPtr ctxt;

            [FieldOffset(48)]
            internal global::System.IntPtr node;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN9_xmlErrorC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlError> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlError>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlError __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlError(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlError __CreateInstance(global::libxml.XmlError.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlError(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlError.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlError.__Internal));
            *(global::libxml.XmlError.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlError(global::libxml.XmlError.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlError(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlError()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlError.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlError(global::libxml.XmlError _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlError.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlError.__Internal*) __Instance) = *((global::libxml.XmlError.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlError __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public int Domain
        {
            get
            {
                return ((global::libxml.XmlError.__Internal*) __Instance)->domain;
            }

            set
            {
                ((global::libxml.XmlError.__Internal*)__Instance)->domain = value;
            }
        }

        public int Code
        {
            get
            {
                return ((global::libxml.XmlError.__Internal*) __Instance)->code;
            }

            set
            {
                ((global::libxml.XmlError.__Internal*)__Instance)->code = value;
            }
        }

        public sbyte* Message
        {
            get
            {
                return (sbyte*) ((global::libxml.XmlError.__Internal*) __Instance)->message;
            }

            set
            {
                ((global::libxml.XmlError.__Internal*)__Instance)->message = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlErrorLevel Level
        {
            get
            {
                return ((global::libxml.XmlError.__Internal*) __Instance)->level;
            }

            set
            {
                ((global::libxml.XmlError.__Internal*)__Instance)->level = value;
            }
        }

        public sbyte* File
        {
            get
            {
                return (sbyte*) ((global::libxml.XmlError.__Internal*) __Instance)->file;
            }

            set
            {
                ((global::libxml.XmlError.__Internal*)__Instance)->file = (global::System.IntPtr) value;
            }
        }

        public int Line
        {
            get
            {
                return ((global::libxml.XmlError.__Internal*) __Instance)->line;
            }

            set
            {
                ((global::libxml.XmlError.__Internal*)__Instance)->line = value;
            }
        }

        public sbyte* Str1
        {
            get
            {
                return (sbyte*) ((global::libxml.XmlError.__Internal*) __Instance)->str1;
            }

            set
            {
                ((global::libxml.XmlError.__Internal*)__Instance)->str1 = (global::System.IntPtr) value;
            }
        }

        public sbyte* Str2
        {
            get
            {
                return (sbyte*) ((global::libxml.XmlError.__Internal*) __Instance)->str2;
            }

            set
            {
                ((global::libxml.XmlError.__Internal*)__Instance)->str2 = (global::System.IntPtr) value;
            }
        }

        public sbyte* Str3
        {
            get
            {
                return (sbyte*) ((global::libxml.XmlError.__Internal*) __Instance)->str3;
            }

            set
            {
                ((global::libxml.XmlError.__Internal*)__Instance)->str3 = (global::System.IntPtr) value;
            }
        }

        public int Int1
        {
            get
            {
                return ((global::libxml.XmlError.__Internal*) __Instance)->int1;
            }

            set
            {
                ((global::libxml.XmlError.__Internal*)__Instance)->int1 = value;
            }
        }

        public int Int2
        {
            get
            {
                return ((global::libxml.XmlError.__Internal*) __Instance)->int2;
            }

            set
            {
                ((global::libxml.XmlError.__Internal*)__Instance)->int2 = value;
            }
        }

        public global::System.IntPtr Ctxt
        {
            get
            {
                return ((global::libxml.XmlError.__Internal*) __Instance)->ctxt;
            }

            set
            {
                ((global::libxml.XmlError.__Internal*)__Instance)->ctxt = (global::System.IntPtr) value;
            }
        }

        public global::System.IntPtr Node
        {
            get
            {
                return ((global::libxml.XmlError.__Internal*) __Instance)->node;
            }

            set
            {
                ((global::libxml.XmlError.__Internal*)__Instance)->node = (global::System.IntPtr) value;
            }
        }
    }

    public unsafe partial class xmlerror
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSetGenericErrorFunc")]
            internal static extern void XmlSetGenericErrorFunc(global::System.IntPtr ctx, global::System.IntPtr handler);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="initGenericErrorDefaultFunc")]
            internal static extern void InitGenericErrorDefaultFunc(global::System.IntPtr handler);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSetStructuredErrorFunc")]
            internal static extern void XmlSetStructuredErrorFunc(global::System.IntPtr ctx, global::System.IntPtr handler);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParserError")]
            internal static extern void XmlParserError(global::System.IntPtr ctx, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParserWarning")]
            internal static extern void XmlParserWarning(global::System.IntPtr ctx, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParserValidityError")]
            internal static extern void XmlParserValidityError(global::System.IntPtr ctx, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParserValidityWarning")]
            internal static extern void XmlParserValidityWarning(global::System.IntPtr ctx, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParserPrintFileInfo")]
            internal static extern void XmlParserPrintFileInfo(global::System.IntPtr input);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParserPrintFileContext")]
            internal static extern void XmlParserPrintFileContext(global::System.IntPtr input);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetLastError")]
            internal static extern global::System.IntPtr XmlGetLastError();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlResetLastError")]
            internal static extern void XmlResetLastError();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCtxtGetLastError")]
            internal static extern global::System.IntPtr XmlCtxtGetLastError(global::System.IntPtr ctx);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCtxtResetLastError")]
            internal static extern void XmlCtxtResetLastError(global::System.IntPtr ctx);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlResetError")]
            internal static extern void XmlResetError(global::System.IntPtr err);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCopyError")]
            internal static extern int XmlCopyError(global::System.IntPtr from, global::System.IntPtr to);
        }

        public static void XmlSetGenericErrorFunc(global::System.IntPtr ctx, global::libxml.XmlGenericErrorFunc handler)
        {
            var __arg1 = handler == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(handler);
            __Internal.XmlSetGenericErrorFunc(ctx, __arg1);
        }

        public static void InitGenericErrorDefaultFunc(global::libxml.XmlGenericErrorFunc handler)
        {
            var __arg0 = handler == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(handler);
            __Internal.InitGenericErrorDefaultFunc(__arg0);
        }

        public static void XmlSetStructuredErrorFunc(global::System.IntPtr ctx, global::libxml.XmlStructuredErrorFunc handler)
        {
            var __arg1 = handler == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(handler);
            __Internal.XmlSetStructuredErrorFunc(ctx, __arg1);
        }

        public static void XmlParserError(global::System.IntPtr ctx, string msg)
        {
            __Internal.XmlParserError(ctx, msg);
        }

        public static void XmlParserWarning(global::System.IntPtr ctx, string msg)
        {
            __Internal.XmlParserWarning(ctx, msg);
        }

        public static void XmlParserValidityError(global::System.IntPtr ctx, string msg)
        {
            __Internal.XmlParserValidityError(ctx, msg);
        }

        public static void XmlParserValidityWarning(global::System.IntPtr ctx, string msg)
        {
            __Internal.XmlParserValidityWarning(ctx, msg);
        }

        public static void XmlParserPrintFileInfo(global::libxml.XmlParserInput input)
        {
            var __arg0 = ReferenceEquals(input, null) ? global::System.IntPtr.Zero : input.__Instance;
            __Internal.XmlParserPrintFileInfo(__arg0);
        }

        public static void XmlParserPrintFileContext(global::libxml.XmlParserInput input)
        {
            var __arg0 = ReferenceEquals(input, null) ? global::System.IntPtr.Zero : input.__Instance;
            __Internal.XmlParserPrintFileContext(__arg0);
        }

        public static global::libxml.XmlError XmlGetLastError()
        {
            var __ret = __Internal.XmlGetLastError();
            global::libxml.XmlError __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlError.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlError) global::libxml.XmlError.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlError.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlResetLastError()
        {
            __Internal.XmlResetLastError();
        }

        public static global::libxml.XmlError XmlCtxtGetLastError(global::System.IntPtr ctx)
        {
            var __ret = __Internal.XmlCtxtGetLastError(ctx);
            global::libxml.XmlError __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlError.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlError) global::libxml.XmlError.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlError.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlCtxtResetLastError(global::System.IntPtr ctx)
        {
            __Internal.XmlCtxtResetLastError(ctx);
        }

        public static void XmlResetError(global::libxml.XmlError err)
        {
            var __arg0 = ReferenceEquals(err, null) ? global::System.IntPtr.Zero : err.__Instance;
            __Internal.XmlResetError(__arg0);
        }

        public static int XmlCopyError(global::libxml.XmlError from, global::libxml.XmlError to)
        {
            var __arg0 = ReferenceEquals(from, null) ? global::System.IntPtr.Zero : from.__Instance;
            var __arg1 = ReferenceEquals(to, null) ? global::System.IntPtr.Zero : to.__Instance;
            var __ret = __Internal.XmlCopyError(__arg0, __arg1);
            return __ret;
        }
    }

    /// <summary>xmlListDeallocator:</summary>
    /// <remarks>
    /// <para>:  the data to deallocate</para>
    /// <para>Callback function used to free data from a list.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void XmlListDeallocator(global::System.IntPtr lk);

    /// <summary>
    /// <para>xmlListDataCompare:</para>
    /// <para>the first data</para>
    /// <para>the second data</para>
    /// </summary>
    /// <remarks>
    /// <para>Callback function used to compare 2 data.</para>
    /// <para>Returns 0 is equality, -1 or 1 otherwise depending on the ordering.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate int XmlListDataCompare(global::System.IntPtr data0, global::System.IntPtr data1);

    /// <summary>xmlListWalker:</summary>
    /// <remarks>
    /// <para>: the data found in the list</para>
    /// <para>: extra user provided data to the walker</para>
    /// <para>Callback function used when walking a list with xmlListWalk().</para>
    /// <para>Returns 0 to stop walking the list, 1 otherwise.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate int XmlListWalker(global::System.IntPtr data, global::System.IntPtr user);

    public unsafe partial class XmlLink
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public partial struct __Internal
        {
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlLink> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlLink>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlLink __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlLink(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlLink __CreateInstance(global::libxml.XmlLink.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlLink(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlLink.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlLink.__Internal));
            *(global::libxml.XmlLink.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlLink(global::libxml.XmlLink.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlLink(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }
    }

    public unsafe partial class XmlList
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public partial struct __Internal
        {
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlList> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlList>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlList __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlList(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlList __CreateInstance(global::libxml.XmlList.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlList(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlList.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlList.__Internal));
            *(global::libxml.XmlList.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlList(global::libxml.XmlList.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlList(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }
    }

    public unsafe partial class list
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListCreate")]
            internal static extern global::System.IntPtr XmlListCreate(global::System.IntPtr deallocator, global::System.IntPtr compare);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListDelete")]
            internal static extern void XmlListDelete(global::System.IntPtr l);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListSearch")]
            internal static extern global::System.IntPtr XmlListSearch(global::System.IntPtr l, global::System.IntPtr data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListReverseSearch")]
            internal static extern global::System.IntPtr XmlListReverseSearch(global::System.IntPtr l, global::System.IntPtr data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListInsert")]
            internal static extern int XmlListInsert(global::System.IntPtr l, global::System.IntPtr data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListAppend")]
            internal static extern int XmlListAppend(global::System.IntPtr l, global::System.IntPtr data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListRemoveFirst")]
            internal static extern int XmlListRemoveFirst(global::System.IntPtr l, global::System.IntPtr data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListRemoveLast")]
            internal static extern int XmlListRemoveLast(global::System.IntPtr l, global::System.IntPtr data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListRemoveAll")]
            internal static extern int XmlListRemoveAll(global::System.IntPtr l, global::System.IntPtr data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListClear")]
            internal static extern void XmlListClear(global::System.IntPtr l);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListEmpty")]
            internal static extern int XmlListEmpty(global::System.IntPtr l);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListFront")]
            internal static extern global::System.IntPtr XmlListFront(global::System.IntPtr l);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListEnd")]
            internal static extern global::System.IntPtr XmlListEnd(global::System.IntPtr l);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListSize")]
            internal static extern int XmlListSize(global::System.IntPtr l);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListPopFront")]
            internal static extern void XmlListPopFront(global::System.IntPtr l);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListPopBack")]
            internal static extern void XmlListPopBack(global::System.IntPtr l);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListPushFront")]
            internal static extern int XmlListPushFront(global::System.IntPtr l, global::System.IntPtr data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListPushBack")]
            internal static extern int XmlListPushBack(global::System.IntPtr l, global::System.IntPtr data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListReverse")]
            internal static extern void XmlListReverse(global::System.IntPtr l);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListSort")]
            internal static extern void XmlListSort(global::System.IntPtr l);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListWalk")]
            internal static extern void XmlListWalk(global::System.IntPtr l, global::System.IntPtr walker, global::System.IntPtr user);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListReverseWalk")]
            internal static extern void XmlListReverseWalk(global::System.IntPtr l, global::System.IntPtr walker, global::System.IntPtr user);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListMerge")]
            internal static extern void XmlListMerge(global::System.IntPtr l1, global::System.IntPtr l2);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListDup")]
            internal static extern global::System.IntPtr XmlListDup(global::System.IntPtr old);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlListCopy")]
            internal static extern int XmlListCopy(global::System.IntPtr cur, global::System.IntPtr old);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlLinkGetData")]
            internal static extern global::System.IntPtr XmlLinkGetData(global::System.IntPtr lk);
        }

        public static global::libxml.XmlList XmlListCreate(global::libxml.XmlListDeallocator deallocator, global::libxml.XmlListDataCompare compare)
        {
            var __arg0 = deallocator == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(deallocator);
            var __arg1 = compare == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(compare);
            var __ret = __Internal.XmlListCreate(__arg0, __arg1);
            global::libxml.XmlList __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlList.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlList) global::libxml.XmlList.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlList.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlListDelete(global::libxml.XmlList l)
        {
            var __arg0 = ReferenceEquals(l, null) ? global::System.IntPtr.Zero : l.__Instance;
            __Internal.XmlListDelete(__arg0);
        }

        public static global::System.IntPtr XmlListSearch(global::libxml.XmlList l, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(l, null) ? global::System.IntPtr.Zero : l.__Instance;
            var __ret = __Internal.XmlListSearch(__arg0, data);
            return __ret;
        }

        public static global::System.IntPtr XmlListReverseSearch(global::libxml.XmlList l, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(l, null) ? global::System.IntPtr.Zero : l.__Instance;
            var __ret = __Internal.XmlListReverseSearch(__arg0, data);
            return __ret;
        }

        public static int XmlListInsert(global::libxml.XmlList l, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(l, null) ? global::System.IntPtr.Zero : l.__Instance;
            var __ret = __Internal.XmlListInsert(__arg0, data);
            return __ret;
        }

        public static int XmlListAppend(global::libxml.XmlList l, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(l, null) ? global::System.IntPtr.Zero : l.__Instance;
            var __ret = __Internal.XmlListAppend(__arg0, data);
            return __ret;
        }

        public static int XmlListRemoveFirst(global::libxml.XmlList l, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(l, null) ? global::System.IntPtr.Zero : l.__Instance;
            var __ret = __Internal.XmlListRemoveFirst(__arg0, data);
            return __ret;
        }

        public static int XmlListRemoveLast(global::libxml.XmlList l, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(l, null) ? global::System.IntPtr.Zero : l.__Instance;
            var __ret = __Internal.XmlListRemoveLast(__arg0, data);
            return __ret;
        }

        public static int XmlListRemoveAll(global::libxml.XmlList l, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(l, null) ? global::System.IntPtr.Zero : l.__Instance;
            var __ret = __Internal.XmlListRemoveAll(__arg0, data);
            return __ret;
        }

        public static void XmlListClear(global::libxml.XmlList l)
        {
            var __arg0 = ReferenceEquals(l, null) ? global::System.IntPtr.Zero : l.__Instance;
            __Internal.XmlListClear(__arg0);
        }

        public static int XmlListEmpty(global::libxml.XmlList l)
        {
            var __arg0 = ReferenceEquals(l, null) ? global::System.IntPtr.Zero : l.__Instance;
            var __ret = __Internal.XmlListEmpty(__arg0);
            return __ret;
        }

        public static global::libxml.XmlLink XmlListFront(global::libxml.XmlList l)
        {
            var __arg0 = ReferenceEquals(l, null) ? global::System.IntPtr.Zero : l.__Instance;
            var __ret = __Internal.XmlListFront(__arg0);
            global::libxml.XmlLink __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlLink.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlLink) global::libxml.XmlLink.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlLink.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlLink XmlListEnd(global::libxml.XmlList l)
        {
            var __arg0 = ReferenceEquals(l, null) ? global::System.IntPtr.Zero : l.__Instance;
            var __ret = __Internal.XmlListEnd(__arg0);
            global::libxml.XmlLink __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlLink.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlLink) global::libxml.XmlLink.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlLink.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlListSize(global::libxml.XmlList l)
        {
            var __arg0 = ReferenceEquals(l, null) ? global::System.IntPtr.Zero : l.__Instance;
            var __ret = __Internal.XmlListSize(__arg0);
            return __ret;
        }

        public static void XmlListPopFront(global::libxml.XmlList l)
        {
            var __arg0 = ReferenceEquals(l, null) ? global::System.IntPtr.Zero : l.__Instance;
            __Internal.XmlListPopFront(__arg0);
        }

        public static void XmlListPopBack(global::libxml.XmlList l)
        {
            var __arg0 = ReferenceEquals(l, null) ? global::System.IntPtr.Zero : l.__Instance;
            __Internal.XmlListPopBack(__arg0);
        }

        public static int XmlListPushFront(global::libxml.XmlList l, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(l, null) ? global::System.IntPtr.Zero : l.__Instance;
            var __ret = __Internal.XmlListPushFront(__arg0, data);
            return __ret;
        }

        public static int XmlListPushBack(global::libxml.XmlList l, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(l, null) ? global::System.IntPtr.Zero : l.__Instance;
            var __ret = __Internal.XmlListPushBack(__arg0, data);
            return __ret;
        }

        public static void XmlListReverse(global::libxml.XmlList l)
        {
            var __arg0 = ReferenceEquals(l, null) ? global::System.IntPtr.Zero : l.__Instance;
            __Internal.XmlListReverse(__arg0);
        }

        public static void XmlListSort(global::libxml.XmlList l)
        {
            var __arg0 = ReferenceEquals(l, null) ? global::System.IntPtr.Zero : l.__Instance;
            __Internal.XmlListSort(__arg0);
        }

        public static void XmlListWalk(global::libxml.XmlList l, global::libxml.XmlListWalker walker, global::System.IntPtr user)
        {
            var __arg0 = ReferenceEquals(l, null) ? global::System.IntPtr.Zero : l.__Instance;
            var __arg1 = walker == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(walker);
            __Internal.XmlListWalk(__arg0, __arg1, user);
        }

        public static void XmlListReverseWalk(global::libxml.XmlList l, global::libxml.XmlListWalker walker, global::System.IntPtr user)
        {
            var __arg0 = ReferenceEquals(l, null) ? global::System.IntPtr.Zero : l.__Instance;
            var __arg1 = walker == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(walker);
            __Internal.XmlListReverseWalk(__arg0, __arg1, user);
        }

        public static void XmlListMerge(global::libxml.XmlList l1, global::libxml.XmlList l2)
        {
            var __arg0 = ReferenceEquals(l1, null) ? global::System.IntPtr.Zero : l1.__Instance;
            var __arg1 = ReferenceEquals(l2, null) ? global::System.IntPtr.Zero : l2.__Instance;
            __Internal.XmlListMerge(__arg0, __arg1);
        }

        public static global::libxml.XmlList XmlListDup(global::libxml.XmlList old)
        {
            var __arg0 = ReferenceEquals(old, null) ? global::System.IntPtr.Zero : old.__Instance;
            var __ret = __Internal.XmlListDup(__arg0);
            global::libxml.XmlList __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlList.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlList) global::libxml.XmlList.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlList.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlListCopy(global::libxml.XmlList cur, global::libxml.XmlList old)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __arg1 = ReferenceEquals(old, null) ? global::System.IntPtr.Zero : old.__Instance;
            var __ret = __Internal.XmlListCopy(__arg0, __arg1);
            return __ret;
        }

        public static global::System.IntPtr XmlLinkGetData(global::libxml.XmlLink lk)
        {
            var __arg0 = ReferenceEquals(lk, null) ? global::System.IntPtr.Zero : lk.__Instance;
            var __ret = __Internal.XmlLinkGetData(__arg0);
            return __ret;
        }
    }

    /// <summary>
    /// <para>xmlValidityErrorFunc:</para>
    /// <para>usually an xmlValidCtxtPtr to a validity error context,</para>
    /// <para>but comes from ctxt-&gt;userData (which normally contains such</para>
    /// <para>a pointer); ctxt-&gt;userData can be changed by the user.</para>
    /// </summary>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void XmlValidityErrorFunc(global::System.IntPtr ctx, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

    /// <summary>
    /// <para>xmlValidityWarningFunc:</para>
    /// <para>usually an xmlValidCtxtPtr to a validity error context,</para>
    /// <para>but comes from ctxt-&gt;userData (which normally contains such</para>
    /// <para>a pointer); ctxt-&gt;userData can be changed by the user.</para>
    /// </summary>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void XmlValidityWarningFunc(global::System.IntPtr ctx, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

    public unsafe partial class valid
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAddNotationDecl")]
            internal static extern global::System.IntPtr XmlAddNotationDecl(global::System.IntPtr ctxt, global::System.IntPtr dtd, byte* name, byte* PublicID, byte* SystemID);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCopyNotationTable")]
            internal static extern global::System.IntPtr XmlCopyNotationTable(global::System.IntPtr table);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlFreeNotationTable")]
            internal static extern void XmlFreeNotationTable(global::System.IntPtr table);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDumpNotationDecl")]
            internal static extern void XmlDumpNotationDecl(global::System.IntPtr buf, global::System.IntPtr nota);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDumpNotationTable")]
            internal static extern void XmlDumpNotationTable(global::System.IntPtr buf, global::System.IntPtr table);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewElementContent")]
            internal static extern global::System.IntPtr XmlNewElementContent(byte* name, global::libxml.XmlElementContentType type);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCopyElementContent")]
            internal static extern global::System.IntPtr XmlCopyElementContent(global::System.IntPtr content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlFreeElementContent")]
            internal static extern void XmlFreeElementContent(global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewDocElementContent")]
            internal static extern global::System.IntPtr XmlNewDocElementContent(global::System.IntPtr doc, byte* name, global::libxml.XmlElementContentType type);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCopyDocElementContent")]
            internal static extern global::System.IntPtr XmlCopyDocElementContent(global::System.IntPtr doc, global::System.IntPtr content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlFreeDocElementContent")]
            internal static extern void XmlFreeDocElementContent(global::System.IntPtr doc, global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSnprintfElementContent")]
            internal static extern void XmlSnprintfElementContent(sbyte* buf, int size, global::System.IntPtr content, int englob);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSprintfElementContent")]
            internal static extern void XmlSprintfElementContent(sbyte* buf, global::System.IntPtr content, int englob);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAddElementDecl")]
            internal static extern global::System.IntPtr XmlAddElementDecl(global::System.IntPtr ctxt, global::System.IntPtr dtd, byte* name, global::libxml.XmlElementTypeVal type, global::System.IntPtr content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCopyElementTable")]
            internal static extern global::System.IntPtr XmlCopyElementTable(global::System.IntPtr table);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlFreeElementTable")]
            internal static extern void XmlFreeElementTable(global::System.IntPtr table);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDumpElementTable")]
            internal static extern void XmlDumpElementTable(global::System.IntPtr buf, global::System.IntPtr table);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDumpElementDecl")]
            internal static extern void XmlDumpElementDecl(global::System.IntPtr buf, global::System.IntPtr elem);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCreateEnumeration")]
            internal static extern global::System.IntPtr XmlCreateEnumeration(byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlFreeEnumeration")]
            internal static extern void XmlFreeEnumeration(global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCopyEnumeration")]
            internal static extern global::System.IntPtr XmlCopyEnumeration(global::System.IntPtr cur);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAddAttributeDecl")]
            internal static extern global::System.IntPtr XmlAddAttributeDecl(global::System.IntPtr ctxt, global::System.IntPtr dtd, byte* elem, byte* name, byte* ns, global::libxml.XmlAttributeType type, global::libxml.XmlAttributeDefault def, byte* defaultValue, global::System.IntPtr tree);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCopyAttributeTable")]
            internal static extern global::System.IntPtr XmlCopyAttributeTable(global::System.IntPtr table);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlFreeAttributeTable")]
            internal static extern void XmlFreeAttributeTable(global::System.IntPtr table);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDumpAttributeTable")]
            internal static extern void XmlDumpAttributeTable(global::System.IntPtr buf, global::System.IntPtr table);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDumpAttributeDecl")]
            internal static extern void XmlDumpAttributeDecl(global::System.IntPtr buf, global::System.IntPtr attr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAddID")]
            internal static extern global::System.IntPtr XmlAddID(global::System.IntPtr ctxt, global::System.IntPtr doc, byte* value, global::System.IntPtr attr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlFreeIDTable")]
            internal static extern void XmlFreeIDTable(global::System.IntPtr table);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetID")]
            internal static extern global::System.IntPtr XmlGetID(global::System.IntPtr doc, byte* ID);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlIsID")]
            internal static extern int XmlIsID(global::System.IntPtr doc, global::System.IntPtr elem, global::System.IntPtr attr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlRemoveID")]
            internal static extern int XmlRemoveID(global::System.IntPtr doc, global::System.IntPtr attr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAddRef")]
            internal static extern global::System.IntPtr XmlAddRef(global::System.IntPtr ctxt, global::System.IntPtr doc, byte* value, global::System.IntPtr attr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlFreeRefTable")]
            internal static extern void XmlFreeRefTable(global::System.IntPtr table);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlIsRef")]
            internal static extern int XmlIsRef(global::System.IntPtr doc, global::System.IntPtr elem, global::System.IntPtr attr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlRemoveRef")]
            internal static extern int XmlRemoveRef(global::System.IntPtr doc, global::System.IntPtr attr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetRefs")]
            internal static extern global::System.IntPtr XmlGetRefs(global::System.IntPtr doc, byte* ID);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewValidCtxt")]
            internal static extern global::System.IntPtr XmlNewValidCtxt();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlFreeValidCtxt")]
            internal static extern void XmlFreeValidCtxt(global::System.IntPtr _0);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidateRoot")]
            internal static extern int XmlValidateRoot(global::System.IntPtr ctxt, global::System.IntPtr doc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidateElementDecl")]
            internal static extern int XmlValidateElementDecl(global::System.IntPtr ctxt, global::System.IntPtr doc, global::System.IntPtr elem);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidNormalizeAttributeValue")]
            internal static extern byte* XmlValidNormalizeAttributeValue(global::System.IntPtr doc, global::System.IntPtr elem, byte* name, byte* value);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidCtxtNormalizeAttributeValue")]
            internal static extern byte* XmlValidCtxtNormalizeAttributeValue(global::System.IntPtr ctxt, global::System.IntPtr doc, global::System.IntPtr elem, byte* name, byte* value);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidateAttributeDecl")]
            internal static extern int XmlValidateAttributeDecl(global::System.IntPtr ctxt, global::System.IntPtr doc, global::System.IntPtr attr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidateAttributeValue")]
            internal static extern int XmlValidateAttributeValue(global::libxml.XmlAttributeType type, byte* value);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidateNotationDecl")]
            internal static extern int XmlValidateNotationDecl(global::System.IntPtr ctxt, global::System.IntPtr doc, global::System.IntPtr nota);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidateDtd")]
            internal static extern int XmlValidateDtd(global::System.IntPtr ctxt, global::System.IntPtr doc, global::System.IntPtr dtd);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidateDtdFinal")]
            internal static extern int XmlValidateDtdFinal(global::System.IntPtr ctxt, global::System.IntPtr doc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidateDocument")]
            internal static extern int XmlValidateDocument(global::System.IntPtr ctxt, global::System.IntPtr doc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidateElement")]
            internal static extern int XmlValidateElement(global::System.IntPtr ctxt, global::System.IntPtr doc, global::System.IntPtr elem);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidateOneElement")]
            internal static extern int XmlValidateOneElement(global::System.IntPtr ctxt, global::System.IntPtr doc, global::System.IntPtr elem);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidateOneAttribute")]
            internal static extern int XmlValidateOneAttribute(global::System.IntPtr ctxt, global::System.IntPtr doc, global::System.IntPtr elem, global::System.IntPtr attr, byte* value);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidateOneNamespace")]
            internal static extern int XmlValidateOneNamespace(global::System.IntPtr ctxt, global::System.IntPtr doc, global::System.IntPtr elem, byte* prefix, global::System.IntPtr ns, byte* value);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidateDocumentFinal")]
            internal static extern int XmlValidateDocumentFinal(global::System.IntPtr ctxt, global::System.IntPtr doc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidateNotationUse")]
            internal static extern int XmlValidateNotationUse(global::System.IntPtr ctxt, global::System.IntPtr doc, byte* notationName);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlIsMixedElement")]
            internal static extern int XmlIsMixedElement(global::System.IntPtr doc, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetDtdAttrDesc")]
            internal static extern global::System.IntPtr XmlGetDtdAttrDesc(global::System.IntPtr dtd, byte* elem, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetDtdQAttrDesc")]
            internal static extern global::System.IntPtr XmlGetDtdQAttrDesc(global::System.IntPtr dtd, byte* elem, byte* name, byte* prefix);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetDtdNotationDesc")]
            internal static extern global::System.IntPtr XmlGetDtdNotationDesc(global::System.IntPtr dtd, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetDtdQElementDesc")]
            internal static extern global::System.IntPtr XmlGetDtdQElementDesc(global::System.IntPtr dtd, byte* name, byte* prefix);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetDtdElementDesc")]
            internal static extern global::System.IntPtr XmlGetDtdElementDesc(global::System.IntPtr dtd, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidGetPotentialChildren")]
            internal static extern int XmlValidGetPotentialChildren(global::System.IntPtr ctree, byte** names, int* len, int max);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidGetValidElements")]
            internal static extern int XmlValidGetValidElements(global::System.IntPtr prev, global::System.IntPtr next, byte** names, int max);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidateNameValue")]
            internal static extern int XmlValidateNameValue(byte* value);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidateNamesValue")]
            internal static extern int XmlValidateNamesValue(byte* value);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidateNmtokenValue")]
            internal static extern int XmlValidateNmtokenValue(byte* value);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidateNmtokensValue")]
            internal static extern int XmlValidateNmtokensValue(byte* value);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidBuildContentModel")]
            internal static extern int XmlValidBuildContentModel(global::System.IntPtr ctxt, global::System.IntPtr elem);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidatePushElement")]
            internal static extern int XmlValidatePushElement(global::System.IntPtr ctxt, global::System.IntPtr doc, global::System.IntPtr elem, byte* qname);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidatePushCData")]
            internal static extern int XmlValidatePushCData(global::System.IntPtr ctxt, byte* data, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlValidatePopElement")]
            internal static extern int XmlValidatePopElement(global::System.IntPtr ctxt, global::System.IntPtr doc, global::System.IntPtr elem, byte* qname);
        }

        public static global::libxml.XmlNotation XmlAddNotationDecl(global::libxml.XmlValidCtxt ctxt, global::libxml.XmlDtd dtd, byte* name, byte* PublicID, byte* SystemID)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(dtd, null) ? global::System.IntPtr.Zero : dtd.__Instance;
            var __ret = __Internal.XmlAddNotationDecl(__arg0, __arg1, name, PublicID, SystemID);
            global::libxml.XmlNotation __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNotation.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNotation) global::libxml.XmlNotation.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNotation.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlHashTable XmlCopyNotationTable(global::libxml.XmlHashTable table)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __ret = __Internal.XmlCopyNotationTable(__arg0);
            global::libxml.XmlHashTable __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlHashTable.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlHashTable) global::libxml.XmlHashTable.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlHashTable.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlFreeNotationTable(global::libxml.XmlHashTable table)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            __Internal.XmlFreeNotationTable(__arg0);
        }

        public static void XmlDumpNotationDecl(global::libxml.XmlBuffer buf, global::libxml.XmlNotation nota)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __arg1 = ReferenceEquals(nota, null) ? global::System.IntPtr.Zero : nota.__Instance;
            __Internal.XmlDumpNotationDecl(__arg0, __arg1);
        }

        public static void XmlDumpNotationTable(global::libxml.XmlBuffer buf, global::libxml.XmlHashTable table)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __arg1 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            __Internal.XmlDumpNotationTable(__arg0, __arg1);
        }

        public static global::libxml.XmlElementContent XmlNewElementContent(byte* name, global::libxml.XmlElementContentType type)
        {
            var __ret = __Internal.XmlNewElementContent(name, type);
            global::libxml.XmlElementContent __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlElementContent.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlElementContent) global::libxml.XmlElementContent.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlElementContent.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlElementContent XmlCopyElementContent(global::libxml.XmlElementContent content)
        {
            var __arg0 = ReferenceEquals(content, null) ? global::System.IntPtr.Zero : content.__Instance;
            var __ret = __Internal.XmlCopyElementContent(__arg0);
            global::libxml.XmlElementContent __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlElementContent.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlElementContent) global::libxml.XmlElementContent.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlElementContent.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlFreeElementContent(global::libxml.XmlElementContent cur)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            __Internal.XmlFreeElementContent(__arg0);
        }

        public static global::libxml.XmlElementContent XmlNewDocElementContent(global::libxml.XmlDoc doc, byte* name, global::libxml.XmlElementContentType type)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlNewDocElementContent(__arg0, name, type);
            global::libxml.XmlElementContent __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlElementContent.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlElementContent) global::libxml.XmlElementContent.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlElementContent.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlElementContent XmlCopyDocElementContent(global::libxml.XmlDoc doc, global::libxml.XmlElementContent content)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg1 = ReferenceEquals(content, null) ? global::System.IntPtr.Zero : content.__Instance;
            var __ret = __Internal.XmlCopyDocElementContent(__arg0, __arg1);
            global::libxml.XmlElementContent __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlElementContent.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlElementContent) global::libxml.XmlElementContent.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlElementContent.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlFreeDocElementContent(global::libxml.XmlDoc doc, global::libxml.XmlElementContent cur)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg1 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            __Internal.XmlFreeDocElementContent(__arg0, __arg1);
        }

        public static void XmlSnprintfElementContent(sbyte* buf, int size, global::libxml.XmlElementContent content, int englob)
        {
            var __arg2 = ReferenceEquals(content, null) ? global::System.IntPtr.Zero : content.__Instance;
            __Internal.XmlSnprintfElementContent(buf, size, __arg2, englob);
        }

        public static void XmlSprintfElementContent(sbyte* buf, global::libxml.XmlElementContent content, int englob)
        {
            var __arg1 = ReferenceEquals(content, null) ? global::System.IntPtr.Zero : content.__Instance;
            __Internal.XmlSprintfElementContent(buf, __arg1, englob);
        }

        public static global::libxml.XmlElement XmlAddElementDecl(global::libxml.XmlValidCtxt ctxt, global::libxml.XmlDtd dtd, byte* name, global::libxml.XmlElementTypeVal type, global::libxml.XmlElementContent content)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(dtd, null) ? global::System.IntPtr.Zero : dtd.__Instance;
            var __arg4 = ReferenceEquals(content, null) ? global::System.IntPtr.Zero : content.__Instance;
            var __ret = __Internal.XmlAddElementDecl(__arg0, __arg1, name, type, __arg4);
            global::libxml.XmlElement __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlElement.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlElement) global::libxml.XmlElement.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlElement.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlHashTable XmlCopyElementTable(global::libxml.XmlHashTable table)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __ret = __Internal.XmlCopyElementTable(__arg0);
            global::libxml.XmlHashTable __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlHashTable.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlHashTable) global::libxml.XmlHashTable.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlHashTable.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlFreeElementTable(global::libxml.XmlHashTable table)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            __Internal.XmlFreeElementTable(__arg0);
        }

        public static void XmlDumpElementTable(global::libxml.XmlBuffer buf, global::libxml.XmlHashTable table)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __arg1 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            __Internal.XmlDumpElementTable(__arg0, __arg1);
        }

        public static void XmlDumpElementDecl(global::libxml.XmlBuffer buf, global::libxml.XmlElement elem)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __arg1 = ReferenceEquals(elem, null) ? global::System.IntPtr.Zero : elem.__Instance;
            __Internal.XmlDumpElementDecl(__arg0, __arg1);
        }

        public static global::libxml.XmlEnumeration XmlCreateEnumeration(byte* name)
        {
            var __ret = __Internal.XmlCreateEnumeration(name);
            global::libxml.XmlEnumeration __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlEnumeration.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlEnumeration) global::libxml.XmlEnumeration.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlEnumeration.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlFreeEnumeration(global::libxml.XmlEnumeration cur)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            __Internal.XmlFreeEnumeration(__arg0);
        }

        public static global::libxml.XmlEnumeration XmlCopyEnumeration(global::libxml.XmlEnumeration cur)
        {
            var __arg0 = ReferenceEquals(cur, null) ? global::System.IntPtr.Zero : cur.__Instance;
            var __ret = __Internal.XmlCopyEnumeration(__arg0);
            global::libxml.XmlEnumeration __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlEnumeration.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlEnumeration) global::libxml.XmlEnumeration.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlEnumeration.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlAttribute XmlAddAttributeDecl(global::libxml.XmlValidCtxt ctxt, global::libxml.XmlDtd dtd, byte* elem, byte* name, byte* ns, global::libxml.XmlAttributeType type, global::libxml.XmlAttributeDefault def, byte* defaultValue, global::libxml.XmlEnumeration tree)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(dtd, null) ? global::System.IntPtr.Zero : dtd.__Instance;
            var __arg8 = ReferenceEquals(tree, null) ? global::System.IntPtr.Zero : tree.__Instance;
            var __ret = __Internal.XmlAddAttributeDecl(__arg0, __arg1, elem, name, ns, type, def, defaultValue, __arg8);
            global::libxml.XmlAttribute __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAttribute.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAttribute) global::libxml.XmlAttribute.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAttribute.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlHashTable XmlCopyAttributeTable(global::libxml.XmlHashTable table)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __ret = __Internal.XmlCopyAttributeTable(__arg0);
            global::libxml.XmlHashTable __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlHashTable.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlHashTable) global::libxml.XmlHashTable.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlHashTable.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlFreeAttributeTable(global::libxml.XmlHashTable table)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            __Internal.XmlFreeAttributeTable(__arg0);
        }

        public static void XmlDumpAttributeTable(global::libxml.XmlBuffer buf, global::libxml.XmlHashTable table)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __arg1 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            __Internal.XmlDumpAttributeTable(__arg0, __arg1);
        }

        public static void XmlDumpAttributeDecl(global::libxml.XmlBuffer buf, global::libxml.XmlAttribute attr)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __arg1 = ReferenceEquals(attr, null) ? global::System.IntPtr.Zero : attr.__Instance;
            __Internal.XmlDumpAttributeDecl(__arg0, __arg1);
        }

        public static global::libxml.XmlID XmlAddID(global::libxml.XmlValidCtxt ctxt, global::libxml.XmlDoc doc, byte* value, global::libxml.XmlAttr attr)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg3 = ReferenceEquals(attr, null) ? global::System.IntPtr.Zero : attr.__Instance;
            var __ret = __Internal.XmlAddID(__arg0, __arg1, value, __arg3);
            global::libxml.XmlID __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlID.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlID) global::libxml.XmlID.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlID.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlFreeIDTable(global::libxml.XmlHashTable table)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            __Internal.XmlFreeIDTable(__arg0);
        }

        public static global::libxml.XmlAttr XmlGetID(global::libxml.XmlDoc doc, byte* ID)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlGetID(__arg0, ID);
            global::libxml.XmlAttr __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAttr.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAttr) global::libxml.XmlAttr.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAttr.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlIsID(global::libxml.XmlDoc doc, global::libxml.XmlNode elem, global::libxml.XmlAttr attr)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg1 = ReferenceEquals(elem, null) ? global::System.IntPtr.Zero : elem.__Instance;
            var __arg2 = ReferenceEquals(attr, null) ? global::System.IntPtr.Zero : attr.__Instance;
            var __ret = __Internal.XmlIsID(__arg0, __arg1, __arg2);
            return __ret;
        }

        public static int XmlRemoveID(global::libxml.XmlDoc doc, global::libxml.XmlAttr attr)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg1 = ReferenceEquals(attr, null) ? global::System.IntPtr.Zero : attr.__Instance;
            var __ret = __Internal.XmlRemoveID(__arg0, __arg1);
            return __ret;
        }

        public static global::libxml.XmlRef XmlAddRef(global::libxml.XmlValidCtxt ctxt, global::libxml.XmlDoc doc, byte* value, global::libxml.XmlAttr attr)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg3 = ReferenceEquals(attr, null) ? global::System.IntPtr.Zero : attr.__Instance;
            var __ret = __Internal.XmlAddRef(__arg0, __arg1, value, __arg3);
            global::libxml.XmlRef __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlRef.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlRef) global::libxml.XmlRef.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlRef.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlFreeRefTable(global::libxml.XmlHashTable table)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            __Internal.XmlFreeRefTable(__arg0);
        }

        public static int XmlIsRef(global::libxml.XmlDoc doc, global::libxml.XmlNode elem, global::libxml.XmlAttr attr)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg1 = ReferenceEquals(elem, null) ? global::System.IntPtr.Zero : elem.__Instance;
            var __arg2 = ReferenceEquals(attr, null) ? global::System.IntPtr.Zero : attr.__Instance;
            var __ret = __Internal.XmlIsRef(__arg0, __arg1, __arg2);
            return __ret;
        }

        public static int XmlRemoveRef(global::libxml.XmlDoc doc, global::libxml.XmlAttr attr)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg1 = ReferenceEquals(attr, null) ? global::System.IntPtr.Zero : attr.__Instance;
            var __ret = __Internal.XmlRemoveRef(__arg0, __arg1);
            return __ret;
        }

        public static global::libxml.XmlList XmlGetRefs(global::libxml.XmlDoc doc, byte* ID)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlGetRefs(__arg0, ID);
            global::libxml.XmlList __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlList.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlList) global::libxml.XmlList.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlList.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlValidCtxt XmlNewValidCtxt()
        {
            var __ret = __Internal.XmlNewValidCtxt();
            global::libxml.XmlValidCtxt __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlValidCtxt.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlValidCtxt) global::libxml.XmlValidCtxt.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlValidCtxt.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlFreeValidCtxt(global::libxml.XmlValidCtxt _0)
        {
            var __arg0 = ReferenceEquals(_0, null) ? global::System.IntPtr.Zero : _0.__Instance;
            __Internal.XmlFreeValidCtxt(__arg0);
        }

        public static int XmlValidateRoot(global::libxml.XmlValidCtxt ctxt, global::libxml.XmlDoc doc)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlValidateRoot(__arg0, __arg1);
            return __ret;
        }

        public static int XmlValidateElementDecl(global::libxml.XmlValidCtxt ctxt, global::libxml.XmlDoc doc, global::libxml.XmlElement elem)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg2 = ReferenceEquals(elem, null) ? global::System.IntPtr.Zero : elem.__Instance;
            var __ret = __Internal.XmlValidateElementDecl(__arg0, __arg1, __arg2);
            return __ret;
        }

        public static byte* XmlValidNormalizeAttributeValue(global::libxml.XmlDoc doc, global::libxml.XmlNode elem, byte* name, byte* value)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg1 = ReferenceEquals(elem, null) ? global::System.IntPtr.Zero : elem.__Instance;
            var __ret = __Internal.XmlValidNormalizeAttributeValue(__arg0, __arg1, name, value);
            return __ret;
        }

        public static byte* XmlValidCtxtNormalizeAttributeValue(global::libxml.XmlValidCtxt ctxt, global::libxml.XmlDoc doc, global::libxml.XmlNode elem, byte* name, byte* value)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg2 = ReferenceEquals(elem, null) ? global::System.IntPtr.Zero : elem.__Instance;
            var __ret = __Internal.XmlValidCtxtNormalizeAttributeValue(__arg0, __arg1, __arg2, name, value);
            return __ret;
        }

        public static int XmlValidateAttributeDecl(global::libxml.XmlValidCtxt ctxt, global::libxml.XmlDoc doc, global::libxml.XmlAttribute attr)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg2 = ReferenceEquals(attr, null) ? global::System.IntPtr.Zero : attr.__Instance;
            var __ret = __Internal.XmlValidateAttributeDecl(__arg0, __arg1, __arg2);
            return __ret;
        }

        public static int XmlValidateAttributeValue(global::libxml.XmlAttributeType type, byte* value)
        {
            var __ret = __Internal.XmlValidateAttributeValue(type, value);
            return __ret;
        }

        public static int XmlValidateNotationDecl(global::libxml.XmlValidCtxt ctxt, global::libxml.XmlDoc doc, global::libxml.XmlNotation nota)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg2 = ReferenceEquals(nota, null) ? global::System.IntPtr.Zero : nota.__Instance;
            var __ret = __Internal.XmlValidateNotationDecl(__arg0, __arg1, __arg2);
            return __ret;
        }

        public static int XmlValidateDtd(global::libxml.XmlValidCtxt ctxt, global::libxml.XmlDoc doc, global::libxml.XmlDtd dtd)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg2 = ReferenceEquals(dtd, null) ? global::System.IntPtr.Zero : dtd.__Instance;
            var __ret = __Internal.XmlValidateDtd(__arg0, __arg1, __arg2);
            return __ret;
        }

        public static int XmlValidateDtdFinal(global::libxml.XmlValidCtxt ctxt, global::libxml.XmlDoc doc)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlValidateDtdFinal(__arg0, __arg1);
            return __ret;
        }

        public static int XmlValidateDocument(global::libxml.XmlValidCtxt ctxt, global::libxml.XmlDoc doc)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlValidateDocument(__arg0, __arg1);
            return __ret;
        }

        public static int XmlValidateElement(global::libxml.XmlValidCtxt ctxt, global::libxml.XmlDoc doc, global::libxml.XmlNode elem)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg2 = ReferenceEquals(elem, null) ? global::System.IntPtr.Zero : elem.__Instance;
            var __ret = __Internal.XmlValidateElement(__arg0, __arg1, __arg2);
            return __ret;
        }

        public static int XmlValidateOneElement(global::libxml.XmlValidCtxt ctxt, global::libxml.XmlDoc doc, global::libxml.XmlNode elem)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg2 = ReferenceEquals(elem, null) ? global::System.IntPtr.Zero : elem.__Instance;
            var __ret = __Internal.XmlValidateOneElement(__arg0, __arg1, __arg2);
            return __ret;
        }

        public static int XmlValidateOneAttribute(global::libxml.XmlValidCtxt ctxt, global::libxml.XmlDoc doc, global::libxml.XmlNode elem, global::libxml.XmlAttr attr, byte* value)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg2 = ReferenceEquals(elem, null) ? global::System.IntPtr.Zero : elem.__Instance;
            var __arg3 = ReferenceEquals(attr, null) ? global::System.IntPtr.Zero : attr.__Instance;
            var __ret = __Internal.XmlValidateOneAttribute(__arg0, __arg1, __arg2, __arg3, value);
            return __ret;
        }

        public static int XmlValidateOneNamespace(global::libxml.XmlValidCtxt ctxt, global::libxml.XmlDoc doc, global::libxml.XmlNode elem, byte* prefix, global::libxml.XmlNs ns, byte* value)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg2 = ReferenceEquals(elem, null) ? global::System.IntPtr.Zero : elem.__Instance;
            var __arg4 = ReferenceEquals(ns, null) ? global::System.IntPtr.Zero : ns.__Instance;
            var __ret = __Internal.XmlValidateOneNamespace(__arg0, __arg1, __arg2, prefix, __arg4, value);
            return __ret;
        }

        public static int XmlValidateDocumentFinal(global::libxml.XmlValidCtxt ctxt, global::libxml.XmlDoc doc)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlValidateDocumentFinal(__arg0, __arg1);
            return __ret;
        }

        public static int XmlValidateNotationUse(global::libxml.XmlValidCtxt ctxt, global::libxml.XmlDoc doc, byte* notationName)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlValidateNotationUse(__arg0, __arg1, notationName);
            return __ret;
        }

        public static int XmlIsMixedElement(global::libxml.XmlDoc doc, byte* name)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlIsMixedElement(__arg0, name);
            return __ret;
        }

        public static global::libxml.XmlAttribute XmlGetDtdAttrDesc(global::libxml.XmlDtd dtd, byte* elem, byte* name)
        {
            var __arg0 = ReferenceEquals(dtd, null) ? global::System.IntPtr.Zero : dtd.__Instance;
            var __ret = __Internal.XmlGetDtdAttrDesc(__arg0, elem, name);
            global::libxml.XmlAttribute __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAttribute.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAttribute) global::libxml.XmlAttribute.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAttribute.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlAttribute XmlGetDtdQAttrDesc(global::libxml.XmlDtd dtd, byte* elem, byte* name, byte* prefix)
        {
            var __arg0 = ReferenceEquals(dtd, null) ? global::System.IntPtr.Zero : dtd.__Instance;
            var __ret = __Internal.XmlGetDtdQAttrDesc(__arg0, elem, name, prefix);
            global::libxml.XmlAttribute __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAttribute.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAttribute) global::libxml.XmlAttribute.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAttribute.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlNotation XmlGetDtdNotationDesc(global::libxml.XmlDtd dtd, byte* name)
        {
            var __arg0 = ReferenceEquals(dtd, null) ? global::System.IntPtr.Zero : dtd.__Instance;
            var __ret = __Internal.XmlGetDtdNotationDesc(__arg0, name);
            global::libxml.XmlNotation __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlNotation.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlNotation) global::libxml.XmlNotation.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlNotation.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlElement XmlGetDtdQElementDesc(global::libxml.XmlDtd dtd, byte* name, byte* prefix)
        {
            var __arg0 = ReferenceEquals(dtd, null) ? global::System.IntPtr.Zero : dtd.__Instance;
            var __ret = __Internal.XmlGetDtdQElementDesc(__arg0, name, prefix);
            global::libxml.XmlElement __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlElement.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlElement) global::libxml.XmlElement.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlElement.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlElement XmlGetDtdElementDesc(global::libxml.XmlDtd dtd, byte* name)
        {
            var __arg0 = ReferenceEquals(dtd, null) ? global::System.IntPtr.Zero : dtd.__Instance;
            var __ret = __Internal.XmlGetDtdElementDesc(__arg0, name);
            global::libxml.XmlElement __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlElement.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlElement) global::libxml.XmlElement.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlElement.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlValidGetPotentialChildren(global::libxml.XmlElementContent ctree, byte** names, ref int len, int max)
        {
            var __arg0 = ReferenceEquals(ctree, null) ? global::System.IntPtr.Zero : ctree.__Instance;
            fixed (int* __len2 = &len)
            {
                var __arg2 = __len2;
                var __ret = __Internal.XmlValidGetPotentialChildren(__arg0, names, __arg2, max);
                return __ret;
            }
        }

        public static int XmlValidGetValidElements(global::libxml.XmlNode prev, global::libxml.XmlNode next, byte** names, int max)
        {
            var __arg0 = ReferenceEquals(prev, null) ? global::System.IntPtr.Zero : prev.__Instance;
            var __arg1 = ReferenceEquals(next, null) ? global::System.IntPtr.Zero : next.__Instance;
            var __ret = __Internal.XmlValidGetValidElements(__arg0, __arg1, names, max);
            return __ret;
        }

        public static int XmlValidateNameValue(byte* value)
        {
            var __ret = __Internal.XmlValidateNameValue(value);
            return __ret;
        }

        public static int XmlValidateNamesValue(byte* value)
        {
            var __ret = __Internal.XmlValidateNamesValue(value);
            return __ret;
        }

        public static int XmlValidateNmtokenValue(byte* value)
        {
            var __ret = __Internal.XmlValidateNmtokenValue(value);
            return __ret;
        }

        public static int XmlValidateNmtokensValue(byte* value)
        {
            var __ret = __Internal.XmlValidateNmtokensValue(value);
            return __ret;
        }

        public static int XmlValidBuildContentModel(global::libxml.XmlValidCtxt ctxt, global::libxml.XmlElement elem)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(elem, null) ? global::System.IntPtr.Zero : elem.__Instance;
            var __ret = __Internal.XmlValidBuildContentModel(__arg0, __arg1);
            return __ret;
        }

        public static int XmlValidatePushElement(global::libxml.XmlValidCtxt ctxt, global::libxml.XmlDoc doc, global::libxml.XmlNode elem, byte* qname)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg2 = ReferenceEquals(elem, null) ? global::System.IntPtr.Zero : elem.__Instance;
            var __ret = __Internal.XmlValidatePushElement(__arg0, __arg1, __arg2, qname);
            return __ret;
        }

        public static int XmlValidatePushCData(global::libxml.XmlValidCtxt ctxt, byte* data, int len)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __ret = __Internal.XmlValidatePushCData(__arg0, data, len);
            return __ret;
        }

        public static int XmlValidatePopElement(global::libxml.XmlValidCtxt ctxt, global::libxml.XmlDoc doc, global::libxml.XmlNode elem, byte* qname)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? global::System.IntPtr.Zero : ctxt.__Instance;
            var __arg1 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg2 = ReferenceEquals(elem, null) ? global::System.IntPtr.Zero : elem.__Instance;
            var __ret = __Internal.XmlValidatePopElement(__arg0, __arg1, __arg2, qname);
            return __ret;
        }
    }

    public enum XmlEntityType : uint
    {
        XML_INTERNAL_GENERAL_ENTITY = 1,
        XML_EXTERNAL_GENERAL_PARSED_ENTITY = 2,
        XML_EXTERNAL_GENERAL_UNPARSED_ENTITY = 3,
        XML_INTERNAL_PARAMETER_ENTITY = 4,
        XML_EXTERNAL_PARAMETER_ENTITY = 5,
        XML_INTERNAL_PREDEFINED_ENTITY = 6
    }

    public unsafe partial class XmlEntity : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 76)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr _private;

            [FieldOffset(4)]
            internal global::libxml.XmlElementType type;

            [FieldOffset(8)]
            internal global::System.IntPtr name;

            [FieldOffset(12)]
            internal global::System.IntPtr children;

            [FieldOffset(16)]
            internal global::System.IntPtr last;

            [FieldOffset(20)]
            internal global::System.IntPtr parent;

            [FieldOffset(24)]
            internal global::System.IntPtr next;

            [FieldOffset(28)]
            internal global::System.IntPtr prev;

            [FieldOffset(32)]
            internal global::System.IntPtr doc;

            [FieldOffset(36)]
            internal global::System.IntPtr orig;

            [FieldOffset(40)]
            internal global::System.IntPtr content;

            [FieldOffset(44)]
            internal int length;

            [FieldOffset(48)]
            internal global::libxml.XmlEntityType etype;

            [FieldOffset(52)]
            internal global::System.IntPtr ExternalID;

            [FieldOffset(56)]
            internal global::System.IntPtr SystemID;

            [FieldOffset(60)]
            internal global::System.IntPtr nexte;

            [FieldOffset(64)]
            internal global::System.IntPtr URI;

            [FieldOffset(68)]
            internal int owner;

            [FieldOffset(72)]
            internal int @checked;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN10_xmlEntityC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlEntity> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlEntity>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlEntity __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlEntity(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlEntity __CreateInstance(global::libxml.XmlEntity.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlEntity(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlEntity.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlEntity.__Internal));
            *(global::libxml.XmlEntity.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlEntity(global::libxml.XmlEntity.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlEntity(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlEntity()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlEntity.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlEntity(global::libxml.XmlEntity _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlEntity.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlEntity.__Internal*) __Instance) = *((global::libxml.XmlEntity.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlEntity __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public global::System.IntPtr Private
        {
            get
            {
                return ((global::libxml.XmlEntity.__Internal*) __Instance)->_private;
            }

            set
            {
                ((global::libxml.XmlEntity.__Internal*)__Instance)->_private = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlElementType Type
        {
            get
            {
                return ((global::libxml.XmlEntity.__Internal*) __Instance)->type;
            }

            set
            {
                ((global::libxml.XmlEntity.__Internal*)__Instance)->type = value;
            }
        }

        public byte* Name
        {
            get
            {
                return (byte*) ((global::libxml.XmlEntity.__Internal*) __Instance)->name;
            }

            set
            {
                ((global::libxml.XmlEntity.__Internal*)__Instance)->name = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlNode Children
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlEntity.__Internal*) __Instance)->children == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlEntity.__Internal*) __Instance)->children))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlEntity.__Internal*) __Instance)->children];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlEntity.__Internal*) __Instance)->children);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlEntity.__Internal*)__Instance)->children = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNode Last
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlEntity.__Internal*) __Instance)->last == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlEntity.__Internal*) __Instance)->last))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlEntity.__Internal*) __Instance)->last];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlEntity.__Internal*) __Instance)->last);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlEntity.__Internal*)__Instance)->last = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlDtd Parent
        {
            get
            {
                global::libxml.XmlDtd __result0;
                if (((global::libxml.XmlEntity.__Internal*) __Instance)->parent == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlDtd.NativeToManagedMap.ContainsKey(((global::libxml.XmlEntity.__Internal*) __Instance)->parent))
                    __result0 = (global::libxml.XmlDtd) global::libxml.XmlDtd.NativeToManagedMap[((global::libxml.XmlEntity.__Internal*) __Instance)->parent];
                else __result0 = global::libxml.XmlDtd.__CreateInstance(((global::libxml.XmlEntity.__Internal*) __Instance)->parent);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlEntity.__Internal*)__Instance)->parent = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNode Next
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlEntity.__Internal*) __Instance)->next == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlEntity.__Internal*) __Instance)->next))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlEntity.__Internal*) __Instance)->next];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlEntity.__Internal*) __Instance)->next);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlEntity.__Internal*)__Instance)->next = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlNode Prev
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlEntity.__Internal*) __Instance)->prev == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlEntity.__Internal*) __Instance)->prev))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlEntity.__Internal*) __Instance)->prev];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlEntity.__Internal*) __Instance)->prev);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlEntity.__Internal*)__Instance)->prev = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlDoc Doc
        {
            get
            {
                global::libxml.XmlDoc __result0;
                if (((global::libxml.XmlEntity.__Internal*) __Instance)->doc == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(((global::libxml.XmlEntity.__Internal*) __Instance)->doc))
                    __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[((global::libxml.XmlEntity.__Internal*) __Instance)->doc];
                else __result0 = global::libxml.XmlDoc.__CreateInstance(((global::libxml.XmlEntity.__Internal*) __Instance)->doc);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlEntity.__Internal*)__Instance)->doc = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public byte* Orig
        {
            get
            {
                return (byte*) ((global::libxml.XmlEntity.__Internal*) __Instance)->orig;
            }

            set
            {
                ((global::libxml.XmlEntity.__Internal*)__Instance)->orig = (global::System.IntPtr) value;
            }
        }

        public byte* Content
        {
            get
            {
                return (byte*) ((global::libxml.XmlEntity.__Internal*) __Instance)->content;
            }

            set
            {
                ((global::libxml.XmlEntity.__Internal*)__Instance)->content = (global::System.IntPtr) value;
            }
        }

        public int Length
        {
            get
            {
                return ((global::libxml.XmlEntity.__Internal*) __Instance)->length;
            }

            set
            {
                ((global::libxml.XmlEntity.__Internal*)__Instance)->length = value;
            }
        }

        public global::libxml.XmlEntityType Etype
        {
            get
            {
                return ((global::libxml.XmlEntity.__Internal*) __Instance)->etype;
            }

            set
            {
                ((global::libxml.XmlEntity.__Internal*)__Instance)->etype = value;
            }
        }

        public byte* ExternalID
        {
            get
            {
                return (byte*) ((global::libxml.XmlEntity.__Internal*) __Instance)->ExternalID;
            }

            set
            {
                ((global::libxml.XmlEntity.__Internal*)__Instance)->ExternalID = (global::System.IntPtr) value;
            }
        }

        public byte* SystemID
        {
            get
            {
                return (byte*) ((global::libxml.XmlEntity.__Internal*) __Instance)->SystemID;
            }

            set
            {
                ((global::libxml.XmlEntity.__Internal*)__Instance)->SystemID = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlEntity Nexte
        {
            get
            {
                global::libxml.XmlEntity __result0;
                if (((global::libxml.XmlEntity.__Internal*) __Instance)->nexte == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlEntity.NativeToManagedMap.ContainsKey(((global::libxml.XmlEntity.__Internal*) __Instance)->nexte))
                    __result0 = (global::libxml.XmlEntity) global::libxml.XmlEntity.NativeToManagedMap[((global::libxml.XmlEntity.__Internal*) __Instance)->nexte];
                else __result0 = global::libxml.XmlEntity.__CreateInstance(((global::libxml.XmlEntity.__Internal*) __Instance)->nexte);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlEntity.__Internal*)__Instance)->nexte = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public byte* URI
        {
            get
            {
                return (byte*) ((global::libxml.XmlEntity.__Internal*) __Instance)->URI;
            }

            set
            {
                ((global::libxml.XmlEntity.__Internal*)__Instance)->URI = (global::System.IntPtr) value;
            }
        }

        public int Owner
        {
            get
            {
                return ((global::libxml.XmlEntity.__Internal*) __Instance)->owner;
            }

            set
            {
                ((global::libxml.XmlEntity.__Internal*)__Instance)->owner = value;
            }
        }

        public int Checked
        {
            get
            {
                return ((global::libxml.XmlEntity.__Internal*) __Instance)->@checked;
            }

            set
            {
                ((global::libxml.XmlEntity.__Internal*)__Instance)->@checked = value;
            }
        }
    }

    public unsafe partial class entities
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlInitializePredefinedEntities")]
            internal static extern void XmlInitializePredefinedEntities();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewEntity")]
            internal static extern global::System.IntPtr XmlNewEntity(global::System.IntPtr doc, byte* name, int type, byte* ExternalID, byte* SystemID, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAddDocEntity")]
            internal static extern global::System.IntPtr XmlAddDocEntity(global::System.IntPtr doc, byte* name, int type, byte* ExternalID, byte* SystemID, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAddDtdEntity")]
            internal static extern global::System.IntPtr XmlAddDtdEntity(global::System.IntPtr doc, byte* name, int type, byte* ExternalID, byte* SystemID, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetPredefinedEntity")]
            internal static extern global::System.IntPtr XmlGetPredefinedEntity(byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetDocEntity")]
            internal static extern global::System.IntPtr XmlGetDocEntity(global::System.IntPtr doc, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetDtdEntity")]
            internal static extern global::System.IntPtr XmlGetDtdEntity(global::System.IntPtr doc, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetParameterEntity")]
            internal static extern global::System.IntPtr XmlGetParameterEntity(global::System.IntPtr doc, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlEncodeEntities")]
            internal static extern byte* XmlEncodeEntities(global::System.IntPtr doc, byte* input);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlEncodeEntitiesReentrant")]
            internal static extern byte* XmlEncodeEntitiesReentrant(global::System.IntPtr doc, byte* input);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlEncodeSpecialChars")]
            internal static extern byte* XmlEncodeSpecialChars(global::System.IntPtr doc, byte* input);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCreateEntitiesTable")]
            internal static extern global::System.IntPtr XmlCreateEntitiesTable();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCopyEntitiesTable")]
            internal static extern global::System.IntPtr XmlCopyEntitiesTable(global::System.IntPtr table);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlFreeEntitiesTable")]
            internal static extern void XmlFreeEntitiesTable(global::System.IntPtr table);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDumpEntitiesTable")]
            internal static extern void XmlDumpEntitiesTable(global::System.IntPtr buf, global::System.IntPtr table);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDumpEntityDecl")]
            internal static extern void XmlDumpEntityDecl(global::System.IntPtr buf, global::System.IntPtr ent);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCleanupPredefinedEntities")]
            internal static extern void XmlCleanupPredefinedEntities();
        }

        public static void XmlInitializePredefinedEntities()
        {
            __Internal.XmlInitializePredefinedEntities();
        }

        public static global::libxml.XmlEntity XmlNewEntity(global::libxml.XmlDoc doc, byte* name, int type, byte* ExternalID, byte* SystemID, byte* content)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlNewEntity(__arg0, name, type, ExternalID, SystemID, content);
            global::libxml.XmlEntity __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlEntity.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlEntity) global::libxml.XmlEntity.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlEntity.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlEntity XmlAddDocEntity(global::libxml.XmlDoc doc, byte* name, int type, byte* ExternalID, byte* SystemID, byte* content)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlAddDocEntity(__arg0, name, type, ExternalID, SystemID, content);
            global::libxml.XmlEntity __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlEntity.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlEntity) global::libxml.XmlEntity.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlEntity.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlEntity XmlAddDtdEntity(global::libxml.XmlDoc doc, byte* name, int type, byte* ExternalID, byte* SystemID, byte* content)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlAddDtdEntity(__arg0, name, type, ExternalID, SystemID, content);
            global::libxml.XmlEntity __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlEntity.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlEntity) global::libxml.XmlEntity.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlEntity.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlEntity XmlGetPredefinedEntity(byte* name)
        {
            var __ret = __Internal.XmlGetPredefinedEntity(name);
            global::libxml.XmlEntity __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlEntity.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlEntity) global::libxml.XmlEntity.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlEntity.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlEntity XmlGetDocEntity(global::libxml.XmlDoc doc, byte* name)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlGetDocEntity(__arg0, name);
            global::libxml.XmlEntity __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlEntity.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlEntity) global::libxml.XmlEntity.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlEntity.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlEntity XmlGetDtdEntity(global::libxml.XmlDoc doc, byte* name)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlGetDtdEntity(__arg0, name);
            global::libxml.XmlEntity __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlEntity.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlEntity) global::libxml.XmlEntity.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlEntity.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlEntity XmlGetParameterEntity(global::libxml.XmlDoc doc, byte* name)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlGetParameterEntity(__arg0, name);
            global::libxml.XmlEntity __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlEntity.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlEntity) global::libxml.XmlEntity.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlEntity.__CreateInstance(__ret);
            return __result0;
        }

        public static byte* XmlEncodeEntities(global::libxml.XmlDoc doc, byte* input)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlEncodeEntities(__arg0, input);
            return __ret;
        }

        public static byte* XmlEncodeEntitiesReentrant(global::libxml.XmlDoc doc, byte* input)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlEncodeEntitiesReentrant(__arg0, input);
            return __ret;
        }

        public static byte* XmlEncodeSpecialChars(global::libxml.XmlDoc doc, byte* input)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __ret = __Internal.XmlEncodeSpecialChars(__arg0, input);
            return __ret;
        }

        public static global::libxml.XmlHashTable XmlCreateEntitiesTable()
        {
            var __ret = __Internal.XmlCreateEntitiesTable();
            global::libxml.XmlHashTable __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlHashTable.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlHashTable) global::libxml.XmlHashTable.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlHashTable.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlHashTable XmlCopyEntitiesTable(global::libxml.XmlHashTable table)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            var __ret = __Internal.XmlCopyEntitiesTable(__arg0);
            global::libxml.XmlHashTable __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlHashTable.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlHashTable) global::libxml.XmlHashTable.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlHashTable.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlFreeEntitiesTable(global::libxml.XmlHashTable table)
        {
            var __arg0 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            __Internal.XmlFreeEntitiesTable(__arg0);
        }

        public static void XmlDumpEntitiesTable(global::libxml.XmlBuffer buf, global::libxml.XmlHashTable table)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __arg1 = ReferenceEquals(table, null) ? global::System.IntPtr.Zero : table.__Instance;
            __Internal.XmlDumpEntitiesTable(__arg0, __arg1);
        }

        public static void XmlDumpEntityDecl(global::libxml.XmlBuffer buf, global::libxml.XmlEntity ent)
        {
            var __arg0 = ReferenceEquals(buf, null) ? global::System.IntPtr.Zero : buf.__Instance;
            var __arg1 = ReferenceEquals(ent, null) ? global::System.IntPtr.Zero : ent.__Instance;
            __Internal.XmlDumpEntityDecl(__arg0, __arg1);
        }

        public static void XmlCleanupPredefinedEntities()
        {
            __Internal.XmlCleanupPredefinedEntities();
        }
    }

    public enum XmlCharEncoding
    {
        XML_CHAR_ENCODING_ERROR = -1,
        XML_CHAR_ENCODING_NONE = 0,
        XML_CHAR_ENCODING_UTF8 = 1,
        XML_CHAR_ENCODING_UTF16LE = 2,
        XML_CHAR_ENCODING_UTF16BE = 3,
        XML_CHAR_ENCODING_UCS4LE = 4,
        XML_CHAR_ENCODING_UCS4BE = 5,
        XML_CHAR_ENCODING_EBCDIC = 6,
        XML_CHAR_ENCODING_UCS4_2143 = 7,
        XML_CHAR_ENCODING_UCS4_3412 = 8,
        XML_CHAR_ENCODING_UCS2 = 9,
        XML_CHAR_ENCODING_8859_1 = 10,
        XML_CHAR_ENCODING_8859_2 = 11,
        XML_CHAR_ENCODING_8859_3 = 12,
        XML_CHAR_ENCODING_8859_4 = 13,
        XML_CHAR_ENCODING_8859_5 = 14,
        XML_CHAR_ENCODING_8859_6 = 15,
        XML_CHAR_ENCODING_8859_7 = 16,
        XML_CHAR_ENCODING_8859_8 = 17,
        XML_CHAR_ENCODING_8859_9 = 18,
        XML_CHAR_ENCODING_2022JP = 19,
        XML_CHAR_ENCODING_SHIFT_JIS = 20,
        XML_CHAR_ENCODING_EUC_JP = 21,
        XML_CHAR_ENCODING_ASCII = 22
    }

    /// <summary>
    /// <para>xmlCharEncodingInputFunc:</para>
    /// <para>a pointer to an array of bytes to store the UTF-8 result</para>
    /// <para>the length of</para>
    /// </summary>
    /// <remarks>
    /// <para>the length of</para>
    /// <para>Take a block of chars in the original encoding and try to convert</para>
    /// <para>it to an UTF-8 block of chars out.</para>
    /// <para>Returns the number of bytes written, -1 if lack of space, or -2</para>
    /// <para>if the transcoding failed.</para>
    /// <para>The value ofafter return is the number of octets consumed</para>
    /// <para>if the return value is positive, else unpredictiable.</para>
    /// <para>The value ofafter return is the number of octets consumed.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate int XmlCharEncodingInputFunc(byte* @out, int* outlen, byte* @in, int* inlen);

    /// <summary>
    /// <para>xmlCharEncodingOutputFunc:</para>
    /// <para>a pointer to an array of bytes to store the result</para>
    /// <para>the length of</para>
    /// </summary>
    /// <remarks>
    /// <para>the length of</para>
    /// <para>Take a block of UTF-8 chars in and try to convert it to another</para>
    /// <para>encoding.</para>
    /// <para>Note: a first call designed to produce heading info is called with</para>
    /// <para>in = NULL. If stateful this should also initialize the encoder state.</para>
    /// <para>Returns the number of bytes written, -1 if lack of space, or -2</para>
    /// <para>if the transcoding failed.</para>
    /// <para>The value ofafter return is the number of octets consumed</para>
    /// <para>if the return value is positive, else unpredictiable.</para>
    /// <para>The value ofafter return is the number of octets produced.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate int XmlCharEncodingOutputFunc(byte* @out, int* outlen, byte* @in, int* inlen);

    public unsafe partial class encoding
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlInitCharEncodingHandlers")]
            internal static extern void XmlInitCharEncodingHandlers();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCleanupCharEncodingHandlers")]
            internal static extern void XmlCleanupCharEncodingHandlers();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlRegisterCharEncodingHandler")]
            internal static extern void XmlRegisterCharEncodingHandler(global::System.IntPtr handler);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetCharEncodingHandler")]
            internal static extern global::System.IntPtr XmlGetCharEncodingHandler(global::libxml.XmlCharEncoding enc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlFindCharEncodingHandler")]
            internal static extern global::System.IntPtr XmlFindCharEncodingHandler([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewCharEncodingHandler")]
            internal static extern global::System.IntPtr XmlNewCharEncodingHandler([MarshalAs(UnmanagedType.LPUTF8Str)] string name, global::System.IntPtr input, global::System.IntPtr output);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAddEncodingAlias")]
            internal static extern int XmlAddEncodingAlias([MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string alias);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDelEncodingAlias")]
            internal static extern int XmlDelEncodingAlias([MarshalAs(UnmanagedType.LPUTF8Str)] string alias);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetEncodingAlias")]
            internal static extern global::System.IntPtr XmlGetEncodingAlias([MarshalAs(UnmanagedType.LPUTF8Str)] string alias);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCleanupEncodingAliases")]
            internal static extern void XmlCleanupEncodingAliases();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParseCharEncoding")]
            internal static extern global::libxml.XmlCharEncoding XmlParseCharEncoding([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetCharEncodingName")]
            internal static extern global::System.IntPtr XmlGetCharEncodingName(global::libxml.XmlCharEncoding enc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDetectCharEncoding")]
            internal static extern global::libxml.XmlCharEncoding XmlDetectCharEncoding(byte* @in, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCharEncOutFunc")]
            internal static extern int XmlCharEncOutFunc(global::System.IntPtr handler, global::System.IntPtr @out, global::System.IntPtr @in);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCharEncInFunc")]
            internal static extern int XmlCharEncInFunc(global::System.IntPtr handler, global::System.IntPtr @out, global::System.IntPtr @in);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCharEncFirstLine")]
            internal static extern int XmlCharEncFirstLine(global::System.IntPtr handler, global::System.IntPtr @out, global::System.IntPtr @in);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCharEncCloseFunc")]
            internal static extern int XmlCharEncCloseFunc(global::System.IntPtr handler);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="UTF8Toisolat1")]
            internal static extern int UTF8Toisolat1(byte* @out, int* outlen, byte* @in, int* inlen);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="isolat1ToUTF8")]
            internal static extern int Isolat1ToUTF8(byte* @out, int* outlen, byte* @in, int* inlen);
        }

        public static void XmlInitCharEncodingHandlers()
        {
            __Internal.XmlInitCharEncodingHandlers();
        }

        public static void XmlCleanupCharEncodingHandlers()
        {
            __Internal.XmlCleanupCharEncodingHandlers();
        }

        public static void XmlRegisterCharEncodingHandler(global::libxml.XmlCharEncodingHandler handler)
        {
            var __arg0 = ReferenceEquals(handler, null) ? global::System.IntPtr.Zero : handler.__Instance;
            __Internal.XmlRegisterCharEncodingHandler(__arg0);
        }

        public static global::libxml.XmlCharEncodingHandler XmlGetCharEncodingHandler(global::libxml.XmlCharEncoding enc)
        {
            var __ret = __Internal.XmlGetCharEncodingHandler(enc);
            global::libxml.XmlCharEncodingHandler __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlCharEncodingHandler.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlCharEncodingHandler) global::libxml.XmlCharEncodingHandler.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlCharEncodingHandler.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlCharEncodingHandler XmlFindCharEncodingHandler(string name)
        {
            var __ret = __Internal.XmlFindCharEncodingHandler(name);
            global::libxml.XmlCharEncodingHandler __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlCharEncodingHandler.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlCharEncodingHandler) global::libxml.XmlCharEncodingHandler.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlCharEncodingHandler.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlCharEncodingHandler XmlNewCharEncodingHandler(string name, global::libxml.XmlCharEncodingInputFunc input, global::libxml.XmlCharEncodingOutputFunc output)
        {
            var __arg1 = input == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(input);
            var __arg2 = output == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(output);
            var __ret = __Internal.XmlNewCharEncodingHandler(name, __arg1, __arg2);
            global::libxml.XmlCharEncodingHandler __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlCharEncodingHandler.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlCharEncodingHandler) global::libxml.XmlCharEncodingHandler.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlCharEncodingHandler.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlAddEncodingAlias(string name, string alias)
        {
            var __ret = __Internal.XmlAddEncodingAlias(name, alias);
            return __ret;
        }

        public static int XmlDelEncodingAlias(string alias)
        {
            var __ret = __Internal.XmlDelEncodingAlias(alias);
            return __ret;
        }

        public static string XmlGetEncodingAlias(string alias)
        {
            var __ret = __Internal.XmlGetEncodingAlias(alias);
            if (__ret == global::System.IntPtr.Zero)
                return default(string);
            var __retPtr = (byte*) __ret;
            int __length = 0;
            while (*(__retPtr++) != 0) __length += sizeof(byte);
            return global::System.Text.Encoding.UTF8.GetString((byte*) __ret, __length);
        }

        public static void XmlCleanupEncodingAliases()
        {
            __Internal.XmlCleanupEncodingAliases();
        }

        public static global::libxml.XmlCharEncoding XmlParseCharEncoding(string name)
        {
            var __ret = __Internal.XmlParseCharEncoding(name);
            return __ret;
        }

        public static string XmlGetCharEncodingName(global::libxml.XmlCharEncoding enc)
        {
            var __ret = __Internal.XmlGetCharEncodingName(enc);
            if (__ret == global::System.IntPtr.Zero)
                return default(string);
            var __retPtr = (byte*) __ret;
            int __length = 0;
            while (*(__retPtr++) != 0) __length += sizeof(byte);
            return global::System.Text.Encoding.UTF8.GetString((byte*) __ret, __length);
        }

        public static global::libxml.XmlCharEncoding XmlDetectCharEncoding(byte* @in, int len)
        {
            var __ret = __Internal.XmlDetectCharEncoding(@in, len);
            return __ret;
        }

        public static int XmlCharEncOutFunc(global::libxml.XmlCharEncodingHandler handler, global::libxml.XmlBuffer @out, global::libxml.XmlBuffer @in)
        {
            var __arg0 = ReferenceEquals(handler, null) ? global::System.IntPtr.Zero : handler.__Instance;
            var __arg1 = ReferenceEquals(@out, null) ? global::System.IntPtr.Zero : @out.__Instance;
            var __arg2 = ReferenceEquals(@in, null) ? global::System.IntPtr.Zero : @in.__Instance;
            var __ret = __Internal.XmlCharEncOutFunc(__arg0, __arg1, __arg2);
            return __ret;
        }

        public static int XmlCharEncInFunc(global::libxml.XmlCharEncodingHandler handler, global::libxml.XmlBuffer @out, global::libxml.XmlBuffer @in)
        {
            var __arg0 = ReferenceEquals(handler, null) ? global::System.IntPtr.Zero : handler.__Instance;
            var __arg1 = ReferenceEquals(@out, null) ? global::System.IntPtr.Zero : @out.__Instance;
            var __arg2 = ReferenceEquals(@in, null) ? global::System.IntPtr.Zero : @in.__Instance;
            var __ret = __Internal.XmlCharEncInFunc(__arg0, __arg1, __arg2);
            return __ret;
        }

        public static int XmlCharEncFirstLine(global::libxml.XmlCharEncodingHandler handler, global::libxml.XmlBuffer @out, global::libxml.XmlBuffer @in)
        {
            var __arg0 = ReferenceEquals(handler, null) ? global::System.IntPtr.Zero : handler.__Instance;
            var __arg1 = ReferenceEquals(@out, null) ? global::System.IntPtr.Zero : @out.__Instance;
            var __arg2 = ReferenceEquals(@in, null) ? global::System.IntPtr.Zero : @in.__Instance;
            var __ret = __Internal.XmlCharEncFirstLine(__arg0, __arg1, __arg2);
            return __ret;
        }

        public static int XmlCharEncCloseFunc(global::libxml.XmlCharEncodingHandler handler)
        {
            var __arg0 = ReferenceEquals(handler, null) ? global::System.IntPtr.Zero : handler.__Instance;
            var __ret = __Internal.XmlCharEncCloseFunc(__arg0);
            return __ret;
        }

        public static int UTF8Toisolat1(byte* @out, ref int outlen, byte* @in, ref int inlen)
        {
            fixed (int* __outlen1 = &outlen)
            {
                var __arg1 = __outlen1;
                fixed (int* __inlen3 = &inlen)
                {
                    var __arg3 = __inlen3;
                    var __ret = __Internal.UTF8Toisolat1(@out, __arg1, @in, __arg3);
                    return __ret;
                }
            }
        }

        public static int Isolat1ToUTF8(byte* @out, ref int outlen, byte* @in, ref int inlen)
        {
            fixed (int* __outlen1 = &outlen)
            {
                var __arg1 = __outlen1;
                fixed (int* __inlen3 = &inlen)
                {
                    var __arg3 = __inlen3;
                    var __ret = __Internal.Isolat1ToUTF8(@out, __arg1, @in, __arg3);
                    return __ret;
                }
            }
        }
    }

    /// <summary>
    /// <para>xmlParserInputBufferCreateFilenameFunc:</para>
    /// <para>the URI to read from</para>
    /// <para>the requested source encoding</para>
    /// </summary>
    /// <remarks>
    /// <para>Signature for the function doing the lookup for a suitable input method</para>
    /// <para>corresponding to an URI.</para>
    /// <para>Returns the new xmlParserInputBufferPtr in case of success or NULL if no</para>
    /// <para>method was found.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate global::System.IntPtr XmlParserInputBufferCreateFilenameFunc([MarshalAs(UnmanagedType.LPUTF8Str)] string URI, global::libxml.XmlCharEncoding enc);

    /// <summary>
    /// <para>xmlOutputBufferCreateFilenameFunc:</para>
    /// <para>the URI to write to</para>
    /// <para>the requested target encoding</para>
    /// </summary>
    /// <remarks>
    /// <para>Signature for the function doing the lookup for a suitable output method</para>
    /// <para>corresponding to an URI.</para>
    /// <para>Returns the new xmlOutputBufferPtr in case of success or NULL if no</para>
    /// <para>method was found.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate global::System.IntPtr XmlOutputBufferCreateFilenameFunc([MarshalAs(UnmanagedType.LPUTF8Str)] string URI, global::System.IntPtr encoder, int compression);

    /// <summary>
    /// <para>xmlRegisterNodeFunc:</para>
    /// <para>the current node</para>
    /// </summary>
    /// <remarks>Signature for the registration callback of a created node</remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void XmlRegisterNodeFunc(global::System.IntPtr node);

    /// <summary>
    /// <para>xmlDeregisterNodeFunc:</para>
    /// <para>the current node</para>
    /// </summary>
    /// <remarks>Signature for the deregistration callback of a discarded node</remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void XmlDeregisterNodeFunc(global::System.IntPtr node);

    public enum XlinkType : uint
    {
        XLINK_TYPE_NONE = 0,
        XLINK_TYPE_SIMPLE = 1,
        XLINK_TYPE_EXTENDED = 2,
        XLINK_TYPE_EXTENDED_SET = 3
    }

    public enum XlinkShow : uint
    {
        XLINK_SHOW_NONE = 0,
        XLINK_SHOW_NEW = 1,
        XLINK_SHOW_EMBED = 2,
        XLINK_SHOW_REPLACE = 3
    }

    public enum XlinkActuate : uint
    {
        XLINK_ACTUATE_NONE = 0,
        XLINK_ACTUATE_AUTO = 1,
        XLINK_ACTUATE_ONREQUEST = 2
    }

    /// <summary>Various defines for the various Link properties.</summary>
    /// <remarks>
    /// <para>NOTE: the link detection layer will try to resolve QName expansion</para>
    /// <para>of namespaces. If &quot;foo&quot; is the prefix for &quot;http://foo.com/&quot;</para>
    /// <para>then the link detection layer will expand role=&quot;foo:myrole&quot;</para>
    /// <para>to &quot;http://foo.com/:myrole&quot;.</para>
    /// <para>NOTE: the link detection layer will expand URI-Refences found on</para>
    /// <para>href attributes by using the base mechanism if found.</para>
    /// </remarks>
    /// <summary>
    /// <para>xlinkNodeDetectFunc:</para>
    /// <para>user data pointer</para>
    /// <para>the node to check</para>
    /// </summary>
    /// <remarks>
    /// <para>This is the prototype for the link detection routine.</para>
    /// <para>It calls the default link detection callbacks upon link detection.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void XlinkNodeDetectFunc(global::System.IntPtr ctx, global::System.IntPtr node);

    /// <summary>
    /// <para>xlinkSimpleLinkFunk:</para>
    /// <para>user data pointer</para>
    /// <para>the node carrying the link</para>
    /// </summary>
    /// <remarks>
    /// <para>the role string</para>
    /// <para>the link title</para>
    /// <para>This is the prototype for a simple link detection callback.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void XlinkSimpleLinkFunk(global::System.IntPtr ctx, global::System.IntPtr node, byte* href, byte* role, byte* title);

    /// <summary>
    /// <para>xlinkExtendedLinkFunk:</para>
    /// <para>user data pointer</para>
    /// <para>the node carrying the link</para>
    /// <para>the number of locators detected on the link</para>
    /// <para>pointer to the array of locator hrefs</para>
    /// <para>pointer to the array of locator roles</para>
    /// <para>the number of arcs detected on the link</para>
    /// <para>pointer to the array of source roles found on the arcs</para>
    /// <para>pointer to the array of target roles found on the arcs</para>
    /// <para>array of values for the show attributes found on the arcs</para>
    /// <para>array of values for the actuate attributes found on the arcs</para>
    /// <para>the number of titles detected on the link</para>
    /// <para>array of titles detected on the link</para>
    /// <para>array of xml:lang values for the titles</para>
    /// </summary>
    /// <remarks>This is the prototype for a extended link detection callback.</remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void XlinkExtendedLinkFunk(global::System.IntPtr ctx, global::System.IntPtr node, int nbLocators, byte** hrefs, byte** roles, int nbArcs, byte** from, byte** to, global::libxml.XlinkShow* show, global::libxml.XlinkActuate* actuate, int nbTitles, byte** titles, byte** langs);

    /// <summary>
    /// <para>xlinkExtendedLinkSetFunk:</para>
    /// <para>user data pointer</para>
    /// <para>the node carrying the link</para>
    /// <para>the number of locators detected on the link</para>
    /// <para>pointer to the array of locator hrefs</para>
    /// <para>pointer to the array of locator roles</para>
    /// <para>the number of titles detected on the link</para>
    /// <para>array of titles detected on the link</para>
    /// <para>array of xml:lang values for the titles</para>
    /// </summary>
    /// <remarks>This is the prototype for a extended link set detection callback.</remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void XlinkExtendedLinkSetFunk(global::System.IntPtr ctx, global::System.IntPtr node, int nbLocators, byte** hrefs, byte** roles, int nbTitles, byte** titles, byte** langs);

    /// <summary>This is the structure containing a set of Links detection callbacks.</summary>
    /// <remarks>
    /// <para>There is no default xlink callbacks, if one want to get link</para>
    /// <para>recognition activated, those call backs must be provided before parsing.</para>
    /// </remarks>
    public unsafe partial class XlinkHandler : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 12)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr simple;

            [FieldOffset(4)]
            internal global::System.IntPtr extended;

            [FieldOffset(8)]
            internal global::System.IntPtr set;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN13_xlinkHandlerC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XlinkHandler> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XlinkHandler>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XlinkHandler __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XlinkHandler(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XlinkHandler __CreateInstance(global::libxml.XlinkHandler.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XlinkHandler(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XlinkHandler.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XlinkHandler.__Internal));
            *(global::libxml.XlinkHandler.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XlinkHandler(global::libxml.XlinkHandler.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XlinkHandler(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XlinkHandler()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XlinkHandler.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XlinkHandler(global::libxml.XlinkHandler _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XlinkHandler.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XlinkHandler.__Internal*) __Instance) = *((global::libxml.XlinkHandler.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XlinkHandler __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public global::libxml.XlinkSimpleLinkFunk Simple
        {
            get
            {
                var __ptr0 = ((global::libxml.XlinkHandler.__Internal*) __Instance)->simple;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XlinkSimpleLinkFunk) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XlinkSimpleLinkFunk));
            }

            set
            {
                ((global::libxml.XlinkHandler.__Internal*)__Instance)->simple = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.XlinkExtendedLinkFunk Extended
        {
            get
            {
                var __ptr0 = ((global::libxml.XlinkHandler.__Internal*) __Instance)->extended;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XlinkExtendedLinkFunk) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XlinkExtendedLinkFunk));
            }

            set
            {
                ((global::libxml.XlinkHandler.__Internal*)__Instance)->extended = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.XlinkExtendedLinkSetFunk Set
        {
            get
            {
                var __ptr0 = ((global::libxml.XlinkHandler.__Internal*) __Instance)->set;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XlinkExtendedLinkSetFunk) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XlinkExtendedLinkSetFunk));
            }

            set
            {
                ((global::libxml.XlinkHandler.__Internal*)__Instance)->set = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }
    }

    public unsafe partial class xlink
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xlinkGetDefaultDetect")]
            internal static extern global::System.IntPtr XlinkGetDefaultDetect();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xlinkSetDefaultDetect")]
            internal static extern void XlinkSetDefaultDetect(global::System.IntPtr func);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xlinkGetDefaultHandler")]
            internal static extern global::System.IntPtr XlinkGetDefaultHandler();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xlinkSetDefaultHandler")]
            internal static extern void XlinkSetDefaultHandler(global::System.IntPtr handler);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xlinkIsLink")]
            internal static extern global::libxml.XlinkType XlinkIsLink(global::System.IntPtr doc, global::System.IntPtr node);
        }

        public static global::libxml.XlinkNodeDetectFunc XlinkGetDefaultDetect()
        {
            var __ret = __Internal.XlinkGetDefaultDetect();
            var __ptr0 = __ret;
            return __ptr0 == IntPtr.Zero? null : (global::libxml.XlinkNodeDetectFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XlinkNodeDetectFunc));
        }

        public static void XlinkSetDefaultDetect(global::libxml.XlinkNodeDetectFunc func)
        {
            var __arg0 = func == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func);
            __Internal.XlinkSetDefaultDetect(__arg0);
        }

        public static global::libxml.XlinkHandler XlinkGetDefaultHandler()
        {
            var __ret = __Internal.XlinkGetDefaultHandler();
            global::libxml.XlinkHandler __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XlinkHandler.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XlinkHandler) global::libxml.XlinkHandler.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XlinkHandler.__CreateInstance(__ret);
            return __result0;
        }

        public static void XlinkSetDefaultHandler(global::libxml.XlinkHandler handler)
        {
            var __arg0 = ReferenceEquals(handler, null) ? global::System.IntPtr.Zero : handler.__Instance;
            __Internal.XlinkSetDefaultHandler(__arg0);
        }

        public static global::libxml.XlinkType XlinkIsLink(global::libxml.XmlDoc doc, global::libxml.XmlNode node)
        {
            var __arg0 = ReferenceEquals(doc, null) ? global::System.IntPtr.Zero : doc.__Instance;
            var __arg1 = ReferenceEquals(node, null) ? global::System.IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XlinkIsLink(__arg0, __arg1);
            return __ret;
        }
    }

    public unsafe partial class SAX2
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2GetPublicId")]
            internal static extern byte* XmlSAX2GetPublicId(global::System.IntPtr ctx);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2GetSystemId")]
            internal static extern byte* XmlSAX2GetSystemId(global::System.IntPtr ctx);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2SetDocumentLocator")]
            internal static extern void XmlSAX2SetDocumentLocator(global::System.IntPtr ctx, global::System.IntPtr loc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2GetLineNumber")]
            internal static extern int XmlSAX2GetLineNumber(global::System.IntPtr ctx);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2GetColumnNumber")]
            internal static extern int XmlSAX2GetColumnNumber(global::System.IntPtr ctx);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2IsStandalone")]
            internal static extern int XmlSAX2IsStandalone(global::System.IntPtr ctx);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2HasInternalSubset")]
            internal static extern int XmlSAX2HasInternalSubset(global::System.IntPtr ctx);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2HasExternalSubset")]
            internal static extern int XmlSAX2HasExternalSubset(global::System.IntPtr ctx);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2InternalSubset")]
            internal static extern void XmlSAX2InternalSubset(global::System.IntPtr ctx, byte* name, byte* ExternalID, byte* SystemID);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2ExternalSubset")]
            internal static extern void XmlSAX2ExternalSubset(global::System.IntPtr ctx, byte* name, byte* ExternalID, byte* SystemID);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2GetEntity")]
            internal static extern global::System.IntPtr XmlSAX2GetEntity(global::System.IntPtr ctx, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2GetParameterEntity")]
            internal static extern global::System.IntPtr XmlSAX2GetParameterEntity(global::System.IntPtr ctx, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2ResolveEntity")]
            internal static extern global::System.IntPtr XmlSAX2ResolveEntity(global::System.IntPtr ctx, byte* publicId, byte* systemId);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2EntityDecl")]
            internal static extern void XmlSAX2EntityDecl(global::System.IntPtr ctx, byte* name, int type, byte* publicId, byte* systemId, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2AttributeDecl")]
            internal static extern void XmlSAX2AttributeDecl(global::System.IntPtr ctx, byte* elem, byte* fullname, int type, int def, byte* defaultValue, global::System.IntPtr tree);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2ElementDecl")]
            internal static extern void XmlSAX2ElementDecl(global::System.IntPtr ctx, byte* name, int type, global::System.IntPtr content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2NotationDecl")]
            internal static extern void XmlSAX2NotationDecl(global::System.IntPtr ctx, byte* name, byte* publicId, byte* systemId);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2UnparsedEntityDecl")]
            internal static extern void XmlSAX2UnparsedEntityDecl(global::System.IntPtr ctx, byte* name, byte* publicId, byte* systemId, byte* notationName);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2StartDocument")]
            internal static extern void XmlSAX2StartDocument(global::System.IntPtr ctx);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2EndDocument")]
            internal static extern void XmlSAX2EndDocument(global::System.IntPtr ctx);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2StartElement")]
            internal static extern void XmlSAX2StartElement(global::System.IntPtr ctx, byte* fullname, byte** atts);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2EndElement")]
            internal static extern void XmlSAX2EndElement(global::System.IntPtr ctx, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2StartElementNs")]
            internal static extern void XmlSAX2StartElementNs(global::System.IntPtr ctx, byte* localname, byte* prefix, byte* URI, int nb_namespaces, byte** namespaces, int nb_attributes, int nb_defaulted, byte** attributes);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2EndElementNs")]
            internal static extern void XmlSAX2EndElementNs(global::System.IntPtr ctx, byte* localname, byte* prefix, byte* URI);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2Reference")]
            internal static extern void XmlSAX2Reference(global::System.IntPtr ctx, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2Characters")]
            internal static extern void XmlSAX2Characters(global::System.IntPtr ctx, byte* ch, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2IgnorableWhitespace")]
            internal static extern void XmlSAX2IgnorableWhitespace(global::System.IntPtr ctx, byte* ch, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2ProcessingInstruction")]
            internal static extern void XmlSAX2ProcessingInstruction(global::System.IntPtr ctx, byte* target, byte* data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2Comment")]
            internal static extern void XmlSAX2Comment(global::System.IntPtr ctx, byte* value);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2CDataBlock")]
            internal static extern void XmlSAX2CDataBlock(global::System.IntPtr ctx, byte* value, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAXDefaultVersion")]
            internal static extern int XmlSAXDefaultVersion(int version);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAXVersion")]
            internal static extern int XmlSAXVersion(global::System.IntPtr hdlr, int version);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2InitDefaultSAXHandler")]
            internal static extern void XmlSAX2InitDefaultSAXHandler(global::System.IntPtr hdlr, int warning);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2InitHtmlDefaultSAXHandler")]
            internal static extern void XmlSAX2InitHtmlDefaultSAXHandler(global::System.IntPtr hdlr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="htmlDefaultSAXHandlerInit")]
            internal static extern void HtmlDefaultSAXHandlerInit();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlSAX2InitDocbDefaultSAXHandler")]
            internal static extern void XmlSAX2InitDocbDefaultSAXHandler(global::System.IntPtr hdlr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="docbDefaultSAXHandlerInit")]
            internal static extern void DocbDefaultSAXHandlerInit();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDefaultSAXHandlerInit")]
            internal static extern void XmlDefaultSAXHandlerInit();
        }

        public static byte* XmlSAX2GetPublicId(global::System.IntPtr ctx)
        {
            var __ret = __Internal.XmlSAX2GetPublicId(ctx);
            return __ret;
        }

        public static byte* XmlSAX2GetSystemId(global::System.IntPtr ctx)
        {
            var __ret = __Internal.XmlSAX2GetSystemId(ctx);
            return __ret;
        }

        public static void XmlSAX2SetDocumentLocator(global::System.IntPtr ctx, global::libxml.XmlSAXLocator loc)
        {
            var __arg1 = ReferenceEquals(loc, null) ? global::System.IntPtr.Zero : loc.__Instance;
            __Internal.XmlSAX2SetDocumentLocator(ctx, __arg1);
        }

        public static int XmlSAX2GetLineNumber(global::System.IntPtr ctx)
        {
            var __ret = __Internal.XmlSAX2GetLineNumber(ctx);
            return __ret;
        }

        public static int XmlSAX2GetColumnNumber(global::System.IntPtr ctx)
        {
            var __ret = __Internal.XmlSAX2GetColumnNumber(ctx);
            return __ret;
        }

        public static int XmlSAX2IsStandalone(global::System.IntPtr ctx)
        {
            var __ret = __Internal.XmlSAX2IsStandalone(ctx);
            return __ret;
        }

        public static int XmlSAX2HasInternalSubset(global::System.IntPtr ctx)
        {
            var __ret = __Internal.XmlSAX2HasInternalSubset(ctx);
            return __ret;
        }

        public static int XmlSAX2HasExternalSubset(global::System.IntPtr ctx)
        {
            var __ret = __Internal.XmlSAX2HasExternalSubset(ctx);
            return __ret;
        }

        public static void XmlSAX2InternalSubset(global::System.IntPtr ctx, byte* name, byte* ExternalID, byte* SystemID)
        {
            __Internal.XmlSAX2InternalSubset(ctx, name, ExternalID, SystemID);
        }

        public static void XmlSAX2ExternalSubset(global::System.IntPtr ctx, byte* name, byte* ExternalID, byte* SystemID)
        {
            __Internal.XmlSAX2ExternalSubset(ctx, name, ExternalID, SystemID);
        }

        public static global::libxml.XmlEntity XmlSAX2GetEntity(global::System.IntPtr ctx, byte* name)
        {
            var __ret = __Internal.XmlSAX2GetEntity(ctx, name);
            global::libxml.XmlEntity __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlEntity.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlEntity) global::libxml.XmlEntity.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlEntity.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlEntity XmlSAX2GetParameterEntity(global::System.IntPtr ctx, byte* name)
        {
            var __ret = __Internal.XmlSAX2GetParameterEntity(ctx, name);
            global::libxml.XmlEntity __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlEntity.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlEntity) global::libxml.XmlEntity.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlEntity.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlParserInput XmlSAX2ResolveEntity(global::System.IntPtr ctx, byte* publicId, byte* systemId)
        {
            var __ret = __Internal.XmlSAX2ResolveEntity(ctx, publicId, systemId);
            global::libxml.XmlParserInput __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlParserInput.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlParserInput) global::libxml.XmlParserInput.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlParserInput.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlSAX2EntityDecl(global::System.IntPtr ctx, byte* name, int type, byte* publicId, byte* systemId, byte* content)
        {
            __Internal.XmlSAX2EntityDecl(ctx, name, type, publicId, systemId, content);
        }

        public static void XmlSAX2AttributeDecl(global::System.IntPtr ctx, byte* elem, byte* fullname, int type, int def, byte* defaultValue, global::libxml.XmlEnumeration tree)
        {
            var __arg6 = ReferenceEquals(tree, null) ? global::System.IntPtr.Zero : tree.__Instance;
            __Internal.XmlSAX2AttributeDecl(ctx, elem, fullname, type, def, defaultValue, __arg6);
        }

        public static void XmlSAX2ElementDecl(global::System.IntPtr ctx, byte* name, int type, global::libxml.XmlElementContent content)
        {
            var __arg3 = ReferenceEquals(content, null) ? global::System.IntPtr.Zero : content.__Instance;
            __Internal.XmlSAX2ElementDecl(ctx, name, type, __arg3);
        }

        public static void XmlSAX2NotationDecl(global::System.IntPtr ctx, byte* name, byte* publicId, byte* systemId)
        {
            __Internal.XmlSAX2NotationDecl(ctx, name, publicId, systemId);
        }

        public static void XmlSAX2UnparsedEntityDecl(global::System.IntPtr ctx, byte* name, byte* publicId, byte* systemId, byte* notationName)
        {
            __Internal.XmlSAX2UnparsedEntityDecl(ctx, name, publicId, systemId, notationName);
        }

        public static void XmlSAX2StartDocument(global::System.IntPtr ctx)
        {
            __Internal.XmlSAX2StartDocument(ctx);
        }

        public static void XmlSAX2EndDocument(global::System.IntPtr ctx)
        {
            __Internal.XmlSAX2EndDocument(ctx);
        }

        public static void XmlSAX2StartElement(global::System.IntPtr ctx, byte* fullname, byte** atts)
        {
            __Internal.XmlSAX2StartElement(ctx, fullname, atts);
        }

        public static void XmlSAX2EndElement(global::System.IntPtr ctx, byte* name)
        {
            __Internal.XmlSAX2EndElement(ctx, name);
        }

        public static void XmlSAX2StartElementNs(global::System.IntPtr ctx, byte* localname, byte* prefix, byte* URI, int nb_namespaces, byte** namespaces, int nb_attributes, int nb_defaulted, byte** attributes)
        {
            __Internal.XmlSAX2StartElementNs(ctx, localname, prefix, URI, nb_namespaces, namespaces, nb_attributes, nb_defaulted, attributes);
        }

        public static void XmlSAX2EndElementNs(global::System.IntPtr ctx, byte* localname, byte* prefix, byte* URI)
        {
            __Internal.XmlSAX2EndElementNs(ctx, localname, prefix, URI);
        }

        public static void XmlSAX2Reference(global::System.IntPtr ctx, byte* name)
        {
            __Internal.XmlSAX2Reference(ctx, name);
        }

        public static void XmlSAX2Characters(global::System.IntPtr ctx, byte* ch, int len)
        {
            __Internal.XmlSAX2Characters(ctx, ch, len);
        }

        public static void XmlSAX2IgnorableWhitespace(global::System.IntPtr ctx, byte* ch, int len)
        {
            __Internal.XmlSAX2IgnorableWhitespace(ctx, ch, len);
        }

        public static void XmlSAX2ProcessingInstruction(global::System.IntPtr ctx, byte* target, byte* data)
        {
            __Internal.XmlSAX2ProcessingInstruction(ctx, target, data);
        }

        public static void XmlSAX2Comment(global::System.IntPtr ctx, byte* value)
        {
            __Internal.XmlSAX2Comment(ctx, value);
        }

        public static void XmlSAX2CDataBlock(global::System.IntPtr ctx, byte* value, int len)
        {
            __Internal.XmlSAX2CDataBlock(ctx, value, len);
        }

        public static int XmlSAXDefaultVersion(int version)
        {
            var __ret = __Internal.XmlSAXDefaultVersion(version);
            return __ret;
        }

        public static int XmlSAXVersion(global::libxml.XmlSAXHandler hdlr, int version)
        {
            var __arg0 = ReferenceEquals(hdlr, null) ? global::System.IntPtr.Zero : hdlr.__Instance;
            var __ret = __Internal.XmlSAXVersion(__arg0, version);
            return __ret;
        }

        public static void XmlSAX2InitDefaultSAXHandler(global::libxml.XmlSAXHandler hdlr, int warning)
        {
            var __arg0 = ReferenceEquals(hdlr, null) ? global::System.IntPtr.Zero : hdlr.__Instance;
            __Internal.XmlSAX2InitDefaultSAXHandler(__arg0, warning);
        }

        public static void XmlSAX2InitHtmlDefaultSAXHandler(global::libxml.XmlSAXHandler hdlr)
        {
            var __arg0 = ReferenceEquals(hdlr, null) ? global::System.IntPtr.Zero : hdlr.__Instance;
            __Internal.XmlSAX2InitHtmlDefaultSAXHandler(__arg0);
        }

        public static void HtmlDefaultSAXHandlerInit()
        {
            __Internal.HtmlDefaultSAXHandlerInit();
        }

        public static void XmlSAX2InitDocbDefaultSAXHandler(global::libxml.XmlSAXHandler hdlr)
        {
            var __arg0 = ReferenceEquals(hdlr, null) ? global::System.IntPtr.Zero : hdlr.__Instance;
            __Internal.XmlSAX2InitDocbDefaultSAXHandler(__arg0);
        }

        public static void DocbDefaultSAXHandlerInit()
        {
            __Internal.DocbDefaultSAXHandlerInit();
        }

        public static void XmlDefaultSAXHandlerInit()
        {
            __Internal.XmlDefaultSAXHandlerInit();
        }
    }

    /// <summary>
    /// <para>xmlFreeFunc:</para>
    /// <para>an already allocated block of memory</para>
    /// </summary>
    /// <remarks>Signature for a free() implementation.</remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate void XmlFreeFunc(global::System.IntPtr mem);

    /// <summary>
    /// <para>xmlReallocFunc:</para>
    /// <para>an already allocated block of memory</para>
    /// <para>the new size requested in bytes</para>
    /// </summary>
    /// <remarks>
    /// <para>Signature for a realloc() implementation.</para>
    /// <para>Returns a pointer to the newly reallocated block or NULL in case of error.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate global::System.IntPtr XmlReallocFunc(global::System.IntPtr mem, uint size);

    /// <summary>
    /// <para>xmlStrdupFunc:</para>
    /// <para>a zero terminated string</para>
    /// </summary>
    /// <remarks>
    /// <para>Signature for an strdup() implementation.</para>
    /// <para>Returns the copy of the string or NULL in case of error.</para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public unsafe delegate sbyte* XmlStrdupFunc([MarshalAs(UnmanagedType.LPUTF8Str)] string str);

    public unsafe partial class xmlmemory
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlMemSetup")]
            internal static extern int XmlMemSetup(global::System.IntPtr freeFunc, global::System.IntPtr mallocFunc, global::System.IntPtr reallocFunc, global::System.IntPtr strdupFunc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlMemGet")]
            internal static extern int XmlMemGet(global::System.IntPtr freeFunc, global::System.IntPtr mallocFunc, global::System.IntPtr reallocFunc, global::System.IntPtr strdupFunc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGcMemSetup")]
            internal static extern int XmlGcMemSetup(global::System.IntPtr freeFunc, global::System.IntPtr mallocFunc, global::System.IntPtr mallocAtomicFunc, global::System.IntPtr reallocFunc, global::System.IntPtr strdupFunc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGcMemGet")]
            internal static extern int XmlGcMemGet(global::System.IntPtr freeFunc, global::System.IntPtr mallocFunc, global::System.IntPtr mallocAtomicFunc, global::System.IntPtr reallocFunc, global::System.IntPtr strdupFunc);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlInitMemory")]
            internal static extern int XmlInitMemory();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCleanupMemory")]
            internal static extern void XmlCleanupMemory();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlMemUsed")]
            internal static extern int XmlMemUsed();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlMemBlocks")]
            internal static extern int XmlMemBlocks();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlMemDisplay")]
            internal static extern void XmlMemDisplay(global::System.IntPtr fp);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlMemDisplayLast")]
            internal static extern void XmlMemDisplayLast(global::System.IntPtr fp, int nbBytes);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlMemShow")]
            internal static extern void XmlMemShow(global::System.IntPtr fp, int nr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlMemoryDump")]
            internal static extern void XmlMemoryDump();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlMemMalloc")]
            internal static extern global::System.IntPtr XmlMemMalloc(uint size);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlMemRealloc")]
            internal static extern global::System.IntPtr XmlMemRealloc(global::System.IntPtr ptr, uint size);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlMemFree")]
            internal static extern void XmlMemFree(global::System.IntPtr ptr);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlMemoryStrdup")]
            internal static extern sbyte* XmlMemoryStrdup([MarshalAs(UnmanagedType.LPUTF8Str)] string str);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlMallocLoc")]
            internal static extern global::System.IntPtr XmlMallocLoc(uint size, [MarshalAs(UnmanagedType.LPUTF8Str)] string file, int line);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlReallocLoc")]
            internal static extern global::System.IntPtr XmlReallocLoc(global::System.IntPtr ptr, uint size, [MarshalAs(UnmanagedType.LPUTF8Str)] string file, int line);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlMallocAtomicLoc")]
            internal static extern global::System.IntPtr XmlMallocAtomicLoc(uint size, [MarshalAs(UnmanagedType.LPUTF8Str)] string file, int line);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlMemStrdupLoc")]
            internal static extern sbyte* XmlMemStrdupLoc([MarshalAs(UnmanagedType.LPUTF8Str)] string str, [MarshalAs(UnmanagedType.LPUTF8Str)] string file, int line);
        }

        public static int XmlMemSetup(global::libxml.XmlFreeFunc freeFunc, global::libxml.XmlMallocFunc mallocFunc, global::libxml.XmlReallocFunc reallocFunc, global::libxml.XmlStrdupFunc strdupFunc)
        {
            var __arg0 = freeFunc == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(freeFunc);
            var __arg1 = mallocFunc == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(mallocFunc);
            var __arg2 = reallocFunc == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(reallocFunc);
            var __arg3 = strdupFunc == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(strdupFunc);
            var __ret = __Internal.XmlMemSetup(__arg0, __arg1, __arg2, __arg3);
            return __ret;
        }

        public static int XmlMemGet(global::libxml.XmlFreeFunc freeFunc, global::libxml.XmlMallocFunc mallocFunc, global::libxml.XmlReallocFunc reallocFunc, global::libxml.XmlStrdupFunc strdupFunc)
        {
            var __arg0 = freeFunc == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(freeFunc);
            var __arg1 = mallocFunc == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(mallocFunc);
            var __arg2 = reallocFunc == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(reallocFunc);
            var __arg3 = strdupFunc == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(strdupFunc);
            var __ret = __Internal.XmlMemGet(__arg0, __arg1, __arg2, __arg3);
            return __ret;
        }

        public static int XmlGcMemSetup(global::libxml.XmlFreeFunc freeFunc, global::libxml.XmlMallocFunc mallocFunc, global::libxml.XmlMallocFunc mallocAtomicFunc, global::libxml.XmlReallocFunc reallocFunc, global::libxml.XmlStrdupFunc strdupFunc)
        {
            var __arg0 = freeFunc == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(freeFunc);
            var __arg1 = mallocFunc == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(mallocFunc);
            var __arg2 = mallocAtomicFunc == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(mallocAtomicFunc);
            var __arg3 = reallocFunc == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(reallocFunc);
            var __arg4 = strdupFunc == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(strdupFunc);
            var __ret = __Internal.XmlGcMemSetup(__arg0, __arg1, __arg2, __arg3, __arg4);
            return __ret;
        }

        public static int XmlGcMemGet(global::libxml.XmlFreeFunc freeFunc, global::libxml.XmlMallocFunc mallocFunc, global::libxml.XmlMallocFunc mallocAtomicFunc, global::libxml.XmlReallocFunc reallocFunc, global::libxml.XmlStrdupFunc strdupFunc)
        {
            var __arg0 = freeFunc == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(freeFunc);
            var __arg1 = mallocFunc == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(mallocFunc);
            var __arg2 = mallocAtomicFunc == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(mallocAtomicFunc);
            var __arg3 = reallocFunc == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(reallocFunc);
            var __arg4 = strdupFunc == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(strdupFunc);
            var __ret = __Internal.XmlGcMemGet(__arg0, __arg1, __arg2, __arg3, __arg4);
            return __ret;
        }

        public static int XmlInitMemory()
        {
            var __ret = __Internal.XmlInitMemory();
            return __ret;
        }

        public static void XmlCleanupMemory()
        {
            __Internal.XmlCleanupMemory();
        }

        public static int XmlMemUsed()
        {
            var __ret = __Internal.XmlMemUsed();
            return __ret;
        }

        public static int XmlMemBlocks()
        {
            var __ret = __Internal.XmlMemBlocks();
            return __ret;
        }

        public static void XmlMemDisplay(global::System.IntPtr fp)
        {
            __Internal.XmlMemDisplay(fp);
        }

        public static void XmlMemDisplayLast(global::System.IntPtr fp, int nbBytes)
        {
            __Internal.XmlMemDisplayLast(fp, nbBytes);
        }

        public static void XmlMemShow(global::System.IntPtr fp, int nr)
        {
            __Internal.XmlMemShow(fp, nr);
        }

        public static void XmlMemoryDump()
        {
            __Internal.XmlMemoryDump();
        }

        public static global::System.IntPtr XmlMemMalloc(uint size)
        {
            var __ret = __Internal.XmlMemMalloc(size);
            return __ret;
        }

        public static global::System.IntPtr XmlMemRealloc(global::System.IntPtr ptr, uint size)
        {
            var __ret = __Internal.XmlMemRealloc(ptr, size);
            return __ret;
        }

        public static void XmlMemFree(global::System.IntPtr ptr)
        {
            __Internal.XmlMemFree(ptr);
        }

        public static sbyte* XmlMemoryStrdup(string str)
        {
            var __ret = __Internal.XmlMemoryStrdup(str);
            return __ret;
        }

        public static global::System.IntPtr XmlMallocLoc(uint size, string file, int line)
        {
            var __ret = __Internal.XmlMallocLoc(size, file, line);
            return __ret;
        }

        public static global::System.IntPtr XmlReallocLoc(global::System.IntPtr ptr, uint size, string file, int line)
        {
            var __ret = __Internal.XmlReallocLoc(ptr, size, file, line);
            return __ret;
        }

        public static global::System.IntPtr XmlMallocAtomicLoc(uint size, string file, int line)
        {
            var __ret = __Internal.XmlMallocAtomicLoc(size, file, line);
            return __ret;
        }

        public static sbyte* XmlMemStrdupLoc(string str, string file, int line)
        {
            var __ret = __Internal.XmlMemStrdupLoc(str, file, line);
            return __ret;
        }
    }

    public unsafe partial class XmlMutex
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public partial struct __Internal
        {
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlMutex> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlMutex>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlMutex __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlMutex(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlMutex __CreateInstance(global::libxml.XmlMutex.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlMutex(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlMutex.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlMutex.__Internal));
            *(global::libxml.XmlMutex.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlMutex(global::libxml.XmlMutex.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlMutex(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }
    }

    public unsafe partial class XmlRMutex
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public partial struct __Internal
        {
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlRMutex> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlRMutex>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlRMutex __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlRMutex(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlRMutex __CreateInstance(global::libxml.XmlRMutex.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlRMutex(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlRMutex.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlRMutex.__Internal));
            *(global::libxml.XmlRMutex.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlRMutex(global::libxml.XmlRMutex.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlRMutex(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }
    }

    public unsafe partial class threads
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewMutex")]
            internal static extern global::System.IntPtr XmlNewMutex();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlMutexLock")]
            internal static extern void XmlMutexLock(global::System.IntPtr tok);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlMutexUnlock")]
            internal static extern void XmlMutexUnlock(global::System.IntPtr tok);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlFreeMutex")]
            internal static extern void XmlFreeMutex(global::System.IntPtr tok);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewRMutex")]
            internal static extern global::System.IntPtr XmlNewRMutex();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlRMutexLock")]
            internal static extern void XmlRMutexLock(global::System.IntPtr tok);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlRMutexUnlock")]
            internal static extern void XmlRMutexUnlock(global::System.IntPtr tok);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlFreeRMutex")]
            internal static extern void XmlFreeRMutex(global::System.IntPtr tok);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlInitThreads")]
            internal static extern void XmlInitThreads();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlLockLibrary")]
            internal static extern void XmlLockLibrary();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlUnlockLibrary")]
            internal static extern void XmlUnlockLibrary();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetThreadId")]
            internal static extern int XmlGetThreadId();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlIsMainThread")]
            internal static extern int XmlIsMainThread();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCleanupThreads")]
            internal static extern void XmlCleanupThreads();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlGetGlobalState")]
            internal static extern global::System.IntPtr XmlGetGlobalState();
        }

        public static global::libxml.XmlMutex XmlNewMutex()
        {
            var __ret = __Internal.XmlNewMutex();
            global::libxml.XmlMutex __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlMutex.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlMutex) global::libxml.XmlMutex.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlMutex.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlMutexLock(global::libxml.XmlMutex tok)
        {
            var __arg0 = ReferenceEquals(tok, null) ? global::System.IntPtr.Zero : tok.__Instance;
            __Internal.XmlMutexLock(__arg0);
        }

        public static void XmlMutexUnlock(global::libxml.XmlMutex tok)
        {
            var __arg0 = ReferenceEquals(tok, null) ? global::System.IntPtr.Zero : tok.__Instance;
            __Internal.XmlMutexUnlock(__arg0);
        }

        public static void XmlFreeMutex(global::libxml.XmlMutex tok)
        {
            var __arg0 = ReferenceEquals(tok, null) ? global::System.IntPtr.Zero : tok.__Instance;
            __Internal.XmlFreeMutex(__arg0);
        }

        public static global::libxml.XmlRMutex XmlNewRMutex()
        {
            var __ret = __Internal.XmlNewRMutex();
            global::libxml.XmlRMutex __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlRMutex.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlRMutex) global::libxml.XmlRMutex.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlRMutex.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlRMutexLock(global::libxml.XmlRMutex tok)
        {
            var __arg0 = ReferenceEquals(tok, null) ? global::System.IntPtr.Zero : tok.__Instance;
            __Internal.XmlRMutexLock(__arg0);
        }

        public static void XmlRMutexUnlock(global::libxml.XmlRMutex tok)
        {
            var __arg0 = ReferenceEquals(tok, null) ? global::System.IntPtr.Zero : tok.__Instance;
            __Internal.XmlRMutexUnlock(__arg0);
        }

        public static void XmlFreeRMutex(global::libxml.XmlRMutex tok)
        {
            var __arg0 = ReferenceEquals(tok, null) ? global::System.IntPtr.Zero : tok.__Instance;
            __Internal.XmlFreeRMutex(__arg0);
        }

        public static void XmlInitThreads()
        {
            __Internal.XmlInitThreads();
        }

        public static void XmlLockLibrary()
        {
            __Internal.XmlLockLibrary();
        }

        public static void XmlUnlockLibrary()
        {
            __Internal.XmlUnlockLibrary();
        }

        public static int XmlGetThreadId()
        {
            var __ret = __Internal.XmlGetThreadId();
            return __ret;
        }

        public static int XmlIsMainThread()
        {
            var __ret = __Internal.XmlIsMainThread();
            return __ret;
        }

        public static void XmlCleanupThreads()
        {
            __Internal.XmlCleanupThreads();
        }

        public static global::libxml.XmlGlobalState XmlGetGlobalState()
        {
            var __ret = __Internal.XmlGetGlobalState();
            global::libxml.XmlGlobalState __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlGlobalState.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlGlobalState) global::libxml.XmlGlobalState.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlGlobalState.__CreateInstance(__ret);
            return __result0;
        }
    }

    namespace Delegates
    {
        [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public unsafe delegate byte* Func_bytePtr_IntPtr(global::System.IntPtr ctx);

        [SuppressUnmanagedCodeSecurity, UnmanagedFunctionPointer(global::System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public unsafe delegate int Func_int_IntPtr(global::System.IntPtr ctx);
    }
}
