using System;
using System.Reflection;
using System.Xml.Linq;
using NUnit.Framework;
using Pchp.Core;
using Sabre.Xml;

namespace sabre.net.tests.sabre.Xml.ElementsCases
{
    public class UriTest
    {
        private const string DavNamespace = "DAV:";

        private static void AssertXmlEquivalent(string expected, string actual)
        {
            Assert.That(XNode.DeepEquals(XDocument.Parse(expected), XDocument.Parse(actual)), Is.True);
        }

        private static string GetInnerValue(object uri)
        {
            var field = uri.GetType().GetField("value", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.That(field, Is.Not.Null);
            return ((PhpValue)field!.GetValue(uri)!).ToString();
        }

        private static Service CreateService()
        {
            var service = new Service();
            var namespaceMap = PhpArray.NewEmpty();
            namespaceMap.Add(DavNamespace, "d");
            service.namespaceMap = namespaceMap;
            return service;
        }

        [Test]
        public void TestUriSerializeResolvesAgainstContext()
        {
            var service = CreateService();
            var uriType = typeof(Service).Assembly.GetType("Sabre.Xml.Element.Uri", throwOnError: true);
            var uri = Activator.CreateInstance(uriType!, new object[] { (PhpValue)"/child" });
            Assert.That(uri, Is.Not.Null);

            var xml = service.write($"{{{DavNamespace}}}href", PhpValue.FromClass(uri!), "https://example.org/base").ToString();

            AssertXmlEquivalent(
                "<?xml version=\"1.0\"?>\n" +
                "<d:href xmlns:d=\"DAV:\">https://example.org/child</d:href>\n",
                xml);
        }

        [Test]
        public void TestUriDeserializeResolvesAgainstContext()
        {
            var service = CreateService();
            var elementMap = PhpArray.NewEmpty();
            elementMap.Add($"{{{DavNamespace}}}href", "Sabre\\Xml\\Element\\Uri");
            service.elementMap = elementMap;
            var rootElement = PhpAlias.Create(PhpValue.Null);

            var parsed = service.parse(
                "<?xml version=\"1.0\"?>\n<d:href xmlns:d=\"DAV:\">/child</d:href>",
                "https://example.org/base",
                rootElement);

            var uri = parsed.AsObject();
            Assert.Multiple(() =>
            {
                Assert.That(rootElement.Value.ToString(), Is.EqualTo($"{{{DavNamespace}}}href"));
                Assert.That(uri, Is.Not.Null);
                Assert.That(GetInnerValue(uri!), Is.EqualTo("https://example.org/child"));
            });
        }
    }
}
