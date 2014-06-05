using System;
using System.Globalization;
using DevUtils.DateTimeExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.DateTimeExtensions.Utils
{
    [TestClass]
    public class FromFromToUtc
    {
        [TestMethod]
        public void TestMethod1()
        {
            var strDate = "05/06/2014";
            var timezoneName = "America/Sao_Paulo";
            var timezoneNameDest = "America/Sao_Paulo";
            
            DateTime correctDate;
            if (DateTime.TryParse(strDate, CultureInfo.CurrentCulture, DateTimeStyles.None, out correctDate))
            {
                correctDate = new DateTime(correctDate.Year, correctDate.Month, correctDate.Day, correctDate.Hour, correctDate.Minute, correctDate.Second, correctDate.Millisecond, DateTimeKind.Utc);
                var offset = correctDate.GetDateTimeOffsetMinutes(timezoneName);
                correctDate = correctDate.AddMinutes(offset*-1);

                var accountTime = correctDate.ToTimezoneDate(timezoneNameDest);
                var facebookUnixTime = correctDate.ToUnixTimestamp();
                var facebookIsoTime = correctDate.ToString("O");

                var t = correctDate;
            }

        }
    }
}
