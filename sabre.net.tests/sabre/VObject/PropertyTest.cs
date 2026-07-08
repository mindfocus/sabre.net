using System;
using System.Reflection;
using NUnit.Framework;
using Pchp.Core;

namespace sabre.net.tests.sabre.VObject
{
    public class PropertyTest
    {
        private static Sabre.VObject.Document CreateVCalendar()
        {
            var type = typeof(Sabre.VObject.Document).Assembly.GetType("Sabre.VObject.Component.VCalendar", true);
            return (Sabre.VObject.Document)Activator.CreateInstance(type, Array.Empty<PhpValue>());
        }

        private static Sabre.VObject.Document CreateVCard(string version)
        {
            var children = PhpArray.NewEmpty();
            children.Add("VERSION", version);
            var type = typeof(Sabre.VObject.Document).Assembly.GetType("Sabre.VObject.Component.VCard", true);
            return (Sabre.VObject.Document)Activator.CreateInstance(type, new object[] { new PhpValue[] { children } });
        }

        private static string GetName(object node)
        {
            var field = node.GetType().GetField("name") ?? node.GetType().BaseType?.GetField("name");
            Assert.That(field, Is.Not.Null);
            return ((PhpValue)field.GetValue(node)).ToString();
        }

        private static PhpArray GetParameters(object property)
        {
            var method = property.GetType().GetMethod("parameters");
            Assert.That(method, Is.Not.Null);
            return ((PhpValue)method.Invoke(property, null)).Array;
        }

        private static object GetParameter(object property, string name)
        {
            var method = property.GetType().GetMethod("offsetGet");
            Assert.That(method, Is.Not.Null);
            return ((PhpValue)method.Invoke(property, new object[] { (PhpValue)name })).Object;
        }

        private static bool HasParameter(object property, string name)
        {
            var method = property.GetType().GetMethod("offsetExists");
            Assert.That(method, Is.Not.Null);
            return ((PhpValue)method.Invoke(property, new object[] { (PhpValue)name })).ToBoolean();
        }

        private static void SetParameter(object property, string name, PhpValue value)
        {
            var method = property.GetType().GetMethod("offsetSet");
            Assert.That(method, Is.Not.Null);
            method.Invoke(property, new object[] { (PhpValue)name, value });
        }

        private static void UnsetParameter(object property, string name)
        {
            var method = property.GetType().GetMethod("offsetUnset");
            Assert.That(method, Is.Not.Null);
            method.Invoke(property, new object[] { (PhpValue)name });
        }

        private static void AddParameter(object property, string name, PhpValue value)
        {
            var method = property.GetType().GetMethod("add");
            Assert.That(method, Is.Not.Null);
            method.Invoke(property, new object[] { (PhpValue)name, value });
        }

        private static string GetValue(object property)
        {
            var method = property.GetType().GetMethod("getValue");
            Assert.That(method, Is.Not.Null);
            return ((PhpValue)method.Invoke(property, null)).ToString();
        }

        private static PhpArray GetParts(object property)
        {
            var method = property.GetType().GetMethod("getParts");
            Assert.That(method, Is.Not.Null);
            return ((PhpValue)method.Invoke(property, null)).Array;
        }

        private static void SetValue(object property, PhpValue value)
        {
            var method = property.GetType().GetMethod("setValue");
            Assert.That(method, Is.Not.Null);
            method.Invoke(property, new object[] { value });
        }

        private static string Serialize(object property)
        {
            var method = property.GetType().GetMethod("serialize");
            Assert.That(method, Is.Not.Null);
            return ((PhpValue)method.Invoke(property, null)).ToString();
        }

        private static PhpArray Validate(object property, int options = 0)
        {
            var method = property.GetType().GetMethod("validate");
            Assert.That(method, Is.Not.Null);
            return ((PhpValue)method.Invoke(property, new object[] { (PhpValue)options })).Array;
        }

        [Test]
        public void TestToString()
        {
            var cal = CreateVCalendar();
            var property = cal.createProperty("propname", "propvalue");

            Assert.Multiple(() =>
            {
                Assert.That(GetName(property), Is.EqualTo("PROPNAME"));
                Assert.That(property.ToString(), Is.EqualTo("propvalue"));
                Assert.That(GetValue(property), Is.EqualTo("propvalue"));
            });
        }

        [Test]
        public void TestCreate()
        {
            var cal = CreateVCalendar();
            var parameters = PhpArray.NewEmpty();
            parameters.Add("param1", "value1");
            parameters.Add("param2", "value2");
            var property = cal.createProperty("propname", "propvalue", parameters);

            Assert.Multiple(() =>
            {
                Assert.That(GetValue(GetParameter(property, "param1")), Is.EqualTo("value1"));
                Assert.That(GetValue(GetParameter(property, "param2")), Is.EqualTo("value2"));
            });
        }

        [Test]
        public void TestSetValue()
        {
            var cal = CreateVCalendar();
            var property = cal.createProperty("propname", "propvalue");
            SetValue(property, "value2");

            Assert.That(GetName(property), Is.EqualTo("PROPNAME"));
            Assert.That(property.ToString(), Is.EqualTo("value2"));
        }

        [Test]
        public void TestParameterLifecycle()
        {
            var cal = CreateVCalendar();
            var property = cal.createProperty("propname", "propvalue");
            SetParameter(property, "paramname", "paramvalue");

            Assert.Multiple(() =>
            {
                Assert.That(HasParameter(property, "PARAMNAME"), Is.True);
                Assert.That(HasParameter(property, "paramname"), Is.True);
                Assert.That(HasParameter(property, "foo"), Is.False);
                Assert.That(GetParameter(property, "paramname"), Is.Not.Null);
                Assert.That(GetParameter(property, "foo"), Is.Null);
            });

            UnsetParameter(property, "PARAMNAME");
            Assert.That(GetParameters(property).Count, Is.EqualTo(0));
        }

