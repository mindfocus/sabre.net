using System;
using System.Runtime.InteropServices;

namespace libxml
{
    public unsafe partial class XmlAutomataState
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public partial struct __Internal
        {
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlAutomataState> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlAutomataState>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlAutomataState __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlAutomataState(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlAutomataState __CreateInstance(global::libxml.XmlAutomataState.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlAutomataState(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlAutomataState.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlAutomataState.__Internal));
            *(global::libxml.XmlAutomataState.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlAutomataState(global::libxml.XmlAutomataState.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlAutomataState(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }
    }
}