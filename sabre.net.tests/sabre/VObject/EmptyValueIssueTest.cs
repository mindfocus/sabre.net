using NUnit.Framework;

namespace sabre.net.tests.sabre.VObject
{
    public class EmptyValueIssueTest
    {
        [Test]
        public void testDecodeValue()
        {
            const string input =
                "BEGIN:VCALENDAR\n" +
                "VERSION:2.0\n" +
                "BEGIN:VEVENT\n" +
                "DESCRIPTION:This is a description\\nwith a linebreak and a \\; \\, and :\n" +
                "END:VEVENT\n" +
                "END:VCALENDAR";

            var vobj = VObjectTestSupport.ReadDocument(input);
            var vevent = VObjectTestSupport.GetNamedObject(vobj, "VEVENT");
            var description = VObjectTestSupport.GetNamedObject(vevent, "DESCRIPTION");

            Assert.That(
                VObjectTestSupport.GetPropertyValue(description),
                Is.EqualTo("This is a description\nwith a linebreak and a ; , and :"));
        }
    }
}
