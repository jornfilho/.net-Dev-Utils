using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace DevUtils.Hash
{
    /// <summary>
    /// Md5 utils class
    /// </summary>
    public static class Md5
    {
        /// <summary>
        /// Convert string to md5 hash
        /// </summary>
        /// <param name="data">string to convert</param>
        /// <returns>md5 hash or null</returns>
        public static string ToMd5(this string data)
        {
            try
            {
                if (data == null)
                    return null;

                var md5 = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(data));
                var sbString = new StringBuilder();
                foreach (var t in md5)
                    sbString.Append(t.ToString("x2"));

                if (String.IsNullOrEmpty(sbString.ToString()))
                    throw new Exception("Erro creating MD5 hash");

                return sbString.ToString();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }
    }
}
