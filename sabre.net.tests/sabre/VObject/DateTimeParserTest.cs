using System;
using System.Collections.Generic;
using NUnit.Framework;
using Pchp.Core;
using Pchp.Core.Utilities;
using Pchp.Library.DateTime;

namespace sabre.net.tests.sabre.VObject
{
    public class DateTimeParserTest
    {
        private static void AssertDateTime(DateTimeImmutable actual, string expectedValue, string expectedTimeZone)
        {
            var actualTimeZone = actual.getTimezone().getName();
            Assert.Multiple(() =>
            {
                Assert.That(actual.format("Y-m-d H:i:s"), Is.EqualTo(expectedValue));
                Assert.That(
                    actualTimeZone == expectedTimeZone ||
                    (expectedTimeZone == "Europe/Amsterdam" && actualTimeZone == "W. Europe Standard Time"),
                    Is.True);
            });
        }

        private static void AssertDateInterval(DateInterval actual, string expectedSpec, int expectedInvert = 0)
        {
            var expected = new DateInterval(expectedSpec);
            expected.invert = expectedInvert;

            Assert.Multiple(() =>
            {
                Assert.That(actual.y, Is.EqualTo(expected.y));
                Assert.That(actual.m, Is.EqualTo(expected.m));
                Assert.That(actual.d, Is.EqualTo(expected.d));
                Assert.That(actual.h, Is.EqualTo(expected.h));
                Assert.That(actual.i, Is.EqualTo(expected.i));
                Assert.That(actual.s, Is.EqualTo(expected.s));
                Assert.That(actual.invert, Is.EqualTo(expected.invert));
            });
        }

        private static void AssertParts(PhpArray actual, Dictionary<string, string> expected)
        {
            Assert.Multiple(() =>
            {
                foreach (var item in expected)
                {
                    var value = actual[item.Key];
                    if (item.Value == null)
                    {
                        Assert.That(value.IsNull, Is.True, item.Key);
                    }
                    else
                    {
                        Assert.That(value.ToString(), Is.EqualTo(item.Value), item.Key);
                    }
                }
            });
        }

        private static IEnumerable<TestCaseData> VCardDateCases()
        {
            yield return new TestCaseData(
                "19961022T140000",
                new Dictionary<string, string>
                {
                    ["year"] = "1996",
                    ["month"] = "10",
                    ["date"] = "22",
                    ["hour"] = "14",
                    ["minute"] = "00",
                    ["second"] = "00",
                    ["timezone"] = null,
                });

            yield return new TestCaseData(
                "--1022T1400",
                new Dictionary<string, string>
                {
                    ["year"] = null,
                    ["month"] = "10",
                    ["date"] = "22",
                    ["hour"] = "14",
                    ["minute"] = "00",
                    ["second"] = null,
                    ["timezone"] = null,
                });

            yield return new TestCaseData(
                "---22T14",
                new Dictionary<string, string>
                {
                    ["year"] = null,
                    ["month"] = null,
                    ["date"] = "22",
                    ["hour"] = "14",
                    ["minute"] = null,
                    ["second"] = null,
                    ["timezone"] = null,
                });

            yield return new TestCaseData(
                "1985-04",
                new Dictionary<string, string>
                {
                    ["year"] = "1985",
                    ["month"] = "04",
                    ["date"] = null,
                    ["hour"] = null,
                    ["minute"] = null,
                    ["second"] = null,
                    ["timezone"] = null,
                });
        }

        [Test]
        public void TestParseICalendarDuration()
        {
            Assert.Multiple(() =>
            {
                Assert.That(Sabre.VObject.DateTimeParser.parseDuration(ContextExtensions.CurrentContext, "P1W", true).ToString(), Is.EqualTo("+1 weeks"));
                Assert.That(Sabre.VObject.DateTimeParser.parseDuration(ContextExtensions.CurrentContext, "P5D", true).ToString(), Is.EqualTo("+5 days"));
                Assert.That(Sabre.VObject.DateTimeParser.parseDuration(ContextExtensions.CurrentContext, "P5DT3H50M12S", true).ToString(), Is.EqualTo("+5 days 3 hours 50 minutes 12 seconds"));
                Assert.That(Sabre.VObject.DateTimeParser.parseDuration(ContextExtensions.CurrentContext, "-P1WT50M", true).ToString(), Is.EqualTo("-1 weeks 50 minutes"));
                Assert.That(Sabre.VObject.DateTimeParser.parseDuration(ContextExtensions.CurrentContext, "+P50DT3H2S", true).ToString(), Is.EqualTo("+50 days 3 hours 2 seconds"));
                Assert.That(Sabre.VObject.DateTimeParser.parseDuration(ContextExtensions.CurrentContext, "+PT0S", true).ToString(), Is.EqualTo("+0 seconds"));
            });

            var zero = (DateInterval)Sabre.VObject.DateTimeParser.parseDuration(ContextExtensions.CurrentContext, "PT0S").Object!;
            AssertDateInterval(zero, "PT0S");
        }

