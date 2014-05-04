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

            UtcTimeZoneInfo = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfo("UTC");
            LocalTimeZoneInfo = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfo(TimeZone.CurrentTimeZone.StandardName);

            UtcTimeZoneName = "UTC";
            LocalTimeZoneName = TimeZone.CurrentTimeZone.StandardName;
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

            var date1Str = date1.ToString("g");
            var date2Str = date2.ToString("g");
            var date3Str = date3.ToString("g");

            #region string date
            Assert.AreEqual(date1.ToString("g"), date1Str.TryParseDate().ToUtc().ToString("g"));
            Assert.AreEqual(date2.ToString("g"), date2Str.TryParseDate().ToUtc().ToString("g"));
            Assert.AreEqual(date3.ToString("g"), date3Str.TryParseDate().ToUtc().ToString("g"));
            Assert.AreEqual(date1.ToString("g"), "".TryParseDate().ToUtc().ToString("g"));

            Assert.AreEqual(date1.ToString("g"), date1Str.TryParseDate(date1).ToUtc().ToString("g"));
            Assert.AreEqual(date2.ToString("g"), date2Str.TryParseDate(date2).ToUtc().ToString("g"));
            Assert.AreEqual(date3.ToString("g"), date3Str.TryParseDate(date3).ToUtc().ToString("g"));
            Assert.AreEqual(date1.ToString("g"), "".TryParseDate(date1).ToUtc().ToString("g"));
            Assert.AreEqual(date2.ToString("g"), "".TryParseDate(date2).ToUtc().ToString("g"));
            Assert.AreEqual(date3.ToString("g"), "".TryParseDate(date3).ToUtc().ToString("g"));

            Assert.AreEqual(date1.ToString("g"), date1Str.TryParseDate(Culture, DateTimeStyles).ToUtc().ToString("g"));
            Assert.AreEqual(date2.ToString("g"), date2Str.TryParseDate(Culture, DateTimeStyles).ToUtc().ToString("g"));
            Assert.AreEqual(date3.ToString("g"), date3Str.TryParseDate(Culture, DateTimeStyles).ToUtc().ToString("g"));
            Assert.AreEqual(date1.ToString("g"), "".TryParseDate(Culture, DateTimeStyles).ToUtc().ToString("g"));

            Assert.AreEqual(date1.ToString("g"), date1Str.TryParseDate(date1, Culture, DateTimeStyles).ToUtc().ToString("g"));
            Assert.AreEqual(date2.ToString("g"), date2Str.TryParseDate(date2, Culture, DateTimeStyles).ToUtc().ToString("g"));
            Assert.AreEqual(date3.ToString("g"), date3Str.TryParseDate(date3, Culture, DateTimeStyles).ToUtc().ToString("g"));
            Assert.AreEqual(date1.ToString("g"), "".TryParseDate(date1, Culture, DateTimeStyles).ToUtc().ToString("g"));
            Assert.AreEqual(date2.ToString("g"), "".TryParseDate(date2, Culture, DateTimeStyles).ToUtc().ToString("g"));
            Assert.AreEqual(date3.ToString("g"), "".TryParseDate(date3, Culture, DateTimeStyles).ToUtc().ToString("g"));
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
        /// Test method FromUnixTimestamp and overloads
        /// </summary>
        [TestMethod]
        public void FromUnixTimestampAndOverloads()
        {
            var unix1 = (UtcDate - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds.TryParseLong();
            var unix2 = (LocalDate.ToUtc(LocalTimeZoneInfo) - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds.TryParseLong();

            Assert.AreEqual(UtcDate.ToString("g"), unix1.FromUnixTimestamp().ToTimezoneDate(LocalTimeZoneInfo, UtcTimeZoneInfo).ToString("g"));
            Assert.AreEqual(UtcDate.ToString("g"), unix1.FromUnixTimestamp(UtcTimeZoneInfo).ToString("g"));
            Assert.AreEqual(UtcDate.ToString("g"), unix1.FromUnixTimestamp(UtcTimeZoneName).ToString("g"));

            Assert.AreEqual(LocalDate.ToString("g"), unix2.FromUnixTimestamp().ToTimezoneDate(UtcTimeZoneInfo, LocalTimeZoneInfo).ToString("g"));
            Assert.AreEqual(LocalDate.ToString("g"), unix2.FromUnixTimestamp(LocalTimeZoneInfo).ToString("g"));
            Assert.AreEqual(LocalDate.ToString("g"), unix2.FromUnixTimestamp(LocalTimeZoneName).ToString("g"));
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
    }
}
