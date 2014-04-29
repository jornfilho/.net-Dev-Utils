using System;
using System.Globalization;
using System.Text;

namespace DevUtils.PrimitivesExtensions
{
    /// <summary>
    /// Static string extensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// <para>Normalize string to unicode</para>
        /// <para>Remove special characters</para>
        /// </summary>
        /// <param name="text">string to normalize</param>
        /// <returns>unicode string</returns>
        public static string ToUnicode(this string text)
        {
            var sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();

            foreach (var letter in arrayText)
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);

            return String.IsNullOrEmpty(text) 
                ? text 
                : sbReturn.ToString();
        }

        /// <summary>
        /// <para>Remove all spaces and normalize string to unicode</para>
        /// <para>Remove special characters</para>
        /// <para>Convert space to underscore</para>
        /// </summary>
        /// <param name="text">strign to normalize</param>
        /// <returns>unicode strings without spaces</returns>
        public static string ToUnicodeWithoutSpace(this string text)
        {
            return String.IsNullOrEmpty(text) 
                ? text
                : text.ToUnicode().Replace(" ", "_");
        }

        /// <summary>
        /// Get first N characters from string
        /// </summary>
        /// <param name="text">string text</param>
        /// <param name="length">characters length</param>
        /// <returns>first N characters</returns>
        public static string Left(this string text, int length)
        {
            if (String.IsNullOrEmpty(text))
                return text;

            return text.Length <= length 
                ? text 
                : text.Substring(0, length);
        }

        /// <summary>
        /// Get last N characters from string
        /// </summary>
        /// <param name="text">string text</param>
        /// <param name="length">characters length</param>
        /// <returns>last N characters</returns>
        public static string Right(this string text, int length)
        {
            if (String.IsNullOrEmpty(text))
                return text;

            return text.Length <= length
               ? text
               : text.Substring(text.Length - length, length);
        }
    }
}