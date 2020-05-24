using System;
using System.Runtime.InteropServices;
using System.Security;

namespace libxml
{
    public unsafe partial class XmlBuffer : IDisposable
    {
        private const string lib = "/usr/local/Cellar/libxml2/2.9.9_2/lib/libxml2.2.dylib";

        [StructLayout(LayoutKind.Explicit, Size = 20)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr content;

            [FieldOffset(4)]
            internal uint use;

            [FieldOffset(8)]
            internal uint size;

            [FieldOffset(12)]
            internal global::libxml.XmlBufferAllocationScheme alloc;

            [FieldOffset(16)]
            internal global::System.IntPtr contentIO;

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN10_xmlBufferC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlBuffer> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlBuffer>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlBuffer __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlBuffer(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlBuffer __CreateInstance(global::libxml.XmlBuffer.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlBuffer(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlBuffer.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlBuffer.__Internal));
            *(global::libxml.XmlBuffer.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlBuffer(global::libxml.XmlBuffer.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlBuffer(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlBuffer()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlBuffer.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlBuffer(global::libxml.XmlBuffer _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlBuffer.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlBuffer.__Internal*) __Instance) = *((global::libxml.XmlBuffer.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlBuffer __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public byte* Content
        {
            get
            {
                return (byte*) ((global::libxml.XmlBuffer.__Internal*) __Instance)->content;
            }

            set
            {
                ((global::libxml.XmlBuffer.__Internal*)__Instance)->content = (global::System.IntPtr) value;
            }
        }

        public uint Use
        {
            get
            {
                return ((global::libxml.XmlBuffer.__Internal*) __Instance)->use;
            }

            set
            {
                ((global::libxml.XmlBuffer.__Internal*)__Instance)->use = value;
            }
        }

        public uint Size
        {
            get
            {
                return ((global::libxml.XmlBuffer.__Internal*) __Instance)->size;
            }

            set
            {
                ((global::libxml.XmlBuffer.__Internal*)__Instance)->size = value;
            }
        }

        public global::libxml.XmlBufferAllocationScheme Alloc
        {
            get
            {
                return ((global::libxml.XmlBuffer.__Internal*) __Instance)->alloc;
            }

            set
            {
                ((global::libxml.XmlBuffer.__Internal*)__Instance)->alloc = value;
            }
        }

        public byte* ContentIO
        {
            get
            {
                return (byte*) ((global::libxml.XmlBuffer.__Internal*) __Instance)->contentIO;
            }

            set
            {
                ((global::libxml.XmlBuffer.__Internal*)__Instance)->contentIO = (global::System.IntPtr) value;
            }
        }
    }
}