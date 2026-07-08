using NUnit.Framework;

namespace sabre.net.tests.sabre
{
    public class DateTimeModifyBehaviorTest
    {
        [Test]
        public void testPeachPieModifyBugExistsWithoutSabreBootstrap()
        {
            var phpCode = @"
date_default_timezone_set('UTC');
$dt = new \DateTime('2011-12-25 00:00:00', new \DateTimeZone('UTC'));
echo $dt->modify('+1 day')->format('Y-m-d H:i:sP') . ""\n"";
";

            var nativeOutput = SabrePhpRunner.RunInNativePhp(phpCode).Trim();
            var peachpieOutput = SabrePhpRunner.RunInPeachpie(phpCode).Trim();

            Assert.That(nativeOutput, Is.EqualTo("2011-12-26 00:00:00+00:00"));
            Assert.That(peachpieOutput, Is.Not.EqualTo(nativeOutput));
        }
    }
}
