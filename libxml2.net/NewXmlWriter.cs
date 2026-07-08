using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using Pchp.Core;

namespace Nextsharp.LibXml2
{
    [PhpType(PhpTypeAttribute.InheritName), PhpExtension("nextsharp_libxml2")]
    public class XMLWriter
    {
        #region Constants

        private const string DefaultXmlVersion = "1.0";

        #endregion

        #region Fields and properties

        private static readonly IntPtr NativeLibraryHandle = libxml2.LoadNativaLibrary();
        private IntPtr _ptr = IntPtr.Zero;
        private IntPtr _buffer = IntPtr.Zero;
        private bool _documentCompleted;

        #endregion

        public bool endAttribute()
        {
            return libxml2.XmlTextWriterEndAttribute(_ptr) != -1;

        }
        public bool endCData() => endCdata();
        public bool endCdata()
        {
            return libxml2.XmlTextWriterEndCDATA(_ptr) != -1;

        }

        public bool endComment()
        {
            return libxml2.XmlTextWriterEndComment(_ptr) != -1;

        }

        public bool endDocument()
        {
            var result = libxml2.XmlTextWriterEndDocument(_ptr) != -1;
            if (result)
            {
                _documentCompleted = true;
            }

            return result;

        }

        public bool endDtdAttlist()
        {
            return libxml2.XmlTextWriterEndDTDAttlist(_ptr) != -1;

        }

        public bool endDtdElement()
        {
            return libxml2.XmlTextWriterEndDTDElement(_ptr) != -1;

        }

        public bool endDtdEntity()
        {
            return libxml2.XmlTextWriterEndDTDEntity(_ptr) != -1;
        }

        public bool endDtd()
        {
            return libxml2.XmlTextWriterEndDTD(_ptr) != -1;
        }

        public bool endElement()
        {
            return libxml2.XmlTextWriterEndElement(_ptr) != -1;

        }
        public bool endPi()
        {
            return libxml2.XmlTextWriterEndPI(_ptr) != -1;
        }
        public bool setIndentString(string indentString) => CheckedCall(() =>
            libxml2.XmlTextWriterSetIndentString(_ptr, indentString)
        );

        public bool setIndent(bool indent) => CheckedCall(() =>
        {

            libxml2.XmlTextWriterSetIndent(_ptr, indent ? 1 : 0);
        });
        public bool startAttributeNS(string prefix, string name, string uri) => startAttributeNs(prefix, name, uri);
        public bool startAttributeNs(string prefix, string name, string uri) => CheckedCall(() =>
            libxml2.XmlTextWriterStartAttributeNS(_ptr, prefix, name, uri)
        );
        
        public bool startAttribute(string name) => CheckedCall(() =>
            libxml2.XmlTextWriterStartAttribute(_ptr, name)
        );
        public bool startCdata()
        {
            return libxml2.XmlTextWriterStartCDATA(_ptr) != -1;
        }
        public bool startCData() => startCdata();
        public bool startComment()
        {
            return libxml2.XmlTextWriterStartComment(_ptr) != -1;
        }

        public bool startDocument(string version = DefaultXmlVersion, string encoding = null, string standalone = null)
        {
            if (version != DefaultXmlVersion)
            {
                throw new Exception();
            }
            if (encoding != null && !string.Equals(encoding, "utf-8", StringComparison.CurrentCultureIgnoreCase))
            {
                //PhpException.ArgumentValueNotSupported(nameof(encoding), encoding);
                throw new Exception();
            }
            if (string.IsNullOrEmpty(standalone))
            {
                return CheckedCall(() =>
                {
                    libxml2.XmlTextWriterStartDocument(_ptr, version, encoding, standalone);
                });
            }
            else
            {
                return CheckedCall(() =>
                {
                    libxml2.XmlTextWriterStartDocument(_ptr, version, encoding, "yes");
                });
            }
        }
        
        public bool startDtdAttlist(string name) => CheckedCall(() =>
            libxml2.XmlTextWriterStartDTDAttlist(_ptr, name)
        );
        public bool startDtdEntity(int pe, string name) => CheckedCall(() =>
            libxml2.XmlTextWriterStartDTDEntity(_ptr, pe, name)
        );
        
        public bool startDtd(string name, string pubid, string sysid) => CheckedCall(() =>
            libxml2.XmlTextWriterStartDTD(_ptr, name, pubid, sysid)
        );

        public bool startElementNS(string prefix, string name, string uri) => startElementNs(prefix, name, uri);
        public bool startElementNs(string prefix, string name, string uri) => CheckedCall(() =>
            libxml2.XmlTextWriterStartElementNS(_ptr, prefix, name, uri)
        );

