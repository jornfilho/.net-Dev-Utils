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

            #region FromOADate
            if (strValue.IsValidDouble(NumberStyles.Float, culture))
            {
                var doubleValue = strValue.TryParseDouble(-99);
                if (doubleValue >= -657434.999 && doubleValue <= 2593589)
                {
                    try
                    {
                        return DateTime.FromOADate(doubleValue);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                    }
                }
            } 
            #endregion
            
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

        /// <summary>
        /// Convert nullable date to datetime
        /// </summary>
        /// <param name="nullableDate">nullable date to convert</param>
        /// <param name="defaultValue">default value when invalid date</param>
        /// <returns>datetime</returns>
        public static DateTime TryParseDate(this DateTime? nullableDate, DateTime defaultValue)
        {
            return nullableDate == null
                ? defaultValue
                : (DateTime) nullableDate;
        }

        /// <summary>
        /// Convert nullable date to datetime
        /// </summary>
        /// <param name="nullableDate">nullable date to convert</param>
        /// <returns>datetime</returns>
        public static DateTime TryParseDate(this DateTime? nullableDate)
        {
            return nullableDate.TryParseDate(BaseDateTimeExtensions.GetCurrentDateTime());
        }
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
            try
            {
                return TimeZoneInfo.ConvertTime(date, timezoneInfo).ToUniversalTime();
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
        /// <param name="timezoneName">current date timezone name</param>
        /// <returns>utc date</returns>
        public static DateTime ToUtc(this DateTime date, string timezoneName)
        {
            var timezoneInfo = BaseDateTimeExtensions.GetTimezoneInfo(timezoneName);
            return date.ToUtc(timezoneInfo);
        }

        /// <summary>
        /// Convert date to UtcDate
        /// </summary>
        /// <param name="date">date to convert</param>
        /// <returns>utc date</returns>
        public static DateTime ToUtc(this DateTime date)
        {
            var timezoneInfo = BaseDateTimeExtensions.GetDefaultTimezoneInfo();
            return date.ToUtc(timezoneInfo);
        }
        #endregion

        #region ToUnixTimestamp
        /// <summary>
        /// Convert date to unix timestamp based in secods
        /// </summary>
        /// <param name="date">date to convert</param>
        /// <param name="timezoneInfo">current date timezone info</param>
        /// <returns>unix timestamp</returns>
        public static long ToUnixTimestamp(this DateTime date, TimeZoneInfo timezoneInfo)
        {
            try
            {
                return (date.ToUtc(timezoneInfo) - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds.TryParseLong();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return 0;
            }
        }

        /// <summary>
        /// Convert date to unix timestamp based in secods
        /// </summary>
        /// <param name="date">date to convert</param>
        /// <param name="timezoneName">current date timezone name</param>
        /// <returns>unix timestamp</returns>
        public static long ToUnixTimestamp(this DateTime date, string timezoneName)
        {
            var timezoneInfo = BaseDateTimeExtensions.GetTimezoneInfo(timezoneName);
            return date.ToUnixTimestamp(timezoneInfo);
        }

        /// <summary>
        /// Convert date to unix timestamp based in secods
        /// </summary>
        /// <param name="date">date to convert</param>
        /// <returns>unix timestamp</returns>
        public static long ToUnixTimestamp(this DateTime date)
        {
            var timezoneInfo = BaseDateTimeExtensions.GetDefaultTimezoneInfo();
            return date.ToUnixTimestamp(timezoneInfo);
        }

        /// <summary>
        /// Convert date to unix timestamp based in milisecods
        /// </summary>
        /// <param name="date">date to convert</param>
        /// <param name="timezoneInfo">current date timezone info</param>
        /// <returns>unix timestamp</returns>
        public static long ToUnixTimestampMilisecondsBased(this DateTime date, TimeZoneInfo timezoneInfo)
        {
            try
            {
                return (date.ToUtc(timezoneInfo) - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds.TryParseLong();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return 0;
            }
        }

        /// <summary>
        /// Convert date to unix timestamp based in milisecods
        /// </summary>
        /// <param name="date">date to convert</param>
        /// <param name="timezoneName">current date timezone name</param>
        /// <returns>unix timestamp</returns>
        public static long ToUnixTimestampMilisecondsBased(this DateTime date, string timezoneName)
        {
            var timezoneInfo = BaseDateTimeExtensions.GetTimezoneInfo(timezoneName);
            return date.ToUnixTimestampMilisecondsBased(timezoneInfo);
        }

        /// <summary>
        /// Convert date to unix timestamp based in milisecods
        /// </summary>
        /// <param name="date">date to convert</param>
        /// <returns>unix timestamp</returns>
        public static long ToUnixTimestampMilisecondsBased(this DateTime date)
        {
            var timezoneInfo = BaseDateTimeExtensions.GetDefaultTimezoneInfo();
            return date.ToUnixTimestampMilisecondsBased(timezoneInfo);
        }

        #endregion

        #region FromUnixTimestamp
        /// <summary>
        /// Convert unix timestamp to date
        /// </summary>
        /// <param name="unixTimestap">unix to convert</param>
        /// <returns>datetime</returns>
        public static DateTime FromUnixTimestamp(this long unixTimestap)
        {
            try
            {
                return (new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).AddSeconds(unixTimestap.TryParseDouble(0));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return BaseDateTimeExtensions.GetCurrentDateTime();
            }
        }
        #endregion

        #region ToTimezoneDate
        /// <summary>
        /// Convert date to an especific timezone
        /// </summary>
        /// <param name="date">date to convert</param>
        /// <param name="currentTimeZoneInfo">current date timezone info</param>
        /// <param name="destinationTimeZoneInfo">destination date timezone info</param>
        /// <returns>date on especific timezone</returns>
        public static DateTime ToTimezoneDate(this DateTime date, TimeZoneInfo currentTimeZoneInfo, TimeZoneInfo destinationTimeZoneInfo)
        {
            try
            {
                return TimeZoneInfo.ConvertTime(date.ToUtc(currentTimeZoneInfo), destinationTimeZoneInfo);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return date;
            }
        }

        /// <summary>
        /// Convert date to an especific timezone
        /// </summary>
        /// <param name="date">date to convert</param>
        /// <param name="currentTimeZoneName">current date timezone name</param>
        /// <param name="destinationTimeZoneInfo">destination date timezone info</param>
        /// <returns>date on especific timezone</returns>
        public static DateTime ToTimezoneDate(this DateTime date, string currentTimeZoneName, TimeZoneInfo destinationTimeZoneInfo)
        {
            var currentTimezone = BaseDateTimeExtensions.GetTimezoneInfo(currentTimeZoneName);
            return date.ToTimezoneDate(currentTimezone, destinationTimeZoneInfo);
        }

        /// <summary>
        /// Convert date to an especific timezone
        /// </summary>
        /// <param name="date">date to convert</param>
        /// <param name="currentTimezoneInfo">current date timezone info</param>
        /// <param name="destinationTimeZoneName">destination date timezone name</param>
        /// <returns>date on especific timezone</returns>
        public static DateTime ToTimezoneDate(this DateTime date, TimeZoneInfo currentTimezoneInfo, string destinationTimeZoneName)
        {
            var destinationTimezone = BaseDateTimeExtensions.GetTimezoneInfo(destinationTimeZoneName);
            return date.ToTimezoneDate(currentTimezoneInfo, destinationTimezone);
        }

        /// <summary>
        /// Convert date to an especific timezone
        /// </summary>
        /// <param name="date">date to convert</param>
        /// <param name="currentTimeZoneName">current date timezone name</param>
        /// <param name="destinationTimeZoneName">destination date timezone name</param>
        /// <returns>date on especific timezone</returns>
        public static DateTime ToTimezoneDate(this DateTime date, string currentTimeZoneName, string destinationTimeZoneName)
        {
            var currentTimezone = BaseDateTimeExtensions.GetTimezoneInfo(currentTimeZoneName);
            var destinationTimezone = BaseDateTimeExtensions.GetTimezoneInfo(destinationTimeZoneName);
            return date.ToTimezoneDate(currentTimezone, destinationTimezone);
        }

        /// <summary>
        /// Convert date to an especific timezone
        /// </summary>
        /// <param name="date">date to convert</param>
        /// <param name="destinationTimeZoneInfo">destination date timezone info</param>
        /// <returns>date on especific timezone</returns>
        public static DateTime ToTimezoneDate(this DateTime date, TimeZoneInfo destinationTimeZoneInfo)
        {
            return date.ToTimezoneDate(BaseDateTimeExtensions.GetDefaultTimezoneInfo(), destinationTimeZoneInfo);
        }

        /// <summary>
        /// Convert date to an especific timezone
        /// </summary>
        /// <param name="date">date to convert</param>
        /// <param name="destinationTimeZoneName">destination date timezone name</param>
        /// <returns>date on especific timezone</returns>
        public static DateTime ToTimezoneDate(this DateTime date, string destinationTimeZoneName)
        {
            var destinationTimezone = BaseDateTimeExtensions.GetTimezoneInfo(destinationTimeZoneName);
            return date.ToTimezoneDate(BaseDateTimeExtensions.GetDefaultTimezoneInfo(), destinationTimezone);
        }
        #endregion

        #region GetWeekNumber
        /// <summary>
        /// Get the week number of a date
        /// </summary>
        /// <param name="date">Date to get week number</param>
        /// <param name="weekRule">Rule to calculate week number</param>
        /// <param name="firstWeekDay">First day of week</param>
        /// <returns>Week number or -1 when error</returns>
        public static int GetWeekNumber(this DateTime date, CalendarWeekRule weekRule, DayOfWeek firstWeekDay)
        {
            try
            {
                // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
                // be the same week# as whatever Thursday, Friday or Saturday are,
                // and we always get those right
                var day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
                if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
                    date = date.AddDays(3);

                // Return the week of our adjusted day
                return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, weekRule, firstWeekDay);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return -1;
            }
        }

        /// <summary>
        /// <para>Get the week number of a date</para>
        /// <para>Use BaseDateTimeExtensions.GetDefaultFirstWeekDay() as  first week day</para>
        /// </summary>
        /// <param name="date">Date to get week number</param>
        /// <param name="weekRule">Rule to calculate week number</param>
        /// <returns>Week number or -1 when error</returns>
        public static int GetWeekNumber(this DateTime date, CalendarWeekRule weekRule)
        {
            return date.GetWeekNumber(weekRule, BaseDateTimeExtensions.GetDefaultFirstWeekDay());
        }

        /// <summary>
        /// <para>Get the week number of a date</para>
        /// <para>Use BaseDateTimeExtensions.GetDefaultCalendarRule() as default calendar rule</para>
        /// </summary>
        /// <param name="date">Date to get week number</param>
        /// <param name="firstWeekDay">First day of week</param>
        /// <returns>Week number or -1 when error</returns>
        public static int GetWeekNumber(this DateTime date, DayOfWeek firstWeekDay)
        {
            return date.GetWeekNumber(BaseDateTimeExtensions.GetDefaultCalendarRule(), firstWeekDay);
        }

        /// <summary>
        /// <para>Get the week number of a date</para>
        /// <para>Use BaseDateTimeExtensions.GetDefaultCalendarRule() as default calendar rule</para>
        /// <para>Use BaseDateTimeExtensions.GetDefaultFirstWeekDay() as first week day</para>
        /// </summary>
        /// <param name="date">Date to get week number</param>
        /// <returns>Week number or -1 when error</returns>
        public static int GetWeekNumber(this DateTime date)
        {
            return date.GetWeekNumber(BaseDateTimeExtensions.GetDefaultCalendarRule(),
                BaseDateTimeExtensions.GetDefaultFirstWeekDay());
        } 
        #endregion

        #region SetAsUtc
        /// <summary>
        /// <para>Convert date local to utc</para>
        /// <para>Only change date local, don`t convert date and time</para>
        /// </summary>
        /// <param name="date">Date to set local</param>
        /// <returns>Date as UTC</returns>
        public static DateTime SetAsUtc(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond, DateTimeKind.Utc);
        } 
        #endregion
    }
}