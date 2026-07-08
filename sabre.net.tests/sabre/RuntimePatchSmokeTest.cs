using NUnit.Framework;

namespace sabre.net.tests.sabre
{
    public class RuntimePatchSmokeTest
    {
        [Test]
        public void testDateTimeModifyPatchWorksWhenBootstrapIsCalledExplicitly()
        {
            var phpCode = @"
date_default_timezone_set('UTC');
\nextsharp_sabre_runtime_patch_bootstrap();
$dt = new \DateTime('2011-12-25 00:00:00', new \DateTimeZone('UTC'));
echo $dt->modify('+1 day')->format('Y-m-d H:i:sP') . ""\n"";
";

            var peachpieOutput = SabrePhpRunner.RunInPeachpie(phpCode).Trim();

            Assert.That(peachpieOutput, Is.EqualTo("2011-12-26 00:00:00+00:00"));
        }
    }
}
