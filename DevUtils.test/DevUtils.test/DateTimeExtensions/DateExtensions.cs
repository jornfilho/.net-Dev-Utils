using System;
using System.Globalization;
using DevUtils.DateTimeExtensions;
using DevUtils.PrimitivesExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.DateTimeExtensions
{
    /// <summary>
    /// Offset test class
    /// </summary>
    [TestClass]
    public class DateExtensions
    {
        #region params
        private CultureInfo Culture { get; set; }
        private DateTimeStyles DateTimeStyles { get; set; }
        private int DateInterval { get; set; }
        private DateTime UtcDate { get; set; } 
        private DateTime LocalDate { get; set; } 
        private TimeZoneInfo UtcTimeZoneInfo { get; set; } 
        private TimeZoneInfo LocalTimeZoneInfo { get; set; } 
        private string UtcTimeZoneName { get; set; }
        private string LocalTimeZoneName { get; set; }
        private TimeZoneInfo OtherTimeZoneInfo { get; set; } 
        private string OtherTimeZoneName { get; set; } 
        #endregion

        #region constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DateExtensions()
        {
            Culture = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetCurrentCulture();
            DateTimeStyles = DateTimeStyles.AssumeUniversal;

            DateInterval = 10;
            UtcDate = DateTime.UtcNow;
            LocalDate = DateTime.Now;

            UtcTimeZoneName = "UTC";
            LocalTimeZoneName = TimeZoneInfo.Local.Id;
            OtherTimeZoneName = "Africa/Douala";

            UtcTimeZoneInfo = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfo(UtcTimeZoneName);
            LocalTimeZoneInfo = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfo(LocalTimeZoneName);
            OtherTimeZoneInfo = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfo(OtherTimeZoneName);
        } 
        #endregion

        #region TryParseDate
        /// <summary>
        /// Test method TryParseDate with string date
        /// </summary>
        [TestMethod]
        public void TryParseDate_string()
        {
            var date1 = UtcDate;
            var date2 = UtcDate.AddDays(DateInterval);
            var date3 = UtcDate.AddMonths(DateInterval);
            var date4 = LocalDate;
            
            var date1Str = date1.ToString("g");
            var date2Str = date2.ToString("g");
            var date3Str = date3.ToString("g");
            var date4Str = date4.ToString("O");
            
            #region string date
            Assert.AreEqual(date1.ToString("g"), date1Str.TryParseDate().ToUtc().ToString("g"));
            Assert.AreEqual(date2.ToString("g"), date2Str.TryParseDate().ToUtc().ToString("g"));
            Assert.AreEqual(date3.ToString("g"), date3Str.TryParseDate().ToUtc().ToString("g"));
            Assert.AreEqual(date4.ToString("g"), date4Str.TryParseDate().ToString("g"));
            Assert.AreEqual(date4.ToUtc().ToString("g"), date4Str.TryParseDate().ToUtc().ToString("g"));
            Assert.AreEqual(date4.ToString("g"), date4Str.TryParseDate().ToTimezoneDate(LocalTimeZoneName).ToString("g"));
            Assert.AreEqual(date1.ToString("g"), "".TryParseDate().ToUtc().ToString("g"));

            Assert.AreEqual(date1.ToString("g"), date1Str.TryParseDate(date1).ToUtc().ToString("g"));
            Assert.AreEqual(date2.ToString("g"), date2Str.TryParseDate(date2).ToUtc().ToString("g"));
            Assert.AreEqual(date3.ToString("g"), date3Str.TryParseDate(date3).ToUtc().ToString("g"));
            Assert.AreEqual(date4.ToUtc().ToString("g"), date4Str.TryParseDate(date4).ToUtc().ToString("g"));
            Assert.AreEqual(date1.ToString("g"), "".TryParseDate(date1).ToUtc().ToString("g"));
            Assert.AreEqual(date2.ToString("g"), "".TryParseDate(date2).ToUtc().ToString("g"));
            Assert.AreEqual(date3.ToString("g"), "".TryParseDate(date3).ToUtc().ToString("g"));

            Assert.AreEqual(date1.ToString("g"), date1Str.TryParseDate(Culture, DateTimeStyles).ToUtc().ToString("g"));
            Assert.AreEqual(date2.ToString("g"), date2Str.TryParseDate(Culture, DateTimeStyles).ToUtc().ToString("g"));
            Assert.AreEqual(date3.ToString("g"), date3Str.TryParseDate(Culture, DateTimeStyles).ToUtc().ToString("g"));
            Assert.AreEqual(date4.ToUtc().ToString("g"), date4Str.TryParseDate(Culture, DateTimeStyles).ToUtc().ToString("g"));
            Assert.AreEqual(date1.ToString("g"), "".TryParseDate(Culture, DateTimeStyles).ToUtc().ToString("g"));

            Assert.AreEqual(date1.ToString("g"), date1Str.TryParseDate(date1, Culture, DateTimeStyles).ToUtc().ToString("g"));
            Assert.AreEqual(date2.ToString("g"), date2Str.TryParseDate(date2, Culture, DateTimeStyles).ToUtc().ToString("g"));
            Assert.AreEqual(date3.ToString("g"), date3Str.TryParseDate(date3, Culture, DateTimeStyles).ToUtc().ToString("g"));
            Assert.AreEqual(date4.ToUtc().ToString("g"), date4Str.TryParseDate(date4, Culture, DateTimeStyles).ToUtc().ToString("g"));
            Assert.AreEqual(date1.ToString("g"), "".TryParseDate(date1, Culture, DateTimeStyles).ToUtc().ToString("g"));
            Assert.AreEqual(date2.ToString("g"), "".TryParseDate(date2, Culture, DateTimeStyles).ToUtc().ToString("g"));
            Assert.AreEqual(date3.ToString("g"), "".TryParseDate(date3, Culture, DateTimeStyles).ToUtc().ToString("g"));
            Assert.AreEqual(date4.ToUtc().ToString("g"), "".TryParseDate(date4, Culture, DateTimeStyles).ToUtc().ToString("g"));
            #endregion

            #region OADate
            Assert.AreEqual(date1.ToString("g"), date1.ToOADate().ToString(Culture).TryParseDate().ToString("g"));
            Assert.AreEqual(date2.ToString("g"), date2.ToOADate().ToString(Culture).TryParseDate().ToString("g"));
            Assert.AreEqual(date3.ToString("g"), date3.ToOADate().ToString(Culture).TryParseDate().ToString("g"));

            Assert.AreEqual(date1.ToString("g"), date1.ToOADate().ToString(Culture).TryParseDate(date1).ToString("g"));
            Assert.AreEqual(date2.ToString("g"), date2.ToOADate().ToString(Culture).TryParseDate(date2).ToString("g"));
            Assert.AreEqual(date3.ToString("g"), date3.ToOADate().ToString(Culture).TryParseDate(date3).ToString("g"));

            Assert.AreEqual(date1.ToString("g"), date1.ToOADate().ToString(Culture).TryParseDate(Culture, DateTimeStyles).ToString("g"));
            Assert.AreEqual(date2.ToString("g"), date2.ToOADate().ToString(Culture).TryParseDate(Culture, DateTimeStyles).ToString("g"));
            Assert.AreEqual(date3.ToString("g"), date3.ToOADate().ToString(Culture).TryParseDate(Culture, DateTimeStyles).ToString("g"));

            Assert.AreEqual(date1.ToString("g"), date1.ToOADate().ToString(Culture).TryParseDate(date1, Culture, DateTimeStyles).ToString("g"));
            Assert.AreEqual(date2.ToString("g"), date2.ToOADate().ToString(Culture).TryParseDate(date2, Culture, DateTimeStyles).ToString("g"));
            Assert.AreEqual(date3.ToString("g"), date3.ToOADate().ToString(Culture).TryParseDate(date3, Culture, DateTimeStyles).ToString("g"));
            #endregion
        }

        /// <summary>
        /// Test method TryParseDate with nullable date
        /// </summary>
        [TestMethod]
        public void TryParseDate_nullableDate()
        {
            var date1 = UtcDate;
            var date2 = UtcDate.AddDays(DateInterval);
            var date3 = UtcDate.AddMonths(DateInterval);

            DateTime? date1Nullable = UtcDate;
            DateTime? date2Nullable = UtcDate.AddDays(DateInterval);
            DateTime? date3Nullable = UtcDate.AddMonths(DateInterval);

            Assert.AreEqual(date1.ToString("g"), date1Nullable.TryParseDate().ToUtc().ToString("g"));
            Assert.AreEqual(date2.ToString("g"), date2Nullable.TryParseDate().ToUtc().ToString("g"));
            Assert.AreEqual(date3.ToString("g"), date3Nullable.TryParseDate().ToUtc().ToString("g"));
            Assert.AreEqual(date1.ToString("g"), ((DateTime?)null).TryParseDate().ToUtc().ToString("g"));

            Assert.AreEqual(date1.ToString("g"), date1Nullable.TryParseDate(date1).ToUtc().ToString("g"));
            Assert.AreEqual(date2.ToString("g"), date2Nullable.TryParseDate(date2).ToUtc().ToString("g"));
            Assert.AreEqual(date3.ToString("g"), date3Nullable.TryParseDate(date3).ToUtc().ToString("g"));
            Assert.AreEqual(date1.ToString("g"), ((DateTime?)null).TryParseDate(date1).ToUtc().ToString("g"));
            Assert.AreEqual(date2.ToString("g"), ((DateTime?)null).TryParseDate(date2).ToUtc().ToString("g"));
            Assert.AreEqual(date3.ToString("g"), ((DateTime?)null).TryParseDate(date3).ToUtc().ToString("g"));
        }
        #endregion

        #region ToUtc
        /// <summary>
        /// Test method ToUtc and overloads
        /// </summary>
        [TestMethod]
        public void ToUtcAndOverloads()
        {
            Assert.AreEqual(UtcDate.ToString("g"), LocalDate.ToUtc().ToString("g"));
            Assert.AreEqual(UtcDate.ToString("g"), LocalDate.ToUtc(UtcTimeZoneInfo).ToString("g"));
            Assert.AreEqual(UtcDate.ToString("g"), LocalDate.ToUtc(UtcTimeZoneName).ToString("g"));
        } 
        #endregion

        #region ToUnixTimestamp
        /// <summary>
        /// Test method ToUnixTimestamp and overloads
        /// </summary>
        [TestMethod]
        public void ToUnixTimestampAndOverloads()
        {
            var unix1 = (UtcDate - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds.TryParseLong();
            var unix2 = (LocalDate.ToUtc(LocalTimeZoneInfo) - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds.TryParseLong();

            Assert.AreEqual(unix1, UtcDate.ToUnixTimestamp());
            Assert.AreEqual(unix1, UtcDate.ToUnixTimestamp(UtcTimeZoneInfo));
            Assert.AreEqual(unix1, UtcDate.ToUnixTimestamp(UtcTimeZoneName));

            Assert.AreEqual(unix2, LocalDate.ToUnixTimestamp());
            Assert.AreEqual(unix2, LocalDate.ToUnixTimestamp(UtcTimeZoneInfo));
            Assert.AreEqual(unix2, LocalDate.ToUnixTimestamp(UtcTimeZoneName));
        }
        #endregion

        #region FromUnixTimestamp
        /// <summary>
        /// Test method FromUnixTimestamp
        /// </summary>
        [TestMethod]
        public void FromUnixTimestampAndOverloads()
        {
            var unix1 = (UtcDate - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds.TryParseLong();
            var unix2 = (LocalDate.ToUtc(LocalTimeZoneInfo) - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds.TryParseLong();

            Assert.AreEqual(UtcDate.ToString("g"), unix1.FromUnixTimestamp().ToTimezoneDate(LocalTimeZoneInfo, UtcTimeZoneInfo).ToString("g"));
            
            Assert.AreEqual(LocalDate.ToString("g"), unix2.FromUnixTimestamp().ToTimezoneDate(UtcTimeZoneInfo, LocalTimeZoneInfo).ToString("g"));
        }
        #endregion

        #region ToTimezoneDate
        /// <summary>
        /// Test method ToTimezoneDate and overloads
        /// </summary>
        [TestMethod]
        public void ToTimezoneDateAndOverloads()
        {
            Assert.AreEqual(LocalDate.ToString("g"), UtcDate.ToTimezoneDate(LocalTimeZoneName).ToString("g"));
            Assert.AreEqual(LocalDate.ToString("g"), UtcDate.ToTimezoneDate(LocalTimeZoneInfo).ToString("g"));
            Assert.AreEqual(LocalDate.ToString("g"), UtcDate.ToTimezoneDate(UtcTimeZoneName, LocalTimeZoneName).ToString("g"));
            Assert.AreEqual(LocalDate.ToString("g"), UtcDate.ToTimezoneDate(UtcTimeZoneInfo, LocalTimeZoneName).ToString("g"));
            Assert.AreEqual(LocalDate.ToString("g"), UtcDate.ToTimezoneDate(UtcTimeZoneName, LocalTimeZoneInfo).ToString("g"));
            Assert.AreEqual(LocalDate.ToString("g"), UtcDate.ToTimezoneDate(UtcTimeZoneInfo, LocalTimeZoneInfo).ToString("g"));
        } 
        #endregion

        #region GetWeekNumber
        /// <summary>
        /// Test method GetWeekNumber and overloads
        /// </summary>
        [TestMethod]
        public void GetWeekNumberAndOverloads()
        {
            var week1 = DateTime.UtcNow.SetMonth(1).SetDay(1).SetTime(0, 0, 0, 0);
            var systemFirstWeekDay = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultFirstWeekDay();
            var systemWeekRules = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultCalendarRule();
            var startYear = week1.Year;
            var endYear = (week1.Year - 100);

            for (var i = startYear; i > endYear; i--)
            {
                week1 = week1.SetYear(i);
                Console.WriteLine("{0} - {1}", week1, week1.GetWeekNumber());

                var weekNumber = week1.GetWeekNumber();
                if (!weekNumber.Equals(1) && !weekNumber.Equals(52) && !weekNumber.Equals(53))
                    Assert.Fail("Error getting week number.\nWeek number {0}", weekNumber);

                weekNumber = week1.GetWeekNumber(systemFirstWeekDay);
                if (!weekNumber.Equals(1) && !weekNumber.Equals(52) && !weekNumber.Equals(53))
                    Assert.Fail("Error getting week number.\nWeek number {0}", weekNumber);

                weekNumber = week1.GetWeekNumber(systemWeekRules);
                if (!weekNumber.Equals(1) && !weekNumber.Equals(52) && !weekNumber.Equals(53))
                    Assert.Fail("Error getting week number.\nWeek number {0}", weekNumber);

                weekNumber = week1.GetWeekNumber(systemWeekRules, systemFirstWeekDay);
                if (!weekNumber.Equals(1) && !weekNumber.Equals(52) && !weekNumber.Equals(53))
                    Assert.Fail("Error getting week number.\nWeek number {0}", weekNumber);
                
            }
        } 
        #endregion

        #region SetAsUtc
        /// <summary>
        /// Test method SetAsUtc
        /// </summary>
        [TestMethod]
        public void SetAsUtc()
        {
            var localDate = DateTime.UtcNow;
            localDate = new DateTime(localDate.Year, localDate.Month, localDate.Day, localDate.Hour, localDate.Minute, localDate.Second, localDate.Millisecond, DateTimeKind.Local);

            var unspecifiedDate = DateTime.UtcNow;
            unspecifiedDate = new DateTime(unspecifiedDate.Year, unspecifiedDate.Month, unspecifiedDate.Day, unspecifiedDate.Hour, unspecifiedDate.Minute, unspecifiedDate.Second, unspecifiedDate.Millisecond, DateTimeKind.Unspecified);

            var utcDate = localDate.SetAsUtc();
            Assert.AreEqual(utcDate.Kind, DateTimeKind.Utc, "Error setting date local");
            Assert.AreEqual(localDate.ToString("s"), utcDate.ToString("s"), "Error setting date local");

            utcDate = unspecifiedDate.SetAsUtc();
            Assert.AreEqual(utcDate.Kind, DateTimeKind.Utc, "Error setting date local");
            Assert.AreEqual(unspecifiedDate.ToString("s"), utcDate.ToString("s"), "Error setting date local");
        } 
        #endregion
    }
}
