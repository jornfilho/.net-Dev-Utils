using System;
using System.Linq;
using DevUtils.DateTimeExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.DateTimeExtensions.Utils
{
    /// <summary>
    /// Start of year and start of business year test class
    /// </summary>
    [TestClass]
    public class StartOfYearAndBusinessYear
    {
        /// <summary>
        /// Test method StartOfYear and overloads
        /// </summary>
        [TestMethod]
        public void StartOfYear()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, 1, 1, 0, 0, 0, 0, baseDate.Kind);

            Assert.AreEqual(expectedDate, baseDate.StartOfYear(), "Error getting start of year");
            Assert.AreEqual(expectedDate, DevUtils.DateTimeExtensions.Utils.StartOfYear(baseDate.Year), "Error getting start of year");
        }

        /// <summary>
        /// Test method StartOfBusinessYear sending date and business days
        /// </summary>
        [TestMethod]
        public void StartOfBusinessYear_UseDateAndBusinessDays()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, 1, 1, 0, 0, 0, 0, baseDate.Kind);
            var businessDays = new[] { DayOfWeek.Tuesday, DayOfWeek.Wednesday};
            var systemBusinessDays = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultBusinessDays();

            while (true)
            {
                if (businessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(1);
            }
            Assert.AreEqual(expectedDate, baseDate.StartOfBusinessYear(businessDays), "Error getting start of business year");

            expectedDate = new DateTime(baseDate.Year, 1, 1, 0, 0, 0, 0, baseDate.Kind);
            while (true)
            {
                if (systemBusinessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(1);
            }
            Assert.AreEqual(expectedDate, baseDate.StartOfBusinessYear(systemBusinessDays), "Error getting start of business year");
            
        }

        /// <summary>
        /// Test method StartOfBusinessYear sending only date
        /// </summary>
        [TestMethod]
        public void StartOfBusinessYear_UseDateAndDontSendBusiness()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, 1, 1, 0, 0, 0, 0, baseDate.Kind);
            var businessDays = new[] { DayOfWeek.Tuesday, DayOfWeek.Wednesday };
            var systemBusinessDays = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultBusinessDays();

            while (true)
            {
                if (systemBusinessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(1);
            }
            Assert.AreEqual(expectedDate, baseDate.StartOfBusinessYear(), "Error getting start of business year");

            expectedDate = new DateTime(baseDate.Year, 1, 1, 0, 0, 0, 0, baseDate.Kind);
            DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultBusinessDays(businessDays);
            while (true)
            {
                if (businessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(1);
            }
            Assert.AreEqual(expectedDate, baseDate.StartOfBusinessYear(), "Error getting start of business year");

        }

        /// <summary>
        /// Test method StartOfBusinessYear sending year and business days
        /// </summary>
        [TestMethod]
        public void StartOfBusinessYear_UseYearAndBusinessDays()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, 1, 1, 0, 0, 0, 0, baseDate.Kind);
            var businessDays = new[] { DayOfWeek.Tuesday, DayOfWeek.Wednesday };
            var systemBusinessDays = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultBusinessDays();

            while (true)
            {
                if (businessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(1);
            }
            Assert.AreEqual(expectedDate, DevUtils.DateTimeExtensions.Utils.StartOfBusinessYear(baseDate.Year, businessDays), "Error getting start of business year");

            expectedDate = new DateTime(baseDate.Year, 1, 1, 0, 0, 0, 0, baseDate.Kind);
            while (true)
            {
                if (systemBusinessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(1);
            }
            Assert.AreEqual(expectedDate, DevUtils.DateTimeExtensions.Utils.StartOfBusinessYear(baseDate.Year, systemBusinessDays), "Error getting start of business year");

        }

        /// <summary>
        /// Test method StartOfBusinessYear sending only year
        /// </summary>
        [TestMethod]
        public void StartOfBusinessYear_UseYearAndDontSendBusiness()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, 1, 1, 0, 0, 0, 0, baseDate.Kind);
            var businessDays = new[] { DayOfWeek.Thursday, DayOfWeek.Friday};
            var systemBusinessDays = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultBusinessDays();

            while (true)
            {
                if (systemBusinessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(1);
            }
            Assert.AreEqual(expectedDate, DevUtils.DateTimeExtensions.Utils.StartOfBusinessYear(baseDate.Year), "Error getting start of business year");
            Console.WriteLine(DevUtils.DateTimeExtensions.Utils.StartOfBusinessYear(baseDate.Year));

            expectedDate = new DateTime(baseDate.Year, 1, 1, 0, 0, 0, 0, baseDate.Kind);
            DevUtils.DateTimeExtensions.BaseDateTimeExtensions.SetDefaultBusinessDays(businessDays);
            while (true)
            {
                if (businessDays.Contains(expectedDate.DayOfWeek))
                    break;

                expectedDate = expectedDate.AddDays(1);
            }
            Assert.AreEqual(expectedDate, DevUtils.DateTimeExtensions.Utils.StartOfBusinessYear(baseDate.Year), "Error getting start of business year");
            Console.WriteLine(DevUtils.DateTimeExtensions.Utils.StartOfBusinessYear(baseDate.Year));

        }
    }
}
