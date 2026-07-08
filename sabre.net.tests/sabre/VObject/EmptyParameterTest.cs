using System;
using System.Text;
using NUnit.Framework;
using Pchp.Core;

namespace sabre.net.tests.sabre.VObject
{
    public class EmptyParameterTest
    {
        [Test]
        public void testRead()
        {
            const string input =
                "BEGIN:VCARD\n" +
                "VERSION:2.1\n" +
                "N:Doe;Jon;;;\n" +
                "FN:Jon Doe\n" +
                "EMAIL;X-INTERN:foo@example.org\n" +
                "UID:foo\n" +
                "END:VCARD";

            var vcard = VObjectTestSupport.ReadDocument(input);

            Assert.That(vcard.GetType().FullName, Is.EqualTo("Sabre.VObject.Component.VCard"));

            var convert = vcard.GetType().GetMethod("convert");
            Assert.That(convert, Is.Not.Null);
            var converted = (Sabre.VObject.Document)((PhpValue)convert!.Invoke(vcard, new object[] { (PhpValue)Sabre.VObject.Document.VCARD30 })!).Object!;

            Assert.DoesNotThrow(() => converted.validate());

            var email = VObjectTestSupport.GetNamedObject(converted, "EMAIL");
            var parameters = VObjectTestSupport.GetParameters(email);
            var expected =
                "BEGIN:VCARD\n" +
                "VERSION:3.0\n" +
                $"PRODID:-//Sabre//Sabre VObject {Sabre.VObject.Version.VERSION}//EN\n" +
                "N:Doe;Jon;;;\n" +
                "FN:Jon Doe\n" +
                "EMAIL;X-INTERN=:foo@example.org\n" +
                "UID:foo\n" +
                "END:VCARD\n";

            Assert.Multiple(() =>
            {
                Assert.That(parameters.ContainsKey("X-INTERN"), Is.True);
                Assert.That(converted.serialize().ToString().Replace("\r", string.Empty), Is.EqualTo(expected));
            });
        }

        [Test]
        public void testVCard21Parameter()
        {
            var vcard = VObjectTestSupport.CreateVCard(false);
            VObjectTestSupport.InvokeAdd(vcard, "VERSION", "2.1");
            var photo = VObjectTestSupport.InvokeAdd(vcard, "PHOTO", "random_stuff").Object;
            VObjectTestSupport.AddParameter(photo!, PhpValue.Null, "BASE64");
            VObjectTestSupport.InvokeAdd(vcard, "UID", "foo-bar");

            var result = vcard.serialize().ToString();
            var expected = string.Join(
                "\r\n",
                new[]
                {
                    "BEGIN:VCARD",
                    "VERSION:2.1",
                    "PHOTO;BASE64:" + System.Convert.ToBase64String(Encoding.UTF8.GetBytes("random_stuff")),
                    "UID:foo-bar",
                    "END:VCARD",
                    string.Empty,
                });

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
