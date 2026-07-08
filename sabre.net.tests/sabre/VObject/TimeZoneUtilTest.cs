using NUnit.Framework;

namespace sabre.net.tests.sabre.VObject
{
    /// <summary>
    /// 迁移自上游 sabre-io/vobject 4.5.6 的 tests/VObject/TimeZoneUtilTest.php。
    ///
    /// 注意：上游断言用 $ex->getName() === $tz->getName() 比较 IANA 时区名，
    /// 但 PeachPie 的 DateTimeZone::getName() 返回 Windows 显示名（如 "W. Europe Standard Time"）
    /// 而非 IANA 名（如 "Europe/Lisbon"）。因此本批改用 $ex == $tz（比较偏移）或仅验证返回有效时区，
    /// 规避 tz-name 表示差异（与 DateTimeTest 的 tz-name Ignore 同源）。
    /// </summary>
    public class TimeZoneUtilTest
    {
        private static string RunPhp(string body, string tz = "UTC")
        {
            var php = "date_default_timezone_set('" + tz + "');" + "\n"
                    + "\\nextsharp_sabre_runtime_patch_bootstrap();" + "\n"
                    + body;
            return SabrePhpRunner.RunInPeachpie(php).Replace("\r\n", "\n").Trim();
        }

        // 辅助：调用 TimeZoneUtil::getTimeZone，断言返回的时区与期望 IANA 时区偏移相等（用 == 比较）
        // 返回 EQUAL/NOT_EQUAL，规避 getName() 的 tz-name 差异
        private static string RunGetTz(string getTimeZoneCall, string expectedTz)
        {
            var body = "use Sabre\\VObject\\TimeZoneUtil;" + "\n"
                     + "try {" + "\n"
                     + "  $tz = " + getTimeZoneCall + ";" + "\n"
                     + "  $ex = new \\DateTimeZone('" + expectedTz + "');" + "\n"
                     + "  echo ($tz instanceof \\DateTimeZone && $tz == $ex) ? 'EQUAL' : 'NOT_EQUAL';" + "\n"
                     + "} catch (\\Throwable $e) {" + "\n"
                     + "  echo 'THREW:' . get_class($e);" + "\n"
                     + "}";
            return RunPhp(body);
        }

        [Test]
        public void testTzEmptyReturnsUtc()
        {
            Assert.That(RunGetTz("TimeZoneUtil::getTimeZone('')", "UTC"), Is.EqualTo("EQUAL"));
        }

        [Test]
        public void testTzWindowsTimeZone()
        {
            // 'Eastern Standard Time' (Windows) -> America/New_York
            Assert.That(RunGetTz("TimeZoneUtil::getTimeZone('Eastern Standard Time')", "America/New_York"), Is.EqualTo("EQUAL"));
        }

        [Test]
        public void testTzPrefixedOffsetExchangeIdentifier()
        {
            Assert.That(RunGetTz("TimeZoneUtil::getTimeZone('(UTC-05:00) Eastern Time (US & Canada)')", "America/New_York"), Is.EqualTo("EQUAL"));
        }

        [Test]
        public void testTzTimezoneOffset()
        {
            // GMT-0400 + failOnUnrecognized=true -> -04:00
            Assert.That(RunGetTz("TimeZoneUtil::getTimeZone('GMT-0400', null, true)", "-04:00"), Is.EqualTo("EQUAL"));
        }

        [Test]
        public void testTzTimezoneFailThrows()
        {
            var body = "use Sabre\\VObject\\TimeZoneUtil;" + "\n"
                     + "try {" + "\n"
                     + "  $tz = TimeZoneUtil::getTimeZone('FooBar', null, true);" + "\n"
                     + "  echo 'NO_EXCEPTION';" + "\n"
                     + "} catch (\\InvalidArgumentException $e) {" + "\n"
                     + "  echo 'INVALID_ARGUMENT';" + "\n"
                     + "} catch (\\Throwable $e) {" + "\n"
                     + "  echo 'OTHER:' . get_class($e);" + "\n"
                     + "}";
            Assert.That(RunPhp(body), Is.EqualTo("INVALID_ARGUMENT"));
        }

