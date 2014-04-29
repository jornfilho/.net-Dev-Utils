using System;
using System.Diagnostics;
using System.Globalization;

namespace DevUtils.Hash
{
    /// <summary>
    /// Randon util class
    /// </summary>
    public static class GetRandom
    {
        /// <summary>
        /// Create randon hash with letter, number and symbols
        /// </summary>
        /// <param name="size">hash size</param>
        /// <returns>randon hash</returns>
        public static string CreateRandonHash(int size)
        {
            try
            {
                if (size <= 0)
                    return "";

                const string letters = "ABCDEFGHIJKLMNOPQRSTWXYZ";
                const string numbers = "0123456789";
                const string symbols = "~!@#$%^&*()_-+=[{]}|><,.?/";

                var hash = string.Empty;
                var rand = new Random();

                for (var cont = 0; cont < size; cont++)
                {
                    switch (rand.Next(0, 3))
                    {
                        case 1:
                            hash = hash + numbers[rand.Next(0, 10)];
                            break;
                        case 2:
                            hash = hash + symbols[rand.Next(0, 26)];
                            break;
                        default:
                            hash = hash + ((cont % 3 == 0)
                                ? letters[rand.Next(0, 24)].ToString(CultureInfo.InvariantCulture)
                                : (letters[rand.Next(0, 24)]).ToString(CultureInfo.InvariantCulture).ToLower());
                            break;
                    }
                }

                return hash;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }
    }
}
