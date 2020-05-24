using System;
using System.Runtime.InteropServices;
using System.Security;

namespace libxml
{
    public unsafe partial class XmlValidCtxt : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 64)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr userData;

            [FieldOffset(4)]
            internal global::System.IntPtr error;

            [FieldOffset(8)]
            internal global::System.IntPtr warning;

            [FieldOffset(12)]
            internal global::System.IntPtr node;

            [FieldOffset(16)]
            internal int nodeNr;

            [FieldOffset(20)]
            internal int nodeMax;

            [FieldOffset(24)]
            internal global::System.IntPtr nodeTab;

            [FieldOffset(28)]
            internal uint finishDtd;

            [FieldOffset(32)]
            internal global::System.IntPtr doc;

            [FieldOffset(36)]
            internal int valid;

            [FieldOffset(40)]
            internal global::System.IntPtr vstate;

            [FieldOffset(44)]
            internal int vstateNr;

            [FieldOffset(48)]
            internal int vstateMax;

            [FieldOffset(52)]
            internal global::System.IntPtr vstateTab;

            [FieldOffset(56)]
            internal global::System.IntPtr am;

            [FieldOffset(60)]
            internal global::System.IntPtr state;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN13_xmlValidCtxtC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlValidCtxt> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlValidCtxt>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlValidCtxt __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlValidCtxt(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlValidCtxt __CreateInstance(global::libxml.XmlValidCtxt.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlValidCtxt(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlValidCtxt.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlValidCtxt.__Internal));
            *(global::libxml.XmlValidCtxt.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlValidCtxt(global::libxml.XmlValidCtxt.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlValidCtxt(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlValidCtxt()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlValidCtxt.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlValidCtxt(global::libxml.XmlValidCtxt _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlValidCtxt.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlValidCtxt.__Internal*) __Instance) = *((global::libxml.XmlValidCtxt.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlValidCtxt __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public global::System.IntPtr UserData
        {
            get
            {
                return ((global::libxml.XmlValidCtxt.__Internal*) __Instance)->userData;
            }

            set
            {
                ((global::libxml.XmlValidCtxt.__Internal*)__Instance)->userData = (global::System.IntPtr) value;
            }
        }

        public global::libxml.XmlValidityErrorFunc Error
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlValidCtxt.__Internal*) __Instance)->error;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlValidityErrorFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlValidityErrorFunc));
            }

            set
            {
                ((global::libxml.XmlValidCtxt.__Internal*)__Instance)->error = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.XmlValidityWarningFunc Warning
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlValidCtxt.__Internal*) __Instance)->warning;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlValidityWarningFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlValidityWarningFunc));
            }

            set
            {
                ((global::libxml.XmlValidCtxt.__Internal*)__Instance)->warning = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.XmlNode Node
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlValidCtxt.__Internal*) __Instance)->node == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlValidCtxt.__Internal*) __Instance)->node))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlValidCtxt.__Internal*) __Instance)->node];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlValidCtxt.__Internal*) __Instance)->node);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlValidCtxt.__Internal*)__Instance)->node = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public int NodeNr
        {
            get
            {
                return ((global::libxml.XmlValidCtxt.__Internal*) __Instance)->nodeNr;
            }

            set
            {
                ((global::libxml.XmlValidCtxt.__Internal*)__Instance)->nodeNr = value;
            }
        }

        public int NodeMax
        {
            get
            {
                return ((global::libxml.XmlValidCtxt.__Internal*) __Instance)->nodeMax;
            }

            set
            {
                ((global::libxml.XmlValidCtxt.__Internal*)__Instance)->nodeMax = value;
            }
        }

        public global::libxml.XmlNode NodeTab
        {
            get
            {
                global::libxml.XmlNode __result0;
                if (((global::libxml.XmlValidCtxt.__Internal*) __Instance)->nodeTab == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlNode.NativeToManagedMap.ContainsKey(((global::libxml.XmlValidCtxt.__Internal*) __Instance)->nodeTab))
                    __result0 = (global::libxml.XmlNode) global::libxml.XmlNode.NativeToManagedMap[((global::libxml.XmlValidCtxt.__Internal*) __Instance)->nodeTab];
                else __result0 = global::libxml.XmlNode.__CreateInstance(((global::libxml.XmlValidCtxt.__Internal*) __Instance)->nodeTab);
                return __result0;
            }

            set
            {
                var __value = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
                ((global::libxml.XmlValidCtxt.__Internal*)__Instance)->nodeTab = new global::System.IntPtr(&__value);
            }
        }

        public uint FinishDtd
        {
            get
            {
                return ((global::libxml.XmlValidCtxt.__Internal*) __Instance)->finishDtd;
            }

            set
            {
                ((global::libxml.XmlValidCtxt.__Internal*)__Instance)->finishDtd = value;
            }
        }

        public global::libxml.XmlDoc Doc
        {
            get
            {
                global::libxml.XmlDoc __result0;
                if (((global::libxml.XmlValidCtxt.__Internal*) __Instance)->doc == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlDoc.NativeToManagedMap.ContainsKey(((global::libxml.XmlValidCtxt.__Internal*) __Instance)->doc))
                    __result0 = (global::libxml.XmlDoc) global::libxml.XmlDoc.NativeToManagedMap[((global::libxml.XmlValidCtxt.__Internal*) __Instance)->doc];
                else __result0 = global::libxml.XmlDoc.__CreateInstance(((global::libxml.XmlValidCtxt.__Internal*) __Instance)->doc);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlValidCtxt.__Internal*)__Instance)->doc = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public int Valid
        {
            get
            {
                return ((global::libxml.XmlValidCtxt.__Internal*) __Instance)->valid;
            }

            set
            {
                ((global::libxml.XmlValidCtxt.__Internal*)__Instance)->valid = value;
            }
        }

        public global::libxml.XmlValidState Vstate
        {
            get
            {
                global::libxml.XmlValidState __result0;
                if (((global::libxml.XmlValidCtxt.__Internal*) __Instance)->vstate == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlValidState.NativeToManagedMap.ContainsKey(((global::libxml.XmlValidCtxt.__Internal*) __Instance)->vstate))
                    __result0 = (global::libxml.XmlValidState) global::libxml.XmlValidState.NativeToManagedMap[((global::libxml.XmlValidCtxt.__Internal*) __Instance)->vstate];
                else __result0 = global::libxml.XmlValidState.__CreateInstance(((global::libxml.XmlValidCtxt.__Internal*) __Instance)->vstate);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlValidCtxt.__Internal*)__Instance)->vstate = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public int VstateNr
        {
            get
            {
                return ((global::libxml.XmlValidCtxt.__Internal*) __Instance)->vstateNr;
            }

            set
            {
                ((global::libxml.XmlValidCtxt.__Internal*)__Instance)->vstateNr = value;
            }
        }

        public int VstateMax
        {
            get
            {
                return ((global::libxml.XmlValidCtxt.__Internal*) __Instance)->vstateMax;
            }

            set
            {
                ((global::libxml.XmlValidCtxt.__Internal*)__Instance)->vstateMax = value;
            }
        }

        public global::libxml.XmlValidState VstateTab
        {
            get
            {
                global::libxml.XmlValidState __result0;
                if (((global::libxml.XmlValidCtxt.__Internal*) __Instance)->vstateTab == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlValidState.NativeToManagedMap.ContainsKey(((global::libxml.XmlValidCtxt.__Internal*) __Instance)->vstateTab))
                    __result0 = (global::libxml.XmlValidState) global::libxml.XmlValidState.NativeToManagedMap[((global::libxml.XmlValidCtxt.__Internal*) __Instance)->vstateTab];
                else __result0 = global::libxml.XmlValidState.__CreateInstance(((global::libxml.XmlValidCtxt.__Internal*) __Instance)->vstateTab);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlValidCtxt.__Internal*)__Instance)->vstateTab = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlAutomata Am
        {
            get
            {
                global::libxml.XmlAutomata __result0;
                if (((global::libxml.XmlValidCtxt.__Internal*) __Instance)->am == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlAutomata.NativeToManagedMap.ContainsKey(((global::libxml.XmlValidCtxt.__Internal*) __Instance)->am))
                    __result0 = (global::libxml.XmlAutomata) global::libxml.XmlAutomata.NativeToManagedMap[((global::libxml.XmlValidCtxt.__Internal*) __Instance)->am];
                else __result0 = global::libxml.XmlAutomata.__CreateInstance(((global::libxml.XmlValidCtxt.__Internal*) __Instance)->am);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlValidCtxt.__Internal*)__Instance)->am = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }

        public global::libxml.XmlAutomataState State
        {
            get
            {
                global::libxml.XmlAutomataState __result0;
                if (((global::libxml.XmlValidCtxt.__Internal*) __Instance)->state == IntPtr.Zero) __result0 = null;
                else if (global::libxml.XmlAutomataState.NativeToManagedMap.ContainsKey(((global::libxml.XmlValidCtxt.__Internal*) __Instance)->state))
                    __result0 = (global::libxml.XmlAutomataState) global::libxml.XmlAutomataState.NativeToManagedMap[((global::libxml.XmlValidCtxt.__Internal*) __Instance)->state];
                else __result0 = global::libxml.XmlAutomataState.__CreateInstance(((global::libxml.XmlValidCtxt.__Internal*) __Instance)->state);
                return __result0;
            }

            set
            {
                ((global::libxml.XmlValidCtxt.__Internal*)__Instance)->state = ReferenceEquals(value, null) ? global::System.IntPtr.Zero : value.__Instance;
            }
        }
    }
}