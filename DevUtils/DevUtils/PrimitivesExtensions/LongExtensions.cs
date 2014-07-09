using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace DevUtils.PrimitivesExtensions
{
    /// <summary>
    /// Static long extension
    /// </summary>
    public static class LongExtensions
    {
        #region string
        /// <summary>
        /// Convert string value to long value
        /// </summary>
        /// <param name="strValue">string value to convert</param>
        /// <param name="defaultValue">default value when error on convert value</param>
        /// <param name="allowZero">allow zero on convert</param>
        /// <param name="numberStyle">string number style</param>
        /// <param name="culture">current culture</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this string strValue, long defaultValue, bool allowZero, NumberStyles numberStyle, CultureInfo culture)
        {
            long longValue;
            var converted = long.TryParse(strValue, numberStyle, culture, out longValue);

            return converted
                ? longValue == 0 && !allowZero
                    ? defaultValue
                    : longValue
                : defaultValue;
        }

        /// <summary>
        /// Convert string value to long value
        /// </summary>
        /// <param name="strValue">string value to convert</param>
        /// <param name="defaultValue">default value when error on convert value</param>
        /// <param name="numberStyle">string number style</param>
        /// <param name="culture">current culture</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this string strValue, long defaultValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseLong(defaultValue,
                BasePrimitivesExtensions.GetDefaultLongAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Convert string value to long value
        /// </summary>
        /// <param name="strValue">string value to convert</param>
        /// <param name="numberStyle">string number style</param>
        /// <param name="culture">current culture</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this string strValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseLong(BasePrimitivesExtensions.GetDefaultLongConversionValue(),
                BasePrimitivesExtensions.GetDefaultLongAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Convert string value to long value
        /// </summary>
        /// <param name="strValue">string value to convert</param>
        /// <param name="defaultValue">default value when error on convert value</param>
        /// <param name="allowZero">allow zero on convert</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this string strValue, long defaultValue, bool allowZero)
        {
            return strValue.TryParseLong(defaultValue, allowZero, 
                BasePrimitivesExtensions.GetDefaultLongNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Convert string value to long value
        /// </summary>
        /// <param name="strValue">string value to convert</param>
        /// <param name="defaultValue">default value when error on convert value</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this string strValue, long defaultValue)
        {
            return strValue.TryParseLong(defaultValue, 
                BasePrimitivesExtensions.GetDefaultLongAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultLongNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Convert string value to long value
        /// </summary>
        /// <param name="strValue">string value to convert</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this string strValue)
        {
            return strValue.TryParseLong(BasePrimitivesExtensions.GetDefaultLongConversionValue(),
                BasePrimitivesExtensions.GetDefaultLongAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultLongNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }
        #endregion

        #region nullable long
        /// <summary>
        /// Convert nullable long to long
        /// </summary>
        /// <param name="longValue">nullable long value</param>
        /// <param name="defaultValue">default value when error on convert</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this long? longValue, long defaultValue)
        {
            return longValue == null 
                ? defaultValue 
                : Convert.ToInt64(longValue);
        }

        /// <summary>
        /// Convert nullable long to long
        /// </summary>
        /// <param name="longValue">nullable long value</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this long? longValue)
        {
            return longValue.TryParseLong(BasePrimitivesExtensions.GetDefaultLongConversionValue());
        }
        #endregion

        #region byte
        /// <summary>
        /// <para>Convert byte value to long value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="byteValue">long value</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this byte byteValue)
        {
            return Convert.ToInt64(byteValue);
        }

        /// <summary>
        /// <para>Convert nullable byte value to long value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="byteValue">nullable byte value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this byte? byteValue, long defaultValue)
        {
            return byteValue == null
                ? defaultValue
                : Convert.ToInt64(byteValue);
        }

        /// <summary>
        /// Convert nullable byte value to long value
        /// </summary>
        /// <param name="byteValue">nullable byte value</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this byte? byteValue)
        {
            return byteValue.TryParseLong(BasePrimitivesExtensions.GetDefaultLongConversionValue());
        }
        #endregion

        #region short
        /// <summary>
        /// <para>Convert short value to long value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="shortValue">short value</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this short shortValue)
        {
            return Convert.ToInt64(shortValue);
        }

        /// <summary>
        /// <para>Convert nullable short value to long value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="shortValue">nullable short value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this short? shortValue, long defaultValue)
        {
            return shortValue == null
                ? defaultValue
                : Convert.ToInt64(shortValue);
        }

        /// <summary>
        /// Convert nullable short value to long value
        /// </summary>
        /// <param name="shortValue">nullable short value</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this short? shortValue)
        {
            return shortValue.TryParseLong(BasePrimitivesExtensions.GetDefaultLongConversionValue());
        }
        #endregion

        #region int
        /// <summary>
        /// <para>Convert int value to long value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="intValue">int value</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this int intValue)
        {
            return Convert.ToInt64(intValue);
        }

        /// <summary>
        /// <para>Convert nullable int value to long value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="intValue">nullable int value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this int? intValue, long defaultValue)
        {
            return intValue == null 
                ? defaultValue
                : Convert.ToInt64(intValue);
        }

        /// <summary>
        /// Convert nullable int value to long value
        /// </summary>
        /// <param name="intValue">nullable int value</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this int? intValue)
        {
            return intValue.TryParseLong(BasePrimitivesExtensions.GetDefaultLongConversionValue());
        }
        #endregion

        #region decimal
        /// <summary>
        /// <para>Convert decimal value to long value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="decimalValue">decimal value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this decimal decimalValue, long defaultValue)
        {
            try
            {
                if (decimalValue > long.MaxValue)
                    decimalValue = defaultValue;

                if (decimalValue < long.MinValue)
                    decimalValue = defaultValue;

                return Convert.ToInt64(decimalValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert decimal value to long value
        /// </summary>
        /// <param name="decimalValue">decimal value</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this decimal decimalValue)
        {
            return decimalValue.TryParseLong(BasePrimitivesExtensions.GetDefaultLongConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable decimal value to long value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="decimalValue">nullable decimal value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this decimal? decimalValue, long defaultValue)
        {
            try
            {
                if (decimalValue == null)
                    decimalValue = defaultValue;

                if (decimalValue > long.MaxValue)
                    decimalValue = defaultValue;

                if (decimalValue < long.MinValue)
                    decimalValue = defaultValue;

                return Convert.ToInt64(decimalValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable decimal value to long value
        /// </summary>
        /// <param name="decimalValue">nullable decimal value</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this decimal? decimalValue)
        {
            return decimalValue.TryParseLong(BasePrimitivesExtensions.GetDefaultLongConversionValue());
        }
        #endregion

        #region double
        /// <summary>
        /// <para>Convert double value to long value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="doubleValue">double value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this double doubleValue, long defaultValue)
        {
            try
            {
                if (doubleValue > long.MaxValue)
                    doubleValue = defaultValue;

                if (doubleValue < long.MinValue)
                    doubleValue = defaultValue;

                return Convert.ToInt64(doubleValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert double value to long value
        /// </summary>
        /// <param name="doubleValue">double value</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this double doubleValue)
        {
            return doubleValue.TryParseLong(BasePrimitivesExtensions.GetDefaultLongConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable double value to long value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="doubleValue">nullable double value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this double? doubleValue, long defaultValue)
        {
            try
            {
                if (doubleValue == null)
                    doubleValue = defaultValue;

                if (doubleValue > long.MaxValue)
                    doubleValue = defaultValue;

                if (doubleValue < long.MinValue)
                    doubleValue = defaultValue;

                return Convert.ToInt64(doubleValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable double value to long value
        /// </summary>
        /// <param name="doubleValue">nullable double value</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this double? doubleValue)
        {
            return doubleValue.TryParseLong(BasePrimitivesExtensions.GetDefaultLongConversionValue());
        }
        #endregion

        #region float
        /// <summary>
        /// <para>Convert float value to long value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="floatValue">float value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this float floatValue, long defaultValue)
        {
            try
            {
                if (floatValue > long.MaxValue)
                    floatValue = defaultValue;

                if (floatValue < long.MinValue)
                    floatValue = defaultValue;

                return Convert.ToInt64(floatValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert float value to long value
        /// </summary>
        /// <param name="floatValue">float value</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this float floatValue)
        {
            return floatValue.TryParseLong(BasePrimitivesExtensions.GetDefaultLongConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable float value to long value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="floatValue">nullable float value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this float? floatValue, long defaultValue)
        {
            try
            {
                if (floatValue == null)
                    floatValue = defaultValue;

                if (floatValue > long.MaxValue)
                    floatValue = defaultValue;

                if (floatValue < long.MinValue)
                    floatValue = defaultValue;

                return Convert.ToInt64(floatValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable float value to long value
        /// </summary>
        /// <param name="floatValue">nullable float value</param>
        /// <returns>long value</returns>
        public static long TryParseLong(this float? floatValue)
        {
            return floatValue.TryParseLong(BasePrimitivesExtensions.GetDefaultLongConversionValue());
        }
        #endregion

        #region object
        /// <summary>
        /// <para>Try parse object long to long value</para>
        /// </summary>
        /// <param name="objValue">object to convert</param>
        /// <param name="defaultValue">default return value</param>
        /// <returns>long result</returns>
        public static long TryParseLong(this object objValue, long defaultValue)
        {
            if (objValue == null)
                return defaultValue;

            try
            {
                return objValue.ToString().TryParseLong(defaultValue,
                BasePrimitivesExtensions.GetDefaultLongAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultLongNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// <para>Try parse long to long value</para>
        /// <para>Default value is BasePrimitivesExtensions.GetDefaultlongConversionValue() value</para>
        /// </summary>
        /// <param name="objValue">object to convert</param>
        /// <returns>long result</returns>
        public static long TryParseLong(this object objValue)
        {
            return objValue.TryParseLong(BasePrimitivesExtensions.GetDefaultLongConversionValue());
        }
        #endregion

        #region string to long array
        /// <summary>
        /// Parse string array in long array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <param name="allowDefaultConversion">Allow default tryparse values</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>long array</returns>
        public static long[] TryParseLongArray(this string strValue, long[] defaultValue, bool allowDefaultConversion, NumberStyles numberStyle, CultureInfo culture)
        {
            if (String.IsNullOrEmpty(strValue))
                return defaultValue ?? new long[] { };

            var intList = defaultValue != null
                ? defaultValue.ToList()
                : new List<long>();

            foreach (var l in strValue.Split(','))
            {
                var strInt = l ?? "";

                if (String.IsNullOrEmpty(strInt))
                {
                    if (allowDefaultConversion)
                        intList.Add(BasePrimitivesExtensions.GetDefaultLongConversionValue());

                    continue;
                }

                long intConvert;
                if (!long.TryParse(strInt, numberStyle, culture, out intConvert))
                {
                    if (allowDefaultConversion)
                        intList.Add(BasePrimitivesExtensions.GetDefaultLongConversionValue());
                }
                else
                    intList.Add(intConvert);

            }

            return intList.ToArray();
        }

        /// <summary>
        /// Parse string array in long array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>long array</returns>
        public static long[] TryParseLongArray(this string strValue, long[] defaultValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseLongArray(defaultValue,
                BasePrimitivesExtensions.GetDefaultLongArrayAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Parse string array in long array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>long array</returns>
        public static long[] TryParseLongArray(this string strValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseLongArray(null,
                BasePrimitivesExtensions.GetDefaultLongArrayAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Parse string array in long array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <param name="allowDefaultConversion">Allow default tryparse values</param>
        /// <returns>long array</returns>
        public static long[] TryParseLongArray(this string strValue, long[] defaultValue, bool allowDefaultConversion)
        {
            return strValue.TryParseLongArray(defaultValue, allowDefaultConversion,
                BasePrimitivesExtensions.GetDefaultLongNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Parse string array in long array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <returns>long array</returns>
        public static long[] TryParseLongArray(this string strValue, long[] defaultValue)
        {
            return strValue.TryParseLongArray(defaultValue,
                BasePrimitivesExtensions.GetDefaultLongArrayAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultLongNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Parse string array in short long
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <returns>long array</returns>
        public static long[] TryParseLongArray(this string strValue)
        {
            return strValue.TryParseLongArray(null,
                BasePrimitivesExtensions.GetDefaultLongArrayAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultLongNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }
        #endregion

        #region IsValidLong
        /// <summary>
        /// Test if string value is a valid long value
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>true/false</returns>
        public static bool IsValidLong(this string strValue, NumberStyles numberStyle, CultureInfo culture)
        {
            try
            {
                var baseValue = strValue == "1" ? 2 : 1;
                var convertedValue = strValue.TryParseLong(baseValue, true, numberStyle, culture);
                return convertedValue != baseValue;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return false;
        }

        /// <summary>
        /// Test if string value is a valid long value
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <returns>true/false</returns>
        public static bool IsValidLong(this string strValue)
        {
            return strValue.IsValidLong(
                BasePrimitivesExtensions.GetDefaultLongNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }
        #endregion
    }
}
