using System.Xml.Linq;
using NUnit.Framework;
using Pchp.Core;
using Pchp.Core.Utilities;
using Sabre.Xml;

namespace sabre.net.tests.sabre.Xml.Serializer
{
    public class FunctionsTest
    {
        private static void AssertXmlEquivalent(string expected, string actual)
        {
            Assert.That(XNode.DeepEquals(XDocument.Parse(expected), XDocument.Parse(actual)), Is.True);
        }

        private static System.Reflection.MethodInfo GetSerializerMethod(string name)
        {
            var serializerType = typeof(Service).Assembly.GetType("<Root>xml/lib/Serializer.functions_php", throwOnError: true);
            var method = serializerType!.GetMethod(name);
            Assert.That(method, Is.Not.Null);
            return method!;
        }

        private static Writer CreateWriter()
        {
            var writer = new Writer();
            var namespaceMap = PhpArray.NewEmpty();
            namespaceMap.Add("http://sabredav.org/ns", "s");
            writer.namespaceMap = namespaceMap;
            writer.openMemory();
            writer.startDocument();
            writer.startElement("{http://sabredav.org/ns}root");
            return writer;
        }

        [Test]
        public void TestRepeatingElements()
        {
            var writer = CreateWriter();
            var items = PhpArray.New("one", "two");

            GetSerializerMethod("Sabre.Xml.Serializer.repeatingElements")
                .Invoke(null, new object[] { ContextExtensions.CurrentContext, writer, items, new PhpString("{http://sabredav.org/ns}item") });

            writer.endElement();
            var xml = writer.outputMemory().ToString();

            AssertXmlEquivalent(
                "<?xml version=\"1.0\"?>\n" +
                "<s:root xmlns:s=\"http://sabredav.org/ns\">\n" +
                " <s:item>one</s:item>\n" +
                " <s:item>two</s:item>\n" +
                "</s:root>\n",
                xml);
        }

        [Test]
        public void TestStandardSerializerDescriptorArray()
        {
            var writer = CreateWriter();
            var attributes = PhpArray.NewEmpty();
            attributes.Add("foo", "bar");

            var descriptor = PhpArray.NewEmpty();
            descriptor.Add("name", "{http://sabredav.org/ns}item");
            descriptor.Add("attributes", attributes);
            descriptor.Add("value", "text");

            GetSerializerMethod("Sabre.Xml.Serializer.standardSerializer")
                .Invoke(null, new object[] { ContextExtensions.CurrentContext, writer, (PhpValue)descriptor });

            writer.endElement();
            var xml = writer.outputMemory().ToString();

            AssertXmlEquivalent(
                "<?xml version=\"1.0\"?>\n" +
                "<s:root xmlns:s=\"http://sabredav.org/ns\">\n" +
                " <s:item foo=\"bar\">text</s:item>\n" +
                "</s:root>\n",
                xml);
        }

        [Test]
        public void TestStandardSerializerThrowsOnUnsupportedObject()
        {
            var writer = CreateWriter();
            var ex = Assert.Throws<System.Reflection.TargetInvocationException>(() =>
                GetSerializerMethod("Sabre.Xml.Serializer.standardSerializer")
                    .Invoke(null, new object[] { ContextExtensions.CurrentContext, writer, PhpValue.FromClass(new object()) }));

            Assert.That(ex!.InnerException, Is.InstanceOf<Pchp.Library.Spl.InvalidArgumentException>());
            Assert.That(ex.InnerException!.Message, Does.Contain("The writer cannot serialize objects of class"));
        }
    }
}
