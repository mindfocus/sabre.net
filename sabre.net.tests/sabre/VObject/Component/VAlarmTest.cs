using System.Reflection;
using NUnit.Framework;
using Pchp.Core;
using Pchp.Library.DateTime;
using Pchp.Core.Utilities;
using sabre.net.tests.sabre.VObject;
using Nextsharp.Sabre.RuntimePatch;

namespace sabre.net.tests.sabre.VObject.Component
{
    public class VAlarmTest
    {
        [OneTimeSetUp]
        public void EnsureRuntimePatchApplied()
        {
            // VAlarm 的 isInTimeRange 在处理相对 TRIGGER（如 -P1D / -PT10M）时会
            // 走到 DateTime 相对日期语义，与 VEventTest 同源，故同样需显式装配
            // DateTime::modify 运行时补丁，避免 PeachPie 相对日期解析偏差。
            RuntimePatchBootstrap.nextsharp_sabre_runtime_patch_bootstrap();
        }

        private static DateTime CreateDateTime(string value)
        {
            return new DateTime(ContextExtensions.CurrentContext, value);
        }

        private static Sabre.VObject.Document CreateCalendar()
        {
            return VObjectTestSupport.CreateVCalendar(false);
        }

        private static object CreateComponent(Sabre.VObject.Document calendar, string name)
        {
            return calendar.createComponent(name, PhpValue.Null, PhpValue.False).Object!;
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

        [TestCase("2012-03-01 01:00:00", "2012-04-01 01:00:00", true)]
        [TestCase("2012-03-01 01:00:00", "2012-03-10 01:00:00", false)]
        public void testInTimeRange_HardDate(string start, string end, bool expected)
        {
            var calendar = CreateCalendar();
            var alarm = CreateComponent(calendar, "VALARM");
            var trigger = calendar.createProperty("TRIGGER", "20120312T130000Z", CreateParameters("VALUE", "DATE-TIME"));
            VObjectTestSupport.InvokeAdd(alarm, PhpValue.FromClass(trigger));

            var result = (PhpValue)alarm.GetType().GetMethod("isInTimeRange")!.Invoke(
                alarm,
                new object[] { CreateDateTime(start), CreateDateTime(end) })!;

            Assert.That(result.ToBoolean(), Is.EqualTo(expected));
        }

        [Test]
        public void testInTimeRange_InvalidComponent()
        {
            var calendar = CreateCalendar();
            var alarm = CreateComponent(calendar, "VALARM");
            SetProperty(alarm, "TRIGGER", "-P1D");
            SetParameter(VObjectTestSupport.GetNamedObject(alarm, "TRIGGER"), "RELATED", "END");

            var journal = CreateComponent(calendar, "VJOURNAL");
            VObjectTestSupport.InvokeAdd(journal, PhpValue.FromClass(alarm));

            var ex = Assert.Throws<TargetInvocationException>(() =>
                alarm.GetType().GetMethod("isInTimeRange")!.Invoke(
                    alarm,
                    new object[] { CreateDateTime("2012-02-25 01:00:00"), CreateDateTime("2012-03-05 01:00:00") }));
            Assert.That(ex!.InnerException, Is.InstanceOf<Sabre.VObject.InvalidDataException>());
        }

        [Test]
        public void testInTimeRange_Buggy()
        {
            const string input =
                "BEGIN:VCALENDAR\n" +
                "BEGIN:VTODO\n" +
                "DTSTAMP:20121003T064931Z\n" +
                "UID:b848cb9a7bb16e464a06c222ca1f8102@examle.com\n" +
                "STATUS:NEEDS-ACTION\n" +
                "DUE:20121005T000000Z\n" +
                "SUMMARY:Task 1\n" +
                "CATEGORIES:AlarmCategory\n" +
                "BEGIN:VALARM\n" +
                "TRIGGER:-PT10M\n" +
                "ACTION:DISPLAY\n" +
                "DESCRIPTION:Task 1\n" +
                "END:VALARM\n" +
                "END:VTODO\n" +
                "END:VCALENDAR";

            var vobj = VObjectTestSupport.ReadDocument(input);
            var todo = VObjectTestSupport.GetNamedObject(vobj, "VTODO");
            var alarm = VObjectTestSupport.GetNamedObject(todo, "VALARM");
            var result = (PhpValue)alarm.GetType().GetMethod("isInTimeRange")!.Invoke(
                alarm,
                new object[] { CreateDateTime("2012-10-01 00:00:00"), CreateDateTime("2012-11-01 00:00:00") })!;

            Assert.That(result.ToBoolean(), Is.True);
        }

        private static PhpArray CreateParameters(string name, string value)
        {
            var parameters = PhpArray.NewEmpty();
            parameters.Add(name, value);
            return parameters;
        }
    }
}
