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

            var date1Str = date1.ToString("G");
            var date2Str = date2.ToString("G");
            var date3Str = date3.ToString("G");

            #region string date
            Assert.AreEqual(date1.ToString("G"), date1Str.TryParseDate().ToUtc().ToString("G"));
            Assert.AreEqual(date2.ToString("G"), date2Str.TryParseDate().ToUtc().ToString("G"));
            Assert.AreEqual(date3.ToString("G"), date3Str.TryParseDate().ToUtc().ToString("G"));
            Assert.AreEqual(date1.ToString("G"), "".TryParseDate().ToUtc().ToString("G"));

            Assert.AreEqual(date1.ToString("G"), date1Str.TryParseDate(date1).ToUtc().ToString("G"));
            Assert.AreEqual(date2.ToString("G"), date2Str.TryParseDate(date2).ToUtc().ToString("G"));
            Assert.AreEqual(date3.ToString("G"), date3Str.TryParseDate(date3).ToUtc().ToString("G"));
            Assert.AreEqual(date1.ToString("G"), "".TryParseDate(date1).ToUtc().ToString("G"));
            Assert.AreEqual(date2.ToString("G"), "".TryParseDate(date2).ToUtc().ToString("G"));
            Assert.AreEqual(date3.ToString("G"), "".TryParseDate(date3).ToUtc().ToString("G"));

            Assert.AreEqual(date1.ToString("G"), date1Str.TryParseDate(Culture, DateTimeStyles).ToUtc().ToString("G"));
            Assert.AreEqual(date2.ToString("G"), date2Str.TryParseDate(Culture, DateTimeStyles).ToUtc().ToString("G"));
            Assert.AreEqual(date3.ToString("G"), date3Str.TryParseDate(Culture, DateTimeStyles).ToUtc().ToString("G"));
            Assert.AreEqual(date1.ToString("G"), "".TryParseDate(Culture, DateTimeStyles).ToUtc().ToString("G"));

            Assert.AreEqual(date1.ToString("G"), date1Str.TryParseDate(date1, Culture, DateTimeStyles).ToUtc().ToString("G"));
            Assert.AreEqual(date2.ToString("G"), date2Str.TryParseDate(date2, Culture, DateTimeStyles).ToUtc().ToString("G"));
            Assert.AreEqual(date3.ToString("G"), date3Str.TryParseDate(date3, Culture, DateTimeStyles).ToUtc().ToString("G"));
            Assert.AreEqual(date1.ToString("G"), "".TryParseDate(date1, Culture, DateTimeStyles).ToUtc().ToString("G"));
            Assert.AreEqual(date2.ToString("G"), "".TryParseDate(date2, Culture, DateTimeStyles).ToUtc().ToString("G"));
            Assert.AreEqual(date3.ToString("G"), "".TryParseDate(date3, Culture, DateTimeStyles).ToUtc().ToString("G"));
            #endregion

            #region OADate
            Assert.AreEqual(date1.ToString("G"), date1.ToOADate().ToString(Culture).TryParseDate().ToString("G"));
            Assert.AreEqual(date2.ToString("G"), date2.ToOADate().ToString(Culture).TryParseDate().ToString("G"));
            Assert.AreEqual(date3.ToString("G"), date3.ToOADate().ToString(Culture).TryParseDate().ToString("G"));

            Assert.AreEqual(date1.ToString("G"), date1.ToOADate().ToString(Culture).TryParseDate(date1).ToString("G"));
            Assert.AreEqual(date2.ToString("G"), date2.ToOADate().ToString(Culture).TryParseDate(date2).ToString("G"));
            Assert.AreEqual(date3.ToString("G"), date3.ToOADate().ToString(Culture).TryParseDate(date3).ToString("G"));

            Assert.AreEqual(date1.ToString("G"), date1.ToOADate().ToString(Culture).TryParseDate(Culture, DateTimeStyles).ToString("G"));
            Assert.AreEqual(date2.ToString("G"), date2.ToOADate().ToString(Culture).TryParseDate(Culture, DateTimeStyles).ToString("G"));
            Assert.AreEqual(date3.ToString("G"), date3.ToOADate().ToString(Culture).TryParseDate(Culture, DateTimeStyles).ToString("G"));

            Assert.AreEqual(date1.ToString("G"), date1.ToOADate().ToString(Culture).TryParseDate(date1, Culture, DateTimeStyles).ToString("G"));
            Assert.AreEqual(date2.ToString("G"), date2.ToOADate().ToString(Culture).TryParseDate(date2, Culture, DateTimeStyles).ToString("G"));
            Assert.AreEqual(date3.ToString("G"), date3.ToOADate().ToString(Culture).TryParseDate(date3, Culture, DateTimeStyles).ToString("G"));
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

            Assert.AreEqual(date1.ToString("G"), date1Nullable.TryParseDate().ToUtc().ToString("G"));
            Assert.AreEqual(date2.ToString("G"), date2Nullable.TryParseDate().ToUtc().ToString("G"));
            Assert.AreEqual(date3.ToString("G"), date3Nullable.TryParseDate().ToUtc().ToString("G"));
            Assert.AreEqual(date1.ToString("G"), ((DateTime?)null).TryParseDate().ToUtc().ToString("G"));

            Assert.AreEqual(date1.ToString("G"), date1Nullable.TryParseDate(date1).ToUtc().ToString("G"));
            Assert.AreEqual(date2.ToString("G"), date2Nullable.TryParseDate(date2).ToUtc().ToString("G"));
            Assert.AreEqual(date3.ToString("G"), date3Nullable.TryParseDate(date3).ToUtc().ToString("G"));
            Assert.AreEqual(date1.ToString("G"), ((DateTime?)null).TryParseDate(date1).ToUtc().ToString("G"));
            Assert.AreEqual(date2.ToString("G"), ((DateTime?)null).TryParseDate(date2).ToUtc().ToString("G"));
            Assert.AreEqual(date3.ToString("G"), ((DateTime?)null).TryParseDate(date3).ToUtc().ToString("G"));
        }
        #endregion

        #region ToUtc
        /// <summary>
        /// Test method ToUtc and overloads
        /// </summary>
        [TestMethod]
        public void ToUtcAndOverloads()
        {
            Assert.AreEqual(UtcDate.ToString("G"), LocalDate.ToUtc().ToString("G"));
            Assert.AreEqual(UtcDate.ToString("G"), LocalDate.ToUtc(UtcTimeZoneInfo).ToString("G"));
            Assert.AreEqual(UtcDate.ToString("G"), LocalDate.ToUtc(UtcTimeZoneName).ToString("G"));
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

        #region ToTimezoneDate
        /// <summary>
        /// Test method ToTimezoneDate and overloads
        /// </summary>
        [TestMethod]
        public void ToTimezoneDateAndOverloads()
        {
            Assert.AreEqual(LocalDate.ToString("G"), UtcDate.ToTimezoneDate(LocalTimeZoneName).ToString("G"));
            Assert.AreEqual(LocalDate.ToString("G"), UtcDate.ToTimezoneDate(LocalTimeZoneInfo).ToString("G"));
            Assert.AreEqual(LocalDate.ToString("G"), UtcDate.ToTimezoneDate(UtcTimeZoneName, LocalTimeZoneName).ToString("G"));
            Assert.AreEqual(LocalDate.ToString("G"), UtcDate.ToTimezoneDate(UtcTimeZoneInfo, LocalTimeZoneName).ToString("G"));
            Assert.AreEqual(LocalDate.ToString("G"), UtcDate.ToTimezoneDate(UtcTimeZoneName, LocalTimeZoneInfo).ToString("G"));
            Assert.AreEqual(LocalDate.ToString("G"), UtcDate.ToTimezoneDate(UtcTimeZoneInfo, LocalTimeZoneInfo).ToString("G"));
        } 
        #endregion

        
    }
}
