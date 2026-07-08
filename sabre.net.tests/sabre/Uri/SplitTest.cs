using NUnit.Framework;
using Pchp.Core;
using Pchp.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sabre.net.tests.sabre.Uri
{
    class SplitTest
    {
        private static PhpArray SplitUri(string path)
        {
            var uriFunctions = typeof(Sabre.Uri.Version).Assembly.GetType("<Root>uri/lib.functions_php", throwOnError: true);
            return (PhpArray)uriFunctions.GetMethod("Sabre.Uri.split")
                .Invoke(null, new object[] { ContextExtensions.CurrentContext, new PhpString(path) });
        }

        [Test]
        public void testSplit()
    {
            var strings = PhpArray.NewEmpty();
            strings.Add("/foo/bar", PhpArray.New("/foo","bar"));
            strings.Add("/foo/bar/", PhpArray.New("/foo","bar"));
            strings.Add("foo/bar/", PhpArray.New("foo","bar"));
            strings.Add("foo/bar", PhpArray.New("foo","bar"));
            strings.Add("foo/bar/baz", PhpArray.New("foo/bar","baz"));
            strings.Add("foo/bar/baz/", PhpArray.New("foo/bar","baz"));
            strings.Add("foo", PhpArray.New("","foo"));
            strings.Add("foo/", PhpArray.New("","foo"));
            strings.Add("/foo/", PhpArray.New("","foo"));
            strings.Add("/foo", PhpArray.New("","foo"));
            strings.Add("", PhpArray.New(PhpValue.Null,PhpValue.Null));
            // input                    // expected result
            // UTF-8
            //"/\xC3\xA0fo\xC3\xB3/bar" => ["/\xC3\xA0fo\xC3\xB3", 'bar'],
            //"/\xC3\xA0foo/b\xC3\xBCr/" => ["/\xC3\xA0foo", "b\xC3\xBCr"],
            //"foo/\xC3\xA0\xC3\xBCr" => ['foo', "\xC3\xA0\xC3\xBCr"],
            foreach (var str in strings)
            {
                var output = SplitUri(str.Key.String);
                Assert.AreEqual(str.Value, output);
            }
    }
    }
}
