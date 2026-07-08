using System;
using System.Collections.Generic;
using System.Text;
using Pchp.Core;

namespace Nextsharp.LibXml2
{
    [PhpExtension("nextsharp_uri")]
    public static class UriCompatFunctions
    {
        private sealed class UriParts
        {
            public string Scheme { get; set; }

            public string Host { get; set; }

            public string Path { get; set; }

            public int? Port { get; set; }

            public string User { get; set; }

            public string Pass { get; set; }

            public string Query { get; set; }

            public string Fragment { get; set; }
        }

        public static PhpValue nextsharp_uri_parse(string uri)
        {
            if (!ShouldOverrideParse(uri))
            {
                return PhpValue.Null;
            }

            return ToPhpArray(ParseUri(uri));
        }

        public static string nextsharp_uri_resolve(string basePath, string newPath)
        {
            if (!ShouldOverrideResolve(newPath))
            {
                return null;
            }

            var delta = ParseUri(newPath);
            if (delta.Scheme != null)
            {
                return BuildUri(delta);
            }

            var @base = ParseUri(basePath);

            if (delta.Fragment != null &&
                delta.Fragment.Length == 0 &&
                delta.Scheme == null &&
                delta.Host == null &&
                delta.Path == null &&
                delta.Query == null)
            {
                @base.Fragment = null;
                return BuildUri(@base);
            }

            var newParts = new UriParts
            {
                Scheme = delta.Scheme ?? @base.Scheme,
                Host = delta.Host ?? @base.Host,
                Port = delta.Port ?? @base.Port,
                User = delta.User ?? @base.User,
                Pass = delta.Pass ?? @base.Pass,
            };

            string path;
            if (!string.IsNullOrEmpty(delta.Path))
            {
                if (delta.Path[0] == '/')
                {
                    path = delta.Path;
                }
                else
                {
                    path = @base.Path ?? string.Empty;
                    var length = path.LastIndexOf('/');
                    if (length >= 0)
                    {
                        path = path.Substring(0, length);
                    }

                    path += "/" + delta.Path;
                }
            }
            else
            {
                path = @base.Path ?? "/";
                if (path.Length == 0)
                {
                    path = "/";
                }
            }

            var pathParts = path.Split('/');
            var newPathParts = new List<string>(pathParts.Length);
            foreach (var pathPart in pathParts)
            {
                switch (pathPart)
                {
                    case ".":
                        break;
                    case "..":
                        if (newPathParts.Count > 0)
                        {
                            newPathParts.RemoveAt(newPathParts.Count - 1);
                        }
                        break;
                    default:
                        newPathParts.Add(pathPart);
                        break;
                }
            }

            path = string.Join("/", newPathParts);
            newParts.Path = path.StartsWith("/", StringComparison.Ordinal) ? path : "/" + path;

            if (delta.Query != null && delta.Query.Length != 0)
            {
                newParts.Query = delta.Query;
            }
            else if (@base.Query != null && delta.Host == null && delta.Path == null)
            {
                newParts.Query = @base.Query;
            }

            if (delta.Fragment != null && delta.Fragment.Length != 0)
            {
                newParts.Fragment = delta.Fragment;
            }

            return BuildUri(newParts);
        }

        private static bool ShouldOverrideParse(string uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                return false;
            }

            foreach (var ch in uri)
            {
                if (ch > 127)
                {
                    return true;
                }
            }

            return uri.StartsWith("/", StringComparison.Ordinal) ||
                uri.Contains(":///", StringComparison.Ordinal) ||
                (uri.Contains("[", StringComparison.Ordinal) && uri.Contains("]", StringComparison.Ordinal));
        }

        private static bool ShouldOverrideResolve(string newPath)
        {
            return newPath.StartsWith("//", StringComparison.Ordinal) ||
                string.Equals(newPath, "#", StringComparison.Ordinal);
        }

        private static UriParts ParseUri(string uri)
        {
            var result = new UriParts();
            var working = uri ?? string.Empty;

            if (TryExtractScheme(ref working, out var scheme))
            {
                result.Scheme = scheme;
            }

            if (TryExtractFragment(ref working, out var fragment))
            {
                result.Fragment = fragment;
            }

            if (TryExtractQuery(ref working, out var query))
            {
                result.Query = query;
            }

            if (working.StartsWith("///", StringComparison.Ordinal))
            {
                result.Path = EncodeNonAscii(working.Substring(2));
                result.Host = string.Empty;
                return result;
            }

            if (working.StartsWith("//", StringComparison.Ordinal))
            {
                ParseAuthority(working.Substring(2), result);
                return result;
            }

            if (working.Length != 0)
            {
                result.Path = EncodeNonAscii(working);
            }

            return result;
        }

