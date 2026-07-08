using NUnit.Framework;
using Pchp.Core;
using Sabre.Xml;

namespace sabre.net.libxml2.tests
{
    public class ServiceLibXml2Test
    {
        private const string SabreNamespace = "http://sabredav.org/ns";
        private const string DavNamespace = "DAV:";

        private static Service CreateService()
        {
            var service = new Service();
            var namespaceMap = PhpArray.NewEmpty();
            namespaceMap.Add(SabreNamespace, "s");
            namespaceMap.Add(DavNamespace, "d");
            service.namespaceMap = namespaceMap;
            return service;
        }

        private static object CreateXmlFragment(string xml)
        {
            var fragmentType = typeof(Service).Assembly.GetType("Sabre.Xml.Element.XmlFragment", throwOnError: true);
            Assert.That(fragmentType, Is.Not.Null);
            return System.Activator.CreateInstance(fragmentType!, new object[] { new PhpString(xml) })!;
        }

        [Test]
        public void Write_UsesLibXml2Writer_ForSimpleDocument()
        {
            var service = CreateService();

            var xml = service.write($"{{{SabreNamespace}}}root", "text").ToString();

            Assert.That(xml, Is.EqualTo(
                "<?xml version=\"1.0\"?>\n" +
                "<s:root xmlns:d=\"DAV:\" xmlns:s=\"http://sabredav.org/ns\">text</s:root>\n"));
        }

        [Test]
        public void Parse_UsesLibXml2Reader_ForSimpleDocument()
        {
            var service = CreateService();
            var rootElement = PhpAlias.Create(PhpValue.Null);

            var value = service.parse(
                "<?xml version=\"1.0\"?><s:root xmlns:s=\"http://sabredav.org/ns\">text</s:root>",
                PhpValue.Null,
                rootElement);

            Assert.That(rootElement.Value.ToString(), Is.EqualTo($"{{{SabreNamespace}}}root"));
            Assert.That(value.ToString(), Is.EqualTo("text"));
        }

        [Test]
        public void XmlFragment_RoundTrips_ThroughService()
        {
            var service = CreateService();
            var elementMap = PhpArray.NewEmpty();
            elementMap.Add($"{{{DavNamespace}}}owner", "Sabre\\Xml\\Element\\XmlFragment");
            service.elementMap = elementMap;

            var fragment = CreateXmlFragment("<d:href>/principals/admin</d:href>");
            var xml = service.write($"{{{DavNamespace}}}owner", PhpValue.FromClass(fragment)).ToString();
            var rootElement = PhpAlias.Create(PhpValue.Null);

            var parsed = service.parse(xml, PhpValue.Null, rootElement);
            var parsedObject = parsed.AsObject();
            Assert.That(parsedObject, Is.Not.Null);
            var parsedType = parsedObject!.GetType();
            var getXml = parsedType.GetMethod("getXml");
            Assert.That(getXml, Is.Not.Null);
            var parsedXml = getXml!.Invoke(parsedObject, null)?.ToString();

            Assert.That(rootElement.Value.ToString(), Is.EqualTo($"{{{DavNamespace}}}owner"));
            Assert.That(xml, Does.Contain("<d:owner"));
            Assert.That(xml, Does.Contain("<d:href>/principals/admin</d:href>"));
            Assert.That(parsedType.FullName, Is.EqualTo("Sabre.Xml.Element.XmlFragment"));
            Assert.That(parsedXml, Does.Contain("<d:href>/principals/admin</d:href>"));
        }
    }
}
