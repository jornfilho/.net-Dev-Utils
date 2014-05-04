using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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

        /// <summary>
        /// Compares two string objects ignoring case.
        /// </summary>
        /// <param name="valueCurrent">The current string used to compare against another string.</param>
        /// <param name="valueToCompare">The string to compare against the current string.</param>
        /// <returns>A value indicating if the strings are equal.</returns>
        public static bool CompareNoCase(this string valueCurrent, string valueToCompare)
        {
            try
            {
                return string.Compare(valueCurrent, valueToCompare, true, CultureInfo.CurrentCulture) == 0;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Determines if the current string is contained in the specified array
        /// of objects.
        /// </summary>
        /// <param name="valueCurrent">The current string used to compare against the array of objects.</param>
        /// <param name="values">The array of objects used compare against the current string.</param>
        /// <returns>A value indicating if the string is contained in the array of objects.</returns>
        public static bool ContainedIn(this string valueCurrent, object[] values)
        {
            try
            {
                if (valueCurrent == null || values == null) 
                    return false;

                return values.Any(value => valueCurrent.Contains(value.ToString()));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
            
        }

        /// <summary>
        /// Determines if the current string is contained in the specified list
        /// of objects.
        /// </summary>
        /// <param name="valueCurrent">The current string used to compare against the list of objects.</param>
        /// <param name="values">The list of objects used compare against the current string.</param>
        /// <returns>A value indicating if the string is contained in the list of objects.</returns>
        public static bool ContainedIn(this string valueCurrent, List<object> values)
        {
            try
            {
                if (valueCurrent == null || values == null) 
                    return false;

                return values.Any(value => valueCurrent.Contains(value.ToString()));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
            
        }

        /// <summary>
        /// Determines if the current string is contained in the specified list
        /// of strings.
        /// </summary>
        /// <param name="valueCurrent">The current string used to compare against the list of strings.</param>
        /// <param name="values">The list of strings used compare against the current string.</param>
        /// <returns>A value indicating if the string is contained in the list of strings.</returns>
        public static bool ContainedIn(this string valueCurrent, List<string> values)
        {
            try
            {
                if (valueCurrent == null || values == null) 
                    return false;

                return values.Any(valueCurrent.Contains);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating if the string ends with the specified
        /// substring for the current culture.
        /// </summary>
        /// <param name="valueCurrent">The current string to compare against a substring.</param>
        /// <param name="valueToCompare">The substring to compare against the current string.</param>
        /// <returns>A value indicating if the string ends with the specified substring.</returns>
        public static bool EndsWithCurrent(this string valueCurrent, string valueToCompare)
        {
            try
            {
                var endsWith = false;

                if (!string.IsNullOrWhiteSpace(valueToCompare) && valueCurrent != null)
                    endsWith = valueCurrent.EndsWith(valueToCompare, StringComparison.CurrentCulture);

                return endsWith;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating if the string ends with the specified
        /// substring for ordinal ignoring case.
        /// </summary>
        /// <param name="valueCurrent">The current string to compare against a substring.</param>
        /// <param name="valueToCompare">The substring to compare against the current string.</param>
        /// <returns>A value indicating if the string ends with the specified substring.</returns>
        public static bool EndsWithOrdinalIgnoreCase(this string valueCurrent, string valueToCompare)
        {
            try
            {
                var endsWith = false;

                if (!string.IsNullOrWhiteSpace(valueToCompare) && valueCurrent != null)
                    endsWith = valueCurrent.EndsWith(valueToCompare, StringComparison.OrdinalIgnoreCase);

                return endsWith;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Formats the string with the specified object for the current
        /// culture.
        /// </summary>
        /// <param name="format">The string to format.</param>
        /// <param name="arg0">The object in which to format in the string.</param>
        /// <returns>A formatted string with the object.</returns>
        public static string FormatCurrent(this string format, object arg0)
        {
            try
            {
                return string.Format(CultureInfo.CurrentCulture, format, arg0);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Formats the string with the specified objects for the current
        /// culture.
        /// </summary>
        /// <param name="format">The string to format.</param>
        /// <param name="arg0">The first object in which to format in the string.</param>
        /// <param name="arg1">The second object in which to format in the string.</param>
        /// <returns>A formatted string with the objects.</returns>
        public static string FormatCurrent(this string format, object arg0, object arg1)
        {
            try
            {
                return string.Format(CultureInfo.CurrentCulture, format, arg0, arg1);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Formats the string with the specified objects for the current
        /// culture.
        /// </summary>
        /// <param name="format">The string to format.</param>
        /// <param name="arg0">The first object in which to format in the string.</param>
        /// <param name="arg1">The second object in which to format in the string.</param>
        /// <param name="arg2">The third object in which to format in the string.</param>
        /// <returns>A formatted string with the objects.</returns>
        public static string FormatCurrent(this string format, object arg0, object arg1, object arg2)
        {
            try
            {
                return string.Format(CultureInfo.CurrentCulture, format, arg0, arg1, arg2);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Formats the string with the specified objects for the current
        /// culture.
        /// </summary>
        /// <param name="format">The string to format.</param>
        /// <param name="args">An array of objects in which to format in the string.</param>
        /// <returns>A formatted string with the objects.</returns>
        public static string FormatCurrent(this string format, params object[] args)
        {
            try
            {
                return string.Format(CultureInfo.CurrentCulture, format, args);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Formats the string with the specified object for an invariant
        /// culture.
        /// </summary>
        /// <param name="format">The string to format.</param>
        /// <param name="arg0">The object in which to format in the string.</param>
        /// <returns>A formatted string with the object.</returns>
        public static string FormatInvariant(this string format, object arg0)
        {
            try
            {
                return string.Format(CultureInfo.InvariantCulture, format, arg0);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Formats the string with the specified objects for an invariant
        /// culture.
        /// </summary>
        /// <param name="format">The string to format.</param>
        /// <param name="arg0">The first object in which to format in the string.</param>
        /// <param name="arg1">The second object in which to format in the string.</param>
        /// <returns>A formatted string with the objects.</returns>
        public static string FormatInvariant(this string format, object arg0, object arg1)
        {
            try
            {
                return string.Format(CultureInfo.InvariantCulture, format, arg0, arg1);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Formats the string with the specified objects for an invariant
        /// culture.
        /// </summary>
        /// <param name="format">The string to format.</param>
        /// <param name="arg0">The first object in which to format in the string.</param>
        /// <param name="arg1">The second object in which to format in the string.</param>
        /// <param name="arg2">The third object in which to format in the string.</param>
        /// <returns>A formatted string with the objects.</returns>
        public static string FormatInvariant(this string format, object arg0, object arg1, object arg2)
        {
            try
            {
                return string.Format(CultureInfo.InvariantCulture, format, arg0, arg1, arg2);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Formats the string with the specified objects for an invariant
        /// culture.
        /// </summary>
        /// <param name="format">The string to format.</param>
        /// <param name="args">An array of objects in which to format in the string.</param>
        /// <returns>A formatted string with the objects.</returns>
        public static string FormatInvariant(this string format, params object[] args)
        {
            try
            {
                return string.Format(CultureInfo.InvariantCulture, format, args);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Gets the indexes of all occurrences of the specified value in the
        /// string.
        /// </summary>
        /// <param name="valueCurrent">The current string in which to obtain all indexes of.</param>
        /// <param name="value">The value to seek for all occurrences of.</param>
        /// <returns>An enumerable containing all the indexes of the occurences of the value sought.</returns>
        public static IEnumerable<int> IndexOfAll(this string valueCurrent, string value)
        {
            try
            {
                return Regex.Matches(valueCurrent, value).Cast<Match>().Select(m => m.Index);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Gets the index of the first occurrence of the specified value in
        /// the string for the current culture.
        /// </summary>
        /// <param name="valueCurrent">The current string in which to obtain the index of.</param>
        /// <param name="value">The value to seek.</param>
        /// <returns>The index of the first occurrence of the specified value in the string.</returns>
        public static int IndexOfCurrent(this string valueCurrent, string value)
        {
            try
            {
                var index = -1;

                if (valueCurrent != null)
                    index = valueCurrent.IndexOf(value, StringComparison.CurrentCulture);

                return index;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return -1;
            }
        }

        /// <summary>
        /// Gets the index of the first occurrence of the specified value in
        /// the string for the current culture.
        /// </summary>
        /// <param name="valueCurrent">The current string in which to obtain the index of.</param>
        /// <param name="value">The value to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>The index of the first occurrence of the specified value in the string.</returns>
        public static int IndexOfCurrent(this string valueCurrent, string value, int startIndex)
        {
            try
            {
                var index = -1;

                if (valueCurrent != null)
                    index = valueCurrent.IndexOf(value, startIndex, StringComparison.CurrentCulture);

                return index;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return -1;
            }
        }

        /// <summary>
        /// Gets the index of the first occurrence of the specified value in
        /// the string for ordinal ignoring case.
        /// </summary>
        /// <param name="valueCurrent">The current string in which to obtain the index of.</param>
        /// <param name="value">The value to seek.</param>>
        /// <returns>The index of the first occurrence of the specified value in the string.</returns>
        public static int IndexOfOrdinalIgnoreCase(this string valueCurrent, string value)
        {
            try
            {
                var index = -1;

                if (valueCurrent != null)
                    index = valueCurrent.IndexOf(value, StringComparison.OrdinalIgnoreCase);

                return index;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return -1;
            }
        }

        /// <summary>
        /// Gets the index of the first occurrence of the specified value in
        /// the string for ordinal ignoring case.
        /// </summary>
        /// <param name="valueCurrent">The current string in which to obtain the index of.</param>
        /// <param name="value">The value to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>The index of the first occurrence of the specified value in the string.</returns>
        public static int IndexOfOrdinalIgnoreCase(this string valueCurrent, string value, int startIndex)
        {
            try
            {
                var index = -1;

                if (valueCurrent != null)
                    index = valueCurrent.IndexOf(value, startIndex, StringComparison.OrdinalIgnoreCase);

                return index;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return -1;
            }
        }

        /// <summary>
        /// Joins all elements in the specified list together separated
        /// by the specified delimiter.
        /// </summary>
        /// <param name="list">A list of elements.</param>
        /// <param name="separator">The separator for each element.</param>
        /// <returns>A joined string of all elements separated by a delimiter.</returns>
        public static string Join(this List<string> list, string separator)
        {
            try
            {
                if (list != null && list.Count > 0)
                    return string.Join(separator, list.ToArray());

                return null;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Joins all elements in the specified array together separated
        /// by the specified delimiter.
        /// </summary>
        /// <param name="array">An array of elements.</param>
        /// <param name="separator">The separator for each element.</param>
        /// <returns>A joined string of all elements separated by a delimiter.</returns>
        public static string Join(this string[] array, string separator)
        {
            try
            {
                if (array != null && array.Length > 0)
                    return string.Join(separator, array);

                return null;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Gets a value indicating if the string begins with the specified
        /// substring for the current culture.
        /// </summary>
        /// <param name="valueCurrent">The current string to compare against a substring.</param>
        /// <param name="valueToCompare">The substring to compare against the current string.</param>
        /// <returns>A value indicating if the string begins with the specified substring.</returns>
        public static bool StartsWithCurrent(this string valueCurrent, string valueToCompare)
        {
            try
            {
                var startsWith = false;

                if (!string.IsNullOrWhiteSpace(valueToCompare) && valueCurrent != null)
                    startsWith = valueCurrent.StartsWith(valueToCompare, StringComparison.CurrentCulture);

                return startsWith;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating if the string begins with the specified
        /// substring for ordinal ignoring case.
        /// </summary>
        /// <param name="valueCurrent">The current string to compare against a substring.</param>
        /// <param name="valueToCompare">The substring to compare against the current string.</param>
        /// <returns>A value indicating if the string begins with the specified substring.</returns>
        public static bool StartsWithOrdinalIgnoreCase(this string valueCurrent, string valueToCompare)
        {
            try
            {
                var startsWith = false;

                if (!string.IsNullOrWhiteSpace(valueToCompare) && valueCurrent != null)
                    startsWith = valueCurrent.StartsWith(valueToCompare, StringComparison.OrdinalIgnoreCase);

                return startsWith;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }
    }
}