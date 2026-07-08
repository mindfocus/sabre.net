using NUnit.Framework;
using Pchp.Core;
using Sabre.Xml;
using System.Xml.Linq;

namespace sabre.net.tests.sabre.DAV.Xml.Property
{
    public class HrefTest
    {
        private static void AssertXmlEquivalent(string expected, string actual)
        {
            Assert.That(
                XDocument.Parse(actual).ToString(SaveOptions.DisableFormatting),
                Is.EqualTo(XDocument.Parse(expected).ToString(SaveOptions.DisableFormatting)));
        }

        private static Service CreateService()
        {
            var service = new Service();
            var namespaceMap = PhpArray.NewEmpty();
            namespaceMap.Add("DAV:", "d");
            service.namespaceMap = namespaceMap;

            var elementMap = PhpArray.NewEmpty();
            elementMap.Add("{DAV:}anything", "Sabre\\DAV\\Xml\\Property\\Href");
            service.elementMap = elementMap;
            return service;
        }

        [Test]
        public void TestConstruct()
        {
            var href = new Sabre.DAV.Xml.Property.Href("path");
            Assert.That(href.getHref().ToString(), Is.EqualTo("path"));
        }

        [Test]
        public void TestSerialize()
        {
            var service = CreateService();
            var href = new Sabre.DAV.Xml.Property.Href("path");

            var xml = service.write("{DAV:}anything", PhpValue.FromClass(href), "/bla/").ToString();

            AssertXmlEquivalent(
                "<?xml version=\"1.0\"?>\n" +
                "<d:anything xmlns:d=\"DAV:\"><d:href>/bla/path</d:href></d:anything>\n",
                xml);
        }

        [Test]
        public void TestUnserialize()
        {
            var service = CreateService();
            var rootElement = PhpAlias.Create(PhpValue.Null);
            var xml = "<?xml version=\"1.0\"?>\n<d:anything xmlns:d=\"DAV:\"><d:href>/bla/path</d:href></d:anything>\n";

            var parsed = service.parse(xml, PhpValue.Null, rootElement);
            var href = parsed.AsObject() as Sabre.DAV.Xml.Property.Href;

            Assert.Multiple(() =>
            {
                Assert.That(rootElement.Value.ToString(), Is.EqualTo("{DAV:}anything"));
                Assert.That(href, Is.Not.Null);
                Assert.That(href!.getHref().ToString(), Is.EqualTo("/bla/path"));
            });
        }

        [Test]
        public void TestUnserializeIncompatible()
        {
            var service = CreateService();
            var rootElement = PhpAlias.Create(PhpValue.Null);
            var xml = "<?xml version=\"1.0\"?>\n<d:anything xmlns:d=\"DAV:\"><d:href2>/bla/path</d:href2></d:anything>\n";

            var parsed = service.parse(xml, PhpValue.Null, rootElement);

            Assert.Multiple(() =>
            {
                Assert.That(rootElement.Value.ToString(), Is.EqualTo("{DAV:}anything"));
                Assert.That(parsed.IsNull, Is.True);
            });
        }

        [Test]
        public void TestUnserializeEmpty()
        {
            var service = CreateService();
            var rootElement = PhpAlias.Create(PhpValue.Null);
            var xml = "<?xml version=\"1.0\"?>\n<d:anything xmlns:d=\"DAV:\"></d:anything>\n";

            var parsed = service.parse(xml, PhpValue.Null, rootElement);

            Assert.Multiple(() =>
            {
                Assert.That(rootElement.Value.ToString(), Is.EqualTo("{DAV:}anything"));
                Assert.That(parsed.IsNull, Is.True);
            });
        }

        [Test]
        public void TestSerializeEntity()
        {
            var service = CreateService();
            var href = new Sabre.DAV.Xml.Property.Href("http://example.org/?a&b");

            var xml = service.write("{DAV:}anything", PhpValue.FromClass(href)).ToString();

            AssertXmlEquivalent(
                "<?xml version=\"1.0\"?>\n" +
                "<d:anything xmlns:d=\"DAV:\"><d:href>http://example.org/?a&amp;b</d:href></d:anything>\n",
                xml);
        }
    }
}
