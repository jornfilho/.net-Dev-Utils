using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DevUtils.Validators
{
    /// <summary>
    /// Email validator class
    /// </summary>
    public static class Email
    {
        /// <summary>
        /// Validate an email
        /// </summary>
        /// <param name="email">email to validate</param>
        /// <returns>is valid email</returns>
        public static bool IsEmailValid(this string email)
        {
            try
            {
                if (String.IsNullOrEmpty(email))
                    return false;

                var rg = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
                return rg.IsMatch(email);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }
    }
}
