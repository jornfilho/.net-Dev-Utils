using System;
using System.Diagnostics;
using System.Linq;

namespace DevUtils.DateTimeExtensions
{
    /// <summary>
    /// Date urils class
    /// </summary>
    public static class Utils
    {
        #region add business days
        /// <summary>
        /// Add business days on a DateTime
        /// </summary>
        /// <param name="date">Date to add days</param>
        /// <param name="days">Days to add</param>
        /// <param name="businessDays">Business days</param>
        /// <returns>date</returns>
        public static DateTime AddBusinessDays(this DateTime date, int days, DayOfWeek[] businessDays)
        {
            days = Math.Abs(days);
            if (businessDays == null || businessDays.Count() == 0)
                businessDays = BaseDateTimeExtensions.GetDefaultBusinessDays();

            var finalCount = 0;
            while (true)
            {
                if (businessDays.Contains(date.DayOfWeek))
                    finalCount++;

                date = date.AddDays(1);

                if (days == finalCount)
                    break;
            }

            return date;
        }

        /// <summary>
        /// Add business days on a DateTime
        /// </summary>
        /// <param name="date">Date to add days</param>
        /// <param name="days">Days to add</param>
        /// <returns>date</returns>
        public static DateTime AddBusinessDays(this DateTime date, int days)
        {
            return date.AddBusinessDays(days, null);
        }
        #endregion

        #region remove business days
        /// <summary>
        /// Remove business days on a DateTime
        /// </summary>
        /// <param name="date">Date to remove days</param>
        /// <param name="days">Days to remove</param>
        /// <param name="businessDays">Business days</param>
        /// <returns>date</returns>
        public static DateTime RemoveBusinessDays(this DateTime date, int days, DayOfWeek[] businessDays)
        {
            days = Math.Abs(days);
            if (businessDays == null || businessDays.Count() == 0)
                businessDays = BaseDateTimeExtensions.GetDefaultBusinessDays();

            var finalCount = 0;
            while (true)
            {
                if (businessDays.Contains(date.DayOfWeek))
                    finalCount++;

                date = date.AddDays(-1);

                if (days == finalCount)
                    break;
            }

            return date;
        }

        /// <summary>
        /// Remove business days on a DateTime
        /// </summary>
        /// <param name="date">Date to remove days</param>
        /// <param name="days">Days to remove</param>
        /// <returns>date</returns>
        public static DateTime RemoveBusinessDays(this DateTime date, int days)
        {
            return date.RemoveBusinessDays(days, null);
        }
        #endregion

        #region set date
        /// <summary>
        /// Set date of datetime
        /// </summary>
        /// <param name="date">Date to set date</param>
        /// <param name="year">Year to set</param>
        /// <param name="month">Month to set</param>
        /// <param name="day">Day to set</param>
        /// <returns>new date</returns>
        public static DateTime SetDate(this DateTime date, int year, int month, int day)
        {
            try
            {
                year = Math.Abs(year);
                month = Math.Abs(month);
                day = Math.Abs(day);

                if (month > 12)
                    month = 12;

                if (day > 31)
                    day = 31;

                return new DateTime(year, month, day, date.Hour, date.Minute, date.Second, date.Millisecond, date.Kind);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return date;
            }
        }

        /// <summary>
        /// Set year of date
        /// </summary>
        /// <param name="date">Date to set date</param>
        /// <param name="year">Year to set</param>
        /// <returns>new date</returns>
        public static DateTime SetYear(this DateTime date, int year)
        {
            return date.SetDate(year, date.Month, date.Day);
        }

        /// <summary>
        /// Set month of date
        /// </summary>
        /// <param name="date">Date to set date</param>
        /// <param name="month">Month to set</param>
        /// <returns>new date</returns>
        public static DateTime SetMonth(this DateTime date, int month)
        {
            return date.SetDate(date.Year, month, date.Day);
        }

        /// <summary>
        /// Set day of date
        /// </summary>
        /// <param name="date">Date to set date</param>
        /// <param name="day">Day to set</param>
        /// <returns>new date</returns>
        public static DateTime SetDay(this DateTime date, int day)
        {
            return date.SetDate(date.Year, date.Month, day);
        }
        #endregion

