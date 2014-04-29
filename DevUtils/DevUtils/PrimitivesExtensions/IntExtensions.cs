using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace DevUtils.PrimitivesExtensions
{
    /// <summary>
    /// Static int extension
    /// </summary>
    public static class IntExtensions
    {
        #region string
        /// <summary>
        /// Convert string value to int value
        /// </summary>
        /// <param name="strValue">string value to convert</param>
        /// <param name="defaultValue">default value when error on convert value</param>
        /// <param name="allowZero">allow zero on convert</param>
        /// <param name="numberStyle">string number style</param>
        /// <param name="culture">current culture</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this string strValue, int defaultValue, bool allowZero, NumberStyles numberStyle, CultureInfo culture)
        {
            int intValue;
            var converted = int.TryParse(strValue, numberStyle, culture, out intValue);

            return converted
                ? intValue == 0 && !allowZero
                    ? defaultValue
                    : intValue
                : defaultValue;
        }

        /// <summary>
        /// Convert string value to int value
        /// </summary>
        /// <param name="strValue">string value to convert</param>
        /// <param name="defaultValue">default value when error on convert value</param>
        /// <param name="numberStyle">string number style</param>
        /// <param name="culture">current culture</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this string strValue, int defaultValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseInt(defaultValue,
                BasePrimitivesExtensions.GetDefaultIntAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Convert string value to int value
        /// </summary>
        /// <param name="strValue">string value to convert</param>
        /// <param name="numberStyle">string number style</param>
        /// <param name="culture">current culture</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this string strValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseInt(BasePrimitivesExtensions.GetDefaultIntConversionValue(),
                BasePrimitivesExtensions.GetDefaultIntAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Convert string value to int value
        /// </summary>
        /// <param name="strValue">string value to convert</param>
        /// <param name="defaultValue">default value when error on convert value</param>
        /// <param name="allowZero">allow zero on convert</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this string strValue, int defaultValue, bool allowZero)
        {
            return strValue.TryParseInt(defaultValue, allowZero, 
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Convert string value to int value
        /// </summary>
        /// <param name="strValue">string value to convert</param>
        /// <param name="defaultValue">default value when error on convert value</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this string strValue, int defaultValue)
        {
            return strValue.TryParseInt(defaultValue, 
                BasePrimitivesExtensions.GetDefaultIntAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Convert string value to int value
        /// </summary>
        /// <param name="strValue">string value to convert</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this string strValue)
        {
            return strValue.TryParseInt(BasePrimitivesExtensions.GetDefaultIntConversionValue(),
                BasePrimitivesExtensions.GetDefaultIntAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }
        #endregion

        #region nullable int
        /// <summary>
        /// Convert nullable int to int
        /// </summary>
        /// <param name="intValue">nullable int value</param>
        /// <param name="defaultValue">default value when error on convert</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this int? intValue, int defaultValue)
        {
            return intValue == null 
                ? defaultValue 
                : Convert.ToInt32(intValue);
        }

        /// <summary>
        /// Convert nullable int to int
        /// </summary>
        /// <param name="intValue">nullable int value</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this int? intValue)
        {
            return intValue.TryParseInt(BasePrimitivesExtensions.GetDefaultIntConversionValue());
        }
        #endregion

        #region byte
        /// <summary>
        /// <para>Convert byte value to int value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="byteValue">int value</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this byte byteValue)
        {
            return Convert.ToInt32(byteValue);
        }

        /// <summary>
        /// <para>Convert nullable byte value to int value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="byteValue">nullable byte value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this byte? byteValue, int defaultValue)
        {
            return byteValue == null
                ? defaultValue
                : Convert.ToInt32(byteValue);
        }

        /// <summary>
        /// Convert nullable byte value to int value
        /// </summary>
        /// <param name="byteValue">nullable byte value</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this byte? byteValue)
        {
            return byteValue.TryParseInt(BasePrimitivesExtensions.GetDefaultIntConversionValue());
        }
        #endregion

        #region short
        /// <summary>
        /// <para>Convert short value to int value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="shortValue">short value</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this short shortValue)
        {
            return Convert.ToInt32(shortValue);
        }

        /// <summary>
        /// <para>Convert nullable short value to int value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="shortValue">nullable short value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this short? shortValue, int defaultValue)
        {
            return shortValue == null
                ? defaultValue
                : Convert.ToInt32(shortValue);
        }

        /// <summary>
        /// Convert nullable short value to int value
        /// </summary>
        /// <param name="shortValue">nullable short value</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this short? shortValue)
        {
            return shortValue.TryParseInt(BasePrimitivesExtensions.GetDefaultIntConversionValue());
        }
        #endregion

        #region long
        /// <summary>
        /// <para>Convert long value to int value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="longValue">long value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this long longValue, int defaultValue)
        {
            try
            {
                if (longValue > int.MaxValue)
                    longValue = defaultValue;

                if (longValue < int.MinValue)
                    longValue = defaultValue;

                return Convert.ToInt32(longValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert long value to int value
        /// </summary>
        /// <param name="longValue">long value</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this long longValue)
        {
            return longValue.TryParseInt(BasePrimitivesExtensions.GetDefaultIntConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable long value to int value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="longValue">nullable long value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this long? longValue, int defaultValue)
        {
            try
            {
                if (longValue == null)
                    longValue = defaultValue;

                if (longValue > int.MaxValue)
                    longValue = defaultValue;

                if (longValue < int.MinValue)
                    longValue = defaultValue;

                return Convert.ToInt32(longValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable long value to int value
        /// </summary>
        /// <param name="longValue">nullable long value</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this long? longValue)
        {
            return longValue.TryParseInt(BasePrimitivesExtensions.GetDefaultIntConversionValue());
        }
        #endregion

        #region decimal
        /// <summary>
        /// <para>Convert decimal value to int value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="decimalValue">decimal value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this decimal decimalValue, int defaultValue)
        {
            try
            {
                if (decimalValue > int.MaxValue)
                    decimalValue = defaultValue;

                if (decimalValue < int.MinValue)
                    decimalValue = defaultValue;

                return Convert.ToInt32(decimalValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert decimal value to int value
        /// </summary>
        /// <param name="decimalValue">decimal value</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this decimal decimalValue)
        {
            return decimalValue.TryParseInt(BasePrimitivesExtensions.GetDefaultIntConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable decimal value to int value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="decimalValue">nullable decimal value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this decimal? decimalValue, int defaultValue)
        {
            try
            {
                if (decimalValue == null)
                    decimalValue = defaultValue;

                if (decimalValue > int.MaxValue)
                    decimalValue = defaultValue;

                if (decimalValue < int.MinValue)
                    decimalValue = defaultValue;

                return Convert.ToInt32(decimalValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable decimal value to int value
        /// </summary>
        /// <param name="decimalValue">nullable decimal value</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this decimal? decimalValue)
        {
            return decimalValue.TryParseInt(BasePrimitivesExtensions.GetDefaultIntConversionValue());
        }
        #endregion

        #region double
        /// <summary>
        /// <para>Convert double value to int value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="doubleValue">double value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this double doubleValue, int defaultValue)
        {
            try
            {
                if (doubleValue > int.MaxValue)
                    doubleValue = defaultValue;

                if (doubleValue < int.MinValue)
                    doubleValue = defaultValue;

                return Convert.ToInt32(doubleValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert double value to int value
        /// </summary>
        /// <param name="doubleValue">double value</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this double doubleValue)
        {
            return doubleValue.TryParseInt(BasePrimitivesExtensions.GetDefaultIntConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable double value to int value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="doubleValue">nullable double value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this double? doubleValue, int defaultValue)
        {
            try
            {
                if (doubleValue == null)
                    doubleValue = defaultValue;

                if (doubleValue > int.MaxValue)
                    doubleValue = defaultValue;

                if (doubleValue < int.MinValue)
                    doubleValue = defaultValue;

                return Convert.ToInt32(doubleValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable double value to int value
        /// </summary>
        /// <param name="doubleValue">nullable double value</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this double? doubleValue)
        {
            return doubleValue.TryParseInt(BasePrimitivesExtensions.GetDefaultIntConversionValue());
        }
        #endregion

        #region float
        /// <summary>
        /// <para>Convert float value to int value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="floatValue">float value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this float floatValue, int defaultValue)
        {
            try
            {
                if (floatValue > int.MaxValue)
                    floatValue = defaultValue;

                if (floatValue < int.MinValue)
                    floatValue = defaultValue;

                return Convert.ToInt32(floatValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert float value to int value
        /// </summary>
        /// <param name="floatValue">float value</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this float floatValue)
        {
            return floatValue.TryParseInt(BasePrimitivesExtensions.GetDefaultIntConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable float value to int value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="floatValue">nullable float value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this float? floatValue, int defaultValue)
        {
            try
            {
                if (floatValue == null)
                    floatValue = defaultValue;

                if (floatValue > int.MaxValue)
                    floatValue = defaultValue;

                if (floatValue < int.MinValue)
                    floatValue = defaultValue;

                return Convert.ToInt32(floatValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable float value to int value
        /// </summary>
        /// <param name="floatValue">nullable float value</param>
        /// <returns>int value</returns>
        public static int TryParseInt(this float? floatValue)
        {
            return floatValue.TryParseInt(BasePrimitivesExtensions.GetDefaultIntConversionValue());
        }
        #endregion

        #region string to int array
        /// <summary>
        /// Parse string array in int array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <param name="allowDefaultConversion">Allow default tryparse values</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>int array</returns>
        public static int[] TryParseIntArray(this string strValue, int[] defaultValue, bool allowDefaultConversion, NumberStyles numberStyle, CultureInfo culture)
        {
            if (String.IsNullOrEmpty(strValue))
                return defaultValue ?? new int[] { };

            var intList = defaultValue != null
                ? defaultValue.ToList()
                : new List<int>();

            foreach (var l in strValue.Split(','))
            {
                var strInt = l ?? "";

                if (String.IsNullOrEmpty(strInt))
                {
                    if (allowDefaultConversion)
                        intList.Add(BasePrimitivesExtensions.GetDefaultIntConversionValue());

                    continue;
                }

                int intConvert;
                if (!int.TryParse(strInt, numberStyle, culture, out intConvert))
                {
                    if (allowDefaultConversion)
                        intList.Add(BasePrimitivesExtensions.GetDefaultIntConversionValue());
                }
                else
                    intList.Add(intConvert);

            }

            return intList.ToArray();
        }

        /// <summary>
        /// Parse string array in int array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>int array</returns>
        public static int[] TryParseIntArray(this string strValue, int[] defaultValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseIntArray(defaultValue,
                BasePrimitivesExtensions.GetDefaultIntArrayAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Parse string array in int array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>int array</returns>
        public static int[] TryParseIntArray(this string strValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseIntArray(null,
                BasePrimitivesExtensions.GetDefaultIntArrayAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Parse string array in int array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <param name="allowDefaultConversion">Allow default tryparse values</param>
        /// <returns>int array</returns>
        public static int[] TryParseIntArray(this string strValue, int[] defaultValue, bool allowDefaultConversion)
        {
            return strValue.TryParseIntArray(defaultValue, allowDefaultConversion,
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Parse string array in int array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <returns>int array</returns>
        public static int[] TryParseIntArray(this string strValue, int[] defaultValue)
        {
            return strValue.TryParseIntArray(defaultValue,
                BasePrimitivesExtensions.GetDefaultIntArrayAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Parse string array in short int
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <returns>int array</returns>
        public static int[] TryParseIntArray(this string strValue)
        {
            return strValue.TryParseIntArray(null,
                BasePrimitivesExtensions.GetDefaultIntArrayAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }
        #endregion

        #region IsValidInt
        /// <summary>
        /// Test if string value is a valid int value
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>true/false</returns>
        public static bool IsValidInt(this string strValue, NumberStyles numberStyle, CultureInfo culture)
        {
            try
            {
                var baseValue = strValue == "1" ? 2 : 1;
                var convertedValue = strValue.TryParseInt(baseValue, true, numberStyle, culture);
                return convertedValue != baseValue;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return false;
        }

        /// <summary>
        /// Test if string value is a valid int value
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <returns>true/false</returns>
        public static bool IsValidInt(this string strValue)
        {
            return strValue.IsValidInt(
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }
        #endregion
    }
}
