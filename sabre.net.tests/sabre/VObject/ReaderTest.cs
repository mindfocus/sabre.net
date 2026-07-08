using System.Reflection;
using NUnit.Framework;
using Pchp.Core;
using Pchp.Core.Utilities;

namespace sabre.net.tests.sabre.VObject
{
    public class ReaderTest
    {
        private static Sabre.VObject.Document ReadDocument(string data)
        {
            var result = Sabre.VObject.Reader.read(ContextExtensions.CurrentContext, data);
            Assert.That(result.Object, Is.Not.Null);
            return (Sabre.VObject.Document)result.Object;
        }

        private static string GetNodeName(object node)
        {
            var field = node.GetType().GetField("name") ?? node.GetType().BaseType?.GetField("name");
            Assert.That(field, Is.Not.Null);
            return ((PhpValue)field!.GetValue(node)!).ToString();
        }

        private static string GetPropertyValue(object property)
        {
            var method = property.GetType().GetMethod("getValue");
            Assert.That(method, Is.Not.Null);
            return method!.Invoke(property, null)?.ToString() ?? string.Empty;
        }

        private static PhpArray GetParameters(object property)
        {
            var method = property.GetType().GetMethod("parameters");
            Assert.That(method, Is.Not.Null);
            var value = (PhpValue)method!.Invoke(property, null)!;
            Assert.That(value.Array, Is.Not.Null);
            return value.Array!;
        }

        private static PhpArray GetChildren(object component)
        {
            var method = component.GetType().GetMethod("children");
            Assert.That(method, Is.Not.Null);
            var childrenValue = (PhpValue)method!.Invoke(component, null)!;
            var children = childrenValue.Array;
            Assert.That(children, Is.Not.Null);
            return children!;
        }

        [Test]
        public void TestReadComponent()
        {
            var result = ReadDocument("BEGIN:VCALENDAR\r\nEND:VCALENDAR");

            Assert.Multiple(() =>
            {
                Assert.That(GetNodeName(result), Is.EqualTo("VCALENDAR"));
                Assert.That(GetChildren(result).Count, Is.EqualTo(0));
            });
        }

        [Test]
        public void TestReadComponentUnixNewLine()
        {
            var result = ReadDocument("BEGIN:VCALENDAR\nEND:VCALENDAR");

            Assert.That(GetNodeName(result), Is.EqualTo("VCALENDAR"));
            Assert.That(GetChildren(result).Count, Is.EqualTo(0));
        }

        [Test]
        public void TestReadComponentLineFold()
        {
            var result = ReadDocument("BEGIN:\r\n\tVCALENDAR\r\nE\r\n ND:VCALENDAR");

            Assert.That(GetNodeName(result), Is.EqualTo("VCALENDAR"));
            Assert.That(GetChildren(result).Count, Is.EqualTo(0));
        }

        [Test]
        public void TestReadCorruptComponent()
        {
            Assert.Throws<Sabre.VObject.ParseException>(() =>
                Sabre.VObject.Reader.read(ContextExtensions.CurrentContext, "BEGIN:VCALENDAR\r\nEND:FOO"));
        }

        [Test]
        public void TestReadCorruptSubComponent()
        {
            Assert.Throws<Sabre.VObject.ParseException>(() =>
                Sabre.VObject.Reader.read(ContextExtensions.CurrentContext, "BEGIN:VCALENDAR\r\nBEGIN:VEVENT\r\nEND:FOO\r\nEND:VCALENDAR"));
        }

        [Test]
        public void TestReadProperty()
        {
            var result = ReadDocument("BEGIN:VCALENDAR\r\nSUMMARY:propValue\r\nEND:VCALENDAR");
            var summary = result.__get("SUMMARY").Object;

            Assert.Multiple(() =>
            {
                Assert.That(summary, Is.Not.Null);
                Assert.That(summary!.GetType().FullName, Does.StartWith("Sabre.VObject.Property"));
                Assert.That(GetNodeName(summary!), Is.EqualTo("SUMMARY"));
                Assert.That(GetPropertyValue(summary!), Is.EqualTo("propValue"));
            });
        }

