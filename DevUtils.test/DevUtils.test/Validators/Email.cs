using DevUtils.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.Validators
{
    /// <summary>
    /// Email validator test class
    /// </summary>
    [TestClass]
    public class Email
    {
        /// <summary>
        /// Test IsEmailValid method
        /// </summary>
        [TestMethod]
        public void IsEmailValid()
        {
            const string validEmail = "teste@teste.com";
            const string invalidEmail = "teste@teste";

            Assert.IsTrue(validEmail.IsEmailValid(), "Error on validate e-mail");
            Assert.IsFalse(invalidEmail.IsEmailValid(), "Error on validate e-mail");
            Assert.IsFalse("".IsEmailValid(), "Error on validate e-mail");
        }
    }
}
