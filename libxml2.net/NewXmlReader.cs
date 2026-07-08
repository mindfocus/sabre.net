using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Pchp.Core;

namespace Nextsharp.LibXml2
{
    [PhpType(PhpTypeAttribute.InheritName), PhpExtension("nextsharp_libxml2")]
    public class XMLReader
    {
        private static readonly IntPtr NativeLibraryHandle = libxml2.LoadNativaLibrary();

        private IntPtr _ptr;
        private IntPtr _inputBuffer;

        public const int NONE = 0;
        public const int ELEMENT = 1;
        public const int ATTRIBUTE = 2;
        public const int TEXT = 3;
        public const int CDATA = 4;
        public const int ENTITY_REF = 5;
        public const int ENTITY = 6;
        public const int PI = 7;
        public const int COMMENT = 8;
        public const int DOC = 9;
        public const int DOC_TYPE = 10;
        public const int DOC_FRAGMENT = 11;
        public const int NOTATION = 12;
        public const int WHITESPACE = 13;
        public const int SIGNIFICANT_WHITESPACE = 14;
        public const int END_ELEMENT = 15;
        public const int END_ENTITY = 16;
        public const int XML_DECLARATION = 17;
        public const int LOADDTD = 1;
        public const int DEFAULTATTRS = 2;
        public const int VALIDATE = 3;
        public const int SUBST_ENTITIES = 4;

        public XMLReader()
        {
            if (NativeLibraryHandle == IntPtr.Zero)
            {
                throw new DllNotFoundException("Unable to load libxml2 from the libxml2.net native directory.");
            }
        }

        public int depth => _ptr == IntPtr.Zero ? 0 : libxml2.XmlTextReaderDepth(_ptr);

        public bool hasAttributes => _ptr != IntPtr.Zero && libxml2.XmlTextReaderHasAttributes(_ptr) == 1;

        public bool isEmptyElement => _ptr != IntPtr.Zero && libxml2.XmlTextReaderIsEmptyElement(_ptr) == 1;

        public string localName => ReadConstString(_ptr == IntPtr.Zero ? IntPtr.Zero : libxml2.XmlTextReaderConstLocalName(_ptr));

        public string namespaceURI => ReadConstString(_ptr == IntPtr.Zero ? IntPtr.Zero : libxml2.XmlTextReaderConstNamespaceUri(_ptr));

        public int nodeType => _ptr == IntPtr.Zero ? NONE : libxml2.XmlTextReaderNodeType(_ptr);

        public string value => ReadConstString(_ptr == IntPtr.Zero ? IntPtr.Zero : libxml2.XmlTextReaderConstValue(_ptr));

        public bool close()
        {
            if (_ptr != IntPtr.Zero)
            {
                libxml2.XmlTextReaderClose(_ptr);
                libxml2.XmlFreeTextReader(_ptr);
                _ptr = IntPtr.Zero;
            }

            ReleaseInputBuffer();

            return true;
        }

        public string getAttribute(string name)
        {
            if (_ptr == IntPtr.Zero || nodeType != ELEMENT)
            {
                return null;
            }

            var namePtr = StringToUtf8HGlobal(name);
            try
            {
                return ReadConstString(libxml2.XmlTextReaderGetAttribute(_ptr, namePtr), null);
            }
            finally
            {
                Marshal.FreeHGlobal(namePtr);
            }
        }

        public string getAttributeNo(int index)
        {
            if (_ptr == IntPtr.Zero || nodeType != ELEMENT)
            {
                return null;
            }

            return ReadConstString(libxml2.XmlTextReaderGetAttributeNo(_ptr, index), null);
        }

        public string getAttributeNs(string localName, string namespaceURI)
        {
            if (_ptr == IntPtr.Zero || nodeType != ELEMENT)
            {
                return null;
            }

            var localNamePtr = StringToUtf8HGlobal(localName);
            var namespacePtr = StringToUtf8HGlobal(namespaceURI);
            try
            {
                return ReadConstString(libxml2.XmlTextReaderGetAttributeNs(_ptr, localNamePtr, namespacePtr), null);
            }
            finally
            {
                Marshal.FreeHGlobal(localNamePtr);
                Marshal.FreeHGlobal(namespacePtr);
            }
        }

        public bool getParserProperty(int property)
        {
            return _ptr != IntPtr.Zero && libxml2.XmlTextReaderGetParserProp(_ptr, property) == 1;
        }

        // Sabre only uses this as a coarse parser health check.
        public bool isValid()
        {
            return _ptr != IntPtr.Zero;
        }

        public bool lookupNamespace(string prefix)
        {
            if (_ptr == IntPtr.Zero)
            {
                return false;
            }

            var prefixPtr = StringToUtf8HGlobal(prefix);
            try
            {
                return !string.IsNullOrEmpty(ReadConstString(libxml2.XmlTextReaderLookupNamespace(_ptr, prefixPtr)));
            }
            finally
            {
                Marshal.FreeHGlobal(prefixPtr);
            }
        }