        private static void ParseAuthority(string authorityAndPath, UriParts result)
        {
            var slashIndex = authorityAndPath.IndexOf('/');
            string authority;
            if (slashIndex >= 0)
            {
                authority = authorityAndPath.Substring(0, slashIndex);
                result.Path = EncodeNonAscii(authorityAndPath.Substring(slashIndex));
            }
            else
            {
                authority = authorityAndPath;
            }

            if (authority.Length == 0)
            {
                return;
            }

            var atIndex = authority.LastIndexOf('@');
            if (atIndex >= 0)
            {
                var userInfo = authority.Substring(0, atIndex);
                authority = authority.Substring(atIndex + 1);

                var colonIndex = userInfo.IndexOf(':');
                if (colonIndex >= 0)
                {
                    result.User = userInfo.Substring(0, colonIndex);
                    result.Pass = userInfo.Substring(colonIndex + 1);
                }
                else
                {
                    result.User = userInfo;
                }
            }

            if (authority.StartsWith("[", StringComparison.Ordinal))
            {
                var bracketIndex = authority.IndexOf(']');
                if (bracketIndex >= 0)
                {
                    result.Host = authority.Substring(0, bracketIndex + 1);
                    if (authority.Length > bracketIndex + 2 && authority[bracketIndex + 1] == ':' &&
                        int.TryParse(authority.Substring(bracketIndex + 2), out var ipv6Port))
                    {
                        result.Port = ipv6Port;
                    }

                    return;
                }
            }

            var portSeparator = authority.LastIndexOf(':');
            if (portSeparator > 0 &&
                portSeparator < authority.Length - 1 &&
                int.TryParse(authority.Substring(portSeparator + 1), out var port))
            {
                result.Host = authority.Substring(0, portSeparator);
                result.Port = port;
            }
            else
            {
                result.Host = authority;
            }
        }

        private static bool TryExtractScheme(ref string uri, out string scheme)
        {
            scheme = null;
            var colonIndex = uri.IndexOf(':');
            if (colonIndex <= 0)
            {
                return false;
            }

            for (var i = 0; i < colonIndex; i++)
            {
                var ch = uri[i];
                if (i == 0)
                {
                    if (!char.IsLetter(ch))
                    {
                        return false;
                    }
                }
                else if (!char.IsLetterOrDigit(ch) && ch != '+' && ch != '-' && ch != '.')
                {
                    return false;
                }
            }

            scheme = uri.Substring(0, colonIndex);
            uri = uri.Substring(colonIndex + 1);
            return true;
        }

        private static bool TryExtractFragment(ref string uri, out string fragment)
        {
            fragment = null;
            var fragmentIndex = uri.IndexOf('#');
            if (fragmentIndex < 0)
            {
                return false;
            }

            fragment = uri.Substring(fragmentIndex + 1);
            uri = uri.Substring(0, fragmentIndex);
            return true;
        }

        private static bool TryExtractQuery(ref string uri, out string query)
        {
            query = null;
            var queryIndex = uri.IndexOf('?');
            if (queryIndex < 0)
            {
                return false;
            }

            query = uri.Substring(queryIndex + 1);
            uri = uri.Substring(0, queryIndex);
            return true;
        }

        private static string EncodeNonAscii(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            var builder = new StringBuilder(input.Length);
            foreach (var rune in input.EnumerateRunes())
            {
                if (rune.Value <= 0x7F)
                {
                    builder.Append(rune.ToString());
                }
                else
                {
                    builder.Append(Uri.EscapeDataString(rune.ToString()));
                }
            }

            return builder.ToString();
        }

        private static PhpArray ToPhpArray(UriParts parts)
        {
            var result = PhpArray.NewEmpty();
            result.Add("scheme", parts.Scheme is null ? PhpValue.Null : PhpValue.Create(parts.Scheme));
            result.Add("host", parts.Host is null ? PhpValue.Null : PhpValue.Create(parts.Host));
            result.Add("path", parts.Path is null ? PhpValue.Null : PhpValue.Create(parts.Path));
            result.Add("port", parts.Port.HasValue ? PhpValue.Create(parts.Port.Value) : PhpValue.Null);
            result.Add("user", parts.User is null ? PhpValue.Null : PhpValue.Create(parts.User));
            result.Add("pass", parts.Pass is null ? PhpValue.Null : PhpValue.Create(parts.Pass));
            result.Add("query", parts.Query is null ? PhpValue.Null : PhpValue.Create(parts.Query));
            result.Add("fragment", parts.Fragment is null ? PhpValue.Null : PhpValue.Create(parts.Fragment));
            return result;
        }

        private static string BuildUri(UriParts parts)
        {
            var uri = new StringBuilder();
            var authority = new StringBuilder();

            if (parts.Host != null)
            {
                authority.Append(parts.Host);
                if (parts.User != null)
                {
                    var userInfo = parts.User;
                    if (parts.Pass != null)
                    {
                        userInfo += ":" + parts.Pass;
                    }

                    authority.Insert(0, userInfo + "@");
                }

                if (parts.Port.HasValue)
                {
                    authority.Append(':').Append(parts.Port.Value);
                }
            }

            if (parts.Scheme != null)
            {
                uri.Append(parts.Scheme).Append(':');
            }

            if (authority.Length != 0 || string.Equals(parts.Scheme, "file", StringComparison.Ordinal))
            {
                uri.Append("//").Append(authority);
            }

            if (parts.Path != null)
            {
                uri.Append(parts.Path);
            }

            if (parts.Query != null)
            {
                uri.Append('?').Append(parts.Query);
            }

            if (parts.Fragment != null)
            {
                uri.Append('#').Append(parts.Fragment);
            }

            return uri.ToString();
        }
    }
}
