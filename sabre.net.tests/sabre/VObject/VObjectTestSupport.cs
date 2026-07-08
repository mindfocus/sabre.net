using System;
using System.Collections.Generic;
using NUnit.Framework;
using Pchp.Core;
using Pchp.Core.Utilities;

namespace sabre.net.tests.sabre.VObject
{
    internal static class VObjectTestSupport
    {
        public static Sabre.VObject.Document ReadDocument(string data)
        {
            var result = Sabre.VObject.Reader.read(ContextExtensions.CurrentContext, data);
            Assert.That(result.Object, Is.Not.Null);
            return (Sabre.VObject.Document)result.Object!;
        }

        public static Sabre.VObject.Document CreateVCalendar(bool defaults = false)
        {
            var type = typeof(Sabre.VObject.Document).Assembly.GetType("Sabre.VObject.Component.VCalendar", true);
            return (Sabre.VObject.Document)Activator.CreateInstance(
                type!,
                new object[] { new PhpValue[] { PhpArray.NewEmpty(), PhpValue.Create(defaults) } })!;
        }

        public static Sabre.VObject.Document CreateVCard(bool defaults = false)
        {
            var type = typeof(Sabre.VObject.Document).Assembly.GetType("Sabre.VObject.Component.VCard", true);
            return (Sabre.VObject.Document)Activator.CreateInstance(
                type!,
                new object[] { new PhpValue[] { PhpArray.NewEmpty(), PhpValue.Create(defaults) } })!;
        }

        public static object GetNamedObject(object component, string name)
        {
            var method = component.GetType().GetMethod("__get");
            Assert.That(method, Is.Not.Null);
            var value = (PhpValue)method!.Invoke(component, new object[] { (PhpValue)name })!;
            Assert.That(value.Object, Is.Not.Null);
            return value.Object!;
        }

        public static string GetPropertyValue(object property)
        {
            var method = property.GetType().GetMethod("getValue");
            Assert.That(method, Is.Not.Null);
            return ((PhpValue)method!.Invoke(property, null)!).ToString();
        }

        public static PhpArray GetParameters(object property)
        {
            var method = property.GetType().GetMethod("parameters");
            Assert.That(method, Is.Not.Null);
            var value = (PhpValue)method!.Invoke(property, null)!;
            Assert.That(value.Array, Is.Not.Null);
            return value.Array!;
        }

        public static PhpValue InvokeAdd(object target, params PhpValue[] arguments)
        {
            var method = target.GetType().GetMethod("add");
            Assert.That(method, Is.Not.Null);
            return (PhpValue)method!.Invoke(target, new object[] { arguments })!;
        }

        public static PhpValue AddParameter(object target, PhpValue name, PhpValue value)
        {
            var method = target.GetType().GetMethod("add", new[] { typeof(PhpValue), typeof(PhpValue) });
            Assert.That(method, Is.Not.Null);
            return (PhpValue)method!.Invoke(target, new object[] { name, value })!;
        }

        public static List<(PhpValue Key, PhpValue Value)> IterateEntries(object iterator)
        {
            var iteratorType = iterator.GetType();
            var rewind = iteratorType.GetMethod("rewind");
            var valid = iteratorType.GetMethod("valid");
            var key = iteratorType.GetMethod("key");
            var current = iteratorType.GetMethod("current");
            var next = iteratorType.GetMethod("next");

            Assert.Multiple(() =>
            {
                Assert.That(rewind, Is.Not.Null);
                Assert.That(valid, Is.Not.Null);
                Assert.That(key, Is.Not.Null);
                Assert.That(current, Is.Not.Null);
                Assert.That(next, Is.Not.Null);
            });

            var result = new List<(PhpValue Key, PhpValue Value)>();
            rewind!.Invoke(iterator, null);

            while ((bool)valid!.Invoke(iterator, null)!)
            {
                result.Add(((PhpValue)key!.Invoke(iterator, null)!, (PhpValue)current!.Invoke(iterator, null)!));
                next!.Invoke(iterator, null);
            }

            return result;
        }
    }
}
