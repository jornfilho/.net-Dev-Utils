using System;
using System.Diagnostics;
using System.Globalization;
using DevUtils.PrimitivesExtensions;

namespace DevUtils.DateTimeExtensions
{
    /// <summary>
    /// Convert values to date
    /// </summary>
    public static class DateExtensions
    {
        #region TryParseDate
        #region string
        /// <summary>
        /// Convert string date to datetime
        /// </summary>
        /// <param name="strValue">string to convert</param>
        /// <param name="defaultValue">default value when invalid date</param>
        /// <param name="culture">date culture</param>
        /// <param name="dateTimeStyle">datetime style</param>
        /// <returns>datetime</returns>
        public static DateTime TryParseDate(this string strValue, DateTime defaultValue, CultureInfo culture, DateTimeStyles dateTimeStyle)
        {
            DateTime date;
            if (DateTime.TryParse(strValue, culture, dateTimeStyle, out date))
                return date;

            //FromOADate
            if (strValue.IsValidDouble(NumberStyles.Float, culture))
            {
                try
                {
                    return DateTime.FromOADate(strValue.TryParseDouble(-99));

                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }

            //FromBinary or FromFileTime
            if (!strValue.IsValidLong(NumberStyles.Integer, culture))
                return defaultValue;

            try
            {
                return DateTime.FromBinary(strValue.TryParseLong(-99));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            try
            {
                return DateTime.FromFileTime(strValue.TryParseLong(-99));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return defaultValue;
        }

        /// <summary>
        /// <para>Convert string date to datetime</para>
        /// <para>Return BaseDateTimeExtensions.GetCurrentDateTime() on error</para>
        /// </summary>
        /// <param name="strValue">string to convert</param>
        /// <param name="culture">date culture</param>
        /// <param name="dateTimeStyle">datetime style</param>
        /// <returns>datetime</returns>
        public static DateTime TryParseDate(this string strValue, CultureInfo culture, DateTimeStyles dateTimeStyle)
        {
            return strValue.TryParseDate(BaseDateTimeExtensions.GetCurrentDateTime(), culture, dateTimeStyle);
        }

        /// <summary>
        /// <para>Convert string date to datetime</para>
        /// </summary>
        /// <param name="strValue">string to convert</param>
        /// <param name="defaultValue">default value when invalid date</param>
        /// <returns>datetime</returns>
        public static DateTime TryParseDate(this string strValue, DateTime defaultValue)
        {
            return strValue.TryParseDate(defaultValue,
                BaseDateTimeExtensions.GetCurrentCulture(),
                BaseDateTimeExtensions.GetDefaultToDateDateTimeStyles());
        }

        /// <summary>
        /// <para>Convert string date to datetime</para>
        /// <para>Return BaseDateTimeExtensions.GetCurrentDateTime() on error</para>
        /// </summary>
        /// <param name="strValue">string to convert</param>
        /// <returns>datetime</returns>
        public static DateTime TryParseDate(this string strValue)
        {
            return strValue.TryParseDate(BaseDateTimeExtensions.GetCurrentDateTime(),
                BaseDateTimeExtensions.GetCurrentCulture(),
                BaseDateTimeExtensions.GetDefaultToDateDateTimeStyles());
        }
        #endregion

        #region double
        /// <summary>
        /// Convert double date to datetime
        /// </summary>
        /// <param name="doubleValue">string to convert</param>
        /// <param name="defaultValue">default value when invalid date</param>
        /// <param name="culture">date culture</param>
        /// <param name="dateTimeStyle">datetime style</param>
        /// <returns>datetime</returns>
        public static DateTime TryParseDate(this double doubleValue, DateTime defaultValue, CultureInfo culture, DateTimeStyles dateTimeStyle)
        {
            if (doubleValue <= 0)
                return defaultValue;

            //FromOADate
            try
            {
                return DateTime.FromOADate(doubleValue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            //FromBinary
            try
            {
                return DateTime.FromBinary(doubleValue.TryParseLong(-99));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            //FromFileTime
            try
            {
                return DateTime.FromFileTime(doubleValue.TryParseLong(-99));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return defaultValue;
        }

        /// <summary>
        /// <para>Convert double date to datetime</para>
        /// <para>Return BaseDateTimeExtensions.GetCurrentDateTime() on error</para>
        /// </summary>
        /// <param name="doubleValue">string to convert</param>
        /// <param name="culture">date culture</param>
        /// <param name="dateTimeStyle">datetime style</param>
        /// <returns>datetime</returns>
        public static DateTime TryParseDate(this double doubleValue, CultureInfo culture, DateTimeStyles dateTimeStyle)
        {
            return doubleValue.TryParseDate(BaseDateTimeExtensions.GetCurrentDateTime(), culture, dateTimeStyle);
        }

        /// <summary>
        /// <para>Convert double date to datetime</para>
        /// </summary>
        /// <param name="doubleValue">string to convert</param>
        /// <param name="defaultValue">default value when invalid date</param>
        /// <returns>datetime</returns>
        public static DateTime TryParseDate(this double doubleValue, DateTime defaultValue)
        {
            return doubleValue.TryParseDate(defaultValue,
                BaseDateTimeExtensions.GetCurrentCulture(),
                BaseDateTimeExtensions.GetDefaultToDateDateTimeStyles());
        }

        /// <summary>
        /// <para>Convert double date to datetime</para>
        /// <para>Return BaseDateTimeExtensions.GetCurrentDateTime() on error</para>
        /// </summary>
        /// <param name="doubleValue">string to convert</param>
        /// <returns>datetime</returns>
        public static DateTime TryParseDate(this double doubleValue)
        {
            return doubleValue.TryParseDate(BaseDateTimeExtensions.GetCurrentDateTime(),
                BaseDateTimeExtensions.GetCurrentCulture(),
                BaseDateTimeExtensions.GetDefaultToDateDateTimeStyles());
        }

        /// <summary>
        /// Convert double date to datetime
        /// </summary>
        /// <param name="doubleValue">string to convert</param>
        /// <param name="defaultValue">default value when invalid date</param>
        /// <param name="culture">date culture</param>
        /// <param name="dateTimeStyle">datetime style</param>
        /// <returns>datetime</returns>
        public static DateTime TryParseDate(this double? doubleValue, DateTime defaultValue, CultureInfo culture, DateTimeStyles dateTimeStyle)
        {
            if (doubleValue == null)
                return defaultValue;

            if (doubleValue <= 0)
                return defaultValue;

            return doubleValue.TryParseDouble(-99).TryParseDate(defaultValue, culture, dateTimeStyle);
        }

        /// <summary>
        /// <para>Convert double date to datetime</para>
        /// <para>Return BaseDateTimeExtensions.GetCurrentDateTime() on error</para>
        /// </summary>
        /// <param name="doubleValue">string to convert</param>
        /// <param name="culture">date culture</param>
        /// <param name="dateTimeStyle">datetime style</param>
        /// <returns>datetime</returns>
        public static DateTime TryParseDate(this double? doubleValue, CultureInfo culture, DateTimeStyles dateTimeStyle)
        {
            return doubleValue.TryParseDate(BaseDateTimeExtensions.GetCurrentDateTime(), culture, dateTimeStyle);
        }

        /// <summary>
        /// <para>Convert double date to datetime</para>
        /// </summary>
        /// <param name="doubleValue">string to convert</param>
        /// <param name="defaultValue">default value when invalid date</param>
        /// <returns>datetime</returns>
        public static DateTime TryParseDate(this double? doubleValue, DateTime defaultValue)
        {
            return doubleValue.TryParseDate(defaultValue,
                BaseDateTimeExtensions.GetCurrentCulture(),
                BaseDateTimeExtensions.GetDefaultToDateDateTimeStyles());
        }

        /// <summary>
        /// <para>Convert double date to datetime</para>
        /// <para>Return BaseDateTimeExtensions.GetCurrentDateTime() on error</para>
        /// </summary>
        /// <param name="doubleValue">string to convert</param>
        /// <returns>datetime</returns>
        public static DateTime TryParseDate(this double? doubleValue)
        {
            return doubleValue.TryParseDate(BaseDateTimeExtensions.GetCurrentDateTime(),
                BaseDateTimeExtensions.GetCurrentCulture(),
                BaseDateTimeExtensions.GetDefaultToDateDateTimeStyles());
        }
        #endregion 
        #endregion

        #region IsValidDate
        /// <summary>
        /// Test if string value is a valid date value
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <param name="culture">culture origin</param>
        /// <param name="dateTimeStyle">date style to convert</param>
        /// <returns>true/false</returns>
        public static bool IsValidDate(this string strValue, CultureInfo culture, DateTimeStyles dateTimeStyle)
        {
            try
            {
                var baseDate = DateTime.UtcNow;
                baseDate = (strValue == baseDate.ToString("O") ? baseDate.AddSeconds(1) : baseDate);
                var convertedValue = strValue.TryParseDate(baseDate, culture, dateTimeStyle);
                return convertedValue != baseDate;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return false;
        }

        /// <summary>
        /// Test if string value is a valid date value
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <returns>true/false</returns>
        public static bool IsValidDate(this string strValue)
        {
            return strValue.IsValidDate(
                BaseDateTimeExtensions.GetCurrentCulture(),
                BaseDateTimeExtensions.GetDefaultToDateDateTimeStyles());
        } 
        #endregion

        #region ToUtc
        /// <summary>
        /// Convert date to UtcDate
        /// </summary>
        /// <param name="date">date to convert</param>
        /// <param name="timezoneInfo">current date timezone info</param>
        /// <returns>utc date</returns>
        public static DateTime ToUtc(this DateTime date, TimeZoneInfo timezoneInfo)
        {
            return TimeZoneInfo.ConvertTimeToUtc(date, timezoneInfo);
        }

        /// <summary>
        /// Convert date to UtcDate
        /// </summary>
        /// <param name="date">date to convert</param>
        /// <param name="timezoneName">current date timezone name</param>
        /// <returns>utc date</returns>
        public static DateTime ToUtc(this DateTime date, string timezoneName)
        {
            try
            {
                var timezoneInfo = BaseDateTimeExtensions.GetTimezoneInfo(timezoneName);
                return timezoneInfo == null 
                    ? date 
                    : TimeZoneInfo.ConvertTimeToUtc(date, timezoneInfo);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return date;
            }
        }

        /// <summary>
        /// Convert date to UtcDate
        /// </summary>
        /// <param name="date">date to convert</param>
        /// <returns>utc date</returns>
        public static DateTime ToUtc(this DateTime date)
        {
            try
            {
                var timezoneInfo = BaseDateTimeExtensions.GetDefaultTimezoneInfo();
                return timezoneInfo == null
                    ? date
                    : TimeZoneInfo.ConvertTimeToUtc(date, timezoneInfo);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return date;
            }
        }
        #endregion
    }
}