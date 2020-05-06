using NUnit.Framework;
using Pchp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sabre.net.tests.sabre.Uri
{
    class SplitTest
    {
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
            var func = new Sabre.Uri.UriFunctions();
            foreach (var str in strings)
            {
                var output = func.split(str.Key.String);
                Assert.AreEqual(str.Value, output);
            }
    }
    }
}
