using NUnit.Framework;

namespace sabre.net.tests.sabre.VObject.Recur
{
    /// <summary>
    /// 迁移自上游 sabre-io/vobject 4.5.6 的 tests/VObject/Recur/RDateIteratorTest.php。
    ///
    /// RDateIterator 处理 RDATE（固定日期列表）递归，比 RRuleIterator 简单——
    /// 没有 modify 相对日期推进，但仍走 DateTime 路径，故同样显式装配 modify patch 以保持一致。
    /// 采用 PHP 脚本路径（SabrePhpRunner.RunInPeachpie），逐字复刻官方断言。
    /// </summary>
    public class RDateIteratorTest
    {
        private static string RunRDate(string rdate, string start, string tz = "UTC", string fastForward = null)
        {
            var ffLine = string.IsNullOrEmpty(fastForward)
                ? string.Empty
                : "$it->fastForward(new \\DateTimeImmutable('" + fastForward + "'));";

            var php = "date_default_timezone_set('" + tz + "');" + "\n"
                    + "\\nextsharp_sabre_runtime_patch_bootstrap();" + "\n"
                    + "use Sabre\\VObject\\Recur\\RDateIterator;" + "\n"
                    + "$tzObj = new \\DateTimeZone('" + tz + "');" + "\n"
                    + "$it = new RDateIterator('" + rdate + "', new \\DateTimeImmutable('" + start + "', $tzObj));" + "\n"
                    + ffLine + "\n"
                    + "$result = [];" + "\n"
                    + "while ($it->valid()) {" + "\n"
                    + "  $result[] = $it->current()->format('Y-m-d H:i:s');" + "\n"
                    + "  $it->next();" + "\n"
                    + "}" + "\n"
                    + "echo implode(\"\\n\", $result) . \"\\n\" . ($it->isInfinite() ? 'INFINITE' : 'FINITE');";

            return SabrePhpRunner.RunInPeachpie(php).Replace("\r\n", "\n").Trim();
        }

        [Test]
        public void testSimple()
        {
            // start + 2 个 RDATE，共 3 个；非无限
            Assert.That(RunRDate("20140901T000000Z,20141001T000000Z", "2014-08-01 00:00:00"), Is.EqualTo(@"
2014-08-01 00:00:00
2014-09-01 00:00:00
2014-10-01 00:00:00
FINITE".TrimStart()));
        }

        [Test]
        public void testTimezone()
        {
            // Europe/Berlin 时区，RDATE 不带 Z（浮点时间按本地时区解析）
            Assert.That(RunRDate("20140901T000000,20141001T000000", "2014-08-01 00:00:00", "Europe/Berlin"), Is.EqualTo(@"
2014-08-01 00:00:00
2014-09-01 00:00:00
2014-10-01 00:00:00
FINITE".TrimStart()));
        }

        [Test]
        public void testFastForward()
        {
            // fastForward 到 2014-08-15，跳过 start，剩 2 个
            Assert.That(RunRDate("20140901T000000Z,20141001T000000Z", "2014-08-01 00:00:00", "UTC", "2014-08-15 00:00:00"), Is.EqualTo(@"
2014-09-01 00:00:00
2014-10-01 00:00:00
FINITE".TrimStart()));
        }
    }
}