        [Test]
        public void TestReadPropertyWithNewLine()
        {
            var result = ReadDocument("BEGIN:VCALENDAR\r\nSUMMARY:Line1\\nLine2\\NLine3\\\\Not the 4th line!\r\nEND:VCALENDAR");
            var summary = result.__get("SUMMARY").Object;

            Assert.That(summary, Is.Not.Null);
            Assert.That(GetPropertyValue(summary!), Is.EqualTo("Line1\nLine2\nLine3\\Not the 4th line!"));
        }

        [Test]
        public void TestReadMappedProperty()
        {
            var result = ReadDocument("BEGIN:VCALENDAR\r\nDTSTART:20110529\r\nEND:VCALENDAR");
            var start = result.__get("DTSTART").Object;

            Assert.Multiple(() =>
            {
                Assert.That(start, Is.Not.Null);
                Assert.That(start!.GetType().FullName, Is.EqualTo("Sabre.VObject.Property.ICalendar.DateTime"));
                Assert.That(GetNodeName(start), Is.EqualTo("DTSTART"));
                Assert.That(GetPropertyValue(start), Is.EqualTo("20110529"));
            });
        }

        [Test]
        public void TestReadMissingEnd()
        {
            var result = ReadDocument("BEGIN:VCALENDAR\r\nPROPNAME:propValue");
            var children = GetChildren(result);
            var child = children[0].Object;

            Assert.Multiple(() =>
            {
                Assert.That(GetNodeName(result), Is.EqualTo("VCALENDAR"));
                Assert.That(children.Count, Is.EqualTo(1));
                Assert.That(child, Is.Not.Null);
                Assert.That(child!.GetType().FullName, Does.StartWith("Sabre.VObject.Property"));
                Assert.That(GetNodeName(child!), Is.EqualTo("PROPNAME"));
                Assert.That(GetPropertyValue(child!), Is.EqualTo("propValue"));
            });
        }

        [Test]
        public void TestReadNestedComponent()
        {
            var result = ReadDocument(
                "BEGIN:VCALENDAR\r\n" +
                "BEGIN:VTIMEZONE\r\n" +
                "BEGIN:DAYLIGHT\r\n" +
                "END:DAYLIGHT\r\n" +
                "END:VTIMEZONE\r\n" +
                "END:VCALENDAR");

            var rootChildren = GetChildren(result);
            var timezone = rootChildren[0].Object;
            var timezoneChildren = GetChildren(timezone);
            var daylight = timezoneChildren[0].Object;

            Assert.Multiple(() =>
            {
                Assert.That(rootChildren.Count, Is.EqualTo(1));
                Assert.That(timezone, Is.Not.Null);
                Assert.That(GetNodeName(timezone!), Is.EqualTo("VTIMEZONE"));
                Assert.That(timezoneChildren.Count, Is.EqualTo(1));
                Assert.That(daylight, Is.Not.Null);
                Assert.That(daylight!.GetType().FullName, Does.StartWith("Sabre.VObject.Component"));
                Assert.That(GetNodeName(daylight!), Is.EqualTo("DAYLIGHT"));
            });
        }

        [Test]
        public void TestReadPropertyParameter()
        {
            var result = ReadDocument("BEGIN:VCALENDAR\r\nPROPNAME;PARAMNAME=paramvalue:propValue\r\nEND:VCALENDAR");
            var property = result.__get("PROPNAME").Object;
            var parameters = GetParameters(property!);
            Assert.That(parameters, Is.Not.Null);
            var parameter = parameters!["PARAMNAME"].Object;

            Assert.Multiple(() =>
            {
                Assert.That(GetNodeName(property), Is.EqualTo("PROPNAME"));
                Assert.That(GetPropertyValue(property), Is.EqualTo("propValue"));
                Assert.That(parameters.Count, Is.EqualTo(1));
                Assert.That(GetNodeName(parameter!), Is.EqualTo("PARAMNAME"));
                Assert.That(GetPropertyValue(parameter!), Is.EqualTo("paramvalue"));
            });
        }
    }
}
