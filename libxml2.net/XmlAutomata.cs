using System;
using System.Runtime.InteropServices;
using System.Security;

namespace libxml
{
    public unsafe partial class xmlautomata
    {
        private const string lib = "/usr/local/Cellar/libxml2/2.9.9_2/lib/libxml2.2.dylib";

        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlNewAutomata")]
            internal static extern global::System.IntPtr XmlNewAutomata();

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlFreeAutomata")]
            internal static extern void XmlFreeAutomata(global::System.IntPtr am);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAutomataGetInitState")]
            internal static extern global::System.IntPtr XmlAutomataGetInitState(global::System.IntPtr am);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAutomataSetFinalState")]
            internal static extern int XmlAutomataSetFinalState(global::System.IntPtr am, global::System.IntPtr state);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAutomataNewState")]
            internal static extern global::System.IntPtr XmlAutomataNewState(global::System.IntPtr am);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAutomataNewTransition")]
            internal static extern global::System.IntPtr XmlAutomataNewTransition(global::System.IntPtr am, global::System.IntPtr from, global::System.IntPtr to, byte* token, global::System.IntPtr data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAutomataNewTransition2")]
            internal static extern global::System.IntPtr XmlAutomataNewTransition2(global::System.IntPtr am, global::System.IntPtr from, global::System.IntPtr to, byte* token, byte* token2, global::System.IntPtr data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAutomataNewNegTrans")]
            internal static extern global::System.IntPtr XmlAutomataNewNegTrans(global::System.IntPtr am, global::System.IntPtr from, global::System.IntPtr to, byte* token, byte* token2, global::System.IntPtr data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAutomataNewCountTrans")]
            internal static extern global::System.IntPtr XmlAutomataNewCountTrans(global::System.IntPtr am, global::System.IntPtr from, global::System.IntPtr to, byte* token, int min, int max, global::System.IntPtr data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAutomataNewCountTrans2")]
            internal static extern global::System.IntPtr XmlAutomataNewCountTrans2(global::System.IntPtr am, global::System.IntPtr from, global::System.IntPtr to, byte* token, byte* token2, int min, int max, global::System.IntPtr data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAutomataNewOnceTrans")]
            internal static extern global::System.IntPtr XmlAutomataNewOnceTrans(global::System.IntPtr am, global::System.IntPtr from, global::System.IntPtr to, byte* token, int min, int max, global::System.IntPtr data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAutomataNewOnceTrans2")]
            internal static extern global::System.IntPtr XmlAutomataNewOnceTrans2(global::System.IntPtr am, global::System.IntPtr from, global::System.IntPtr to, byte* token, byte* token2, int min, int max, global::System.IntPtr data);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAutomataNewAllTrans")]
            internal static extern global::System.IntPtr XmlAutomataNewAllTrans(global::System.IntPtr am, global::System.IntPtr from, global::System.IntPtr to, int lax);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAutomataNewEpsilon")]
            internal static extern global::System.IntPtr XmlAutomataNewEpsilon(global::System.IntPtr am, global::System.IntPtr from, global::System.IntPtr to);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAutomataNewCountedTrans")]
            internal static extern global::System.IntPtr XmlAutomataNewCountedTrans(global::System.IntPtr am, global::System.IntPtr from, global::System.IntPtr to, int counter);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAutomataNewCounterTrans")]
            internal static extern global::System.IntPtr XmlAutomataNewCounterTrans(global::System.IntPtr am, global::System.IntPtr from, global::System.IntPtr to, int counter);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAutomataNewCounter")]
            internal static extern int XmlAutomataNewCounter(global::System.IntPtr am, int min, int max);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAutomataCompile")]
            internal static extern global::System.IntPtr XmlAutomataCompile(global::System.IntPtr am);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlAutomataIsDeterminist")]
            internal static extern int XmlAutomataIsDeterminist(global::System.IntPtr am);
        }

        public static global::libxml.XmlAutomata XmlNewAutomata()
        {
            var __ret = __Internal.XmlNewAutomata();
            global::libxml.XmlAutomata __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAutomata.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAutomata) global::libxml.XmlAutomata.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAutomata.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlFreeAutomata(global::libxml.XmlAutomata am)
        {
            var __arg0 = ReferenceEquals(am, null) ? global::System.IntPtr.Zero : am.__Instance;
            __Internal.XmlFreeAutomata(__arg0);
        }

        public static global::libxml.XmlAutomataState XmlAutomataGetInitState(global::libxml.XmlAutomata am)
        {
            var __arg0 = ReferenceEquals(am, null) ? global::System.IntPtr.Zero : am.__Instance;
            var __ret = __Internal.XmlAutomataGetInitState(__arg0);
            global::libxml.XmlAutomataState __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAutomataState.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAutomataState) global::libxml.XmlAutomataState.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAutomataState.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlAutomataSetFinalState(global::libxml.XmlAutomata am, global::libxml.XmlAutomataState state)
        {
            var __arg0 = ReferenceEquals(am, null) ? global::System.IntPtr.Zero : am.__Instance;
            var __arg1 = ReferenceEquals(state, null) ? global::System.IntPtr.Zero : state.__Instance;
            var __ret = __Internal.XmlAutomataSetFinalState(__arg0, __arg1);
            return __ret;
        }

        public static global::libxml.XmlAutomataState XmlAutomataNewState(global::libxml.XmlAutomata am)
        {
            var __arg0 = ReferenceEquals(am, null) ? global::System.IntPtr.Zero : am.__Instance;
            var __ret = __Internal.XmlAutomataNewState(__arg0);
            global::libxml.XmlAutomataState __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAutomataState.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAutomataState) global::libxml.XmlAutomataState.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAutomataState.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlAutomataState XmlAutomataNewTransition(global::libxml.XmlAutomata am, global::libxml.XmlAutomataState from, global::libxml.XmlAutomataState to, byte* token, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(am, null) ? global::System.IntPtr.Zero : am.__Instance;
            var __arg1 = ReferenceEquals(from, null) ? global::System.IntPtr.Zero : from.__Instance;
            var __arg2 = ReferenceEquals(to, null) ? global::System.IntPtr.Zero : to.__Instance;
            var __ret = __Internal.XmlAutomataNewTransition(__arg0, __arg1, __arg2, token, data);
            global::libxml.XmlAutomataState __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAutomataState.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAutomataState) global::libxml.XmlAutomataState.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAutomataState.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlAutomataState XmlAutomataNewTransition2(global::libxml.XmlAutomata am, global::libxml.XmlAutomataState from, global::libxml.XmlAutomataState to, byte* token, byte* token2, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(am, null) ? global::System.IntPtr.Zero : am.__Instance;
            var __arg1 = ReferenceEquals(from, null) ? global::System.IntPtr.Zero : from.__Instance;
            var __arg2 = ReferenceEquals(to, null) ? global::System.IntPtr.Zero : to.__Instance;
            var __ret = __Internal.XmlAutomataNewTransition2(__arg0, __arg1, __arg2, token, token2, data);
            global::libxml.XmlAutomataState __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAutomataState.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAutomataState) global::libxml.XmlAutomataState.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAutomataState.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlAutomataState XmlAutomataNewNegTrans(global::libxml.XmlAutomata am, global::libxml.XmlAutomataState from, global::libxml.XmlAutomataState to, byte* token, byte* token2, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(am, null) ? global::System.IntPtr.Zero : am.__Instance;
            var __arg1 = ReferenceEquals(from, null) ? global::System.IntPtr.Zero : from.__Instance;
            var __arg2 = ReferenceEquals(to, null) ? global::System.IntPtr.Zero : to.__Instance;
            var __ret = __Internal.XmlAutomataNewNegTrans(__arg0, __arg1, __arg2, token, token2, data);
            global::libxml.XmlAutomataState __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAutomataState.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAutomataState) global::libxml.XmlAutomataState.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAutomataState.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlAutomataState XmlAutomataNewCountTrans(global::libxml.XmlAutomata am, global::libxml.XmlAutomataState from, global::libxml.XmlAutomataState to, byte* token, int min, int max, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(am, null) ? global::System.IntPtr.Zero : am.__Instance;
            var __arg1 = ReferenceEquals(from, null) ? global::System.IntPtr.Zero : from.__Instance;
            var __arg2 = ReferenceEquals(to, null) ? global::System.IntPtr.Zero : to.__Instance;
            var __ret = __Internal.XmlAutomataNewCountTrans(__arg0, __arg1, __arg2, token, min, max, data);
            global::libxml.XmlAutomataState __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAutomataState.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAutomataState) global::libxml.XmlAutomataState.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAutomataState.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlAutomataState XmlAutomataNewCountTrans2(global::libxml.XmlAutomata am, global::libxml.XmlAutomataState from, global::libxml.XmlAutomataState to, byte* token, byte* token2, int min, int max, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(am, null) ? global::System.IntPtr.Zero : am.__Instance;
            var __arg1 = ReferenceEquals(from, null) ? global::System.IntPtr.Zero : from.__Instance;
            var __arg2 = ReferenceEquals(to, null) ? global::System.IntPtr.Zero : to.__Instance;
            var __ret = __Internal.XmlAutomataNewCountTrans2(__arg0, __arg1, __arg2, token, token2, min, max, data);
            global::libxml.XmlAutomataState __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAutomataState.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAutomataState) global::libxml.XmlAutomataState.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAutomataState.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlAutomataState XmlAutomataNewOnceTrans(global::libxml.XmlAutomata am, global::libxml.XmlAutomataState from, global::libxml.XmlAutomataState to, byte* token, int min, int max, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(am, null) ? global::System.IntPtr.Zero : am.__Instance;
            var __arg1 = ReferenceEquals(from, null) ? global::System.IntPtr.Zero : from.__Instance;
            var __arg2 = ReferenceEquals(to, null) ? global::System.IntPtr.Zero : to.__Instance;
            var __ret = __Internal.XmlAutomataNewOnceTrans(__arg0, __arg1, __arg2, token, min, max, data);
            global::libxml.XmlAutomataState __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAutomataState.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAutomataState) global::libxml.XmlAutomataState.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAutomataState.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlAutomataState XmlAutomataNewOnceTrans2(global::libxml.XmlAutomata am, global::libxml.XmlAutomataState from, global::libxml.XmlAutomataState to, byte* token, byte* token2, int min, int max, global::System.IntPtr data)
        {
            var __arg0 = ReferenceEquals(am, null) ? global::System.IntPtr.Zero : am.__Instance;
            var __arg1 = ReferenceEquals(from, null) ? global::System.IntPtr.Zero : from.__Instance;
            var __arg2 = ReferenceEquals(to, null) ? global::System.IntPtr.Zero : to.__Instance;
            var __ret = __Internal.XmlAutomataNewOnceTrans2(__arg0, __arg1, __arg2, token, token2, min, max, data);
            global::libxml.XmlAutomataState __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAutomataState.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAutomataState) global::libxml.XmlAutomataState.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAutomataState.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlAutomataState XmlAutomataNewAllTrans(global::libxml.XmlAutomata am, global::libxml.XmlAutomataState from, global::libxml.XmlAutomataState to, int lax)
        {
            var __arg0 = ReferenceEquals(am, null) ? global::System.IntPtr.Zero : am.__Instance;
            var __arg1 = ReferenceEquals(from, null) ? global::System.IntPtr.Zero : from.__Instance;
            var __arg2 = ReferenceEquals(to, null) ? global::System.IntPtr.Zero : to.__Instance;
            var __ret = __Internal.XmlAutomataNewAllTrans(__arg0, __arg1, __arg2, lax);
            global::libxml.XmlAutomataState __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAutomataState.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAutomataState) global::libxml.XmlAutomataState.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAutomataState.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlAutomataState XmlAutomataNewEpsilon(global::libxml.XmlAutomata am, global::libxml.XmlAutomataState from, global::libxml.XmlAutomataState to)
        {
            var __arg0 = ReferenceEquals(am, null) ? global::System.IntPtr.Zero : am.__Instance;
            var __arg1 = ReferenceEquals(from, null) ? global::System.IntPtr.Zero : from.__Instance;
            var __arg2 = ReferenceEquals(to, null) ? global::System.IntPtr.Zero : to.__Instance;
            var __ret = __Internal.XmlAutomataNewEpsilon(__arg0, __arg1, __arg2);
            global::libxml.XmlAutomataState __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAutomataState.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAutomataState) global::libxml.XmlAutomataState.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAutomataState.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlAutomataState XmlAutomataNewCountedTrans(global::libxml.XmlAutomata am, global::libxml.XmlAutomataState from, global::libxml.XmlAutomataState to, int counter)
        {
            var __arg0 = ReferenceEquals(am, null) ? global::System.IntPtr.Zero : am.__Instance;
            var __arg1 = ReferenceEquals(from, null) ? global::System.IntPtr.Zero : from.__Instance;
            var __arg2 = ReferenceEquals(to, null) ? global::System.IntPtr.Zero : to.__Instance;
            var __ret = __Internal.XmlAutomataNewCountedTrans(__arg0, __arg1, __arg2, counter);
            global::libxml.XmlAutomataState __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAutomataState.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAutomataState) global::libxml.XmlAutomataState.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAutomataState.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlAutomataState XmlAutomataNewCounterTrans(global::libxml.XmlAutomata am, global::libxml.XmlAutomataState from, global::libxml.XmlAutomataState to, int counter)
        {
            var __arg0 = ReferenceEquals(am, null) ? global::System.IntPtr.Zero : am.__Instance;
            var __arg1 = ReferenceEquals(from, null) ? global::System.IntPtr.Zero : from.__Instance;
            var __arg2 = ReferenceEquals(to, null) ? global::System.IntPtr.Zero : to.__Instance;
            var __ret = __Internal.XmlAutomataNewCounterTrans(__arg0, __arg1, __arg2, counter);
            global::libxml.XmlAutomataState __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlAutomataState.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlAutomataState) global::libxml.XmlAutomataState.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlAutomataState.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlAutomataNewCounter(global::libxml.XmlAutomata am, int min, int max)
        {
            var __arg0 = ReferenceEquals(am, null) ? global::System.IntPtr.Zero : am.__Instance;
            var __ret = __Internal.XmlAutomataNewCounter(__arg0, min, max);
            return __ret;
        }

        public static global::libxml.XmlRegexp XmlAutomataCompile(global::libxml.XmlAutomata am)
        {
            var __arg0 = ReferenceEquals(am, null) ? global::System.IntPtr.Zero : am.__Instance;
            var __ret = __Internal.XmlAutomataCompile(__arg0);
            global::libxml.XmlRegexp __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlRegexp.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlRegexp) global::libxml.XmlRegexp.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlRegexp.__CreateInstance(__ret);
            return __result0;
        }

        public static int XmlAutomataIsDeterminist(global::libxml.XmlAutomata am)
        {
            var __arg0 = ReferenceEquals(am, null) ? global::System.IntPtr.Zero : am.__Instance;
            var __ret = __Internal.XmlAutomataIsDeterminist(__arg0);
            return __ret;
        }
    }

    /// <summary>xmlAutomataPtr:</summary>
    /// <remarks>A libxml automata description, It can be compiled into a regexp</remarks>
    /// <summary>xmlAutomataStatePtr:</summary>
    /// <remarks>A state int the automata description,</remarks>
    public unsafe partial class XmlAutomata
    {
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        public partial struct __Internal
        {
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly
            global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlAutomata>
            NativeToManagedMap =
                new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlAutomata>();

        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlAutomata __CreateInstance(global::System.IntPtr native,
            bool skipVTables = false)
        {
            return new global::libxml.XmlAutomata(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlAutomata __CreateInstance(global::libxml.XmlAutomata.__Internal native,
            bool skipVTables = false)
        {
            return new global::libxml.XmlAutomata(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlAutomata.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlAutomata.__Internal));
            *(global::libxml.XmlAutomata.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlAutomata(global::libxml.XmlAutomata.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlAutomata(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }
    }
}