        #region set time
        /// <summary>
        /// Set time of date
        /// </summary>
        /// <param name="date">Date to add time</param>
        /// <param name="hour">Hours to add</param>
        /// <param name="minute">Minutes to add</param>
        /// <param name="second">Seconds to add</param>
        /// <param name="millisecond">Milliseconds to add</param>
        /// <returns>Date with new time</returns>
        public static DateTime SetTime(this DateTime date, int hour, int minute, int second, int millisecond)
        {
            try
            {
                hour = Math.Abs(hour);
                minute = Math.Abs(minute);
                second = Math.Abs(second);
                millisecond = Math.Abs(millisecond);

                if (hour > 23)
                    hour = 23;

                if (minute > 59)
                    minute = 59;

                if (second > 59)
                    second = 59;

                if (millisecond > 999)
                    millisecond = 999;

                return new DateTime(date.Year, date.Month, date.Day, hour, minute, second, millisecond, date.Kind);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return date;
            }
        }

        /// <summary>
        /// Set time of date
        /// </summary>
        /// <param name="date">Date to add time</param>
        /// <param name="hour">Hours to add</param>
        /// <param name="minute">Minutes to add</param>
        /// <param name="second">Seconds to add</param>
        /// <returns>Date with new time</returns>
        public static DateTime SetTime(this DateTime date, int hour, int minute, int second)
        {
            return date.SetTime(hour, minute, second, date.Millisecond);
        }

        /// <summary>
        /// Set time of date
        /// </summary>
        /// <param name="date">Date to add time</param>
        /// <param name="hour">Hours to add</param>
        /// <param name="minute">Minutes to add</param>
        /// <returns>Date with new time</returns>
        public static DateTime SetTime(this DateTime date, int hour, int minute)
        {
            return date.SetTime(hour, minute, date.Second, date.Millisecond);
        }

        /// <summary>
        /// Set hour of date
        /// </summary>
        /// <param name="date">Date to set time</param>
        /// <param name="hour">Hours to set</param>
        /// <returns>Date with new time</returns>
        public static DateTime SetHour(this DateTime date, int hour)
        {
            return date.SetTime(hour, date.Minute, date.Second, date.Millisecond);
        }

        /// <summary>
        /// Set minute of date
        /// </summary>
        /// <param name="date">Date to set time</param>
        /// <param name="minute">Minute to set</param>
        /// <returns>Date with new time</returns>
        public static DateTime SetMinute(this DateTime date, int minute)
        {
            return date.SetTime(date.Hour, minute, date.Second, date.Millisecond);
        }

        /// <summary>
        /// Set second of date
        /// </summary>
        /// <param name="date">Date to set time</param>
        /// <param name="second">Second to set</param>
        /// <returns>Date with new time</returns>
        public static DateTime SetSecond(this DateTime date, int second)
        {
            return date.SetTime(date.Hour, date.Minute, second, date.Millisecond);
        }

        /// <summary>
        /// Set millisecond of date
        /// </summary>
        /// <param name="date">Date to set time</param>
        /// <param name="millisecond">Millisecond to set</param>
        /// <returns>Date with new time</returns>
        public static DateTime SetMillisecond(this DateTime date, int millisecond)
        {
            return date.SetTime(date.Hour, date.Minute, date.Second, millisecond);
        }
        #endregion

        #region start of year
        /// <summary>
        /// Get start of year
        /// </summary>
        /// <param name="date">base date</param>
        /// <returns>Start of year from date</returns>
        public static DateTime StartOfYear(this DateTime date)
        {
            return new DateTime(date.Year, 1, 1, 0, 0, 0, 0, date.Kind);
        }

