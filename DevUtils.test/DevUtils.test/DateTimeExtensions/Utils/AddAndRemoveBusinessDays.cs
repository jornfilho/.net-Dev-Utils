using System;
using System.Linq;
using DevUtils.DateTimeExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.DateTimeExtensions.Utils
{
    /// <summary>
    /// Add adn remove business days test class
    /// </summary>
    [TestClass]
    public class AddAndRemoveBusinessDays
    {
        /// <summary>
        /// Test method AddBusinessDays and overloads
        /// </summary>
        [TestMethod]
        public void AddBusinessDaysAndOverloads()
        {
            var businessDays = new[] {DayOfWeek.Monday, DayOfWeek.Tuesday};
            var systemBusinessDays = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultBusinessDays();
            const int daysToAdd = 20;
            var baseDate = DateTime.Now;

            #region sending business days
            var expectedDate = baseDate;
            var expectedCount = 0;
            while (true)
            {
                if (businessDays.Contains(expectedDate.DayOfWeek))
                    expectedCount++;

                expectedDate = expectedDate.AddDays(1);

                if (expectedCount == daysToAdd)
                    break;
            }

            var newDate = baseDate.AddBusinessDays(daysToAdd, businessDays);
            Assert.AreEqual(newDate, expectedDate, "Error on add business days"); 
            #endregion

            #region dont send business days
            expectedDate = baseDate;
            expectedCount = 0;
            while (true)
            {
                if (systemBusinessDays.Contains(expectedDate.DayOfWeek))
                    expectedCount++;

                expectedDate = expectedDate.AddDays(1);

                if (expectedCount == daysToAdd)
                    break;
            }

            newDate = baseDate.AddBusinessDays(daysToAdd);
            Assert.AreEqual(newDate, expectedDate, "Error on add business days"); 
            #endregion


        }

        /// <summary>
        /// Test method RemoveBusinessDays and overloads
        /// </summary>
        [TestMethod]
        public void RemoveBusinessDaysAndOverloads()
        {
            var businessDays = new[] { DayOfWeek.Monday, DayOfWeek.Tuesday };
            var systemBusinessDays = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetDefaultBusinessDays();
            const int daysToRemove = 20;
            var baseDate = DateTime.Now;

            #region sending business days
            var expectedDate = baseDate;
            var expectedCount = 0;
            while (true)
            {
                if (businessDays.Contains(expectedDate.DayOfWeek))
                    expectedCount++;

                expectedDate = expectedDate.AddDays(-1);

                if (expectedCount == daysToRemove)
                    break;
            }

            var newDate = baseDate.RemoveBusinessDays(daysToRemove, businessDays);
            Assert.AreEqual(newDate, expectedDate, "Error on remove business days");
            #endregion

            #region dont send business days
            expectedDate = baseDate;
            expectedCount = 0;
            while (true)
            {
                if (systemBusinessDays.Contains(expectedDate.DayOfWeek))
                    expectedCount++;

                expectedDate = expectedDate.AddDays(-1);

                if (expectedCount == daysToRemove)
                    break;
            }

            newDate = baseDate.RemoveBusinessDays(daysToRemove);
            Assert.AreEqual(newDate, expectedDate, "Error on remove business days");
            #endregion


        }
    }
}
