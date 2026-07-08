using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Pchp.Core;
using Pchp.Core.Utilities;

namespace sabre.net.tests.sabre.DAV
{
    public class StringUtilTest
    {
        private static IEnumerable<object[]> Dataset()
        {
            yield return new object[] { "FOOBAR", "FOO", "i;octet", "contains", true };
            yield return new object[] { "FOOBAR", "foo", "i;octet", "contains", false };
            yield return new object[] { "FÖÖBAR", "FÖÖ", "i;octet", "contains", true };
            yield return new object[] { "FÖÖBAR", "föö", "i;octet", "contains", false };
            yield return new object[] { "FOOBAR", "FOOBAR", "i;octet", "equals", true };
            yield return new object[] { "FOOBAR", "fooBAR", "i;octet", "equals", false };
            yield return new object[] { "FOOBAR", "FOO", "i;octet", "starts-with", true };
            yield return new object[] { "FOOBAR", "foo", "i;octet", "starts-with", false };
            yield return new object[] { "FOOBAR", "BAR", "i;octet", "starts-with", false };
            yield return new object[] { "FOOBAR", "bar", "i;octet", "starts-with", false };
            yield return new object[] { "FOOBAR", "FOO", "i;octet", "ends-with", false };
            yield return new object[] { "FOOBAR", "foo", "i;octet", "ends-with", false };
            yield return new object[] { "FOOBAR", "BAR", "i;octet", "ends-with", true };
            yield return new object[] { "FOOBAR", "bar", "i;octet", "ends-with", false };
            yield return new object[] { "FOOBAR", "FOO", "i;ascii-casemap", "contains", true };
            yield return new object[] { "FOOBAR", "foo", "i;ascii-casemap", "contains", true };
            yield return new object[] { "FÖÖBAR", "FÖÖ", "i;ascii-casemap", "contains", true };
            yield return new object[] { "FÖÖBAR", "föö", "i;ascii-casemap", "contains", false };
            yield return new object[] { "FOOBAR", "FOOBAR", "i;ascii-casemap", "equals", true };
            yield return new object[] { "FOOBAR", "fooBAR", "i;ascii-casemap", "equals", true };
            yield return new object[] { "FOOBAR", "FOO", "i;ascii-casemap", "starts-with", true };
            yield return new object[] { "FOOBAR", "foo", "i;ascii-casemap", "starts-with", true };
            yield return new object[] { "FOOBAR", "BAR", "i;ascii-casemap", "starts-with", false };
            yield return new object[] { "FOOBAR", "bar", "i;ascii-casemap", "starts-with", false };
            yield return new object[] { "FOOBAR", "FOO", "i;ascii-casemap", "ends-with", false };
            yield return new object[] { "FOOBAR", "foo", "i;ascii-casemap", "ends-with", false };
            yield return new object[] { "FOOBAR", "BAR", "i;ascii-casemap", "ends-with", true };
            yield return new object[] { "FOOBAR", "bar", "i;ascii-casemap", "ends-with", true };
            yield return new object[] { "FOOBAR", "FOO", "i;unicode-casemap", "contains", true };
            yield return new object[] { "FOOBAR", "foo", "i;unicode-casemap", "contains", true };
            yield return new object[] { "FÖÖBAR", "FÖÖ", "i;unicode-casemap", "contains", true };
            yield return new object[] { "FÖÖBAR", "föö", "i;unicode-casemap", "contains", true };
            yield return new object[] { "FOOBAR", "FOOBAR", "i;unicode-casemap", "equals", true };
            yield return new object[] { "FOOBAR", "fooBAR", "i;unicode-casemap", "equals", true };
            yield return new object[] { "FOOBAR", "FOO", "i;unicode-casemap", "starts-with", true };
            yield return new object[] { "FOOBAR", "foo", "i;unicode-casemap", "starts-with", true };
            yield return new object[] { "FOOBAR", "BAR", "i;unicode-casemap", "starts-with", false };
            yield return new object[] { "FOOBAR", "bar", "i;unicode-casemap", "starts-with", false };
            yield return new object[] { "FOOBAR", "FOO", "i;unicode-casemap", "ends-with", false };
            yield return new object[] { "FOOBAR", "foo", "i;unicode-casemap", "ends-with", false };
            yield return new object[] { "FOOBAR", "BAR", "i;unicode-casemap", "ends-with", true };
            yield return new object[] { "FOOBAR", "bar", "i;unicode-casemap", "ends-with", true };
        }

        [TestCaseSource(nameof(Dataset))]
        public void TestTextMatch(string haystack, string needle, string collation, string matchType, bool result)
        {
            Assert.That(
                Sabre.DAV.StringUtil.textMatch(ContextExtensions.CurrentContext, haystack, needle, collation, matchType),
                Is.EqualTo(result));
        }

        [Test]
        public void TestBadCollation()
        {
            var badRequestType = typeof(Sabre.DAV.StringUtil).Assembly.GetType("Sabre.DAV.Exception.BadRequest", throwOnError: true);
            Assert.Throws(badRequestType, () =>
                Sabre.DAV.StringUtil.textMatch(ContextExtensions.CurrentContext, "foobar", "foo", "blabla", "contains"));
        }

        [Test]
        public void TestBadMatchType()
        {
            var badRequestType = typeof(Sabre.DAV.StringUtil).Assembly.GetType("Sabre.DAV.Exception.BadRequest", throwOnError: true);
            Assert.Throws(badRequestType, () =>
                Sabre.DAV.StringUtil.textMatch(ContextExtensions.CurrentContext, "foobar", "foo", "i;octet", "booh"));
        }

        [Test]
        public void TestEnsureUtf8Ascii()
        {
            Assert.That(
                Sabre.DAV.StringUtil.ensureUTF8(ContextExtensions.CurrentContext, "harkema").ToString(),
                Is.EqualTo("harkema"));
        }

        [Test]
        public void TestEnsureUtf8Latin1()
        {
            var input = Encoding.Latin1.GetString(new byte[] { 0x6d, 0xfc, 0x6e, 0x73, 0x74, 0x65, 0x72 });
            Assert.That(
                Sabre.DAV.StringUtil.ensureUTF8(ContextExtensions.CurrentContext, input).ToString(),
                Is.EqualTo("münster"));
        }

        [Test]
        public void TestEnsureUtf8Utf8()
        {
            var input = Encoding.UTF8.GetString(new byte[] { 0x6d, 0xc3, 0xbc, 0x6e, 0x73, 0x74, 0x65, 0x72 });
            Assert.That(
                Sabre.DAV.StringUtil.ensureUTF8(ContextExtensions.CurrentContext, input).ToString(),
                Is.EqualTo("münster"));
        }
    }
}
