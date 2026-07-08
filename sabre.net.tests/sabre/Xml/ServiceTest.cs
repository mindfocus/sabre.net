using System.Xml.Linq;
using NUnit.Framework;
using Pchp.Core;
using Sabre.Xml;

namespace sabre.net.tests.sabre.Xml
{
    public class ServiceTest
    {
        private static void AssertXmlEquivalent(string expected, string actual)
        {
            Assert.That(
                XDocument.Parse(actual).ToString(SaveOptions.DisableFormatting),
                Is.EqualTo(XDocument.Parse(expected).ToString(SaveOptions.DisableFormatting)));
        }

        private static PhpArray GetArray(PhpValue value)
        {
            var array = value.AsArray();
            Assert.That(array, Is.Not.Null);
            return array!;
        }

        [Test]
        public void TestGetReader()
        {
            var elems = PhpArray.NewEmpty();
            elems.Add("{http://sabre.io/ns}test", "stdClass");

            var service = new Service();
            service.elementMap = elems;

            var reader = service.getReader();

            Assert.That(reader.elementMap["{http://sabre.io/ns}test"].ToString(), Is.EqualTo("stdClass"));
        }

        [Test]
        public void TestGetWriter()
        {
            var namespaces = PhpArray.NewEmpty();
            namespaces.Add("http://sabre.io/ns", "stdClass");

            var service = new Service();
            service.namespaceMap = namespaces;

            var writer = service.getWriter();

            Assert.That(writer.namespaceMap["http://sabre.io/ns"].ToString(), Is.EqualTo("stdClass"));
        }

        [Test]
        public void TestEmptyInputParse()
        {
            var service = new Service();
            var ex = Assert.Throws<ParseException>(() => service.parse(string.Empty));
            Assert.That(ex!.Message, Does.Contain("The input element to parse is empty"));
        }

        [Test]
        public void TestParse()
        {
            var xml = "<root xmlns=\"http://sabre.io/ns\">\n  <child>value</child>\n</root>";
            var service = new Service();
            var rootElement = PhpAlias.Create(PhpValue.Null);

            var result = service.parse(xml, PhpValue.Null, rootElement);

            var children = GetArray(result);
            Assert.Multiple(() =>
            {
                Assert.That(rootElement.Value.ToString(), Is.EqualTo("{http://sabre.io/ns}root"));
                Assert.That(children.Count, Is.EqualTo(1));
                Assert.That(children[0].AsArray()["name"].ToString(), Is.EqualTo("{http://sabre.io/ns}child"));
                Assert.That(children[0].AsArray()["value"].ToString(), Is.EqualTo("value"));
            });
        }

        [Test]
        public void TestEmptyInputExpect()
        {
            var service = new Service();
            var ex = Assert.Throws<ParseException>(() => service.expect("foo", string.Empty));
            Assert.That(ex!.Message, Does.Contain("The input element to parse is empty"));
        }

        [Test]
        public void TestExpect()
        {
            var xml = "<root xmlns=\"http://sabre.io/ns\">\n  <child>value</child>\n</root>";
            var service = new Service();

            var result = service.expect("{http://sabre.io/ns}root", xml);

            var children = GetArray(result);
            Assert.Multiple(() =>
            {
                Assert.That(children.Count, Is.EqualTo(1));
                Assert.That(children[0].AsArray()["name"].ToString(), Is.EqualTo("{http://sabre.io/ns}child"));
                Assert.That(children[0].AsArray()["value"].ToString(), Is.EqualTo("value"));
            });
        }

        [Test]
        public void TestExpectWrong()
        {
            var xml = "<root xmlns=\"http://sabre.io/ns\">\n  <child>value</child>\n</root>";
            var service = new Service();

            var ex = Assert.Throws<ParseException>(() => service.expect("{http://sabre.io/ns}error", xml));
            Assert.That(ex!.Message, Does.Contain("Expected {http://sabre.io/ns}error but received {http://sabre.io/ns}root"));
        }

        [Test]
        public void TestWrite()
        {
            var service = new Service();
            var namespaces = PhpArray.NewEmpty();
            namespaces.Add("http://sabre.io/ns", "stdClass");
            service.namespaceMap = namespaces;

            var value = PhpArray.NewEmpty();
            value.Add("{http://sabre.io/ns}child", "value");

            var result = service.write("{http://sabre.io/ns}root", value).ToString();

            AssertXmlEquivalent(
                "<?xml version=\"1.0\"?>\n" +
                "<stdClass:root xmlns:stdClass=\"http://sabre.io/ns\">\n" +
                " <stdClass:child>value</stdClass:child>\n" +
                "</stdClass:root>",
                result);
        }
    }
}
