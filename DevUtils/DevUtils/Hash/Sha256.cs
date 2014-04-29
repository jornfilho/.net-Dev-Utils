using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DevUtils.Hash
{
    /// <summary>
    /// Sha256 utils class
    /// </summary>
    public static class Sha256
    {
        /// <summary>
        /// Convert string to sha256 hash
        /// </summary>
        /// <param name="data">string to convert</param>
        /// <returns>sha256 hash or null</returns>
        public static string ToSha256(this string data)
        {
            try
            {
                if (String.IsNullOrEmpty(data))
                    return null;

                var hashValue = new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(data));
                var hex = hashValue.Aggregate("", (current, x) => current + String.Format("{0:x2}", x));

                if (String.IsNullOrEmpty(hex))
                    throw new Exception("Erro creating SHA256 hash");

                return hex;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }
    }
}
