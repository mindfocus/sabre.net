using Devsense.PHP.Syntax;
using NUnit.Framework;
using Pchp.Core;
using Pchp.Core.Utilities;
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
            var children = ((Sabre.VObject.Document)document.Object).children().Array;
            var availableType = typeof(Sabre.VObject.Document).Assembly.GetType("Sabre.VObject.Component.Available", throwOnError: true);
            object AvaObj = null;
            foreach(var o in children.Values)
            {
                if(o.Object.GetType() == availableType)
                {
                    AvaObj = o.Object;
                    break;
                }
            }

            Assert.That(AvaObj, Is.InstanceOf(availableType));
    }
    }
}
