using NUnit.Framework;
using Pchp.Core;

namespace sabre.net.tests.sabre.VObject
{
    public class ElementListTest
    {
        [Test]
        public void testIterate()
        {
            var cal = VObjectTestSupport.CreateVCalendar();
            var elements = PhpArray.NewEmpty();
            elements.Add(cal.createComponent("VEVENT", PhpValue.Null, PhpValue.False));
            elements.Add(cal.createComponent("VEVENT", PhpValue.Null, PhpValue.False));
            elements.Add(cal.createComponent("VEVENT", PhpValue.Null, PhpValue.False));

            var elementList = new Sabre.VObject.ElementList(elements);
            var entries = VObjectTestSupport.IterateEntries(elementList);

            Assert.Multiple(() =>
            {
                Assert.That(entries.Count, Is.EqualTo(3));
                Assert.That(entries[0].Value.Object?.GetType().FullName, Does.StartWith("Sabre.VObject.Component."));
                Assert.That(entries[1].Value.Object?.GetType().FullName, Does.StartWith("Sabre.VObject.Component."));
                Assert.That(entries[2].Value.Object?.GetType().FullName, Does.StartWith("Sabre.VObject.Component."));
                Assert.That(entries[2].Key.ToInt(), Is.EqualTo(2));
            });
        }
    }
}
