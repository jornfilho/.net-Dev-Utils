using System;
using System.Linq;
using DevUtils.DateTimeExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.DateTimeExtensions.Utils
{
    /// <summary>
    /// End of mopnth and end of business month test class
    /// </summary>
    [TestClass]
    public class EndOfMonthAndBusinessMonth
    {
        /// <summary>
        /// Test method EndOfMonth and overloads
        /// </summary>
        [TestMethod]
        public void EndOfMonth()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, 1, 23, 59, 59, 999, baseDate.Kind).AddMonths(1).AddDays(-1);

            Assert.AreEqual(expectedDate, baseDate.EndOfMonth(), "Error getting end of month");
            Assert.AreEqual(expectedDate, DevUtils.DateTimeExtensions.Utils.EndOfMonth((Month)baseDate.Month, baseDate.Year), "Error getting end of month");
        }

        /// <summary>
        /// Test method EndOfBusinessMonth sending date and business days
        /// </summary>
        [TestMethod]
        public void EndOfBusinessMonth_UseDateAndBusinessDays()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, 1, 23, 59, 59, 999, baseDate.Kind).AddMonths(1).AddDays(-1);
            var businessDays = new[] { DayOfWeek.Tuesday, DayOfWeek.Wednesday };
            var systemBusinessDays = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultBusinessDays();

            while (true)
            {
                if (businessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, baseDate.EndOfBusinessMonth(businessDays), "Error getting end of business month");

            expectedDate = new DateTime(baseDate.Year, baseDate.Month, 1, 23, 59, 59, 999, baseDate.Kind).AddMonths(1).AddDays(-1);
            while (true)
            {
                if (systemBusinessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, baseDate.EndOfBusinessMonth(systemBusinessDays), "Error getting end of business month");

        }

        /// <summary>
        /// Test method EndOfBusinessMonth sending only date
        /// </summary>
        [TestMethod]
        public void EndOfBusinessMonth_UseDateAndDontSendBusiness()
        {
            try
            {
                var baseDate = DateTime.Now;
                var expectedDate = new DateTime(baseDate.Year, baseDate.Month, 1, 23, 59, 59, 999, baseDate.Kind).AddMonths(1).AddDays(-1);
                var businessDays = new[] { DayOfWeek.Tuesday, DayOfWeek.Wednesday };
                var systemBusinessDays = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultBusinessDays();

                while (true)
                {
                    if (systemBusinessDays.Contains(expectedDate.DayOfWeek))
                        break;

                    expectedDate = expectedDate.AddDays(-1);
                }
                Assert.AreEqual(expectedDate, baseDate.EndOfBusinessMonth(), "Error getting end of business month");

                expectedDate = new DateTime(baseDate.Year, baseDate.Month, 1, 23, 59, 59, 999, baseDate.Kind).AddMonths(1).AddDays(-1);
                DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultBusinessDays(businessDays);
                while (true)
                {
                    if (businessDays.Contains(expectedDate.DayOfWeek))
                        break;

                    expectedDate = expectedDate.AddDays(-1);
                }
                Assert.AreEqual(expectedDate, baseDate.EndOfBusinessMonth(), "Error getting end of business month");
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
        /// Test method EndOfBusinessMonth sending year, month and business days
        /// </summary>
        [TestMethod]
        public void EndOfBusinessMonth_UseYearAndBusinessDays()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, 1, 23, 59, 59, 999, baseDate.Kind).AddMonths(1).AddDays(-1);
            var businessDays = new[] { DayOfWeek.Tuesday, DayOfWeek.Wednesday };
            var systemBusinessDays = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultBusinessDays();

            while (true)
            {
                if (businessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, DevUtils.DateTimeExtensions.Utils.EndOfBusinessMonth((Month)baseDate.Month, baseDate.Year, businessDays), "Error getting end of business month");

            expectedDate = new DateTime(baseDate.Year, baseDate.Month, 1, 23, 59, 59, 999, baseDate.Kind).AddMonths(1).AddDays(-1);
            while (true)
            {
                if (systemBusinessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, DevUtils.DateTimeExtensions.Utils.EndOfBusinessMonth((Month)baseDate.Month, baseDate.Year, systemBusinessDays), "Error getting end of business month");

        }

        /// <summary>
        /// Test method EndOfBusinessMonth sending only year and month
        /// </summary>
        [TestMethod]
        public void EndOfBusinessMonth_UseYearAndDontSendBusiness()
        {
            try
            {
                var baseDate = DateTime.Now;
                var expectedDate = new DateTime(baseDate.Year, baseDate.Month, 1, 23, 59, 59, 999, baseDate.Kind).AddMonths(1).AddDays(-1);
                var businessDays = new[] { DayOfWeek.Thursday, DayOfWeek.Friday };
                var systemBusinessDays = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultBusinessDays();

                while (true)
                {
                    if (systemBusinessDays.Contains(expectedDate.DayOfWeek))
                        break;

                    expectedDate = expectedDate.AddDays(-1);
                }
                Assert.AreEqual(expectedDate, DevUtils.DateTimeExtensions.Utils.EndOfBusinessMonth((Month)baseDate.Month, baseDate.Year), "Error getting end of business month");
                Console.WriteLine(DevUtils.DateTimeExtensions.Utils.EndOfBusinessMonth((Month)baseDate.Month, baseDate.Year));

                expectedDate = new DateTime(baseDate.Year, baseDate.Month, 1, 23, 59, 59, 999, baseDate.Kind).AddMonths(1).AddDays(-1);
                DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultBusinessDays(businessDays);
                while (true)
                {
                    if (businessDays.Contains(expectedDate.DayOfWeek))
                        break;

                    expectedDate = expectedDate.AddDays(-1);
                }
                Assert.AreEqual(expectedDate, DevUtils.DateTimeExtensions.Utils.EndOfBusinessMonth((Month)baseDate.Month, baseDate.Year), "Error getting end of business month");
                Console.WriteLine(DevUtils.DateTimeExtensions.Utils.EndOfBusinessMonth((Month)baseDate.Month, baseDate.Year));
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
    }
}