        /// <summary>
        /// Get start of year
        /// </summary>
        /// <param name="year">year reference</param>
        /// <returns>start of year from reference year</returns>
        public static DateTime StartOfYear(int year)
        {
            return new DateTime(Math.Abs(year), 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
        }

        /// <summary>
        /// Get start of business year
        /// </summary>
        /// <param name="date">base date</param>
        /// <param name="businessDays">business days list</param>
        /// <returns>Start of business year from date</returns>
        public static DateTime StartOfBusinessYear(this DateTime date, DayOfWeek[] businessDays)
        {
            date = date.StartOfYear();

            if (businessDays == null || businessDays.Count() == 0)
                businessDays = BaseDateTimeExtensions.GetDefaultBusinessDays();

            while (true)
            {
                if (businessDays.Contains(date.DayOfWeek))
                    return date;

                date = date.AddDays(1);
            }
        }

        /// <summary>
        /// Get start of business year
        /// </summary>
        /// <param name="date">base date</param>
        /// <returns>Start of business year from date</returns>
        public static DateTime StartOfBusinessYear(this DateTime date)
        {
            return date.StartOfBusinessYear(null);
        }

        /// <summary>
        /// Get start of business year
        /// </summary>
        /// <param name="year">year reference</param>
        /// <param name="businessDays">business days list</param>
        /// <returns>start of business year from reference year</returns>
        public static DateTime StartOfBusinessYear(int year, DayOfWeek[] businessDays)
        {
            return StartOfYear(year).StartOfBusinessYear(businessDays);
        }

        /// <summary>
        /// Get start of business year
        /// </summary>
        /// <param name="year">year reference</param>
        /// <returns>start of business year from reference year</returns>
        public static DateTime StartOfBusinessYear(int year)
        {
            return StartOfBusinessYear(year, null);
        }
        #endregion

        #region end of year
        /// <summary>
        /// Get end of year
        /// </summary>
        /// <param name="date">base date</param>
        /// <returns>End of year from date</returns>
        public static DateTime EndOfYear(this DateTime date)
        {
            return new DateTime(date.Year, 12, DateTime.DaysInMonth(date.Year, 12), 23, 59, 59, 999, date.Kind);
        }

        /// <summary>
        /// Get end of year
        /// </summary>
        /// <param name="year">reference year</param>
        /// <returns>End of year from reference year</returns>
        public static DateTime EndOfYear(int year)
        {
            return new DateTime(Math.Abs(year), 12, DateTime.DaysInMonth(Math.Abs(year), 12), 23, 59, 59, 999, DateTimeKind.Local);
        }

        /// <summary>
        /// Get end of business year
        /// </summary>
        /// <param name="date">base date</param>
        /// <param name="businessDays">business days list</param>
        /// <returns>End of business year from date</returns>
        public static DateTime EndOfBusinessYear(this DateTime date, DayOfWeek[] businessDays)
        {
            date = date.EndOfYear();

            if (businessDays == null || businessDays.Count() == 0)
                businessDays = BaseDateTimeExtensions.GetDefaultBusinessDays();
            
            while (true)
            {
                if (businessDays.Contains(date.DayOfWeek))
                    return date;

                date = date.AddDays(-1);
            }
        }

        /// <summary>
        /// Get end of business year
        /// </summary>
        /// <param name="date">base date</param>
        /// <returns>End of business year from date</returns>
        public static DateTime EndOfBusinessYear(this DateTime date)
        {
            return date.EndOfBusinessYear(null);
        }

        /// <summary>
        /// Get end of business year
        /// </summary>
        /// <param name="year">reference year</param>
        /// <param name="businessDays">business days list</param>
        /// <returns>End of business year from reference year</returns>
        public static DateTime EndOfBusinessYear(int year, DayOfWeek[] businessDays)
        {
            return EndOfYear(year).EndOfBusinessYear(businessDays);
        }

        /// <summary>
        /// Get end of business year
        /// </summary>
        /// <param name="year">reference year</param>
        /// <returns>End of business year from reference year</returns>
        public static DateTime EndOfBusinessYear(int year)
        {
            return EndOfYear(year).EndOfBusinessYear(null);
        }
        #endregion

        #region start of month
        /// <summary>
        /// Get start of month
        /// </summary>
        /// <param name="date">base date</param>
        /// <returns>Start of month from date</returns>
        public static DateTime StartOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1, 0, 0, 0, 0, date.Kind);
        }

        /// <summary>
        /// Get start of month from year/month
        /// </summary>
        /// <param name="month">month reference</param>
        /// <param name="year">year reference</param>
        /// <returns>start of month from reference year and month</returns>
        public static DateTime StartOfMonth(Month month, int year)
        {
            return new DateTime(Math.Abs(year), (int)month, 1, 0, 0, 0, 0, DateTimeKind.Local);
        }

