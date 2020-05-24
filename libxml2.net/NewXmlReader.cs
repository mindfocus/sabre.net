using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using Pchp.Core;

namespace ConsoleApp1
{
    /// <summary>
    /// The XMLReader extension is an XML pull parser. The reader acts as a cursor going forward
    /// on the document stream and stopping at each node on the way.
    /// </summary>
    [PhpType(PhpTypeAttribute.InheritName), PhpExtension("xmlreader")]
    public class XMLReader
    {
        private IntPtr _ptr;
        
        #region XmlReader node types

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

        #endregion
        
        internal string _xmlreader_get_valid_file_path(string source, string resolved_path, int resolved_path_len )
        {
            unsafe
            {
                var uri = libxml2.XmlCreateURI();
                var sourcePtr = Marshal.StringToHGlobalAuto(source);
                var listPtr = Marshal.StringToHGlobalAuto(":");
                var escsource = libxml2.XmlURIEscapeStr((byte*) sourcePtr, (byte*) listPtr);
                var escsourceStr = Marshal.PtrToStringAuto(new IntPtr(escsource));
                libxml2.XmlParseURIReference(uri, escsourceStr);
                return "";
            }
        }
        #region Methods

        /// <summary>
        /// Returns the value of a named attribute or NULL if the attribute does not exist or
        /// not positioned on an element node.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        /// <returns>The value of the attribute, or NULL if no attribute with the given name is
        /// found or not positioned on an element node.</returns>
        public string getAttribute(string name)
        {
            unsafe
            {
                var namePtr = Marshal.StringToHGlobalAuto(name);

                var resultPtr = libxml2.XmlTextReaderGetAttribute(_ptr, (byte*) namePtr);
                var result = Marshal.PtrToStringAuto(new IntPtr(resultPtr));
                return result;
            }
        }
        /// <summary>
        /// Returns the value of an attribute based on its position or an empty string if attribute
        /// does not exist or not positioned on an element node.
        /// </summary>
        /// <param name="index">The position of the attribute.</param>
        /// <returns>The value of the attribute, or NULL if no attribute exists at index or is not
        /// positioned on the element.</returns>
        public string getAttributeNo(int index)
        {
            unsafe
            {
                var result = libxml2.XmlTextReaderGetAttributeNo(_ptr, index);
                return Marshal.PtrToStringAuto(new IntPtr(result));
            }
        }
        /// <summary>
        /// Returns the value of an attribute by name and namespace URI or an empty string if attribute
        /// does not exist or not positioned on an element node.
        /// </summary>
        /// <param name="localName">The local name.</param>
        /// <param name="namespaceURI">The namespace URI.</param>
        /// <returns>The value of the attribute, or NULL if no attribute with the given localName and
        /// namespaceURI is found or not positioned of element.</returns>
        public string getAttributeNs(string localName, string namespaceURI)
        {
            unsafe
            {
                var localNamePtr = Marshal.StringToHGlobalAuto(localName);
                var namespaceURIPtr = Marshal.StringToHGlobalAuto(namespaceURI);
                var resultPtr = libxml2.XmlTextReaderGetAttributeNs(_ptr, (byte*) localNamePtr, (byte*) namespaceURIPtr);
                return Marshal.PtrToStringAuto(new IntPtr(resultPtr));
            }
        }
        /// <summary>
        /// Indicates if specified property has been set.
        /// </summary>
        /// <param name="property">One of the parser option constants.</param>
        /// <returns>Returns TRUE on success or FALSE on failure.</returns>
        public bool getParserProperty(int property)
        {
            return libxml2.XmlTextReaderGetParserProp(_ptr, property) != -1;
        }
        /// <summary>
        /// Returns a boolean indicating if the document being parsed is currently valid.
        /// </summary>
        /// <returns>Returns TRUE on success or FALSE on failure.</returns>
        public bool isValid()
        {
            return libxml2.XmlTextReaderIsValid(_ptr) != -1;
        }

