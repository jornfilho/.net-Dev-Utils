using System;
using System.Linq;
using DevUtils.DateTimeExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.DateTimeExtensions
{
    /// <summary>
    /// Offset test class
    /// </summary>
    [TestClass]
    public class Offset
    {
        /// <summary>
        /// Test method GetDateTimeOffsetMinutes with date and timezone info
        /// </summary>
        [TestMethod]
        public void GetDateTimeOffsetMinutes_DateAndTimezoneInfo()
        {
            var currentDate = DateTime.Now;

            var date1 = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, currentDate.Second, currentDate.Millisecond, DateTimeKind.Local);
            var date2 = date1.AddMonths(4);
            var date3 = date2.AddMonths(4);

            var timezones = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfoDictionary();
            foreach (var tz in timezones.ToList())
            {
                var timezone = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfo(tz.Key) ??
                               DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfo(tz.Value);

                Assert.IsNotNull(timezone, "Error getting timezoneinfo");
                
                Console.WriteLine("{0} - {1} - {2}", date1.GetDateTimeOffsetMinutes(timezone), date1.ToString("s"), tz.Key);
                Console.WriteLine("{0} - {1} - {2}", date2.GetDateTimeOffsetMinutes(timezone), date2.ToString("s"), tz.Key);
                Console.WriteLine("{0} - {1} - {2}", date3.GetDateTimeOffsetMinutes(timezone), date3.ToString("s"), tz.Key);
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Test method GetDateTimeOffsetMinutes with date and timexone name
        /// </summary>
        [TestMethod]
        public void GetDateTimeOffsetMinutes_DateAndTimezoneName()
        {
            var currentDate = DateTime.Now;

            var date1 = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, currentDate.Second, currentDate.Millisecond, DateTimeKind.Local);
            var date2 = date1.AddMonths(4);
            var date3 = date2.AddMonths(4);

            var timezones = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfoDictionary();
            foreach (var tz in timezones.ToList())
            {
                var timezone = DevUtils.DateTimeExtensions.BaseDateTimeExtensions.GetTimezoneInfo(tz.Key);
                Assert.IsNotNull(timezone, "Error getting timezoneinfo");

                Console.WriteLine("{0} - {1} - {2}", date1.GetDateTimeOffsetMinutes(timezone.Id), date1.ToString("s"), timezone.Id);
                Console.WriteLine("{0} - {1} - {2}", date2.GetDateTimeOffsetMinutes(timezone.Id), date2.ToString("s"), timezone.Id);
                Console.WriteLine("{0} - {1} - {2}", date3.GetDateTimeOffsetMinutes(timezone.Id), date3.ToString("s"), timezone.Id);
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Test method GetDateTimeOffsetMinutes with date only
        /// </summary>
        [TestMethod]
        public void GetDateTimeOffsetMinutes_DateOnly()
        {
            var currentDate = DateTime.Now;

            var date1 = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, currentDate.Second, currentDate.Millisecond, DateTimeKind.Local);
            var date2 = date1.AddMonths(4);
            var date3 = date2.AddMonths(4);

            Console.WriteLine("{0} - {1}", date1.GetDateTimeOffsetMinutes(), date1.ToString("s"));
            Console.WriteLine("{0} - {1}", date2.GetDateTimeOffsetMinutes(), date2.ToString("s"));
            Console.WriteLine("{0} - {1}", date3.GetDateTimeOffsetMinutes(), date3.ToString("s"));
            Console.WriteLine("");
        }
    }
}
