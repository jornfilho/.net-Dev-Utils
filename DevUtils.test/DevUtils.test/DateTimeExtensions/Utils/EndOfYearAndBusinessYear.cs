using System;
using System.Linq;
using DevUtils.DateTimeExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.DateTimeExtensions.Utils
{
    /// <summary>
    /// End of year and end of business year test class
    /// </summary>
    [TestClass]
    public class EndOfYearAndBusinessYear
    {
        /// <summary>
        /// Test method EndOfYear and overloads
        /// </summary>
        [TestMethod]
        public void EndOfYear()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, 1, 1, 23, 59, 59, 999, baseDate.Kind).AddYears(1).AddDays(-1);

            Assert.AreEqual(expectedDate, baseDate.EndOfYear(), "Error getting end of year");
            Assert.AreEqual(expectedDate, DevUtils.DateTimeExtensions.Utils.EndOfYear(baseDate.Year), "Error getting end of year");
        }

        /// <summary>
        /// Test method EndOfBusinessYear sending date and business days
        /// </summary>
        [TestMethod]
        public void EndOfBusinessYear_UseDateAndBusinessDays()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, 1, 1, 23, 59, 59, 999, baseDate.Kind).AddYears(1).AddDays(-1);
            var businessDays = new[] { DayOfWeek.Tuesday, DayOfWeek.Wednesday };
            var systemBusinessDays = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultBusinessDays();

            while (true)
            {
                if (businessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, baseDate.EndOfBusinessYear(businessDays), "Error getting end of business year");

            expectedDate = new DateTime(baseDate.Year, 1, 1, 23, 59, 59, 999, baseDate.Kind).AddYears(1).AddDays(-1);
            while (true)
            {
                if (systemBusinessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, baseDate.EndOfBusinessYear(systemBusinessDays), "Error getting end of business year");

        }

        /// <summary>
        /// Test method EndOfBusinessYear sending only date
        /// </summary>
        [TestMethod]
        public void EndOfBusinessYear_UseDateAndDontSendBusiness()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, 1, 1, 23, 59, 59, 999, baseDate.Kind).AddYears(1).AddDays(-1);
            var businessDays = new[] { DayOfWeek.Tuesday, DayOfWeek.Wednesday };
            var systemBusinessDays = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultBusinessDays();

            while (true)
            {
                if (systemBusinessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, baseDate.EndOfBusinessYear(), "Error getting end of business year");

            expectedDate = new DateTime(baseDate.Year, 1, 1, 23, 59, 59, 999, baseDate.Kind).AddYears(1).AddDays(-1);
            DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultBusinessDays(businessDays);
            while (true)
            {
                if (businessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, baseDate.EndOfBusinessYear(), "Error getting end of business year");

        }

        /// <summary>
        /// Test method EndOfBusinessYear sending year and business days
        /// </summary>
        [TestMethod]
        public void EndOfBusinessYear_UseYearAndBusinessDays()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, 1, 1, 23, 59, 59, 999, baseDate.Kind).AddYears(1).AddDays(-1);
            var businessDays = new[] { DayOfWeek.Tuesday, DayOfWeek.Wednesday };
            var systemBusinessDays = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultBusinessDays();

            while (true)
            {
                if (businessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, DevUtils.DateTimeExtensions.Utils.EndOfBusinessYear(baseDate.Year, businessDays), "Error getting end of business year");

            expectedDate = new DateTime(baseDate.Year, 1, 1, 23, 59, 59, 999, baseDate.Kind).AddYears(1).AddDays(-1);
            while (true)
            {
                if (systemBusinessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, DevUtils.DateTimeExtensions.Utils.EndOfBusinessYear(baseDate.Year, systemBusinessDays), "Error getting end of business year");

        }

        /// <summary>
        /// Test method EndOfBusinessYear sending only year
        /// </summary>
        [TestMethod]
        public void StartOfBusinessYear_UseYearAndDontSendBusiness()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, 1, 1, 23, 59, 59, 999, baseDate.Kind).AddYears(1).AddDays(-1);
            var businessDays = new[] { DayOfWeek.Thursday, DayOfWeek.Friday };
            var systemBusinessDays = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultBusinessDays();

            while (true)
            {
                if (systemBusinessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, DevUtils.DateTimeExtensions.Utils.EndOfBusinessYear(baseDate.Year), "Error getting end of business year");
            Console.WriteLine(DevUtils.DateTimeExtensions.Utils.EndOfBusinessYear(baseDate.Year));

            expectedDate = new DateTime(baseDate.Year, 1, 1, 23, 59, 59, 999, baseDate.Kind).AddYears(1).AddDays(-1);
            DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultBusinessDays(businessDays);
            while (true)
            {
                if (businessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(-1);
            }
            Assert.AreEqual(expectedDate, DevUtils.DateTimeExtensions.Utils.EndOfBusinessYear(baseDate.Year), "Error getting end of business year");
            Console.WriteLine(DevUtils.DateTimeExtensions.Utils.EndOfBusinessYear(baseDate.Year));

        }
    }
}
