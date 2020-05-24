using System;
using System.Runtime.InteropServices;
using System.Security;

namespace libxml
{
    public unsafe partial class XmlCharEncodingHandler : IDisposable
    {
        private const string lib = "/usr/local/Cellar/libxml2/2.9.9_2/lib/libxml2.2.dylib";

        [StructLayout(LayoutKind.Explicit, Size = 20)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr name;

            [FieldOffset(4)]
            internal global::System.IntPtr input;

            [FieldOffset(8)]
            internal global::System.IntPtr output;

            [FieldOffset(12)]
            internal global::System.IntPtr iconv_in;

            [FieldOffset(16)]
            internal global::System.IntPtr iconv_out;

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN23_xmlCharEncodingHandlerC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlCharEncodingHandler> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlCharEncodingHandler>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlCharEncodingHandler __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlCharEncodingHandler(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlCharEncodingHandler __CreateInstance(global::libxml.XmlCharEncodingHandler.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlCharEncodingHandler(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlCharEncodingHandler.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlCharEncodingHandler.__Internal));
            *(global::libxml.XmlCharEncodingHandler.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlCharEncodingHandler(global::libxml.XmlCharEncodingHandler.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlCharEncodingHandler(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlCharEncodingHandler()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlCharEncodingHandler.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlCharEncodingHandler(global::libxml.XmlCharEncodingHandler _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlCharEncodingHandler.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlCharEncodingHandler.__Internal*) __Instance) = *((global::libxml.XmlCharEncodingHandler.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlCharEncodingHandler __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public sbyte* Name
        {
            get
            {
                return (sbyte*) ((global::libxml.XmlCharEncodingHandler.__Internal*) __Instance)->name;
            }

            set
            {
                ((global::libxml.XmlCharEncodingHandler.__Internal*)__Instance)->name = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlCharEncodingInputFunc Input
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlCharEncodingHandler.__Internal*) __Instance)->input;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlCharEncodingInputFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlCharEncodingInputFunc));
            }

            set
            {
                ((global::libxml.XmlCharEncodingHandler.__Internal*)__Instance)->input = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.XmlCharEncodingOutputFunc Output
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlCharEncodingHandler.__Internal*) __Instance)->output;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlCharEncodingOutputFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlCharEncodingOutputFunc));
            }

            set
            {
                ((global::libxml.XmlCharEncodingHandler.__Internal*)__Instance)->output = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::System.IntPtr IconvIn
        {
            get
            {
                return ((global::libxml.XmlCharEncodingHandler.__Internal*) __Instance)->iconv_in;
            }

            set
            {
                ((global::libxml.XmlCharEncodingHandler.__Internal*)__Instance)->iconv_in = (global::System.IntPtr) value;
            }
        }

        public global::System.IntPtr IconvOut
        {
            get
            {
                return ((global::libxml.XmlCharEncodingHandler.__Internal*) __Instance)->iconv_out;
            }

            set
            {
                ((global::libxml.XmlCharEncodingHandler.__Internal*)__Instance)->iconv_out = (global::System.IntPtr) value;
            }
        }
    }
}