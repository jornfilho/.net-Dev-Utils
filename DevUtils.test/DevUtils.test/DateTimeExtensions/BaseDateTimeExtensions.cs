using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.DateTimeExtensions
{
    /// <summary>
    /// BaseDateTimeExtensions test class
    /// </summary>
    [TestClass]
    public class BaseDateTimeExtensions
    {
        /// <summary>
        /// Test method GetTimezoneInfoDictionary
        /// </summary>
        [TestMethod]
        public void GetTimezoneInfoDictionary()
        {
            var timezoneDictionary = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfoDictionary();
            Assert.IsNotNull(timezoneDictionary, "Error getting timezoneinfo dictionary");
            Assert.IsTrue(timezoneDictionary.Count > 0, "Error getting timezoneinfo dictionary");
        }
        
        /// <summary>
        /// Test method GetTimezoneInfo
        /// </summary>
        [TestMethod]
        public void GetTimezoneInfo()
        {
            const string success1 = "Africa/Abidjan";
            const string success2 = "Greenwich Standard Time";
            const string success3 = "PST8PDT";
            const string success4 = "Pacific Standard Time";
            const string success5 = "Etc/GMT";
            const string success6 = "UTC";

            const string error1 = "";
            const string error2 = null;
            const string error3 = "test";

            var success = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfo(success1);
            Assert.IsNotNull(success, "Error getting timezone info");

            success = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfo(success2);
            Assert.IsNotNull(success, "Error getting timezone info");

            success = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfo(success3);
            Assert.IsNotNull(success, "Error getting timezone info");

            success = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfo(success4);
            Assert.IsNotNull(success, "Error getting timezone info");

            success = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfo(success5);
            Assert.IsNotNull(success, "Error getting timezone info");

            success = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfo(success6);
            Assert.IsNotNull(success, "Error getting timezone info");

            var error = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfo(error1);
            Assert.IsNull(error, "The timezoneinfo should be null");

            error = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfo(error2);
            Assert.IsNull(error, "The timezoneinfo should be null");

            error = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfo(error3);
            Assert.IsNull(error, "The timezoneinfo should be null");
        }

        /// <summary>
        /// Test methods GetDefaultBusinessDays and SetDefaultBusinessDays
        /// </summary>
        [TestMethod]
        public void GetAndSet_DefaultBusinessDays()
        {
            try
            {
                var businessDays = new[] { DayOfWeek.Tuesday, DayOfWeek.Wednesday };
                var systemBusinessDays = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultBusinessDays();

                Assert.IsNotNull(systemBusinessDays, "Error getting default business days");

                DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultBusinessDays(businessDays);
                systemBusinessDays = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultBusinessDays();

                Assert.IsNotNull(systemBusinessDays, "Error getting default business days");
                Assert.IsTrue(systemBusinessDays.Count() == businessDays.Count(), "Error setting business days");
                foreach (var day in businessDays)
                    Assert.IsTrue(systemBusinessDays.Any(d => d == day), "Error setting business days");


                DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultBusinessDays(null);
                systemBusinessDays = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultBusinessDays();

                Assert.IsNotNull(systemBusinessDays, "Error getting default business days");
                Assert.IsTrue(systemBusinessDays.Count() == businessDays.Count(), "Error setting business days");
                foreach (var day in businessDays)
                    Assert.IsTrue(systemBusinessDays.Any(d => d == day), "Error setting business days");


                DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultBusinessDays(new DayOfWeek[] { });
                systemBusinessDays = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultBusinessDays();

                Assert.IsNotNull(systemBusinessDays, "Error getting default business days");
                Assert.IsTrue(systemBusinessDays.Count() == businessDays.Count(), "Error setting business days");
                foreach (var day in businessDays)
                    Assert.IsTrue(systemBusinessDays.Any(d => d == day), "Error setting business days");
            }
            finally
            {
                DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultBusinessDays(new[]
                {
                    DayOfWeek.Monday,
                    DayOfWeek.Tuesday,
                    DayOfWeek.Wednesday,
                    DayOfWeek.Thursday,
                    DayOfWeek.Friday
                });
            }

        }

        /// <summary>
        /// Test methods GetDefaultFirstWeekDay, GetDefaultFirstWeekBusinessDay and SetDefaultFirstDay
        /// </summary>
        [TestMethod]
        public void GetAndSet_FirstDays()
        {
            const DayOfWeek firstDay = DayOfWeek.Tuesday;
            const DayOfWeek firstBusinessDay = DayOfWeek.Wednesday;
            var systemFirstDay = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultFirstWeekDay();
            var systemFirstBusinessDay = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultFirstWeekBusinessDay();

            Assert.IsNotNull(systemFirstDay, "Error getting default first day");
            Assert.IsNotNull(systemFirstBusinessDay, "Error getting default first business day");

            var firstDayTested = false;
            var firstBusinessDayTested = false;

            if (systemFirstDay != firstDay)
            {
                firstDayTested = true;
                DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultFirstDay(firstDay, systemFirstBusinessDay);
                systemFirstDay = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultFirstWeekDay();
                Assert.AreEqual(firstDay, systemFirstDay, "Error setting system first week day");
            }

            if (systemFirstBusinessDay != firstBusinessDay)
            {
                firstBusinessDayTested = true;
                DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultFirstDay(systemFirstDay, firstBusinessDay);
                systemFirstBusinessDay = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultFirstWeekBusinessDay();
                Assert.AreEqual(firstBusinessDay, systemFirstBusinessDay, "Error setting system first business week day");
            }

            if(!firstBusinessDayTested || !firstDayTested)
                Assert.Inconclusive("Cant test all methods:\nfirstDayTested: {0}\nfirstBusinessDayTested: {1}", firstDayTested, firstBusinessDayTested);

        }

        /// <summary>
        /// Test methods GetDefaultLastWeekDay, GetDefaultLastWeekBusinessDay and SetDefaultLastDay
        /// </summary>
        [TestMethod]
        public void GetAndSet_LastDays()
        {
            const DayOfWeek lastDay = DayOfWeek.Friday;
            const DayOfWeek lastBusinessDay = DayOfWeek.Wednesday;
            var systemLastDay = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultLastWeekDay();
            var systemLastBusinessDay = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultLastWeekBusinessDay();

            Assert.IsNotNull(systemLastDay, "Error getting default last day");
            Assert.IsNotNull(systemLastBusinessDay, "Error getting default last business day");

            var lastDayTested = false;
            var lastBusinessDayTested = false;

            if (systemLastDay != lastDay)
            {
                lastDayTested = true;
                DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultLastDay(lastDay, systemLastBusinessDay);
                systemLastDay = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultLastWeekDay();
                Assert.AreEqual(lastDay, systemLastDay, "Error setting system last week day");
            }

            if (systemLastBusinessDay != lastBusinessDay)
            {
                lastBusinessDayTested = true;
                DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultLastDay(systemLastDay, lastBusinessDay);
                systemLastBusinessDay = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultLastWeekBusinessDay();
                Assert.AreEqual(lastBusinessDay, systemLastBusinessDay, "Error setting system last business week day");
            }

            if (!lastBusinessDayTested || !lastDayTested)
                Assert.Inconclusive("Cant test all methods:\nlastDayTested: {0}\nlastBusinessDayTested: {1}", lastDayTested, lastBusinessDayTested);

        }

        /// <summary>
        /// Test method GetDefaultTimezoneInfo
        /// </summary>
        [TestMethod]
        public void GetDefaultTimezoneInfo()
        {
            var currentTimezone = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfo(TimeZone.CurrentTimeZone.StandardName);
            Assert.IsNotNull(currentTimezone, "Error getting current timezoneinfo");
            Assert.AreEqual(currentTimezone, DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultTimezoneInfo(), "Error getting default timezoneinfo");
        }
        
        /// <summary>
        /// Test method SetDefaultTimezoneInfo with timezone info
        /// </summary>
        [TestMethod]
        public void SetDefaultTimezoneInfoWithTimezoneinfo()
        {
            var utcTimezone = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfo("UTC");
            var localTimezone = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfo(TimeZone.CurrentTimeZone.StandardName);

            try
            {
                Assert.IsNotNull(utcTimezone, "Error getting utc timezoneinfo");
                Assert.IsNotNull(localTimezone, "Error local timezoneinfo");

                var defaultTimezone = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultTimezoneInfo();
                if (defaultTimezone.Equals(utcTimezone))
                {
                    DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultTimezoneInfo(localTimezone);
                    Assert.AreEqual(localTimezone, DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultTimezoneInfo(), "Error setting default timezoneinfo");
                }
                else
                {
                    DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultTimezoneInfo(utcTimezone);
                    Assert.AreEqual(utcTimezone, DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultTimezoneInfo(), "Error setting default timezoneinfo");
                }
            }
            finally
            {
                if(utcTimezone != null)
                    DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultTimezoneInfo(localTimezone);
            }
        }

        /// <summary>
        /// Test method SetDefaultTimezoneInfo with timezone name
        /// </summary>
        [TestMethod]
        public void SetDefaultTimezoneInfoWithTimezonename()
        {
            var utcTimezone = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfo("UTC");
            var localTimezone = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfo(TimeZone.CurrentTimeZone.StandardName);

            try
            {
                Assert.IsNotNull(utcTimezone, "Error getting utc timezoneinfo");
                Assert.IsNotNull(localTimezone, "Error getting local timezoneinfo");

                var defaultTimezone = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultTimezoneInfo();
                if (defaultTimezone.Equals(utcTimezone))
                {
                    DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultTimezoneInfo(TimeZone.CurrentTimeZone.StandardName);
                    Assert.AreEqual(localTimezone, DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultTimezoneInfo(), "Error setting default timezoneinfo");
                }
                else
                {
                    DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultTimezoneInfo("UTC");
                    Assert.AreEqual(utcTimezone, DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultTimezoneInfo(), "Error setting default timezoneinfo");
                }
            }
            finally
            {
                if (utcTimezone != null)
                    DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultTimezoneInfo(localTimezone);
            }
        }
    }
}
