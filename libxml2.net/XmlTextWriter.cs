using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace libxml
{
    public unsafe class XmlTextWriter
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public struct __Internal
        {
        }

        public IntPtr __Instance { get; protected set; }

        internal static readonly ConcurrentDictionary<IntPtr, XmlTextWriter> NativeToManagedMap = new ConcurrentDictionary<IntPtr, XmlTextWriter>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static XmlTextWriter __CreateInstance(IntPtr native, bool skipVTables = false)
        {
            return new XmlTextWriter(native.ToPointer(), skipVTables);
        }

        internal static XmlTextWriter __CreateInstance(__Internal native, bool skipVTables = false)
        {
            return new XmlTextWriter(native, skipVTables);
        }

        private static void* __CopyValue(__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(__Internal));
            *(__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlTextWriter(__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlTextWriter(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new IntPtr(native);
        }
    }
}