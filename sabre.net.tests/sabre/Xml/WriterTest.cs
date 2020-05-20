using NUnit.Framework;
using Pchp.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace sabre.net.tests.sabre.Xml
{
    class WriterTest
    {
        protected Sabre.Xml.Writer writer;
        [SetUp]
        public void Setup()
        {
            this.writer = new Sabre.Xml.Writer();
            var map = PhpArray.NewEmpty();
            map.Add("http://sabredav.org/ns", "s");
            this.writer.namespaceMap = map;
            this.writer.openMemory();
            //this.writer.setIndent(true);
            this.writer.startDocument();
        }

        public void compare(PhpValue input, PhpValue output)
        {
            MemoryStream ms = new MemoryStream();
            var ss = System.Xml.XmlWriter.Create(ms);
            // ss.Settings.Indent = true;
            ss.WriteStartDocument();
            ss.WriteStartElement("{http://sabredav.org/ns}root");
            ss.WriteAttributeString("s", "root");
            ss.WriteEndElement();
            ss.Flush();
            var result = Encoding.UTF8.GetString(ms.GetBuffer());
            this.writer.write(input);
            var realOutput = this.writer.outputMemory(true);
            this.writer.write("{http://sabredav.org/ns}root");
            Assert.AreEqual(output, realOutput);
        }
        [Test]
        public void testSimple()
        {
            var map = PhpArray.NewEmpty();
            map.Add("{http://sabredav.org/ns}root", "text");
            var rawText = "<?xml version=\"1.0\"?>" + Environment.NewLine + "<s:root xmlns:s=\"http://sabredav.org/ns\">text</s:root>";
            this.compare(map, rawText);
        }
        /**
 * @depends testSimple
 */
        [Test]
        public void testSimpleQuotes()
        {
            var map = PhpArray.NewEmpty();
            map.Add("{http://sabredav.org/ns}root", "\"text\"");
            var rawText = "<?xml version=\"1.0\"?>" + Environment.NewLine + "<s:root xmlns:s=\"http://sabredav.org/ns\">&quot;text&quot;</s:root>";
            this.compare(map, rawText);
        }
        [Test]
        public void testSimpleAttributes()
        {
            var map = PhpArray.NewEmpty();

            var attributesNode = PhpArray.NewEmpty();
            attributesNode.Add("attr1", "attribute value");
            var valueNode = PhpArray.NewEmpty();
            valueNode.Add("value", "text");
            valueNode.Add("attributes", attributesNode);
            map.Add("{http://sabredav.org/ns}root", valueNode);
            var rawText = "<?xml version=\"1.0\"?>" + Environment.NewLine + "<s:root xmlns:s=\"http://sabredav.org/ns\"  attr1=\"attribute value\">text</s:root>";
            this.compare(map, rawText);
        }
        [Test]
            public void testMixedSyntax()
    {
            var attributesNode = PhpArray.NewEmpty();
            attributesNode.Add("foo", "bar");
            var multipleNode1 = PhpArray.NewEmpty();
            multipleNode1.Add("name", "{http://sabredav.org/ns}foo");
            multipleNode1.Add("value", "bar");
            var multipleNode2 = PhpArray.NewEmpty();
            multipleNode2.Add("name", "{http://sabredav.org/ns}foo");
            multipleNode2.Add("value", "foobar");
            var mapNode = PhpArray.NewEmpty();
            mapNode.Add("{http://sabredav.org/ns}single","value");
            mapNode.Add("{http://sabredav.org/ns}multiple", PhpArray.New(multipleNode1, multipleNode2));
            var array1 = PhpArray.NewEmpty();
            array1.Add("name", "{http://sabredav.org/ns}attributes");
            array1.Add("value", PhpValue.Null);
            array1.Add("attributes", attributesNode);
            var array2 = PhpArray.NewEmpty();
            array2.Add("name", "{http://sabredav.org/ns}verbose");
            array2.Add("value", "syntax");
            array2.Add("attributes", attributesNode);
            mapNode.Add(array1);
            mapNode.Add(array2);
            var rootNode = PhpArray.NewEmpty();
            rootNode.Add("{http://sabredav.org/ns}root", mapNode);
            this.compare(rootNode, "<?xml version=\"1.0\"?>" + Environment.NewLine 
                + "<s:root xmlns:s=\"http://sabredav.org/ns\">" + Environment.NewLine
                + "<s:single>value</s:single>" + Environment.NewLine
                + "<s:multiple>" + Environment.NewLine 
                + "<s:foo>bar</s:foo>" + Environment.NewLine
                + "<s:foo>foobar</s:foo>" + Environment.NewLine
                + "</s:multiple>" + Environment.NewLine
                + "<s:attributes foo=\"bar\"/>" + Environment.NewLine
                + "<s:verbose foo=\"bar\">syntax</s:verbose>" + Environment.NewLine
                + "</s:root>");
    }
    }
}
