using NUnit.Framework;

namespace sabre.net.tests.sabre.VObject
{
    public class GoogleColonEscapingTest
    {
        [Test]
        public void testDecode()
        {
            const string vcard =
                "BEGIN:VCARD\n" +
                "VERSION:3.0\n" +
                "FN:Evert Pot\n" +
                "N:Pot;Evert;;;\n" +
                "EMAIL;TYPE=INTERNET;TYPE=WORK:evert@fruux.com\n" +
                "BDAY:1985-04-07\n" +
                "item7.URL:http\\://www.rooftopsolutions.nl/\n" +
                "END:VCARD";

            var vobj = VObjectTestSupport.ReadDocument(vcard);
            var url = VObjectTestSupport.GetNamedObject(vobj, "URL");

            Assert.That(VObjectTestSupport.GetPropertyValue(url), Is.EqualTo("http://www.rooftopsolutions.nl/"));
        }
    }
}
