using NUnit.Framework;
using Pchp.Core;
using sabre.net.bridge;
using Sabre.Uri;
using System.Collections.Generic;

namespace sabre.net.tests.sabre.Uri
{
    class ParseTest
    {
        protected Sabre.Uri.UriFunctions func;
        [SetUp]
        public void Setup()
        {
            func = new Sabre.Uri.UriFunctions();
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
            var actualOutput = func.parse(input).ToUri();
            Assert.AreEqual(output.ToUri(), actualOutput);
    }
         /**
     * @dataProvider parseData
     *
     * @param string $in
     * @param string $out
     */
          [Test, TestCaseSource("parseData1")]
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
        [ExpectedException(typeof(InvalidUriException))]
         public void testParseFallbackShouldThrowInvalidUriException()
    {
        // this.func._parse_fallback("ssh://invalid::7000/hello?foo=bar#test");
    }
        [Test]
        [ExpectedExceptionMessage("Invalid, or could not parse URI")]
         public void testParseFallbackShouldThrowInvalidUriExceptionMsg()
            {
            // this.func._parse_fallback("ssh://invalid::7000/hello?foo=bar#test");
            }
        public static IEnumerable<object[]> parseData1()
        {
            var result = new List<object[]>();
            var actualResult = PhpArray.NewEmpty();
            actualResult.Add("scheme", "http");
            actualResult.Add("host", "example.org");
            actualResult.Add("path", "/hello");
            actualResult.Add("port", 0);
            actualResult.Add("user", PhpValue.Null);
            actualResult.Add("query", "foo=bar");
            actualResult.Add("fragment", "test");
            result.Add(new object[]{ "http://example.org/hello?foo=bar#test",  actualResult});
                    //        'http://example.org/有词法别名.zh',
        //        [
        //            'scheme' => 'http',
        //            'host' => 'example.org',
        //            'path' => '/%E6%9C%89%E8%AF%8D%E6%B3%95%E5%88%AB%E5%90%8D.zh',
        //            'port' => null,
        //            'user' => null,
        //            'query' => null,
        //            'fragment' => null,
        //        ],
                    var actualResult1 = PhpArray.NewEmpty();
            actualResult1.Add("scheme", "http");
            actualResult1.Add("host", "example.org");
            actualResult1.Add("path", "/%E6%9C%89%E8%AF%8D%E6%B3%95%E5%88%AB%E5%90%8D.zh");
            actualResult1.Add("port", 0);
            actualResult1.Add("user", PhpValue.Null);
            actualResult1.Add("query", PhpValue.Null);
            actualResult1.Add("fragment", PhpValue.Null);
            result.Add(new object[]{ "http://example.org/有词法别名.zh",  actualResult1});
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
