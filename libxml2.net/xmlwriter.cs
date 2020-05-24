using System;
using System.Runtime.InteropServices;
using System.Security;

namespace libxml
{
    public unsafe class xmlwriter
    {
        private const string lib = "/usr/local/Cellar/libxml2/2.9.9_2/lib/libxml2.2.dylib";
        public struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlNewTextWriter")]
            internal static extern IntPtr XmlNewTextWriter(IntPtr @out);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlNewTextWriterFilename")]
            internal static extern IntPtr XmlNewTextWriterFilename([MarshalAs(UnmanagedType.LPUTF8Str)] string uri, int compression);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlNewTextWriterMemory")]
            internal static extern IntPtr XmlNewTextWriterMemory(IntPtr buf, int compression);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlNewTextWriterPushParser")]
            internal static extern IntPtr XmlNewTextWriterPushParser(IntPtr ctxt, int compression);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlNewTextWriterDoc")]
            internal static extern IntPtr XmlNewTextWriterDoc(IntPtr doc, int compression);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlNewTextWriterTree")]
            internal static extern IntPtr XmlNewTextWriterTree(IntPtr doc, IntPtr node, int compression);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlFreeTextWriter")]
            internal static extern void XmlFreeTextWriter(IntPtr writer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterStartDocument")]
            internal static extern int XmlTextWriterStartDocument(IntPtr writer, [MarshalAs(UnmanagedType.LPUTF8Str)] string version, [MarshalAs(UnmanagedType.LPUTF8Str)] string encoding, [MarshalAs(UnmanagedType.LPUTF8Str)] string standalone);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterEndDocument")]
            internal static extern int XmlTextWriterEndDocument(IntPtr writer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterStartComment")]
            internal static extern int XmlTextWriterStartComment(IntPtr writer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterEndComment")]
            internal static extern int XmlTextWriterEndComment(IntPtr writer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteFormatComment")]
            internal static extern int XmlTextWriterWriteFormatComment(IntPtr writer, [MarshalAs(UnmanagedType.LPUTF8Str)] string format);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteComment")]
            internal static extern int XmlTextWriterWriteComment(IntPtr writer, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterStartElement")]
            internal static extern int XmlTextWriterStartElement(IntPtr writer, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterStartElementNS")]
            internal static extern int XmlTextWriterStartElementNS(IntPtr writer, byte* prefix, byte* name, byte* namespaceURI);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterEndElement")]
            internal static extern int XmlTextWriterEndElement(IntPtr writer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterFullEndElement")]
            internal static extern int XmlTextWriterFullEndElement(IntPtr writer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteFormatElement")]
            internal static extern int XmlTextWriterWriteFormatElement(IntPtr writer, byte* name, [MarshalAs(UnmanagedType.LPUTF8Str)] string format);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteElement")]
            internal static extern int XmlTextWriterWriteElement(IntPtr writer, byte* name, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteFormatElementNS")]
            internal static extern int XmlTextWriterWriteFormatElementNS(IntPtr writer, byte* prefix, byte* name, byte* namespaceURI, [MarshalAs(UnmanagedType.LPUTF8Str)] string format);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteElementNS")]
            internal static extern int XmlTextWriterWriteElementNS(IntPtr writer, byte* prefix, byte* name, byte* namespaceURI, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteFormatRaw")]
            internal static extern int XmlTextWriterWriteFormatRaw(IntPtr writer, [MarshalAs(UnmanagedType.LPUTF8Str)] string format);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteRawLen")]
            internal static extern int XmlTextWriterWriteRawLen(IntPtr writer, byte* content, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteRaw")]
            internal static extern int XmlTextWriterWriteRaw(IntPtr writer, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteFormatString")]
            internal static extern int XmlTextWriterWriteFormatString(IntPtr writer, [MarshalAs(UnmanagedType.LPUTF8Str)] string format);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteString")]
            internal static extern int XmlTextWriterWriteString(IntPtr writer, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteBase64")]
            internal static extern int XmlTextWriterWriteBase64(IntPtr writer, [MarshalAs(UnmanagedType.LPUTF8Str)] string data, int start, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteBinHex")]
            internal static extern int XmlTextWriterWriteBinHex(IntPtr writer, [MarshalAs(UnmanagedType.LPUTF8Str)] string data, int start, int len);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterStartAttribute")]
            internal static extern int XmlTextWriterStartAttribute(IntPtr writer, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterStartAttributeNS")]
            internal static extern int XmlTextWriterStartAttributeNS(IntPtr writer, byte* prefix, byte* name, byte* namespaceURI);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterEndAttribute")]
            internal static extern int XmlTextWriterEndAttribute(IntPtr writer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteFormatAttribute")]
            internal static extern int XmlTextWriterWriteFormatAttribute(IntPtr writer, byte* name, [MarshalAs(UnmanagedType.LPUTF8Str)] string format);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteAttribute")]
            internal static extern int XmlTextWriterWriteAttribute(IntPtr writer, byte* name, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteFormatAttributeNS")]
            internal static extern int XmlTextWriterWriteFormatAttributeNS(IntPtr writer, byte* prefix, byte* name, byte* namespaceURI, [MarshalAs(UnmanagedType.LPUTF8Str)] string format);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteAttributeNS")]
            internal static extern int XmlTextWriterWriteAttributeNS(IntPtr writer, byte* prefix, byte* name, byte* namespaceURI, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterStartPI")]
            internal static extern int XmlTextWriterStartPI(IntPtr writer, byte* target);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterEndPI")]
            internal static extern int XmlTextWriterEndPI(IntPtr writer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteFormatPI")]
            internal static extern int XmlTextWriterWriteFormatPI(IntPtr writer, byte* target, [MarshalAs(UnmanagedType.LPUTF8Str)] string format);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWritePI")]
            internal static extern int XmlTextWriterWritePI(IntPtr writer, byte* target, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterStartCDATA")]
            internal static extern int XmlTextWriterStartCDATA(IntPtr writer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterEndCDATA")]
            internal static extern int XmlTextWriterEndCDATA(IntPtr writer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteFormatCDATA")]
            internal static extern int XmlTextWriterWriteFormatCDATA(IntPtr writer, [MarshalAs(UnmanagedType.LPUTF8Str)] string format);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteCDATA")]
            internal static extern int XmlTextWriterWriteCDATA(IntPtr writer, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterStartDTD")]
            internal static extern int XmlTextWriterStartDTD(IntPtr writer, byte* name, byte* pubid, byte* sysid);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterEndDTD")]
            internal static extern int XmlTextWriterEndDTD(IntPtr writer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteFormatDTD")]
            internal static extern int XmlTextWriterWriteFormatDTD(IntPtr writer, byte* name, byte* pubid, byte* sysid, [MarshalAs(UnmanagedType.LPUTF8Str)] string format);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteDTD")]
            internal static extern int XmlTextWriterWriteDTD(IntPtr writer, byte* name, byte* pubid, byte* sysid, byte* subset);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterStartDTDElement")]
            internal static extern int XmlTextWriterStartDTDElement(IntPtr writer, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterEndDTDElement")]
            internal static extern int XmlTextWriterEndDTDElement(IntPtr writer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteFormatDTDElement")]
            internal static extern int XmlTextWriterWriteFormatDTDElement(IntPtr writer, byte* name, [MarshalAs(UnmanagedType.LPUTF8Str)] string format);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteDTDElement")]
            internal static extern int XmlTextWriterWriteDTDElement(IntPtr writer, byte* name, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterStartDTDAttlist")]
            internal static extern int XmlTextWriterStartDTDAttlist(IntPtr writer, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterEndDTDAttlist")]
            internal static extern int XmlTextWriterEndDTDAttlist(IntPtr writer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteFormatDTDAttlist")]
            internal static extern int XmlTextWriterWriteFormatDTDAttlist(IntPtr writer, byte* name, [MarshalAs(UnmanagedType.LPUTF8Str)] string format);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteDTDAttlist")]
            internal static extern int XmlTextWriterWriteDTDAttlist(IntPtr writer, byte* name, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterStartDTDEntity")]
            internal static extern int XmlTextWriterStartDTDEntity(IntPtr writer, int pe, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterEndDTDEntity")]
            internal static extern int XmlTextWriterEndDTDEntity(IntPtr writer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteFormatDTDInternalEntity")]
            internal static extern int XmlTextWriterWriteFormatDTDInternalEntity(IntPtr writer, int pe, byte* name, [MarshalAs(UnmanagedType.LPUTF8Str)] string format);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteDTDInternalEntity")]
            internal static extern int XmlTextWriterWriteDTDInternalEntity(IntPtr writer, int pe, byte* name, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteDTDExternalEntity")]
            internal static extern int XmlTextWriterWriteDTDExternalEntity(IntPtr writer, int pe, byte* name, byte* pubid, byte* sysid, byte* ndataid);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteDTDExternalEntityContents")]
            internal static extern int XmlTextWriterWriteDTDExternalEntityContents(IntPtr writer, byte* pubid, byte* sysid, byte* ndataid);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteDTDEntity")]
            internal static extern int XmlTextWriterWriteDTDEntity(IntPtr writer, int pe, byte* name, byte* pubid, byte* sysid, byte* ndataid, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterWriteDTDNotation")]
            internal static extern int XmlTextWriterWriteDTDNotation(IntPtr writer, byte* name, byte* pubid, byte* sysid);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterSetIndent")]
            internal static extern int XmlTextWriterSetIndent(IntPtr writer, int indent);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterSetIndentString")]
            internal static extern int XmlTextWriterSetIndentString(IntPtr writer, byte* str);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterSetQuoteChar")]
            internal static extern int XmlTextWriterSetQuoteChar(IntPtr writer, byte quotechar);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(lib, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterFlush")]
            internal static extern int XmlTextWriterFlush(IntPtr writer);
        }

        public static XmlTextWriter XmlNewTextWriter(XmlOutputBuffer @out)
        {
            var __arg0 = ReferenceEquals(@out, null) ? IntPtr.Zero : @out.__Instance;
            var __ret = __Internal.XmlNewTextWriter(__arg0);
            XmlTextWriter __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (XmlTextWriter.NativeToManagedMap.ContainsKey(__ret))
                __result0 = XmlTextWriter.NativeToManagedMap[__ret];
            else __result0 = XmlTextWriter.__CreateInstance(__ret);
            return __result0;
        }

        public static XmlTextWriter XmlNewTextWriterFilename(string uri, int compression)
        {
            var __ret = __Internal.XmlNewTextWriterFilename(uri, compression);
            XmlTextWriter __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (XmlTextWriter.NativeToManagedMap.ContainsKey(__ret))
                __result0 = XmlTextWriter.NativeToManagedMap[__ret];
            else __result0 = XmlTextWriter.__CreateInstance(__ret);
            return __result0;
        }

        public static XmlTextWriter XmlNewTextWriterMemory(XmlBuffer buf, int compression)
        {
            var __arg0 = ReferenceEquals(buf, null) ? IntPtr.Zero : buf.__Instance;
            var __ret = __Internal.XmlNewTextWriterMemory(__arg0, compression);
            XmlTextWriter __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (XmlTextWriter.NativeToManagedMap.ContainsKey(__ret))
                __result0 = XmlTextWriter.NativeToManagedMap[__ret];
            else __result0 = XmlTextWriter.__CreateInstance(__ret);
            return __result0;
        }

        public static XmlTextWriter XmlNewTextWriterPushParser(XmlParserCtxt ctxt, int compression)
        {
            var __arg0 = ReferenceEquals(ctxt, null) ? IntPtr.Zero : ctxt.__Instance;
            var __ret = __Internal.XmlNewTextWriterPushParser(__arg0, compression);
            XmlTextWriter __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (XmlTextWriter.NativeToManagedMap.ContainsKey(__ret))
                __result0 = XmlTextWriter.NativeToManagedMap[__ret];
            else __result0 = XmlTextWriter.__CreateInstance(__ret);
            return __result0;
        }

        public static XmlTextWriter XmlNewTextWriterDoc(XmlDoc doc, int compression)
        {
            var ____arg0 = ReferenceEquals(doc, null) ? IntPtr.Zero : doc.__Instance;
            var __arg0 = new IntPtr(&____arg0);
            var __ret = __Internal.XmlNewTextWriterDoc(__arg0, compression);
            XmlTextWriter __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (XmlTextWriter.NativeToManagedMap.ContainsKey(__ret))
                __result0 = XmlTextWriter.NativeToManagedMap[__ret];
            else __result0 = XmlTextWriter.__CreateInstance(__ret);
            return __result0;
        }

        public static XmlTextWriter XmlNewTextWriterTree(XmlDoc doc, XmlNode node, int compression)
        {
            var __arg0 = ReferenceEquals(doc, null) ? IntPtr.Zero : doc.__Instance;
            var __arg1 = ReferenceEquals(node, null) ? IntPtr.Zero : node.__Instance;
            var __ret = __Internal.XmlNewTextWriterTree(__arg0, __arg1, compression);
            XmlTextWriter __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (XmlTextWriter.NativeToManagedMap.ContainsKey(__ret))
                __result0 = XmlTextWriter.NativeToManagedMap[__ret];
            else __result0 = XmlTextWriter.__CreateInstance(__ret);
            return __result0;
        }

        public static void XmlFreeTextWriter(XmlTextWriter writer)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            __Internal.XmlFreeTextWriter(__arg0);
        }

        public static int XmlTextWriterStartDocument(XmlTextWriter writer, string version, string encoding, string standalone)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterStartDocument(__arg0, version, encoding, standalone);
            return __ret;
        }

        public static int XmlTextWriterEndDocument(XmlTextWriter writer)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterEndDocument(__arg0);
            return __ret;
        }

        public static int XmlTextWriterStartComment(XmlTextWriter writer)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterStartComment(__arg0);
            return __ret;
        }

        public static int XmlTextWriterEndComment(XmlTextWriter writer)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterEndComment(__arg0);
            return __ret;
        }

        public static int XmlTextWriterWriteFormatComment(XmlTextWriter writer, string format)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteFormatComment(__arg0, format);
            return __ret;
        }

        public static int XmlTextWriterWriteComment(XmlTextWriter writer, byte* content)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteComment(__arg0, content);
            return __ret;
        }

        public static int XmlTextWriterStartElement(XmlTextWriter writer, byte* name)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterStartElement(__arg0, name);
            return __ret;
        }

        public static int XmlTextWriterStartElementNS(XmlTextWriter writer, byte* prefix, byte* name, byte* namespaceURI)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterStartElementNS(__arg0, prefix, name, namespaceURI);
            return __ret;
        }

        public static int XmlTextWriterEndElement(XmlTextWriter writer)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterEndElement(__arg0);
            return __ret;
        }

        public static int XmlTextWriterFullEndElement(XmlTextWriter writer)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterFullEndElement(__arg0);
            return __ret;
        }

        public static int XmlTextWriterWriteFormatElement(XmlTextWriter writer, byte* name, string format)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteFormatElement(__arg0, name, format);
            return __ret;
        }

        public static int XmlTextWriterWriteElement(XmlTextWriter writer, byte* name, byte* content)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteElement(__arg0, name, content);
            return __ret;
        }

        public static int XmlTextWriterWriteFormatElementNS(XmlTextWriter writer, byte* prefix, byte* name, byte* namespaceURI, string format)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteFormatElementNS(__arg0, prefix, name, namespaceURI, format);
            return __ret;
        }

        public static int XmlTextWriterWriteElementNS(XmlTextWriter writer, byte* prefix, byte* name, byte* namespaceURI, byte* content)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteElementNS(__arg0, prefix, name, namespaceURI, content);
            return __ret;
        }

        public static int XmlTextWriterWriteFormatRaw(XmlTextWriter writer, string format)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteFormatRaw(__arg0, format);
            return __ret;
        }

        public static int XmlTextWriterWriteRawLen(XmlTextWriter writer, byte* content, int len)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteRawLen(__arg0, content, len);
            return __ret;
        }

        public static int XmlTextWriterWriteRaw(XmlTextWriter writer, byte* content)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteRaw(__arg0, content);
            return __ret;
        }

        public static int XmlTextWriterWriteFormatString(XmlTextWriter writer, string format)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteFormatString(__arg0, format);
            return __ret;
        }

        public static int XmlTextWriterWriteString(XmlTextWriter writer, byte* content)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteString(__arg0, content);
            return __ret;
        }

        public static int XmlTextWriterWriteBase64(XmlTextWriter writer, string data, int start, int len)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteBase64(__arg0, data, start, len);
            return __ret;
        }

        public static int XmlTextWriterWriteBinHex(XmlTextWriter writer, string data, int start, int len)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteBinHex(__arg0, data, start, len);
            return __ret;
        }

        public static int XmlTextWriterStartAttribute(XmlTextWriter writer, byte* name)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterStartAttribute(__arg0, name);
            return __ret;
        }

        public static int XmlTextWriterStartAttributeNS(XmlTextWriter writer, byte* prefix, byte* name, byte* namespaceURI)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterStartAttributeNS(__arg0, prefix, name, namespaceURI);
            return __ret;
        }

        public static int XmlTextWriterEndAttribute(XmlTextWriter writer)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterEndAttribute(__arg0);
            return __ret;
        }

        public static int XmlTextWriterWriteFormatAttribute(XmlTextWriter writer, byte* name, string format)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteFormatAttribute(__arg0, name, format);
            return __ret;
        }

        public static int XmlTextWriterWriteAttribute(XmlTextWriter writer, byte* name, byte* content)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteAttribute(__arg0, name, content);
            return __ret;
        }

        public static int XmlTextWriterWriteFormatAttributeNS(XmlTextWriter writer, byte* prefix, byte* name, byte* namespaceURI, string format)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteFormatAttributeNS(__arg0, prefix, name, namespaceURI, format);
            return __ret;
        }

        public static int XmlTextWriterWriteAttributeNS(XmlTextWriter writer, byte* prefix, byte* name, byte* namespaceURI, byte* content)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteAttributeNS(__arg0, prefix, name, namespaceURI, content);
            return __ret;
        }

        public static int XmlTextWriterStartPI(XmlTextWriter writer, byte* target)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterStartPI(__arg0, target);
            return __ret;
        }

        public static int XmlTextWriterEndPI(XmlTextWriter writer)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterEndPI(__arg0);
            return __ret;
        }

        public static int XmlTextWriterWriteFormatPI(XmlTextWriter writer, byte* target, string format)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteFormatPI(__arg0, target, format);
            return __ret;
        }

        public static int XmlTextWriterWritePI(XmlTextWriter writer, byte* target, byte* content)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWritePI(__arg0, target, content);
            return __ret;
        }

        public static int XmlTextWriterStartCDATA(XmlTextWriter writer)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterStartCDATA(__arg0);
            return __ret;
        }

