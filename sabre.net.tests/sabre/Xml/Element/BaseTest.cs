using System;
using NUnit.Framework;
using Pchp.Core;
using Sabre.Xml;

namespace sabre.net.tests.sabre.Xml.ElementsCases
{
    public class BaseTest
    {
        private const string SabreNamespace = "http://sabredav.org/ns";

        [Test]
        public void TestBaseDeserialize()
        {
            var service = new Service();
            var elementMap = PhpArray.NewEmpty();
            elementMap.Add($"{{{SabreNamespace}}}root", "Sabre\\Xml\\Element\\Base");
            service.elementMap = elementMap;
            var rootElement = PhpAlias.Create(PhpValue.Null);

            var parsed = service.parse(
                "<?xml version=\"1.0\"?>\n" +
                "<s:root xmlns:s=\"http://sabredav.org/ns\">\n" +
                " <s:child attr=\"value\">text</s:child>\n" +
                "</s:root>",
                PhpValue.Null,
                rootElement);

            var children = parsed.AsArray();
            Assert.That(children, Is.Not.Null);
            var child = children![0].AsArray();
            Assert.That(child, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(rootElement.Value.ToString(), Is.EqualTo($"{{{SabreNamespace}}}root"));
                Assert.That(child!["name"].ToString(), Is.EqualTo($"{{{SabreNamespace}}}child"));
                Assert.That(child["value"].ToString(), Is.EqualTo("text"));
                Assert.That(child["attributes"].AsArray()!["attr"].ToString(), Is.EqualTo("value"));
            });
        }

        [Test]
        public void TestBaseSerialize()
        {
            var service = new Service();
            var namespaceMap = PhpArray.NewEmpty();
            namespaceMap.Add(SabreNamespace, "s");
            service.namespaceMap = namespaceMap;

            var value = PhpArray.NewEmpty();
            value.Add($"{{{SabreNamespace}}}child", "text");
            var baseType = typeof(Service).Assembly.GetType("Sabre.Xml.Element.Base", throwOnError: true);
            var element = Activator.CreateInstance(baseType!, new object[] { (PhpValue)value });
            Assert.That(element, Is.Not.Null);

            var xml = service.write($"{{{SabreNamespace}}}root", PhpValue.FromClass(element!)).ToString();

            Assert.That(xml, Does.Contain("<s:child>text</s:child>"));
        }
    }
}
