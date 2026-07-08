using System.Xml.Linq;
using NUnit.Framework;
using Pchp.Core.Utilities;

namespace sabre.net.tests.sabre.VObject
{
    public class WriterTest
    {
        private static Sabre.VObject.Document GetComponent()
        {
            var result = Sabre.VObject.Reader.read(ContextExtensions.CurrentContext, "BEGIN:VCALENDAR\r\nEND:VCALENDAR");
            Assert.That(result.Object, Is.Not.Null);
            return (Sabre.VObject.Document)result.Object;
        }

        private static void AssertXmlEquivalent(string expected, string actual)
        {
            Assert.That(XNode.DeepEquals(XDocument.Parse(expected), XDocument.Parse(actual)), Is.True);
        }

        [Test]
        public void TestWriteToMimeDir()
        {
            var result = Sabre.VObject.Writer.write(ContextExtensions.CurrentContext, GetComponent()).ToString();

            Assert.That(result, Is.EqualTo("BEGIN:VCALENDAR\r\nEND:VCALENDAR\r\n"));
        }

        [Test]
        public void TestWriteToJson()
        {
            var result = Sabre.VObject.Writer.writeJson(ContextExtensions.CurrentContext, GetComponent()).ToString();

            Assert.That(result, Is.EqualTo("[\"vcalendar\",[],[]]"));
        }

        [Test]
        public void TestWriteToXml()
        {
            var result = Sabre.VObject.Writer.writeXml(ContextExtensions.CurrentContext, GetComponent());

            AssertXmlEquivalent(
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
                "<icalendar xmlns=\"urn:ietf:params:xml:ns:icalendar-2.0\">\n" +
                " <vcalendar/>\n" +
                "</icalendar>\n",
                result);
        }
    }
}
