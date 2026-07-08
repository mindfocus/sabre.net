using NUnit.Framework;
using Pchp.Core;
using Pchp.Core.Utilities;
using Sabre.Uri;
using System.Collections.Generic;

namespace sabre.net.tests.sabre.Uri
{
    class ParseTest
    {
        private static PhpArray ParseUri(string input)
        {
            var uriFunctions = typeof(Sabre.Uri.Version).Assembly.GetType("<Root>uri/lib.functions_php", throwOnError: true);
            return (PhpArray)uriFunctions.GetMethod("Sabre.Uri.parse").Invoke(null, new object[] { ContextExtensions.CurrentContext, new PhpString(input) });
        }

        private sealed class UriParts
        {
            public string Scheme { get; init; }
            public string Host { get; init; }
            public string Path { get; init; }
            public int Port { get; init; }
            public string User { get; init; }
            public string Pass { get; init; }
            public string Query { get; init; }
            public string Fragment { get; init; }
        }

        private static PhpArray BuildExpected(
            string scheme,
            string host,
            string path,
            int? port = null,
            string user = null,
            string pass = null,
            string query = null,
            string fragment = null)
        {
            var result = PhpArray.NewEmpty();
            result.Add("scheme", scheme == null ? PhpValue.Null : PhpValue.Create(scheme));
            result.Add("host", host == null ? PhpValue.Null : PhpValue.Create(host));
            result.Add("path", path == null ? PhpValue.Null : PhpValue.Create(path));
            result.Add("port", port.HasValue ? PhpValue.Create(port.Value) : PhpValue.Null);
            result.Add("user", user == null ? PhpValue.Null : PhpValue.Create(user));
            result.Add("pass", pass == null ? PhpValue.Null : PhpValue.Create(pass));
            result.Add("query", query == null ? PhpValue.Null : PhpValue.Create(query));
            result.Add("fragment", fragment == null ? PhpValue.Null : PhpValue.Create(fragment));
            return result;
        }

        private static UriParts FromPhpArray(PhpArray source)
        {
            return new UriParts
            {
                Scheme = source.GetItemValue(new IntStringKey("scheme")).AsString(),
                Host = source.GetItemValue(new IntStringKey("host")).AsString(),
                Path = source.GetItemValue(new IntStringKey("path")).AsString(),
                Port = source.GetItemValue(new IntStringKey("port")).IsNull ? 0 : source.GetItemValue(new IntStringKey("port")).ToInt(),
                User = source.GetItemValue(new IntStringKey("user")).AsString(),
                Pass = source.GetItemValue(new IntStringKey("pass")).AsString(),
                Query = source.GetItemValue(new IntStringKey("query")).AsString(),
                Fragment = source.GetItemValue(new IntStringKey("fragment")).AsString(),
            };
        }

