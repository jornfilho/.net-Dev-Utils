using System;
using System.Diagnostics;
using System.Text;

namespace DevUtils.Hash
{
    /// <summary>
    /// Base64 utils class
    /// </summary>
    public static class Base64
    {
        /// <summary>
        /// Convert string to base64 hash
        /// </summary>
        /// <param name="data">string to convert</param>
        /// <returns>base64 hash or null</returns>
        public static string ToBase64(this string data)
        {
            try
            {
                if (data == null)
                    return null;

                var plainTextBytes = Encoding.UTF8.GetBytes(data);
                return Convert.ToBase64String(plainTextBytes);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Convert hash base64 string to plain
        /// </summary>
        /// <param name="data">base64 string</param>
        /// <returns>plain string or null</returns>
        public static string FromBase64(this string data)
        {
            try
            {
                if (String.IsNullOrEmpty(data))
                    return data;

                var base64EncodedBytes = Convert.FromBase64String(data);
                return Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return data;
            }
        }
    }
}
