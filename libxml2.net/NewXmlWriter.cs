using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using Pchp.Core;

namespace Peachpie.Library.XmlDom
{
    [PhpType(PhpTypeAttribute.InheritName), PhpExtension("xmlwriter")]
    public class XMLWriter
    {
        #region Constants

        private const string DefaultXmlVersion = "1.0";

        #endregion

        #region Fields and properties

        private IntPtr _ptr = IntPtr.Zero;
        private IntPtr _buffer = IntPtr.Zero;

        #endregion

        public bool endAttribute()
        {
            return -1 == libxml2.XmlTextWriterEndAttribute(_ptr);

        }
        public bool endCdata()
        {
            return -1 == libxml2.XmlTextWriterEndCDATA(_ptr);

        }

        public bool endComment()
        {
            return -1 == libxml2.XmlTextWriterEndComment(_ptr);

        }

        public bool endDocument()
        {
            return -1 == libxml2.XmlTextWriterEndDocument(_ptr);

        }

        public bool endDtdAttlist()
        {
            return -1 == libxml2.XmlTextWriterEndDTDAttlist(_ptr);

        }

        public bool endDtdElement()
        {
            return -1 == libxml2.XmlTextWriterEndDTDElement(_ptr);

        }

        public bool endDtdEntity()
        {
            return -1 == libxml2.XmlTextWriterEndDTDEntity(_ptr);
        }

        public bool endDtd()
        {
            return -1 == libxml2.XmlTextWriterEndDTD(_ptr);
        }

        public bool endElement()
        {
            return -1 == libxml2.XmlTextWriterEndElement(_ptr);

        }
        public bool endPi()
        {
            return -1 == libxml2.XmlTextWriterEndPI(_ptr);
        }
        public bool setIndentString(string indentString) => CheckedCall(() =>
        {
            unsafe
            {
                var indentStringPtr = Marshal.StringToHGlobalAuto(indentString);

                libxml2.XmlTextWriterSetIndentString(_ptr, (byte*) indentStringPtr);
            }
        });

        public bool setIndent(bool indent) => CheckedCall(() =>
        {

            libxml2.XmlTextWriterSetIndent(_ptr, 0);
        });
        public bool startAttributeNs(string prefix, string name, string uri) => CheckedCall(() =>
        {
            unsafe
            {
                var prefixPtr = Marshal.StringToHGlobalAuto(prefix);
                var namePtr = Marshal.StringToHGlobalAuto(name);
                var uriPtr = Marshal.StringToHGlobalAuto(uri);
                libxml2.XmlTextWriterStartAttributeNS(_ptr, (byte*) prefixPtr, (byte*) namePtr, (byte*) uriPtr);
            }
        });
        
        public bool startAttribute(string name) => CheckedCall(() =>
        {
            unsafe
            {
                var namePtr = Marshal.StringToHGlobalAuto(name);
                libxml2.XmlTextWriterStartAttribute(_ptr, (byte*) namePtr);
            }

        });
        public bool startCdata()
        {
            return -1 == libxml2.XmlTextWriterStartCDATA(_ptr);
        }
        public bool startComment()
        {
            return -1 == libxml2.XmlTextWriterStartComment(_ptr);
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
            {
                unsafe
                {
                    var namePtr = Marshal.StringToHGlobalAuto(name);
                    libxml2.XmlTextWriterStartDTDAttlist(_ptr, (byte*) namePtr);
                }
            }
        );
        public bool startDtdEntity(int pe, string name) => CheckedCall(() =>
            {
                unsafe
                {
                    var namePtr = Marshal.StringToHGlobalAuto(name);
                    libxml2.XmlTextWriterStartDTDEntity(_ptr, pe, (byte*) namePtr);
                }
            }
        );
        
        public bool startDtd(string name, string pubid, string sysid) => CheckedCall(() =>
            {
                unsafe
                {
                    var namePtr = Marshal.StringToHGlobalAuto(name);
                    var pubidPtr = Marshal.StringToHGlobalAuto(pubid);
                    var sysidPtr = Marshal.StringToHGlobalAuto(sysid);
                    libxml2.XmlTextWriterStartDTD(_ptr, (byte*) namePtr, (byte*) pubidPtr, (byte*) sysidPtr);
                }
            }
        );

        public bool startElementNs(string prefix, string name, string uri) => CheckedCall(() =>
            {
                unsafe
                {
                    var prefixPtr = Marshal.StringToHGlobalAuto(prefix);
                    var namePtr = Marshal.StringToHGlobalAuto(name);
                    var uriPtr = Marshal.StringToHGlobalAuto(uri);
                    libxml2.XmlTextWriterStartElementNS(_ptr, (byte*) prefixPtr, (byte*) namePtr, (byte*) uriPtr);
                }
            }
        );

        public bool startElement(string name) => CheckedCall(() =>
            {
                unsafe
                {
                    var namePtr = Marshal.StringToHGlobalAuto(name);

                    libxml2.XmlTextWriterStartElement(_ptr, (byte*) namePtr);
                }
            }
        );