        public bool startElement(string name) => CheckedCall(() =>
            libxml2.XmlTextWriterStartElement(_ptr, name)
        );

        public bool startPi(string target) => CheckedCall(() =>
            libxml2.XmlTextWriterStartPI(_ptr, target)
        );

        public bool writeAttributeNS(string prefix, string name, string uri, string content) => writeAttributeNs(prefix, name, uri, content);
        public bool writeAttributeNs(string prefix, string name, string uri, string content) => CheckedCall(() =>
            libxml2.XmlTextWriterWriteAttributeNS(_ptr, prefix, name, uri, content)
        );

        public bool writeAttribute(string name, string content) => CheckedCall(() =>
            libxml2.XmlTextWriterWriteAttribute(_ptr, name, content)
        );

        public bool writeCData(string content) => writeCdata(content);
        public bool writeCdata(string content) => CheckedCall(() =>
            libxml2.XmlTextWriterWriteCDATA(_ptr, content)
        );

        public bool writeComment(string content) => CheckedCall(() =>
            libxml2.XmlTextWriterWriteComment(_ptr, content)
        );

        public bool text(string content) => writeString(content);

        public bool writeString(string content) => CheckedCall(() =>
            libxml2.XmlTextWriterWriteString(_ptr, content)
        );

        public bool writeDtdAttlist(string name, string content) => CheckedCall(() =>
            libxml2.XmlTextWriterWriteDTDAttlist(_ptr, name, content)
        );

        public bool writeDtdElement(int pe, string name, string content) => CheckedCall(() =>
            libxml2.XmlTextWriterWriteDTDElement(_ptr, name, content)
        );

        public bool writeDtdEntity(int pe, string name, string pubid, string sysid, string ndataid, string content) =>
            CheckedCall(() =>
                libxml2.XmlTextWriterWriteDTDEntity(_ptr, pe, name, pubid, sysid, ndataid, content)
            );

        public bool writeDtd(string name, string pubid, string sysid, string subset) => CheckedCall(() =>
            libxml2.XmlTextWriterWriteDTD(_ptr, name, pubid, sysid, subset)
        );

        public bool writeElementNS(string prefix, string name, string uri, string content = null) => writeElementNs(prefix, name, uri, content);
        public bool writeElementNs(string prefix, string name, string uri, string content = null) =>
            CheckedCall(() =>
                libxml2.XmlTextWriterWriteElementNS(_ptr, prefix, name, uri, content)
            );

        public bool writeElement(string name, string content = null) => CheckedCall(() =>
                libxml2.XmlTextWriterWriteElement(_ptr, name, content)
        );

        public bool writePi(string target, string content)
        {
            return libxml2.XmlTextWriterWritePI(_ptr, target, content) != -1;
        }

        public bool writeRaw(string content)
        {
            return libxml2.XmlTextWriterWriteRaw(_ptr, content) != -1;
        }

        public XMLWriter()
        {
            if (NativeLibraryHandle == IntPtr.Zero)
            {
                throw new DllNotFoundException("Unable to load libxml2 from the libxml2.net native directory.");
            }
        }


        public string outputMemory(bool flush = true)
        {
            if (flush && _ptr != IntPtr.Zero && !_documentCompleted)
            {
                endDocument();
            }

            return output_memory();
        }
        public string output_memory()
        {
            unsafe
            {
                var result = libxml2.XmlBufferContent(_buffer);
                return Marshal.PtrToStringUTF8((IntPtr) result) ?? string.Empty;
            }
        }

        public bool open_memory()
        {
            _buffer = libxml2.XmlBufferCreate();
            if (_buffer == IntPtr.Zero)
            {
                return false;
            }

            _ptr = libxml2.XmlNewTextWriterMemory(_buffer, 0);
            if (_ptr == IntPtr.Zero)
            {
                libxml2.XmlBufferFree(_buffer);
                return false;
            }

            _documentCompleted = false;
            return true;
        }
        public bool openMemory() => open_memory();

        public void set_indent()
        {
        }

        private bool CheckedCall(Action operation)
        {
            Debug.WriteLine("checked call");
            if (_ptr == IntPtr.Zero)
            {
                return false;
            }

            try
            {
                operation();
                return true;
            }
            catch (ArgumentException)
            {
                // PhpException.Throw(PhpError.Warning, e.Message);
                return false;
            }
            catch (InvalidOperationException)
            {
                // PhpException.Throw(PhpError.Warning, e.Message);
                return false;
            }
        }

