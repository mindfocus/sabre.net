using System;
using System.Runtime.InteropServices;

namespace libxml
{
    public unsafe partial class XmlValidState
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public partial struct __Internal
        {
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlValidState> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlValidState>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlValidState __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlValidState(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlValidState __CreateInstance(global::libxml.XmlValidState.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlValidState(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlValidState.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlValidState.__Internal));
            *(global::libxml.XmlValidState.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlValidState(global::libxml.XmlValidState.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlValidState(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }
    }
}