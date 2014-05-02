using System;
using System.Globalization;
using System.Linq;
using DevUtils.DateTimeExtensions;
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
            DateInterval = 10;
            UtcDate = DateTime.UtcNow;
            LocalDate = DateTime.Now;

            UtcTimeZoneInfo = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfo("UTC");
            LocalTimeZoneInfo = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfo(TimeZone.CurrentTimeZone.StandardName);

            UtcTimeZoneName = "UTC";
            LocalTimeZoneName = TimeZone.CurrentTimeZone.StandardName;
        } 
        #endregion

        /// <summary>
        /// Test method GetDateTimeOffsetMinutes with date and timezone info
        /// </summary>
        [TestMethod]
        public void TryParseDate_string()
        {
            var date1 = UtcDate.SetMillisecond(0);
            var date2 = date1.AddDays(DateInterval);
            var date3 = date1.AddMonths(DateInterval);

            var date1Str = date1.ToString("O");
            var date2Str = date2.ToString(CultureInfo.InvariantCulture);
            var date3Str = date3.ToString(CultureInfo.InvariantCulture);

            var t = date1.GetDateTimeOffsetMinutes("E. South America Standard Time");
            //.AddMinutes(t * -1)
            //Assert.AreEqual(date1.ToString("O"), date1Str.TryParseDate().ToString("O"));

            
        }

        /// <summary>
        /// Test method ToUtc and overloads
        /// </summary>
        [TestMethod]
        public void ToUtcAndOverloads()
        {
            try
            {
                DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultTimezoneInfo(LocalTimeZoneInfo);
                Assert.AreEqual(UtcDate.ToString("G"), LocalDate.ToUtc().ToString("G"));
                DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultTimezoneInfo(UtcTimeZoneInfo);

                Assert.AreEqual(UtcDate.ToString("G"), LocalDate.ToUtc(UtcTimeZoneInfo).ToString("G"));
                Assert.AreEqual(UtcDate.ToString("G"), LocalDate.ToUtc(UtcTimeZoneName).ToString("G"));
            }
            finally
            {
                if(UtcTimeZoneInfo != null)
                    DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultTimezoneInfo(UtcTimeZoneInfo);
            }


        }

        
    }
}