        [Test]
        public void TestParseICalendarDurationDateInterval()
        {
            var oneWeek = (DateInterval)Sabre.VObject.DateTimeParser.parseDuration(ContextExtensions.CurrentContext, "P1W").Object!;
            var oneWeekViaParse = (DateInterval)Sabre.VObject.DateTimeParser.parse(ContextExtensions.CurrentContext, "P1W").Object!;
            var negative = (DateInterval)Sabre.VObject.DateTimeParser.parseDuration(ContextExtensions.CurrentContext, "-PT3M").Object!;

            Assert.Multiple(() =>
            {
                AssertDateInterval(oneWeek, "P7D");
                AssertDateInterval(oneWeekViaParse, "P7D");
                AssertDateInterval(negative, "PT3M", 1);
            });
        }

        [Test]
        public void TestParseDurationZero()
        {
            var interval = (DateInterval)Sabre.VObject.DateTimeParser.parseDuration(ContextExtensions.CurrentContext, "P").Object!;
            AssertDateInterval(interval, "PT0S");
        }

        [Test]
        public void TestParseICalendarDurationFail()
        {
            Assert.Throws<Sabre.VObject.InvalidDataException>(() =>
                Sabre.VObject.DateTimeParser.parseDuration(ContextExtensions.CurrentContext, "P1X", true));
        }

        [Test]
        public void TestParseICalendarDateTime()
        {
            var dateTime = Sabre.VObject.DateTimeParser.parseDateTime(ContextExtensions.CurrentContext, "20100316T141405");
            AssertDateTime(dateTime, "2010-03-16 14:14:05", "UTC");
        }

        [Test]
        public void TestParseICalendarDateTimeBadFormat()
        {
            Assert.Throws<Sabre.VObject.InvalidDataException>(() =>
                Sabre.VObject.DateTimeParser.parseDateTime(ContextExtensions.CurrentContext, "20100316T141405 "));
        }

        [Test]
        public void TestParseICalendarDateTimeInvalidTime()
        {
            Assert.Throws<Sabre.VObject.InvalidDataException>(() =>
                Sabre.VObject.DateTimeParser.parseDateTime(ContextExtensions.CurrentContext, "20100316T251405"));
        }

        [Test]
        public void TestParseICalendarDateTimeUtcAndCustomTimeZone()
        {
            var utcDateTime = Sabre.VObject.DateTimeParser.parseDateTime(ContextExtensions.CurrentContext, "20100316T141405Z");
            var customDateTime = Sabre.VObject.DateTimeParser.parseDateTime(ContextExtensions.CurrentContext, "20100316T141405", new DateTimeZone(ContextExtensions.CurrentContext, "Europe/Amsterdam"));

            Assert.Multiple(() =>
            {
                AssertDateTime(utcDateTime, "2010-03-16 14:14:05", "UTC");
                AssertDateTime(customDateTime, "2010-03-16 14:14:05", "Europe/Amsterdam");
            });
        }

        [Test]
        public void TestParseICalendarDate()
        {
            var date = Sabre.VObject.DateTimeParser.parseDate(ContextExtensions.CurrentContext, "20100316");
            var dateViaParse = (DateTimeImmutable)Sabre.VObject.DateTimeParser.parse(ContextExtensions.CurrentContext, "20100316").Object!;

            Assert.Multiple(() =>
            {
                AssertDateTime(date, "2010-03-16 00:00:00", "UTC");
                AssertDateTime(dateViaParse, "2010-03-16 00:00:00", "UTC");
            });
        }

        [Test]
        public void TestParseICalendarDateAndDateTimeGreaterThan4000()
        {
            var date = Sabre.VObject.DateTimeParser.parseDate(ContextExtensions.CurrentContext, "45001231");
            var dateTime = Sabre.VObject.DateTimeParser.parseDateTime(ContextExtensions.CurrentContext, "45001231T235959");

            Assert.Multiple(() =>
            {
                AssertDateTime(date, "4500-12-31 00:00:00", "UTC");
                AssertDateTime(dateTime, "4500-12-31 23:59:59", "UTC");
            });
        }

        [Test]
        public void TestParseICalendarDateFailures()
        {
            Assert.Multiple(() =>
            {
                Assert.Throws<Sabre.VObject.InvalidDataException>(() =>
                    Sabre.VObject.DateTimeParser.parseDate(ContextExtensions.CurrentContext, "20100316T141405"));
                Assert.Throws<Sabre.VObject.InvalidDataException>(() =>
                    Sabre.VObject.DateTimeParser.parseDate(ContextExtensions.CurrentContext, "20101331"));
            });
        }

        [TestCaseSource(nameof(VCardDateCases))]
        public void TestVCardDate(string input, Dictionary<string, string> expected)
        {
            var actual = Sabre.VObject.DateTimeParser.parseVCardDateTime(ContextExtensions.CurrentContext, input);
            AssertParts(actual, expected);
        }

        [Test]
        public void TestBadVCardDateAndTime()
        {
            Assert.Multiple(() =>
            {
                Assert.Throws<Sabre.VObject.InvalidDataException>(() =>
                    Sabre.VObject.DateTimeParser.parseVCardDateTime(ContextExtensions.CurrentContext, "1985---01"));
                Assert.Throws<Sabre.VObject.InvalidDataException>(() =>
                    Sabre.VObject.DateTimeParser.parseVCardTime(ContextExtensions.CurrentContext, "23:12:166"));
            });
        }
    }
}
