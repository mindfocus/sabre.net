using System;
using System.Runtime.InteropServices;
using System.Security;

namespace libxml
{
    public unsafe partial class XmlGlobalState : IDisposable
    {
        [StructLayout(LayoutKind.Explicit, Size = 516)]
        public partial struct __Internal
        {
            [FieldOffset(0)]
            internal global::System.IntPtr xmlParserVersion;

            [FieldOffset(4)]
            internal global::libxml.XmlSAXLocator.__Internal xmlDefaultSAXLocator;

            [FieldOffset(20)]
            internal global::libxml.XmlSAXHandlerV1.__Internal xmlDefaultSAXHandler;

            [FieldOffset(132)]
            internal global::libxml.XmlSAXHandlerV1.__Internal docbDefaultSAXHandler;

            [FieldOffset(244)]
            internal global::libxml.XmlSAXHandlerV1.__Internal htmlDefaultSAXHandler;

            [FieldOffset(356)]
            internal global::System.IntPtr xmlFree;

            [FieldOffset(360)]
            internal global::System.IntPtr xmlMalloc;

            [FieldOffset(364)]
            internal global::System.IntPtr xmlMemStrdup;

            [FieldOffset(368)]
            internal global::System.IntPtr xmlRealloc;

            [FieldOffset(372)]
            internal global::System.IntPtr xmlGenericError;

            [FieldOffset(376)]
            internal global::System.IntPtr xmlStructuredError;

            [FieldOffset(380)]
            internal global::System.IntPtr xmlGenericErrorContext;

            [FieldOffset(384)]
            internal int oldXMLWDcompatibility;

            [FieldOffset(388)]
            internal global::libxml.XmlBufferAllocationScheme xmlBufferAllocScheme;

            [FieldOffset(392)]
            internal int xmlDefaultBufferSize;

            [FieldOffset(396)]
            internal int xmlSubstituteEntitiesDefaultValue;

            [FieldOffset(400)]
            internal int xmlDoValidityCheckingDefaultValue;

            [FieldOffset(404)]
            internal int xmlGetWarningsDefaultValue;

            [FieldOffset(408)]
            internal int xmlKeepBlanksDefaultValue;

            [FieldOffset(412)]
            internal int xmlLineNumbersDefaultValue;

            [FieldOffset(416)]
            internal int xmlLoadExtDtdDefaultValue;

            [FieldOffset(420)]
            internal int xmlParserDebugEntities;

            [FieldOffset(424)]
            internal int xmlPedanticParserDefaultValue;

            [FieldOffset(428)]
            internal int xmlSaveNoEmptyTags;

            [FieldOffset(432)]
            internal int xmlIndentTreeOutput;

            [FieldOffset(436)]
            internal global::System.IntPtr xmlTreeIndentString;

            [FieldOffset(440)]
            internal global::System.IntPtr xmlRegisterNodeDefaultValue;

            [FieldOffset(444)]
            internal global::System.IntPtr xmlDeregisterNodeDefaultValue;

            [FieldOffset(448)]
            internal global::System.IntPtr xmlMallocAtomic;

            [FieldOffset(452)]
            internal global::libxml.XmlError.__Internal xmlLastError;

            [FieldOffset(504)]
            internal global::System.IntPtr xmlParserInputBufferCreateFilenameValue;

            [FieldOffset(508)]
            internal global::System.IntPtr xmlOutputBufferCreateFilenameValue;

