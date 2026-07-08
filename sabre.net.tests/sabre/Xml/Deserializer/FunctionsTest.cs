using NUnit.Framework;
using Pchp.Core;
using Pchp.Core.Utilities;
using Sabre.Xml;

namespace sabre.net.tests.sabre.Xml.Deserializer
{
    public class FunctionsTest
    {
        private static System.Reflection.MethodInfo GetDeserializerMethod(string name)
        {
            var deserializerType = typeof(Service).Assembly.GetType("<Root>xml/lib/Deserializer.functions_php", throwOnError: true);
            var method = deserializerType!.GetMethod(name);
            Assert.That(method, Is.Not.Null);
            return method!;
        }

        private static Reader CreateReader(string xml)
        {
            var reader = new Reader();
            reader.XML(xml);
            reader.next();
            return reader;
        }

        [Test]
        public void TestKeyValue()
        {
            var reader = CreateReader(
                "<?xml version=\"1.0\"?>\n" +
                "<root xmlns=\"http://sabredav.org/ns\">\n" +
                "  <elem1>value1</elem1>\n" +
                "  <elem2>value2</elem2>\n" +
                "  <elem3 />\n" +
                "</root>");

            var values = (PhpArray)GetDeserializerMethod("Sabre.Xml.Deserializer.keyValue")
                .Invoke(null, new object[] { ContextExtensions.CurrentContext, reader, PhpValue.Null })!;

            Assert.Multiple(() =>
            {
                Assert.That(values["{http://sabredav.org/ns}elem1"].ToString(), Is.EqualTo("value1"));
                Assert.That(values["{http://sabredav.org/ns}elem2"].ToString(), Is.EqualTo("value2"));
                Assert.That(values["{http://sabredav.org/ns}elem3"].IsNull, Is.True);
            });
        }

        [Test]
        public void TestKeyValueStripsNamespace()
        {
            var reader = CreateReader(
                "<?xml version=\"1.0\"?>\n" +
                "<root xmlns=\"http://sabredav.org/ns\">\n" +
                "  <elem1>value1</elem1>\n" +
                "  <elem2>value2</elem2>\n" +
                "</root>");

            var values = (PhpArray)GetDeserializerMethod("Sabre.Xml.Deserializer.keyValue")
                .Invoke(null, new object[] { ContextExtensions.CurrentContext, reader, (PhpValue)"http://sabredav.org/ns" })!;

            Assert.Multiple(() =>
            {
                Assert.That(values["elem1"].ToString(), Is.EqualTo("value1"));
                Assert.That(values["elem2"].ToString(), Is.EqualTo("value2"));
            });
        }

        [Test]
        public void TestEnum()
        {
            var reader = CreateReader(
                "<?xml version=\"1.0\"?>\n" +
                "<root xmlns=\"http://sabredav.org/ns\">\n" +
                "  <elem1 />\n" +
                "  <elem2>value</elem2>\n" +
                "  <elem3 attr=\"val\" />\n" +
                "</root>");

            var values = (PhpArray)GetDeserializerMethod("Sabre.Xml.Deserializer.enum")
                .Invoke(null, new object[] { ContextExtensions.CurrentContext, reader, (PhpValue)"http://sabredav.org/ns" })!;

            Assert.That(values.Count, Is.EqualTo(3));
            Assert.That(values[0].ToString(), Is.EqualTo("elem1"));
            Assert.That(values[1].ToString(), Is.EqualTo("elem2"));
            Assert.That(values[2].ToString(), Is.EqualTo("elem3"));
        }

        [Test]
        public void TestRepeatingElements()
        {
            var reader = CreateReader(
                "<?xml version=\"1.0\"?>\n" +
                "<collection>\n" +
                "  <item>one</item>\n" +
                "  <skip>ignored</skip>\n" +
                "  <item>two</item>\n" +
                "</collection>");

            var values = (PhpArray)GetDeserializerMethod("Sabre.Xml.Deserializer.repeatingElements")
                .Invoke(null, new object[] { ContextExtensions.CurrentContext, reader, new PhpString("item") })!;

            Assert.That(values.Count, Is.EqualTo(2));
            Assert.That(values[0].ToString(), Is.EqualTo("one"));
            Assert.That(values[1].ToString(), Is.EqualTo("two"));
        }

        [Test]
        public void TestMixedContent()
        {
            var reader = CreateReader(
                "<?xml version=\"1.0\"?>\n" +
                "<p>some text<extref>and a inline tag</extref>and even more text</p>");

            var content = (PhpArray)GetDeserializerMethod("Sabre.Xml.Deserializer.mixedContent")
                .Invoke(null, new object[] { ContextExtensions.CurrentContext, reader })!;

            Assert.That(content.Count, Is.EqualTo(3));
            Assert.That(content[0].ToString(), Is.EqualTo("some text"));
            Assert.That(content[2].ToString(), Is.EqualTo("and even more text"));

            var node = content[1].AsArray();
            Assert.That(node, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(node!["name"].ToString(), Is.EqualTo("{}extref"));
                Assert.That(node["value"].ToString(), Is.EqualTo("and a inline tag"));
                Assert.That(node["attributes"].AsArray()!.Count, Is.EqualTo(0));
            });
        }
    }
}
