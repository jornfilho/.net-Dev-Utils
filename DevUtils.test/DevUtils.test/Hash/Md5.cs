using DevUtils.Hash;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.Hash
{
    /// <summary>
    /// Md5 test class
    /// </summary>
    [TestClass]
    public class Md5
    {
        /// <summary>
        /// Test ToMd5 method
        /// </summary>
        [TestMethod]
        public void Md5_Create()
        {
            const string md5Text = "test";
            const string md5Result = "098f6bcd4621d373cade4e832627b4f6";

            Assert.AreEqual(md5Result, md5Text.ToMd5(), "Error creating md5 hash");
            Assert.AreEqual(((string)null).ToMd5(), null, "Error creating md5 hash");
        }
    }
}