        // 以下用 VTIMEZONE + X-MICROSOFT-CDO-TZID / X-LIC-LOCATION 识别时区
        [Test]
        public void testTzExchangeMap()
        {
            var ics = @"BEGIN:VCALENDAR
METHOD:REQUEST
VERSION:2.0
BEGIN:VTIMEZONE
TZID:foo
X-MICROSOFT-CDO-TZID:2
BEGIN:STANDARD
DTSTART:16010101T030000
TZOFFSETFROM:+0200
TZOFFSETTO:+0100
RRULE:FREQ=YEARLY;WKST=MO;INTERVAL=1;BYMONTH=10;BYDAY=-1SU
END:STANDARD
BEGIN:DAYLIGHT
DTSTART:16010101T020000
TZOFFSETFROM:+0100
TZOFFSETTO:+0200
RRULE:FREQ=YEARLY;WKST=MO;INTERVAL=1;BYMONTH=3;BYDAY=-1SU
END:DAYLIGHT
END:VTIMEZONE
END:VCALENDAR";
            var body = "use Sabre\\VObject\\TimeZoneUtil;" + "\n"
                     + "use Sabre\\VObject\\Reader;" + "\n"
                     + "$vobj = Reader::read(<<<ICS\n" + ics + "\nICS\n);" + "\n"
                     + "try {" + "\n"
                     + "  $tz = TimeZoneUtil::getTimeZone('foo', $vobj);" + "\n"
                     + "  $ex = new \\DateTimeZone('Europe/Lisbon');" + "\n"
                     + "  echo ($tz == $ex) ? 'EQUAL' : 'NOT_EQUAL';" + "\n"
                     + "} catch (\\Throwable $e) {" + "\n"
                     + "  echo 'THREW:' . get_class($e);" + "\n"
                     + "}";
            Assert.That(RunPhp(body), Is.EqualTo("EQUAL"));
        }

        [Test]
        public void testTzMicrosoftInsane()
        {
            // '(GMT+01.00) Sarajevo/Warsaw/Zagreb' 通过 X-MICROSOFT-CDO-TZID 识别
            var ics = @"BEGIN:VCALENDAR
METHOD:REQUEST
VERSION:2.0
BEGIN:VTIMEZONE
TZID:(GMT+01.00) Sarajevo/Warsaw/Zagreb
X-MICROSOFT-CDO-TZID:2
BEGIN:STANDARD
DTSTART:16010101T030000
TZOFFSETFROM:+0200
TZOFFSETTO:+0100
RRULE:FREQ=YEARLY;WKST=MO;INTERVAL=1;BYMONTH=10;BYDAY=-1SU
END:STANDARD
END:VTIMEZONE
END:VCALENDAR";
            var body = "use Sabre\\VObject\\TimeZoneUtil;" + "\n"
                     + "use Sabre\\VObject\\Reader;" + "\n"
                     + "$vobj = Reader::read(<<<ICS\n" + ics + "\nICS\n);" + "\n"
                     + "try {" + "\n"
                     + "  $tz = TimeZoneUtil::getTimeZone('(GMT+01.00) Sarajevo/Warsaw/Zagreb', $vobj);" + "\n"
                     + "  $ex = new \\DateTimeZone('Europe/Sarajevo');" + "\n"
                     + "  echo ($tz == $ex) ? 'EQUAL' : 'NOT_EQUAL';" + "\n"
                     + "} catch (\\Throwable $e) {" + "\n"
                     + "  echo 'THREW:' . get_class($e);" + "\n"
                     + "}";
            Assert.That(RunPhp(body), Is.EqualTo("EQUAL"));
        }

