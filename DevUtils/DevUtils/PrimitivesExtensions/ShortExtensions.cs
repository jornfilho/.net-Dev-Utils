using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace DevUtils.PrimitivesExtensions
{
    /// <summary>
    /// Static short extension
    /// </summary>
    public static class ShortExtensions
    {
        #region string
        /// <summary>
        /// <para>Convert string to short</para>
        /// <para>Set default value on error</para>
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <param name="defaultValue">default value</param>
        /// <param name="allowZero">allow 0 on convert.</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>converted value or default value</returns>
        public static short TryParseShort(this string strValue, short defaultValue, bool allowZero, NumberStyles numberStyle, CultureInfo culture)
        {
            short shortValue;
            var converted = short.TryParse(strValue, numberStyle, culture, out shortValue);

            return converted
                ? shortValue == 0 && !allowZero
                    ? defaultValue
                    : shortValue
                : defaultValue;
        }

        /// <summary>
        /// <para>Convert string to short</para>
        /// <para>set default value on error</para>
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <param name="defaultValue">default value</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>converted value or default value</returns>
        public static short TryParseShort(this string strValue, short defaultValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseShort(defaultValue,
                BasePrimitivesExtensions.GetDefaultShortAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Convert string to short
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>converted value or BasePrimitivesExtensions.GetDefaultShortConversionValue value</returns>
        public static short TryParseShort(this string strValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseShort(BasePrimitivesExtensions.GetDefaultShortConversionValue(),
                BasePrimitivesExtensions.GetDefaultShortAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// <para>Convert string to short</para>
        /// <para>Set default value on error</para>
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <param name="defaultValue">default value</param>
        /// <param name="allowZero">allow 0 on convert.</param>
        /// <returns>converted value or default value</returns>
        public static short TryParseShort(this string strValue, short defaultValue, bool allowZero)
        {
            return strValue.TryParseShort(defaultValue, allowZero,
                BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// <para>Convert string to short</para>
        /// <para>set default value on error</para>
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>converted value or default value</returns>
        public static short TryParseShort(this string strValue, short defaultValue)
        {
            return strValue.TryParseShort(defaultValue,
                BasePrimitivesExtensions.GetDefaultShortAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Convert string to short
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <returns>converted value or BasePrimitivesExtensions.GetDefaultShortConversionValue value</returns>
        public static short TryParseShort(this string strValue)
        {
            return strValue.TryParseShort(BasePrimitivesExtensions.GetDefaultShortConversionValue(),
                BasePrimitivesExtensions.GetDefaultShortAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }
        #endregion

        #region nullable short
        /// <summary>
        /// Convert nullable short to short
        /// </summary>
        /// <param name="shortValue">nullable shortValue value</param>
        /// <param name="defaultValue">default value when error on convert</param>
        /// <returns>converted value or defaultValue value</returns>
        public static short TryParseShort(this short? shortValue, short defaultValue)
        {
            return shortValue == null 
                ? defaultValue 
                : Convert.ToInt16(shortValue);
        }

        /// <summary>
        /// Convert nullable short to short
        /// </summary>
        /// <param name="shortValue">nullable shortValue value</param>
        /// <returns>converted value or BasePrimitivesExtensions.GetDefaultShortConversionValue value</returns>
        public static short TryParseShort(this short? shortValue)
        {
            return shortValue.TryParseShort(BasePrimitivesExtensions.GetDefaultShortConversionValue());
        }
        #endregion

        #region byte
        /// <summary>
        /// <para>Convert byte value to short value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="byteValue">byte value</param>
        /// <returns>short value</returns>
        public static short TryParseShort(this byte byteValue)
        {
            return Convert.ToInt16(byteValue);
        }

        /// <summary>
        /// <para>Convert nullable byte value to short value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="byteValue">nullable byte value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>short value</returns>
        public static short TryParseShort(this byte? byteValue, short defaultValue)
        {
            return byteValue == null 
                ? defaultValue 
                : Convert.ToInt16(byteValue);
        }

        /// <summary>
        /// Convert nullable byte value to short value
        /// </summary>
        /// <param name="byteValue">nullable byte value</param>
        /// <returns>short value</returns>
        public static short TryParseShort(this byte? byteValue)
        {
            return byteValue.TryParseShort(BasePrimitivesExtensions.GetDefaultShortConversionValue());
        }
        #endregion

        #region int
        /// <summary>
        /// <para>Convert int value to short value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="intValue">int value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>short value</returns>
        public static short TryParseShort(this int intValue, short defaultValue)
        {
            try
            {
                if (intValue > short.MaxValue)
                    intValue = defaultValue;

                if (intValue < short.MinValue)
                    intValue = defaultValue;

                return Convert.ToInt16(intValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert int value to short value
        /// </summary>
        /// <param name="intValue">int value</param>
        /// <returns>short value</returns>
        public static short TryParseShort(this int intValue)
        {
            return intValue.TryParseShort(BasePrimitivesExtensions.GetDefaultShortConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable int value to short value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="intValue">nullable int value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>short value</returns>
        public static short TryParseShort(this int? intValue, short defaultValue)
        {
            try
            {
                if (intValue == null)
                    intValue = defaultValue;

                if (intValue > short.MaxValue)
                    intValue = defaultValue;

                if (intValue < short.MinValue)
                    intValue = defaultValue;

                return Convert.ToInt16(intValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable int value to short value
        /// </summary>
        /// <param name="intValue">nullable int value</param>
        /// <returns>short value</returns>
        public static short TryParseShort(this int? intValue)
        {
            return intValue.TryParseShort(BasePrimitivesExtensions.GetDefaultShortConversionValue());
        }
        #endregion

        #region long
        /// <summary>
        /// <para>Convert long value to short value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="longValue">long value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>short value</returns>
        public static short TryParseShort(this long longValue, short defaultValue)
        {
            try
            {
                if (longValue > short.MaxValue)
                    longValue = defaultValue;

                if (longValue < short.MinValue)
                    longValue = defaultValue;

                return Convert.ToInt16(longValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert long value to short value
        /// </summary>
        /// <param name="longValue">long value</param>
        /// <returns>short value</returns>
        public static short TryParseShort(this long longValue)
        {
            return longValue.TryParseShort(BasePrimitivesExtensions.GetDefaultShortConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable long value to short value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="longValue">nullable long value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>short value</returns>
        public static short TryParseShort(this long? longValue, short defaultValue)
        {
            try
            {
                if (longValue == null)
                    longValue = defaultValue;

                if (longValue > short.MaxValue)
                    longValue = defaultValue;

                if (longValue < short.MinValue)
                    longValue = defaultValue;

                return Convert.ToInt16(longValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable long value to short value
        /// </summary>
        /// <param name="longValue">nullable long value</param>
        /// <returns>short value</returns>
        public static short TryParseShort(this long? longValue)
        {
            return longValue.TryParseShort(BasePrimitivesExtensions.GetDefaultShortConversionValue());
        }
        #endregion

        #region decimal
        /// <summary>
        /// <para>Convert decimal value to short value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="decimalValue">decimal value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>short value</returns>
        public static short TryParseShort(this decimal decimalValue, short defaultValue)
        {
            try
            {
                if (decimalValue > short.MaxValue)
                    decimalValue = defaultValue;

                if (decimalValue < short.MinValue)
                    decimalValue = defaultValue;

                return Convert.ToInt16(decimalValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert decimal value to short value
        /// </summary>
        /// <param name="decimalValue">decimal value</param>
        /// <returns>short value</returns>
        public static short TryParseShort(this decimal decimalValue)
        {
            return decimalValue.TryParseShort(BasePrimitivesExtensions.GetDefaultShortConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable decimal value to short value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="decimalValue">nullable decimal value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>short value</returns>
        public static short TryParseShort(this decimal? decimalValue, short defaultValue)
        {
            try
            {
                if (decimalValue == null)
                    decimalValue = defaultValue;

                if (decimalValue > short.MaxValue)
                    decimalValue = defaultValue;

                if (decimalValue < short.MinValue)
                    decimalValue = defaultValue;

                return Convert.ToInt16(decimalValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable decimal value to short value
        /// </summary>
        /// <param name="decimalValue">nullable decimal value</param>
        /// <returns>short value</returns>
        public static short TryParseShort(this decimal? decimalValue)
        {
            return decimalValue.TryParseShort(BasePrimitivesExtensions.GetDefaultShortConversionValue());
        }
        #endregion

        #region double
        /// <summary>
        /// <para>Convert double value to short value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="doubleValue">double value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>short value</returns>
        public static short TryParseShort(this double doubleValue, short defaultValue)
        {
            try
            {
                if (doubleValue > short.MaxValue)
                    doubleValue = defaultValue;

                if (doubleValue < short.MinValue)
                    doubleValue = defaultValue;

                return Convert.ToInt16(doubleValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert double value to short value
        /// </summary>
        /// <param name="doubleValue">double value</param>
        /// <returns>short value</returns>
        public static short TryParseShort(this double doubleValue)
        {
            return doubleValue.TryParseShort(BasePrimitivesExtensions.GetDefaultShortConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable double value to short value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="doubleValue">nullable double value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>short value</returns>
        public static short TryParseShort(this double? doubleValue, short defaultValue)
        {
            try
            {
                if (doubleValue == null)
                    doubleValue = defaultValue;

                if (doubleValue > short.MaxValue)
                    doubleValue = defaultValue;

                if (doubleValue < short.MinValue)
                    doubleValue = defaultValue;

                return Convert.ToInt16(doubleValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable double value to short value
        /// </summary>
        /// <param name="doubleValue">nullable double value</param>
        /// <returns>short value</returns>
        public static short TryParseShort(this double? doubleValue)
        {
            return doubleValue.TryParseShort(BasePrimitivesExtensions.GetDefaultShortConversionValue());
        }
        #endregion

        #region float
        /// <summary>
        /// <para>Convert float value to short value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="floatValue">float value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>short value</returns>
        public static short TryParseShort(this float floatValue, short defaultValue)
        {
            try
            {
                if (floatValue > short.MaxValue)
                    floatValue = defaultValue;

                if (floatValue < short.MinValue)
                    floatValue = defaultValue;

                return Convert.ToInt16(floatValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert float value to short value
        /// </summary>
        /// <param name="floatValue">float value</param>
        /// <returns>long value</returns>
        public static short TryParseShort(this float floatValue)
        {
            return floatValue.TryParseShort(BasePrimitivesExtensions.GetDefaultShortConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable float value to short value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="floatValue">nullable float value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>short value</returns>
        public static short TryParseShort(this float? floatValue, short defaultValue)
        {
            try
            {
                if (floatValue == null)
                    floatValue = defaultValue;

                if (floatValue > short.MaxValue)
                    floatValue = defaultValue;

                if (floatValue < short.MinValue)
                    floatValue = defaultValue;

                return Convert.ToInt16(floatValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable float value to short value
        /// </summary>
        /// <param name="floatValue">nullable float value</param>
        /// <returns>long value</returns>
        public static short TryParseShort(this float? floatValue)
        {
            return floatValue.TryParseShort(BasePrimitivesExtensions.GetDefaultShortConversionValue());
        }
        #endregion

        #region object
        /// <summary>
        /// <para>Try parse object short to short value</para>
        /// </summary>
        /// <param name="objValue">object to convert</param>
        /// <param name="defaultValue">default return value</param>
        /// <returns>short result</returns>
        public static short TryParseShort(this object objValue, short defaultValue)
        {
            if (objValue == null)
                return defaultValue;

            try
            {
                return objValue.ToString().TryParseShort(defaultValue,
                BasePrimitivesExtensions.GetDefaultShortAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// <para>Try parse short to short value</para>
        /// <para>Default value is BasePrimitivesExtensions.GetDefaultShortConversionValue() value</para>
        /// </summary>
        /// <param name="objValue">object to convert</param>
        /// <returns>short result</returns>
        public static short TryParseShort(this object objValue)
        {
            return objValue.TryParseShort(BasePrimitivesExtensions.GetDefaultShortConversionValue());
        }
        #endregion

        #region string to short array
        /// <summary>
        /// Parse string array in short array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <param name="allowDefaultConversion">Allow default tryparse values</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>short array</returns>
        public static short[] TryParseShortArray(this string strValue, short[] defaultValue, bool allowDefaultConversion, NumberStyles numberStyle, CultureInfo culture)
        {
            if (String.IsNullOrEmpty(strValue))
                return defaultValue ?? new short[] { };

            var shortList = defaultValue != null
                ? defaultValue.ToList()
                : new List<short>();

            foreach (var l in strValue.Split(','))
            {
                var strShort = l ?? "";

                if (String.IsNullOrEmpty(strShort))
                {
                    if (allowDefaultConversion)
                        shortList.Add(BasePrimitivesExtensions.GetDefaultShortConversionValue());

                    continue;
                }

                short shortConvert;
                if (!short.TryParse(strShort, numberStyle, culture, out shortConvert))
                {
                    if (allowDefaultConversion)
                        shortList.Add(BasePrimitivesExtensions.GetDefaultShortConversionValue());
                }
                else
                    shortList.Add(shortConvert);

            }

            return shortList.ToArray();
        }

        /// <summary>
        /// Parse string array in short array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>short array</returns>
        public static short[] TryParseShortArray(this string strValue, short[] defaultValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseShortArray(defaultValue, 
                BasePrimitivesExtensions.GetDefaultShortArrayAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Parse string array in short array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>short array</returns>
        public static short[] TryParseShortArray(this string strValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseShortArray(null, 
                BasePrimitivesExtensions.GetDefaultShortArrayAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Parse string array in short array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <param name="allowDefaultConversion">Allow default tryparse values</param>
        /// <returns>short array</returns>
        public static short[] TryParseShortArray(this string strValue, short[] defaultValue, bool allowDefaultConversion)
        {
            return strValue.TryParseShortArray(defaultValue, allowDefaultConversion,
                BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Parse string array in short array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <returns>short array</returns>
        public static short[] TryParseShortArray(this string strValue, short[] defaultValue)
        {
            return strValue.TryParseShortArray(defaultValue, 
                BasePrimitivesExtensions.GetDefaultShortArrayAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Parse string array in short array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <returns>short array</returns>
        public static short[] TryParseShortArray(this string strValue)
        {
            return strValue.TryParseShortArray(null, 
                BasePrimitivesExtensions.GetDefaultShortArrayAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }
        #endregion

        #region IsValidShort
        /// <summary>
        /// Test if string value is a valid short value
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>true/false</returns>
        public static bool IsValidShort(this string strValue, NumberStyles numberStyle, CultureInfo culture)
        {
            try
            {
                var baseValue = (short)(strValue == "1" ? 2 : 1);
                var convertedValue = strValue.TryParseShort(baseValue, true, numberStyle, culture);
                return convertedValue != baseValue;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return false;
        }

        /// <summary>
        /// Test if string value is a valid short value
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <returns>true/false</returns>
        public static bool IsValidShort(this string strValue)
        {
            return strValue.IsValidShort(
                BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }
        #endregion
    }
}
