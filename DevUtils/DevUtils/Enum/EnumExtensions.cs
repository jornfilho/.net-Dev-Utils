﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace DevUtils.Enum
{
    /// <summary>
    /// <para>The <c>EnumExtensions</c> type provides extension methods for
    /// enumerations.</para>
    /// <para>Base project reference: https://github.com/cjaehnen/OpenLib.Extensions </para>
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Converts the current enumeration to the specified enumeration type.
        /// </summary>
        /// <typeparam name="T">The type of the enumeration to convert to.</typeparam>
        /// <param name="enumeration">The current enumeration in which to convert.</param>
        /// <returns>The converted enumeration type.</returns>
        public static T ToEnum<T>(this System.Enum enumeration)
        {
            try
            {
                return (T)System.Enum.Parse(typeof(T), enumeration.ToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return default(T);
            }
        }

        /// <summary>
        /// Converts the current enumerated string to the specified enumeration
        /// type.
        /// </summary>
        /// <typeparam name="T">The type of enumeration to convert to.</typeparam>
        /// <param name="enumeration">The current enumerated string in which to convert.</param>
        /// <returns>The converted enumeration.</returns>
        public static T ToEnum<T>(this string enumeration)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(enumeration))
                    return (T)System.Enum.Parse(typeof(T), enumeration);

                return Activator.CreateInstance<T>();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return default(T);
            }
        }

        /// <summary>
        /// Converts the current 32-bit integer value to its enumeration
        /// equivalent.
        /// </summary>
        /// <param name="value">The current 32-bit integer value in which to convert.</param>
        /// <returns>The enumeration equivalent of the 32-bit integer value.</returns>
        public static T ToEnum<T>(this int value)
        {
            try
            {
                return (T)System.Enum.ToObject(typeof(T), value);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return default(T);
            }
        }

        /// <summary>
        /// Converts the enum instance to IList with all anum options.
        /// </summary>
        /// <param name="value">Enum to convert.</param>
        /// <returns>The IList with equivalent enumeration option.</returns>
        public static IList<T> FromEnum<T>(this T value)
        {
            try
            {
                return System.Enum.GetValues(typeof (T))
                    .Cast<T>()
                    .Select(v => v)
                    .ToList();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return new T[]{};
            }
        }

        /// <summary>
        /// Converts the current enumeration to its 32-bit integer value.
        /// </summary>
        /// <param name="enumeration">The current enumeration in which to convert.</param>
        /// <returns>The 32-bit integer value of the enumeration.</returns>
        public static int FromEnumToInt(this System.Enum enumeration)
        {
            try
            {
                return Convert.ToInt32(enumeration);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return 0;
            }
        }

        /// <summary>
        /// Converts the current enumeration to its string value.
        /// </summary>
        /// <param name="enumeration">The current enumeration in which to convert.</param>
        /// <returns>The string value of the enumeration.</returns>
        public static string FromEnumToString(this System.Enum enumeration)
        {
            try
            {
                return FromEnumToInt(enumeration).ToString(CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }
    }
}
