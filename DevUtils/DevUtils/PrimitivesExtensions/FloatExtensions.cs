using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace DevUtils.PrimitivesExtensions
{
    /// <summary>
    /// Float extensions class
    /// </summary>
    public static class FloatExtensions
    {
        #region string
        /// <summary>
        /// Convert float string value in float value
        /// </summary>
        /// <param name="strValue">string to convert</param>
        /// <param name="defaultValue">default value to return on convert error</param>
        /// <param name="allowZero">allow 0 valuen on convert</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">float culture origin</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this string strValue, float defaultValue, bool allowZero, NumberStyles numberStyle, CultureInfo culture)
        {
            float floatValue;
            var converted = float.TryParse(strValue, numberStyle, culture, out floatValue);

            return converted
                ? floatValue.Equals(0) && !allowZero
                    ? defaultValue
                    : floatValue
                : defaultValue;
        }

        /// <summary>
        /// Convert float string value in float value
        /// </summary>
        /// <param name="strValue">string to convert</param>
        /// <param name="defaultValue">default value to return on convert error</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">float culture origin</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this string strValue, float defaultValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseFloat(defaultValue,
                BasePrimitivesExtensions.GetDefaultFloatAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Convert float string value in float value
        /// </summary>
        /// <param name="strValue">string to convert</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">float culture origin</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this string strValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseFloat(BasePrimitivesExtensions.GetDefaultFloatConversionValue(),
                BasePrimitivesExtensions.GetDefaultFloatAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Convert float string value in float value
        /// </summary>
        /// <param name="strValue">string to convert</param>
        /// <param name="defaultValue">default value to return on convert error</param>
        /// <param name="allowZero">allow 0 valuen on convert</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this string strValue, float defaultValue, bool allowZero)
        {
            return strValue.TryParseFloat(defaultValue, allowZero,
                BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Convert float string value in float value
        /// </summary>
        /// <param name="strValue">string to convert</param>
        /// <param name="defaultValue">default value to return on convert error</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this string strValue, float defaultValue)
        {
            return strValue.TryParseFloat(defaultValue,
                BasePrimitivesExtensions.GetDefaultFloatAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Convert float string value in float value
        /// </summary>
        /// <param name="strValue">string to convert</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this string strValue)
        {
            return strValue.TryParseFloat(
                BasePrimitivesExtensions.GetDefaultFloatConversionValue(),
                BasePrimitivesExtensions.GetDefaultFloatAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }
        #endregion

        #region nullable float
        /// <summary>
        /// Convert nullable float to float
        /// </summary>
        /// <param name="floatValue">nullable float value</param>
        /// <param name="defaultValue">default value when error on convert</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this float? floatValue, float defaultValue)
        {
            return floatValue == null
                ? defaultValue
                : (float)Convert.ToDecimal(floatValue);
        }

        /// <summary>
        /// Convert nullable float to float
        /// </summary>
        /// <param name="floatValue">nullable float value</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this float? floatValue)
        {
            return floatValue.TryParseFloat(BasePrimitivesExtensions.GetDefaultFloatConversionValue());
        }
        #endregion

        #region byte
        /// <summary>
        /// <para>Convert byte value to float value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="byteValue">byte value</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this byte byteValue)
        {
            return (float)Convert.ToDecimal(byteValue);
        }

        /// <summary>
        /// <para>Convert nullable byte value to float value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="byteValue">nullable byte value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this byte? byteValue, float defaultValue)
        {
            return byteValue == null
                ? defaultValue
                : (float)Convert.ToDecimal(byteValue);
        }

        /// <summary>
        /// Convert nullable byte value to float value
        /// </summary>
        /// <param name="byteValue">nullable byte value</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this byte? byteValue)
        {
            return byteValue.TryParseFloat(BasePrimitivesExtensions.GetDefaultFloatConversionValue());
        }
        #endregion

        #region short
        /// <summary>
        /// <para>Convert short value to float value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="shortValue">short value</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this short shortValue)
        {
            return (float)Convert.ToDecimal(shortValue);
        }

        /// <summary>
        /// <para>Convert nullable short value to float value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="shortValue">nullable short value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this short? shortValue, float defaultValue)
        {
            return shortValue == null
                ? defaultValue
                : (float)Convert.ToDecimal(shortValue);
        }

        /// <summary>
        /// Convert nullable short value to float value
        /// </summary>
        /// <param name="shortValue">nullable short value</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this short? shortValue)
        {
            return shortValue.TryParseFloat(BasePrimitivesExtensions.GetDefaultFloatConversionValue());
        }
        #endregion

        #region int
        /// <summary>
        /// <para>Convert int32 value to float value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="intValue">int32 value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this int intValue, float defaultValue)
        {
            try
            {
                if (intValue > float.MaxValue)
                    return defaultValue;

                return intValue < float.MinValue
                    ? defaultValue
                    : (float)Convert.ToDecimal(intValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert int32 value to float value
        /// </summary>
        /// <param name="intValue">int32 value</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this int intValue)
        {
            return intValue.TryParseFloat(BasePrimitivesExtensions.GetDefaultFloatConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable int32 value to float value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="intValue">nullable int32 value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this int? intValue, float defaultValue)
        {
            try
            {
                if (intValue == null)
                    return defaultValue;

                if (intValue > float.MaxValue)
                    return defaultValue;

                return intValue < float.MinValue
                    ? defaultValue
                    : (float)Convert.ToDecimal(intValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable int32 value to float value
        /// </summary>
        /// <param name="intValue">nullable int32 value</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this int? intValue)
        {
            return intValue.TryParseFloat(BasePrimitivesExtensions.GetDefaultFloatConversionValue());
        }
        #endregion

        #region long
        /// <summary>
        /// <para>Convert long value to float value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="longValue">long value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this long longValue, float defaultValue)
        {
            try
            {
                if (longValue > float.MaxValue)
                    return defaultValue;

                return longValue < float.MinValue
                    ? defaultValue
                    : (float)Convert.ToDecimal(longValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert long value to float value
        /// </summary>
        /// <param name="longValue">long value</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this long longValue)
        {
            return longValue.TryParseFloat(BasePrimitivesExtensions.GetDefaultFloatConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable long value to float value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="longValue">nullable long value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this long? longValue, float defaultValue)
        {
            try
            {
                if (longValue == null)
                    return defaultValue;

                if (longValue > float.MaxValue)
                    return defaultValue;

                return longValue < float.MinValue
                    ? defaultValue
                    : (float)Convert.ToDecimal(longValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable long value to float value
        /// </summary>
        /// <param name="longValue">nullable long value</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this long? longValue)
        {
            return longValue.TryParseFloat(BasePrimitivesExtensions.GetDefaultFloatConversionValue());
        }
        #endregion
        
        #region double
        /// <summary>
        /// <para>Convert double value to float value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="doubleValue">double value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this double doubleValue, float defaultValue)
        {
            try
            {
                if (doubleValue > float.MaxValue)
                    return defaultValue;

                return doubleValue < float.MinValue
                    ? defaultValue
                    : (float)Convert.ToDecimal(doubleValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert double value to float value
        /// </summary>
        /// <param name="doubleValue">double value</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this double doubleValue)
        {
            return doubleValue.TryParseFloat(BasePrimitivesExtensions.GetDefaultFloatConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable double value to float value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="doubleValue">nullable double value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this double? doubleValue, float defaultValue)
        {
            try
            {
                if (doubleValue == null)
                    return defaultValue;

                if (doubleValue > float.MaxValue)
                    return defaultValue;

                return doubleValue < float.MinValue
                    ? defaultValue
                    : (float)Convert.ToDecimal(doubleValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable double value to float value
        /// </summary>
        /// <param name="doubleValue">nullable double value</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this double? doubleValue)
        {
            return doubleValue.TryParseFloat(BasePrimitivesExtensions.GetDefaultFloatConversionValue());
        }
        #endregion

        #region decimal
        /// <summary>
        /// <para>Convert decimal value to float value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="decimalValue">decimal value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this decimal decimalValue, float defaultValue)
        {
            try
            {
                if ((float) decimalValue > float.MaxValue)
                    return defaultValue;

                if ((float) decimalValue < float.MinValue)
                    return defaultValue;

                return (float)Convert.ToDecimal(decimalValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert decimal value to float value
        /// </summary>
        /// <param name="decimalValue">decimal value</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this decimal decimalValue)
        {
            return decimalValue.TryParseFloat(BasePrimitivesExtensions.GetDefaultFloatConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable decimal value to float value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="decimalValue">nullable decimal value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this decimal? decimalValue, float defaultValue)
        {
            try
            {
                if (decimalValue == null)
                    return defaultValue;

                if ((float)decimalValue > float.MaxValue)
                    return defaultValue;

                if ((float) decimalValue < float.MinValue)
                    return defaultValue;

                return (float)Convert.ToDecimal(decimalValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable decimal value to float value
        /// </summary>
        /// <param name="decimalValue">nullable decimal value</param>
        /// <returns>float value</returns>
        public static float TryParseFloat(this decimal? decimalValue)
        {
            return decimalValue.TryParseFloat(BasePrimitivesExtensions.GetDefaultFloatConversionValue());
        }
        #endregion

        #region object
        /// <summary>
        /// <para>Try parse object float to float value</para>
        /// </summary>
        /// <param name="objValue">object to convert</param>
        /// <param name="defaultValue">default return value</param>
        /// <returns>float result</returns>
        public static float TryParseFloat(this object objValue, float defaultValue)
        {
            if (objValue == null)
                return defaultValue;

            try
            {
                return objValue.ToString().TryParseFloat(defaultValue,
                BasePrimitivesExtensions.GetDefaultFloatAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// <para>Try parse float to float value</para>
        /// <para>Default value is BasePrimitivesExtensions.GetDefaultFloatConversionValue() value</para>
        /// </summary>
        /// <param name="objValue">object to convert</param>
        /// <returns>float result</returns>
        public static float TryParseFloat(this object objValue)
        {
            return objValue.TryParseFloat(BasePrimitivesExtensions.GetDefaultFloatConversionValue());
        }
        #endregion

        #region string to float array
        /// <summary>
        /// Parse string array in float array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <param name="allowDefaultConversion">Allow default tryparse values</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>float array</returns>
        public static float[] TryParseFloatArray(this string strValue, float[] defaultValue, bool allowDefaultConversion, NumberStyles numberStyle, CultureInfo culture)
        {
            if (String.IsNullOrEmpty(strValue))
                return defaultValue ?? new float[] { };

            var floatList = defaultValue != null
                ? defaultValue.ToList()
                : new List<float>();

            foreach (var l in strValue.Split(','))
            {
                var strFloat = l ?? "";

                if (String.IsNullOrEmpty(strFloat))
                {
                    if (allowDefaultConversion)
                        floatList.Add(BasePrimitivesExtensions.GetDefaultFloatConversionValue());

                    continue;
                }

                float floatConvert;
                if (!float.TryParse(strFloat, numberStyle, culture, out floatConvert))
                {
                    if (allowDefaultConversion)
                        floatList.Add(BasePrimitivesExtensions.GetDefaultFloatConversionValue());
                }
                else
                    floatList.Add(floatConvert);

            }

            return floatList.ToArray();
        }

        /// <summary>
        /// Parse string array in float array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>float array</returns>
        public static float[] TryParseFloatArray(this string strValue, float[] defaultValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseFloatArray(defaultValue,
                BasePrimitivesExtensions.GetDefaultFloatArrayAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Parse string array in float array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>float array</returns>
        public static float[] TryParseFloatArray(this string strValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseFloatArray(null,
                BasePrimitivesExtensions.GetDefaultFloatArrayAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Parse string array in float array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <param name="allowDefaultConversion">Allow default tryparse values</param>
        /// <returns>float array</returns>
        public static float[] TryParseFloatArray(this string strValue, float[] defaultValue, bool allowDefaultConversion)
        {
            return strValue.TryParseFloatArray(defaultValue, allowDefaultConversion,
                BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Parse string array in float array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <returns>float array</returns>
        public static float[] TryParseFloatArray(this string strValue, float[] defaultValue)
        {
            return strValue.TryParseFloatArray(defaultValue,
                BasePrimitivesExtensions.GetDefaultFloatArrayAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Parse string array in short float
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <returns>float array</returns>
        public static float[] TryParseFloatArray(this string strValue)
        {
            return strValue.TryParseFloatArray(null,
                BasePrimitivesExtensions.GetDefaultFloatArrayAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }
        #endregion

        #region IsValidFloat
        /// <summary>
        /// Test if string value is a valid float value
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>true/false</returns>
        public static bool IsValidFloat(this string strValue, NumberStyles numberStyle, CultureInfo culture)
        {
            try
            {
                var baseValue = (float)(strValue == "1" ? 2 : 1);
                var convertedValue = strValue.TryParseFloat(baseValue, true, numberStyle, culture);
                return !convertedValue.Equals(baseValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return false;
        }

        /// <summary>
        /// Test if string value is a valid float value
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <returns>true/false</returns>
        public static bool IsValidFloat(this string strValue)
        {
            return strValue.IsValidFloat(
                BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }
        #endregion
    }
}
