using System;
using DevUtils.DateTimeExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.DateTimeExtensions.Utils
{
    /// <summary>
    /// SetDate test class
    /// </summary>
    [TestClass]
    public class SetDate
    {
        /// <summary>
        /// Test method SetDay
        /// </summary>
        [TestMethod]
        public void SetDay()
        {
            var baseDate = DateTime.UtcNow;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, 1, baseDate.Hour, baseDate.Minute, baseDate.Second, baseDate.Millisecond, baseDate.Kind);

            Assert.AreEqual(baseDate.SetDay(1), expectedDate, "Error setting day");
        }

        /// <summary>
        /// Test method SetMonth
        /// </summary>
        [TestMethod]
        public void SetMonth()
        {
            var baseDate = DateTime.UtcNow;
            var expectedDate = new DateTime(baseDate.Year, 1, baseDate.Day, baseDate.Hour, baseDate.Minute, baseDate.Second, baseDate.Millisecond, baseDate.Kind);

            Assert.AreEqual(baseDate.SetMonth(1), expectedDate, "Error setting month");
        }

        /// <summary>
        /// Test method SetYear
        /// </summary>
        [TestMethod]
        public void SetYear()
        {
            var baseDate = DateTime.UtcNow;
            var expectedDate = new DateTime(2015, baseDate.Month, baseDate.Day, baseDate.Hour, baseDate.Minute, baseDate.Second, baseDate.Millisecond, baseDate.Kind);

            Assert.AreEqual(baseDate.SetYear(2015), expectedDate, "Error setting year");
        }

        /// <summary>
        /// Test method SetDate with all params
        /// </summary>
        [TestMethod]
        public void SetAllDate()
        {
            var baseDate = DateTime.UtcNow;
            var expectedDate = new DateTime(2014, 10, 10, baseDate.Hour, baseDate.Minute, baseDate.Second, baseDate.Millisecond, baseDate.Kind);

            Assert.AreEqual(baseDate.SetDate(2014, 10, 10), expectedDate, "Error setting date");
            Assert.AreEqual(baseDate.SetDate(2014, 15, 40), baseDate.EndOfYear().SetTime(baseDate.Hour, baseDate.Minute, baseDate.Second, baseDate.Millisecond), "Error setting date");
        }
    }
}
