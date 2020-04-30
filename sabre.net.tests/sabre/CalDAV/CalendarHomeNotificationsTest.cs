using Moq;
using NUnit.Framework;
using Pchp.Core;
using Sabre.CalDAV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sabre.net.tests.sabre.CalDAV
{
    class CalendarHomeNotificationsTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void testGetChildrenNoSupport()
        {
            var backend = new Mock<Sabre.CalDAV.Backend.BackendInterface>();
            PhpArray p = new PhpArray();
            p.Add("uri", "principals/user");
            var calendarHome = new CalendarHome(backend.Object, p);
            var children = calendarHome.getChildren();
            Assert.IsTrue(children.Array.Count == 0);
        }
        [Test]
        [ExpectedException( typeof( Sabre.DAV.ExceptionNs.NotFound ) )]
        public void testGetChildNoSupport()
        {
        //    $this->expectException('Sabre\DAV\Exception\NotFound');
        //$backend = new Backend\Mock();
        //$calendarHome = new CalendarHome($backend, ['uri' => 'principals/user']);
        //$calendarHome->getChild('notifications');
            var backend = new Mock<Sabre.CalDAV.Backend.BackendInterface>();
            PhpArray p = new PhpArray();
            p.Add("uri", "principals/user");
            var calendarHome = new CalendarHome(backend.Object, p);
            calendarHome.getChild("notifications");
        }
        [Test]
        public void testGetChildren()
        {
        }
    }
}
