using DevUtils.PrimitivesExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.PrimitivesExtensions
{
    /// <summary>
    /// StringExtensions test class
    /// </summary>
    [TestClass]
    public class StringExtensions
    {
        /// <summary>
        /// Test method ToUnicode
        /// </summary>
        [TestMethod]
        public void ToUnicode()
        {
            const string stringToPrepare = "çÇáéíóúýÁÉÍÓÚÝàèìòùÀÈÌÒÙãõñäëïöüÿÄËÏÖÜÃÕÑâêîôûÂÊÎÔÛ";
            const string stringExpected = "cCaeiouyAEIOUYaeiouAEIOUaonaeiouyAEIOUAONaeiouAEIOU";

            Assert.AreEqual(stringToPrepare.ToUnicode(), stringExpected, "Error converting string to unicode");
        }

        /// <summary>
        /// Test method ToUnicodeWithoutSpace
        /// </summary>
        [TestMethod]
        public void ToUnicodeWithoutSpaces()
        {
            const string stringToPrepare = "ç Ç áéíóúý ÁÉÍÓÚÝ àèìòù ÀÈÌÒÙ ãõñäëïöüÿ ÄËÏÖÜÃÕÑ âêîôû ÂÊÎÔÛ";
            const string stringExpected = "c_C_aeiouy_AEIOUY_aeiou_AEIOU_aonaeiouy_AEIOUAON_aeiou_AEIOU";

            Assert.AreEqual(stringToPrepare.ToUnicodeWithoutSpace(), stringExpected, "Error converting string to unicode");
        }

        /// <summary>
        /// Test method Left
        /// </summary>
        [TestMethod]
        public void Left()
        {
            const string fullString = "test";
            const string partString = "te";
            const int length = 2;

            Assert.AreEqual(fullString.Left(length), partString, "Error getting left string part");
            Assert.AreEqual(fullString.Left(fullString.Length + 1), fullString, "Error getting left string part");
        }

        /// <summary>
        /// Test method Right
        /// </summary>
        [TestMethod]
        public void Right()
        {
            const string fullString = "test";
            const string partString = "st";
            const int length = 2;

            Assert.AreEqual(fullString.Right(length), partString, "Error getting right string part");
            Assert.AreEqual(fullString.Right(fullString.Length + 1), fullString, "Error getting right string part");
        }
    }
}
