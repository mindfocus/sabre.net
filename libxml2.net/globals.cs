using System;
using System.Runtime.InteropServices;
using System.Security;

namespace libxml
{
    public unsafe partial class globals
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlInitGlobals")]
            internal static extern void XmlInitGlobals();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlCleanupGlobals")]
            internal static extern void XmlCleanupGlobals();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParserInputBufferCreateFilenameDefault")]
            internal static extern global::System.IntPtr XmlParserInputBufferCreateFilenameDefault(global::System.IntPtr func);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlOutputBufferCreateFilenameDefault")]
            internal static extern global::System.IntPtr XmlOutputBufferCreateFilenameDefault(global::System.IntPtr func);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlInitializeGlobalState")]
            internal static extern void XmlInitializeGlobalState(global::System.IntPtr gs);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlThrDefSetGenericErrorFunc")]
            internal static extern void XmlThrDefSetGenericErrorFunc(global::System.IntPtr ctx, global::System.IntPtr handler);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlThrDefSetStructuredErrorFunc")]
            internal static extern void XmlThrDefSetStructuredErrorFunc(global::System.IntPtr ctx, global::System.IntPtr handler);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlRegisterNodeDefault")]
            internal static extern global::System.IntPtr XmlRegisterNodeDefault(global::System.IntPtr func);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlThrDefRegisterNodeDefault")]
            internal static extern global::System.IntPtr XmlThrDefRegisterNodeDefault(global::System.IntPtr func);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlDeregisterNodeDefault")]
            internal static extern global::System.IntPtr XmlDeregisterNodeDefault(global::System.IntPtr func);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlThrDefDeregisterNodeDefault")]
            internal static extern global::System.IntPtr XmlThrDefDeregisterNodeDefault(global::System.IntPtr func);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlThrDefOutputBufferCreateFilenameDefault")]
            internal static extern global::System.IntPtr XmlThrDefOutputBufferCreateFilenameDefault(global::System.IntPtr func);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlThrDefParserInputBufferCreateFilenameDefault")]
            internal static extern global::System.IntPtr XmlThrDefParserInputBufferCreateFilenameDefault(global::System.IntPtr func);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__docbDefaultSAXHandler")]
            internal static extern global::System.IntPtr DocbDefaultSAXHandler();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__htmlDefaultSAXHandler")]
            internal static extern global::System.IntPtr HtmlDefaultSAXHandler();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlLastError")]
            internal static extern global::System.IntPtr XmlLastError();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__oldXMLWDcompatibility")]
            internal static extern int* OldXMLWDcompatibility();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlBufferAllocScheme")]
            internal static extern global::libxml.XmlBufferAllocationScheme* XmlBufferAllocScheme();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlThrDefBufferAllocScheme")]
            internal static extern global::libxml.XmlBufferAllocationScheme XmlThrDefBufferAllocScheme(global::libxml.XmlBufferAllocationScheme v);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlDefaultBufferSize")]
            internal static extern int* XmlDefaultBufferSize();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlThrDefDefaultBufferSize")]
            internal static extern int XmlThrDefDefaultBufferSize(int v);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlDefaultSAXHandler")]
            internal static extern global::System.IntPtr XmlDefaultSAXHandler();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlDefaultSAXLocator")]
            internal static extern global::System.IntPtr XmlDefaultSAXLocator();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlDoValidityCheckingDefaultValue")]
            internal static extern int* XmlDoValidityCheckingDefaultValue();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlThrDefDoValidityCheckingDefaultValue")]
            internal static extern int XmlThrDefDoValidityCheckingDefaultValue(int v);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlGenericError")]
            internal static extern global::System.IntPtr XmlGenericError();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlStructuredError")]
            internal static extern global::System.IntPtr XmlStructuredError();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlGenericErrorContext")]
            internal static extern void** XmlGenericErrorContext();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlStructuredErrorContext")]
            internal static extern void** XmlStructuredErrorContext();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlGetWarningsDefaultValue")]
            internal static extern int* XmlGetWarningsDefaultValue();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlThrDefGetWarningsDefaultValue")]
            internal static extern int XmlThrDefGetWarningsDefaultValue(int v);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlIndentTreeOutput")]
            internal static extern int* XmlIndentTreeOutput();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlThrDefIndentTreeOutput")]
            internal static extern int XmlThrDefIndentTreeOutput(int v);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlTreeIndentString")]
            internal static extern sbyte** XmlTreeIndentString();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlThrDefTreeIndentString")]
            internal static extern global::System.IntPtr XmlThrDefTreeIndentString([MarshalAs(UnmanagedType.LPUTF8Str)] string v);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlKeepBlanksDefaultValue")]
            internal static extern int* XmlKeepBlanksDefaultValue();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlThrDefKeepBlanksDefaultValue")]
            internal static extern int XmlThrDefKeepBlanksDefaultValue(int v);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlLineNumbersDefaultValue")]
            internal static extern int* XmlLineNumbersDefaultValue();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlThrDefLineNumbersDefaultValue")]
            internal static extern int XmlThrDefLineNumbersDefaultValue(int v);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlLoadExtDtdDefaultValue")]
            internal static extern int* XmlLoadExtDtdDefaultValue();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlThrDefLoadExtDtdDefaultValue")]
            internal static extern int XmlThrDefLoadExtDtdDefaultValue(int v);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlParserDebugEntities")]
            internal static extern int* XmlParserDebugEntities();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlThrDefParserDebugEntities")]
            internal static extern int XmlThrDefParserDebugEntities(int v);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlParserVersion")]
            internal static extern sbyte** XmlParserVersion();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlPedanticParserDefaultValue")]
            internal static extern int* XmlPedanticParserDefaultValue();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlThrDefPedanticParserDefaultValue")]
            internal static extern int XmlThrDefPedanticParserDefaultValue(int v);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlSaveNoEmptyTags")]
            internal static extern int* XmlSaveNoEmptyTags();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlThrDefSaveNoEmptyTags")]
            internal static extern int XmlThrDefSaveNoEmptyTags(int v);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlSubstituteEntitiesDefaultValue")]
            internal static extern int* XmlSubstituteEntitiesDefaultValue();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlThrDefSubstituteEntitiesDefaultValue")]
            internal static extern int XmlThrDefSubstituteEntitiesDefaultValue(int v);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlRegisterNodeDefaultValue")]
            internal static extern global::System.IntPtr XmlRegisterNodeDefaultValue();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlDeregisterNodeDefaultValue")]
            internal static extern global::System.IntPtr XmlDeregisterNodeDefaultValue();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlParserInputBufferCreateFilenameValue")]
            internal static extern global::System.IntPtr XmlParserInputBufferCreateFilenameValue();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("1", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="__xmlOutputBufferCreateFilenameValue")]
            internal static extern global::System.IntPtr XmlOutputBufferCreateFilenameValue();
        }

        public static void XmlInitGlobals()
        {
            __Internal.XmlInitGlobals();
        }

        public static void XmlCleanupGlobals()
        {
            __Internal.XmlCleanupGlobals();
        }

        public static global::libxml.XmlParserInputBufferCreateFilenameFunc XmlParserInputBufferCreateFilenameDefault(global::libxml.XmlParserInputBufferCreateFilenameFunc func)
        {
            var __arg0 = func == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func);
            var __ret = __Internal.XmlParserInputBufferCreateFilenameDefault(__arg0);
            var __ptr0 = __ret;
            return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlParserInputBufferCreateFilenameFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlParserInputBufferCreateFilenameFunc));
        }

        public static global::libxml.XmlOutputBufferCreateFilenameFunc XmlOutputBufferCreateFilenameDefault(global::libxml.XmlOutputBufferCreateFilenameFunc func)
        {
            var __arg0 = func == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func);
            var __ret = __Internal.XmlOutputBufferCreateFilenameDefault(__arg0);
            var __ptr0 = __ret;
            return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlOutputBufferCreateFilenameFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlOutputBufferCreateFilenameFunc));
        }

        public static void XmlInitializeGlobalState(global::libxml.XmlGlobalState gs)
        {
            var __arg0 = ReferenceEquals(gs, null) ? global::System.IntPtr.Zero : gs.__Instance;
            __Internal.XmlInitializeGlobalState(__arg0);
        }

        public static void XmlThrDefSetGenericErrorFunc(global::System.IntPtr ctx, global::libxml.XmlGenericErrorFunc handler)
        {
            var __arg1 = handler == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(handler);
            __Internal.XmlThrDefSetGenericErrorFunc(ctx, __arg1);
        }

        public static void XmlThrDefSetStructuredErrorFunc(global::System.IntPtr ctx, global::libxml.XmlStructuredErrorFunc handler)
        {
            var __arg1 = handler == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(handler);
            __Internal.XmlThrDefSetStructuredErrorFunc(ctx, __arg1);
        }

        public static global::libxml.XmlRegisterNodeFunc XmlRegisterNodeDefault(global::libxml.XmlRegisterNodeFunc func)
        {
            var __arg0 = func == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func);
            var __ret = __Internal.XmlRegisterNodeDefault(__arg0);
            var __ptr0 = __ret;
            return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlRegisterNodeFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlRegisterNodeFunc));
        }

        public static global::libxml.XmlRegisterNodeFunc XmlThrDefRegisterNodeDefault(global::libxml.XmlRegisterNodeFunc func)
        {
            var __arg0 = func == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func);
            var __ret = __Internal.XmlThrDefRegisterNodeDefault(__arg0);
            var __ptr0 = __ret;
            return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlRegisterNodeFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlRegisterNodeFunc));
        }

        public static global::libxml.XmlDeregisterNodeFunc XmlDeregisterNodeDefault(global::libxml.XmlDeregisterNodeFunc func)
        {
            var __arg0 = func == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func);
            var __ret = __Internal.XmlDeregisterNodeDefault(__arg0);
            var __ptr0 = __ret;
            return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlDeregisterNodeFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlDeregisterNodeFunc));
        }

        public static global::libxml.XmlDeregisterNodeFunc XmlThrDefDeregisterNodeDefault(global::libxml.XmlDeregisterNodeFunc func)
        {
            var __arg0 = func == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func);
            var __ret = __Internal.XmlThrDefDeregisterNodeDefault(__arg0);
            var __ptr0 = __ret;
            return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlDeregisterNodeFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlDeregisterNodeFunc));
        }

        public static global::libxml.XmlOutputBufferCreateFilenameFunc XmlThrDefOutputBufferCreateFilenameDefault(global::libxml.XmlOutputBufferCreateFilenameFunc func)
        {
            var __arg0 = func == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func);
            var __ret = __Internal.XmlThrDefOutputBufferCreateFilenameDefault(__arg0);
            var __ptr0 = __ret;
            return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlOutputBufferCreateFilenameFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlOutputBufferCreateFilenameFunc));
        }

        public static global::libxml.XmlParserInputBufferCreateFilenameFunc XmlThrDefParserInputBufferCreateFilenameDefault(global::libxml.XmlParserInputBufferCreateFilenameFunc func)
        {
            var __arg0 = func == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func);
            var __ret = __Internal.XmlThrDefParserInputBufferCreateFilenameDefault(__arg0);
            var __ptr0 = __ret;
            return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlParserInputBufferCreateFilenameFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlParserInputBufferCreateFilenameFunc));
        }

        public static global::libxml.XmlSAXHandlerV1 DocbDefaultSAXHandler()
        {
            var __ret = __Internal.DocbDefaultSAXHandler();
            global::libxml.XmlSAXHandlerV1 __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlSAXHandlerV1.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlSAXHandlerV1) global::libxml.XmlSAXHandlerV1.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlSAXHandlerV1.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlSAXHandlerV1 HtmlDefaultSAXHandler()
        {
            var __ret = __Internal.HtmlDefaultSAXHandler();
            global::libxml.XmlSAXHandlerV1 __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlSAXHandlerV1.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlSAXHandlerV1) global::libxml.XmlSAXHandlerV1.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlSAXHandlerV1.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlError XmlLastError()
        {
            var __ret = __Internal.XmlLastError();
            global::libxml.XmlError __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlError.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlError) global::libxml.XmlError.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlError.__CreateInstance(__ret);
            return __result0;
        }

        public static int* OldXMLWDcompatibility()
        {
            var __ret = __Internal.OldXMLWDcompatibility();
            return __ret;
        }

        public static global::libxml.XmlBufferAllocationScheme* XmlBufferAllocScheme()
        {
            var __ret = __Internal.XmlBufferAllocScheme();
            return __ret;
        }

        public static global::libxml.XmlBufferAllocationScheme XmlThrDefBufferAllocScheme(global::libxml.XmlBufferAllocationScheme v)
        {
            var __ret = __Internal.XmlThrDefBufferAllocScheme(v);
            return __ret;
        }

        public static int* XmlDefaultBufferSize()
        {
            var __ret = __Internal.XmlDefaultBufferSize();
            return __ret;
        }

        public static int XmlThrDefDefaultBufferSize(int v)
        {
            var __ret = __Internal.XmlThrDefDefaultBufferSize(v);
            return __ret;
        }

        public static global::libxml.XmlSAXHandlerV1 XmlDefaultSAXHandler()
        {
            var __ret = __Internal.XmlDefaultSAXHandler();
            global::libxml.XmlSAXHandlerV1 __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlSAXHandlerV1.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlSAXHandlerV1) global::libxml.XmlSAXHandlerV1.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlSAXHandlerV1.__CreateInstance(__ret);
            return __result0;
        }

        public static global::libxml.XmlSAXLocator XmlDefaultSAXLocator()
        {
            var __ret = __Internal.XmlDefaultSAXLocator();
            global::libxml.XmlSAXLocator __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (global::libxml.XmlSAXLocator.NativeToManagedMap.ContainsKey(__ret))
                __result0 = (global::libxml.XmlSAXLocator) global::libxml.XmlSAXLocator.NativeToManagedMap[__ret];
            else __result0 = global::libxml.XmlSAXLocator.__CreateInstance(__ret);
            return __result0;
        }

        public static int* XmlDoValidityCheckingDefaultValue()
        {
            var __ret = __Internal.XmlDoValidityCheckingDefaultValue();
            return __ret;
        }

        public static int XmlThrDefDoValidityCheckingDefaultValue(int v)
        {
            var __ret = __Internal.XmlThrDefDoValidityCheckingDefaultValue(v);
            return __ret;
        }

        public static global::libxml.XmlGenericErrorFunc XmlGenericError()
        {
            var __ret = __Internal.XmlGenericError();
            var __ptr0 = __ret;
            return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlGenericErrorFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlGenericErrorFunc));
        }

        public static global::libxml.XmlStructuredErrorFunc XmlStructuredError()
        {
            var __ret = __Internal.XmlStructuredError();
            var __ptr0 = __ret;
            return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlStructuredErrorFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlStructuredErrorFunc));
        }

        public static void** XmlGenericErrorContext()
        {
            var __ret = __Internal.XmlGenericErrorContext();
            return __ret;
        }

        public static void** XmlStructuredErrorContext()
        {
            var __ret = __Internal.XmlStructuredErrorContext();
            return __ret;
        }

        public static int* XmlGetWarningsDefaultValue()
        {
            var __ret = __Internal.XmlGetWarningsDefaultValue();
            return __ret;
        }

        public static int XmlThrDefGetWarningsDefaultValue(int v)
        {
            var __ret = __Internal.XmlThrDefGetWarningsDefaultValue(v);
            return __ret;
        }

        public static int* XmlIndentTreeOutput()
        {
            var __ret = __Internal.XmlIndentTreeOutput();
            return __ret;
        }

        public static int XmlThrDefIndentTreeOutput(int v)
        {
            var __ret = __Internal.XmlThrDefIndentTreeOutput(v);
            return __ret;
        }

        public static sbyte** XmlTreeIndentString()
        {
            var __ret = __Internal.XmlTreeIndentString();
            return __ret;
        }

        public static string XmlThrDefTreeIndentString(string v)
        {
            var __ret = __Internal.XmlThrDefTreeIndentString(v);
            if (__ret == global::System.IntPtr.Zero)
                return default(string);
            var __retPtr = (byte*) __ret;
            int __length = 0;
            while (*(__retPtr++) != 0) __length += sizeof(byte);
            return global::System.Text.Encoding.UTF8.GetString((byte*) __ret, __length);
        }

        public static int* XmlKeepBlanksDefaultValue()
        {
            var __ret = __Internal.XmlKeepBlanksDefaultValue();
            return __ret;
        }

        public static int XmlThrDefKeepBlanksDefaultValue(int v)
        {
            var __ret = __Internal.XmlThrDefKeepBlanksDefaultValue(v);
            return __ret;
        }

        public static int* XmlLineNumbersDefaultValue()
        {
            var __ret = __Internal.XmlLineNumbersDefaultValue();
            return __ret;
        }

        public static int XmlThrDefLineNumbersDefaultValue(int v)
        {
            var __ret = __Internal.XmlThrDefLineNumbersDefaultValue(v);
            return __ret;
        }

        public static int* XmlLoadExtDtdDefaultValue()
        {
            var __ret = __Internal.XmlLoadExtDtdDefaultValue();
            return __ret;
        }

        public static int XmlThrDefLoadExtDtdDefaultValue(int v)
        {
            var __ret = __Internal.XmlThrDefLoadExtDtdDefaultValue(v);
            return __ret;
        }

        public static int* XmlParserDebugEntities()
        {
            var __ret = __Internal.XmlParserDebugEntities();
            return __ret;
        }

        public static int XmlThrDefParserDebugEntities(int v)
        {
            var __ret = __Internal.XmlThrDefParserDebugEntities(v);
            return __ret;
        }

        public static sbyte** XmlParserVersion()
        {
            var __ret = __Internal.XmlParserVersion();
            return __ret;
        }

        public static int* XmlPedanticParserDefaultValue()
        {
            var __ret = __Internal.XmlPedanticParserDefaultValue();
            return __ret;
        }

        public static int XmlThrDefPedanticParserDefaultValue(int v)
        {
            var __ret = __Internal.XmlThrDefPedanticParserDefaultValue(v);
            return __ret;
        }

        public static int* XmlSaveNoEmptyTags()
        {
            var __ret = __Internal.XmlSaveNoEmptyTags();
            return __ret;
        }

        public static int XmlThrDefSaveNoEmptyTags(int v)
        {
            var __ret = __Internal.XmlThrDefSaveNoEmptyTags(v);
            return __ret;
        }

        public static int* XmlSubstituteEntitiesDefaultValue()
        {
            var __ret = __Internal.XmlSubstituteEntitiesDefaultValue();
            return __ret;
        }

        public static int XmlThrDefSubstituteEntitiesDefaultValue(int v)
        {
            var __ret = __Internal.XmlThrDefSubstituteEntitiesDefaultValue(v);
            return __ret;
        }

        public static global::libxml.XmlRegisterNodeFunc XmlRegisterNodeDefaultValue()
        {
            var __ret = __Internal.XmlRegisterNodeDefaultValue();
            var __ptr0 = __ret;
            return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlRegisterNodeFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlRegisterNodeFunc));
        }

        public static global::libxml.XmlDeregisterNodeFunc XmlDeregisterNodeDefaultValue()
        {
            var __ret = __Internal.XmlDeregisterNodeDefaultValue();
            var __ptr0 = __ret;
            return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlDeregisterNodeFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlDeregisterNodeFunc));
        }

        public static global::libxml.XmlParserInputBufferCreateFilenameFunc XmlParserInputBufferCreateFilenameValue()
        {
            var __ret = __Internal.XmlParserInputBufferCreateFilenameValue();
            var __ptr0 = __ret;
            return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlParserInputBufferCreateFilenameFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlParserInputBufferCreateFilenameFunc));
        }

        public static global::libxml.XmlOutputBufferCreateFilenameFunc XmlOutputBufferCreateFilenameValue()
        {
            var __ret = __Internal.XmlOutputBufferCreateFilenameValue();
            var __ptr0 = __ret;
            return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlOutputBufferCreateFilenameFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlOutputBufferCreateFilenameFunc));
        }

        public static global::libxml.XmlMallocFunc XmlMalloc
        {
            get
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlMalloc");
                var __ptr0 = *__ptr;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlMallocFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlMallocFunc));
            }

            set
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlMalloc");
                *__ptr = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public static global::libxml.XmlMallocFunc XmlMallocAtomic
        {
            get
            {
                // var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlMallocAtomic");
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlMallocAtomic");
                var __ptr0 = *__ptr;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlMallocFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlMallocFunc));
            }

            set
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlMallocAtomic");
                *__ptr = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public static global::libxml.XmlReallocFunc XmlRealloc
        {
            get
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlRealloc");
                var __ptr0 = *__ptr;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlReallocFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlReallocFunc));
            }

            set
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlRealloc");
                *__ptr = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public static global::libxml.XmlFreeFunc XmlFree
        {
            get
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlFree");
                var __ptr0 = *__ptr;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlFreeFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlFreeFunc));
            }

            set
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlFree");
                *__ptr = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public static global::libxml.XmlStrdupFunc XmlMemStrdup
        {
            get
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlMemStrdup");
                var __ptr0 = *__ptr;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlStrdupFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlStrdupFunc));
            }

            set
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlMemStrdup");
                *__ptr = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public static global::libxml.XmlSAXHandlerV1 docbDefaultSAXHandler
        {
            get
            {
                var __ptr = (global::libxml.XmlSAXHandlerV1.__Internal*)CppSharp.SymbolResolver.ResolveSymbol("1", "docbDefaultSAXHandler");
                return global::libxml.XmlSAXHandlerV1.__CreateInstance(*__ptr);
            }

            set
            {
                var __ptr = (global::libxml.XmlSAXHandlerV1.__Internal*)CppSharp.SymbolResolver.ResolveSymbol("1", "docbDefaultSAXHandler");
                if (ReferenceEquals(value, null))
                    throw new global::System.ArgumentNullException("value", "Cannot be null because it is passed by value.");
                *__ptr = *(global::libxml.XmlSAXHandlerV1.__Internal*) value.__Instance;
            }
        }

        public static global::libxml.XmlSAXHandlerV1 htmlDefaultSAXHandler
        {
            get
            {
                var __ptr = (global::libxml.XmlSAXHandlerV1.__Internal*)CppSharp.SymbolResolver.ResolveSymbol("1", "htmlDefaultSAXHandler");
                return global::libxml.XmlSAXHandlerV1.__CreateInstance(*__ptr);
            }

            set
            {
                var __ptr = (global::libxml.XmlSAXHandlerV1.__Internal*)CppSharp.SymbolResolver.ResolveSymbol("1", "htmlDefaultSAXHandler");
                if (ReferenceEquals(value, null))
                    throw new global::System.ArgumentNullException("value", "Cannot be null because it is passed by value.");
                *__ptr = *(global::libxml.XmlSAXHandlerV1.__Internal*) value.__Instance;
            }
        }

        public static global::libxml.XmlError xmlLastError
        {
            get
            {
                var __ptr = (global::libxml.XmlError.__Internal*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlLastError");
                return global::libxml.XmlError.__CreateInstance(*__ptr);
            }

            set
            {
                var __ptr = (global::libxml.XmlError.__Internal*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlLastError");
                if (ReferenceEquals(value, null))
                    throw new global::System.ArgumentNullException("value", "Cannot be null because it is passed by value.");
                *__ptr = *(global::libxml.XmlError.__Internal*) value.__Instance;
            }
        }

        public static int oldXMLWDcompatibility
        {
            get
            {
                var __ptr = (int*)CppSharp.SymbolResolver.ResolveSymbol("1", "oldXMLWDcompatibility");
                return *__ptr;
            }

            set
            {
                var __ptr = (int*)CppSharp.SymbolResolver.ResolveSymbol("1", "oldXMLWDcompatibility");
                *__ptr = value;
            }
        }

        public static global::libxml.XmlBufferAllocationScheme xmlBufferAllocScheme
        {
            get
            {
                var __ptr = (global::libxml.XmlBufferAllocationScheme*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlBufferAllocScheme");
                return *__ptr;
            }

            set
            {
                var __ptr = (global::libxml.XmlBufferAllocationScheme*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlBufferAllocScheme");
                *__ptr = value;
            }
        }

        public static int xmlDefaultBufferSize
        {
            get
            {
                var __ptr = (int*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlDefaultBufferSize");
                return *__ptr;
            }

            set
            {
                var __ptr = (int*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlDefaultBufferSize");
                *__ptr = value;
            }
        }

        public static global::libxml.XmlSAXHandlerV1 xmlDefaultSAXHandler
        {
            get
            {
                var __ptr = (global::libxml.XmlSAXHandlerV1.__Internal*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlDefaultSAXHandler");
                return global::libxml.XmlSAXHandlerV1.__CreateInstance(*__ptr);
            }

            set
            {
                var __ptr = (global::libxml.XmlSAXHandlerV1.__Internal*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlDefaultSAXHandler");
                if (ReferenceEquals(value, null))
                    throw new global::System.ArgumentNullException("value", "Cannot be null because it is passed by value.");
                *__ptr = *(global::libxml.XmlSAXHandlerV1.__Internal*) value.__Instance;
            }
        }

        public static global::libxml.XmlSAXLocator xmlDefaultSAXLocator
        {
            get
            {
                var __ptr = (global::libxml.XmlSAXLocator.__Internal*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlDefaultSAXLocator");
                return global::libxml.XmlSAXLocator.__CreateInstance(*__ptr);
            }

            set
            {
                var __ptr = (global::libxml.XmlSAXLocator.__Internal*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlDefaultSAXLocator");
                if (ReferenceEquals(value, null))
                    throw new global::System.ArgumentNullException("value", "Cannot be null because it is passed by value.");
                *__ptr = *(global::libxml.XmlSAXLocator.__Internal*) value.__Instance;
            }
        }

        public static int xmlDoValidityCheckingDefaultValue
        {
            get
            {
                var __ptr = (int*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlDoValidityCheckingDefaultValue");
                return *__ptr;
            }

            set
            {
                var __ptr = (int*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlDoValidityCheckingDefaultValue");
                *__ptr = value;
            }
        }

        public static global::libxml.XmlGenericErrorFunc xmlGenericError
        {
            get
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlGenericError");
                var __ptr0 = *__ptr;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlGenericErrorFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlGenericErrorFunc));
            }

            set
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlGenericError");
                *__ptr = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public static global::libxml.XmlStructuredErrorFunc xmlStructuredError
        {
            get
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlStructuredError");
                var __ptr0 = *__ptr;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlStructuredErrorFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlStructuredErrorFunc));
            }

            set
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlStructuredError");
                *__ptr = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public static global::System.IntPtr xmlGenericErrorContext
        {
            get
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlGenericErrorContext");
                return *__ptr;
            }

            set
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlGenericErrorContext");
                *__ptr = value;
            }
        }

        public static global::System.IntPtr xmlStructuredErrorContext
        {
            get
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlStructuredErrorContext");
                return *__ptr;
            }

            set
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlStructuredErrorContext");
                *__ptr = value;
            }
        }

        public static int xmlGetWarningsDefaultValue
        {
            get
            {
                var __ptr = (int*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlGetWarningsDefaultValue");
                return *__ptr;
            }

            set
            {
                var __ptr = (int*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlGetWarningsDefaultValue");
                *__ptr = value;
            }
        }

        public static int xmlIndentTreeOutput
        {
            get
            {
                var __ptr = (int*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlIndentTreeOutput");
                return *__ptr;
            }

            set
            {
                var __ptr = (int*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlIndentTreeOutput");
                *__ptr = value;
            }
        }

        public static string xmlTreeIndentString
        {
            get
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlTreeIndentString");
                if (*__ptr == global::System.IntPtr.Zero)
                    return default(string);
                var __retPtr = (byte*) *__ptr;
                int __length = 0;
                while (*(__retPtr++) != 0) __length += sizeof(byte);
                return global::System.Text.Encoding.UTF8.GetString((byte*) *__ptr, __length);
            }

            set
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlTreeIndentString");
                byte[] __bytes0 = global::System.Text.Encoding.UTF8.GetBytes(value);
                fixed (byte* __bytePtr0 = __bytes0)
                {
                    *__ptr = new global::System.IntPtr(__bytePtr0);
                }
            }
        }

        public static int xmlKeepBlanksDefaultValue
        {
            get
            {
                var __ptr = (int*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlKeepBlanksDefaultValue");
                return *__ptr;
            }

            set
            {
                var __ptr = (int*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlKeepBlanksDefaultValue");
                *__ptr = value;
            }
        }

        public static int xmlLineNumbersDefaultValue
        {
            get
            {
                var __ptr = (int*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlLineNumbersDefaultValue");
                return *__ptr;
            }

            set
            {
                var __ptr = (int*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlLineNumbersDefaultValue");
                *__ptr = value;
            }
        }

        public static int xmlLoadExtDtdDefaultValue
        {
            get
            {
                var __ptr = (int*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlLoadExtDtdDefaultValue");
                return *__ptr;
            }

            set
            {
                var __ptr = (int*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlLoadExtDtdDefaultValue");
                *__ptr = value;
            }
        }

        public static int xmlParserDebugEntities
        {
            get
            {
                var __ptr = (int*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlParserDebugEntities");
                return *__ptr;
            }

            set
            {
                var __ptr = (int*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlParserDebugEntities");
                *__ptr = value;
            }
        }

        public static string xmlParserVersion
        {
            get
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlParserVersion");
                if (*__ptr == global::System.IntPtr.Zero)
                    return default(string);
                var __retPtr = (byte*) *__ptr;
                int __length = 0;
                while (*(__retPtr++) != 0) __length += sizeof(byte);
                return global::System.Text.Encoding.UTF8.GetString((byte*) *__ptr, __length);
            }

            set
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlParserVersion");
                byte[] __bytes0 = global::System.Text.Encoding.UTF8.GetBytes(value);
                fixed (byte* __bytePtr0 = __bytes0)
                {
                    *__ptr = new global::System.IntPtr(__bytePtr0);
                }
            }
        }

        public static int xmlPedanticParserDefaultValue
        {
            get
            {
                var __ptr = (int*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlPedanticParserDefaultValue");
                return *__ptr;
            }

            set
            {
                var __ptr = (int*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlPedanticParserDefaultValue");
                *__ptr = value;
            }
        }

        public static int xmlSaveNoEmptyTags
        {
            get
            {
                var __ptr = (int*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlSaveNoEmptyTags");
                return *__ptr;
            }

            set
            {
                var __ptr = (int*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlSaveNoEmptyTags");
                *__ptr = value;
            }
        }

        public static int xmlSubstituteEntitiesDefaultValue
        {
            get
            {
                var __ptr = (int*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlSubstituteEntitiesDefaultValue");
                return *__ptr;
            }

            set
            {
                var __ptr = (int*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlSubstituteEntitiesDefaultValue");
                *__ptr = value;
            }
        }

        public static global::libxml.XmlRegisterNodeFunc xmlRegisterNodeDefaultValue
        {
            get
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlRegisterNodeDefaultValue");
                var __ptr0 = *__ptr;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlRegisterNodeFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlRegisterNodeFunc));
            }

            set
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlRegisterNodeDefaultValue");
                *__ptr = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public static global::libxml.XmlDeregisterNodeFunc xmlDeregisterNodeDefaultValue
        {
            get
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlDeregisterNodeDefaultValue");
                var __ptr0 = *__ptr;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlDeregisterNodeFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlDeregisterNodeFunc));
            }

            set
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlDeregisterNodeDefaultValue");
                *__ptr = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public static global::libxml.XmlParserInputBufferCreateFilenameFunc xmlParserInputBufferCreateFilenameValue
        {
            get
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlParserInputBufferCreateFilenameValue");
                var __ptr0 = *__ptr;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlParserInputBufferCreateFilenameFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlParserInputBufferCreateFilenameFunc));
            }

            set
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlParserInputBufferCreateFilenameValue");
                *__ptr = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }

        public static global::libxml.XmlOutputBufferCreateFilenameFunc xmlOutputBufferCreateFilenameValue
        {
            get
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlOutputBufferCreateFilenameValue");
                var __ptr0 = *__ptr;
                return __ptr0 == IntPtr.Zero? null : (global::libxml.XmlOutputBufferCreateFilenameFunc) Marshal.GetDelegateForFunctionPointer(__ptr0, typeof(global::libxml.XmlOutputBufferCreateFilenameFunc));
            }

            set
            {
                var __ptr = (global::System.IntPtr*)CppSharp.SymbolResolver.ResolveSymbol("1", "xmlOutputBufferCreateFilenameValue");
                *__ptr = value == null ? global::System.IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }
    }
}