        private static void AssertUriPartsEqual(UriParts expected, UriParts actual)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected.Scheme, actual.Scheme, "scheme");
                Assert.AreEqual(expected.Host, actual.Host, "host");
                Assert.AreEqual(expected.Path, actual.Path, "path");
                Assert.AreEqual(expected.Port, actual.Port, "port");
                Assert.AreEqual(expected.User, actual.User, "user");
                Assert.AreEqual(expected.Pass, actual.Pass, "pass");
                Assert.AreEqual(expected.Query, actual.Query, "query");
                Assert.AreEqual(expected.Fragment, actual.Fragment, "fragment");
            });
        }

        [SetUp]
        public void Setup()
        {
        }
         /**
     * @dataProvider parseData
     *
     * @param string $in
     * @param string $out
     */
          [Test, TestCaseSource("parseData1")]
    public void testParse(string input, PhpArray output)
    {
            var actualOutput = FromPhpArray(ParseUri(input));
            AssertUriPartsEqual(FromPhpArray(output), actualOutput);
    }
         /**
     * @dataProvider parseData
     *
     * @param string $in
     * @param string $out
     */
        [Test, Ignore("当前构建未暴露 fallback parser 入口。"), TestCaseSource("parseData1")]
    public void testParseFallback(string input, PhpArray output)
    {
        // var result = this.func._parse_fallback(input);
            //result.Add("scheme", PhpValue.Null);
            //result.Add("host", PhpValue.Null);
            //result.Add("path", PhpValue.Null);
            //result.Add("port", PhpValue.Null);
            //result.Add("user", PhpValue.Null);
            //result.Add("query", PhpValue.Null);
            //result.Add("fragment", PhpValue.Null);
            // var v1 = output.ToUri();
            // var v2 = result.ToUri();
            // Assert.AreEqual(output.ToUri() , result.ToUri());
    }
        [Test]
        [Ignore("当前构建未暴露 fallback parser 入口。")]
        [ExpectedException(typeof(InvalidUriException))]
         public void testParseFallbackShouldThrowInvalidUriException()
    {
        // this.func._parse_fallback("ssh://invalid::7000/hello?foo=bar#test");
    }
        [Test]
        [Ignore("当前构建未暴露 fallback parser 入口。")]
        [ExpectedExceptionMessage("Invalid, or could not parse URI")]
         public void testParseFallbackShouldThrowInvalidUriExceptionMsg()
            {
            // this.func._parse_fallback("ssh://invalid::7000/hello?foo=bar#test");
            }
        public static IEnumerable<object[]> parseData1()
        {
            var result = new List<object[]>();
            result.Add(new object[]
            {
                "http://example.org/hello?foo=bar#test",
                BuildExpected("http", "example.org", "/hello", query: "foo=bar", fragment: "test"),
            });
            result.Add(new object[]
            {
                "http://example.org/有词法别名.zh",
                BuildExpected("http", "example.org", "/%E6%9C%89%E8%AF%8D%E6%B3%95%E5%88%AB%E5%90%8D.zh"),
            });
            result.Add(new object[]
            {
                "ftp://user:password@ftp.example.org/",
                BuildExpected("ftp", "ftp.example.org", "/", user: "user", pass: "password"),
            });
            result.Add(new object[]
            {
                "http://example.org/hello:12?foo=bar#test",
                BuildExpected("http", "example.org", "/hello:12", query: "foo=bar", fragment: "test"),
            });
            result.Add(new object[]
            {
                "/path/to/colon:34",
                BuildExpected(null, null, "/path/to/colon:34"),
            });
            result.Add(new object[]
            {
                "file:///foo/bar",
                BuildExpected("file", string.Empty, "/foo/bar"),
            });
            result.Add(new object[]
            {
                "vfs:///somefile",
                BuildExpected("vfs", string.Empty, "/somefile"),
            });
            result.Add(new object[]
            {
                "ldap://[2001:db8::7]/c=GB?objectClass?one",
                BuildExpected("ldap", "[2001:db8::7]", "/c=GB", query: "objectClass?one"),
            });
            result.Add(new object[]
            {
                "news:comp.infosystems.www.servers.unix",
                BuildExpected("news", null, "comp.infosystems.www.servers.unix"),
            });
            result.Add(new object[]
            {
                "http://example.org:8080/",
                BuildExpected("http", "example.org", "/", port: 8080),
            });
            result.Add(new object[]
            {
                "#foo",
                BuildExpected(null, null, null, fragment: "foo"),
            });
            result.Add(new object[]
            {
                "https://",
                BuildExpected("https", null, null),
            });
            result.Add(new object[]
            {
                "https://test",
                BuildExpected("https", "test", null),
            });
            return result;
        }
        public static List<List<object>> parseData()
        {
            var rootNode = new List<List<object>>();
            rootNode.Add(new List<object>{
                "http://example.org/hello?foo=bar#test",
                new Dictionary<string, object>
                {
                    { "scheme", "http" },
                    {"host", "example.org" },
                    { "path", "/hello" },
                    { "port", null },
                    { "user", null },
                    { "query", "foo=bar" },
                    { "fragment", "test" }
                }
            });
            return rootNode;

        //    // See issue #6. parse_url corrupts strings like this, but only on
        //    // macs.
        //    [

        //    ],
        //    [
        //        'ftp://user:password@ftp.example.org/',
        //        [
        //            'scheme' => 'ftp',
        //            'host' => 'ftp.example.org',
        //            'path' => '/',
        //            'port' => null,
        //            'user' => 'user',
        //            'pass' => 'password',
        //            'query' => null,
        //            'fragment' => null,
        //        ],
        //    ],
        //    // See issue #9, parse_url doesn't like colons followed by numbers even
        //    // though they are allowed since RFC 3986
        //    [
        //        'http://example.org/hello:12?foo=bar#test',
        //        [
        //            'scheme' => 'http',
        //            'host' => 'example.org',
        //            'path' => '/hello:12',
        //            'port' => null,
        //            'user' => null,
        //            'query' => 'foo=bar',
        //            'fragment' => 'test',
        //        ],
        //    ],
        //    [
        //        '/path/to/colon:34',
        //        [
        //            'scheme' => null,
        //            'host' => null,
        //            'path' => '/path/to/colon:34',
        //            'port' => null,
        //            'user' => null,
        //            'query' => null,
        //            'fragment' => null,
        //        ],
        //    ],
        //    // File scheme
        //    [
        //        'file:///foo/bar',
        //        [
        //            'scheme' => 'file',
        //            'host' => '',
        //            'path' => '/foo/bar',
        //            'port' => null,
        //            'user' => null,
        //            'query' => null,
        //            'fragment' => null,
        //        ],
        //    ],
        //    // Weird scheme with triple-slash. See Issue #11.
        //    [
        //        'vfs:///somefile',
        //        [
        //            'scheme' => 'vfs',
        //            'host' => '',
        //            'path' => '/somefile',
        //            'port' => null,
        //            'user' => null,
        //            'query' => null,
        //            'fragment' => null,
        //        ],
        //    ],
        //    // Examples from RFC3986
        //    [
        //        'ldap://[2001:db8::7]/c=GB?objectClass?one',
        //        [
        //            'scheme' => 'ldap',
        //            'host' => '[2001:db8::7]',
        //            'path' => '/c=GB',
        //            'port' => null,
        //            'user' => null,
        //            'query' => 'objectClass?one',
        //            'fragment' => null,
        //        ],
        //    ],
        //    [
        //        'news:comp.infosystems.www.servers.unix',
        //        [
        //            'scheme' => 'news',
        //            'host' => null,
        //            'path' => 'comp.infosystems.www.servers.unix',
        //            'port' => null,
        //            'user' => null,
        //            'query' => null,
        //            'fragment' => null,
        //        ],
        //    ],
        //    // Port
        //    [
        //        'http://example.org:8080/',
        //        [
        //            'scheme' => 'http',
        //            'host' => 'example.org',
        //            'path' => '/',
        //            'port' => 8080,
        //            'user' => null,
        //            'query' => null,
        //            'fragment' => null,
        //        ],
        //    ],
        //    // Partial url
        //    [
        //        '#foo',
        //        [
        //            'scheme' => null,
        //            'host' => null,
        //            'path' => null,
        //            'port' => null,
        //            'user' => null,
        //            'query' => null,
        //            'fragment' => 'foo',
        //        ],
        //    ],
        //    [
        //        'https://',
        //        [
        //            'scheme' => 'https',
        //            'host' => null,
        //            'path' => null,
        //            'port' => null,
        //            'user' => null,
        //            'query' => null,
        //            'fragment' => null,
        //        ],
        //    ],
        //    [
        //        'https://test',
        //        [
        //            'scheme' => 'https',
        //            'host' => 'test',
        //            'path' => null,
        //            'port' => null,
        //            'user' => null,
        //            'query' => null,
        //            'fragment' => null,
        //        ],
        //    ],
        //];
        }
    }
}
