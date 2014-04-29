using System;
using DevUtils.DateTimeExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.DateTimeExtensions.Utils
{
    /// <summary>
    /// End of week and end of business week test class
    /// </summary>
    [TestClass]
    public class EndOfWeekAndBusinessWeek
    {
        /// <summary>
        /// Test method EndOfWeek sending date and last week day
        /// </summary>
        [TestMethod]
        public void EndOfWeek_SendDateAndLastWeekDay()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 23, 59, 59, 999, baseDate.Kind);
            const DayOfWeek lastWeekDay = DayOfWeek.Thursday;
            var systemLastWeekDay = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultLastWeekDay();

            while (true)
            {
                if(expectedDate.DayOfWeek == lastWeekDay)
                    break;

                expectedDate = (int)lastWeekDay > (int)expectedDate.DayOfWeek
                    ? expectedDate.AddDays(1)
                    : expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, baseDate.EndOfWeek(lastWeekDay), "Error getting end of week");

            expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 23, 59, 59, 999, baseDate.Kind);
            while (true)
            {
                if (expectedDate.DayOfWeek == systemLastWeekDay)
                    break;

                expectedDate = (int)systemLastWeekDay > (int)expectedDate.DayOfWeek
                    ? expectedDate.AddDays(1)
                    : expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, baseDate.EndOfWeek(systemLastWeekDay), "Error getting end of week");
        }

        /// <summary>
        /// Test method EndOfWeek sending date and dont send last week day
        /// </summary>
        [TestMethod]
        public void EndOfWeek_SendDate()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 23, 59, 59, 999, baseDate.Kind);
            var lastWeekDay = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultLastWeekDay();
            var lastWeekBusiness = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultLastWeekBusinessDay();

            while (true)
            {
                if (expectedDate.DayOfWeek == lastWeekDay)
                    break;

                expectedDate = (int)lastWeekDay > (int)expectedDate.DayOfWeek
                    ? expectedDate.AddDays(1)
                    : expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, baseDate.EndOfWeek(), "Error getting end of week");

            lastWeekDay = DayOfWeek.Thursday;
            DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultLastDay(lastWeekDay, lastWeekBusiness);
            expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 23, 59, 59, 999, baseDate.Kind);
            while (true)
            {
                if (expectedDate.DayOfWeek == lastWeekDay)
                    break;

                expectedDate = (int)lastWeekDay > (int)expectedDate.DayOfWeek
                    ? expectedDate.AddDays(1)
                    : expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, baseDate.EndOfWeek(), "Error getting end of week");
        }

        /// <summary>
        /// Test method EndOfBusinessWeek sending date and last business week day
        /// </summary>
        [TestMethod]
        public void EndOfBusinessWeek_SendDateAndLastWeekDay()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 23, 59, 59, 999, baseDate.Kind);
            const DayOfWeek lastBusinessWeekDay = DayOfWeek.Thursday;
            var systemLastBusinessWeekDay = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultLastWeekBusinessDay();

            while (true)
            {
                if (expectedDate.DayOfWeek == lastBusinessWeekDay)
                    break;

                expectedDate = (int)lastBusinessWeekDay > (int)expectedDate.DayOfWeek
                    ? expectedDate.AddDays(1)
                    : expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, baseDate.EndOfBusinessWeek(lastBusinessWeekDay), "Error getting end of business week");

            expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 23, 59, 59, 999, baseDate.Kind);
            while (true)
            {
                if (expectedDate.DayOfWeek == systemLastBusinessWeekDay)
                    break;

                expectedDate = (int)systemLastBusinessWeekDay > (int)expectedDate.DayOfWeek
                    ? expectedDate.AddDays(1)
                    : expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, baseDate.EndOfBusinessWeek(systemLastBusinessWeekDay), "Error getting end of business week");
        }

        /// <summary>
        /// Test method EndOfBusinessWeek sending date and dont send last week day
        /// </summary>
        [TestMethod]
        public void EndOfBusinessWeek_SendDate()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 23, 59, 59, 999, baseDate.Kind);
            var lastBusinessWeekDay = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultLastWeekBusinessDay();
            var lastWeekDay = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultLastWeekDay();

            while (true)
            {
                if (expectedDate.DayOfWeek == lastBusinessWeekDay)
                    break;

                expectedDate = (int)lastBusinessWeekDay > (int)expectedDate.DayOfWeek
                    ? expectedDate.AddDays(1)
                    : expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, baseDate.EndOfBusinessWeek(), "Error getting end of business week");

            lastBusinessWeekDay = DayOfWeek.Thursday;
            DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultLastDay(lastWeekDay, lastBusinessWeekDay);
            expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 23, 59, 59, 999, baseDate.Kind);
            while (true)
            {
                if (expectedDate.DayOfWeek == lastBusinessWeekDay)
                    break;

                expectedDate = (int)lastBusinessWeekDay > (int)expectedDate.DayOfWeek
                    ? expectedDate.AddDays(1)
                    : expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, baseDate.EndOfBusinessWeek(), "Error getting end of business week");
        }
    }
}
