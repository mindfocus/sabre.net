using System;
using System.Xml.Linq;
using NUnit.Framework;
using Pchp.Core;
using Sabre.Xml;

namespace sabre.net.tests.sabre.Xml.ElementsCases
{
    public class KeyValueTest
    {
        private const string SabreNamespace = "http://sabredav.org/ns";

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
            namespaceMap.Add(SabreNamespace, "s");
            service.namespaceMap = namespaceMap;
            return service;
        }

        [Test]
        public void TestKeyValueSerialize()
        {
            var service = CreateService();
            var values = PhpArray.NewEmpty();
            values.Add($"{{{SabreNamespace}}}elem1", "value1");
            values.Add($"{{{SabreNamespace}}}elem2", PhpValue.Null);
            var keyValueType = typeof(Service).Assembly.GetType("Sabre.Xml.Element.KeyValue", throwOnError: true);
            var element = Activator.CreateInstance(keyValueType!, new object[] { values });
            Assert.That(element, Is.Not.Null);

            var xml = service.write($"{{{SabreNamespace}}}root", PhpValue.FromClass(element!)).ToString();

            AssertXmlEquivalent(
                "<?xml version=\"1.0\"?>\n" +
                "<s:root xmlns:s=\"http://sabredav.org/ns\">\n" +
                " <s:elem1>value1</s:elem1>\n" +
                " <s:elem2></s:elem2>\n" +
                "</s:root>\n",
                xml);
        }

        [Test]
        public void TestKeyValueDeserialize()
        {
            var service = CreateService();
            var elementMap = PhpArray.NewEmpty();
            elementMap.Add($"{{{SabreNamespace}}}root", "Sabre\\Xml\\Element\\KeyValue");
            service.elementMap = elementMap;
            var rootElement = PhpAlias.Create(PhpValue.Null);

            var parsed = service.parse(
                "<?xml version=\"1.0\"?>\n" +
                "<s:root xmlns:s=\"http://sabredav.org/ns\">\n" +
                " <s:elem1>value1</s:elem1>\n" +
                " <s:elem2/>\n" +
                "</s:root>",
                PhpValue.Null,
                rootElement);

            var values = parsed.AsArray();
            Assert.That(values, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(rootElement.Value.ToString(), Is.EqualTo($"{{{SabreNamespace}}}root"));
                Assert.That(values![$"{{{SabreNamespace}}}elem1"].ToString(), Is.EqualTo("value1"));
                Assert.That(values[$"{{{SabreNamespace}}}elem2"].IsNull, Is.True);
            });
        }
    }
}