            [FieldOffset(512)]
            internal global::System.IntPtr xmlStructuredErrorContext;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="_ZN15_xmlGlobalStateC2ERKS_")]
            internal static extern void cctor(global::System.IntPtr __instance, global::System.IntPtr _0);
        }

        public global::System.IntPtr __Instance { get; protected set; }

        internal static readonly global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlGlobalState> NativeToManagedMap = new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::libxml.XmlGlobalState>();
        protected internal void*[] __OriginalVTables;

        protected bool __ownsNativeInstance;

        internal static global::libxml.XmlGlobalState __CreateInstance(global::System.IntPtr native, bool skipVTables = false)
        {
            return new global::libxml.XmlGlobalState(native.ToPointer(), skipVTables);
        }

        internal static global::libxml.XmlGlobalState __CreateInstance(global::libxml.XmlGlobalState.__Internal native, bool skipVTables = false)
        {
            return new global::libxml.XmlGlobalState(native, skipVTables);
        }

        private static void* __CopyValue(global::libxml.XmlGlobalState.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::libxml.XmlGlobalState.__Internal));
            *(global::libxml.XmlGlobalState.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private XmlGlobalState(global::libxml.XmlGlobalState.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        protected XmlGlobalState(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new global::System.IntPtr(native);
        }

        public XmlGlobalState()
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlGlobalState.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
        }

        public XmlGlobalState(global::libxml.XmlGlobalState _0)
        {
            __Instance = Marshal.AllocHGlobal(sizeof(global::libxml.XmlGlobalState.__Internal));
            __ownsNativeInstance = true;
            NativeToManagedMap[__Instance] = this;
            *((global::libxml.XmlGlobalState.__Internal*) __Instance) = *((global::libxml.XmlGlobalState.__Internal*) _0.__Instance);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (__Instance == IntPtr.Zero)
                return;
            global::libxml.XmlGlobalState __dummy;
            NativeToManagedMap.TryRemove(__Instance, out __dummy);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }

        public string XmlParserVersion
        {
            get
            {
                if (((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlParserVersion == global::System.IntPtr.Zero)
                    return default(string);
                var __retPtr = (byte*) ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlParserVersion;
                int __length = 0;
                while (*(__retPtr++) != 0) __length += sizeof(byte);
                return global::System.Text.Encoding.UTF8.GetString((byte*) ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlParserVersion, __length);
            }

            set
            {
                byte[] __bytes0 = global::System.Text.Encoding.UTF8.GetBytes(value);
                fixed (byte* __bytePtr0 = __bytes0)
                {
                    ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlParserVersion = (global::System.IntPtr) new global::System.IntPtr(__bytePtr0);
                }
            }
        }

        public global::libxml.XmlSAXLocator XmlDefaultSAXLocator
        {
            get
            {
                return global::libxml.XmlSAXLocator.__CreateInstance(new global::System.IntPtr(&((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlDefaultSAXLocator));
            }

            set
            {
                if (ReferenceEquals(value, null))
                    throw new global::System.ArgumentNullException("value", "Cannot be null because it is passed by value.");
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlDefaultSAXLocator = *(global::libxml.XmlSAXLocator.__Internal*) value.__Instance;
            }
        }

        public global::libxml.XmlSAXHandlerV1 XmlDefaultSAXHandler
        {
            get
            {
                return global::libxml.XmlSAXHandlerV1.__CreateInstance(new global::System.IntPtr(&((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlDefaultSAXHandler));
            }

            set
            {
                if (ReferenceEquals(value, null))
                    throw new global::System.ArgumentNullException("value", "Cannot be null because it is passed by value.");
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlDefaultSAXHandler = *(global::libxml.XmlSAXHandlerV1.__Internal*) value.__Instance;
            }
        }

        public global::libxml.XmlSAXHandlerV1 DocbDefaultSAXHandler
        {
            get
            {
                return global::libxml.XmlSAXHandlerV1.__CreateInstance(new global::System.IntPtr(&((global::libxml.XmlGlobalState.__Internal*) __Instance)->docbDefaultSAXHandler));
            }

            set
            {
                if (ReferenceEquals(value, null))
                    throw new global::System.ArgumentNullException("value", "Cannot be null because it is passed by value.");
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->docbDefaultSAXHandler = *(global::libxml.XmlSAXHandlerV1.__Internal*) value.__Instance;
            }
        }

        public global::libxml.XmlSAXHandlerV1 HtmlDefaultSAXHandler
        {
            get
            {
                return global::libxml.XmlSAXHandlerV1.__CreateInstance(new global::System.IntPtr(&((global::libxml.XmlGlobalState.__Internal*) __Instance)->htmlDefaultSAXHandler));
            }

            set
            {
                if (ReferenceEquals(value, null))
                    throw new global::System.ArgumentNullException("value", "Cannot be null because it is passed by value.");
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->htmlDefaultSAXHandler = *(global::libxml.XmlSAXHandlerV1.__Internal*) value.__Instance;
            }
        }

        public global::libxml.XmlFreeFunc XmlFree
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlFree;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlFreeFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlFreeFunc));
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlFree = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.XmlMallocFunc XmlMalloc
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlMalloc;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlMallocFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlMallocFunc));
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlMalloc = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.XmlStrdupFunc XmlMemStrdup
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlMemStrdup;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlStrdupFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlStrdupFunc));
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlMemStrdup = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.XmlReallocFunc XmlRealloc
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlRealloc;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlReallocFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlReallocFunc));
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlRealloc = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.XmlGenericErrorFunc XmlGenericError
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlGenericError;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlGenericErrorFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlGenericErrorFunc));
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlGenericError = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.XmlStructuredErrorFunc XmlStructuredError
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlStructuredError;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlStructuredErrorFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlStructuredErrorFunc));
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlStructuredError = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::System.IntPtr XmlGenericErrorContext
        {
            get
            {
                return ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlGenericErrorContext;
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlGenericErrorContext = (global::System.IntPtr) value;
            }
        }

        public int OldXMLWDcompatibility
        {
            get
            {
                return ((global::libxml.XmlGlobalState.__Internal*) __Instance)->oldXMLWDcompatibility;
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->oldXMLWDcompatibility = value;
            }
        }

        public global::libxml.XmlBufferAllocationScheme XmlBufferAllocScheme
        {
            get
            {
                return ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlBufferAllocScheme;
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlBufferAllocScheme = value;
            }
        }

        public int XmlDefaultBufferSize
        {
            get
            {
                return ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlDefaultBufferSize;
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlDefaultBufferSize = value;
            }
        }

        public int XmlSubstituteEntitiesDefaultValue
        {
            get
            {
                return ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlSubstituteEntitiesDefaultValue;
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlSubstituteEntitiesDefaultValue = value;
            }
        }

        public int XmlDoValidityCheckingDefaultValue
        {
            get
            {
                return ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlDoValidityCheckingDefaultValue;
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlDoValidityCheckingDefaultValue = value;
            }
        }

        public int XmlGetWarningsDefaultValue
        {
            get
            {
                return ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlGetWarningsDefaultValue;
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlGetWarningsDefaultValue = value;
            }
        }

        public int XmlKeepBlanksDefaultValue
        {
            get
            {
                return ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlKeepBlanksDefaultValue;
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlKeepBlanksDefaultValue = value;
            }
        }

        public int XmlLineNumbersDefaultValue
        {
            get
            {
                return ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlLineNumbersDefaultValue;
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlLineNumbersDefaultValue = value;
            }
        }

        public int XmlLoadExtDtdDefaultValue
        {
            get
            {
                return ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlLoadExtDtdDefaultValue;
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlLoadExtDtdDefaultValue = value;
            }
        }

        public int XmlParserDebugEntities
        {
            get
            {
                return ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlParserDebugEntities;
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlParserDebugEntities = value;
            }
        }

        public int XmlPedanticParserDefaultValue
        {
            get
            {
                return ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlPedanticParserDefaultValue;
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlPedanticParserDefaultValue = value;
            }
        }

        public int XmlSaveNoEmptyTags
        {
            get
            {
                return ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlSaveNoEmptyTags;
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlSaveNoEmptyTags = value;
            }
        }

        public int XmlIndentTreeOutput
        {
            get
            {
                return ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlIndentTreeOutput;
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlIndentTreeOutput = value;
            }
        }

        public string XmlTreeIndentString
        {
            get
            {
                if (((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlTreeIndentString == global::System.IntPtr.Zero)
                    return default(string);
                var __retPtr = (byte*) ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlTreeIndentString;
                int __length = 0;
                while (*(__retPtr++) != 0) __length += sizeof(byte);
                return global::System.Text.Encoding.UTF8.GetString((byte*) ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlTreeIndentString, __length);
            }

            set
            {
                byte[] __bytes0 = global::System.Text.Encoding.UTF8.GetBytes(value);
                fixed (byte* __bytePtr0 = __bytes0)
                {
                    ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlTreeIndentString = (global::System.IntPtr) new global::System.IntPtr(__bytePtr0);
                }
            }
        }

        public global::libxml.XmlRegisterNodeFunc XmlRegisterNodeDefaultValue
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlRegisterNodeDefaultValue;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlRegisterNodeFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlRegisterNodeFunc));
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlRegisterNodeDefaultValue = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.XmlDeregisterNodeFunc XmlDeregisterNodeDefaultValue
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlDeregisterNodeDefaultValue;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlDeregisterNodeFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlDeregisterNodeFunc));
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlDeregisterNodeDefaultValue = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.XmlMallocFunc XmlMallocAtomic
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlMallocAtomic;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlMallocFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlMallocFunc));
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlMallocAtomic = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.XmlError XmlLastError
        {
            get
            {
                return global::libxml.XmlError.__CreateInstance(new global::System.IntPtr(&((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlLastError));
            }

            set
            {
                if (ReferenceEquals(value, null))
                    throw new global::System.ArgumentNullException("value", "Cannot be null because it is passed by value.");
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlLastError = *(global::libxml.XmlError.__Internal*) value.__Instance;
            }
        }

        public global::libxml.XmlParserInputBufferCreateFilenameFunc XmlParserInputBufferCreateFilenameValue
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlParserInputBufferCreateFilenameValue;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlParserInputBufferCreateFilenameFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlParserInputBufferCreateFilenameFunc));
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlParserInputBufferCreateFilenameValue = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::libxml.XmlOutputBufferCreateFilenameFunc XmlOutputBufferCreateFilenameValue
        {
            get
            {
                var __ptr0 = ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlOutputBufferCreateFilenameValue;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlOutputBufferCreateFilenameFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlOutputBufferCreateFilenameFunc));
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlOutputBufferCreateFilenameValue = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public global::System.IntPtr XmlStructuredErrorContext
        {
            get
            {
                return ((global::libxml.XmlGlobalState.__Internal*) __Instance)->xmlStructuredErrorContext;
            }

            set
            {
                ((global::libxml.XmlGlobalState.__Internal*)__Instance)->xmlStructuredErrorContext = (global::System.IntPtr) value;
            }
        }
    }
}