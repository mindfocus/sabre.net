using System.Collections.Generic;
using NUnit.Framework;
using Pchp.Core;

namespace sabre.net.tests.sabre.VObject
{
    public class ParameterTest
    {
        private static string GetName(object node)
        {
            var field = node.GetType().GetField("name") ?? node.GetType().BaseType?.GetField("name");
            Assert.That(field, Is.Not.Null);
            return ((PhpValue)field.GetValue(node)).ToString();
        }

        private static string GetValue(object parameter)
        {
            return ((PhpValue)parameter.GetType().GetMethod("getValue").Invoke(parameter, null)).ToString();
        }

        private static PhpArray GetParts(object parameter)
        {
            return ((PhpValue)parameter.GetType().GetMethod("getParts").Invoke(parameter, null)).Array;
        }

        private static string Serialize(object parameter)
        {
            return ((PhpValue)parameter.GetType().GetMethod("serialize").Invoke(parameter, null)).ToString();
        }

        private static List<string> IterateValues(object iterator)
        {
            var iteratorType = iterator.GetType();
            var rewind = iteratorType.GetMethod("rewind");
            var valid = iteratorType.GetMethod("valid");
            var current = iteratorType.GetMethod("current");
            var next = iteratorType.GetMethod("next");

            Assert.Multiple(() =>
            {
                Assert.That(rewind, Is.Not.Null);
                Assert.That(valid, Is.Not.Null);
                Assert.That(current, Is.Not.Null);
                Assert.That(next, Is.Not.Null);
            });

            var result = new List<string>();
            rewind.Invoke(iterator, null);

            while ((bool)valid.Invoke(iterator, null))
            {
                result.Add(((PhpValue)current.Invoke(iterator, null)).ToString());
                next.Invoke(iterator, null);
            }

            return result;
        }

        [Test]
        public void TestSetup()
        {
            var cal = CreateVCalendar();
            var param = new Sabre.VObject.Parameter(cal, "name", "value");

            Assert.Multiple(() =>
            {
                Assert.That(GetName(param), Is.EqualTo("NAME"));
                Assert.That(GetValue(param), Is.EqualTo("value"));
            });
        }

        [Test]
        public void TestSetupNameLess()
        {
            var card = CreateVCard();
            var param = new Sabre.VObject.Parameter(card, PhpValue.Null, "URL");

            Assert.Multiple(() =>
            {
                Assert.That(GetName(param), Is.EqualTo("VALUE"));
                Assert.That(GetValue(param), Is.EqualTo("URL"));
                Assert.That(param.noName.ToBoolean(), Is.True);
            });
        }

        [Test]
        public void TestModify()
        {
            var cal = CreateVCalendar();
            var param = new Sabre.VObject.Parameter(cal, "name", PhpValue.Null);

            param.addValue(1);
            Assert.That(GetParts(param).Count, Is.EqualTo(1));

            var parts = PhpArray.New(1, 2);
            param.setParts(parts);
            Assert.That(GetParts(param).Count, Is.EqualTo(2));

            param.addValue(3);
            Assert.That(GetParts(param).Count, Is.EqualTo(3));

            param.setValue(4);
            param.addValue(5);
            var actual = GetParts(param);
            Assert.Multiple(() =>
            {
                Assert.That(actual.Count, Is.EqualTo(2));
                Assert.That(actual[0].ToString(), Is.EqualTo("4"));
                Assert.That(actual[1].ToString(), Is.EqualTo("5"));
            });
        }

        [Test]
        public void TestCastToString()
        {
            var cal = CreateVCalendar();
            var param = new Sabre.VObject.Parameter(cal, "name", "value");

            Assert.That(param.ToString(), Is.EqualTo("value"));
            Assert.That(GetValue(param), Is.EqualTo("value"));
        }

        [Test]
        public void TestCastNullToString()
        {
            var cal = CreateVCalendar();
            var param = new Sabre.VObject.Parameter(cal, "name", PhpValue.Null);

            Assert.That(param.ToString(), Is.EqualTo(string.Empty));
            Assert.That(GetValue(param), Is.EqualTo(string.Empty));
        }

        [Test]
        public void TestSerialize()
        {
            var cal = CreateVCalendar();
            var param = new Sabre.VObject.Parameter(cal, "name", "value");

            Assert.That(Serialize(param), Is.EqualTo("NAME=value"));
        }

        [Test]
        public void TestSerializeEmpty()
        {
            var cal = CreateVCalendar();
            var param = new Sabre.VObject.Parameter(cal, "name", PhpValue.Null);

            Assert.That(Serialize(param), Is.EqualTo("NAME="));
        }

        [Test]
        public void TestSerializeComplex()
        {
            var cal = CreateVCalendar();
            var values = PhpArray.New("val1", "val2;", "val3^", "val4\n", "val5\"");
            var param = new Sabre.VObject.Parameter(cal, "name", values);

            Assert.That(Serialize(param), Is.EqualTo("NAME=val1,\"val2;\",\"val3^^\",\"val4^n\",\"val5^'\""));
        }

        [Test]
        public void TestSerializePlusSign()
        {
            var cal = CreateVCalendar();
            var param = new Sabre.VObject.Parameter(cal, "EMAIL", "user+something@example.org");

            Assert.That(Serialize(param), Is.EqualTo("EMAIL=\"user+something@example.org\""));
        }

        [Test]
        public void TestIterate()
        {
            var cal = CreateVCalendar();
            var param = new Sabre.VObject.Parameter(cal, "name", PhpArray.New(1, 2, 3, 4));
            var iterator = ((PhpValue)param.getIterator()).Object;
            var result = IterateValues(iterator);

            Assert.That(result, Is.EqualTo(new[] { "1", "2", "3", "4" }));
        }

        [Test]
        public void TestSerializeColonAndSemiColon()
        {
            var cal = CreateVCalendar();
            var colon = new Sabre.VObject.Parameter(cal, "name", "va:lue");
            var semi = new Sabre.VObject.Parameter(cal, "name", "va;lue");

            Assert.Multiple(() =>
            {
                Assert.That(Serialize(colon), Is.EqualTo("NAME=\"va:lue\""));
                Assert.That(Serialize(semi), Is.EqualTo("NAME=\"va;lue\""));
            });
        }

        private static Sabre.VObject.Document CreateVCalendar()
        {
            var type = typeof(Sabre.VObject.Document).Assembly.GetType("Sabre.VObject.Component.VCalendar", true);
            return (Sabre.VObject.Document)System.Activator.CreateInstance(type, System.Array.Empty<PhpValue>());
        }

        private static Sabre.VObject.Document CreateVCard()
        {
            var type = typeof(Sabre.VObject.Document).Assembly.GetType("Sabre.VObject.Component.VCard", true);
            return (Sabre.VObject.Document)System.Activator.CreateInstance(type, System.Array.Empty<PhpValue>());
        }
    }
}
