using NUnit.Framework;
using Pchp.Core;
using Pchp.Core.Utilities;

namespace sabre.net.tests.sabre.DAV
{
    public class UUIDUtilTest
    {
        [Test]
        public void TestValidateUuid()
        {
            Assert.Multiple(() =>
            {
                Assert.That(
                    Sabre.DAV.UUIDUtil.validateUUID(ContextExtensions.CurrentContext, "11111111-2222-3333-4444-555555555555"),
                    Is.True);
                Assert.That(
                    Sabre.DAV.UUIDUtil.validateUUID(ContextExtensions.CurrentContext, " 11111111-2222-3333-4444-555555555555"),
                    Is.False);
                Assert.That(
                    Sabre.DAV.UUIDUtil.validateUUID(ContextExtensions.CurrentContext, "ffffffff-2222-3333-4444-555555555555"),
                    Is.True);
                Assert.That(
                    Sabre.DAV.UUIDUtil.validateUUID(ContextExtensions.CurrentContext, "fffffffg-2222-3333-4444-555555555555"),
                    Is.False);
            });
        }
    }
}