        /// <summary>
        /// Lookup in scope namespace for a given prefix.
        /// </summary>
        /// <param name="prefix">String containing the prefix.</param>
        /// <returns>Returns TRUE on success or FALSE on failure.</returns>
        public bool lookupNamespace(string prefix)
        {
            unsafe
            {
                var prefixPtr = Marshal.StringToHGlobalAuto(prefix);

                var resultPtr = libxml2.XmlTextReaderLookupNamespace(_ptr, (byte*) prefixPtr);
                var result = Marshal.PtrToStringAuto(new IntPtr(resultPtr));
                return result != "";
            }
        }
        /// <summary>
        /// Positions cursor on the named attribute.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        /// <returns>Returns TRUE on success or FALSE on failure.</returns>
        public bool moveToAttribute(string name)
        {
            unsafe
            {
                var namePtr = Marshal.StringToHGlobalAuto(name);
                return  libxml2.XmlTextReaderMoveToAttribute(_ptr, (byte*) namePtr) != -1;
            }
        }
        /// <summary>
        /// Positions cursor on attribute based on its position.
        /// </summary>
        /// <param name="index">The position of the attribute.</param>
        /// <returns>Returns TRUE on success or FALSE on failure.</returns>
        public bool moveToAttributeNo(int index)
        {
            return libxml2.XmlTextReaderMoveToAttributeNo(_ptr, index) != -1;
        }
        /// <summary>
        /// Positions cursor on the named attribute in specified namespace.
        /// </summary>
        /// <param name="localName">The local name.</param>
        /// <param name="namespaceURI">The namespace URI.</param>
        /// <returns>Returns TRUE on success or FALSE on failure.</returns>
        public bool moveToAttributeNs(string localName, string namespaceURI)
        {
            unsafe
            {
                var localNamePtr = Marshal.StringToHGlobalAuto(localName);
                var namespacePtr = Marshal.StringToHGlobalAuto(namespaceURI);
                return libxml2.XmlTextReaderMoveToAttributeNs(_ptr, (byte*) localNamePtr, (byte*) namespacePtr) != -1;
            }
        }
        /// <summary>
        /// Moves cursor to the parent Element of current Attribute.
        /// </summary>
        /// <returns>Returns TRUE if successful and FALSE if it fails or not positioned on Attribute
        /// when this method is called.</returns>
        public bool moveToElement()
        {
            return libxml2.XmlTextReaderMoveToElement(_ptr) != -1;
        }
        /// <summary>
        /// Moves cursor to the first Attribute.
        /// </summary>
        /// <returns>Returns TRUE on success or FALSE on failure.</returns>
        public bool moveToFirstAttribute()
        {
            return libxml2.XmlTextReaderMoveToFirstAttribute(_ptr) != -1;
        }
        /// <summary>
        /// Moves cursor to the next Attribute if positioned on an Attribute or moves to first attribute
        /// if positioned on an Element.
        /// </summary>
        /// <returns>Returns TRUE on success or FALSE on failure.</returns>
        public bool moveToNextAttribute()
        {
            return libxml2.XmlTextReaderMoveToNextAttribute(_ptr) != -1;
        }
        /// <summary>
        /// Positions cursor on the next node skipping all subtrees.
        /// </summary>
        /// <param name="localname">The name of the next node to move to.</param>
        /// <returns>Returns TRUE on success or FALSE on failure.</returns>
        public bool next(string localname = null)
        {
            return libxml2.XmlTextReaderNext(_ptr) != -1;
        }
        /// <summary>
        /// Set the URI containing the XML document to be parsed.
        /// </summary>
        /// <param name="URI">URI pointing to the document.</param>
        /// <param name="encoding">The document encoding or NULL.</param>
        /// <param name="options">A bitmask of the LIBXML_* constants.</param>
        /// <returns>Returns TRUE on success or FALSE on failure.</returns>
        public bool open(string URI, string encoding = null, int options = 0)
        {
            // _ptr = libxml2.XmlReaderForFile();
            return false;
        }
        #endregion
        internal unsafe class libxml2
        {
            internal const string LibraryName = "libxml2.2";
            private const string macoslib = "native/mac/libxml2.2.dylib";
            private const string windowslib = "native/win/libxml2.2.dll";
            private const string linuxlib = "native/linux/libxml2.2.so";
            internal static IntPtr LoadNativaLibrary()
            {
                var assembly = Assembly.GetExecutingAssembly();
                IntPtr lib = IntPtr.Zero;
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    NativeLibrary.TryLoad(macoslib, assembly, DllImportSearchPath.AssemblyDirectory, out lib);
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    NativeLibrary.TryLoad(linuxlib, assembly, DllImportSearchPath.AssemblyDirectory, out lib);
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    NativeLibrary.TryLoad(windowslib, assembly, DllImportSearchPath.AssemblyDirectory, out lib);
                }

                return lib;
            }
            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint="xmlParseURIReference")]
            internal static extern int XmlParseURIReference(global::System.IntPtr uri, [MarshalAs(UnmanagedType.LPUTF8Str)] string str);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlURIEscapeStr")]
            internal static extern byte* XmlURIEscapeStr(byte* str, byte* list);
            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlCreateURI")]
            internal static extern IntPtr XmlCreateURI();
            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlReaderForFile")]
            internal static extern IntPtr XmlReaderForFile([MarshalAs(UnmanagedType.LPUTF8Str)] string filename, [MarshalAs(UnmanagedType.LPUTF8Str)] string encoding, int options);
            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextReaderNext")]
            internal static extern int XmlTextReaderNext(IntPtr reader);
            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextReaderMoveToNextAttribute")]
            internal static extern int XmlTextReaderMoveToNextAttribute(IntPtr reader);
            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextReaderMoveToFirstAttribute")]
            internal static extern int XmlTextReaderMoveToFirstAttribute(IntPtr reader);
            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextReaderMoveToElement")]
            internal static extern int XmlTextReaderMoveToElement(IntPtr reader);
            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextReaderMoveToAttributeNs")]
            internal static extern int XmlTextReaderMoveToAttributeNs(IntPtr reader, byte* localName, byte* namespaceURI);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextReaderMoveToAttributeNo")]
            internal static extern int XmlTextReaderMoveToAttributeNo(IntPtr reader, int no);
            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextReaderGetAttribute")]
            internal static extern byte* XmlTextReaderGetAttribute(IntPtr reader, byte* name);
            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextReaderGetAttributeNo")]
            internal static extern byte* XmlTextReaderGetAttributeNo(IntPtr reader, int no);
            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextReaderGetAttributeNs")]
            internal static extern byte* XmlTextReaderGetAttributeNs(IntPtr reader, byte* localName, byte* namespaceURI);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextReaderGetParserProp")]
            internal static extern int XmlTextReaderGetParserProp(IntPtr reader, int prop);
            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextReaderIsValid")]
            internal static extern int XmlTextReaderIsValid(IntPtr reader);
            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextReaderLookupNamespace")]
            internal static extern byte* XmlTextReaderLookupNamespace(IntPtr reader, byte* prefix);
            
            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextReaderMoveToAttribute")]
            internal static extern int XmlTextReaderMoveToAttribute(IntPtr reader, byte* name);
        }
        
    }
}