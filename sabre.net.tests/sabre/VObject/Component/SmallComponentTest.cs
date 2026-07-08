using NUnit.Framework;

namespace sabre.net.tests.sabre.VObject.Component
{
    /// <summary>
    /// 迁移自上游 sabre-io/vobject 4.5.6 的 tests/VObject/Component/ 下小型组件测试：
    /// VTimeZone、VJournal、VFreeBusy。
    /// VJournal::isInTimeRange 涉及日期比较，需 modify patch。
    /// 采用 PHP 脚本路径（SabrePhpRunner.RunInPeachpie）。
    /// </summary>
    public class SmallComponentTest
    {
        private static string RunPhp(string body, string tz = "UTC")
        {
            var php = "date_default_timezone_set('" + tz + "');" + "\n"
                    + "\\nextsharp_sabre_runtime_patch_bootstrap();" + "\n"
                    + body;
            return SabrePhpRunner.RunInPeachpie(php).Replace("\r\n", "\n").Trim();
        }

        // ===== VTimeZoneTest::testValidate: VTIMEZONE 合法时 validate 无 message =====
        [Test]
        public void testVTimeZoneValidate()
        {
            var ics = @"BEGIN:VCALENDAR
VERSION:2.0
PRODID:YoYo
BEGIN:VTIMEZONE
TZID:America/Toronto
END:VTIMEZONE
END:VCALENDAR";
            var body = "use Sabre\\VObject\\Reader;" + "\n"
                     + "$obj = Reader::read(<<<ICS\n" + ics + "\nICS\n);" + "\n"
                     + "$messages = [];" + "\n"
                     + "foreach ($obj->validate() as $w) { $messages[] = $w['message']; }" + "\n"
                     + "echo count($messages) === 0 ? 'EMPTY' : implode(\"\\n\", $messages);";
            Assert.That(RunPhp(body), Is.EqualTo("EMPTY"));
        }

        // ===== VTimeZoneTest::testGetTimeZone =====
        [Test]
        public void testVTimeZoneGetTimeZone()
        {
            var ics = @"BEGIN:VCALENDAR
VERSION:2.0
PRODID:YoYo
BEGIN:VTIMEZONE
TZID:America/Toronto
END:VTIMEZONE
END:VCALENDAR";
            // getTimeZone() 返回 DateTimeZone('America/Toronto')；比较用 ==（PeachPie tz-name 可能差异，== 比较偏移）
            var body = "use Sabre\\VObject\\Reader;" + "\n"
                     + "$obj = Reader::read(<<<ICS\n" + ics + "\nICS\n);" + "\n"
                     + "$tz = new \\DateTimeZone('America/Toronto');" + "\n"
                     + "$got = $obj->VTIMEZONE->getTimeZone();" + "\n"
                     + "echo $got == $tz ? 'EQUAL' : 'NOT_EQUAL';";
            Assert.That(RunPhp(body), Is.EqualTo("EQUAL"));
        }

        // ===== VJournalTest::testValidate =====
        [Test]
        public void testVJournalValidate()
        {
            var ics = @"BEGIN:VCALENDAR
VERSION:2.0
PRODID:YoYo
BEGIN:VJOURNAL
UID:12345678
DTSTAMP:20140402T174100Z
END:VJOURNAL
END:VCALENDAR";
            var body = "use Sabre\\VObject\\Reader;" + "\n"
                     + "$obj = Reader::read(<<<ICS\n" + ics + "\nICS\n);" + "\n"
                     + "$messages = [];" + "\n"
                     + "foreach ($obj->validate() as $w) { $messages[] = $w['message']; }" + "\n"
                     + "echo count($messages) === 0 ? 'EMPTY' : implode(\"\\n\", $messages);";
            Assert.That(RunPhp(body), Is.EqualTo("EMPTY"));
        }

