using System;
using System.Collections.Generic;
using System.Xml;

namespace sabre.net.end.xml
{
    public class Writer : XmlWriter
    {
        /// <summary>
        /// Any namespace that the writer is asked to write, will be added here.
        ///
        /// Any of these elements will get a new namespace definition *every single
        /// time* they are used, but this array allows the writer to make sure that
        /// the prefixes are consistent anyway.
        /// </summary>
        protected List<String> adhocNamespaces = new List<string>();
        /// <summary>
        /// When the first element is written, this flag is set to true.
        ///
        /// This ensures that the namespaces in the namespaces map are only written once.
        /// </summary>
        protected bool namespacesWritten = false;
        
        public override void Flush()
        {
            throw new System.NotImplementedException();
        }

        public override string LookupPrefix(string ns)
        {
            throw new System.NotImplementedException();
        }

        public override void WriteBase64(byte[] buffer, int index, int count)
        {
            throw new System.NotImplementedException();
        }

        public override void WriteCData(string text)
        {
            throw new System.NotImplementedException();
        }

        public override void WriteCharEntity(char ch)
        {
            throw new System.NotImplementedException();
        }

        public override void WriteChars(char[] buffer, int index, int count)
        {
            throw new System.NotImplementedException();
        }

        public override void WriteComment(string text)
        {
            throw new System.NotImplementedException();
        }

        public override void WriteDocType(string name, string pubid, string sysid, string subset)
        {
            throw new System.NotImplementedException();
        }

        public override void WriteEndAttribute()
        {
            throw new System.NotImplementedException();
        }

        public override void WriteEndDocument()
        {
            throw new System.NotImplementedException();
        }

        public override void WriteEndElement()
        {
            throw new System.NotImplementedException();
        }

        public override void WriteEntityRef(string name)
        {
            throw new System.NotImplementedException();
        }

        public override void WriteFullEndElement()
        {
            throw new System.NotImplementedException();
        }

        public override void WriteProcessingInstruction(string name, string text)
        {
            throw new System.NotImplementedException();
        }

        public override void WriteRaw(char[] buffer, int index, int count)
        {
            throw new System.NotImplementedException();
        }

        public override void WriteRaw(string data)
        {
            throw new System.NotImplementedException();
        }

        public override void WriteStartAttribute(string prefix, string localName, string ns)
        {
            throw new System.NotImplementedException();
        }

        public override void WriteStartDocument()
        {
            throw new System.NotImplementedException();
        }

        public override void WriteStartDocument(bool standalone)
        {
            throw new System.NotImplementedException();
        }

        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            throw new System.NotImplementedException();
        }

        public override void WriteString(string text)
        {
            throw new System.NotImplementedException();
        }

        public override void WriteSurrogateCharEntity(char lowChar, char highChar)
        {
            throw new System.NotImplementedException();
        }

        public override void WriteWhitespace(string ws)
        {
            throw new System.NotImplementedException();
        }

        public override WriteState WriteState { get; }
    }
}