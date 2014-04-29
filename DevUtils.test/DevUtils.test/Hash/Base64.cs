using DevUtils.Hash;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.Hash
{
    /// <summary>
    /// Base64 test class
    /// </summary>
    [TestClass]
    public class Base64
    {
        /// <summary>
        /// Test ToBase64 method
        /// </summary>
        [TestMethod]
        public void Base64_Create()
        {
            const string base64Text = "test";
            const string base64Result = "dGVzdA==";

            Assert.AreEqual(base64Result, base64Text.ToBase64(), "Error creating base64 hash");
            Assert.AreEqual(((string)null).ToBase64(), null, "Error creating base64 hash");
        }

        /// <summary>
        /// Test FromBase64 method
        /// </summary>
        [TestMethod]
        public void Base64_Revert()
        {
            const string base64Text = "test";
            const string base64Result = "dGVzdA==";

            Assert.AreEqual(base64Text, base64Result.FromBase64(), "Error reverting base64 hash");
            Assert.AreEqual(((string)null).FromBase64(), null, "Error reverting base64 hash");
        }
    }
}
