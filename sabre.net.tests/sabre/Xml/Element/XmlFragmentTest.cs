using System.Collections.Generic;
using System.Xml.Linq;
using NUnit.Framework;
using Pchp.Core;
using Sabre.Xml;

namespace sabre.net.tests.sabre.Xml.Element
{
    public class XmlFragmentTest
    {
        private const string SabreNamespace = "http://sabredav.org/ns";

        private static object CreateXmlFragment(string xml)
        {
            var fragmentType = typeof(Service).Assembly.GetType("Sabre.Xml.Element.XmlFragment", throwOnError: true);
            Assert.That(fragmentType, Is.Not.Null);
            return System.Activator.CreateInstance(fragmentType!, new object[] { new PhpString(xml) })!;
        }

        private static string GetXmlFromFragment(object fragment)
        {
            var getXml = fragment.GetType().GetMethod("getXml");
            Assert.That(getXml, Is.Not.Null);
            return getXml!.Invoke(fragment, null)?.ToString() ?? string.Empty;
        }

        private static void AssertFragmentEquivalent(string expected, string actual)
        {
            var expectedDocument = XDocument.Parse("<root>" + expected + "</root>");
            var actualDocument = XDocument.Parse("<root>" + actual + "</root>");
            Assert.That(XNode.DeepEquals(expectedDocument.Root, actualDocument.Root), Is.True);
        }

        private static void AssertXmlEquivalent(string expected, string actual)
        {
            Assert.That(XNode.DeepEquals(XDocument.Parse(expected), XDocument.Parse(actual)), Is.True);
        }

        private static IEnumerable<object[]> XmlProvider()
        {
            yield return new object[] { "hello", "hello", null };
            yield return new object[] { "<element>hello</element>", "<element xmlns=\"http://sabredav.org/ns\">hello</element>", null };
            yield return new object[] { "<element foo=\"bar\">hello</element>", "<element xmlns=\"http://sabredav.org/ns\" foo=\"bar\">hello</element>", null };
            yield return new object[] { "<element x1:foo=\"bar\" xmlns:x1=\"http://example.org/ns\">hello</element>", "<element xmlns:x1=\"http://example.org/ns\" xmlns=\"http://sabredav.org/ns\" x1:foo=\"bar\">hello</element>", null };
            yield return new object[] { "<element xmlns=\"http://example.org/ns\">hello</element>", "<element xmlns=\"http://example.org/ns\">hello</element>", "<x1:element xmlns:x1=\"http://example.org/ns\">hello</x1:element>" };
            yield return new object[] { "<element xmlns:foo=\"http://example.org/ns\">hello</element>", "<element xmlns:foo=\"http://example.org/ns\" xmlns=\"http://sabredav.org/ns\">hello</element>", "<element>hello</element>" };
            yield return new object[] { "<foo:element xmlns:foo=\"http://example.org/ns\">hello</foo:element>", "<foo:element xmlns:foo=\"http://example.org/ns\">hello</foo:element>", "<x1:element xmlns:x1=\"http://example.org/ns\">hello</x1:element>" };
            yield return new object[] { "<foo:element xmlns:foo=\"http://example.org/ns\"><child>hello</child></foo:element>", "<foo:element xmlns:foo=\"http://example.org/ns\" xmlns=\"http://sabredav.org/ns\"><child>hello</child></foo:element>", "<x1:element xmlns:x1=\"http://example.org/ns\"><child>hello</child></x1:element>" };
            yield return new object[] { "<foo:element xmlns:foo=\"http://example.org/ns\"><child/></foo:element>", "<foo:element xmlns:foo=\"http://example.org/ns\" xmlns=\"http://sabredav.org/ns\"><child/></foo:element>", "<x1:element xmlns:x1=\"http://example.org/ns\"><child/></x1:element>" };
            yield return new object[] { "<foo:element xmlns:foo=\"http://example.org/ns\"><child a=\"b\"/></foo:element>", "<foo:element xmlns:foo=\"http://example.org/ns\" xmlns=\"http://sabredav.org/ns\"><child a=\"b\"/></foo:element>", "<x1:element xmlns:x1=\"http://example.org/ns\"><child a=\"b\"/></x1:element>" };
        }

        [TestCaseSource(nameof(XmlProvider))]
        public void TestDeserialize(string input, string expected, string expectedSerialized)
        {
            var xml = "<?xml version=\"1.0\"?>\n" +
                "<root xmlns=\"http://sabredav.org/ns\">\n" +
                $"   <fragment>{input}</fragment>\n" +
                "</root>";
            var reader = new Reader();
            var elementMap = PhpArray.NewEmpty();
            elementMap.Add("{http://sabredav.org/ns}fragment", "Sabre\\Xml\\Element\\XmlFragment");
            reader.elementMap = elementMap;

            reader.XML(xml);
            var output = reader.parse();

            var children = output["value"].AsArray();
            Assert.That(children, Is.Not.Null);
            var fragmentNode = children![0].AsArray();
            Assert.That(fragmentNode, Is.Not.Null);
            var fragment = fragmentNode!["value"].AsObject();

            Assert.Multiple(() =>
            {
                Assert.That(output["name"].ToString(), Is.EqualTo("{http://sabredav.org/ns}root"));
                Assert.That(fragmentNode["name"].ToString(), Is.EqualTo("{http://sabredav.org/ns}fragment"));
                Assert.That(fragment, Is.Not.Null);
                AssertFragmentEquivalent(expected, GetXmlFromFragment(fragment!));
            });
        }

        [TestCaseSource(nameof(XmlProvider))]
        public void TestSerialize(string expectedFallback, string input, string expected)
        {
            if (expected == null)
            {
                expected = expectedFallback;
            }

            var service = new Service();
            var namespaceMap = PhpArray.NewEmpty();
            namespaceMap.Add(SabreNamespace, PhpValue.Null);
            service.namespaceMap = namespaceMap;

            var value = PhpArray.NewEmpty();
            value.Add($"{{{SabreNamespace}}}fragment", PhpValue.FromClass(CreateXmlFragment(input)));

            var output = service.write($"{{{SabreNamespace}}}root", value).ToString();
            var expectedXml = "<?xml version=\"1.0\"?>\n" +
                $"<root xmlns=\"{SabreNamespace}\"><fragment>{expected}</fragment></root>";

            AssertXmlEquivalent(expectedXml, output);
        }
    }
}
