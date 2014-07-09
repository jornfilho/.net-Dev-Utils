using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace DevUtils.PrimitivesExtensions
{
    /// <summary>
    /// Static byte extension
    /// </summary>
    public static class ByteExtensions
    {
        #region string
        /// <summary>
        /// <para>Convert string byte value to byte value</para>
        /// <para>Set default value on invalid convertion</para>
        /// <para>Allow 0 as converted value flag</para>
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <param name="defaultValue">default value</param>
        /// <param name="allowZero">Allow 0</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this string strValue, byte defaultValue, bool allowZero, NumberStyles numberStyle, CultureInfo culture)
        {
            byte byteValue;
            var converted = byte.TryParse(strValue, numberStyle, culture, out byteValue);

            return converted
                ? byteValue == 0 && !allowZero
                    ? defaultValue
                    : byteValue
                : defaultValue;
        }

        /// <summary>
        /// <para>Convert string byte value to byte value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <param name="defaultValue">default value</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this string strValue, byte defaultValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseByte(defaultValue, BasePrimitivesExtensions.GetDefaultByteAllowDefaultConversion(), numberStyle, culture);
        }

        /// <summary>
        /// Convert string byte value to byte value
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this string strValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseByte(BasePrimitivesExtensions.GetDefaultByteConversionValue(),
                BasePrimitivesExtensions.GetDefaultByteAllowDefaultConversion(), numberStyle, culture);
        }
        
        /// <summary>
        /// <para>Convert string byte value to byte value</para>
        /// <para>Set default value on invalid convertion</para>
        /// <para>Allow 0 as converted value flag</para>
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <param name="defaultValue">default value</param>
        /// <param name="allowZero">Allow 0</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this string strValue, byte defaultValue, bool allowZero)
        {
            return strValue.TryParseByte(defaultValue, allowZero, BasePrimitivesExtensions.GetDefaultByteNumberStyle(), BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// <para>Convert string byte value to byte value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this string strValue, byte defaultValue)
        {
            return strValue.TryParseByte(defaultValue, BasePrimitivesExtensions.GetDefaultByteAllowDefaultConversion(), 
                BasePrimitivesExtensions.GetDefaultByteNumberStyle(), BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Convert string byte value to byte value
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this string strValue)
        {
            return strValue.TryParseByte(BasePrimitivesExtensions.GetDefaultByteConversionValue(),
                BasePrimitivesExtensions.GetDefaultByteAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultByteNumberStyle(), 
                BasePrimitivesExtensions.GetCurrentCulture());
        }
        #endregion

        #region nullable byte
        /// <summary>
        /// <para>Convert nullable byte value to byte value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="byteValue">nullable byte value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this byte? byteValue, byte defaultValue)
        {
            return byteValue == null 
                ? defaultValue
                : Convert.ToByte(byteValue);
        }

        /// <summary>
        /// Convert nullable byte value to byte value
        /// </summary>
        /// <param name="byteValue">nullable byte value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this byte? byteValue)
        {
            return byteValue.TryParseByte(BasePrimitivesExtensions.GetDefaultByteConversionValue());
        }
        #endregion

        #region short
        /// <summary>
        /// <para>Convert short value to byte value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="shortValue">short value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this short shortValue, byte defaultValue)
        {
            try
            {
                if (shortValue > byte.MaxValue)
                    shortValue = defaultValue;

                if (shortValue < byte.MinValue)
                    shortValue = defaultValue;

                return Convert.ToByte(shortValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert short value to byte value
        /// </summary>
        /// <param name="shortValue">short value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this short shortValue)
        {
            return shortValue.TryParseByte(BasePrimitivesExtensions.GetDefaultByteConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable short value to byte value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="shortValue">nullable short value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this short? shortValue, byte defaultValue)
        {
            try
            {
                if (shortValue == null)
                    shortValue = defaultValue;

                if (shortValue > byte.MaxValue)
                    shortValue = defaultValue;

                if (shortValue < byte.MinValue)
                    shortValue = defaultValue;

                return Convert.ToByte(shortValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable short value to byte value
        /// </summary>
        /// <param name="shortValue">nullable short value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this short? shortValue)
        {
            return shortValue.TryParseByte(BasePrimitivesExtensions.GetDefaultByteConversionValue());
        }
        #endregion
        
        #region int
        /// <summary>
        /// <para>Convert int value to byte value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="intValue">int value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this int intValue, byte defaultValue)
        {
            try
            {
                if (intValue > byte.MaxValue)
                    intValue = defaultValue;

                if (intValue < byte.MinValue)
                    intValue = defaultValue;

                return Convert.ToByte(intValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert int value to byte value
        /// </summary>
        /// <param name="intValue">int value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this int intValue)
        {
            return intValue.TryParseByte(BasePrimitivesExtensions.GetDefaultByteConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable int value to byte value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="intValue">nullable int value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this int? intValue, byte defaultValue)
        {
            try
            {
                if (intValue == null)
                    intValue = defaultValue;

                if (intValue > byte.MaxValue)
                    intValue = defaultValue;

                if (intValue < byte.MinValue)
                    intValue = defaultValue;

                return Convert.ToByte(intValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable int value to byte value
        /// </summary>
        /// <param name="intValue">nullable int value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this int? intValue)
        {
            return intValue.TryParseByte(BasePrimitivesExtensions.GetDefaultByteConversionValue());
        }
        #endregion

        #region long
        /// <summary>
        /// <para>Convert long value to byte value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="longValue">long value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this long longValue, byte defaultValue)
        {
            try
            {
                if (longValue > byte.MaxValue)
                    longValue = defaultValue;

                if (longValue < byte.MinValue)
                    longValue = defaultValue;

                return Convert.ToByte(longValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert long value to byte value
        /// </summary>
        /// <param name="longValue">long value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this long longValue)
        {
            return longValue.TryParseByte(BasePrimitivesExtensions.GetDefaultByteConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable long value to byte value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="longValue">nullable long value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this long? longValue, byte defaultValue)
        {
            try
            {
                if (longValue == null)
                    longValue = defaultValue;

                if (longValue > byte.MaxValue)
                    longValue = defaultValue;

                if (longValue < byte.MinValue)
                    longValue = defaultValue;

                return Convert.ToByte(longValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable long value to byte value
        /// </summary>
        /// <param name="longValue">nullable long value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this long? longValue)
        {
            return longValue.TryParseByte(BasePrimitivesExtensions.GetDefaultByteConversionValue());
        }
        #endregion

        #region decimal
        /// <summary>
        /// <para>Convert decimal value to byte value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="decimalValue">decimal value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this decimal decimalValue, byte defaultValue)
        {
            try
            {
                if (decimalValue > byte.MaxValue)
                    decimalValue = defaultValue;

                if (decimalValue < byte.MinValue)
                    decimalValue = defaultValue;

                return Convert.ToByte(decimalValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert decimal value to byte value
        /// </summary>
        /// <param name="decimalValue">decimal value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this decimal decimalValue)
        {
            return decimalValue.TryParseByte(BasePrimitivesExtensions.GetDefaultByteConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable decimal value to byte value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="decimalValue">nullable decimal value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this decimal? decimalValue, byte defaultValue)
        {
            try
            {
                if (decimalValue == null)
                    decimalValue = defaultValue;

                if (decimalValue > byte.MaxValue)
                    decimalValue = defaultValue;

                if (decimalValue < byte.MinValue)
                    decimalValue = defaultValue;

                return Convert.ToByte(decimalValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable decimal value to byte value
        /// </summary>
        /// <param name="decimalValue">nullable decimal value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this decimal? decimalValue)
        {
            return decimalValue.TryParseByte(BasePrimitivesExtensions.GetDefaultByteConversionValue());
        }
        #endregion

        #region double
        /// <summary>
        /// <para>Convert double value to byte value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="doubleValue">double value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this double doubleValue, byte defaultValue)
        {
            try
            {
                if (doubleValue > byte.MaxValue)
                    doubleValue = defaultValue;

                if (doubleValue < byte.MinValue)
                    doubleValue = defaultValue;

                return Convert.ToByte(doubleValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert double value to byte value
        /// </summary>
        /// <param name="doubleValue">double value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this double doubleValue)
        {
            return doubleValue.TryParseByte(BasePrimitivesExtensions.GetDefaultByteConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable double value to byte value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="doubleValue">nullable double value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this double? doubleValue, byte defaultValue)
        {
            try
            {
                if (doubleValue == null)
                    doubleValue = defaultValue;

                if (doubleValue > byte.MaxValue)
                    doubleValue = defaultValue;

                if (doubleValue < byte.MinValue)
                    doubleValue = defaultValue;

                return Convert.ToByte(doubleValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable double value to byte value
        /// </summary>
        /// <param name="doubleValue">nullable double value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this double? doubleValue)
        {
            return doubleValue.TryParseByte(BasePrimitivesExtensions.GetDefaultByteConversionValue());
        }
        #endregion

        #region float
        /// <summary>
        /// <para>Convert float value to byte value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="floatValue">float value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this float floatValue, byte defaultValue)
        {
            try
            {
                if (floatValue > byte.MaxValue)
                    floatValue = defaultValue;

                if (floatValue < byte.MinValue)
                    floatValue = defaultValue;

                return Convert.ToByte(floatValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert float value to byte value
        /// </summary>
        /// <param name="floatValue">float value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this float floatValue)
        {
            return floatValue.TryParseByte(BasePrimitivesExtensions.GetDefaultByteConversionValue());
        }

        /// <summary>
        /// <para>Convert nullable float value to byte value</para>
        /// <para>Set default value on invalid convertion</para>
        /// </summary>
        /// <param name="floatValue">nullable float value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this float? floatValue, byte defaultValue)
        {
            try
            {
                if (floatValue == null)
                    floatValue = defaultValue;

                if (floatValue > byte.MaxValue)
                    floatValue = defaultValue;

                if (floatValue < byte.MinValue)
                    floatValue = defaultValue;

                return Convert.ToByte(floatValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert nullable float value to byte value
        /// </summary>
        /// <param name="floatValue">nullable float value</param>
        /// <returns>byte value</returns>
        public static byte TryParseByte(this float? floatValue)
        {
            return floatValue.TryParseByte(BasePrimitivesExtensions.GetDefaultByteConversionValue());
        }
        #endregion

        #region object
        /// <summary>
        /// <para>Try parse object byte to byte value</para>
        /// </summary>
        /// <param name="objValue">object to convert</param>
        /// <param name="defaultValue">default return value</param>
        /// <returns>byte result</returns>
        public static byte TryParseByte(this object objValue, byte defaultValue)
        {
            if (objValue == null)
                return defaultValue;

            try
            {
                return objValue.ToString().TryParseByte(defaultValue,
                    BasePrimitivesExtensions.GetDefaultByteAllowDefaultConversion(),
                    BasePrimitivesExtensions.GetDefaultByteNumberStyle(),
                    BasePrimitivesExtensions.GetCurrentCulture());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// <para>Try parse byte to byte value</para>
        /// <para>Default value is BasePrimitivesExtensions.GetDefaultByteConversionValue() value</para>
        /// </summary>
        /// <param name="objValue">object to convert</param>
        /// <returns>byte result</returns>
        public static byte TryParseByte(this object objValue)
        {
            return objValue.TryParseByte(BasePrimitivesExtensions.GetDefaultByteConversionValue());
        }
        #endregion

        #region string to byte array
        /// <summary>
        /// Parse string array in byte array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <param name="allowDefaultConversion">Allow default tryparse values</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>byte array</returns>
        public static byte[] TryParseByteArray(this string strValue, byte[] defaultValue, bool allowDefaultConversion, NumberStyles numberStyle, CultureInfo culture)
        {
            if (String.IsNullOrEmpty(strValue))
                return defaultValue ?? new byte[] { };

            var byteList = defaultValue != null
                ? defaultValue.ToList()
                : new List<byte>();

            foreach (var l in strValue.Split(','))
            {
                var strByte = l ?? "";

                if (String.IsNullOrEmpty(strByte))
                {
                    if (allowDefaultConversion)
                        byteList.Add(BasePrimitivesExtensions.GetDefaultByteConversionValue());

                    continue;
                }

                byte byteConvert;
                if (!byte.TryParse(strByte, numberStyle, culture, out byteConvert))
                {
                    if (allowDefaultConversion)
                        byteList.Add(BasePrimitivesExtensions.GetDefaultByteConversionValue());
                }
                else
                    byteList.Add(byteConvert);

            }

            return byteList.ToArray();
        }

        /// <summary>
        /// Parse string array in byte array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>byte array</returns>
        public static byte[] TryParseByteArray(this string strValue, byte[] defaultValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseByteArray(defaultValue,
                BasePrimitivesExtensions.GetDefaultByteArrayAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Parse string array in byte array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>byte array</returns>
        public static byte[] TryParseByteArray(this string strValue, NumberStyles numberStyle, CultureInfo culture)
        {
            return strValue.TryParseByteArray(null,
                BasePrimitivesExtensions.GetDefaultByteArrayAllowDefaultConversion(),
                numberStyle, culture);
        }

        /// <summary>
        /// Parse string array in byte array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <param name="allowDefaultConversion">Allow default tryparse values</param>
        /// <returns>byte array</returns>
        public static byte[] TryParseByteArray(this string strValue, byte[] defaultValue, bool allowDefaultConversion)
        {
            return strValue.TryParseByteArray(defaultValue, allowDefaultConversion,
                BasePrimitivesExtensions.GetDefaultByteNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Parse string array in byte array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <returns>byte array</returns>
        public static byte[] TryParseByteArray(this string strValue, byte[] defaultValue)
        {
            return strValue.TryParseByteArray(defaultValue, 
                BasePrimitivesExtensions.GetDefaultByteArrayAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultByteNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }

        /// <summary>
        /// Parse string array in byte array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <returns>byte array</returns>
        public static byte[] TryParseByteArray(this string strValue)
        {
            return strValue.TryParseByteArray(null, 
                BasePrimitivesExtensions.GetDefaultByteArrayAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultByteNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
        }
        #endregion

        #region IsValidByte
        /// <summary>
        /// Test if string value is a valid byte value
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <param name="numberStyle">number style to convert</param>
        /// <param name="culture">culture origin</param>
        /// <returns>true/false</returns>
        public static bool IsValidByte(this string strValue, NumberStyles numberStyle, CultureInfo culture)
        {
            try
            {
                var baseValue = (byte)(strValue == "1" ? 2 : 1);
                var convertedValue = strValue.TryParseByte(baseValue, true, numberStyle, culture);
                return convertedValue != baseValue;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return false;
        }

        /// <summary>
        /// Test if string value is a valid byte value
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <returns>true/false</returns>
        public static bool IsValidByte(this string strValue)
        {
            return strValue.IsValidByte(
                BasePrimitivesExtensions.GetDefaultByteNumberStyle(), 
                BasePrimitivesExtensions.GetCurrentCulture());
        } 
        #endregion
    }
}