        public bool startPi(string target) => CheckedCall(() =>
        {
            unsafe
            {
                var targetPtr = Marshal.StringToHGlobalAuto(target);
                libxml2.XmlTextWriterStartPI(_ptr, (byte*) targetPtr);
            }
        });

        public bool writeAttributeNs(string prefix, string name, string uri, string content) => CheckedCall(() =>
        {
            unsafe
            {
                var prefixPtr = Marshal.StringToHGlobalAuto(prefix);
                var namePtr = Marshal.StringToHGlobalAuto(name);
                var uriPtr = Marshal.StringToHGlobalAuto(uri);
                var contentPtr = Marshal.StringToHGlobalAuto(content);
                libxml2.XmlTextWriterWriteAttributeNS(_ptr, (byte*) prefixPtr, (byte*) namePtr, (byte*) uriPtr,
                    (byte*) contentPtr);
            }
        });

        public bool writeAttribute(string name, string content) => CheckedCall(() =>
        {
            unsafe
            {
                var namePtr = Marshal.StringToHGlobalAuto(name);
                var contentPtr = Marshal.StringToHGlobalAuto(content);
                libxml2.XmlTextWriterWriteAttribute(_ptr, (byte*) namePtr, (byte*) contentPtr);
            }
        });

        public bool writeCdata(string content) => CheckedCall(() =>
        {
            unsafe
            {
                var contentPtr = Marshal.StringToHGlobalAuto(content);
                libxml2.XmlTextWriterWriteCDATA(_ptr, (byte*) contentPtr);
            }
        });

        public bool writeComment(string content) => CheckedCall(() =>
        {
            unsafe
            {
                var contentPtr = Marshal.StringToHGlobalAuto(content);
                libxml2.XmlTextWriterWriteComment(_ptr, (byte*) contentPtr);
            }
        });

        public bool writeDtdAttlist(string name, string content) => CheckedCall(() =>
        {
            unsafe
            {
                var namePtr = Marshal.StringToHGlobalAuto(name);
                var contentPtr = Marshal.StringToHGlobalAuto(content);
                libxml2.XmlTextWriterWriteDTDAttlist(_ptr, (byte*) namePtr, (byte*) contentPtr);
            }
        });

        public bool writeDtdElement(int pe, string name, string content) => CheckedCall(() =>
        {
            unsafe
            {
                var namePtr = Marshal.StringToHGlobalAuto(name);
                var contentPtr = Marshal.StringToHGlobalAuto(content);
                libxml2.XmlTextWriterWriteDTDElement(_ptr, (byte*) namePtr, (byte*) contentPtr);
            }
        });

        public bool writeDtdEntity(int pe, string name, string pubid, string sysid, string ndataid, string content) =>
            CheckedCall(() =>
            {
                unsafe
                {
                    var ndataidPtr = Marshal.StringToHGlobalAuto(ndataid);
                    var namePtr = Marshal.StringToHGlobalAuto(name);
                    var sysidPtr = Marshal.StringToHGlobalAuto(sysid);
                    var pubidPtr = Marshal.StringToHGlobalAuto(pubid);
                    var contentPtr = Marshal.StringToHGlobalAuto(content);
                    libxml2.XmlTextWriterWriteDTDEntity(_ptr, pe, (byte*) namePtr, (byte*) pubidPtr, (byte*) sysidPtr,
                        (byte*) ndataidPtr, (byte*) contentPtr);
                }
            });

        public bool writeDtd(string name, string pubid, string sysid, string subset) => CheckedCall(() =>
        {
            unsafe
            {
                var subsetPtr = Marshal.StringToHGlobalAuto(subset);
                var sysidPtr = Marshal.StringToHGlobalAuto(sysid);
                var namePtr = Marshal.StringToHGlobalAuto(name);
                var pubidPtr = Marshal.StringToHGlobalAuto(pubid);
                libxml2.XmlTextWriterWriteDTD(_ptr, (byte*) namePtr, (byte*) pubidPtr, (byte*) sysidPtr,
                    (byte*) subsetPtr);
            }
        });

        public bool writeElementNs(string prefix, string name, string uri, string content = null) =>
            CheckedCall(() =>
            {
                unsafe
                {
                    var prefixPtr = Marshal.StringToHGlobalAuto(prefix);
                    var contentPtr = Marshal.StringToHGlobalAuto(content);
                    var namePtr = Marshal.StringToHGlobalAuto(name);
                    var uriPtr = Marshal.StringToHGlobalAuto(uri);
                    libxml2.XmlTextWriterWriteElementNS(_ptr, (byte*) prefixPtr, (byte*) namePtr, (byte*) uriPtr,
                        (byte*) contentPtr);
                }
            });

