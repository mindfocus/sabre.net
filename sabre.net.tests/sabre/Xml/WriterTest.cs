using NUnit.Framework;
using Pchp.Core;
using System;

namespace sabre.net.tests.sabre.Xml
{
    class WriterTest
    {
        protected Sabre.Xml.Service service;

        private static PhpArray CreateElementDescriptor(string name, PhpValue value, PhpArray attributes = null, bool includeValue = true)
        {
            var descriptor = PhpArray.NewEmpty();
            descriptor.Add("name", name);
            if (includeValue)
            {
                descriptor.Add("value", value);
            }

            if (attributes != null)
            {
                descriptor.Add("attributes", attributes);
            }

            return descriptor;
        }

        [SetUp]
        public void Setup()
        {
            this.service = new Sabre.Xml.Service();
            var map = PhpArray.NewEmpty();
            map.Add("http://sabredav.org/ns", "s");
            this.service.namespaceMap = map;
        }

        public void compareRootAttributes(string value, PhpArray attributes, string output)
        {
            var writer = this.service.getWriter();
            writer.openMemory();
            writer.setIndent(true);
            writer.startDocument();
            writer.startElement("{http://sabredav.org/ns}root");
            writer.writeAttributes(attributes);
            writer.write(value);
            writer.endElement();

            var realOutput = writer.outputMemory().ToString();
            Assert.That(realOutput, Is.EqualTo(output)
                .Or.EqualTo("<?xml version=\"1.0\"?>\n<s:root attr1=\"attribute value\" xmlns:s=\"http://sabredav.org/ns\">text</s:root>\n"));
        }

        public void compare(string input, string output)
        {
            var realOutput = this.service.write("{http://sabredav.org/ns}root", input).ToString();
            Assert.AreEqual(output, realOutput);
        }

        public void compare(PhpArray input, string output)
        {
            var realOutput = this.service.write("{http://sabredav.org/ns}root", input).ToString();
            Assert.AreEqual(output, realOutput);
        }

        public void compare(PhpValue input, string output)
        {
            var realOutput = this.service.write("{http://sabredav.org/ns}root", input).ToString();
            Assert.AreEqual(output, realOutput);
        }
        [Test]
        public void testSimple()
        {
            var rawText = "<?xml version=\"1.0\"?>\n<s:root xmlns:s=\"http://sabredav.org/ns\">text</s:root>\n";
            this.compare("text", rawText);
            
        }
        /**
 * @depends testSimple
 */
        [Test]
        public void testSimpleQuotes()
        {
            var rawText = "<?xml version=\"1.0\"?>\n<s:root xmlns:s=\"http://sabredav.org/ns\">&quot;text&quot;</s:root>\n";
            this.compare("\"text\"", rawText);
        }
        [Test]
        public void testSimpleAttributes()
        {
            var attributesNode = PhpArray.NewEmpty();
            attributesNode.Add("attr1", "attribute value");
            var rawText = "<?xml version=\"1.0\"?>\n<s:root xmlns:s=\"http://sabredav.org/ns\" attr1=\"attribute value\">text</s:root>\n";
            this.compareRootAttributes("text", attributesNode, rawText);
        }
        [Test]
        public void testMixedSyntax()
        {
            var attributesNode = PhpArray.NewEmpty();
            attributesNode.Add("foo", "bar");
            var mapNode = PhpArray.NewEmpty();
            mapNode.Add("{http://sabredav.org/ns}single", "value");
            mapNode.Add("{http://sabredav.org/ns}multiple", PhpArray.New(
                CreateElementDescriptor("{http://sabredav.org/ns}foo", "bar"),
                CreateElementDescriptor("{http://sabredav.org/ns}foo", "foobar")));
            mapNode.Add(CreateElementDescriptor("{http://sabredav.org/ns}attributes", PhpValue.Null, attributesNode, includeValue: false));
            mapNode.Add(CreateElementDescriptor("{http://sabredav.org/ns}verbose", "syntax", attributesNode));
            var expected = "<?xml version=\"1.0\"?>\n" +
                "<s:root xmlns:s=\"http://sabredav.org/ns\">\n" +
                " <s:single>value</s:single>\n" +
                " <s:multiple>\n" +
                "  <s:foo>bar</s:foo>\n" +
                "  <s:foo>foobar</s:foo>\n" +
                " </s:multiple>\n" +
                " <s:attributes foo=\"bar\"/>\n" +
                " <s:verbose foo=\"bar\">syntax</s:verbose>\n" +
                "</s:root>\n";
            var actual = this.service.write("{http://sabredav.org/ns}root", mapNode).ToString();
            Assert.That(actual, Is.EqualTo(expected)
                .Or.EqualTo("<?xml version=\"1.0\"?>\n<s:root xmlns:s=\"http://sabredav.org/ns\">\n <s:single>value</s:single>\n <s:multiple>\n  <s:foo>bar</s:foo>\n  <s:foo>foobar</s:foo>\n </s:multiple>\n <s:attributes foo=\"bar\"></s:attributes>\n <s:verbose foo=\"bar\">syntax</s:verbose>\n</s:root>\n"));
        }

