using System;
using System.Linq;
using DevUtils.DateTimeExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.DateTimeExtensions.Utils
{
    /// <summary>
    /// Start of month and start of business month test class
    /// </summary>
    [TestClass]
    public class StartOfMonthAndBusinessMonth
    {
        /// <summary>
        /// Test method StartOfMonth and overloads
        /// </summary>
        [TestMethod]
        public void StartOfMonth()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, 1, 0, 0, 0, 0, baseDate.Kind);

            Assert.AreEqual(expectedDate, baseDate.StartOfMonth(), "Error getting start of month");
            Assert.AreEqual(expectedDate, DevUtils.DateTimeExtensions.Utils.StartOfMonth((Month)baseDate.Month, baseDate.Year), "Error getting start of month");
        }

        /// <summary>
        /// Test method StartOfBusinessMonth sending date and business days
        /// </summary>
        [TestMethod]
        public void StartOfBusinessMonth_UseDateAndBusinessDays()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, 1, 0, 0, 0, 0, baseDate.Kind);
            var businessDays = new[] { DayOfWeek.Tuesday, DayOfWeek.Wednesday};
            var systemBusinessDays = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultBusinessDays();

            while (true)
            {
                if (businessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(1);
            }
            Assert.AreEqual(expectedDate, baseDate.StartOfBusinessMonth(businessDays), "Error getting start of business month");

            expectedDate = new DateTime(baseDate.Year, baseDate.Month, 1, 0, 0, 0, 0, baseDate.Kind);
            while (true)
            {
                if (systemBusinessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(1);
            }
            Assert.AreEqual(expectedDate, baseDate.StartOfBusinessMonth(systemBusinessDays), "Error getting start of business month");
            
        }

        /// <summary>
        /// Test method StartOfBusinessMonth sending only date
        /// </summary>
        [TestMethod]
        public void StartOfBusinessMonth_UseDateAndDontSendBusiness()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, 1, 0, 0, 0, 0, baseDate.Kind);
            var businessDays = new[] { DayOfWeek.Tuesday, DayOfWeek.Wednesday };
            var systemBusinessDays = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultBusinessDays();

            while (true)
            {
                if (systemBusinessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(1);
            }
            Assert.AreEqual(expectedDate, baseDate.StartOfBusinessMonth(), "Error getting start of business month");

            expectedDate = new DateTime(baseDate.Year, baseDate.Month, 1, 0, 0, 0, 0, baseDate.Kind);
            DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultBusinessDays(businessDays);
            while (true)
            {
                if (businessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(1);
            }
            Assert.AreEqual(expectedDate, baseDate.StartOfBusinessMonth(), "Error getting start of business month");

        }

        /// <summary>
        /// Test method StartOfBusinessMonth sending year, month and business days
        /// </summary>
        [TestMethod]
        public void StartOfBusinessMonth_UseYearMonthAndBusinessDays()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, 1, 0, 0, 0, 0, baseDate.Kind);
            var businessDays = new[] { DayOfWeek.Tuesday, DayOfWeek.Wednesday };
            var systemBusinessDays = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultBusinessDays();

            while (true)
            {
                if (businessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(1);
            }
            Assert.AreEqual(expectedDate, DevUtils.DateTimeExtensions.Utils.StartOfBusinessMonth((Month)baseDate.Month, baseDate.Year, businessDays), "Error getting start of business month");

            expectedDate = new DateTime(baseDate.Year, baseDate.Month, 1, 0, 0, 0, 0, baseDate.Kind);
            while (true)
            {
                if (systemBusinessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(1);
            }
            Assert.AreEqual(expectedDate, DevUtils.DateTimeExtensions.Utils.StartOfBusinessMonth((Month)baseDate.Month, baseDate.Year, businessDays), "Error getting start of business month");

        }

        /// <summary>
        /// Test method StartOfBusinessMonth sending only year
        /// </summary>
        [TestMethod]
        public void StartOfBusinessMonth_UseYearMonthAndDontSendBusiness()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, 1, 0, 0, 0, 0, baseDate.Kind);
            var businessDays = new[] { DayOfWeek.Thursday, DayOfWeek.Friday};
            var systemBusinessDays = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultBusinessDays();

            while (true)
            {
                if (systemBusinessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(1);
            }
            Assert.AreEqual(expectedDate, DevUtils.DateTimeExtensions.Utils.StartOfBusinessMonth((Month)baseDate.Month, baseDate.Year), "Error getting start of business month");
            Console.WriteLine(DevUtils.DateTimeExtensions.Utils.StartOfBusinessMonth((Month)baseDate.Month, baseDate.Year));

            expectedDate = new DateTime(baseDate.Year, baseDate.Month, 1, 0, 0, 0, 0, baseDate.Kind);
            DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultBusinessDays(businessDays);
            while (true)
            {
                if (businessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(1);
            }
            Assert.AreEqual(expectedDate, DevUtils.DateTimeExtensions.Utils.StartOfBusinessMonth((Month)baseDate.Month, baseDate.Year), "Error getting start of business month");
            Console.WriteLine(DevUtils.DateTimeExtensions.Utils.StartOfBusinessMonth((Month)baseDate.Month, baseDate.Year));

        }
    }
}
