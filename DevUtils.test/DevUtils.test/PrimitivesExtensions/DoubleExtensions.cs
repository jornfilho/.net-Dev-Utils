using System.Globalization;
using System.Linq;
using DevUtils.PrimitivesExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.PrimitivesExtensions
{
    /// <summary>
    /// Test class DoubleExtensions
    /// </summary>
    [TestClass]
    public class DoubleExtensions
    {
        #region Params
        private CultureInfo Culture { get; set; }
        private string ConvertibleStringValue { get; set; }
        private double ConvertibleDoubleValue { get; set; }
        private double ConvertibleDoubleValueInt { get; set; }
        private double? ConvertibleNullableDoubleValue { get; set; }
        private byte? ConvertibleNullableByteValue { get; set; }
        private byte ConvertibleByteValue { get; set; }
        private short? ConvertibleNullableShortValue { get; set; }
        private short ConvertibleShortValue { get; set; }
        private long? ConvertibleNullableLongValue { get; set; }
        private long ConvertibleLongValue { get; set; }
        private int? ConvertibleNullableIntValue { get; set; }
        private int ConvertibleIntValue { get; set; }
        private decimal? ConvertibleNullableDecimalValue { get; set; }
        private decimal ConvertibleDecimalValue { get; set; }
        private float? ConvertibleNullableFloatValue { get; set; }
        private float ConvertibleFloatValue { get; set; }
        private double DefaultValue { get; set; }
        private NumberStyles NumberStyle { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Test constructor
        /// </summary>
        public DoubleExtensions()
        {
            Culture = CultureInfo.CurrentCulture;
            DefaultValue = 100;

            ConvertibleStringValue = "200.21".Replace(".", Culture.NumberFormat.CurrencyDecimalSeparator);
            ConvertibleDoubleValue = 200.21;
            ConvertibleNullableDoubleValue = 200.21;
            ConvertibleDoubleValueInt = 200;
            ConvertibleNullableByteValue = (byte?)ConvertibleNullableDoubleValue;
            ConvertibleByteValue = (byte)ConvertibleNullableDoubleValue;
            ConvertibleNullableShortValue = (short?)ConvertibleNullableDoubleValue;
            ConvertibleShortValue = (short)ConvertibleNullableDoubleValue;
            ConvertibleNullableLongValue = (long?)ConvertibleNullableDoubleValue;
            ConvertibleLongValue = (long)ConvertibleNullableDoubleValue;
            ConvertibleNullableIntValue = (int?)ConvertibleNullableDoubleValue;
            ConvertibleIntValue = (int)ConvertibleNullableDoubleValue;
            ConvertibleNullableDecimalValue = (decimal?)ConvertibleNullableDoubleValue;
            ConvertibleDecimalValue = (decimal)ConvertibleDoubleValue;
            ConvertibleNullableFloatValue = (float?)ConvertibleNullableDoubleValue;
            ConvertibleFloatValue = (float)ConvertibleDoubleValue;
            NumberStyle = NumberStyles.Float;

        } 
        #endregion

        /// <summary>
        /// Test TryParseDouble method from string value
        /// </summary>
        [TestMethod]
        public void TryParseDouble_FromString()
        {
            const string invalidValue1 = "";
            const string invalidValue2 = "b";
            
            #region full method
            var success = ConvertibleStringValue.TryParseDouble(DefaultValue,
                BasePrimitivesExtensions.GetDefaultDoubleAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            var invalid1 = invalidValue1.TryParseDouble(DefaultValue,
                BasePrimitivesExtensions.GetDefaultDoubleAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            var invalid2 = invalidValue2.TryParseDouble(DefaultValue,
                BasePrimitivesExtensions.GetDefaultDoubleAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            Assert.AreEqual(success, ConvertibleDoubleValue, "Error converting string to double");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to double");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to double");
            #endregion

            #region without allowZero param
            success = ConvertibleStringValue.TryParseDouble(DefaultValue,
                BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid1 = invalidValue1.TryParseDouble(DefaultValue,
                BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid2 = invalidValue2.TryParseDouble(DefaultValue,
                BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            Assert.AreEqual(success, ConvertibleDoubleValue, "Error converting string to double");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to double");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to double");
            #endregion

            #region without allowZero and DefaultValue params
            success = ConvertibleStringValue.TryParseDouble(BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid1 = invalidValue1.TryParseDouble(BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid2 = invalidValue2.TryParseDouble(BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            Assert.AreEqual(success, ConvertibleDoubleValue, "Error converting string to double");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting string to double");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting string to double");
            #endregion

            #region without number style and culture params
            success = ConvertibleStringValue.TryParseDouble(DefaultValue,
                BasePrimitivesExtensions.GetDefaultDoubleAllowDefaultConversion());

            invalid1 = invalidValue1.TryParseDouble(DefaultValue,
                BasePrimitivesExtensions.GetDefaultDoubleAllowDefaultConversion());

            invalid2 = invalidValue2.TryParseDouble(DefaultValue,
                BasePrimitivesExtensions.GetDefaultDoubleAllowDefaultConversion());

            Assert.AreEqual(success, ConvertibleDoubleValue, "Error converting string to double");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to double");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to double");
            #endregion

            #region without number style, culture and allowZero params
            success = ConvertibleStringValue.TryParseDouble(DefaultValue);
            invalid1 = invalidValue1.TryParseDouble(DefaultValue);
            invalid2 = invalidValue2.TryParseDouble(DefaultValue);

            Assert.AreEqual(success, ConvertibleDoubleValue, "Error converting string to double");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to double");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to double");
            #endregion

            #region simple conversion
            success = ConvertibleStringValue.TryParseDouble();
            invalid1 = invalidValue1.TryParseDouble();
            invalid2 = invalidValue2.TryParseDouble();

            Assert.AreEqual(success, ConvertibleDoubleValue, "Error converting string to double");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting string to double");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting string to double");
            #endregion
        }

        /// <summary>
        /// Test TryParseDouble method from nullable double value
        /// </summary>
        [TestMethod]
        public void TryParseDouble_NullableDouble()
        {
            #region full method
            var success = ConvertibleNullableDoubleValue.TryParseDouble(DefaultValue);
            var invalid = ((double?)null).TryParseDouble(DefaultValue);

            Assert.AreEqual(success, ConvertibleDoubleValue, "Error converting nullable double to double");
            Assert.AreEqual(invalid, DefaultValue, "Error converting nullable double to double");
            #endregion

            #region simple method
            success = ConvertibleNullableDoubleValue.TryParseDouble();
            invalid = ((double?)null).TryParseDouble();

            Assert.AreEqual(success, ConvertibleDoubleValue, "Error converting nullable double to double");
            Assert.AreEqual(invalid, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting nullable double to double");
            #endregion
        }

        /// <summary>
        /// Test TryParseDouble method from byte and nullable byte values
        /// </summary>
        [TestMethod]
        public void TryParseDouble_FromByteAndNullableByte()
        {
            #region byte - full method
            var success = ConvertibleByteValue.TryParseDouble();
            Assert.AreEqual(success, ConvertibleDoubleValueInt, "Error converting byte to double");
            #endregion

            #region byte? - full method
            success = ConvertibleNullableByteValue.TryParseDouble(DefaultValue);
            var invalid1 = ((byte?)null).TryParseDouble(DefaultValue);

            Assert.AreEqual(success, ConvertibleDoubleValueInt, "Error converting byte? to double");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting byte? to double");
            #endregion

            #region byte? - without DefaultValue param
            success = ConvertibleNullableByteValue.TryParseDouble();
            invalid1 = ((byte?)null).TryParseDouble();

            Assert.AreEqual(success, ConvertibleDoubleValueInt, "Error converting byte? to double");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting byte? to double");
            #endregion

        }

        /// <summary>
        /// Test TryParseDouble method from short and nullable short values
        /// </summary>
        [TestMethod]
        public void TryParseDouble_FromShortAndNullableShort()
        {
            #region byte - full method
            var success = ConvertibleShortValue.TryParseDouble();
            Assert.AreEqual(success, ConvertibleDoubleValueInt, "Error converting byte to double");
            #endregion

            #region byte? - full method
            success = ConvertibleNullableShortValue.TryParseDouble(DefaultValue);
            var invalid1 = ((short?)null).TryParseDouble(DefaultValue);

            Assert.AreEqual(success, ConvertibleDoubleValueInt, "Error converting byte? to double");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting byte? to double");
            #endregion

            #region byte? - without DefaultValue param
            success = ConvertibleNullableShortValue.TryParseDouble();
            invalid1 = ((short?)null).TryParseDouble();

            Assert.AreEqual(success, ConvertibleDoubleValueInt, "Error converting byte? to double");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting byte? to double");
            #endregion

        }

        /// <summary>
        /// Test TryParseDouble method from long and nullable long values
        /// </summary>
        [TestMethod]
        public void TryParseDouble_FromLongAndNullableLong()
        {
            #region long - full method
            var success = ConvertibleLongValue.TryParseDouble(DefaultValue);

            Assert.AreEqual(success, ConvertibleDoubleValueInt, "Error converting long to double");
            #endregion

            #region long - without DefaultValue param
            success = ConvertibleLongValue.TryParseDouble();

            Assert.AreEqual(success, ConvertibleDoubleValueInt, "Error converting long to double");
            #endregion

            #region long? - full method
            success = ConvertibleNullableLongValue.TryParseDouble(DefaultValue);
            var invalid1 = ((long?)null).TryParseDouble(DefaultValue);

            Assert.AreEqual(success, ConvertibleDoubleValueInt, "Error converting long? to double");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting long? to double");
            #endregion

            #region long? - without DefaultValue param
            success = ConvertibleNullableLongValue.TryParseDouble();
            invalid1 = ((long?)null).TryParseDouble();

            Assert.AreEqual(success, ConvertibleDoubleValueInt, "Error converting long? to double");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting long? to double");
            #endregion

        }

        /// <summary>
        /// Test TryParseDouble method from double and nullable double values
        /// </summary>
        [TestMethod]
        public void TryParseDouble_FromIntAndNullableInt()
        {
            #region double - full method
            var success = ConvertibleIntValue.TryParseDouble(DefaultValue);

            Assert.AreEqual(success, ConvertibleDoubleValueInt, "Error converting double to double");
            #endregion

            #region double - without DefaultValue param
            success = ConvertibleIntValue.TryParseDouble();

            Assert.AreEqual(success, ConvertibleDoubleValueInt, "Error converting double to double");
            #endregion

            #region double? - full method
            success = ConvertibleNullableIntValue.TryParseDouble(DefaultValue);
            var invalid1 = ((int?)null).TryParseDouble(DefaultValue);

            Assert.AreEqual(success, ConvertibleDoubleValueInt, "Error converting double? to double");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting double? to double");
            #endregion

            #region double? - without DefaultValue param
            success = ConvertibleNullableIntValue.TryParseDouble();
            invalid1 = ((int?)null).TryParseDouble();

            Assert.AreEqual(success, ConvertibleDoubleValueInt, "Error converting double? to double");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting double? to double");
            #endregion

        }

        /// <summary>
        /// Test TryParseDouble method from double and nullable double values
        /// </summary>
        [TestMethod]
        public void TryParseDouble_FromDecimalAndNullableDecimal()
        {
            #region double - full method
            var success = ConvertibleDecimalValue.TryParseDouble();

            Assert.AreEqual(success, ConvertibleDoubleValue, "Error converting double to double");
            #endregion

            #region double - without DefaultValue param
            success = ConvertibleDecimalValue.TryParseDouble();

            Assert.AreEqual(success, ConvertibleDoubleValue, "Error converting double to double");
            #endregion

            #region double? - full method
            success = ConvertibleNullableDecimalValue.TryParseDouble(DefaultValue);
            var invalid1 = ((decimal?)null).TryParseDouble(DefaultValue);

            Assert.AreEqual(success, ConvertibleDoubleValue, "Error converting double? to double");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting double? to double");
            #endregion

            #region double? - without DefaultValue param
            success = ConvertibleNullableDecimalValue.TryParseDouble();
            invalid1 = ((decimal?)null).TryParseDouble();

            Assert.AreEqual(success, ConvertibleDoubleValue, "Error converting double? to double");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting double? to double");
            #endregion

        }

        /// <summary>
        /// Test TryParseDouble method from float and nullable float values
        /// </summary>
        [TestMethod]
        public void TryParseDouble_FromFloatAndNullableFloat()
        {
            #region float - full method
            var success = ConvertibleFloatValue.TryParseDouble(DefaultValue);

            Assert.AreEqual(success.ToString("n2"), ConvertibleDoubleValue.ToString("n2"), "Error converting float to double");
            #endregion

            #region float - without DefaultValue param
            success = ConvertibleFloatValue.TryParseDouble();

            Assert.AreEqual(success.ToString("n2"), ConvertibleDoubleValue.ToString("n2"), "Error converting float to double");
            #endregion

            #region float? - full method
            success = ConvertibleNullableFloatValue.TryParseDouble(DefaultValue);
            var invalid1 = ((float?)null).TryParseDouble(DefaultValue);

            Assert.AreEqual(success.ToString("n2"), ConvertibleDoubleValue.ToString("n2"), "Error converting float? to double");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting float? to double");
            #endregion

            #region float? - without DefaultValue param
            success = ConvertibleNullableFloatValue.TryParseDouble();
            invalid1 = ((float?)null).TryParseDouble();

            Assert.AreEqual(success.ToString("n2"), ConvertibleDoubleValue.ToString("n2"), "Error converting float? to double");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultDoubleConversionValue(), "Error converting float? to double");
            #endregion
        }

        /// <summary>
        /// Teste method TryParseDoubleArray and overload
        /// </summary>
        [TestMethod]
        public void TryParseDoubleArray()
        {
            const string successValue1 = "10";
            const string successValue2 = "20";
            const string errorValue1 = "";
            const string errorValue2 = "a";

            var successByteValues = new[] { successValue1.TryParseDouble(), successValue2.TryParseDouble() };
            var successValues = new[] { successValue1, successValue2 };
            var errorValues = new[] { errorValue1, errorValue2 };
            var mixedValues = new[] { successValue1, successValue2, errorValue1, errorValue2 };

            #region full method (with number format), without default, dont return defult conversion
            var successConversion = string.Join(",", successValues).TryParseDoubleArray(null, false,
                BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(successConversion, "Error converting string to double array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to double array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to double array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to double array");

            var falseConversions = string.Join(",", errorValues).TryParseDoubleArray(null, false,
                BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(falseConversions, "Error converting string to double array");
            Assert.IsFalse(falseConversions.Any(), "Error converting string to double array");

            var mixedConversions = string.Join(",", mixedValues).TryParseDoubleArray(null, false,
                BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(mixedConversions, "Error converting string to double array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a)), "Error converting string to double array");
            Assert.IsTrue(mixedConversions.Count() == successByteValues.Count(), "Error converting string to double array");
            #endregion

            #region partial method (with number format), without default
            successConversion = string.Join(",", successValues).TryParseDoubleArray(null,
                BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(successConversion, "Error converting string to double array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to double array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to double array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to double array");

            falseConversions = string.Join(",", errorValues).TryParseDoubleArray(null,
                BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(falseConversions, "Error converting string to double array");
            Assert.IsFalse(falseConversions.Any(a=>!a.Equals(BasePrimitivesExtensions.GetDefaultDoubleConversionValue())), "Error converting string to double array");

            mixedConversions = string.Join(",", mixedValues).TryParseDoubleArray(null,
                BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(mixedConversions, "Error converting string to double array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a) && !a.Equals(BasePrimitivesExtensions.GetDefaultDoubleConversionValue())), "Error converting string to double array");
            Assert.IsTrue((mixedConversions.Count() - falseConversions.Count()) == successByteValues.Count(), "Error converting string to double array");
            #endregion

            #region simple method (with number format)
            successConversion = string.Join(",", successValues).TryParseDoubleArray(
                BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(successConversion, "Error converting string to double array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to double array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to double array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to double array");

            falseConversions = string.Join(",", errorValues).TryParseDoubleArray(
                BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(falseConversions, "Error converting string to double array");
            Assert.IsFalse(falseConversions.Any(a => !a.Equals(BasePrimitivesExtensions.GetDefaultDoubleConversionValue())), "Error converting string to double array");

            mixedConversions = string.Join(",", mixedValues).TryParseDoubleArray(
                BasePrimitivesExtensions.GetDefaultDoubleNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(mixedConversions, "Error converting string to double array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a) && !a.Equals(BasePrimitivesExtensions.GetDefaultDoubleConversionValue())), "Error converting string to double array");
            Assert.IsTrue((mixedConversions.Count() - falseConversions.Count()) == successByteValues.Count(), "Error converting string to double array");
            #endregion

            #region full method (without number format), without default, dont return defult conversion
            successConversion = string.Join(",", successValues).TryParseDoubleArray(null, false);
            Assert.IsNotNull(successConversion, "Error converting string to double array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to double array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to double array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to double array");

            falseConversions = string.Join(",", errorValues).TryParseDoubleArray(null, false);
            Assert.IsNotNull(falseConversions, "Error converting string to double array");
            Assert.IsFalse(falseConversions.Any(a => !a.Equals(BasePrimitivesExtensions.GetDefaultDoubleConversionValue())), "Error converting string to double array");

            mixedConversions = string.Join(",", mixedValues).TryParseDoubleArray(null, false);
            Assert.IsNotNull(mixedConversions, "Error converting string to double array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a) && !a.Equals(BasePrimitivesExtensions.GetDefaultDoubleConversionValue())), "Error converting string to double array");
            Assert.IsTrue((mixedConversions.Count() - falseConversions.Count()) == successByteValues.Count(), "Error converting string to double array");
            #endregion

            #region partial method (without number format), without default
            successConversion = string.Join(",", successValues).TryParseDoubleArray(null);
            Assert.IsNotNull(successConversion, "Error converting string to double array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to double array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to double array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to double array");

            falseConversions = string.Join(",", errorValues).TryParseDoubleArray(null);
            Assert.IsNotNull(falseConversions, "Error converting string to double array");
            Assert.IsFalse(falseConversions.Any(a => !a.Equals(BasePrimitivesExtensions.GetDefaultDoubleConversionValue())), "Error converting string to double array");

            mixedConversions = string.Join(",", mixedValues).TryParseDoubleArray(null);
            Assert.IsNotNull(mixedConversions, "Error converting string to double array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a) && !a.Equals(BasePrimitivesExtensions.GetDefaultDoubleConversionValue())), "Error converting string to double array");
            Assert.IsTrue((mixedConversions.Count() - falseConversions.Count()) == successByteValues.Count(), "Error converting string to double array");
            #endregion

            #region simple method (without number format)
            successConversion = string.Join(",", successValues).TryParseDoubleArray();
            Assert.IsNotNull(successConversion, "Error converting string to double array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to double array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to double array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to double array");

            falseConversions = string.Join(",", errorValues).TryParseDoubleArray();
            Assert.IsNotNull(falseConversions, "Error converting string to double array");
            Assert.IsFalse(falseConversions.Any(a => !a.Equals(BasePrimitivesExtensions.GetDefaultDoubleConversionValue())), "Error converting string to double array");

            mixedConversions = string.Join(",", mixedValues).TryParseDoubleArray();
            Assert.IsNotNull(mixedConversions, "Error converting string to double array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a) && !a.Equals(BasePrimitivesExtensions.GetDefaultDoubleConversionValue())), "Error converting string to double array");
            Assert.IsTrue((mixedConversions.Count() - falseConversions.Count()) == successByteValues.Count(), "Error converting string to double array");
            #endregion
        }

        /// <summary>
        /// Teste method IsValidDouble and overload
        /// </summary>
        [TestMethod]
        public void IsValidDouble()
        {
            Assert.IsFalse("".IsValidDouble());
            Assert.IsFalse("jorn".IsValidDouble());
            Assert.IsFalse("false".IsValidDouble());
            Assert.IsTrue("1".IsValidDouble());
            Assert.IsTrue("1.1".Replace(".", Culture.NumberFormat.CurrencyDecimalSeparator).IsValidDouble());
            Assert.IsTrue("4545454.4545445".Replace(".", Culture.NumberFormat.CurrencyDecimalSeparator).IsValidDouble());
            Assert.IsTrue("10".IsValidDouble());
            Assert.IsTrue("0".IsValidDouble());

            Assert.IsFalse("".IsValidDouble(NumberStyle, Culture));
            Assert.IsFalse("jorn".IsValidDouble(NumberStyle, Culture));
            Assert.IsFalse("false".IsValidDouble(NumberStyle, Culture));
            Assert.IsTrue("1".IsValidDouble(NumberStyle, Culture));
            Assert.IsTrue("1.1".Replace(".", Culture.NumberFormat.CurrencyDecimalSeparator).IsValidDouble(NumberStyle, Culture));
            Assert.IsTrue("4545454.4545445".Replace(".", Culture.NumberFormat.CurrencyDecimalSeparator).IsValidDouble(NumberStyle, Culture));
            Assert.IsTrue("10".IsValidDouble(NumberStyle, Culture));
            Assert.IsTrue("0".IsValidDouble(NumberStyle, Culture));
        }
    }
}
