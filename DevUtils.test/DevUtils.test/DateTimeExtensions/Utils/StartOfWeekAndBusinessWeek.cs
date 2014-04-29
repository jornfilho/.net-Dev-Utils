using System;
using DevUtils.DateTimeExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.DateTimeExtensions.Utils
{
    /// <summary>
    /// Start of week and start of business week test class
    /// </summary>
    [TestClass]
    public class StartOfWeekAndBusinessWeek
    {
        /// <summary>
        /// Test method StartOfWeek sending date and first week day
        /// </summary>
        [TestMethod]
        public void StartOfWeek_SendDateAndFirstWeekDay()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 0, 0, 0, 0, baseDate.Kind);
            const DayOfWeek firstWeekDay = DayOfWeek.Thursday;
            var systemFirstWeekDay = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultFirstWeekDay();

            while (true)
            {
                if(expectedDate.DayOfWeek == firstWeekDay)
                    break;

                expectedDate = (int)firstWeekDay > (int)expectedDate.DayOfWeek
                    ? expectedDate.AddDays(1)
                    : expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, baseDate.StartOfWeek(firstWeekDay), "Error getting start of week");

            expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 0, 0, 0, 0, baseDate.Kind);
            while (true)
            {
                if (expectedDate.DayOfWeek == systemFirstWeekDay)
                    break;

                expectedDate = (int)systemFirstWeekDay > (int)expectedDate.DayOfWeek
                    ? expectedDate.AddDays(1)
                    : expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, baseDate.StartOfWeek(systemFirstWeekDay), "Error getting start of week");
        }

        /// <summary>
        /// Test method StartOfWeek sending date and dont send first week day
        /// </summary>
        [TestMethod]
        public void StartOfWeek_SendDate()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 0, 0, 0, 0, baseDate.Kind);
            var firstWeekDay = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultFirstWeekDay();
            var firstWeekBusiness = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultFirstWeekBusinessDay();

            while (true)
            {
                if (expectedDate.DayOfWeek == firstWeekDay)
                    break;

                expectedDate = (int)firstWeekDay > (int)expectedDate.DayOfWeek
                    ? expectedDate.AddDays(1)
                    : expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, baseDate.StartOfWeek(), "Error getting start of week");

            firstWeekDay = DayOfWeek.Thursday;
            DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultFirstDay(firstWeekDay, firstWeekBusiness);
            expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 0, 0, 0, 0, baseDate.Kind);
            while (true)
            {
                if (expectedDate.DayOfWeek == firstWeekDay)
                    break;

                expectedDate = (int)firstWeekDay > (int)expectedDate.DayOfWeek
                    ? expectedDate.AddDays(1)
                    : expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, baseDate.StartOfWeek(), "Error getting start of week");
        }

        /// <summary>
        /// Test method StartOfBusinessWeek sending date and first business week day
        /// </summary>
        [TestMethod]
        public void StartOfBusinessWeek_SendDateAndFirstWeekDay()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 0, 0, 0, 0, baseDate.Kind);
            const DayOfWeek firstBusinessWeekDay = DayOfWeek.Thursday;
            var systemFirstBusinessWeekDay = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultFirstWeekBusinessDay();

            while (true)
            {
                if (expectedDate.DayOfWeek == firstBusinessWeekDay)
                    break;

                expectedDate = (int)firstBusinessWeekDay > (int)expectedDate.DayOfWeek
                    ? expectedDate.AddDays(1)
                    : expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, baseDate.StartOfBusinessWeek(firstBusinessWeekDay), "Error getting start of business week");

            expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 0, 0, 0, 0, baseDate.Kind);
            while (true)
            {
                if (expectedDate.DayOfWeek == systemFirstBusinessWeekDay)
                    break;

                expectedDate = (int)systemFirstBusinessWeekDay > (int)expectedDate.DayOfWeek
                    ? expectedDate.AddDays(1)
                    : expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, baseDate.StartOfBusinessWeek(systemFirstBusinessWeekDay), "Error getting start of business week");
        }

        /// <summary>
        /// Test method StartOfBusinessWeek sending date and dont send first week day
        /// </summary>
        [TestMethod]
        public void StartOfBusinessWeek_SendDate()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 0, 0, 0, 0, baseDate.Kind);
            var firstBusinessWeekDay = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultFirstWeekBusinessDay();
            var firstWeekDay = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultFirstWeekDay();

            while (true)
            {
                if (expectedDate.DayOfWeek == firstBusinessWeekDay)
                    break;

                expectedDate = (int)firstBusinessWeekDay > (int)expectedDate.DayOfWeek
                    ? expectedDate.AddDays(1)
                    : expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, baseDate.StartOfBusinessWeek(), "Error getting start of business week");

            firstBusinessWeekDay = DayOfWeek.Thursday;
            DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultFirstDay(firstWeekDay, firstBusinessWeekDay);
            expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 0, 0, 0, 0, baseDate.Kind);
            while (true)
            {
                if (expectedDate.DayOfWeek == firstBusinessWeekDay)
                    break;

                expectedDate = (int)firstBusinessWeekDay > (int)expectedDate.DayOfWeek
                    ? expectedDate.AddDays(1)
                    : expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, baseDate.StartOfBusinessWeek(), "Error getting start of business week");
        }
    }
}