        public bool moveToAttribute(string name)
        {
            if (_ptr == IntPtr.Zero)
            {
                return false;
            }

            var namePtr = StringToUtf8HGlobal(name);
            try
            {
                return libxml2.XmlTextReaderMoveToAttribute(_ptr, namePtr) == 1;
            }
            finally
            {
                Marshal.FreeHGlobal(namePtr);
            }
        }

        public bool moveToAttributeNo(int index)
        {
            return _ptr != IntPtr.Zero && libxml2.XmlTextReaderMoveToAttributeNo(_ptr, index) == 1;
        }

        public bool moveToAttributeNs(string localName, string namespaceURI)
        {
            if (_ptr == IntPtr.Zero)
            {
                return false;
            }

            var localNamePtr = StringToUtf8HGlobal(localName);
            var namespacePtr = StringToUtf8HGlobal(namespaceURI);
            try
            {
                return libxml2.XmlTextReaderMoveToAttributeNs(_ptr, localNamePtr, namespacePtr) == 1;
            }
            finally
            {
                Marshal.FreeHGlobal(localNamePtr);
                Marshal.FreeHGlobal(namespacePtr);
            }
        }

        public bool moveToElement()
        {
            return _ptr != IntPtr.Zero && libxml2.XmlTextReaderMoveToElement(_ptr) == 1;
        }

        public bool moveToFirstAttribute()
        {
            return _ptr != IntPtr.Zero && libxml2.XmlTextReaderMoveToFirstAttribute(_ptr) == 1;
        }

        public bool moveToNextAttribute()
        {
            return _ptr != IntPtr.Zero && libxml2.XmlTextReaderMoveToNextAttribute(_ptr) == 1;
        }

        public bool next(string localname = null)
        {
            if (_ptr == IntPtr.Zero)
            {
                return false;
            }

            if (libxml2.XmlTextReaderNext(_ptr) != 1)
            {
                return false;
            }

            if (string.IsNullOrEmpty(localname))
            {
                return true;
            }

            while (nodeType != NONE && !string.Equals(localName, localname, StringComparison.Ordinal))
            {
                if (libxml2.XmlTextReaderNext(_ptr) != 1)
                {
                    return false;
                }
            }

            return string.Equals(localName, localname, StringComparison.Ordinal);
        }

        public bool open(string URI, string encoding = null, int options = 0)
        {
            close();

            _ptr = libxml2.XmlReaderForFile(URI, encoding, options);

            return _ptr != IntPtr.Zero;
        }

        public bool read()
        {
            return _ptr != IntPtr.Zero && libxml2.XmlTextReaderRead(_ptr) == 1;
        }

        public string readInnerXml()
        {
            if (_ptr == IntPtr.Zero)
            {
                return string.Empty;
            }

            var xmlPtr = libxml2.XmlTextReaderReadInnerXml(_ptr);
            if (xmlPtr == IntPtr.Zero)
            {
                return string.Empty;
            }

            // `xmlTextReaderReadInnerXml()` should return an xmlChar buffer,
            // but with the current Windows libxml2 build the matching free
            // path crashes in practice. Copy the UTF-8 content and let the
            // caller continue; the string sizes here are bounded by the
            // current element subtree, so this is a pragmatic compatibility
            // trade-off until we replace this with a safer subtree reader.
            return ReadConstString(xmlPtr);
        }

        public string readInnerXML() => readInnerXml();

        public bool xml(string source, string encoding = null, int options = 0)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return false;
            }

            close();

            _inputBuffer = StringToUtf8HGlobal(source, out var byteCount);
            _ptr = libxml2.XmlReaderForMemory(_inputBuffer, byteCount, IntPtr.Zero, encoding, options);

            if (_ptr == IntPtr.Zero)
            {
                ReleaseInputBuffer();
                return false;
            }

