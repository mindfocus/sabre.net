using NUnit.Framework;
using Pchp.Core;
using Sabre.VObject.ComponentNs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sabre.net.tests.sabre.VObject
{
    class ComponentTest
    {
        [Test]
        public void testIterate()
        {
            var comp = new VCalendar(PhpArray.Empty, false);
            var sub = comp.createComponent("VEVENT");
            comp.add(sub);
            var sub1 = comp.createComponent("VTODO");
            comp.add(sub1);
            
            var count = 0;
            foreach (var compChild in comp.children())
            {
                count++;
                Assert.IsInstanceOf<Sabre.VObject.Component>(compChild.Value.Object);
                if (2 == count)
                {
                    Assert.AreEqual(1, compChild.Key.ToInt());
                }
            }
            Assert.AreEqual(2, count);
        }
    }
}