        /// <summary>
        /// Get start of business month
        /// </summary>
        /// <param name="date">base date</param>
        /// <param name="businessDays">business days list</param>
        /// <returns>Start of business month from date</returns>
        public static DateTime StartOfBusinessMonth(this DateTime date, DayOfWeek[] businessDays)
        {
            date = date.StartOfMonth();
            
            if (businessDays == null || businessDays.Count() == 0)
                businessDays = BaseDateTimeExtensions.GetDefaultBusinessDays();

            while (true)
            {
                if (businessDays.Contains(date.DayOfWeek))
                    return date;

                date = date.AddDays(1);
            }
        }

        /// <summary>
        /// Get start of business month
        /// </summary>
        /// <param name="date">base date</param>
        /// <returns>Start of business month from date</returns>
        public static DateTime StartOfBusinessMonth(this DateTime date)
        {
            return date.StartOfBusinessMonth(null);
        }

        /// <summary>
        /// Get start of month from year/month
        /// </summary>
        /// <param name="month">month reference</param>
        /// <param name="year">year reference</param>
        /// <param name="businessDays">business days list</param>
        /// <returns>start of business month from reference year and month</returns>
        public static DateTime StartOfBusinessMonth(Month month, int year, DayOfWeek[] businessDays)
        {
            return StartOfMonth(month, year).StartOfBusinessMonth(businessDays);
        } 

        /// <summary>
        /// Get start of month from year/month
        /// </summary>
        /// <param name="month">month reference</param>
        /// <param name="year">year reference</param>
        /// <returns>start of business month from reference year and month</returns>
        public static DateTime StartOfBusinessMonth(Month month, int year)
        {
            return StartOfBusinessMonth(month, year, null);
        } 
        #endregion

