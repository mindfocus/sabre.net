using NUnit.Framework;

namespace sabre.net.tests.sabre.VObject
{
    public class AttachIssueTest
    {
        [Test]
        public void testRead()
        {
            const string eventData =
                "BEGIN:VCALENDAR\r\n" +
                "BEGIN:VEVENT\r\n" +
                "ATTACH;FMTTYPE=;ENCODING=:Zm9v\r\n" +
                "END:VEVENT\r\n" +
                "END:VCALENDAR\r\n";

            var obj = VObjectTestSupport.ReadDocument(eventData);

            Assert.That(obj.serialize().ToString(), Is.EqualTo(eventData));
        }
    }
}