        public bool writeElement(string name, string content = null) => CheckedCall(() =>
            {
                unsafe
                {
                    var contentPtr = Marshal.StringToHGlobalAuto(content);
                    var namePtr = Marshal.StringToHGlobalAuto(name);
                    libxml2.XmlTextWriterWriteElement(_ptr, (byte*) namePtr, (byte*) contentPtr);
                }
            }
        );

        public bool writePi(string target, string content)
        {
            unsafe
            {
                var contentPtr = Marshal.StringToHGlobalAuto(content);
                var targetPtr = Marshal.StringToHGlobalAuto(target);
                return libxml2.XmlTextWriterWritePI(_ptr, (byte*) targetPtr, (byte*) contentPtr) != -1;
            }
        }

        public bool writeRaw(string content)
        {
            unsafe
            {
                var contentPtr = Marshal.StringToHGlobalAuto(content);
                return libxml2.XmlTextWriterWriteRaw(_ptr, (byte*) contentPtr) != -1;
            }
        }

        public XMLWriter()
        {
            Console.WriteLine("ctor");
        }


        public string output_memory()
        {
            unsafe
            {
                var result = libxml2.XmlBufferContent(_buffer);
                return Marshal.PtrToStringAuto((IntPtr) result);
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

            return true;
        }

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
            catch (ArgumentException e)
            {
                // PhpException.Throw(PhpError.Warning, e.Message);
                return false;
            }
            catch (InvalidOperationException e)
            {
                // PhpException.Throw(PhpError.Warning, e.Message);
                return false;
            }
        }

        internal unsafe class libxml2
        {
            internal const string LibraryName = "libxml2.2";
            private const string macoslib = "native/mac/libxml2.2.dylib";
            private const string windowslib = "native/win/libxml2.2.dll";
            private const string linuxlib = "native/linux/libxml2.2.so";

            internal static IntPtr LoadNativaLibrary()
            {
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
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
            internal static extern int XmlTextWriterWriteRaw(IntPtr writer, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWritePI")]
            internal static extern int XmlTextWriterWritePI(IntPtr writer, byte* target, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWriteElement")]
            internal static extern int XmlTextWriterWriteElement(IntPtr writer, byte* name, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWriteElementNS")]
            internal static extern int XmlTextWriterWriteElementNS(IntPtr writer, byte* prefix, byte* name,
                byte* namespaceURI, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWriteDTD")]
            internal static extern int XmlTextWriterWriteDTD(IntPtr writer, byte* name, byte* pubid, byte* sysid,
                byte* subset);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWriteDTDEntity")]
            internal static extern int XmlTextWriterWriteDTDEntity(IntPtr writer, int pe, byte* name, byte* pubid,
                byte* sysid, byte* ndataid, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWriteDTDElement")]
            internal static extern int XmlTextWriterWriteDTDElement(IntPtr writer, byte* name, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWriteDTDAttlist")]
            internal static extern int XmlTextWriterWriteDTDAttlist(IntPtr writer, byte* name, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWriteComment")]
            internal static extern int XmlTextWriterWriteComment(IntPtr writer, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWriteCDATA")]
            internal static extern int XmlTextWriterWriteCDATA(IntPtr writer, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWriteAttribute")]
            internal static extern int XmlTextWriterWriteAttribute(IntPtr writer, byte* name, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWriteAttributeNS")]
            internal static extern int XmlTextWriterWriteAttributeNS(IntPtr writer, byte* prefix, byte* name,
                byte* namespaceURI, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterWriteString")]
            internal static extern int XmlTextWriterWriteString(IntPtr writer, byte* content);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterStartPI")]
            internal static extern int XmlTextWriterStartPI(IntPtr writer, byte* target);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterStartElement")]
            internal static extern int XmlTextWriterStartElement(IntPtr writer, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterStartElementNS")]
            internal static extern int XmlTextWriterStartElementNS(IntPtr writer, byte* prefix, byte* name,
                byte* namespaceURI);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "xmlTextWriterStartDTD")]
            internal static extern int XmlTextWriterStartDTD(IntPtr writer, byte* name, byte* pubid, byte* sysid);
            
            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterStartDTDEntity")]
            internal static extern int XmlTextWriterStartDTDEntity(IntPtr writer, int pe, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterStartDTDElement")]
            internal static extern int XmlTextWriterStartDTDElement(IntPtr writer, byte* name);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterStartDTDAttlist")]
            internal static extern int XmlTextWriterStartDTDAttlist(IntPtr writer, byte* name);
    
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
            internal static extern int XmlTextWriterStartAttribute(IntPtr writer, byte* name);
            
            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterStartAttributeNS")]
            internal static extern int XmlTextWriterStartAttributeNS(IntPtr writer, byte* prefix, byte* name, byte* namespaceURI);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterSetIndent")]
            internal static extern int XmlTextWriterSetIndent(IntPtr writer, int indent);

            [SuppressUnmanagedCodeSecurity]
            [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
                EntryPoint="xmlTextWriterSetIndentString")]
            internal static extern int XmlTextWriterSetIndentString(IntPtr writer, byte* str);

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