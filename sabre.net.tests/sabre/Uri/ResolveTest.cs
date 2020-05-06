using NUnit.Framework;
using Pchp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sabre.net.tests.sabre.Uri
{
    class ResolveTest
    {
        protected Sabre.Uri.UriFunctions func;
        [SetUp]
        public void Setup()
        {
            func = new Sabre.Uri.UriFunctions();
        }
        /**
     * @dataProvider resolveData
     *
     * @param string $base
     * @param string $update
     * @param string $expected
     *
     * @throws InvalidUriException
     */
        [Test, TestCaseSource("resolveData")]
    public void testResolve(string @base, string update, string expected)
    {
            Assert.AreEqual(expected, func.resolve(@base, update));
        }
           /**
     * @return array<int, array<int, string>>
     */
    public static IEnumerable<string[]>  resolveData()
    {
            var rootNode = PhpArray.NewEmpty();
            rootNode.Add(PhpArray.New("http://example.org/foo/baz","/bar","http://example.org/bar"));
            rootNode.Add(PhpArray.New("https://example.org/foo","//example.net/","https://example.net/"));
            rootNode.Add(PhpArray.New("https://example.org/foo","?a=b","https://example.org/foo?a=b"));
            rootNode.Add(PhpArray.New("//example.org/foo","?a=b","//example.org/foo?a=b"));
            // Ports and fragments
             rootNode.Add(PhpArray.New("https://example.org:81/foo#hey","?a=b#c=d","https://example.org:81/foo?a=b#c=d"));
             // Relative.. in-directory paths
             rootNode.Add(PhpArray.New("http://example.org/foo/bar","bar2","http://example.org/foo/bar2"));
            // Now the base path ended with a slash
            rootNode.Add(PhpArray.New("http://example.org/foo/bar/","bar2/bar3","http://example.org/foo/bar/bar2/bar3"));
            // .. and .
            rootNode.Add(PhpArray.New("http://example.org/foo/bar/","../bar2/.././/bar3/","http://example.org/foo//bar3/"));
            // Only updating the fragment
            rootNode.Add(PhpArray.New("https://example.org/foo?a=b","#comments","https://example.org/foo?a=b#comments"));
            // Switching to mailto!
            rootNode.Add(PhpArray.New("https://example.org/foo?a=b","mailto:foo@example.org","mailto:foo@example.org"));
            // Resolving empty path
            rootNode.Add(PhpArray.New("http://www.example.org","#foo","http://www.example.org/#foo"));
            // Another fragment test
            rootNode.Add(PhpArray.New("http://example.org/path.json","#","http://example.org/path.json"));
            rootNode.Add(PhpArray.New("http://www.example.com","#","http://www.example.com"));
            rootNode.Add(PhpArray.New("http://www.example.org","#foo","http://www.example.org/#foo"));
            // Another fragment test
            rootNode.Add(PhpArray.New("http://example.org/path.json","#","http://example.org/path.json"));
            // Allow to use 0 in path
            rootNode.Add(PhpArray.New("http://example.org/","0","http://example.org/0"));
            foreach(var node in rootNode)
            {
                yield return new []{node.Value.AsArray()[0].String, node.Value.AsArray()[1].String, node.Value.AsArray()[2].String};
            }
    }
    }
}
