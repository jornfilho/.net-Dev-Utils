using System.Globalization;
using System.Linq;
using DevUtils.PrimitivesExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.PrimitivesExtensions
{
    /// <summary>
    /// Test class FloatExtensions
    /// </summary>
    [TestClass]
    public class FloatExtensions
    {
        #region Params
        private CultureInfo Culture { get; set; }
        private string ConvertibleStringValue { get; set; }
        private double ConvertibleDoubleValue { get; set; }
        private float ConvertibleFloatValueInt { get; set; }
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
        private float DefaultValue { get; set; }
        private NumberStyles NumberStyle { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Test constructor
        /// </summary>
        public FloatExtensions()
        {
            Culture = CultureInfo.CurrentCulture;
            DefaultValue = 100f;

            ConvertibleStringValue = "200.21".Replace(".", Culture.NumberFormat.CurrencyDecimalSeparator);
            ConvertibleFloatValue = 200.21f;
            ConvertibleNullableFloatValue = 200.21f;
            ConvertibleFloatValueInt = 200f;
            ConvertibleNullableByteValue = (byte?)ConvertibleFloatValueInt;
            ConvertibleByteValue = (byte)ConvertibleFloatValueInt;
            ConvertibleNullableShortValue = (short?)ConvertibleFloatValueInt;
            ConvertibleShortValue = (short)ConvertibleFloatValueInt;
            ConvertibleNullableLongValue = (long?)ConvertibleFloatValueInt;
            ConvertibleLongValue = (long)ConvertibleFloatValueInt;
            ConvertibleNullableIntValue = (int?)ConvertibleFloatValueInt;
            ConvertibleIntValue = (int)ConvertibleFloatValueInt;
            ConvertibleNullableDecimalValue = (decimal?)ConvertibleNullableFloatValue;
            ConvertibleDecimalValue = (decimal)ConvertibleFloatValue;
            ConvertibleNullableDoubleValue = ConvertibleNullableFloatValue;
            ConvertibleDoubleValue = ConvertibleFloatValue;
            NumberStyle = NumberStyles.Float;

        } 
        #endregion

        /// <summary>
        /// Test TryParseFloat method from string value
        /// </summary>
        [TestMethod]
        public void TryParseFloat_FromString()
        {
            var invalidValue1 = double.MaxValue.ToString(CultureInfo.InvariantCulture);
            var invalidValue2 = double.MinValue.ToString(CultureInfo.InvariantCulture);

            #region full method
            var success = ConvertibleStringValue.TryParseFloat(DefaultValue,
                BasePrimitivesExtensions.GetDefaultFloatAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            var invalid1 = invalidValue1.TryParseFloat(DefaultValue,
                BasePrimitivesExtensions.GetDefaultFloatAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            var invalid2 = invalidValue2.TryParseFloat(DefaultValue,
                BasePrimitivesExtensions.GetDefaultFloatAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            Assert.AreEqual(success, ConvertibleFloatValue, "Error converting string to float");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to float");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to float");
            #endregion

            #region without allowZero param
            success = ConvertibleStringValue.TryParseFloat(DefaultValue,
                BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid1 = invalidValue1.TryParseFloat(DefaultValue,
                BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid2 = invalidValue2.TryParseFloat(DefaultValue,
                BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            Assert.AreEqual(success, ConvertibleFloatValue, "Error converting string to float");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to float");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to float");
            #endregion

            #region without allowZero and DefaultValue params
            success = ConvertibleStringValue.TryParseFloat(BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid1 = invalidValue1.TryParseFloat(BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid2 = invalidValue2.TryParseFloat(BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            Assert.AreEqual(success, ConvertibleFloatValue, "Error converting string to float");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting string to float");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting string to float");
            #endregion

            #region without number style and culture params
            success = ConvertibleStringValue.TryParseFloat(DefaultValue,
                BasePrimitivesExtensions.GetDefaultFloatAllowDefaultConversion());

            invalid1 = invalidValue1.TryParseFloat(DefaultValue,
                BasePrimitivesExtensions.GetDefaultFloatAllowDefaultConversion());

            invalid2 = invalidValue2.TryParseFloat(DefaultValue,
                BasePrimitivesExtensions.GetDefaultFloatAllowDefaultConversion());

            Assert.AreEqual(success, ConvertibleFloatValue, "Error converting string to float");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to float");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to float");
            #endregion

            #region without number style, culture and allowZero params
            success = ConvertibleStringValue.TryParseFloat(DefaultValue);
            invalid1 = invalidValue1.TryParseFloat(DefaultValue);
            invalid2 = invalidValue2.TryParseFloat(DefaultValue);

            Assert.AreEqual(success, ConvertibleFloatValue, "Error converting string to float");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to float");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to float");
            #endregion

            #region simple conversion
            success = ConvertibleStringValue.TryParseFloat();
            invalid1 = invalidValue1.TryParseFloat();
            invalid2 = invalidValue2.TryParseFloat();

            Assert.AreEqual(success, ConvertibleFloatValue, "Error converting string to float");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting string to float");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting string to float");
            #endregion
        }

        /// <summary>
        /// Test TryParseFloat method from nullable float value
        /// </summary>
        [TestMethod]
        public void TryParseFloat_NullableFloat()
        {
            #region full method
            var success = ConvertibleNullableFloatValue.TryParseFloat(DefaultValue);
            var invalid = ((float?)null).TryParseFloat(DefaultValue);

            Assert.AreEqual(success, ConvertibleFloatValue, "Error converting nullable float to float");
            Assert.AreEqual(invalid, DefaultValue, "Error converting nullable float to float");
            #endregion

            #region simple method
            success = ConvertibleNullableFloatValue.TryParseFloat();
            invalid = ((float?)null).TryParseFloat();

            Assert.AreEqual(success, ConvertibleFloatValue, "Error converting nullable float to float");
            Assert.AreEqual(invalid, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting nullable float to float");
            #endregion
        }

        /// <summary>
        /// Test TryParseFloat method from byte and nullable byte values
        /// </summary>
        [TestMethod]
        public void TryParseFloat_FromByteAndNullableByte()
        {
            #region byte - full method
            var success = ConvertibleByteValue.TryParseFloat();
            Assert.AreEqual(success, ConvertibleFloatValueInt, "Error converting byte to float");
            #endregion

            #region byte? - full method
            success = ConvertibleNullableByteValue.TryParseFloat(DefaultValue);
            var invalid1 = ((byte?)null).TryParseFloat(DefaultValue);

            Assert.AreEqual(success, ConvertibleFloatValueInt, "Error converting byte? to float");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting byte? to float");
            #endregion

            #region byte? - without DefaultValue param
            success = ConvertibleNullableByteValue.TryParseFloat();
            invalid1 = ((byte?)null).TryParseFloat();

            Assert.AreEqual(success, ConvertibleFloatValueInt, "Error converting byte? to float");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting byte? to float");
            #endregion

        }

        /// <summary>
        /// Test TryParseFloat method from short and nullable short values
        /// </summary>
        [TestMethod]
        public void TryParseFloat_FromShortAndNullableShort()
        {
            #region byte - full method
            var success = ConvertibleShortValue.TryParseFloat();
            Assert.AreEqual(success, ConvertibleFloatValueInt, "Error converting byte to float");
            #endregion

            #region byte? - full method
            success = ConvertibleNullableShortValue.TryParseFloat(DefaultValue);
            var invalid1 = ((short?)null).TryParseFloat(DefaultValue);

            Assert.AreEqual(success, ConvertibleFloatValueInt, "Error converting byte? to float");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting byte? to float");
            #endregion

            #region byte? - without DefaultValue param
            success = ConvertibleNullableShortValue.TryParseFloat();
            invalid1 = ((short?)null).TryParseFloat();

            Assert.AreEqual(success, ConvertibleFloatValueInt, "Error converting byte? to float");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting byte? to float");
            #endregion

        }

        /// <summary>
        /// Test TryParseFloat method from long and nullable long values
        /// </summary>
        [TestMethod]
        public void TryParseFloat_FromLongAndNullableLong()
        {
            #region long - full method
            var success = ConvertibleLongValue.TryParseFloat(DefaultValue);

            Assert.AreEqual(success, ConvertibleFloatValueInt, "Error converting long to float");
            #endregion

            #region long - without DefaultValue param
            success = ConvertibleLongValue.TryParseFloat();

            Assert.AreEqual(success, ConvertibleFloatValueInt, "Error converting long to float");
            #endregion

            #region long? - full method
            success = ConvertibleNullableLongValue.TryParseFloat(DefaultValue);
            var invalid1 = ((long?)null).TryParseFloat(DefaultValue);

            Assert.AreEqual(success, ConvertibleFloatValueInt, "Error converting long? to float");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting long? to float");
            #endregion

            #region long? - without DefaultValue param
            success = ConvertibleNullableLongValue.TryParseFloat();
            invalid1 = ((long?)null).TryParseFloat();

            Assert.AreEqual(success, ConvertibleFloatValueInt, "Error converting long? to float");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting long? to float");
            #endregion

        }

        /// <summary>
        /// Test TryParseFloat method from float and nullable float values
        /// </summary>
        [TestMethod]
        public void TryParseFloat_FromIntAndNullableInt()
        {
            #region float - full method
            var success = ConvertibleIntValue.TryParseFloat(DefaultValue);

            Assert.AreEqual(success, ConvertibleFloatValueInt, "Error converting float to float");
            #endregion

            #region float - without DefaultValue param
            success = ConvertibleIntValue.TryParseFloat();

            Assert.AreEqual(success, ConvertibleFloatValueInt, "Error converting float to float");
            #endregion

            #region float? - full method
            success = ConvertibleNullableIntValue.TryParseFloat(DefaultValue);
            var invalid1 = ((int?)null).TryParseFloat(DefaultValue);

            Assert.AreEqual(success, ConvertibleFloatValueInt, "Error converting float? to float");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting float? to float");
            #endregion

            #region float? - without DefaultValue param
            success = ConvertibleNullableIntValue.TryParseFloat();
            invalid1 = ((int?)null).TryParseFloat();

            Assert.AreEqual(success, ConvertibleFloatValueInt, "Error converting float? to float");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting float? to float");
            #endregion

        }

        /// <summary>
        /// Test TryParseFloat method from double and nullable double values
        /// </summary>
        [TestMethod]
        public void TryParseFloat_FromDoubleAndNullableDouble()
        {
            const double invalidValue1 = double.MaxValue;
            double? nullableInvalidValue1 = double.MaxValue;
            const double invalidValue2 = double.MinValue;
            double? nullableInvalidValue2 = double.MinValue;
            
            #region double - full method
            var success = ConvertibleDoubleValue.TryParseFloat(DefaultValue);
            var invalid1 = invalidValue1.TryParseFloat(DefaultValue);
            var invalid2 = invalidValue2.TryParseFloat(DefaultValue);

            Assert.AreEqual(success, ConvertibleFloatValue, "Error converting double to float");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting double to float");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting double to float");
            #endregion

            #region double - without DefaultValue param
            success = ConvertibleDoubleValue.TryParseFloat();
            invalid1 = invalidValue1.TryParseFloat();
            invalid2 = invalidValue2.TryParseFloat();

            Assert.AreEqual(success, ConvertibleFloatValue, "Error converting double to byte");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultFloatConversionValue(), "Error converting double to float");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultFloatConversionValue(), "Error converting double to float");
            #endregion

            #region double? - full method
            success = ConvertibleNullableDoubleValue.TryParseFloat(DefaultValue);
            invalid1 = nullableInvalidValue1.TryParseFloat(DefaultValue);
            invalid2 = nullableInvalidValue2.TryParseFloat(DefaultValue);

            Assert.AreEqual(success, ConvertibleFloatValue, "Error converting double? to float");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting double? to float");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting double? to float");
            #endregion

            #region double? - without DefaultValue param
            success = ConvertibleNullableDoubleValue.TryParseFloat();
            invalid1 = nullableInvalidValue1.TryParseFloat();
            invalid2 = nullableInvalidValue2.TryParseFloat();

            Assert.AreEqual(success, ConvertibleFloatValue, "Error converting double? to float");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultFloatConversionValue(), "Error converting double? to float");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultFloatConversionValue(), "Error converting double? to float");
            #endregion

        }

        /// <summary>
        /// Test TryParseFloat method from decimal and nullable decimal values
        /// </summary>
        [TestMethod]
        public void TryParseFloat_FromDecimalAndNullableDecimal()
        {
            #region float - full method
            var success = ConvertibleDecimalValue.TryParseFloat(DefaultValue);

            Assert.AreEqual(success, ConvertibleFloatValue, "Error converting decimal to float");
            #endregion

            #region float - without DefaultValue param
            success = ConvertibleDecimalValue.TryParseFloat();

            Assert.AreEqual(success, ConvertibleFloatValue, "Error converting decimal to float");
            #endregion

            #region float? - full method
            success = ConvertibleNullableDecimalValue.TryParseFloat(DefaultValue);
            var invalid1 = ((decimal?)null).TryParseFloat(DefaultValue);

            Assert.AreEqual(success, ConvertibleFloatValue, "Error converting decimal? to float");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting decimal? to float");
            #endregion

            #region float? - without DefaultValue param
            success = ConvertibleNullableDecimalValue.TryParseFloat();
            invalid1 = ((decimal?)null).TryParseFloat();

            Assert.AreEqual(success, ConvertibleFloatValue, "Error converting decimal? to float");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultFloatConversionValue(), "Error converting decimal? to float");
            #endregion

        }

        /// <summary>
        /// Teste method TryParseFloatArray and overload
        /// </summary>
        [TestMethod]
        public void TryParseFloatArray()
        {
            const string successValue1 = "10";
            const string successValue2 = "20";
            var errorValue1 = double.MaxValue.ToString(CultureInfo.InvariantCulture);
            var errorValue2 = double.MinValue.ToString(CultureInfo.InvariantCulture);

            var successByteValues = new[] { successValue1.TryParseFloat(), successValue2.TryParseFloat() };
            var successValues = new[] { successValue1, successValue2 };
            var errorValues = new[] { errorValue1, errorValue2 };
            var mixedValues = new[] { successValue1, successValue2, errorValue1, errorValue2 };

            #region full method (with number format), without default, dont return defult conversion
            var successConversion = string.Join(",", successValues).TryParseFloatArray(null, false,
                BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(successConversion, "Error converting string to float array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to float array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to float array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to float array");

            var falseConversions = string.Join(",", errorValues).TryParseFloatArray(null, false,
                BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(falseConversions, "Error converting string to float array");
            Assert.IsFalse(falseConversions.Any(), "Error converting string to float array");

            var mixedConversions = string.Join(",", mixedValues).TryParseFloatArray(null, false,
                BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(mixedConversions, "Error converting string to float array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a)), "Error converting string to float array");
            Assert.IsTrue(mixedConversions.Count() == successByteValues.Count(), "Error converting string to float array");
            #endregion

            #region partial method (with number format), without default
            successConversion = string.Join(",", successValues).TryParseFloatArray(null,
                BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(successConversion, "Error converting string to float array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to float array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to float array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to float array");

            falseConversions = string.Join(",", errorValues).TryParseFloatArray(null,
                BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(falseConversions, "Error converting string to float array");
            Assert.IsFalse(falseConversions.Any(a=>!a.Equals(BasePrimitivesExtensions.GetDefaultFloatConversionValue())), "Error converting string to float array");

            mixedConversions = string.Join(",", mixedValues).TryParseFloatArray(null,
                BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(mixedConversions, "Error converting string to float array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a) && !a.Equals(BasePrimitivesExtensions.GetDefaultFloatConversionValue())), "Error converting string to float array");
            Assert.IsTrue((mixedConversions.Count() - falseConversions.Count()) == successByteValues.Count(), "Error converting string to float array");
            #endregion

            #region simple method (with number format)
            successConversion = string.Join(",", successValues).TryParseFloatArray(
                BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(successConversion, "Error converting string to float array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to float array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to float array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to float array");

            falseConversions = string.Join(",", errorValues).TryParseFloatArray(
                BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(falseConversions, "Error converting string to float array");
            Assert.IsFalse(falseConversions.Any(a => !a.Equals(BasePrimitivesExtensions.GetDefaultFloatConversionValue())), "Error converting string to float array");

            mixedConversions = string.Join(",", mixedValues).TryParseFloatArray(
                BasePrimitivesExtensions.GetDefaultFloatNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(mixedConversions, "Error converting string to float array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a) && !a.Equals(BasePrimitivesExtensions.GetDefaultFloatConversionValue())), "Error converting string to float array");
            Assert.IsTrue((mixedConversions.Count() - falseConversions.Count()) == successByteValues.Count(), "Error converting string to float array");
            #endregion

            #region full method (without number format), without default, dont return defult conversion
            successConversion = string.Join(",", successValues).TryParseFloatArray(null, false);
            Assert.IsNotNull(successConversion, "Error converting string to float array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to float array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to float array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to float array");

            falseConversions = string.Join(",", errorValues).TryParseFloatArray(null, false);
            Assert.IsNotNull(falseConversions, "Error converting string to float array");
            Assert.IsFalse(falseConversions.Any(a => !a.Equals(BasePrimitivesExtensions.GetDefaultFloatConversionValue())), "Error converting string to float array");

            mixedConversions = string.Join(",", mixedValues).TryParseFloatArray(null, false);
            Assert.IsNotNull(mixedConversions, "Error converting string to float array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a) && !a.Equals(BasePrimitivesExtensions.GetDefaultFloatConversionValue())), "Error converting string to float array");
            Assert.IsTrue((mixedConversions.Count() - falseConversions.Count()) == successByteValues.Count(), "Error converting string to float array");
            #endregion

            #region partial method (without number format), without default
            successConversion = string.Join(",", successValues).TryParseFloatArray(null);
            Assert.IsNotNull(successConversion, "Error converting string to float array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to float array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to float array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to float array");

            falseConversions = string.Join(",", errorValues).TryParseFloatArray(null);
            Assert.IsNotNull(falseConversions, "Error converting string to float array");
            Assert.IsFalse(falseConversions.Any(a => !a.Equals(BasePrimitivesExtensions.GetDefaultFloatConversionValue())), "Error converting string to float array");

            mixedConversions = string.Join(",", mixedValues).TryParseFloatArray(null);
            Assert.IsNotNull(mixedConversions, "Error converting string to float array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a) && !a.Equals(BasePrimitivesExtensions.GetDefaultFloatConversionValue())), "Error converting string to float array");
            Assert.IsTrue((mixedConversions.Count() - falseConversions.Count()) == successByteValues.Count(), "Error converting string to float array");
            #endregion

            #region simple method (without number format)
            successConversion = string.Join(",", successValues).TryParseFloatArray();
            Assert.IsNotNull(successConversion, "Error converting string to float array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to float array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to float array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to float array");

            falseConversions = string.Join(",", errorValues).TryParseFloatArray();
            Assert.IsNotNull(falseConversions, "Error converting string to float array");
            Assert.IsFalse(falseConversions.Any(a => !a.Equals(BasePrimitivesExtensions.GetDefaultFloatConversionValue())), "Error converting string to float array");

            mixedConversions = string.Join(",", mixedValues).TryParseFloatArray();
            Assert.IsNotNull(mixedConversions, "Error converting string to float array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a) && !a.Equals(BasePrimitivesExtensions.GetDefaultFloatConversionValue())), "Error converting string to float array");
            Assert.IsTrue((mixedConversions.Count() - falseConversions.Count()) == successByteValues.Count(), "Error converting string to float array");
            #endregion
        }

        /// <summary>
        /// Teste method IsValidFloat and overload
        /// </summary>
        [TestMethod]
        public void IsValidFloat()
        {
            Assert.IsFalse(double.MaxValue.ToString(CultureInfo.InvariantCulture).IsValidFloat());
            Assert.IsFalse(double.MinValue.ToString(CultureInfo.InvariantCulture).IsValidFloat());
            Assert.IsFalse("".IsValidFloat());
            Assert.IsFalse("jorn".IsValidFloat());
            Assert.IsFalse("false".IsValidFloat());
            Assert.IsTrue("1".IsValidFloat());
            Assert.IsTrue("1.1".Replace(".", Culture.NumberFormat.CurrencyDecimalSeparator).IsValidFloat());
            Assert.IsTrue("4545454.4545445".Replace(".", Culture.NumberFormat.CurrencyDecimalSeparator).IsValidFloat());
            Assert.IsTrue("10".IsValidFloat());
            Assert.IsTrue("0".IsValidFloat());

            Assert.IsFalse("".IsValidFloat(NumberStyle, Culture));
            Assert.IsFalse("jorn".IsValidFloat(NumberStyle, Culture));
            Assert.IsFalse("false".IsValidFloat(NumberStyle, Culture));
            Assert.IsTrue("1".IsValidFloat(NumberStyle, Culture));
            Assert.IsTrue("1.1".Replace(".", Culture.NumberFormat.CurrencyDecimalSeparator).IsValidFloat(NumberStyle, Culture));
            Assert.IsTrue("4545454.4545445".Replace(".", Culture.NumberFormat.CurrencyDecimalSeparator).IsValidFloat(NumberStyle, Culture));
            Assert.IsTrue("10".IsValidFloat(NumberStyle, Culture));
            Assert.IsTrue("0".IsValidFloat(NumberStyle, Culture));
        }
    }
}
