using System;

namespace DevUtils.Validators
{
    /// <summary>
    /// Uri class urils
    /// </summary>
    public static class Url
    {
        /// <summary>
        /// Validate an uri
        /// </summary>
        /// <param name="uri">uri to validate</param>
        /// <returns>is valid uri</returns>
        public static bool IsUriValid(this string uri)
        {
            if (String.IsNullOrEmpty(uri))
                return false;

            if (uri.IndexOf(".", StringComparison.OrdinalIgnoreCase) == -1)
                return false;

            //http://msdn.microsoft.com/en-us/library/system.uri.scheme(v=vs.110).aspx
            var schemes = new[]
            {
                "file",
                "ftp",
                "gopher",
                "http",
                "https",
                "ldap",
                "mailto",
                "net.pipe",
                "net.tcp",
                "news",
                "nntp",
                "telnet",
                "uuid"
            };

            var hasValidSchema = false;
            foreach (var s in schemes)
            {
                if (hasValidSchema)
                    continue;

                if (uri.StartsWith(s, StringComparison.OrdinalIgnoreCase))
                    hasValidSchema = true;
            }

            if (!hasValidSchema)
                uri = "http://" + uri;

            return Uri.IsWellFormedUriString(uri, UriKind.Absolute);
        }
    }
}
