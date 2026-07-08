using System.Reflection;
using NUnit.Framework;
using Pchp.Core;

namespace sabre.net.tests.sabre.VObject
{
    public class DocumentTest
    {
        private static Sabre.VObject.Document CreateVCalendar()
        {
            var type = typeof(Sabre.VObject.Document).Assembly.GetType("Sabre.VObject.Component.VCalendar", true);
            return (Sabre.VObject.Document)System.Activator.CreateInstance(type, new object[] { new PhpValue[] { PhpArray.NewEmpty(), PhpValue.False } });
        }

        private static PhpValue InvokeAdd(object component, PhpValue node)
        {
            var method = component.GetType().GetMethod("add");
            Assert.That(method, Is.Not.Null);
            return (PhpValue)method.Invoke(component, new object[] { new[] { node } });
        }

        private static string GetName(object node)
        {
            var field = node.GetType().GetField("name") ?? node.GetType().BaseType?.GetField("name");
            Assert.That(field, Is.Not.Null);
            return ((PhpValue)field.GetValue(node)).ToString();
        }

        private static object GetParent(object node)
        {
            var field = node.GetType().GetField("parent") ?? node.GetType().BaseType?.GetField("parent");
            Assert.That(field, Is.Not.Null);
            return ((PhpValue)field.GetValue(node)).Object;
        }

        private static void UnsetNodeProperty(object node, string name)
        {
            var method = node.GetType().GetMethod("offsetUnset");
            Assert.That(method, Is.Not.Null);
            method.Invoke(node, new object[] { (PhpValue)name });
        }

        private static PhpArray CreateParameters(string name, string value)
        {
            var parameters = PhpArray.NewEmpty();
            parameters.Add(name, value);
            return parameters;
        }

        [Test]
        public void TestCreateComponent()
        {
            var vcal = CreateVCalendar();
            var @event = vcal.createComponent("VEVENT", PhpValue.Null, PhpValue.False).Object;

            Assert.That(@event, Is.Not.Null);
            Assert.That(@event.GetType().FullName, Is.EqualTo("Sabre.VObject.Component.VEvent"));

            vcal.add(PhpValue.FromClass(@event));
            var prop = vcal.createProperty("X-PROP", "1234256", CreateParameters("X-PARAM", "3"));
            InvokeAdd(@event, PhpValue.FromClass(prop));

            var output = vcal.serialize().ToString();
            Assert.That(output, Is.EqualTo("BEGIN:VCALENDAR\r\nBEGIN:VEVENT\r\nX-PROP;X-PARAM=3:1234256\r\nEND:VEVENT\r\nEND:VCALENDAR\r\n"));
        }

        [Test]
        public void TestCreate()
        {
            var vcal = CreateVCalendar();
            var @event = vcal.create("VEVENT").Object;
            var prop = vcal.create("CALSCALE").Object;
            var textType = typeof(Sabre.VObject.Document).Assembly.GetType("Sabre.VObject.Property.Text", true);

            Assert.Multiple(() =>
            {
                Assert.That(@event, Is.Not.Null);
                Assert.That(@event.GetType().FullName, Is.EqualTo("Sabre.VObject.Component.VEvent"));
                Assert.That(prop, Is.Not.Null);
                Assert.That(textType.IsAssignableFrom(prop.GetType()), Is.True);
            });
        }

        [Test]
        public void TestGetClassNameForPropertyValue()
        {
            var vcal = CreateVCalendar();

            Assert.Multiple(() =>
            {
                Assert.That(vcal.getClassNameForPropertyValue("TEXT").ToString(), Is.EqualTo("Sabre\\VObject\\Property\\Text"));
                Assert.That(vcal.getClassNameForPropertyValue("FOO").IsNull, Is.True);
            });
        }

        [Test]
        public void TestDestroy()
        {
            var vcal = CreateVCalendar();
            var @event = vcal.createComponent("VEVENT", PhpValue.Null, PhpValue.False).Object;
            vcal.add(PhpValue.FromClass(@event));
            var prop = vcal.createProperty("X-PROP", "1234256", CreateParameters("X-PARAM", "3"));
            InvokeAdd(@event, PhpValue.FromClass(prop));

            Assert.That(GetParent(prop), Is.SameAs(@event));
            vcal.destroy();
            Assert.That(GetParent(prop), Is.Null);
        }
    }
}
