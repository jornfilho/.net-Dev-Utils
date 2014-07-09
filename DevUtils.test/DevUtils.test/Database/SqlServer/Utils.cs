using DevUtils.Database.SqlServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.Database.SqlServer
{
    /// <summary>
    /// Test class for Utils methods
    /// </summary>
    [TestClass]
    public class Utils
    {
        /// <summary>
        /// Test method for 
        /// </summary>
        [TestMethod]
        public void EscapeString()
        {
            const string str1 = "abcdçãé";
            const string str1Escaped = "abcd[ç][ã][é]";

            Assert.AreEqual(str1.EscapeString(), str1Escaped, "Error escaping sql server string");
        }
    }
}