        public static int XmlTextWriterEndCDATA(XmlTextWriter writer)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterEndCDATA(__arg0);
            return __ret;
        }

        public static int XmlTextWriterWriteFormatCDATA(XmlTextWriter writer, string format)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteFormatCDATA(__arg0, format);
            return __ret;
        }

        public static int XmlTextWriterWriteCDATA(XmlTextWriter writer, byte* content)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteCDATA(__arg0, content);
            return __ret;
        }

        public static int XmlTextWriterStartDTD(XmlTextWriter writer, byte* name, byte* pubid, byte* sysid)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterStartDTD(__arg0, name, pubid, sysid);
            return __ret;
        }

        public static int XmlTextWriterEndDTD(XmlTextWriter writer)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterEndDTD(__arg0);
            return __ret;
        }

        public static int XmlTextWriterWriteFormatDTD(XmlTextWriter writer, byte* name, byte* pubid, byte* sysid, string format)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteFormatDTD(__arg0, name, pubid, sysid, format);
            return __ret;
        }

        public static int XmlTextWriterWriteDTD(XmlTextWriter writer, byte* name, byte* pubid, byte* sysid, byte* subset)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteDTD(__arg0, name, pubid, sysid, subset);
            return __ret;
        }

        public static int XmlTextWriterStartDTDElement(XmlTextWriter writer, byte* name)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterStartDTDElement(__arg0, name);
            return __ret;
        }

        public static int XmlTextWriterEndDTDElement(XmlTextWriter writer)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterEndDTDElement(__arg0);
            return __ret;
        }

        public static int XmlTextWriterWriteFormatDTDElement(XmlTextWriter writer, byte* name, string format)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteFormatDTDElement(__arg0, name, format);
            return __ret;
        }

        public static int XmlTextWriterWriteDTDElement(XmlTextWriter writer, byte* name, byte* content)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteDTDElement(__arg0, name, content);
            return __ret;
        }

        public static int XmlTextWriterStartDTDAttlist(XmlTextWriter writer, byte* name)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterStartDTDAttlist(__arg0, name);
            return __ret;
        }

        public static int XmlTextWriterEndDTDAttlist(XmlTextWriter writer)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterEndDTDAttlist(__arg0);
            return __ret;
        }

        public static int XmlTextWriterWriteFormatDTDAttlist(XmlTextWriter writer, byte* name, string format)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteFormatDTDAttlist(__arg0, name, format);
            return __ret;
        }

        public static int XmlTextWriterWriteDTDAttlist(XmlTextWriter writer, byte* name, byte* content)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteDTDAttlist(__arg0, name, content);
            return __ret;
        }

        public static int XmlTextWriterStartDTDEntity(XmlTextWriter writer, int pe, byte* name)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterStartDTDEntity(__arg0, pe, name);
            return __ret;
        }

        public static int XmlTextWriterEndDTDEntity(XmlTextWriter writer)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterEndDTDEntity(__arg0);
            return __ret;
        }

        public static int XmlTextWriterWriteFormatDTDInternalEntity(XmlTextWriter writer, int pe, byte* name, string format)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteFormatDTDInternalEntity(__arg0, pe, name, format);
            return __ret;
        }

        public static int XmlTextWriterWriteDTDInternalEntity(XmlTextWriter writer, int pe, byte* name, byte* content)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteDTDInternalEntity(__arg0, pe, name, content);
            return __ret;
        }

        public static int XmlTextWriterWriteDTDExternalEntity(XmlTextWriter writer, int pe, byte* name, byte* pubid, byte* sysid, byte* ndataid)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteDTDExternalEntity(__arg0, pe, name, pubid, sysid, ndataid);
            return __ret;
        }

        public static int XmlTextWriterWriteDTDExternalEntityContents(XmlTextWriter writer, byte* pubid, byte* sysid, byte* ndataid)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteDTDExternalEntityContents(__arg0, pubid, sysid, ndataid);
            return __ret;
        }

        public static int XmlTextWriterWriteDTDEntity(XmlTextWriter writer, int pe, byte* name, byte* pubid, byte* sysid, byte* ndataid, byte* content)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteDTDEntity(__arg0, pe, name, pubid, sysid, ndataid, content);
            return __ret;
        }

        public static int XmlTextWriterWriteDTDNotation(XmlTextWriter writer, byte* name, byte* pubid, byte* sysid)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterWriteDTDNotation(__arg0, name, pubid, sysid);
            return __ret;
        }

        public static int XmlTextWriterSetIndent(XmlTextWriter writer, int indent)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterSetIndent(__arg0, indent);
            return __ret;
        }

        public static int XmlTextWriterSetIndentString(XmlTextWriter writer, byte* str)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterSetIndentString(__arg0, str);
            return __ret;
        }

        public static int XmlTextWriterSetQuoteChar(XmlTextWriter writer, byte quotechar)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterSetQuoteChar(__arg0, quotechar);
            return __ret;
        }

        public static int XmlTextWriterFlush(XmlTextWriter writer)
        {
            var __arg0 = ReferenceEquals(writer, null) ? IntPtr.Zero : writer.__Instance;
            var __ret = __Internal.XmlTextWriterFlush(__arg0);
            return __ret;
        }
    }
}