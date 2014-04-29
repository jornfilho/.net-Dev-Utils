using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace DevUtils.PrimitivesExtensions
{
    /// <summary>
    /// Decimal extensions class
    /// </summary>
    public static class DecimalExtensions
    {
        #region string
        /// <summary>
        /// Convert decimal string value in decimal value
        /// </summary>
        /// <param name="strValue">string to convert</param>
        /// <param name="defaultValue">default value to return on convert error</param>
        /// <param name="allowZero">allow 0 valuen on convert</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">decimal culture origin</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this string strValue, decimal defaultValue, bool allowZero, NumberStyles numberStyle, CultureInfo culture)
        {
            decimal decimalValue;
            var converted = decimal.TryParse(strValue, numberStyle, culture, out decimalValue);

            return converted
                ? decimalValue == 0 && !allowZero
                    ? defaultValue
                    : decimalValue
                : defaultValue;
        }

        /// <summary>
        /// Convert decimal string value in decimal value
        /// </summary>
        /// <param name="strValue">string to convert</param>
        /// <param name="defaultValue">default value to return on convert error</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">decimal culture origin</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this string strValue, decimal defaultValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseDecimal(defaultValue,
                BasePrimitivesExtensions.GetDefaultDecimalAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Convert decimal string value in decimal value
        /// </summary>
        /// <param name="strValue">string to convert</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">decimal culture origin</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this string strValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseDecimal(BasePrimitivesExtensions.GetDefaultDecimalConversionValue(),
                BasePrimitivesExtensions.GetDefaultDecimalAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Convert decimal string value in decimal value
        /// </summary>
        /// <param name="strValue">string to convert</param>
        /// <param name="defaultValue">default value to return on convert error</param>
        /// <param name="allowZero">allow 0 valuen on convert</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this string strValue, decimal defaultValue, bool allowZero)
        {
            return strValue.TryParseDecimal(defaultValue, allowZero,
                BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Convert decimal string value in decimal value
        /// </summary>
        /// <param name="strValue">string to convert</param>
        /// <param name="defaultValue">default value to return on convert error</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this string strValue, decimal defaultValue)
        {
            return strValue.TryParseDecimal(defaultValue,
                BasePrimitivesExtensions.GetDefaultDecimalAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Convert decimal string value in decimal value
        /// </summary>
        /// <param name="strValue">string to convert</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this string strValue)
        {
            return strValue.TryParseDecimal(
                BasePrimitivesExtensions.GetDefaultDecimalConversionValue(),
                BasePrimitivesExtensions.GetDefaultDecimalAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }
        #endregion

        #region nullable decimal
        /// <summary>
        /// Convert nullable decimal to decimal
        /// </summary>
        /// <param name="decimalValue">nullable decimal value</param>
        /// <param name="defaultValue">default value when error on convert</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this decimal? decimalValue, decimal defaultValue)
        {
            return decimalValue == null
                ? defaultValue
                : Convert.ToDecimal(decimalValue);
        }

        /// <summary>
        /// Convert nullable decimal to decimal
        /// </summary>
        /// <param name="decimalValue">nullable decimal value</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this decimal? decimalValue)
        {
            return decimalValue.TryParseDecimal(BasePrimitivesExtensions.GetDefaultDecimalConversionValue());
        }
        #endregion

        #region byte
        /// <summary>
        /// <para>Convert byte value to decimal value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="byteValue">byte value</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this byte byteValue)
        {
            return Convert.ToDecimal(byteValue);
        }

        /// <summary>
        /// <para>Convert nullable byte value to decimal value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="byteValue">nullable byte value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this byte? byteValue, decimal defaultValue)
        {
            return byteValue == null
                ? defaultValue
                : Convert.ToDecimal(byteValue);
        }

        /// <summary>
        /// Convert nullable byte value to decimal value
        /// </summary>
        /// <param name="byteValue">nullable byte value</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this byte? byteValue)
        {
            return byteValue.TryParseDecimal(BasePrimitivesExtensions.GetDefaultDecimalConversionValue());
        }
        #endregion

        #region short
        /// <summary>
        /// <para>Convert short value to decimal value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="shortValue">short value</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this short shortValue)
        {
            return Convert.ToDecimal(shortValue);
        }

        /// <summary>
        /// <para>Convert nullable short value to decimal value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="shortValue">nullable short value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this short? shortValue, decimal defaultValue)
        {
            return shortValue == null
                ? defaultValue
                : Convert.ToDecimal(shortValue);
        }

        /// <summary>
        /// Convert nullable short value to decimal value
        /// </summary>
        /// <param name="shortValue">nullable short value</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this short? shortValue)
        {
            return shortValue.TryParseDecimal(BasePrimitivesExtensions.GetDefaultDecimalConversionValue());
        }
        #endregion

        #region int
        /// <summary>
        /// <para>Convert int32 value to decimal value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="intValue">int32 value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this int intValue, decimal defaultValue)
        {
            try
            {
                if (intValue > decimal.MaxValue)
                    return defaultValue;

                return intValue < decimal.MinValue
                    ? defaultValue
                    : Convert.ToDecimal(intValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert int32 value to decimal value
        /// </summary>
        /// <param name="intValue">int32 value</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this int intValue)
        {
            return intValue.TryParseDecimal(BasePrimitivesExtensions.GetDefaultDecimalConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable int32 value to decimal value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="intValue">nullable int32 value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this int? intValue, decimal defaultValue)
        {
            try
            {
                if (intValue == null)
                    return defaultValue;

                if (intValue > decimal.MaxValue)
                    return defaultValue;

                return intValue < decimal.MinValue
                    ? defaultValue
                    : Convert.ToDecimal(intValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable int32 value to decimal value
        /// </summary>
        /// <param name="intValue">nullable int32 value</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this int? intValue)
        {
            return intValue.TryParseDecimal(BasePrimitivesExtensions.GetDefaultDecimalConversionValue());
        }
        #endregion

        #region long
        /// <summary>
        /// <para>Convert long value to decimal value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="longValue">long value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this long longValue, decimal defaultValue)
        {
            try
            {
                if (longValue > decimal.MaxValue)
                    return defaultValue;

                return longValue < decimal.MinValue
                    ? defaultValue
                    : Convert.ToDecimal(longValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert long value to decimal value
        /// </summary>
        /// <param name="longValue">long value</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this long longValue)
        {
            return longValue.TryParseDecimal(BasePrimitivesExtensions.GetDefaultDecimalConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable long value to decimal value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="longValue">nullable long value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this long? longValue, decimal defaultValue)
        {
            try
            {
                if (longValue == null)
                    return defaultValue;

                if (longValue > decimal.MaxValue)
                    return defaultValue;

                return longValue < decimal.MinValue
                    ? defaultValue
                    : Convert.ToDecimal(longValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable long value to decimal value
        /// </summary>
        /// <param name="longValue">nullable long value</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this long? longValue)
        {
            return longValue.TryParseDecimal(BasePrimitivesExtensions.GetDefaultDecimalConversionValue());
        }
        #endregion
        
        #region double
        /// <summary>
        /// <para>Convert double value to decimal value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="doubleValue">double value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this double doubleValue, decimal defaultValue)
        {
            try
            {
                if (doubleValue > (double)decimal.MaxValue)
                    return defaultValue;

                return doubleValue < (double)decimal.MinValue
                    ? defaultValue
                    : Convert.ToDecimal(doubleValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert double value to decimal value
        /// </summary>
        /// <param name="doubleValue">double value</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this double doubleValue)
        {
            return doubleValue.TryParseDecimal(BasePrimitivesExtensions.GetDefaultDecimalConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable double value to decimal value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="doubleValue">nullable double value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this double? doubleValue, decimal defaultValue)
        {
            try
            {
                if (doubleValue == null)
                    return defaultValue;

                if (doubleValue > (double)decimal.MaxValue)
                    return defaultValue;

                return doubleValue < (double)decimal.MinValue
                    ? defaultValue
                    : Convert.ToDecimal(doubleValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable double value to decimal value
        /// </summary>
        /// <param name="doubleValue">nullable double value</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this double? doubleValue)
        {
            return doubleValue.TryParseDecimal(BasePrimitivesExtensions.GetDefaultDecimalConversionValue());
        }
        #endregion

        #region float
        /// <summary>
        /// <para>Convert float value to decimal value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="floatValue">float value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this float floatValue, decimal defaultValue)
        {
            try
            {
                if (floatValue > (float)decimal.MaxValue)
                    floatValue = (float)defaultValue;

                if (floatValue < (float)decimal.MinValue)
                    floatValue = (float)defaultValue;

                return Convert.ToDecimal(floatValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert float value to decimal value
        /// </summary>
        /// <param name="floatValue">float value</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this float floatValue)
        {
            return floatValue.TryParseDecimal(BasePrimitivesExtensions.GetDefaultDecimalConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable float value to decimal value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="floatValue">nullable float value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this float? floatValue, decimal defaultValue)
        {
            try
            {
                if (floatValue == null)
                    floatValue = (float)defaultValue;

                if (floatValue > (float)decimal.MaxValue)
                    floatValue = (float)defaultValue;

                if (floatValue < (float)decimal.MinValue)
                    floatValue = (float)defaultValue;

                return Convert.ToDecimal(floatValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable float value to decimal value
        /// </summary>
        /// <param name="floatValue">nullable float value</param>
        /// <returns>decimal value</returns>
        public static decimal TryParseDecimal(this float? floatValue)
        {
            return floatValue.TryParseDecimal(BasePrimitivesExtensions.GetDefaultDecimalConversionValue());
        }
        #endregion

        #region string to decimal array
        /// <summary>
        /// Parse string array in decimal array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <param name="allowDefaultConversion">Allow default tryparse values</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>decimal array</returns>
        public static decimal[] TryParseDecimalArray(this string strValue, decimal[] defaultValue, bool allowDefaultConversion, NumberStyles numberStyle, CultureInfo culture)
        {
            if (String.IsNullOrEmpty(strValue))
                return defaultValue ?? new decimal[] { };

            var decimalList = defaultValue != null
                ? defaultValue.ToList()
                : new List<decimal>();

            foreach (var l in strValue.Split(','))
            {
                var strDecimal = l ?? "";

                if (String.IsNullOrEmpty(strDecimal))
                {
                    if (allowDefaultConversion)
                        decimalList.Add(BasePrimitivesExtensions.GetDefaultDecimalConversionValue());

                    continue;
                }

                decimal decimalConvert;
                if (!decimal.TryParse(strDecimal, numberStyle, culture, out decimalConvert))
                {
                    if (allowDefaultConversion)
                        decimalList.Add(BasePrimitivesExtensions.GetDefaultDecimalConversionValue());
                }
                else
                    decimalList.Add(decimalConvert);

            }

            return decimalList.ToArray();
        }

        /// <summary>
        /// Parse string array in decimal array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>decimal array</returns>
        public static decimal[] TryParseDecimalArray(this string strValue, decimal[] defaultValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseDecimalArray(defaultValue,
                BasePrimitivesExtensions.GetDefaultDecimalArrayAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Parse string array in decimal array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>decimal array</returns>
        public static decimal[] TryParseDecimalArray(this string strValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseDecimalArray(null,
                BasePrimitivesExtensions.GetDefaultDecimalArrayAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Parse string array in decimal array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <param name="allowDefaultConversion">Allow default tryparse values</param>
        /// <returns>decimal array</returns>
        public static decimal[] TryParseDecimalArray(this string strValue, decimal[] defaultValue, bool allowDefaultConversion)
        {
            return strValue.TryParseDecimalArray(defaultValue, allowDefaultConversion,
                BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Parse string array in decimal array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <returns>decimal array</returns>
        public static decimal[] TryParseDecimalArray(this string strValue, decimal[] defaultValue)
        {
            return strValue.TryParseDecimalArray(defaultValue,
                BasePrimitivesExtensions.GetDefaultDecimalArrayAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Parse string array in short decimal
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <returns>decimal array</returns>
        public static decimal[] TryParseDecimalArray(this string strValue)
        {
            return strValue.TryParseDecimalArray(null,
                BasePrimitivesExtensions.GetDefaultDecimalArrayAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }
        #endregion

        #region IsValidDecimal
        /// <summary>
        /// Test if string value is a valid decimal value
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>true/false</returns>
        public static bool IsValidDecimal(this string strValue, NumberStyles numberStyle, CultureInfo culture)
        {
            try
            {
                var baseValue = (decimal)(strValue == "1" ? 2 : 1);
                var convertedValue = strValue.TryParseDecimal(baseValue, true, numberStyle, culture);
                return convertedValue != baseValue;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return false;
        }

        /// <summary>
        /// Test if string value is a valid decimal value
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <returns>true/false</returns>
        public static bool IsValidDecimal(this string strValue)
        {
            return strValue.IsValidDecimal(
                BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }
        #endregion
    }
}
