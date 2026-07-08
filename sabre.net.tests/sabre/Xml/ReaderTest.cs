using NUnit.Framework;
using Pchp.Core;
using Sabre.Xml;

namespace sabre.net.tests.sabre.Xml
{
    public class ReaderTest
    {
        private static PhpArray GetArray(PhpValue value)
        {
            var array = value.AsArray();
            Assert.That(array, Is.Not.Null);
            return array!;
        }

        private static PhpArray GetChild(PhpArray array, int index)
        {
            return GetArray(array[index]);
        }

        [Test]
        public void TestGetClark()
        {
            var input = "<?xml version=\"1.0\"?>\n<root xmlns=\"http://sabredav.org/ns\" />";
            var reader = new Reader();

            reader.XML(input);
            reader.next();

            Assert.That(reader.getClark().ToString(), Is.EqualTo("{http://sabredav.org/ns}root"));
        }

        [Test]
        public void TestGetClarkNoNs()
        {
            var input = "<?xml version=\"1.0\"?>\n<root />";
            var reader = new Reader();

            reader.XML(input);
            reader.next();

            Assert.That(reader.getClark().ToString(), Is.EqualTo("{}root"));
        }

        [Test]
        public void TestGetClarkNotOnAnElement()
        {
            var input = "<?xml version=\"1.0\"?>\n<root />";
            var reader = new Reader();

            reader.XML(input);

            Assert.That(reader.getClark().IsNull, Is.True);
        }

        [Test]
        public void TestSimple()
        {
            var input = "<?xml version=\"1.0\"?>\n" +
                "<root xmlns=\"http://sabredav.org/ns\">\n" +
                "  <elem1 attr=\"val\" />\n" +
                "  <elem2>\n" +
                "    <elem3>Hi!</elem3>\n" +
                "  </elem2>\n" +
                "</root>";
            var reader = new Reader();

            reader.XML(input);
            var output = reader.parse();

            Assert.Multiple(() =>
            {
                Assert.That(output["name"].ToString(), Is.EqualTo("{http://sabredav.org/ns}root"));
                Assert.That(GetArray(output["attributes"]).Count, Is.EqualTo(0));

                var children = GetArray(output["value"]);
                Assert.That(children.Count, Is.EqualTo(2));

                var elem1 = GetChild(children, 0);
                Assert.That(elem1["name"].ToString(), Is.EqualTo("{http://sabredav.org/ns}elem1"));
                Assert.That(elem1["value"].IsNull, Is.True);
                Assert.That(GetArray(elem1["attributes"])["attr"].ToString(), Is.EqualTo("val"));

                var elem2 = GetChild(children, 1);
                Assert.That(elem2["name"].ToString(), Is.EqualTo("{http://sabredav.org/ns}elem2"));
                Assert.That(GetArray(elem2["attributes"]).Count, Is.EqualTo(0));

                var nested = GetArray(elem2["value"]);
                Assert.That(nested.Count, Is.EqualTo(1));
                var elem3 = GetChild(nested, 0);
                Assert.That(elem3["name"].ToString(), Is.EqualTo("{http://sabredav.org/ns}elem3"));
                Assert.That(elem3["value"].ToString(), Is.EqualTo("Hi!"));
                Assert.That(GetArray(elem3["attributes"]).Count, Is.EqualTo(0));
            });
        }

        [Test]
        public void TestCData()
        {
            var input = "<?xml version=\"1.0\"?>\n" +
                "<root xmlns=\"http://sabredav.org/ns\">\n" +
                "  <foo><![CDATA[bar]]></foo>\n" +
                "</root>";
            var reader = new Reader();

            reader.XML(input);
            var output = reader.parse();

            var children = GetArray(output["value"]);
            var foo = GetChild(children, 0);
            Assert.Multiple(() =>
            {
                Assert.That(output["name"].ToString(), Is.EqualTo("{http://sabredav.org/ns}root"));
                Assert.That(foo["name"].ToString(), Is.EqualTo("{http://sabredav.org/ns}foo"));
                Assert.That(foo["value"].ToString(), Is.EqualTo("bar"));
            });
        }

        [Test]
        public void TestSimpleNamespacedAttribute()
        {
            var input = "<?xml version=\"1.0\"?>\n" +
                "<root xmlns=\"http://sabredav.org/ns\" xmlns:foo=\"urn:foo\">\n" +
                "  <elem1 foo:attr=\"val\" />\n" +
                "</root>";
            var reader = new Reader();

            reader.XML(input);
            var output = reader.parse();

            var children = GetArray(output["value"]);
            var elem1 = GetChild(children, 0);
            var attributes = GetArray(elem1["attributes"]);
            Assert.That(attributes["{urn:foo}attr"].ToString(), Is.EqualTo("val"));
        }

        [Test]
        public void TestReadText()
        {
            var input = "<?xml version=\"1.0\"?>\n" +
                "<root xmlns=\"http://sabredav.org/ns\"> before <child/> after <![CDATA[done]]></root>";
            var reader = new Reader();

            reader.XML(input);
            reader.next();

            Assert.That(reader.readText().ToString(), Is.EqualTo(" before  after done"));
        }
    }
}
