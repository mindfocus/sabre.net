using System;
using System.Xml.Linq;
using NUnit.Framework;
using Pchp.Core;
using Sabre.Xml;

namespace sabre.net.tests.sabre.Xml.ElementsCases
{
    public class ElementsTest
    {
        private const string SabreNamespace = "http://sabredav.org/ns";

        private static void AssertXmlEquivalent(string expected, string actual)
        {
            Assert.That(XNode.DeepEquals(XDocument.Parse(expected), XDocument.Parse(actual)), Is.True);
        }

        private static Service CreateService()
        {
            var service = new Service();
            var namespaceMap = PhpArray.NewEmpty();
            namespaceMap.Add(SabreNamespace, "s");
            service.namespaceMap = namespaceMap;
            return service;
        }

        [Test]
        public void TestElementsSerialize()
        {
            var service = CreateService();
            var elementsType = typeof(Service).Assembly.GetType("Sabre.Xml.Element.Elements", throwOnError: true);
            var elements = Activator.CreateInstance(elementsType!, new object[] { PhpArray.New(
                $"{{{SabreNamespace}}}elem1",
                $"{{{SabreNamespace}}}elem2") });
            Assert.That(elements, Is.Not.Null);

            var xml = service.write($"{{{SabreNamespace}}}root", PhpValue.FromClass(elements!)).ToString();

            AssertXmlEquivalent(
                "<?xml version=\"1.0\"?>\n" +
                "<s:root xmlns:s=\"http://sabredav.org/ns\">\n" +
                " <s:elem1/>\n" +
                " <s:elem2/>\n" +
                "</s:root>\n",
                xml);
        }

        [Test]
        public void TestElementsDeserialize()
        {
            var service = CreateService();
            var elementMap = PhpArray.NewEmpty();
            elementMap.Add($"{{{SabreNamespace}}}root", "Sabre\\Xml\\Element\\Elements");
            service.elementMap = elementMap;
            var rootElement = PhpAlias.Create(PhpValue.Null);

            var parsed = service.parse(
                "<?xml version=\"1.0\"?>\n" +
                "<s:root xmlns:s=\"http://sabredav.org/ns\">\n" +
                " <s:elem1/>\n" +
                " <s:elem2>text</s:elem2>\n" +
                "</s:root>",
                PhpValue.Null,
                rootElement);

            var values = parsed.AsArray();
            Assert.That(values, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(rootElement.Value.ToString(), Is.EqualTo($"{{{SabreNamespace}}}root"));
                Assert.That(values!.Count, Is.EqualTo(2));
                Assert.That(values[0].ToString(), Is.EqualTo($"{{{SabreNamespace}}}elem1"));
                Assert.That(values[1].ToString(), Is.EqualTo($"{{{SabreNamespace}}}elem2"));
            });
        }
    }
}
