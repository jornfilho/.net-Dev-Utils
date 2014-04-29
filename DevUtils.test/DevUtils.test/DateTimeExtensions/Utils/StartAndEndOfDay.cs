using System;
using DevUtils.DateTimeExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.DateTimeExtensions.Utils
{
    /// <summary>
    /// StartOfDay and EndOfDay test class
    /// </summary>
    [TestClass]
    public class StartAndEndOfDay
    {
        /// <summary>
        /// Test method StartOfDay
        /// </summary>
        [TestMethod]
        public void StartOfDay()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 0, 0, 0, 0, baseDate.Kind);
            Assert.AreEqual(expectedDate, baseDate.StartOfDay(), "Error setting start of day");
        }

        /// <summary>
        /// Test method EndOfDay
        /// </summary>
        [TestMethod]
        public void EndOfDay()
        {
            var baseDate = DateTime.Now;
            var expectedDate = new DateTime(baseDate.Year, baseDate.Month, baseDate.Day, 23, 59, 59, 999, baseDate.Kind);
            Assert.AreEqual(expectedDate, baseDate.EndOfDay(), "Error setting end of day");
        }
    }
}
