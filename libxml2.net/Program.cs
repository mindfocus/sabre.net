using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using Peachpie.Library.XmlDom;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var platform = Environment.OSVersion;
            var mac = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
            var xmlWriter = new XMLWriter();
            xmlWriter.open_memory();
            xmlWriter.startDocument();
            xmlWriter.startElement("test");
            xmlWriter.startComment();
            xmlWriter.writeRaw("comment content");
            xmlWriter.endComment();
            xmlWriter.endElement();
            xmlWriter.writeElement("focus", "totototototto");
            xmlWriter.endDocument();
            var result = xmlWriter.output_memory();
            
            // var writer = new MockXmlWriter();
            // writer.open_memory();
            // writer.startDocument();
            // writer.endDocument();
            // var result = writer.output_memory();
            Console.WriteLine($"Hello World! \n {result}  ");
        }
    }
}