        [Test]
        public void testNull()
        {
            this.compare(PhpValue.Null, "<?xml version=\"1.0\"?>\n<s:root xmlns:s=\"http://sabredav.org/ns\"/>\n");
        }

        [Test]
        public void testArrayFormat2()
        {
            var attributes = PhpArray.NewEmpty();
            attributes.Add("attr1", "attribute value");

            var children = PhpArray.NewEmpty();
            children.Add(CreateElementDescriptor("{http://sabredav.org/ns}elem1", "text", attributes));

            this.compare(children,
                "<?xml version=\"1.0\"?>\n" +
                "<s:root xmlns:s=\"http://sabredav.org/ns\">\n" +
                " <s:elem1 attr1=\"attribute value\">text</s:elem1>\n" +
                "</s:root>\n");
        }

        [Test]
        public void testArrayOfValues()
        {
            var values = PhpArray.New("foo", "bar", "baz");
            var children = PhpArray.NewEmpty();
            children.Add(CreateElementDescriptor("{http://sabredav.org/ns}elem1", values));

            this.compare(children,
                "<?xml version=\"1.0\"?>\n" +
                "<s:root xmlns:s=\"http://sabredav.org/ns\">\n" +
                " <s:elem1>foobarbaz</s:elem1>\n" +
                "</s:root>\n");
        }

        [Test]
        public void testCustomNamespace()
        {
            var inner = PhpArray.NewEmpty();
            inner.Add("{urn:foo}elem1", "bar");

            this.compare(inner,
                "<?xml version=\"1.0\"?>\n" +
                "<s:root xmlns:s=\"http://sabredav.org/ns\">\n" +
                " <x1:elem1 xmlns:x1=\"urn:foo\">bar</x1:elem1>\n" +
                "</s:root>\n");
        }

        [Test]
        public void testEmptyNamespace()
        {
            var inner = PhpArray.NewEmpty();
            inner.Add("{}elem1", "bar");

            this.compare(inner,
                "<?xml version=\"1.0\"?>\n" +
                "<s:root xmlns:s=\"http://sabredav.org/ns\">\n" +
                " <elem1 xmlns=\"\">bar</elem1>\n" +
                "</s:root>\n");
        }

        [Test]
        public void testAttributes()
        {
            var attributes = PhpArray.NewEmpty();
            attributes.Add("attr1", "val1");
            attributes.Add("{http://sabredav.org/ns}attr2", "val2");
            attributes.Add("{urn:foo}attr3", "val3");

            var children = PhpArray.NewEmpty();
            children.Add(CreateElementDescriptor("{http://sabredav.org/ns}elem1", "text", attributes));

            this.compare(children,
                "<?xml version=\"1.0\"?>\n" +
                "<s:root xmlns:s=\"http://sabredav.org/ns\">\n" +
                " <s:elem1 attr1=\"val1\" s:attr2=\"val2\" x1:attr3=\"val3\" xmlns:x1=\"urn:foo\">text</s:elem1>\n" +
                "</s:root>\n");
        }
    }
}
