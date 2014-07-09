using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace DevUtils.PrimitivesExtensions
{
    /// <summary>
    /// Double extensions class
    /// </summary>
    public static class DoubleExtensions
    {
        #region string
        /// <summary>
        /// Convert double string value in double value
        /// </summary>
        /// <param name="strValue">string to convert</param>
        /// <param name="defaultValue">default value to return on convert error</param>
        /// <param name="allowZero">allow 0 valuen on convert</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">double culture origin</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this string strValue, double defaultValue, bool allowZero, NumberStyles numberStyle, CultureInfo culture)
        {
            double doubleValue;
            var converted = double.TryParse(strValue, numberStyle, culture, out doubleValue);

            return converted
                ? doubleValue.Equals(0) && !allowZero
                    ? defaultValue
                    : doubleValue
                : defaultValue;
        }

        /// <summary>
        /// Convert double string value in double value
        /// </summary>
        /// <param name="strValue">string to convert</param>
        /// <param name="defaultValue">default value to return on convert error</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">double culture origin</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this string strValue, double defaultValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseDouble(defaultValue,
                BasePrimitivesExtensions.GetDefaultDoubleAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Convert double string value in double value
        /// </summary>
        /// <param name="strValue">string to convert</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">double culture origin</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this string strValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseDouble(BasePrimitivesExtensions.GetDefaultDoubleConversionValue(),
                BasePrimitivesExtensions.GetDefaultDoubleAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Convert double string value in double value
        /// </summary>
        /// <param name="strValue">string to convert</param>
        /// <param name="defaultValue">default value to return on convert error</param>
        /// <param name="allowZero">allow 0 valuen on convert</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this string strValue, double defaultValue, bool allowZero)
        {
            return strValue.TryParseDouble(defaultValue, allowZero,
                BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Convert double string value in double value
        /// </summary>
        /// <param name="strValue">string to convert</param>
        /// <param name="defaultValue">default value to return on convert error</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this string strValue, double defaultValue)
        {
            return strValue.TryParseDouble(defaultValue,
                BasePrimitivesExtensions.GetDefaultDoubleAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Convert double string value in double value
        /// </summary>
        /// <param name="strValue">string to convert</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this string strValue)
        {
            return strValue.TryParseDouble(
                BasePrimitivesExtensions.GetDefaultDoubleConversionValue(),
                BasePrimitivesExtensions.GetDefaultDoubleAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }
        #endregion

        #region nullable double
        /// <summary>
        /// Convert nullable double to double
        /// </summary>
        /// <param name="doubleValue">nullable double value</param>
        /// <param name="defaultValue">default value when error on convert</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this double? doubleValue, double defaultValue)
        {
            return doubleValue == null
                ? defaultValue
                : Convert.ToDouble(doubleValue);
        }

        /// <summary>
        /// Convert nullable double to double
        /// </summary>
        /// <param name="doubleValue">nullable double value</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this double? doubleValue)
        {
            return doubleValue.TryParseDouble(BasePrimitivesExtensions.GetDefaultDoubleConversionValue());
        }
        #endregion

        #region byte
        /// <summary>
        /// <para>Convert byte value to double value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="byteValue">byte value</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this byte byteValue)
        {
            return Convert.ToDouble(byteValue);
        }

        /// <summary>
        /// <para>Convert nullable byte value to double value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="byteValue">nullable byte value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this byte? byteValue, double defaultValue)
        {
            return byteValue == null
                ? defaultValue
                : Convert.ToDouble(byteValue);
        }

        /// <summary>
        /// Convert nullable byte value to double value
        /// </summary>
        /// <param name="byteValue">nullable byte value</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this byte? byteValue)
        {
            return byteValue.TryParseDouble(BasePrimitivesExtensions.GetDefaultDoubleConversionValue());
        }
        #endregion

        #region short
        /// <summary>
        /// <para>Convert short value to double value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="shortValue">short value</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this short shortValue)
        {
            return Convert.ToDouble(shortValue);
        }

        /// <summary>
        /// <para>Convert nullable short value to double value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="shortValue">nullable short value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this short? shortValue, double defaultValue)
        {
            return shortValue == null
                ? defaultValue
                : Convert.ToDouble(shortValue);
        }

        /// <summary>
        /// Convert nullable short value to double value
        /// </summary>
        /// <param name="shortValue">nullable short value</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this short? shortValue)
        {
            return shortValue.TryParseDouble(BasePrimitivesExtensions.GetDefaultDoubleConversionValue());
        }
        #endregion

        #region int
        /// <summary>
        /// <para>Convert int32 value to double value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="intValue">int32 value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this int intValue, double defaultValue)
        {
            try
            {
                if (intValue > double.MaxValue)
                    return defaultValue;

                return intValue < double.MinValue
                    ? defaultValue
                    : Convert.ToDouble(intValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert int32 value to double value
        /// </summary>
        /// <param name="intValue">int32 value</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this int intValue)
        {
            return intValue.TryParseDouble(BasePrimitivesExtensions.GetDefaultDoubleConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable int32 value to double value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="intValue">nullable int32 value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this int? intValue, double defaultValue)
        {
            try
            {
                if (intValue == null)
                    return defaultValue;

                if (intValue > double.MaxValue)
                    return defaultValue;

                return intValue < double.MinValue
                    ? defaultValue
                    : Convert.ToDouble(intValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable int32 value to double value
        /// </summary>
        /// <param name="intValue">nullable int32 value</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this int? intValue)
        {
            return intValue.TryParseDouble(BasePrimitivesExtensions.GetDefaultDoubleConversionValue());
        }
        #endregion

        #region long
        /// <summary>
        /// <para>Convert long value to double value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="longValue">long value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this long longValue, double defaultValue)
        {
            try
            {
                if (longValue > double.MaxValue)
                    return defaultValue;

                return longValue < double.MinValue
                    ? defaultValue
                    : Convert.ToDouble(longValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert long value to double value
        /// </summary>
        /// <param name="longValue">long value</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this long longValue)
        {
            return longValue.TryParseDouble(BasePrimitivesExtensions.GetDefaultDoubleConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable long value to double value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="longValue">nullable long value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this long? longValue, double defaultValue)
        {
            try
            {
                if (longValue == null)
                    return defaultValue;

                if (longValue > double.MaxValue)
                    return defaultValue;

                return longValue < double.MinValue
                    ? defaultValue
                    : Convert.ToDouble(longValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable long value to double value
        /// </summary>
        /// <param name="longValue">nullable long value</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this long? longValue)
        {
            return longValue.TryParseDouble(BasePrimitivesExtensions.GetDefaultDoubleConversionValue());
        }
        #endregion
        
        #region decimal
        /// <summary>
        /// <para>Convert decimal value to double value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="decimalValue">decimal value</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this decimal decimalValue)
        {
            return Convert.ToDouble(decimalValue);
        }

        /// <summary>
        /// <para>Convert nullable decimal value to double value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="decimalValue">nullable decimal value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this decimal? decimalValue, double defaultValue)
        {
            return decimalValue == null 
                ? defaultValue 
                : Convert.ToDouble(decimalValue);
        }

        /// <summary>
        /// Convert nullable decimal value to double value
        /// </summary>
        /// <param name="decimalValue">nullable double value</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this decimal? decimalValue)
        {
            return decimalValue.TryParseDouble(BasePrimitivesExtensions.GetDefaultDoubleConversionValue());
        }
        #endregion

        #region float
        /// <summary>
        /// <para>Convert float value to double value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="floatValue">float value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this float floatValue, double defaultValue)
        {
            try
            {
                if (floatValue > double.MaxValue)
                    floatValue = (float)defaultValue;

                if (floatValue < double.MinValue)
                    floatValue = (float)defaultValue;

                return Convert.ToDouble(floatValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert float value to double value
        /// </summary>
        /// <param name="floatValue">float value</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this float floatValue)
        {
            return floatValue.TryParseDouble(BasePrimitivesExtensions.GetDefaultDoubleConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable float value to double value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="floatValue">nullable float value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this float? floatValue, double defaultValue)
        {
            try
            {
                if (floatValue == null)
                    floatValue = (float)defaultValue;

                if (floatValue > double.MaxValue)
                    floatValue = (float)defaultValue;

                if (floatValue < double.MinValue)
                    floatValue = (float)defaultValue;

                return Convert.ToDouble(floatValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable float value to double value
        /// </summary>
        /// <param name="floatValue">nullable float value</param>
        /// <returns>double value</returns>
        public static double TryParseDouble(this float? floatValue)
        {
            return floatValue.TryParseDouble(BasePrimitivesExtensions.GetDefaultDoubleConversionValue());
        }
        #endregion

        #region object
        /// <summary>
        /// <para>Try parse object double to double value</para>
        /// </summary>
        /// <param name="objValue">object to convert</param>
        /// <param name="defaultValue">default return value</param>
        /// <returns>double result</returns>
        public static double TryParseDouble(this object objValue, double defaultValue)
        {
            if (objValue == null)
                return defaultValue;

            try
            {
                return objValue.ToString().TryParseDouble(defaultValue,
                BasePrimitivesExtensions.GetDefaultDoubleAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// <para>Try parse double to double value</para>
        /// <para>Default value is BasePrimitivesExtensions.GetDefaultDoubleConversionValue() value</para>
        /// </summary>
        /// <param name="objValue">object to convert</param>
        /// <returns>double result</returns>
        public static double TryParseDouble(this object objValue)
        {
            return objValue.TryParseDouble(BasePrimitivesExtensions.GetDefaultDoubleConversionValue());
        }
        #endregion

        #region string to double array
        /// <summary>
        /// Parse string array in double array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <param name="allowDefaultConversion">Allow default tryparse values</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>double array</returns>
        public static double[] TryParseDoubleArray(this string strValue, double[] defaultValue, bool allowDefaultConversion, NumberStyles numberStyle, CultureInfo culture)
        {
            if (String.IsNullOrEmpty(strValue))
                return defaultValue ?? new double[] { };

            var doubleList = defaultValue != null
                ? defaultValue.ToList()
                : new List<double>();

            foreach (var l in strValue.Split(','))
            {
                var strDouble = l ?? "";

                if (String.IsNullOrEmpty(strDouble))
                {
                    if (allowDefaultConversion)
                        doubleList.Add(BasePrimitivesExtensions.GetDefaultDoubleConversionValue());

                    continue;
                }

                double doubleConvert;
                if (!double.TryParse(strDouble, numberStyle, culture, out doubleConvert))
                {
                    if (allowDefaultConversion)
                        doubleList.Add(BasePrimitivesExtensions.GetDefaultDoubleConversionValue());
                }
                else
                    doubleList.Add(doubleConvert);

            }

            return doubleList.ToArray();
        }

        /// <summary>
        /// Parse string array in double array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>double array</returns>
        public static double[] TryParseDoubleArray(this string strValue, double[] defaultValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseDoubleArray(defaultValue,
                BasePrimitivesExtensions.GetDefaultDoubleArrayAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Parse string array in double array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>double array</returns>
        public static double[] TryParseDoubleArray(this string strValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseDoubleArray(null,
                BasePrimitivesExtensions.GetDefaultDoubleArrayAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Parse string array in double array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <param name="allowDefaultConversion">Allow default tryparse values</param>
        /// <returns>double array</returns>
        public static double[] TryParseDoubleArray(this string strValue, double[] defaultValue, bool allowDefaultConversion)
        {
            return strValue.TryParseDoubleArray(defaultValue, allowDefaultConversion,
                BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Parse string array in double array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <returns>double array</returns>
        public static double[] TryParseDoubleArray(this string strValue, double[] defaultValue)
        {
            return strValue.TryParseDoubleArray(defaultValue,
                BasePrimitivesExtensions.GetDefaultDoubleArrayAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Parse string array in short double
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <returns>double array</returns>
        public static double[] TryParseDoubleArray(this string strValue)
        {
            return strValue.TryParseDoubleArray(null,
                BasePrimitivesExtensions.GetDefaultDoubleArrayAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }
        #endregion

        #region IsValidDouble
        /// <summary>
        /// Test if string value is a valid double value
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>true/false</returns>
        public static bool IsValidDouble(this string strValue, NumberStyles numberStyle, CultureInfo culture)
        {
            try
            {
                var baseValue = (double)(strValue == "1" ? 2 : 1);
                var convertedValue = strValue.TryParseDouble(baseValue, true, numberStyle, culture);
                return !convertedValue.Equals(baseValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return false;
        }

        /// <summary>
        /// Test if string value is a valid double value
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <returns>true/false</returns>
        public static bool IsValidDouble(this string strValue)
        {
            return strValue.IsValidDouble(
                BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }
        #endregion
    }
}