        // ===== VJournalTest::testValidateBroken: 重复 URL 应报错 =====
        [Test]
        public void testVJournalValidateBroken()
        {
            var ics = @"BEGIN:VCALENDAR
VERSION:2.0
PRODID:YoYo
BEGIN:VJOURNAL
UID:12345678
DTSTAMP:20140402T174100Z
URL:http://example.org/
URL:http://example.com/
END:VJOURNAL
END:VCALENDAR";
            var body = "use Sabre\\VObject\\Reader;" + "\n"
                     + "$obj = Reader::read(<<<ICS\n" + ics + "\nICS\n);" + "\n"
                     + "$messages = [];" + "\n"
                     + "foreach ($obj->validate() as $w) { $messages[] = $w['message']; }" + "\n"
                     + "echo implode(\"\\n\", $messages);";
            Assert.That(RunPhp(body), Is.EqualTo("URL MUST NOT appear more than once in a VJOURNAL component"));
        }

        // ===== VJournalTest::testInTimeRange（DataProvider 6 组）=====
        // 用一个脚本跑全部 6 个断言，输出 PASS/FAIL 行
        [Test]
        public void testVJournalInTimeRange()
        {
            var body = "use Sabre\\VObject\\Component\\VCalendar;" + "\n"
                     + "$cal = new VCalendar();" + "\n"
                     + "$tz = new \\DateTimeZone('UTC');" + "\n"
                     + "$lines = [];" + "\n"
                     + "// case1: DTSTART=20111223T120000Z, range 2011-01-01~2012-01-01 => true" + "\n"
                     + "$j1 = $cal->createComponent('VJOURNAL');" + "\n"
                     + "$j1->DTSTART = '20111223T120000Z';" + "\n"
                     + "$lines[] = $j1->isInTimeRange(new \\DateTime('2011-01-01'), new \\DateTime('2012-01-01')) ? '1T' : '1F';" + "\n"
                     + "// case2: 同上 j1, range 2011-01-01~2011-11-01 => false" + "\n"
                     + "$lines[] = $j1->isInTimeRange(new \\DateTime('2011-01-01'), new \\DateTime('2011-11-01')) ? '2T' : '2F';" + "\n"
                     + "// case3: DATE 类型 DTSTART=20111223, range 2011-01-01~2012-01-01 => true" + "\n"
                     + "$j2 = $cal->createComponent('VJOURNAL');" + "\n"
                     + "$j2->DTSTART = '20111223';" + "\n"
                     + "$j2->DTSTART['VALUE'] = 'DATE';" + "\n"
                     + "$lines[] = $j2->isInTimeRange(new \\DateTime('2011-01-01'), new \\DateTime('2012-01-01')) ? '3T' : '3F';" + "\n"
                     + "// case4: 同 j2, range 2011-01-01~2011-11-01 => false" + "\n"
                     + "$lines[] = $j2->isInTimeRange(new \\DateTime('2011-01-01'), new \\DateTime('2011-11-01')) ? '4T' : '4F';" + "\n"
                     + "// case5: 无 DTSTART, range 2011-01-01~2012-01-01 => false" + "\n"
                     + "$j3 = $cal->createComponent('VJOURNAL');" + "\n"
                     + "$lines[] = $j3->isInTimeRange(new \\DateTime('2011-01-01'), new \\DateTime('2012-01-01')) ? '5T' : '5F';" + "\n"
                     + "// case6: 同 j3, range 2011-01-01~2011-11-01 => false" + "\n"
                     + "$lines[] = $j3->isInTimeRange(new \\DateTime('2011-01-01'), new \\DateTime('2011-11-01')) ? '6T' : '6F';" + "\n"
                     + "echo implode(\"\\n\", $lines);";
            // 期望：1T, 2F, 3T, 4F, 5F, 6F
            Assert.That(RunPhp(body), Is.EqualTo(@"1T
2F
3T
4F
5F
6F"));
        }

        // ===== VFreeBusyTest::testIsFree =====
        [Test]
        public void testVFreeBusyIsFree()
        {
            var ics = @"BEGIN:VCALENDAR
BEGIN:VFREEBUSY
FREEBUSY;FBTYPE=FREE:20120912T000500Z/PT1H
FREEBUSY;FBTYPE=BUSY:20120912T010000Z/20120912T020000Z
FREEBUSY;FBTYPE=BUSY-TENTATIVE:20120912T020000Z/20120912T030000Z
FREEBUSY;FBTYPE=BUSY-UNAVAILABLE:20120912T030000Z/20120912T040000Z
FREEBUSY;FBTYPE=BUSY:20120912T050000Z/20120912T060000Z,20120912T080000Z/20120912T090000Z
FREEBUSY;FBTYPE=BUSY:20120912T100000Z/PT1H
END:VFREEBUSY
END:VCALENDAR";
            var body = "use Sabre\\VObject;" + "\n"
                     + "$obj = VObject\\Reader::read(<<<ICS\n" + ics + "\nICS\n);" + "\n"
                     + "$vfb = $obj->VFREEBUSY;" + "\n"
                     + "$tz = new \\DateTimeZone('UTC');" + "\n"
                     + "$lines = [];" + "\n"
                     + "$lines[] = $vfb->isFree(new \\DateTime('2012-09-12 01:15:00', $tz), new \\DateTime('2012-09-12 01:45:00', $tz)) ? 'FREE1' : 'BUSY1';" + "\n"
                     + "$lines[] = $vfb->isFree(new \\DateTime('2012-09-12 08:05:00', $tz), new \\DateTime('2012-09-12 08:10:00', $tz)) ? 'FREE2' : 'BUSY2';" + "\n"
                     + "$lines[] = $vfb->isFree(new \\DateTime('2012-09-12 10:15:00', $tz), new \\DateTime('2012-09-12 10:45:00', $tz)) ? 'FREE3' : 'BUSY3';" + "\n"
                     + "// end time non-inclusive" + "\n"
                     + "$lines[] = $vfb->isFree(new \\DateTime('2012-09-12 09:00:00', $tz), new \\DateTime('2012-09-12 09:15:00', $tz)) ? 'FREE4' : 'BUSY4';" + "\n"
                     + "$lines[] = $vfb->isFree(new \\DateTime('2012-09-12 09:45:00', $tz), new \\DateTime('2012-09-12 10:00:00', $tz)) ? 'FREE5' : 'BUSY5';" + "\n"
                     + "$lines[] = $vfb->isFree(new \\DateTime('2012-09-12 11:00:00', $tz), new \\DateTime('2012-09-12 12:00:00', $tz)) ? 'FREE6' : 'BUSY6';" + "\n"
                     + "echo implode(\"\\n\", $lines);";
            // 前 3 个 isFree=false（忙），后 3 个 isFree=true（空）
            Assert.That(RunPhp(body), Is.EqualTo(@"BUSY1
BUSY2
BUSY3
FREE4
FREE5
FREE6"));
        }

        // ===== VFreeBusyTest::testValidate =====
        [Test]
        public void testVFreeBusyValidate()
        {
            var ics = @"BEGIN:VCALENDAR
VERSION:2.0
PRODID:YoYo
BEGIN:VFREEBUSY
UID:some-random-id
DTSTAMP:20140402T180200Z
END:VFREEBUSY
END:VCALENDAR";
            var body = "use Sabre\\VObject\\Reader;" + "\n"
                     + "$obj = Reader::read(<<<ICS\n" + ics + "\nICS\n);" + "\n"
                     + "$messages = [];" + "\n"
                     + "foreach ($obj->validate() as $w) { $messages[] = $w['message']; }" + "\n"
                     + "echo count($messages) === 0 ? 'EMPTY' : implode(\"\\n\", $messages);";
            Assert.That(RunPhp(body), Is.EqualTo("EMPTY"));
        }

        // ===== VTodoTest::testInTimeRange（16 组 DataProvider，一个脚本跑完）=====
        [Test]
        public void testVTodoInTimeRange()
        {
            var body = "use Sabre\\VObject\\Component\\VCalendar;" + "\n"
                     + "$cal = new VCalendar();" + "\n"
                     + "$lines = [];" + "\n"
                     + "$r1 = new \\DateTime('2011-01-01'); $r2 = new \\DateTime('2012-01-01'); $r3 = new \\DateTime('2011-11-01');" + "\n"
                     + "// t1: DTSTART=20111223T120000Z" + "\n"
                     + "$t1 = $cal->createComponent('VTODO'); $t1->DTSTART = '20111223T120000Z';" + "\n"
                     + "$lines[] = $t1->isInTimeRange($r1, $r2) ? '1T' : '1F';" + "\n"
                     + "$lines[] = $t1->isInTimeRange($r1, $r3) ? '2T' : '2F';" + "\n"
                     + "// t2: t1 + DURATION=P1D" + "\n"
                     + "$t2 = clone $t1; $t2->DURATION = 'P1D';" + "\n"
                     + "$lines[] = $t2->isInTimeRange($r1, $r2) ? '3T' : '3F';" + "\n"
                     + "$lines[] = $t2->isInTimeRange($r1, $r3) ? '4T' : '4F';" + "\n"
                     + "// t3: t1 + DUE=20111225" + "\n"
                     + "$t3 = clone $t1; $t3->DUE = '20111225';" + "\n"
                     + "$lines[] = $t3->isInTimeRange($r1, $r2) ? '5T' : '5F';" + "\n"
                     + "$lines[] = $t3->isInTimeRange($r1, $r3) ? '6T' : '6F';" + "\n"
                     + "// t4: 仅 DUE=20111225" + "\n"
                     + "$t4 = $cal->createComponent('VTODO'); $t4->DUE = '20111225';" + "\n"
                     + "$lines[] = $t4->isInTimeRange($r1, $r2) ? '7T' : '7F';" + "\n"
                     + "$lines[] = $t4->isInTimeRange($r1, $r3) ? '8T' : '8F';" + "\n"
                     + "// t5: 仅 COMPLETED=20111225" + "\n"
                     + "$t5 = $cal->createComponent('VTODO'); $t5->COMPLETED = '20111225';" + "\n"
                     + "$lines[] = $t5->isInTimeRange($r1, $r2) ? '9T' : '9F';" + "\n"
                     + "$lines[] = $t5->isInTimeRange($r1, $r3) ? '10T' : '10F';" + "\n"
                     + "// t6: 仅 CREATED=20111225" + "\n"
                     + "$t6 = $cal->createComponent('VTODO'); $t6->CREATED = '20111225';" + "\n"
                     + "$lines[] = $t6->isInTimeRange($r1, $r2) ? '11T' : '11F';" + "\n"
                     + "$lines[] = $t6->isInTimeRange($r1, $r3) ? '12T' : '12F';" + "\n"
                     + "// t7: CREATED+COMPLETED" + "\n"
                     + "$t7 = $cal->createComponent('VTODO'); $t7->CREATED = '20111225'; $t7->COMPLETED = '20111226';" + "\n"
                     + "$lines[] = $t7->isInTimeRange($r1, $r2) ? '13T' : '13F';" + "\n"
                     + "$lines[] = $t7->isInTimeRange($r1, $r3) ? '14T' : '14F';" + "\n"
                     + "// t8: 空白 VTODO" + "\n"
                     + "$t8 = $cal->createComponent('VTODO');" + "\n"
                     + "$lines[] = $t8->isInTimeRange($r1, $r2) ? '15T' : '15F';" + "\n"
                     + "$lines[] = $t8->isInTimeRange($r1, $r3) ? '16T' : '16F';" + "\n"
                     + "echo implode(\"\\n\", $lines);";
            // 期望：1T 2F 3T 4F 5T 6F 7T 8F 9T 10F 11T 12F 13T 14F 15T 16T
            Assert.That(RunPhp(body), Is.EqualTo(@"1T
2F
3T
4F
5T
6F
7T
8F
9T
10F
11T
12F
13T
14F
15T
16T"));
        }

        // ===== VTodoTest::testValidate =====
        [Test]
        public void testVTodoValidate()
        {
            var ics = @"BEGIN:VCALENDAR
VERSION:2.0
PRODID:YoYo
BEGIN:VTODO
UID:1234-21355-123156
DTSTAMP:20140402T183400Z
END:VTODO
END:VCALENDAR";
            var body = "use Sabre\\VObject\\Reader;" + "\n"
                     + "$obj = Reader::read(<<<ICS\n" + ics + "\nICS\n);" + "\n"
                     + "$messages = [];" + "\n"
                     + "foreach ($obj->validate() as $w) { $messages[] = $w['message']; }" + "\n"
                     + "echo count($messages) === 0 ? 'EMPTY' : implode(\"\\n\", $messages);";
            Assert.That(RunPhp(body), Is.EqualTo("EMPTY"));
        }

        [Test]
        public void testVTodoValidateInvalid()
        {
            // 空 VTODO，缺 UID 和 DTSTAMP
            var ics = @"BEGIN:VCALENDAR
VERSION:2.0
PRODID:YoYo
BEGIN:VTODO
END:VTODO
END:VCALENDAR";
            var body = "use Sabre\\VObject\\Reader;" + "\n"
                     + "$obj = Reader::read(<<<ICS\n" + ics + "\nICS\n);" + "\n"
                     + "$messages = [];" + "\n"
                     + "foreach ($obj->validate() as $w) { $messages[] = $w['message']; }" + "\n"
                     + "echo implode(\"\\n\", $messages);";
            Assert.That(RunPhp(body), Is.EqualTo(@"UID MUST appear exactly once in a VTODO component
DTSTAMP MUST appear exactly once in a VTODO component"));
        }

        [Test]
        public void testVTodoValidateDUEDTSTARTMisMatch()
        {
            var ics = @"BEGIN:VCALENDAR
VERSION:2.0
PRODID:YoYo
BEGIN:VTODO
UID:FOO
DTSTART;VALUE=DATE-TIME:20140520T131600Z
DUE;VALUE=DATE:20140520
DTSTAMP;VALUE=DATE-TIME:20140520T131600Z
END:VTODO
END:VCALENDAR";
            var body = "use Sabre\\VObject\\Reader;" + "\n"
                     + "$obj = Reader::read(<<<ICS\n" + ics + "\nICS\n);" + "\n"
                     + "$messages = [];" + "\n"
                     + "foreach ($obj->validate() as $w) { $messages[] = $w['message']; }" + "\n"
                     + "echo implode(\"\\n\", $messages);";
            Assert.That(RunPhp(body), Is.EqualTo("The value type (DATE or DATE-TIME) must be identical for DUE and DTSTART"));
        }

        [Test]
        public void testVTodoValidateDUEbeforeDTSTART()
        {
            var ics = @"BEGIN:VCALENDAR
VERSION:2.0
PRODID:YoYo
BEGIN:VTODO
UID:FOO
DTSTART;VALUE=DATE:20140520
DUE;VALUE=DATE:20140518
DTSTAMP;VALUE=DATE-TIME:20140520T131600Z
END:VTODO
END:VCALENDAR";
            var body = "use Sabre\\VObject\\Reader;" + "\n"
                     + "$obj = Reader::read(<<<ICS\n" + ics + "\nICS\n);" + "\n"
                     + "$messages = [];" + "\n"
                     + "foreach ($obj->validate() as $w) { $messages[] = $w['message']; }" + "\n"
                     + "echo implode(\"\\n\", $messages);";
            Assert.That(RunPhp(body), Is.EqualTo("DUE must occur after DTSTART"));
        }
    }
}