        [Test]
        public void TestParameterMultiple()
        {
            var cal = CreateVCalendar();
            var property = cal.createProperty("propname", "propvalue");
            SetParameter(property, "paramname", "paramvalue");
            AddParameter(property, "paramname", "paramvalue2");

            var parameter = GetParameter(property, "paramname");
            Assert.That(parameter, Is.Not.Null);
            Assert.That(GetParts(parameter).Count, Is.EqualTo(2));
        }

        [Test]
        public void TestSerialize()
        {
            var cal = CreateVCalendar();
            var property = cal.createProperty("propname", "propvalue");

            Assert.That(Serialize(property), Is.EqualTo("PROPNAME:propvalue\r\n"));
        }

        [Test]
        public void TestSerializeParam()
        {
            var cal = CreateVCalendar();
            var parameters = PhpArray.NewEmpty();
            parameters.Add("paramname", "paramvalue");
            parameters.Add("paramname2", "paramvalue2");
            var property = cal.createProperty("propname", "propvalue", parameters);

            Assert.That(Serialize(property), Is.EqualTo("PROPNAME;PARAMNAME=paramvalue;PARAMNAME2=paramvalue2:propvalue\r\n"));
        }

        [Test]
        public void TestSerializeNewLine()
        {
            var cal = CreateVCalendar();
            var property = cal.createProperty("SUMMARY", "line1\nline2");

            Assert.That(Serialize(property), Is.EqualTo("SUMMARY:line1\\nline2\r\n"));
        }

        [Test]
        public void TestSerializeLongLine()
        {
            var cal = CreateVCalendar();
            var value = new string('!', 200);
            var property = cal.createProperty("propname", value);
            var expected = "PROPNAME:" + new string('!', 66) + "\r\n " + new string('!', 74) + "\r\n " + new string('!', 60) + "\r\n";

            Assert.That(Serialize(property), Is.EqualTo(expected));
        }

        [Test]
        public void TestAddParameterTwice()
        {
            var cal = CreateVCalendar();
            var property = cal.createProperty("EMAIL");
            AddParameter(property, "MYPARAM", "value1");
            AddParameter(property, "MYPARAM", "value2");

            var parameters = GetParameters(property);
            var myParam = GetParameter(property, "MYPARAM");
            Assert.Multiple(() =>
            {
                Assert.That(parameters.Count, Is.EqualTo(1));
                Assert.That(GetParts(myParam).Count, Is.EqualTo(2));
                Assert.That(GetName(myParam), Is.EqualTo("MYPARAM"));
            });
        }

        [Test]
        public void TestGetValueVariants()
        {
            var cal = CreateVCalendar();
            var property = cal.createProperty("SUMMARY", PhpValue.Null);

            Assert.That(GetParts(property).Count, Is.EqualTo(0));
            Assert.That(((PhpValue)property.getValue()).IsNull, Is.True);

            SetValue(property, PhpArray.NewEmpty());
            Assert.That(GetParts(property).Count, Is.EqualTo(0));
            Assert.That(((PhpValue)property.getValue()).IsNull, Is.True);

            SetValue(property, PhpArray.New(1));
            Assert.That(GetParts(property).Count, Is.EqualTo(1));
            Assert.That(GetValue(property), Is.EqualTo("1"));

            SetValue(property, PhpArray.New(1, 2));
            Assert.That(GetParts(property).Count, Is.EqualTo(2));
            Assert.That(GetValue(property), Is.EqualTo("1,2"));

            SetValue(property, "str");
            Assert.That(GetParts(property).Count, Is.EqualTo(1));
            Assert.That(GetValue(property), Is.EqualTo("str"));
        }

        [Test]
        public void TestValidateBadEncoding()
        {
            var document = CreateVCalendar();
            var property = document.add("X-FOO", "value").Object;
            SetParameter(property, "ENCODING", "invalid");

            var result = Validate(property);
            var warning = result[0].Array;

            Assert.Multiple(() =>
            {
                Assert.That(warning["message"].ToString(), Is.EqualTo("ENCODING=INVALID is not valid for this document type."));
                Assert.That(warning["level"].ToString(), Is.EqualTo("3"));
            });
        }

        [Test]
        public void TestValidateBadEncodingVCard4()
        {
            var document = CreateVCard("4.0");
            var property = document.add("X-FOO", "value").Object;
            SetParameter(property, "ENCODING", "BASE64");

            var result = Validate(property);
            var warning = result[0].Array;

            Assert.Multiple(() =>
            {
                Assert.That(warning["message"].ToString(), Is.EqualTo("ENCODING parameter is not valid in vCard 4."));
                Assert.That(warning["level"].ToString(), Is.EqualTo("3"));
            });
        }

        [Test]
        public void TestValidateBadEncodingVCard3Repair()
        {
            var document = CreateVCard("3.0");
            var property = document.add("X-FOO", "value").Object;
            SetParameter(property, "ENCODING", "BASE64");

            var result = Validate(property, 1);
            var warning = result[0].Array;

            Assert.Multiple(() =>
            {
                Assert.That(warning["message"].ToString(), Is.EqualTo("ENCODING=BASE64 has been transformed to ENCODING=B."));
                Assert.That(warning["level"].ToString(), Is.EqualTo("1"));
                Assert.That(GetValue(GetParameter(property, "ENCODING")), Is.EqualTo("B"));
            });
        }
    }
}
