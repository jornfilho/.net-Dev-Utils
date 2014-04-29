using System.Linq;
using DevUtils.PrimitivesExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.PrimitivesExtensions
{
    /// <summary>
    /// Test class BoolExtensions
    /// </summary>
    [TestClass]
    public class BoolExtensions
    {
        /// <summary>
        /// Teste method TryParseBool and overload
        /// </summary>
        [TestMethod]
        public void TryParseBool()
        {
            const string strTrue = "true";
            const string strTrueBit = "1";
            const string strFalse = "false";
            const string strFalseBit = "0";
            const string strInvalid = "";

            Assert.AreEqual(strTrue.TryParseBool(), true, "Error converting boolean with TryParseBool class");
            Assert.AreEqual(strTrue.ToUpper().TryParseBool(), true, "Error converting boolean with TryParseBool class");
            Assert.AreEqual(strTrueBit.TryParseBool(), true, "Error converting boolean with TryParseBool class");
            Assert.AreEqual(strFalse.TryParseBool(), false, "Error converting boolean with TryParseBool class");
            Assert.AreEqual(strFalse.ToUpper().TryParseBool(), false, "Error converting boolean with TryParseBool class");
            Assert.AreEqual(strFalseBit.TryParseBool(), false, "Error converting boolean with TryParseBool class");
            Assert.AreEqual(strInvalid.TryParseBool(), false, "Error converting boolean with TryParseBool class");

            Assert.AreEqual(strTrue.TryParseBool(false), true, "Error converting boolean with TryParseBool class");
            Assert.AreEqual(strTrue.ToUpper().TryParseBool(false), true, "Error converting boolean with TryParseBool class");
            Assert.AreEqual(strTrueBit.TryParseBool(false), true, "Error converting boolean with TryParseBool class");
            Assert.AreEqual(strFalse.TryParseBool(false), false, "Error converting boolean with TryParseBool class");
            Assert.AreEqual(strFalse.ToUpper().TryParseBool(false), false, "Error converting boolean with TryParseBool class");
            Assert.AreEqual(strFalseBit.TryParseBool(false), false, "Error converting boolean with TryParseBool class");
            Assert.AreEqual(strInvalid.TryParseBool(false), false, "Error converting boolean with TryParseBool class");
            Assert.AreEqual(strInvalid.TryParseBool(true), true, "Error converting boolean with TryParseBool class");
            
        }

        /// <summary>
        /// Teste method TryParseBoolArray and overload
        /// </summary>
        [TestMethod]
        public void TryParseBoolArray()
        {
            const string strTrue = "true";
            const string strTrueBit = "1";
            const string strFalse = "false";
            const string strFalseBit = "0";
            const string strInvalid = "a";

            var trueValues = new[] { strTrue, strTrueBit };
            var falseValues = new[] { strFalse, strFalseBit };
            var mixedValues = new[] { strTrue, strTrueBit, strFalse, strFalseBit, strInvalid };
            var noneValues = new[] { strInvalid };

            #region full method, without default, dont return defult false conversion
            var trueConversions = string.Join(",", trueValues).TryParseBoolArray(null, false);
            Assert.IsNotNull(trueConversions, "Error converting string to bool array");
            Assert.IsTrue(trueConversions.Any(), "Error converting string to bool array");
            Assert.IsFalse(trueConversions.Any(a => !a), "Error converting string to bool array");
            Assert.IsTrue(trueConversions.Count() == trueValues.Count(), "Error converting string to bool array");

            var falseConversions = string.Join(",", falseValues).TryParseBoolArray(null, false);
            Assert.IsNotNull(falseConversions, "Error converting string to bool array");
            Assert.IsTrue(falseConversions.Any(), "Error converting string to bool array");
            Assert.IsFalse(falseConversions.Any(a => a), "Error converting string to bool array");
            Assert.IsTrue(falseConversions.Count() == falseValues.Count(), "Error converting string to bool array");

            var mixedConversions = string.Join(",", mixedValues).TryParseBoolArray(null, false);
            Assert.IsNotNull(mixedConversions, "Error converting string to bool array");
            Assert.IsTrue(mixedConversions.Any(a => a) && mixedConversions.Any(a => !a), "Error converting string to bool array");
            Assert.IsTrue(mixedConversions.Count() == (mixedValues.Count() - 1), "Error converting string to bool array");

            var noneConversions = string.Join(",", noneValues).TryParseBoolArray(null, false);
            Assert.IsNotNull(noneConversions, "Error converting string to bool array");
            Assert.IsFalse(noneConversions.Any(), "Error converting string to bool array");
            #endregion

            #region full method, with default, dont return defult false conversion
            noneConversions = string.Join(",", noneValues).TryParseBoolArray(new []{true}, false);
            Assert.IsNotNull(noneConversions, "Error converting string to bool array");
            Assert.IsTrue(noneConversions.Any(), "Error converting string to bool array");
            Assert.IsFalse(noneConversions.Any(a=> !a), "Error converting string to bool array");
            #endregion

            #region full method, without default, return defult false conversion
            noneConversions = string.Join(",", noneValues).TryParseBoolArray(null, true);
            Assert.IsNotNull(noneConversions, "Error converting string to bool array");
            Assert.IsTrue(noneConversions.Any(), "Error converting string to bool array");
            Assert.IsFalse(noneConversions.Any(a => a), "Error converting string to bool array");
            #endregion

            #region partial method, without default
            trueConversions = string.Join(",", trueValues).TryParseBoolArray(null);
            Assert.IsNotNull(trueConversions, "Error converting string to bool array");
            Assert.IsTrue(trueConversions.Any(), "Error converting string to bool array");
            Assert.IsFalse(trueConversions.Any(a => !a), "Error converting string to bool array");
            Assert.IsTrue(trueConversions.Count() == trueValues.Count(), "Error converting string to bool array");

            falseConversions = string.Join(",", falseValues).TryParseBoolArray(null);
            Assert.IsNotNull(falseConversions, "Error converting string to bool array");
            Assert.IsTrue(falseConversions.Any(), "Error converting string to bool array");
            Assert.IsFalse(falseConversions.Any(a => a), "Error converting string to bool array");
            Assert.IsTrue(falseConversions.Count() == falseValues.Count(), "Error converting string to bool array");

            mixedConversions = string.Join(",", mixedValues).TryParseBoolArray(null);
            Assert.IsNotNull(mixedConversions, "Error converting string to bool array");
            Assert.IsTrue(mixedConversions.Any(a => a) && mixedConversions.Any(a => !a), "Error converting string to bool array");
            Assert.IsTrue(mixedConversions.Count() == (mixedValues.Count() - 1), "Error converting string to bool array");

            noneConversions = string.Join(",", noneValues).TryParseBoolArray(null);
            Assert.IsNotNull(noneConversions, "Error converting string to bool array");
            Assert.IsFalse(noneConversions.Any(), "Error converting string to bool array");
            #endregion

            #region partial method, with default
            noneConversions = string.Join(",", noneValues).TryParseBoolArray(new[] { true });
            Assert.IsNotNull(noneConversions, "Error converting string to bool array");
            Assert.IsTrue(noneConversions.Any(), "Error converting string to bool array");
            Assert.IsFalse(noneConversions.Any(a => !a), "Error converting string to bool array");
            #endregion

            #region simple method
            trueConversions = string.Join(",", trueValues).TryParseBoolArray();
            Assert.IsNotNull(trueConversions, "Error converting string to bool array");
            Assert.IsTrue(trueConversions.Any(), "Error converting string to bool array");
            Assert.IsFalse(trueConversions.Any(a => !a), "Error converting string to bool array");
            Assert.IsTrue(trueConversions.Count() == trueValues.Count(), "Error converting string to bool array");

            falseConversions = string.Join(",", falseValues).TryParseBoolArray();
            Assert.IsNotNull(falseConversions, "Error converting string to bool array");
            Assert.IsTrue(falseConversions.Any(), "Error converting string to bool array");
            Assert.IsFalse(falseConversions.Any(a => a), "Error converting string to bool array");
            Assert.IsTrue(falseConversions.Count() == falseValues.Count(), "Error converting string to bool array");

            mixedConversions = string.Join(",", mixedValues).TryParseBoolArray();
            Assert.IsNotNull(mixedConversions, "Error converting string to bool array");
            Assert.IsTrue(mixedConversions.Any(a => a) && mixedConversions.Any(a => !a), "Error converting string to bool array");
            Assert.IsTrue(mixedConversions.Count() == (mixedValues.Count() - 1), "Error converting string to bool array");

            noneConversions = string.Join(",", noneValues).TryParseBoolArray();
            Assert.IsNotNull(noneConversions, "Error converting string to bool array");
            Assert.IsFalse(noneConversions.Any(), "Error converting string to bool array");
            #endregion
        }

        /// <summary>
        /// Teste method IsValidBool
        /// </summary>
        [TestMethod]
        public void IsValidBool()
        {
            Assert.IsFalse("0".IsValidBool());
            Assert.IsFalse("1.1".IsValidBool());
            Assert.IsFalse("10".IsValidBool());
            Assert.IsFalse("jorn".IsValidBool());
            Assert.IsFalse("false".IsValidBool());
            Assert.IsFalse("".IsValidBool());
            Assert.IsTrue("1".IsValidBool());
            Assert.IsTrue("true".IsValidBool());
        }
    }
}
