using System;
using System.Runtime.InteropServices;
using System.Security;

namespace libxml
{
    public unsafe partial class XmlOutputBuffer : IDisposable
    {
        private const string lib = "/usr/local/Cellar/libxml2/2.9.9_2/lib/libxml2.2.dylib";
        [StructLayout(LayoutKind.Explicit, Size = 32)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr context;

            [FieldOffset(4)]
            internal global::System.IntPtr writecallback;

            [FieldOffset(8)]
            internal global::System.IntPtr closecallback;

            [FieldOffset(12)]
            internal global::System.IntPtr encoder;

            [FieldOffset(16)]
            internal global::System.IntPtr buffer;

            [FieldOffset(20)]
            internal global::System.IntPtr conv;

            [FieldOffset(24)]
            internal int written;

            [FieldOffset(28)]
            internal int error;

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN16_xmlOutputBufferC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlOutputBuffer> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlOutputBuffer>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlOutputBuffer __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlOutputBuffer(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlOutputBuffer __CreateInstance(global::libxml.XmlOutputBuffer.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlOutputBuffer(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlOutputBuffer.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlOutputBuffer.__Internal));
            *(global::libxml.XmlOutputBuffer.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlOutputBuffer(global::libxml.XmlOutputBuffer.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlOutputBuffer(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlOutputBuffer()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlOutputBuffer.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlOutputBuffer(global::libxml.XmlOutputBuffer _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlOutputBuffer.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlOutputBuffer.__Internal*) __Instance) = *((global::libxml.XmlOutputBuffer.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlOutputBuffer __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public global::System.IntPtr Context
        {
            get
            {
                return ((global::libxml.XmlOutputBuffer.__Internal*) __Instance)->context;
            }

            set
            {
                ((global::libxml.XmlOutputBuffer.__Internal*)__Instance)->context = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlOutputWriteCallback Writecallback
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlOutputBuffer.__Internal*) __Instance)->writecallback;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlOutputWriteCallback) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlOutputWriteCallback));
            }

            set
            {
                ((global::libxml.XmlOutputBuffer.__Internal*)__Instance)->writecallback = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.XmlOutputCloseCallback Closecallback
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlOutputBuffer.__Internal*) __Instance)->closecallback;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlOutputCloseCallback) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlOutputCloseCallback));
            }

            set
            {
                ((global::libxml.XmlOutputBuffer.__Internal*)__Instance)->closecallback = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.XmlCharEncodingHandler Encoder
        {
            get
            {
                global::libxml.XmlCharEncodingHandler __result0;
                if (((global::libxml.XmlOutputBuffer.__Internal*) __Instance)->encoder == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlCharEncodingHandler.NativeToManagedMap.ContainsKey(((global::libxml.XmlOutputBuffer.__Internal*) __Instance)->encoder))
                    __result0 = (global::libxml.XmlCharEncodingHandler) global::libxml.XmlCharEncodingHandler.NativeToManagedMap[((global::libxml.XmlOutputBuffer.__Internal*) __Instance)->encoder];
                else __result0 = global::libxml.XmlCharEncodingHandler.__CreateInstance(((global::libxml.XmlOutputBuffer.__Internal*) __Instance)->encoder);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlOutputBuffer.__Internal*)__Instance)->encoder = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlBuf Buffer
        {
            get
            {
                global::libxml.XmlBuf __result0;
                if (((global::libxml.XmlOutputBuffer.__Internal*) __Instance)->buffer == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlBuf.NativeToManagedMap.ContainsKey(((global::libxml.XmlOutputBuffer.__Internal*) __Instance)->buffer))
                    __result0 = (global::libxml.XmlBuf) global::libxml.XmlBuf.NativeToManagedMap[((global::libxml.XmlOutputBuffer.__Internal*) __Instance)->buffer];
                else __result0 = global::libxml.XmlBuf.__CreateInstance(((global::libxml.XmlOutputBuffer.__Internal*) __Instance)->buffer);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlOutputBuffer.__Internal*)__Instance)->buffer = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlBuf Conv
        {
            get
            {
                global::libxml.XmlBuf __result0;
                if (((global::libxml.XmlOutputBuffer.__Internal*) __Instance)->conv == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlBuf.NativeToManagedMap.ContainsKey(((global::libxml.XmlOutputBuffer.__Internal*) __Instance)->conv))
                    __result0 = (global::libxml.XmlBuf) global::libxml.XmlBuf.NativeToManagedMap[((global::libxml.XmlOutputBuffer.__Internal*) __Instance)->conv];
                else __result0 = global::libxml.XmlBuf.__CreateInstance(((global::libxml.XmlOutputBuffer.__Internal*) __Instance)->conv);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlOutputBuffer.__Internal*)__Instance)->conv = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public int Written
        {
            get
            {
                return ((global::libxml.XmlOutputBuffer.__Internal*) __Instance)->written;
            }

            set
            {
                ((global::libxml.XmlOutputBuffer.__Internal*)__Instance)->written = value;
            }
        }

        public int Error
        {
            get
            {
                return ((global::libxml.XmlOutputBuffer.__Internal*) __Instance)->error;
            }

            set
            {
                ((global::libxml.XmlOutputBuffer.__Internal*)__Instance)->error = value;
            }
        }
    }
}