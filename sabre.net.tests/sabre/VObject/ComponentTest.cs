using NUnit.Framework;
using Pchp.Core;
using System;

namespace sabre.net.tests.sabre.VObject
{
    class ComponentTest
    {
        private static string GetNodeName(object node)
        {
            var field = node.GetType().BaseType?.GetField("name");
            if (field == null)
            {
                field = node.GetType().GetField("name");
            }

            Assert.That(field, Is.Not.Null);
            return ((PhpValue)field!.GetValue(node)!).ToString();
        }

        private static Sabre.VObject.Document CreateVCalendar(bool defaults = false)
        {
            var vCalendarType = typeof(Sabre.VObject.Document).Assembly.GetType("Sabre.VObject.Component.VCalendar", throwOnError: true);
            return (Sabre.VObject.Document)Activator.CreateInstance(
                vCalendarType!,
                new object[] { new PhpValue[] { PhpArray.NewEmpty(), PhpValue.Create(defaults) } })!;
        }

        [Test]
        public void testIterate()
        {
            var comp = CreateVCalendar(false);
            var sub = comp.createComponent("VEVENT");
            comp.add(sub);
            var sub1 = comp.createComponent("VTODO");
            comp.add(sub1);

            var count = 0;
            foreach (var compChild in comp.children())
            {
                count++;
                Assert.IsInstanceOf<Sabre.VObject.Node>(compChild.Value.Object);
                if (2 == count)
                {
                    Assert.AreEqual(1, compChild.Key.ToInt());
                }
            }
            Assert.AreEqual(2, count);
        }

        [Test]
        public void testMagicGet()
        {
            var comp = CreateVCalendar(false);
            comp.add(comp.createComponent("VEVENT"));
            comp.add(comp.createComponent("VTODO"));

            var eventValue = comp.__get("VEVENT");

            Assert.Multiple(() =>
            {
                Assert.That(eventValue.IsNull, Is.False);
                Assert.That(eventValue.Object, Is.Not.Null);
                Assert.That(GetNodeName(eventValue.Object!), Is.EqualTo("VEVENT"));
                Assert.That(comp.__get("VJOURNAL").IsNull, Is.True);
            });
        }

        [Test]
        public void testMagicIsset()
        {
            var comp = CreateVCalendar(false);
            comp.add(comp.createComponent("VEVENT"));
            comp.add(comp.createComponent("VTODO"));

            Assert.Multiple(() =>
            {
                Assert.That(comp.__isset("vevent").ToBoolean(), Is.True);
                Assert.That(comp.__isset("vtodo").ToBoolean(), Is.True);
                Assert.That(comp.__isset("vjournal").ToBoolean(), Is.False);
            });
        }
    }
}