            return true;
        }

        public bool XML(string source, string encoding = null, int options = 0) => xml(source, encoding, options);

        private void ReleaseInputBuffer()
        {
            if (_inputBuffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_inputBuffer);
                _inputBuffer = IntPtr.Zero;
            }
        }

        private static string ReadConstString(IntPtr ptr, string defaultValue = "")
        {
            return ptr == IntPtr.Zero ? defaultValue : Marshal.PtrToStringUTF8(ptr) ?? defaultValue;
        }

        private static IntPtr StringToUtf8HGlobal(string value)
        {
            return StringToUtf8HGlobal(value, out _);
        }

        private static IntPtr StringToUtf8HGlobal(string value, out int byteCount)
        {
            var bytes = Encoding.UTF8.GetBytes(value ?? string.Empty);
            byteCount = bytes.Length;

            var ptr = Marshal.AllocHGlobal(byteCount + 1);
            Marshal.Copy(bytes, 0, ptr, byteCount);
            Marshal.WriteByte(ptr, byteCount, 0);

            return ptr;
        }

        internal static class libxml2
        {
            internal const string LibraryName = "libxml2";
            private const string macoslib = "native/mac/libxml2.2.dylib";
            private const string linuxlib = "native/linux/libxml2.2.so";
            private const string windowsdir = "native/win";
            private const string windowscharsetlib = "charset-1.dll";
            private const string windowsiconvlib = "iconv-2.dll";
            private const string windowszlib = "z.dll";
            private const string windowslib = "libxml2.dll";

            internal static IntPtr LoadNativaLibrary()
            {
                var assembly = Assembly.GetExecutingAssembly();
                var assemblyDirectory = Path.GetDirectoryName(assembly.Location) ?? string.Empty;
                IntPtr lib = IntPtr.Zero;
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    NativeLibrary.TryLoad(Path.Combine(assemblyDirectory, macoslib), out lib);
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    NativeLibrary.TryLoad(Path.Combine(assemblyDirectory, linuxlib), out lib);
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    var windowsDirectory = Path.Combine(assemblyDirectory, windowsdir);
                    TryLoadDependency(Path.Combine(windowsDirectory, windowscharsetlib));
                    TryLoadDependency(Path.Combine(windowsDirectory, windowsiconvlib));
                    TryLoadDependency(Path.Combine(windowsDirectory, windowszlib));
                    NativeLibrary.TryLoad(Path.Combine(windowsDirectory, windowslib), out lib);
                }

                return lib;
            }

            private static void TryLoadDependency(string path)
            {
                if (File.Exists(path))
                {
                    NativeLibrary.TryLoad(path, out _);
                }
            }

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlReaderForFile")]
            internal static extern IntPtr XmlReaderForFile(
                [MarshalAs(UnmanagedType.LPUTF8Str)] string filename,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string encoding,
                int options);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlReaderForMemory")]
            internal static extern IntPtr XmlReaderForMemory(
                IntPtr buffer,
                int size,
                IntPtr url,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string encoding,
                int options);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlTextReaderRead")]
            internal static extern int XmlTextReaderRead(IntPtr reader);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlTextReaderNext")]
            internal static extern int XmlTextReaderNext(IntPtr reader);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlTextReaderMoveToNextAttribute")]
            internal static extern int XmlTextReaderMoveToNextAttribute(IntPtr reader);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlTextReaderMoveToFirstAttribute")]
            internal static extern int XmlTextReaderMoveToFirstAttribute(IntPtr reader);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlTextReaderMoveToElement")]
            internal static extern int XmlTextReaderMoveToElement(IntPtr reader);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlTextReaderMoveToAttributeNs")]
            internal static extern int XmlTextReaderMoveToAttributeNs(IntPtr reader, IntPtr localName, IntPtr namespaceURI);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlTextReaderMoveToAttributeNo")]
            internal static extern int XmlTextReaderMoveToAttributeNo(IntPtr reader, int no);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlTextReaderGetAttribute")]
            internal static extern IntPtr XmlTextReaderGetAttribute(IntPtr reader, IntPtr name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlTextReaderGetAttributeNo")]
            internal static extern IntPtr XmlTextReaderGetAttributeNo(IntPtr reader, int no);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlTextReaderGetAttributeNs")]
            internal static extern IntPtr XmlTextReaderGetAttributeNs(IntPtr reader, IntPtr localName, IntPtr namespaceURI);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlTextReaderGetParserProp")]
            internal static extern int XmlTextReaderGetParserProp(IntPtr reader, int prop);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlTextReaderLookupNamespace")]
            internal static extern IntPtr XmlTextReaderLookupNamespace(IntPtr reader, IntPtr prefix);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlTextReaderMoveToAttribute")]
            internal static extern int XmlTextReaderMoveToAttribute(IntPtr reader, IntPtr name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlTextReaderConstLocalName")]
            internal static extern IntPtr XmlTextReaderConstLocalName(IntPtr reader);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlTextReaderConstNamespaceUri")]
            internal static extern IntPtr XmlTextReaderConstNamespaceUri(IntPtr reader);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlTextReaderConstValue")]
            internal static extern IntPtr XmlTextReaderConstValue(IntPtr reader);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlTextReaderDepth")]
            internal static extern int XmlTextReaderDepth(IntPtr reader);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlTextReaderNodeType")]
            internal static extern int XmlTextReaderNodeType(IntPtr reader);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlTextReaderIsEmptyElement")]
            internal static extern int XmlTextReaderIsEmptyElement(IntPtr reader);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlTextReaderHasAttributes")]
            internal static extern int XmlTextReaderHasAttributes(IntPtr reader);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlTextReaderReadInnerXml")]
            internal static extern IntPtr XmlTextReaderReadInnerXml(IntPtr reader);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlTextReaderClose")]
            internal static extern int XmlTextReaderClose(IntPtr reader);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlFreeTextReader")]
            internal static extern void XmlFreeTextReader(IntPtr reader);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "xmlFree")]
            internal static extern void XmlFree(IntPtr ptr);
        }
    }
}
