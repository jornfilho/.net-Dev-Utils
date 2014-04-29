using DevUtils.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.Validators
{
    /// <summary>
    /// Uri validator class
    /// </summary>
    [TestClass]
    public class Uri
    {
        /// <summary>
        /// Test IsUriValid method
        /// </summary>
        [TestMethod]
        public void IsUriValid()
        {
            const string valid1 = "http://www.test.com";
            const string valid2 = "http://test.com";
            const string valid3 = "www.test.com";
            const string valid4 = "http://test.com";
            const string invalid1 = "teste";
            const string invalid2 = "";

            Assert.IsTrue(valid1.IsUriValid(), "Error on validate uri");
            Assert.IsTrue(valid2.IsUriValid(), "Error on validate uri");
            Assert.IsTrue(valid3.IsUriValid(), "Error on validate uri");
            Assert.IsTrue(valid4.IsUriValid(), "Error on validate uri");

            Assert.IsFalse(invalid1.IsUriValid(), "Error on validate uri");
            Assert.IsFalse(invalid2.IsUriValid(), "Error on validate uri");
        }
    }
}
