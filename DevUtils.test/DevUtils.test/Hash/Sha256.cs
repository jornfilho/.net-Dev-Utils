using DevUtils.Hash;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.Hash
{
    /// <summary>
    /// Sha256 test class
    /// </summary>
    [TestClass]
    public class Sha256
    {
        /// <summary>
        /// Test ToSha256 method
        /// </summary>
        [TestMethod]
        public void Sha256_Create()
        {
            const string sha256Text = "test";
            const string sha256TextBlank = "";
            const string sha256Result = "9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08";

            Assert.AreEqual(sha256Result, sha256Text.ToSha256(), "Error creating sha256 hash");
            Assert.AreEqual(((string)null).ToSha256(), null, "Error creating sha256 hash");
            Assert.IsNull(sha256TextBlank.ToSha256(), "Error creating sha256 hash");
        }
    }
}