        internal unsafe class libxml2
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
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
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
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlBufferCreate")]
            internal static extern IntPtr XmlBufferCreate();

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlNewTextWriterMemory")]
            internal static extern IntPtr XmlNewTextWriterMemory(IntPtr buf, int compression);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlBufferFree")]
            internal static extern void XmlBufferFree(IntPtr buf);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterStartDocument")]
            internal static extern int XmlTextWriterStartDocument(IntPtr writer,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string version,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string encoding,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string standalone);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterEndDocument")]
            internal static extern int XmlTextWriterEndDocument(IntPtr writer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlBufferContent")]
            internal static extern unsafe byte* XmlBufferContent(IntPtr buf);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWriteRaw")]
            internal static extern int XmlTextWriterWriteRaw(IntPtr writer,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWritePI")]
            internal static extern int XmlTextWriterWritePI(IntPtr writer,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string target,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWriteElement")]
            internal static extern int XmlTextWriterWriteElement(IntPtr writer,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWriteElementNS")]
            internal static extern int XmlTextWriterWriteElementNS(IntPtr writer,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string prefix,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string namespaceURI,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWriteDTD")]
            internal static extern int XmlTextWriterWriteDTD(IntPtr writer,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string pubid,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string sysid,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string subset);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWriteDTDEntity")]
            internal static extern int XmlTextWriterWriteDTDEntity(IntPtr writer, int pe,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string pubid,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string sysid,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string ndataid,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWriteDTDElement")]
            internal static extern int XmlTextWriterWriteDTDElement(IntPtr writer,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWriteDTDAttlist")]
            internal static extern int XmlTextWriterWriteDTDAttlist(IntPtr writer,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWriteComment")]
            internal static extern int XmlTextWriterWriteComment(IntPtr writer,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWriteCDATA")]
            internal static extern int XmlTextWriterWriteCDATA(IntPtr writer,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWriteAttribute")]
            internal static extern int XmlTextWriterWriteAttribute(IntPtr writer,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWriteAttributeNS")]
            internal static extern int XmlTextWriterWriteAttributeNS(IntPtr writer,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string prefix,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string namespaceURI,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWriteString")]
            internal static extern int XmlTextWriterWriteString(IntPtr writer,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterStartPI")]
            internal static extern int XmlTextWriterStartPI(IntPtr writer,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string target);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterStartElement")]
            internal static extern int XmlTextWriterStartElement(IntPtr writer,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterStartElementNS")]
            internal static extern int XmlTextWriterStartElementNS(IntPtr writer,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string prefix,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string namespaceURI);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterStartDTD")]
            internal static extern int XmlTextWriterStartDTD(IntPtr writer,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string pubid,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string sysid);
            
            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterStartDTDEntity")]
            internal static extern int XmlTextWriterStartDTDEntity(IntPtr writer, int pe,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterStartDTDElement")]
            internal static extern int XmlTextWriterStartDTDElement(IntPtr writer,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterStartDTDAttlist")]
            internal static extern int XmlTextWriterStartDTDAttlist(IntPtr writer,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string name);
    
            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterStartComment")]
            internal static extern int XmlTextWriterStartComment(IntPtr writer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterStartCDATA")]
            internal static extern int XmlTextWriterStartCDATA(IntPtr writer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterStartAttribute")]
            internal static extern int XmlTextWriterStartAttribute(IntPtr writer,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string name);
            
            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterStartAttributeNS")]
            internal static extern int XmlTextWriterStartAttributeNS(IntPtr writer,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string prefix,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string namespaceURI);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterSetIndent")]
            internal static extern int XmlTextWriterSetIndent(IntPtr writer, int indent);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterSetIndentString")]
            internal static extern int XmlTextWriterSetIndentString(IntPtr writer,
                [MarshalAs(UnmanagedType.LPUTF8Str)] string str);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterEndPI")]
            internal static extern int XmlTextWriterEndPI(IntPtr writer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterEndElement")]
            internal static extern int XmlTextWriterEndElement(IntPtr writer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterEndDTD")]
            internal static extern int XmlTextWriterEndDTD(IntPtr writer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterEndDTDEntity")]
            internal static extern int XmlTextWriterEndDTDEntity(IntPtr writer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterEndDTDElement")]
            internal static extern int XmlTextWriterEndDTDElement(IntPtr writer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterEndDTDAttlist")]
            internal static extern int XmlTextWriterEndDTDAttlist(IntPtr writer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterEndComment")]
            internal static extern int XmlTextWriterEndComment(IntPtr writer);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterEndCDATA")]
            internal static extern int XmlTextWriterEndCDATA(IntPtr writer);
            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterEndAttribute")]
            internal static extern int XmlTextWriterEndAttribute(IntPtr writer);


        }
    }
}
