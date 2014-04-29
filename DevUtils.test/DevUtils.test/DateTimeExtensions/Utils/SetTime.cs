using System;
using DevUtils.DateTimeExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.DateTimeExtensions.Utils
{
    /// <summary>
    /// SetTime test class
    /// </summary>
    [TestClass]
    public class SetTime
    {
        /// <summary>
        /// Test method SetHour
        /// </summary>
        [TestMethod]
        public void SetHour()
        {
            var baseDate = DateTime.UtcNow;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 1, baseDate.Minute, baseDate.Second, baseDate.Millisecond, baseDate.Kind);

            Assert.AreEqual(baseDate.SetHour(1), expectedDate, "Error setting time");
        }

        /// <summary>
        /// Test method SetMinute
        /// </summary>
        [TestMethod]
        public void SetMinute()
        {
            var baseDate = DateTime.UtcNow;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, baseDate.Hour, 1, baseDate.Second, baseDate.Millisecond, baseDate.Kind);

            Assert.AreEqual(baseDate.SetMinute(1), expectedDate, "Error setting time");
        }

        /// <summary>
        /// Test method SetSecond
        /// </summary>
        [TestMethod]
        public void SetSecond()
        {
            var baseDate = DateTime.UtcNow;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, baseDate.Hour, baseDate.Minute, 1, baseDate.Millisecond, baseDate.Kind);

            Assert.AreEqual(baseDate.SetSecond(1), expectedDate, "Error setting time");
        }

        /// <summary>
        /// Test method SetMillisecond
        /// </summary>
        [TestMethod]
        public void SetMillisecond()
        {
            var baseDate = DateTime.UtcNow;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, baseDate.Hour, baseDate.Minute, baseDate.Second, 1, baseDate.Kind);

            Assert.AreEqual(baseDate.SetMillisecond(1), expectedDate, "Error setting time");
        }

        /// <summary>
        /// Test method SetTime with hour and minute only
        /// </summary>
        [TestMethod]
        public void SetHourAndMinute()
        {
            var baseDate = DateTime.UtcNow;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 1, 1, baseDate.Second, baseDate.Millisecond, baseDate.Kind);

            Assert.AreEqual(baseDate.SetTime(1, 1), expectedDate, "Error setting time");
        }

        /// <summary>
        /// Test method SetTime with hour, minute and second only
        /// </summary>
        [TestMethod]
        public void SetHourMinuteAndSecond()
        {
            var baseDate = DateTime.UtcNow;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 1, 1, 1, baseDate.Millisecond, baseDate.Kind);

            Assert.AreEqual(baseDate.SetTime(1, 1, 1), expectedDate, "Error setting time");
        }

        /// <summary>
        /// Test method SetTime with all params
        /// </summary>
        [TestMethod]
        public void SetAllTime()
        {
            var baseDate = DateTime.UtcNow;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 1, 1, 1, 1, baseDate.Kind);

            Assert.AreEqual(baseDate.SetTime(1,1,1,1), expectedDate, "Error setting time");
        }
    }
}
