using System;
using DevUtils.ObjectExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.ObjectExtensions
{
    /// <summary>
    /// Test class for ObjectExtension methods
    /// </summary>
    [TestClass]
    public class ObjectExtension
    {
        /// <summary>
        /// Test method IsNull
        /// </summary>
        [TestMethod]
        public void TestVerifyObjectNull()
        {
            Object objectDefaultNull = null;
            var objectDefaultNotNull = new Object();
            Foo objectFooNull = null;
            var objectFooNotNull = new Foo();
            var objectFooWithNameNotNull = new Foo { Name = "test" };
            EnumTest? enumNull = null;
            EnumTest? enumNotNull = EnumTest.First;
            int? variableIntNull = null;
            const int variableIntNotNull = 10;
            string stringNull = null;
            var stringNotNull = string.Empty;
            bool? booleanNull = null;
            bool? booleanNotNull = false;
            byte? byteNull = null;
            byte? byteNotNull = 1;
            decimal? decimalNull = null;
            decimal? decimalNotNull = 1;
            double? doubleNull = null;
            double? doubleNotNull = 1;
            float? floatNull = null;
            float? floatNotNull = 1;
            long? longNull = null;
            long? longNotNull = 1;
            short? shortNull = null;
            short? shortNotNull = 1;
            
            Assert.IsTrue(objectDefaultNull.IsNull());
            Assert.IsFalse(objectDefaultNotNull.IsNull());
            Assert.IsTrue(objectFooNull.IsNull());
            Assert.IsFalse(objectFooNotNull.IsNull());
            Assert.IsFalse(objectFooWithNameNotNull.IsNull());
            Assert.IsTrue(enumNull.IsNull());
            Assert.IsFalse(enumNotNull.IsNull());
            Assert.IsTrue(variableIntNull.IsNull());
            Assert.IsFalse(variableIntNotNull.IsNull());
            Assert.IsTrue(stringNull.IsNull());
            Assert.IsFalse(stringNotNull.IsNull());
            Assert.IsTrue(booleanNull.IsNull());
            Assert.IsFalse(booleanNotNull.IsNull());
            Assert.IsTrue(byteNull.IsNull());
            Assert.IsFalse(byteNotNull.IsNull());
            Assert.IsTrue(decimalNull.IsNull());
            Assert.IsFalse(decimalNotNull.IsNull());
            Assert.IsTrue(doubleNull.IsNull());
            Assert.IsFalse(doubleNotNull.IsNull());
            Assert.IsTrue(floatNull.IsNull());
            Assert.IsFalse(floatNotNull.IsNull());
            Assert.IsTrue(longNull.IsNull());
            Assert.IsFalse(longNotNull.IsNull());
            Assert.IsTrue(shortNull.IsNull());
            Assert.IsFalse(shortNotNull.IsNull());
        }
    }

    /// <summary>
    ///     Class for test
    /// </summary>
    internal class Foo
    {
        public string Name { get; set; }
    }

    /// <summary>
    ///     Enum for test
    /// </summary>
    internal enum EnumTest
    {
        First = 1
    }
}