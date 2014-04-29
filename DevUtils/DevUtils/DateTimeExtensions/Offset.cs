using System;
using DevUtils.PrimitivesExtensions;

namespace DevUtils.DateTimeExtensions
{
    /// <summary>
    /// Datetime offset utils class
    /// </summary>
    public static class Offset
    {
        /// <summary>
        /// Get datetime offset minutes from utc
        /// </summary>
        /// <param name="date">Datetime</param>
        /// <param name="timezoneInfo">Timezoneinfo</param>
        /// <returns>Minutes from utc</returns>
        public static int GetDateTimeOffsetMinutes(this DateTime date, TimeZoneInfo timezoneInfo)
        {
            return timezoneInfo == null 
                ? 0 
                : timezoneInfo.GetUtcOffset(date).TotalMinutes.TryParseInt();
        }

        /// <summary>
        /// Get datetime offset minutes from utc
        /// </summary>
        /// <param name="date">Datetime</param>
        /// <param name="timezoneName">timezone name</param>
        /// <returns>Minutes from utc</returns>
        public static int GetDateTimeOffsetMinutes(this DateTime date, string timezoneName)
        {
            return date.GetDateTimeOffsetMinutes(BaseDateTimeExtensions.GetTimezoneInfo(timezoneName));
        }

        /// <summary>
        /// Get datetime offset minutes from utc
        /// </summary>
        /// <param name="date">Datetime</param>
        /// <returns>Minutes from utc</returns>
        public static int GetDateTimeOffsetMinutes(this DateTime date)
        {
            return date.GetDateTimeOffsetMinutes(TimeZoneInfo.Local);
        }
    }
}
