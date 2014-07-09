using System.Collections.Generic;
using System.Linq;
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
        /// Test method GetDigits
        /// </summary>
        [TestMethod]
        public void GetDigits()
        {
            const string str1 = "a1b2 c3d4";
            const string str2 = "abcd 1234";
            const string str3 = "1234 abcd";
            const string strNumbers = "1234";

            Assert.AreEqual(str1.GetDigits(), strNumbers, "Error getting only digits");
            Assert.AreEqual(str2.GetDigits(), strNumbers, "Error getting only digits");
            Assert.AreEqual(str3.GetDigits(), strNumbers, "Error getting only digits");
        }
        
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

        /// <summary>
        /// Test method CompareNoCase. Compare strings with no case
        /// </summary>
        [TestMethod]
        public void TestCaseInsensitiveComparisonIsEquivalent()
        {
            const string value = "Hello World!";
            var result = value.CompareNoCase("hello world!");
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test method ContainedIn. Test if string is contained in array
        /// </summary>
        [TestMethod]
        public void TestedStringIsContainedInArray()
        {
            const string value = "Hello World!";
            object[] values = { 1, "smith", true, "World" };

            var result = value.ContainedIn(values);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test method ContainedIn. Test if string is contained in object list
        /// </summary>
        [TestMethod]
        public void TestStringIsContainedInGenericObjectList()
        {
            const string value = "Hello World!";
            var values = new List<object> { 1, "smith", true, "World" };

            var result = value.ContainedIn(values);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test method ContainedIn. Test if string is contained in string list
        /// </summary>
        [TestMethod]
        public void TestStringIsContainedInGenericStringList()
        {
            const string value = "Hello World!";
            var values = new List<string> { "1", "smith", "true", "World" };

            var result = value.ContainedIn(values);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test method EndsWithCurrent. Compare with current culture
        /// </summary>
        [TestMethod]
        public void TestStringOfCurrentCultureEndsWithSubstring()
        {
            const string value = "Hello World!";

            var result = value.EndsWithCurrent("World!");
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test method EndsWithOrdinalIgnoreCase. Compare with ignore case
        /// </summary>
        [TestMethod]
        public void TestCaseInsensitiveStringEndsWithSubstring()
        {
            const string value = "Hello World!";

            var result = value.EndsWithOrdinalIgnoreCase("world!");
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test method FormatCurrent. Format string in current culture from arguments array
        /// </summary>
        [TestMethod]
        public void TestStringOfCurrentCultureIsFormattedWithArgumentsArray()
        {
            const string format = "I work for {0}. My name is {1}. Today is {2}. My favorite language is {3}.";
            const string expected = "I work for My Company. My name is John. Today is Friday. My favorite language is C#.";

            var result = format.FormatCurrent("My Company", "John", "Friday", "C#");

            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Test method FormatCurrent. Format string in current culture with 3 arguments
        /// </summary>
        [TestMethod]
        public void TestStringOfCurrentCultureIsFormattedWith3Arguments()
        {
            const string format = "I work for {0}. My name is {1}. Today is {2}.";
            const string expected = "I work for My Company. My name is John. Today is Friday.";

            var result = format.FormatCurrent("My Company", "John", "Friday");

            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Test method FormatCurrent. Format string in current culture with 2 arguments
        /// </summary>
        [TestMethod]
        public void TestStringOfCurrentCultureIsFormattedWith2Arguments()
        {
            const string format = "I work for {0}. My name is {1}.";
            const string expected = "I work for My Company. My name is John.";

            var result = format.FormatCurrent("My Company", "John");

            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Test method FormatCurrent. Format string in current culture with 1 argument
        /// </summary>
        [TestMethod]
        public void TestStringOfCurrentCultureIsFormattedWith1Argument()
        {
            const string format = "I work for {0}.";
            const string expected = "I work for My Company.";

            var result = format.FormatCurrent("My Company");

            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Test method FormatInvariant. Format string in invariant culture with arguments array
        /// </summary>
        [TestMethod]
        public void TestStringOfInvariantCultureIsFormattedWithArgumentsArray()
        {
            const string format = "I work for {0}. My name is {1}. Today is {2}. My favorite language is {3}.";
            const string expected = "I work for My Company. My name is John. Today is Friday. My favorite language is C#.";

            var result = format.FormatInvariant("My Company", "John", "Friday", "C#");

            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Test method FormatInvariant. Format string in invariant culture with 3 arguments
        /// </summary>
        [TestMethod]
        public void TestStringOfInvariantCultureIsFormattedWith3Arguments()
        {
            const string format = "I work for {0}. My name is {1}. Today is {2}.";
            const string expected = "I work for My Company. My name is John. Today is Friday.";

            var result = format.FormatInvariant("My Company", "John", "Friday");

            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Test method FormatInvariant. Format string in invariant culture with 2 arguments
        /// </summary>
        [TestMethod]
        public void TestStringOfInvariantCultureIsFormattedWith2Arguments()
        {
            const string format = "I work for {0}. My name is {1}.";
            const string expected = "I work for My Company. My name is John.";

            var result = format.FormatInvariant("My Company", "John");

            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Test method FormatInvariant. Format string in invariant culture with 1 argument
        /// </summary>
        [TestMethod]
        public void TestStringOfInvariantCultureIsFormattedWith1Argument()
        {
            const string format = "I work for {0}.";
            const string expected = "I work for My Company.";

            var result = format.FormatInvariant("My Company");

            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Test method IndexOfAll.
        /// </summary>
        [TestMethod]
        public void TestSubstringReturnsAllIndexesFromString()
        {
            const string value = "This is a string used in a unit test. It has many strings in this big string.";

            var indexes = value.IndexOfAll("string");

            Assert.AreEqual(indexes.Count(), 3);
            Assert.AreEqual(10, indexes.ElementAt(0));
            Assert.AreEqual(50, indexes.ElementAt(1));
            Assert.AreEqual(70, indexes.ElementAt(2));
        }

        /// <summary>
        /// Test method IndexOfAll.
        /// </summary>
        [TestMethod]
        public void TestSubstringDoesNotReturnAllIndexesFromStringWhenSubstringIsNotFound()
        {
            const string value = "This is a string used in a unit test. It has many strings in this big string.";

            var indexes = value.IndexOfAll("nostring");

            Assert.AreEqual(indexes.Count(), 0);
        }

        /// <summary>
        /// Test method IndexOfCurrent. Current culture, start index
        /// </summary>
        [TestMethod]
        public void TestSubstringOfCurrentCultureWithStartIndexArgumentReturnsProperIndexFromString()
        {
            const string value = "This is a string used in a unit test.";

            var index = value.IndexOfCurrent("string", 16);

            Assert.AreNotEqual(10, index);
        }

        /// <summary>
        /// Test method IndexOfCurrent. Current culture, no start index
        /// </summary>
        [TestMethod]
        public void TestSubstringOfCurrentCultureReturnsProperIndexFromString()
        {
            const string value = "This is a string used in a unit test.";

            var index = value.IndexOfCurrent("string");

            Assert.AreEqual(10, index);
        }

        /// <summary>
        /// Test method IndexOfCurrent. Current culture, no start index
        /// </summary>
        [TestMethod]
        public void TestSubstringOfCurrentCultureReturnsInvalidIndexWhenNotFoundInString()
        {
            const string value = "This is a string used in a unit test.";

            var index = value.IndexOfCurrent("NotFound");

            Assert.AreEqual(-1, index);
        }

        /// <summary>
        /// Test method IndexOfOrdinalIgnoreCase. Ignore case, start index
        /// </summary>
        [TestMethod]
        public void TestCaseInsensitiveSubstringWithStartIndexArgumentReturnsProperIndexFromString()
        {
            const string value = "This is a STRING used in a unit test.";

            var index = value.IndexOfOrdinalIgnoreCase("string", 16);

            Assert.AreNotEqual(10, index);
        }

        /// <summary>
        /// Test method IndexOfOrdinalIgnoreCase. Ignore case, no start index
        /// </summary>
        [TestMethod]
        public void TestCaseInsensitiveSubstringReturnsProperIndexFromString()
        {
            const string value = "This is a STRING used in a unit test.";

            var index = value.IndexOfOrdinalIgnoreCase("string");

            Assert.AreEqual(10, index);
        }

        /// <summary>
        /// Test method IndexOfOrdinalIgnoreCase. Ignore case, no start index
        /// </summary>
        [TestMethod]
        public void TestCaseInsensitiveSubstringReturnsInvalidIndexWhenNotFoundInString()
        {
            const string value = "This is a STRING used in a unit test.";

            var index = value.IndexOfOrdinalIgnoreCase("NotFound");

            Assert.AreEqual(-1, index);
        }

        /// <summary>
        /// Test method Join. String join from array
        /// </summary>
        [TestMethod]
        public void TestStringIsJoinedFromArray()
        {
            const string value = "This,is,a,joined,string";
            string[] array = { "This", "is", "a", "joined", "string" };

            var result = array.Join(",");

            Assert.AreEqual(value, result);
        }

        /// <summary>
        /// Test method Join. String join from null array
        /// </summary>
        [TestMethod]
        public void TestStringIsNotJoinedFromArrayWhenNull()
        {
            string[] array = null;

            var result = array.Join(",");

            Assert.IsNull(result);
        }

        /// <summary>
        /// Test method Join. String join from list
        /// </summary>
        [TestMethod]
        public void TestStringIsJoinedFromList()
        {
            const string value = "This,is,a,joined,string";
            var list = new List<string> { "This", "is", "a", "joined", "string" };

            var result = list.Join(",");

            Assert.AreEqual(value, result);
        }

        /// <summary>
        /// Test method Join. String join from null list
        /// </summary>
        [TestMethod]
        public void TestStringIsNotJoinedFromListWhenNull()
        {
            List<string> list = null;

            var result = list.Join(",");

            Assert.IsNull(result);
        }

        /// <summary>
        /// Test method StartsWithCurrent. Current culture
        /// </summary>
        [TestMethod]
        public void TestStringOfCurrentCultureStartsWithSubstring()
        {
            const string value = "C# programming is cool!";

            var result = value.StartsWithCurrent("C#");

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test method StartsWithOrdinalIgnoreCase. Ignore case
        /// </summary>
        [TestMethod]
        public void TestCaseInsensitiveStringStartsWithSubstring()
        {
            const string value = "c# programming is cool!";

            var result = value.StartsWithOrdinalIgnoreCase("C#");

            Assert.IsTrue(result);
        }
    }
}
