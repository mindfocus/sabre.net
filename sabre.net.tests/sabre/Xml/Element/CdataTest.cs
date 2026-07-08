using System.Xml.Linq;
using NUnit.Framework;
using Pchp.Core;
using Sabre.Xml;
using System;

namespace sabre.net.tests.sabre.Xml.ElementsCases
{
    public class CdataTest
    {
        private const string SabreNamespace = "http://sabredav.org/ns";

        private static void AssertXmlEquivalent(string expected, string actual)
        {
            Assert.That(XNode.DeepEquals(XDocument.Parse(expected), XDocument.Parse(actual)), Is.True);
        }

        [Test]
        public void TestCdataSerialize()
        {
            var service = new Service();
            var namespaceMap = PhpArray.NewEmpty();
            namespaceMap.Add(SabreNamespace, "s");
            service.namespaceMap = namespaceMap;

            var cdataType = typeof(Service).Assembly.GetType("Sabre.Xml.Element.Cdata", throwOnError: true);
            var cdata = Activator.CreateInstance(cdataType!, new object[] { new PhpString("<hello>&world") });
            Assert.That(cdata, Is.Not.Null);
            var xml = service.write($"{{{SabreNamespace}}}root", PhpValue.FromClass(cdata!)).ToString();

            AssertXmlEquivalent(
                "<?xml version=\"1.0\"?>\n" +
                "<s:root xmlns:s=\"http://sabredav.org/ns\"><![CDATA[<hello>&world]]></s:root>\n",
                xml);
        }
    }
}
