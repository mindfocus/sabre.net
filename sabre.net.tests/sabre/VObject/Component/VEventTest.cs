using NUnit.Framework;
using Pchp.Core;
using Pchp.Core.Utilities;
using Pchp.Library.DateTime;
using sabre.net.tests.sabre.VObject;
using Nextsharp.Sabre.RuntimePatch;

namespace sabre.net.tests.sabre.VObject.Component
{
    public class VEventTest
    {
        [OneTimeSetUp]
        public void EnsureRuntimePatchApplied()
        {
            // VEventTest 是纯 C# 反射调用，不经过 PHP 脚本路径，因此
            // \nextsharp_sabre_runtime_patch_bootstrap() 的 PHP 入口不会自然触发。
            // 这里在测试类加载时显式装配 DateTime::modify 运行时补丁，
            // 否则触及 RRULE 迭代的用例会因 PeachPie 相对日期解析偏差而死循环。
            RuntimePatchBootstrap.nextsharp_sabre_runtime_patch_bootstrap();
        }

        private static DateTime CreateDateTime(string value)
        {
            return new DateTime(ContextExtensions.CurrentContext, value, new DateTimeZone(ContextExtensions.CurrentContext, "UTC"));
        }

        private static object CreateEvent()
        {
            var calendar = VObjectTestSupport.CreateVCalendar(false);
            var vevent = calendar.createComponent("VEVENT", PhpValue.Null, PhpValue.False).Object!;
            SetProperty(vevent, "DTSTART", "20111223T120000Z");
            return vevent;
        }

        private static void SetProperty(object component, string name, PhpValue value)
        {
            var method = component.GetType().GetMethod("__set");
            Assert.That(method, Is.Not.Null);
            method!.Invoke(component, new object[] { (PhpValue)name, value });
        }

        private static void SetParameter(object property, string name, string value)
        {
            VObjectTestSupport.AddParameter(property, name, value);
        }

        private static PhpArray CreateAssocArray(params object[] items)
        {
            var result = PhpArray.NewEmpty();

            for (var i = 0; i < items.Length; i += 2)
            {
                result.Add(items[i]!.ToString()!, PhpValue.FromClr(items[i + 1]));
            }

            return result;
        }

        private static bool IsInTimeRange(object vevent, string start, string end, string timeZone = null)
        {
            var startDate = timeZone is null
                ? new DateTime(ContextExtensions.CurrentContext, start, new DateTimeZone(ContextExtensions.CurrentContext, "UTC"))
                : new DateTime(ContextExtensions.CurrentContext, start, new DateTimeZone(ContextExtensions.CurrentContext, timeZone));
            var endDate = timeZone is null
                ? new DateTime(ContextExtensions.CurrentContext, end, new DateTimeZone(ContextExtensions.CurrentContext, "UTC"))
                : new DateTime(ContextExtensions.CurrentContext, end, new DateTimeZone(ContextExtensions.CurrentContext, timeZone));

            var result = (PhpValue)vevent.GetType().GetMethod("isInTimeRange")!.Invoke(vevent, new object[] { startDate, endDate })!;
            return result.ToBoolean();
        }

        private static bool HasTime(object property)
        {
            var method = property.GetType().GetMethod("hasTime");
            Assert.That(method, Is.Not.Null);
            return ((PhpValue)method!.Invoke(property, null)!).ToBoolean();
        }

        private static string GetDateTimeValue(object property, string timeZone = null)
        {
            var method = property.GetType().GetMethod("getDateTime");
            Assert.That(method, Is.Not.Null);

            var value = (PhpValue)(timeZone is null
                ? method!.Invoke(property, new object[] { null })!
                : method!.Invoke(property, new object[] { new DateTimeZone(ContextExtensions.CurrentContext, timeZone) })!);
            var dateTime = value.Object!;
            var format = dateTime.GetType().GetMethod("format");
            Assert.That(format, Is.Not.Null);

            return format!.Invoke(dateTime, new object[] { "Y-m-d H:i:s" })!.ToString()!;
        }

        [Test]
        public void testInTimeRange_Basic()
        {
            var vevent = CreateEvent();

            Assert.Multiple(() =>
            {
                Assert.That(IsInTimeRange(vevent, "2011-01-01", "2012-01-01"), Is.True);
                Assert.That(IsInTimeRange(vevent, "2011-01-01", "2011-11-01"), Is.False);
            });
        }

        [Test]
        public void testInTimeRange_WithDtEnd()
        {
            var vevent = CreateEvent();
            SetProperty(vevent, "DTEND", "20111225T120000Z");

            Assert.Multiple(() =>
            {
                Assert.That(IsInTimeRange(vevent, "2011-01-01", "2012-01-01"), Is.True);
                Assert.That(IsInTimeRange(vevent, "2011-01-01", "2011-11-01"), Is.False);
            });
        }