        #region end of month
        /// <summary>
        /// Get end of month
        /// </summary>
        /// <param name="date">base date</param>
        /// <returns>End of month from date</returns>
        public static DateTime EndOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month), 23, 59, 59, 999, date.Kind);
        }

        /// <summary>
        /// Get end of month from year/month
        /// </summary>
        /// <param name="month">month reference</param>
        /// <param name="year">year reference</param>
        /// <returns>end of month from reference year and month</returns>
        public static DateTime EndOfMonth(Month month, int year)
        {
            return new DateTime(Math.Abs(year), (int)month, DateTime.DaysInMonth(year, (int)month), 23, 59, 59, 999, DateTimeKind.Local);
        }

        /// <summary>
        /// Get end of business month
        /// </summary>
        /// <param name="date">base date</param>
        /// <param name="businessDays">business days list</param>
        /// <returns>End of business month from date</returns>
        public static DateTime EndOfBusinessMonth(this DateTime date, DayOfWeek[] businessDays)
        {
            date = date.EndOfMonth();

            if (businessDays == null || businessDays.Count() == 0)
                businessDays = BaseDateTimeExtensions.GetDefaultBusinessDays();

            while (true)
            {
                if (businessDays.Contains(date.DayOfWeek))
                    return date;

                date = date.AddDays(-1);
            }
        }

        /// <summary>
        /// Get end of business month
        /// </summary>
        /// <param name="date">base date</param>
        /// <returns>End of business month from date</returns>
        public static DateTime EndOfBusinessMonth(this DateTime date)
        {
            return date.EndOfBusinessMonth(null);
        }

        /// <summary>
        /// Get end of month from year/month
        /// </summary>
        /// <param name="month">month reference</param>
        /// <param name="year">year reference</param>
        /// <param name="businessDays">business days list</param>
        /// <returns>End of business month from reference year and month</returns>
        public static DateTime EndOfBusinessMonth(Month month, int year, DayOfWeek[] businessDays)
        {
            return EndOfMonth(month, year).EndOfBusinessMonth(businessDays);
        }

        /// <summary>
        /// Get end of month from year/month
        /// </summary>
        /// <param name="month">month reference</param>
        /// <param name="year">year reference</param>
        /// <returns>End of business month from reference year and month</returns>
        public static DateTime EndOfBusinessMonth(Month month, int year)
        {
            return EndOfBusinessMonth(month, year, null);
        } 
        #endregion

        #region start of week
        /// <summary>
        /// Get start of week
        /// </summary>
        /// <param name="date">base date</param>
        /// <param name="firstDay">first week day</param>
        /// <returns>Start of week from date</returns>
        public static DateTime StartOfWeek(this DateTime date, DayOfWeek firstDay)
        {
            while (true)
            {
                if (date.DayOfWeek == firstDay)
                    return date.StartOfDay();

                date = (int)firstDay > (int)date.DayOfWeek
                    ? date.AddDays(1)
                    : date.AddDays(-1);
            }
        }

        /// <summary>
        /// Get start of week
        /// </summary>
        /// <param name="date">base date</param>
        /// <returns>Start of week from date</returns>
        public static DateTime StartOfWeek(this DateTime date)
        {
            return date.StartOfWeek(BaseDateTimeExtensions.GetDefaultFirstWeekDay());
        }

        /// <summary>
        /// Get start of business week
        /// </summary>
        /// <param name="date">base date</param>
        /// <param name="firstBusinessDay">first week business day</param>
        /// <returns>Start of business week from date</returns>
        public static DateTime StartOfBusinessWeek(this DateTime date, DayOfWeek firstBusinessDay)
        {
            while (true)
            {
                if (date.DayOfWeek == firstBusinessDay)
                    return date.StartOfDay();

                date = (int)firstBusinessDay > (int)date.DayOfWeek 
                    ? date.AddDays(1)
                    : date.AddDays(-1);
            }
        }

        /// <summary>
        /// Get start of business week
        /// </summary>
        /// <param name="date">base date</param>
        /// <returns>Start of business week from date</returns>
        public static DateTime StartOfBusinessWeek(this DateTime date)
        {
            return date.StartOfBusinessWeek(BaseDateTimeExtensions.GetDefaultFirstWeekBusinessDay());
        }
        #endregion

        #region end of week
        /// <summary>
        /// Get end of week
        /// </summary>
        /// <param name="date">base date</param>
        /// <param name="lastDay">last week day</param>
        /// <returns>End of week from date</returns>
        public static DateTime EndOfWeek(this DateTime date, DayOfWeek lastDay)
        {
            while (true)
            {
                if (date.DayOfWeek == lastDay)
                    return date.EndOfDay();

                date = (int)lastDay > (int)date.DayOfWeek
                    ? date.AddDays(1)
                    : date.AddDays(-1);
            }
        }

        /// <summary>
        /// Get end of week
        /// </summary>
        /// <param name="date">base date</param>
        /// <returns>End of week from date</returns>
        public static DateTime EndOfWeek(this DateTime date)
        {
            return date.EndOfWeek(BaseDateTimeExtensions.GetDefaultLastWeekDay());
        }

        /// <summary>
        /// Get end of business week
        /// </summary>
        /// <param name="date">base date</param>
        /// <param name="lastBusinessDay">last week business day</param>
        /// <returns>End of business week from date</returns>
        public static DateTime EndOfBusinessWeek(this DateTime date, DayOfWeek lastBusinessDay)
        {
            while (true)
            {
                if (date.DayOfWeek == lastBusinessDay)
                    return date.EndOfDay();

                date = (int)lastBusinessDay > (int)date.DayOfWeek
                    ? date.AddDays(1)
                    : date.AddDays(-1);
            }
        }

        /// <summary>
        /// Get end of business week
        /// </summary>
        /// <param name="date">base date</param>
        /// <returns>End of business week from date</returns>
        public static DateTime EndOfBusinessWeek(this DateTime date)
        {
            return date.EndOfBusinessWeek(BaseDateTimeExtensions.GetDefaultLastWeekBusinessDay());
        }
        #endregion

        #region start of day
        /// <summary>
        /// Get start of day
        /// </summary>
        /// <param name="date">base date</param>
        /// <returns>Start of day from date</returns>
        public static DateTime StartOfDay(this DateTime date)
        {
            return date.SetTime(0, 0, 0, 0);
        }
        #endregion

        #region end of day
        /// <summary>
        /// Get end of day
        /// </summary>
        /// <param name="date">base date</param>
        /// <returns>End of day from date</returns>
        public static DateTime EndOfDay(this DateTime date)
        {
            return date.SetTime(23, 59, 59, 999);
        }
        #endregion
    }
}
