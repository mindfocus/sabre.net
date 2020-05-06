using Devsense.PHP.Syntax;
using NUnit.Framework;
using Pchp.Core;
using Pchp.Core.Utilities;
using Sabre.VObject.ComponentNs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sabre.net.tests.sabre.VObject.Component
{
    class AvailableTest
    {
        
        [Test]
    public void testAvailableComponent()
    {
        var vcal = Environment.NewLine
                    + "BEGIN:VCALENDAR" + Environment.NewLine
                    + "BEGIN:AVAILABLE" + Environment.NewLine
                    + "END:AVAILABLE" + Environment.NewLine
                    + "END:VCALENDAR" + Environment.NewLine;
            var document = Sabre.VObject.Reader.read(ContextExtensions.CurrentContext, vcal);
            var children = ((VCalendar)document.Object).children().Array;
            Available AvaObj = null;
            foreach(var o in children.Values)
            {
                if(o.Object.GetType() == typeof(Available))
                {
                    AvaObj = (Available)o.Object;
                    break;
                }
            }

            Assert.IsInstanceOf(typeof(Available), AvaObj);
    }
    }
}