        [Test]
        public void testInTimeRange_WithDuration()
        {
            var vevent = CreateEvent();
            SetProperty(vevent, "DURATION", "P1D");

            Assert.Multiple(() =>
            {
                Assert.That(IsInTimeRange(vevent, "2011-01-01", "2012-01-01"), Is.True);
                Assert.That(IsInTimeRange(vevent, "2011-01-01", "2011-11-01"), Is.False);
            });
        }

        [Test]
        public void testInTimeRange_AllDay()
        {
            var vevent = CreateEvent();
            SetProperty(vevent, "DTSTART", "20111225");
            var dtStart = VObjectTestSupport.GetNamedObject(vevent, "DTSTART");
            SetParameter(dtStart, "VALUE", "DATE");

            Assert.Multiple(() =>
            {
                Assert.That(HasTime(dtStart), Is.False);
                Assert.That(GetDateTimeValue(dtStart), Is.EqualTo("2011-12-25 00:00:00"));
                Assert.That(GetDateTimeValue(dtStart, "Europe/Berlin"), Is.EqualTo("2011-12-25 00:00:00"));
                Assert.That(IsInTimeRange(vevent, "2011-12-25 16:00:00", "2011-12-25 17:00:00"), Is.True);
                Assert.That(IsInTimeRange(vevent, "2011-12-26 00:00:00", "2011-12-26 17:00:00"), Is.False);
                Assert.That(IsInTimeRange(vevent, "2011-12-26 00:00:00", "2011-12-26 17:00:00", "Europe/Berlin"), Is.False);
            });
        }

        [Test]
        public void testInTimeRange_RecurringYearly()
        {
            var vevent = CreateEvent();
            SetProperty(vevent, "DURATION", "P1D");
            SetProperty(vevent, "RRULE", "FREQ=YEARLY");

            Assert.Multiple(() =>
            {
                Assert.That(IsInTimeRange(vevent, "2011-01-01", "2012-01-01"), Is.True);
                Assert.That(IsInTimeRange(vevent, "2011-01-01", "2011-11-01"), Is.False);
                Assert.That(IsInTimeRange(vevent, "2013-12-01", "2013-12-31"), Is.True);
            });
        }

        [Test]
        public void testInTimeRange_AllDayWithDtEnd()
        {
            var vevent = CreateEvent();
            SetProperty(vevent, "DTSTART", "20111225");
            SetProperty(vevent, "DTEND", "20111225");
            SetParameter(VObjectTestSupport.GetNamedObject(vevent, "DTSTART"), "VALUE", "DATE");
            SetParameter(VObjectTestSupport.GetNamedObject(vevent, "DTEND"), "VALUE", "DATE");

            Assert.Multiple(() =>
            {
                Assert.That(IsInTimeRange(vevent, "2011-01-01", "2012-01-01"), Is.True);
                Assert.That(IsInTimeRange(vevent, "2011-01-01", "2011-11-01"), Is.False);
            });
        }

        [Test]
        public void testInTimeRange_RecurringMonthlyAllDay()
        {
            var vevent = CreateEvent();
            SetProperty(vevent, "DTSTART", "20120101");
            SetProperty(vevent, "RRULE", "FREQ=MONTHLY");
            SetParameter(VObjectTestSupport.GetNamedObject(vevent, "DTSTART"), "VALUE", "DATE");

            Assert.Multiple(() =>
            {
                Assert.That(IsInTimeRange(vevent, "2012-02-01 15:00:00", "2012-02-02"), Is.True);
                Assert.That(IsInTimeRange(vevent, "2012-02-02 00:00:00", "2012-02-03", "Europe/Berlin"), Is.False);
            });
        }

        [Test]
        public void testInTimeRange_RecurringDailyAllDay()
        {
            var vevent = CreateEvent();
            SetProperty(vevent, "DTSTART", "20161027");
            SetProperty(vevent, "DTEND", "20161028");
            SetProperty(vevent, "RRULE", "FREQ=DAILY");

            Assert.That(IsInTimeRange(vevent, "2016-10-31", "2016-12-12"), Is.True);
        }

        [Test]
        public void testInTimeRange_NoInstancesAfterExDate()
        {
            var vevent = CreateEvent();
            SetProperty(vevent, "DTSTART", "20130329T140000");
            SetProperty(vevent, "DTEND", "20130329T153000");
            SetProperty(vevent, "RRULE", CreateAssocArray(
                "FREQ", "WEEKLY",
                "BYDAY", PhpArray.New("FR"),
                "UNTIL", "20130412T115959Z"));
            VObjectTestSupport.InvokeAdd(vevent, "EXDATE", "20130405T140000");
            VObjectTestSupport.InvokeAdd(vevent, "EXDATE", "20130329T140000");

            Assert.That(IsInTimeRange(vevent, "2013-03-01", "2013-04-01"), Is.False);
        }
    }
}
