using System;
using System.Diagnostics;
using System.Text;

namespace DevUtils.Database.SqlServer
{
    /// <summary>
    /// Sql server utils
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// <para>Escape string to search on sql server database</para>
        /// <para>http://msdn.microsoft.com/en-us/library/ms179859.aspx</para>
        /// </summary>
        /// <param name="str">String to escape</param>
        /// <returns>Escaped string</returns>
        public static string EscapeString(this string str)
        {
            try
            {
                if (String.IsNullOrEmpty(str) || String.IsNullOrWhiteSpace(str))
                    return str;

                var sb = new StringBuilder();
                foreach (char c in str)
                {
                    if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                        sb.Append(c);
                    else
                        sb.Append("[" + c + "]");
                }

                return sb.ToString();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return str;
            }
        }
    }
}