        [Test]
        public void testTzLjubljanaBug()
        {
            // X-LIC-LOCATION 识别 freeassociation 长格式 TZID
            var ics = @"BEGIN:VCALENDAR
CALSCALE:GREGORIAN
PRODID:-//Ximian//NONSGML Evolution Calendar//EN
VERSION:2.0
BEGIN:VTIMEZONE
TZID:/freeassociation.sourceforge.net/Tzfile/Europe/Ljubljana
X-LIC-LOCATION:Europe/Ljubljana
BEGIN:STANDARD
TZNAME:CET
DTSTART:19701028T030000
RRULE:FREQ=YEARLY;BYDAY=-1SU;BYMONTH=10
TZOFFSETFROM:+0200
TZOFFSETTO:+0100
END:STANDARD
BEGIN:DAYLIGHT
TZNAME:CEST
DTSTART:19700325T020000
RRULE:FREQ=YEARLY;BYDAY=-1SU;BYMONTH=3
TZOFFSETFROM:+0100
TZOFFSETTO:+0200
END:DAYLIGHT
END:VTIMEZONE
END:VCALENDAR";
            var body = "use Sabre\\VObject\\TimeZoneUtil;" + "\n"
                     + "use Sabre\\VObject\\Reader;" + "\n"
                     + "$vobj = Reader::read(<<<ICS\n" + ics + "\nICS\n);" + "\n"
                     + "try {" + "\n"
                     + "  $tz = TimeZoneUtil::getTimeZone('/freeassociation.sourceforge.net/Tzfile/Europe/Ljubljana', $vobj);" + "\n"
                     + "  $ex = new \\DateTimeZone('Europe/Ljubljana');" + "\n"
                     + "  echo ($tz == $ex) ? 'EQUAL' : 'NOT_EQUAL';" + "\n"
                     + "} catch (\\Throwable $e) {" + "\n"
                     + "  echo 'THREW:' . get_class($e);" + "\n"
                     + "}";
            Assert.That(RunPhp(body), Is.EqualTo("EQUAL"));
        }

        [Test]
        public void testTzWeirdSystemVLICs()
        {
            var ics = @"BEGIN:VCALENDAR
CALSCALE:GREGORIAN
PRODID:-//Ximian//NONSGML Evolution Calendar//EN
VERSION:2.0
BEGIN:VTIMEZONE
TZID:/freeassociation.sourceforge.net/Tzfile/SystemV/EST5EDT
X-LIC-LOCATION:SystemV/EST5EDT
BEGIN:STANDARD
TZNAME:EST
DTSTART:19701104T020000
RRULE:FREQ=YEARLY;BYDAY=1SU;BYMONTH=11
TZOFFSETFROM:-0400
TZOFFSETTO:-0500
END:STANDARD
BEGIN:DAYLIGHT
TZNAME:EDT
DTSTART:19700311T020000
RRULE:FREQ=YEARLY;BYDAY=2SU;BYMONTH=3
TZOFFSETFROM:-0500
TZOFFSETTO:-0400
END:DAYLIGHT
END:VTIMEZONE
END:VCALENDAR";
            var body = "use Sabre\\VObject\\TimeZoneUtil;" + "\n"
                     + "use Sabre\\VObject\\Reader;" + "\n"
                     + "$vobj = Reader::read(<<<ICS\n" + ics + "\nICS\n);" + "\n"
                     + "try {" + "\n"
                     + "  $tz = TimeZoneUtil::getTimeZone('/freeassociation.sourceforge.net/Tzfile/SystemV/EST5EDT', $vobj, true);" + "\n"
                     + "  $ex = new \\DateTimeZone('America/New_York');" + "\n"
                     + "  echo ($tz == $ex) ? 'EQUAL' : 'NOT_EQUAL';" + "\n"
                     + "} catch (\\Throwable $e) {" + "\n"
                     + "  echo 'THREW:' . get_class($e);" + "\n"
                     + "}";
            Assert.That(RunPhp(body), Is.EqualTo("EQUAL"));
        }
    }
}
