using System.Globalization;
using System.Linq;
using DevUtils.PrimitivesExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.PrimitivesExtensions
{
    /// <summary>
    /// Test class DecimalExtensions
    /// </summary>
    [TestClass]
    public class DecimalExtensions
    {
        #region Params
        private CultureInfo Culture { get; set; }
        private string ConvertibleStringValue { get; set; }
        private decimal ConvertibleDecimalValue { get; set; }
        private decimal ConvertibleDecimalValueInt { get; set; }
        private decimal? ConvertibleNullableDecimalValue { get; set; }
        private byte? ConvertibleNullableByteValue { get; set; }
        private byte ConvertibleByteValue { get; set; }
        private short? ConvertibleNullableShortValue { get; set; }
        private short ConvertibleShortValue { get; set; }
        private long? ConvertibleNullableLongValue { get; set; }
        private long ConvertibleLongValue { get; set; }
        private int? ConvertibleNullableIntValue { get; set; }
        private int ConvertibleIntValue { get; set; }
        private double? ConvertibleNullableDoubleValue { get; set; }
        private double ConvertibleDoubleValue { get; set; }
        private float? ConvertibleNullableFloatValue { get; set; }
        private float ConvertibleFloatValue { get; set; }
        private decimal DefaultValue { get; set; }
        private NumberStyles NumberStyle { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Test constructor
        /// </summary>
        public DecimalExtensions()
        {
            Culture = CultureInfo.CurrentCulture;
            DefaultValue = 100;

            ConvertibleStringValue = "200.21".Replace(".", Culture.NumberFormat.CurrencyDecimalSeparator);
            ConvertibleDecimalValue = (decimal)200.21;
            ConvertibleNullableDecimalValue = (decimal?)200.21;
            ConvertibleDecimalValueInt = 200;
            ConvertibleNullableByteValue = (byte?)ConvertibleDecimalValueInt;
            ConvertibleByteValue = (byte)ConvertibleDecimalValueInt;
            ConvertibleNullableShortValue = (short?)ConvertibleDecimalValueInt;
            ConvertibleShortValue = (short)ConvertibleDecimalValueInt;
            ConvertibleNullableLongValue = (long?)ConvertibleDecimalValueInt;
            ConvertibleLongValue = (long)ConvertibleDecimalValueInt;
            ConvertibleNullableIntValue = (int?)ConvertibleDecimalValueInt;
            ConvertibleIntValue = (int)ConvertibleDecimalValueInt;
            ConvertibleNullableDoubleValue = (double?)ConvertibleNullableDecimalValue;
            ConvertibleDoubleValue = (double)ConvertibleDecimalValue;
            ConvertibleNullableFloatValue = (float?)ConvertibleNullableDecimalValue;
            ConvertibleFloatValue = (float)ConvertibleDecimalValue;
            NumberStyle = NumberStyles.Float;
            
        } 
        #endregion
        
        /// <summary>
        /// Test TryParseDecimal method from string value
        /// </summary>
        [TestMethod]
        public void TryParseDecimal_FromString()
        {
            var invalidValue1 = double.MaxValue.ToString(CultureInfo.InvariantCulture);
            var invalidValue2 = double.MinValue.ToString(CultureInfo.InvariantCulture);

            #region full method
            var success = ConvertibleStringValue.TryParseDecimal(DefaultValue,
                BasePrimitivesExtensions.GetDefaultDecimalAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            var invalid1 = invalidValue1.TryParseDecimal(DefaultValue,
                BasePrimitivesExtensions.GetDefaultDecimalAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            var invalid2 = invalidValue2.TryParseDecimal(DefaultValue,
                BasePrimitivesExtensions.GetDefaultDecimalAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            Assert.AreEqual(success, ConvertibleDecimalValue, "Error converting string to decimal");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to decimal");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to decimal");
            #endregion

            #region without allowZero param
            success = ConvertibleStringValue.TryParseDecimal(DefaultValue,
                BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid1 = invalidValue1.TryParseDecimal(DefaultValue,
                BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid2 = invalidValue2.TryParseDecimal(DefaultValue,
                BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            Assert.AreEqual(success, ConvertibleDecimalValue, "Error converting string to decimal");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to decimal");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to decimal");
            #endregion

            #region without allowZero and DefaultValue params
            success = ConvertibleStringValue.TryParseDecimal(BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid1 = invalidValue1.TryParseDecimal(BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid2 = invalidValue2.TryParseDecimal(BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            Assert.AreEqual(success, ConvertibleDecimalValue, "Error converting string to decimal");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting string to decimal");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting string to decimal");
            #endregion

            #region without number style and culture params
            success = ConvertibleStringValue.TryParseDecimal(DefaultValue,
                BasePrimitivesExtensions.GetDefaultDecimalAllowDefaultConversion());

            invalid1 = invalidValue1.TryParseDecimal(DefaultValue,
                BasePrimitivesExtensions.GetDefaultDecimalAllowDefaultConversion());

            invalid2 = invalidValue2.TryParseDecimal(DefaultValue,
                BasePrimitivesExtensions.GetDefaultDecimalAllowDefaultConversion());

            Assert.AreEqual(success, ConvertibleDecimalValue, "Error converting string to decimal");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to decimal");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to decimal");
            #endregion

            #region without number style, culture and allowZero params
            success = ConvertibleStringValue.TryParseDecimal(DefaultValue);
            invalid1 = invalidValue1.TryParseDecimal(DefaultValue);
            invalid2 = invalidValue2.TryParseDecimal(DefaultValue);

            Assert.AreEqual(success, ConvertibleDecimalValue, "Error converting string to decimal");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to decimal");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to decimal");
            #endregion

            #region simple conversion
            success = ConvertibleStringValue.TryParseDecimal();
            invalid1 = invalidValue1.TryParseDecimal();
            invalid2 = invalidValue2.TryParseDecimal();

            Assert.AreEqual(success, ConvertibleDecimalValue, "Error converting string to decimal");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting string to decimal");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting string to decimal");
            #endregion
        }

        /// <summary>
        /// Test TryParseDecimal method from nullable decimal value
        /// </summary>
        [TestMethod]
        public void TryParseDecimal_NullableDecimal()
        {
            #region full method
            var success = ConvertibleNullableDecimalValue.TryParseDecimal(DefaultValue);
            var invalid = ((decimal?)null).TryParseDecimal(DefaultValue);

            Assert.AreEqual(success, ConvertibleDecimalValue, "Error converting nullable decimal to decimal");
            Assert.AreEqual(invalid, DefaultValue, "Error converting nullable decimal to decimal");
            #endregion

            #region simple method
            success = ConvertibleNullableDecimalValue.TryParseDecimal();
            invalid = ((decimal?)null).TryParseDecimal();

            Assert.AreEqual(success, ConvertibleDecimalValue, "Error converting nullable decimal to decimal");
            Assert.AreEqual(invalid, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting nullable decimal to decimal");
            #endregion
        }

        /// <summary>
        /// Test TryParseDecimal method from byte and nullable byte values
        /// </summary>
        [TestMethod]
        public void TryParseDecimal_FromByteAndNullableByte()
        {
            #region byte - full method
            var success = ConvertibleByteValue.TryParseDecimal();
            Assert.AreEqual(success, ConvertibleDecimalValueInt, "Error converting byte to decimal");
            #endregion

            #region byte? - full method
            success = ConvertibleNullableByteValue.TryParseDecimal(DefaultValue);
            var invalid1 = ((byte?)null).TryParseDecimal(DefaultValue);

            Assert.AreEqual(success, ConvertibleDecimalValueInt, "Error converting byte? to decimal");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting byte? to decimal");
            #endregion

            #region byte? - without DefaultValue param
            success = ConvertibleNullableByteValue.TryParseDecimal();
            invalid1 = ((byte?)null).TryParseDecimal();

            Assert.AreEqual(success, ConvertibleDecimalValueInt, "Error converting byte? to decimal");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting byte? to decimal");
            #endregion

        }

        /// <summary>
        /// Test TryParseDecimal method from short and nullable short values
        /// </summary>
        [TestMethod]
        public void TryParseDecimal_FromShortAndNullableShort()
        {
            #region byte - full method
            var success = ConvertibleShortValue.TryParseDecimal();
            Assert.AreEqual(success, ConvertibleDecimalValueInt, "Error converting byte to decimal");
            #endregion

            #region byte? - full method
            success = ConvertibleNullableShortValue.TryParseDecimal(DefaultValue);
            var invalid1 = ((short?)null).TryParseDecimal(DefaultValue);

            Assert.AreEqual(success, ConvertibleDecimalValueInt, "Error converting byte? to decimal");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting byte? to decimal");
            #endregion

            #region byte? - without DefaultValue param
            success = ConvertibleNullableShortValue.TryParseDecimal();
            invalid1 = ((short?)null).TryParseDecimal();

            Assert.AreEqual(success, ConvertibleDecimalValueInt, "Error converting byte? to decimal");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting byte? to decimal");
            #endregion

        }

        /// <summary>
        /// Test TryParseDecimal method from long and nullable long values
        /// </summary>
        [TestMethod]
        public void TryParseDecimal_FromLongAndNullableLong()
        {
            #region long - full method
            var success = ConvertibleLongValue.TryParseDecimal(DefaultValue);

            Assert.AreEqual(success, ConvertibleDecimalValueInt, "Error converting long to decimal");
            #endregion

            #region long - without DefaultValue param
            success = ConvertibleLongValue.TryParseDecimal();

            Assert.AreEqual(success, ConvertibleDecimalValueInt, "Error converting long to decimal");
            #endregion

            #region long? - full method
            success = ConvertibleNullableLongValue.TryParseDecimal(DefaultValue);
            var invalid1 = ((long?)null).TryParseDecimal(DefaultValue);

            Assert.AreEqual(success, ConvertibleDecimalValueInt, "Error converting long? to decimal");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting long? to decimal");
            #endregion

            #region long? - without DefaultValue param
            success = ConvertibleNullableLongValue.TryParseDecimal();
            invalid1 = ((long?)null).TryParseDecimal();

            Assert.AreEqual(success, ConvertibleDecimalValueInt, "Error converting long? to decimal");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting long? to decimal");
            #endregion

        }

        /// <summary>
        /// Test TryParseDecimal method from decimal and nullable decimal values
        /// </summary>
        [TestMethod]
        public void TryParseDecimal_FromIntAndNullableInt()
        {
            #region decimal - full method
            var success = ConvertibleIntValue.TryParseDecimal(DefaultValue);

            Assert.AreEqual(success, ConvertibleDecimalValueInt, "Error converting decimal to decimal");
            #endregion

            #region decimal - without DefaultValue param
            success = ConvertibleIntValue.TryParseDecimal();

            Assert.AreEqual(success, ConvertibleDecimalValueInt, "Error converting decimal to decimal");
            #endregion

            #region decimal? - full method
            success = ConvertibleNullableIntValue.TryParseDecimal(DefaultValue);
            var invalid1 = ((int?)null).TryParseDecimal(DefaultValue);

            Assert.AreEqual(success, ConvertibleDecimalValueInt, "Error converting decimal? to decimal");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting decimal? to decimal");
            #endregion

            #region decimal? - without DefaultValue param
            success = ConvertibleNullableIntValue.TryParseDecimal();
            invalid1 = ((int?)null).TryParseDecimal();

            Assert.AreEqual(success, ConvertibleDecimalValueInt, "Error converting decimal? to decimal");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting decimal? to decimal");
            #endregion

        }

        /// <summary>
        /// Test TryParseDecimal method from double and nullable double values
        /// </summary>
        [TestMethod]
        public void TryParseDecimal_FromDoubleAndNullableDouble()
        {
            const double invalidValue1 = double.MaxValue;
            double? nullableInvalidValue1 = double.MaxValue;
            const double invalidValue2 = double.MinValue;
            double? nullableInvalidValue2 = double.MinValue;

            #region double - full method
            var success = ConvertibleDoubleValue.TryParseDecimal(DefaultValue);
            var invalid1 = invalidValue1.TryParseDecimal(DefaultValue);
            var invalid2 = invalidValue2.TryParseDecimal(DefaultValue);

            Assert.AreEqual(success, ConvertibleDecimalValue, "Error converting double to decimal");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting double to decimal");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting double to decimal");
            #endregion

            #region double - without DefaultValue param
            success = ConvertibleDoubleValue.TryParseDecimal();
            invalid1 = invalidValue1.TryParseDecimal();
            invalid2 = invalidValue2.TryParseDecimal();

            Assert.AreEqual(success, ConvertibleDecimalValue, "Error converting double to byte");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultDecimalConversionValue(), "Error converting double to decimal");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultDecimalConversionValue(), "Error converting double to decimal");
            #endregion

            #region double? - full method
            success = ConvertibleNullableDoubleValue.TryParseDecimal(DefaultValue);
            invalid1 = nullableInvalidValue1.TryParseDecimal(DefaultValue);
            invalid2 = nullableInvalidValue2.TryParseDecimal(DefaultValue);

            Assert.AreEqual(success, ConvertibleDecimalValue, "Error converting double? to decimal");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting double? to decimal");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting double? to decimal");
            #endregion

            #region double? - without DefaultValue param
            success = ConvertibleNullableDoubleValue.TryParseDecimal();
            invalid1 = nullableInvalidValue1.TryParseDecimal();
            invalid2 = nullableInvalidValue2.TryParseDecimal();

            Assert.AreEqual(success, ConvertibleDecimalValue, "Error converting double? to decimal");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultDecimalConversionValue(), "Error converting double? to decimal");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultDecimalConversionValue(), "Error converting double? to decimal");
            #endregion

        }

        /// <summary>
        /// Test TryParseDecimal method from float and nullable float values
        /// </summary>
        [TestMethod]
        public void TryParseDecimal_FromFloatAndNullableFloat()
        {
            const float invalidValue1 = float.MaxValue;
            float? nullableInvalidValue1 = float.MaxValue;
            const float invalidValue2 = float.MinValue;
            float? nullableInvalidValue2 = float.MinValue;
            
            #region float - full method
            var success = ConvertibleFloatValue.TryParseDecimal(DefaultValue);
            var invalid1 = invalidValue1.TryParseDecimal(DefaultValue);
            var invalid2 = invalidValue2.TryParseDecimal(DefaultValue);

            Assert.AreEqual(success, ConvertibleDecimalValue, "Error converting float to decimal");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting float to decimal");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting float to decimal");
            #endregion

            #region float - without DefaultValue param
            success = ConvertibleFloatValue.TryParseDecimal();
            invalid1 = invalidValue1.TryParseDecimal();
            invalid2 = invalidValue2.TryParseDecimal();

            Assert.AreEqual(success, ConvertibleDecimalValue, "Error converting float to byte");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultDecimalConversionValue(), "Error converting float to decimal");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultDecimalConversionValue(), "Error converting float to decimal");
            #endregion

            #region float? - full method
            success = ConvertibleNullableFloatValue.TryParseDecimal(DefaultValue);
            invalid1 = nullableInvalidValue1.TryParseDecimal(DefaultValue);
            invalid2 = nullableInvalidValue2.TryParseDecimal(DefaultValue);

            Assert.AreEqual(success, ConvertibleDecimalValue, "Error converting float? to decimal");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting float? to decimal");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting float? to decimal");
            #endregion

            #region float? - without DefaultValue param
            success = ConvertibleNullableFloatValue.TryParseDecimal();
            invalid1 = nullableInvalidValue1.TryParseDecimal();
            invalid2 = nullableInvalidValue2.TryParseDecimal();

            Assert.AreEqual(success, ConvertibleDecimalValue, "Error converting float? to decimal");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultDecimalConversionValue(), "Error converting float? to decimal");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultDecimalConversionValue(), "Error converting float? to decimal");
            #endregion

        }

        /// <summary>
        /// Teste method TryParseDecimalArray and overload
        /// </summary>
        [TestMethod]
        public void TryParseDecimalArray()
        {
            const string successValue1 = "10";
            const string successValue2 = "20";
            var errorValue1 = double.MaxValue.ToString(CultureInfo.InvariantCulture);
            var errorValue2 = double.MinValue.ToString(CultureInfo.InvariantCulture);

            var successByteValues = new[] { successValue1.TryParseDecimal(), successValue2.TryParseDecimal() };
            var successValues = new[] { successValue1, successValue2 };
            var errorValues = new[] { errorValue1, errorValue2 };
            var mixedValues = new[] { successValue1, successValue2, errorValue1, errorValue2 };

            #region full method (with number format), without default, dont return defult conversion
            var successConversion = string.Join(",", successValues).TryParseDecimalArray(null, false,
                BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(successConversion, "Error converting string to decimal array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to decimal array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to decimal array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to decimal array");

            var falseConversions = string.Join(",", errorValues).TryParseDecimalArray(null, false,
                BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(falseConversions, "Error converting string to decimal array");
            Assert.IsFalse(falseConversions.Any(), "Error converting string to decimal array");

            var mixedConversions = string.Join(",", mixedValues).TryParseDecimalArray(null, false,
                BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(mixedConversions, "Error converting string to decimal array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a)), "Error converting string to decimal array");
            Assert.IsTrue(mixedConversions.Count() == successByteValues.Count(), "Error converting string to decimal array");
            #endregion

            #region partial method (with number format), without default
            successConversion = string.Join(",", successValues).TryParseDecimalArray(null,
                BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(successConversion, "Error converting string to decimal array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to decimal array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to decimal array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to decimal array");

            falseConversions = string.Join(",", errorValues).TryParseDecimalArray(null,
                BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(falseConversions, "Error converting string to decimal array");
            Assert.IsFalse(falseConversions.Any(), "Error converting string to decimal array");

            mixedConversions = string.Join(",", mixedValues).TryParseDecimalArray(null,
                BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(mixedConversions, "Error converting string to decimal array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a)), "Error converting string to decimal array");
            Assert.IsTrue(mixedConversions.Count() == successByteValues.Count(), "Error converting string to decimal array");
            #endregion

            #region simple method (with number format)
            successConversion = string.Join(",", successValues).TryParseDecimalArray(
                BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(successConversion, "Error converting string to decimal array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to decimal array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to decimal array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to decimal array");

            falseConversions = string.Join(",", errorValues).TryParseDecimalArray(
                BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(falseConversions, "Error converting string to decimal array");
            Assert.IsFalse(falseConversions.Any(), "Error converting string to decimal array");

            mixedConversions = string.Join(",", mixedValues).TryParseDecimalArray(
                BasePrimitivesExtensions.GetDefaultDecimalNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(mixedConversions, "Error converting string to decimal array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a)), "Error converting string to decimal array");
            Assert.IsTrue(mixedConversions.Count() == successByteValues.Count(), "Error converting string to decimal array");
            #endregion

            #region full method (without number format), without default, dont return defult conversion
            successConversion = string.Join(",", successValues).TryParseDecimalArray(null, false);
            Assert.IsNotNull(successConversion, "Error converting string to decimal array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to decimal array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to decimal array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to decimal array");

            falseConversions = string.Join(",", errorValues).TryParseDecimalArray(null, false);
            Assert.IsNotNull(falseConversions, "Error converting string to decimal array");
            Assert.IsFalse(falseConversions.Any(), "Error converting string to decimal array");

            mixedConversions = string.Join(",", mixedValues).TryParseDecimalArray(null, false);
            Assert.IsNotNull(mixedConversions, "Error converting string to decimal array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a)), "Error converting string to decimal array");
            Assert.IsTrue(mixedConversions.Count() == successByteValues.Count(), "Error converting string to decimal array");
            #endregion

            #region partial method (without number format), without default
            successConversion = string.Join(",", successValues).TryParseDecimalArray(null);
            Assert.IsNotNull(successConversion, "Error converting string to decimal array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to decimal array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to decimal array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to decimal array");

            falseConversions = string.Join(",", errorValues).TryParseDecimalArray(null);
            Assert.IsNotNull(falseConversions, "Error converting string to decimal array");
            Assert.IsFalse(falseConversions.Any(), "Error converting string to decimal array");

            mixedConversions = string.Join(",", mixedValues).TryParseDecimalArray(null);
            Assert.IsNotNull(mixedConversions, "Error converting string to decimal array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a)), "Error converting string to decimal array");
            Assert.IsTrue(mixedConversions.Count() == successByteValues.Count(), "Error converting string to decimal array");
            #endregion

            #region simple method (without number format)
            successConversion = string.Join(",", successValues).TryParseDecimalArray();
            Assert.IsNotNull(successConversion, "Error converting string to decimal array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to decimal array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to decimal array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to decimal array");

            falseConversions = string.Join(",", errorValues).TryParseDecimalArray();
            Assert.IsNotNull(falseConversions, "Error converting string to decimal array");
            Assert.IsFalse(falseConversions.Any(), "Error converting string to decimal array");

            mixedConversions = string.Join(",", mixedValues).TryParseDecimalArray();
            Assert.IsNotNull(mixedConversions, "Error converting string to decimal array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a)), "Error converting string to decimal array");
            Assert.IsTrue(mixedConversions.Count() == successByteValues.Count(), "Error converting string to decimal array");
            #endregion
        }

        /// <summary>
        /// Teste method IsValidDecimal and overload
        /// </summary>
        [TestMethod]
        public void IsValidDecimal()
        {
            Assert.IsFalse(double.MaxValue.ToString(CultureInfo.InvariantCulture).IsValidDecimal());
            Assert.IsFalse(double.MinValue.ToString(CultureInfo.InvariantCulture).IsValidDecimal());
            Assert.IsFalse("".IsValidDecimal());
            Assert.IsFalse("jorn".IsValidDecimal());
            Assert.IsFalse("false".IsValidDecimal());
            Assert.IsTrue("1".IsValidDecimal());
            Assert.IsTrue("1,1".IsValidDecimal());
            Assert.IsTrue("4545454.4545445".Replace(".", Culture.NumberFormat.CurrencyDecimalSeparator).IsValidDecimal());
            Assert.IsTrue("10".IsValidDecimal());
            Assert.IsTrue("0".IsValidDecimal());

            Assert.IsFalse(double.MaxValue.ToString(CultureInfo.InvariantCulture).IsValidDecimal(NumberStyle, Culture));
            Assert.IsFalse(double.MinValue.ToString(CultureInfo.InvariantCulture).IsValidDecimal(NumberStyle, Culture));
            Assert.IsFalse("".IsValidDecimal(NumberStyle, Culture));
            Assert.IsFalse("jorn".IsValidDecimal(NumberStyle, Culture));
            Assert.IsFalse("false".IsValidDecimal(NumberStyle, Culture));
            Assert.IsTrue("1".IsValidDecimal(NumberStyle, Culture));
            Assert.IsTrue("1,1".IsValidDecimal(NumberStyle, Culture));
            Assert.IsTrue("4545454.4545445".Replace(".", Culture.NumberFormat.CurrencyDecimalSeparator).IsValidDecimal(NumberStyle, Culture));
            Assert.IsTrue("10".IsValidDecimal(NumberStyle, Culture));
            Assert.IsTrue("0".IsValidDecimal(NumberStyle, Culture));
        }
    }
}
