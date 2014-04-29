using System.Globalization;
using System.Linq;
using DevUtils.PrimitivesExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.PrimitivesExtensions
{
    /// <summary>
    /// Test class LongExtensions
    /// </summary>
    [TestClass]
    public class LongExtensions
    {
        #region Params
        private CultureInfo Culture { get; set; }
        private string ConvertibleStringValue { get; set; }
        private decimal ConvertibleDecimalValue { get; set; }
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
        private long DefaultValue { get; set; }
        private NumberStyles NumberStyle { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Test constructor
        /// </summary>
        public LongExtensions()
        {
            Culture = CultureInfo.CurrentCulture;
            DefaultValue = 100;

            ConvertibleStringValue = "200";
            ConvertibleLongValue = 200;
            ConvertibleNullableLongValue = 200;
            ConvertibleNullableDecimalValue = ConvertibleNullableLongValue;
            ConvertibleDecimalValue = ConvertibleLongValue;
            ConvertibleNullableShortValue = (short?)ConvertibleNullableLongValue;
            ConvertibleShortValue = (short)ConvertibleLongValue;
            ConvertibleNullableIntValue = (int?)ConvertibleNullableLongValue;
            ConvertibleIntValue = (int)ConvertibleLongValue;
            ConvertibleNullableByteValue = (byte?)ConvertibleNullableLongValue;
            ConvertibleByteValue = (byte)ConvertibleLongValue;
            ConvertibleNullableDoubleValue = ConvertibleNullableLongValue + 0.2d;
            ConvertibleDoubleValue = ConvertibleLongValue + 0.2d;
            ConvertibleNullableFloatValue = ConvertibleNullableLongValue + 0.2f;
            ConvertibleFloatValue = ConvertibleLongValue + 0.2f;
            NumberStyle = NumberStyles.Integer;
            
        } 
        #endregion

        /// <summary>
        /// Test TryParseLong method from string value
        /// </summary>
        [TestMethod]
        public void TryParseLong_FromString()
        {
            var invalidValue1 = double.MaxValue.ToString(CultureInfo.InvariantCulture);
            var invalidValue2 = double.MinValue.ToString(CultureInfo.InvariantCulture);
            
            #region full method
            var success = ConvertibleStringValue.TryParseLong(DefaultValue,
                BasePrimitivesExtensions.GetDefaultIntAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            var invalid1 = invalidValue1.TryParseLong(DefaultValue,
                BasePrimitivesExtensions.GetDefaultIntAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            var invalid2 = invalidValue2.TryParseLong(DefaultValue,
                BasePrimitivesExtensions.GetDefaultIntAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            Assert.AreEqual(success, ConvertibleLongValue, "Error converting string to long");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to long");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to long");
            #endregion

            #region without allowZero param
            success = ConvertibleStringValue.TryParseLong(DefaultValue,
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid1 = invalidValue1.TryParseLong(DefaultValue,
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid2 = invalidValue2.TryParseLong(DefaultValue,
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            Assert.AreEqual(success, ConvertibleLongValue, "Error converting string to long");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to long");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to long");
            #endregion

            #region without allowZero and DefaultValue params
            success = ConvertibleStringValue.TryParseLong(BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid1 = invalidValue1.TryParseLong(BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid2 = invalidValue2.TryParseLong(BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            Assert.AreEqual(success, ConvertibleLongValue, "Error converting string to long");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting string to long");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting string to long");
            #endregion

            #region without number style and culture params
            success = ConvertibleStringValue.TryParseLong(DefaultValue,
                BasePrimitivesExtensions.GetDefaultIntAllowDefaultConversion());

            invalid1 = invalidValue1.TryParseLong(DefaultValue,
                BasePrimitivesExtensions.GetDefaultIntAllowDefaultConversion());

            invalid2 = invalidValue2.TryParseLong(DefaultValue,
                BasePrimitivesExtensions.GetDefaultIntAllowDefaultConversion());

            Assert.AreEqual(success, ConvertibleLongValue, "Error converting string to long");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to long");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to long");
            #endregion

            #region without number style, culture and allowZero params
            success = ConvertibleStringValue.TryParseLong(DefaultValue);
            invalid1 = invalidValue1.TryParseLong(DefaultValue);
            invalid2 = invalidValue2.TryParseLong(DefaultValue);

            Assert.AreEqual(success, ConvertibleLongValue, "Error converting string to long");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to long");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to long");
            #endregion

            #region simple conversion
            success = ConvertibleStringValue.TryParseLong();
            invalid1 = invalidValue1.TryParseLong();
            invalid2 = invalidValue2.TryParseLong();

            Assert.AreEqual(success, ConvertibleLongValue, "Error converting string to long");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting string to long");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting string to long");
            #endregion
        }

        /// <summary>
        /// Test TryParseLong method from nullable long value
        /// </summary>
        [TestMethod]
        public void TryParseLong_NullableLong()
        {
            #region full method
            var success = ConvertibleNullableLongValue.TryParseLong(DefaultValue);
            var invalid = ((long?)null).TryParseLong(DefaultValue);

            Assert.AreEqual(success, ConvertibleLongValue, "Error converting nullable long to long");
            Assert.AreEqual(invalid, DefaultValue, "Error converting nullable long to long");
            #endregion

            #region simple method
            success = ConvertibleNullableLongValue.TryParseLong();
            invalid = ((long?)null).TryParseLong();

            Assert.AreEqual(success, ConvertibleLongValue, "Error converting nullable long to long");
            Assert.AreEqual(invalid, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting nullable long to long");
            #endregion
        }

        /// <summary>
        /// Test TryParseLong method from byte and nullable byte values
        /// </summary>
        [TestMethod]
        public void TryParseLong_FromByteAndNullableByte()
        {
            #region byte - full method
            var success = ConvertibleByteValue.TryParseLong();
            Assert.AreEqual(success, ConvertibleLongValue, "Error converting byte to long");
            #endregion

            #region byte? - full method
            success = ConvertibleNullableByteValue.TryParseLong(DefaultValue);
            var invalid1 = ((byte?)null).TryParseLong(DefaultValue);

            Assert.AreEqual(success, ConvertibleLongValue, "Error converting byte? to long");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting byte? to long");
            #endregion

            #region byte? - without DefaultValue param
            success = ConvertibleNullableByteValue.TryParseLong();
            invalid1 = ((byte?)null).TryParseLong();

            Assert.AreEqual(success, ConvertibleLongValue, "Error converting byte? to long");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting byte? to long");
            #endregion

        }

        /// <summary>
        /// Test TryParseLong method from short and nullable short values
        /// </summary>
        [TestMethod]
        public void TryParseLong_FromShortAndNullableShort()
        {
            #region byte - full method
            var success = ConvertibleShortValue.TryParseLong();
            Assert.AreEqual(success, ConvertibleLongValue, "Error converting byte to long");
            #endregion

            #region byte? - full method
            success = ConvertibleNullableShortValue.TryParseLong(DefaultValue);
            var invalid1 = ((short?)null).TryParseLong(DefaultValue);

            Assert.AreEqual(success, ConvertibleLongValue, "Error converting byte? to long");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting byte? to long");
            #endregion

            #region byte? - without DefaultValue param
            success = ConvertibleNullableShortValue.TryParseLong();
            invalid1 = ((short?)null).TryParseLong();

            Assert.AreEqual(success, ConvertibleLongValue, "Error converting byte? to long");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting byte? to long");
            #endregion

        }

        /// <summary>
        /// Test TryParseLong method from int and nullable int values
        /// </summary>
        [TestMethod]
        public void TryParseLong_FromIntAndNullableInt()
        {
            #region long - without DefaultValue param
            var success = ConvertibleIntValue.TryParseLong();
            
            Assert.AreEqual(success, ConvertibleLongValue, "Error converting long to long");
            #endregion

            #region long? - full method
            success = ConvertibleNullableIntValue.TryParseLong(DefaultValue);
            var invalid1 = ((int?)null).TryParseLong(DefaultValue);
            
            Assert.AreEqual(success, ConvertibleLongValue, "Error converting long? to long");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting long? to long");
            #endregion

            #region long? - without DefaultValue param
            success = ConvertibleNullableIntValue.TryParseLong();
            invalid1 = ((int?)null).TryParseLong();
            
            Assert.AreEqual(success, ConvertibleLongValue, "Error converting long? to long");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting long? to long");
            #endregion

        }

        /// <summary>
        /// Test TryParseLong method from decimal and nullable decimal values
        /// </summary>
        [TestMethod]
        public void TryParseLong_FromDecimalAndNullableDecimal()
        {
            const decimal invalidValue1 = decimal.MaxValue;
            decimal? nullableInvalidValue1 = decimal.MaxValue;
            const decimal invalidValue2 = decimal.MinValue;
            decimal? nullableInvalidValue2 = decimal.MinValue;
            
            #region decimal - full method
            var success = ConvertibleDecimalValue.TryParseLong(DefaultValue);
            var invalid1 = invalidValue1.TryParseLong(DefaultValue);
            var invalid2 = invalidValue2.TryParseLong(DefaultValue);

            Assert.AreEqual(success, ConvertibleLongValue, "Error converting decimal to long");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting decimal to long");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting decimal to long");
            #endregion

            #region decimal - without DefaultValue param
            success = ConvertibleDecimalValue.TryParseLong();
            invalid1 = invalidValue1.TryParseLong();
            invalid2 = invalidValue2.TryParseLong();

            Assert.AreEqual(success, ConvertibleLongValue, "Error converting decimal to long");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultLongConversionValue(), "Error converting decimal to long");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultLongConversionValue(), "Error converting decimal to long");
            #endregion

            #region decimal? - full method
            success = ConvertibleNullableDecimalValue.TryParseLong(DefaultValue);
            invalid1 = nullableInvalidValue1.TryParseLong(DefaultValue);
            invalid2 = nullableInvalidValue2.TryParseLong(DefaultValue);

            Assert.AreEqual(success, ConvertibleLongValue, "Error converting decimal? to long");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting decimal? to long");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting decimal? to long");
            #endregion

            #region decimal? - without DefaultValue param
            success = ConvertibleNullableDecimalValue.TryParseLong();
            invalid1 = nullableInvalidValue1.TryParseLong();
            invalid2 = nullableInvalidValue2.TryParseLong();

            Assert.AreEqual(success, ConvertibleLongValue, "Error converting decimal? to long");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultLongConversionValue(), "Error converting decimal? to long");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultLongConversionValue(), "Error converting decimal? to long");
            #endregion

        }

        /// <summary>
        /// Test TryParseLong method from double and nullable double values
        /// </summary>
        [TestMethod]
        public void TryParseLong_FromDoubleAndNullableDouble()
        {
            const double invalidValue1 = double.MaxValue;
            double? nullableInvalidValue1 = double.MaxValue;
            const double invalidValue2 = double.MinValue;
            double? nullableInvalidValue2 = double.MinValue;
            
            #region double - full method
            var success = ConvertibleDoubleValue.TryParseLong(DefaultValue);
            var invalid1 = invalidValue1.TryParseLong(DefaultValue);
            var invalid2 = invalidValue2.TryParseLong(DefaultValue);

            Assert.AreEqual(success, ConvertibleLongValue, "Error converting double to long");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting double to long");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting double to long");
            #endregion

            #region double - without DefaultValue param
            success = ConvertibleDoubleValue.TryParseLong();
            invalid1 = invalidValue1.TryParseLong();
            invalid2 = invalidValue2.TryParseLong();

            Assert.AreEqual(success, ConvertibleLongValue, "Error converting double to long");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultLongConversionValue(), "Error converting double to long");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultLongConversionValue(), "Error converting double to long");
            #endregion

            #region double? - full method
            success = ConvertibleNullableDoubleValue.TryParseLong(DefaultValue);
            invalid1 = nullableInvalidValue1.TryParseLong(DefaultValue);
            invalid2 = nullableInvalidValue2.TryParseLong(DefaultValue);

            Assert.AreEqual(success, ConvertibleLongValue, "Error converting double? to long");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting double? to long");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting double? to long");
            #endregion

            #region double? - without DefaultValue param
            success = ConvertibleNullableDoubleValue.TryParseLong();
            invalid1 = nullableInvalidValue1.TryParseLong();
            invalid2 = nullableInvalidValue2.TryParseLong();

            Assert.AreEqual(success, ConvertibleLongValue, "Error converting double? to long");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultLongConversionValue(), "Error converting double? to long");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultLongConversionValue(), "Error converting double? to long");
            #endregion
        }

        /// <summary>
        /// Test TryParseLong method from float and nullable float values
        /// </summary>
        [TestMethod]
        public void TryParseLong_FromFloatAndNullableFloat()
        {
            const float invalidValue1 = float.MaxValue;
            float? nullableInvalidValue1 = float.MaxValue;
            const float invalidValue2 = float.MinValue;
            float? nullableInvalidValue2 = float.MinValue;
            
            #region float - full method
            var success = ConvertibleFloatValue.TryParseLong(DefaultValue);
            var invalid1 = invalidValue1.TryParseLong(DefaultValue);
            var invalid2 = invalidValue2.TryParseLong(DefaultValue);

            Assert.AreEqual(success, ConvertibleLongValue, "Error converting float to long");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting float to long");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting float to long");
            #endregion

            #region float - without DefaultValue param
            success = ConvertibleFloatValue.TryParseLong();
            invalid1 = invalidValue1.TryParseLong();
            invalid2 = invalidValue2.TryParseLong();

            Assert.AreEqual(success, ConvertibleLongValue, "Error converting float to long");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultLongConversionValue(), "Error converting float to long");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultLongConversionValue(), "Error converting float to long");
            #endregion

            #region float? - full method
            success = ConvertibleNullableFloatValue.TryParseLong(DefaultValue);
            invalid1 = nullableInvalidValue1.TryParseLong(DefaultValue);
            invalid2 = nullableInvalidValue2.TryParseLong(DefaultValue);

            Assert.AreEqual(success, ConvertibleLongValue, "Error converting float? to long");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting float? to long");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting float? to long");
            #endregion

            #region float? - without DefaultValue param
            success = ConvertibleNullableFloatValue.TryParseLong();
            invalid1 = nullableInvalidValue1.TryParseLong();
            invalid2 = nullableInvalidValue2.TryParseLong();

            Assert.AreEqual(success, ConvertibleLongValue, "Error converting float? to long");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultLongConversionValue(), "Error converting float? to long");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultLongConversionValue(), "Error converting float? to long");
            #endregion

        }

        /// <summary>
        /// Teste method TryParseLongArray and overload
        /// </summary>
        [TestMethod]
        public void TryParseLongArray()
        {
            const string successValue1 = "10";
            const string successValue2 = "20";
            var errorValue1 = double.MaxValue.ToString(CultureInfo.InvariantCulture);
            var errorValue2 = double.MinValue.ToString(CultureInfo.InvariantCulture);

            var successByteValues = new[] { successValue1.TryParseLong(), successValue2.TryParseLong() };
            var successValues = new[] { successValue1, successValue2 };
            var errorValues = new[] { errorValue1, errorValue2 };
            var mixedValues = new[] { successValue1, successValue2, errorValue1, errorValue2 };

            #region full method (with number format), without default, dont return defult conversion
            var successConversion = string.Join(",", successValues).TryParseLongArray(null, false,
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(successConversion, "Error converting string to long array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to long array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to long array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to long array");

            var falseConversions = string.Join(",", errorValues).TryParseLongArray(null, false,
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(falseConversions, "Error converting string to long array");
            Assert.IsFalse(falseConversions.Any(), "Error converting string to long array");

            var mixedConversions = string.Join(",", mixedValues).TryParseLongArray(null, false,
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(mixedConversions, "Error converting string to long array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a)), "Error converting string to long array");
            Assert.IsTrue(mixedConversions.Count() == successByteValues.Count(), "Error converting string to long array");
            #endregion

            #region partial method (with number format), without default
            successConversion = string.Join(",", successValues).TryParseLongArray(null,
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(successConversion, "Error converting string to long array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to long array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to long array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to long array");

            falseConversions = string.Join(",", errorValues).TryParseLongArray(null,
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(falseConversions, "Error converting string to long array");
            Assert.IsFalse(falseConversions.Any(), "Error converting string to long array");

            mixedConversions = string.Join(",", mixedValues).TryParseLongArray(null,
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(mixedConversions, "Error converting string to long array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a)), "Error converting string to long array");
            Assert.IsTrue(mixedConversions.Count() == successByteValues.Count(), "Error converting string to long array");
            #endregion

            #region simple method (with number format)
            successConversion = string.Join(",", successValues).TryParseLongArray(
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(successConversion, "Error converting string to long array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to long array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to long array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to long array");

            falseConversions = string.Join(",", errorValues).TryParseLongArray(
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(falseConversions, "Error converting string to long array");
            Assert.IsFalse(falseConversions.Any(), "Error converting string to long array");

            mixedConversions = string.Join(",", mixedValues).TryParseLongArray(
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(mixedConversions, "Error converting string to long array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a)), "Error converting string to long array");
            Assert.IsTrue(mixedConversions.Count() == successByteValues.Count(), "Error converting string to long array");
            #endregion

            #region full method (without number format), without default, dont return defult conversion
            successConversion = string.Join(",", successValues).TryParseLongArray(null, false);
            Assert.IsNotNull(successConversion, "Error converting string to long array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to long array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to long array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to long array");

            falseConversions = string.Join(",", errorValues).TryParseLongArray(null, false);
            Assert.IsNotNull(falseConversions, "Error converting string to long array");
            Assert.IsFalse(falseConversions.Any(), "Error converting string to long array");

            mixedConversions = string.Join(",", mixedValues).TryParseLongArray(null, false);
            Assert.IsNotNull(mixedConversions, "Error converting string to long array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a)), "Error converting string to long array");
            Assert.IsTrue(mixedConversions.Count() == successByteValues.Count(), "Error converting string to long array");
            #endregion

            #region partial method (without number format), without default
            successConversion = string.Join(",", successValues).TryParseLongArray(null);
            Assert.IsNotNull(successConversion, "Error converting string to long array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to long array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to long array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to long array");

            falseConversions = string.Join(",", errorValues).TryParseLongArray(null);
            Assert.IsNotNull(falseConversions, "Error converting string to long array");
            Assert.IsFalse(falseConversions.Any(), "Error converting string to long array");

            mixedConversions = string.Join(",", mixedValues).TryParseLongArray(null);
            Assert.IsNotNull(mixedConversions, "Error converting string to long array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a)), "Error converting string to long array");
            Assert.IsTrue(mixedConversions.Count() == successByteValues.Count(), "Error converting string to long array");
            #endregion

            #region simple method (without number format)
            successConversion = string.Join(",", successValues).TryParseLongArray();
            Assert.IsNotNull(successConversion, "Error converting string to long array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to long array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to long array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to long array");

            falseConversions = string.Join(",", errorValues).TryParseLongArray();
            Assert.IsNotNull(falseConversions, "Error converting string to long array");
            Assert.IsFalse(falseConversions.Any(), "Error converting string to long array");

            mixedConversions = string.Join(",", mixedValues).TryParseLongArray();
            Assert.IsNotNull(mixedConversions, "Error converting string to long array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a)), "Error converting string to long array");
            Assert.IsTrue(mixedConversions.Count() == successByteValues.Count(), "Error converting string to long array");
            #endregion
        }

        /// <summary>
        /// Teste method IsValidLong and overload
        /// </summary>
        [TestMethod]
        public void IsValidLong()
        {
            Assert.IsFalse("".IsValidLong());
            Assert.IsFalse("jorn".IsValidLong());
            Assert.IsFalse("false".IsValidLong());
            Assert.IsFalse("1.1".Replace(".", Culture.NumberFormat.CurrencyDecimalSeparator).IsValidLong());
            Assert.IsFalse("4545454.4545445".Replace(".", Culture.NumberFormat.CurrencyDecimalSeparator).IsValidLong());
            Assert.IsFalse(double.MaxValue.ToString(CultureInfo.InvariantCulture).IsValidLong());
            Assert.IsFalse(double.MinValue.ToString(CultureInfo.InvariantCulture).IsValidLong());
            Assert.IsTrue(int.MaxValue.ToString(CultureInfo.InvariantCulture).IsValidLong());
            Assert.IsTrue(int.MinValue.ToString(CultureInfo.InvariantCulture).IsValidLong());
            Assert.IsTrue(long.MaxValue.ToString(CultureInfo.InvariantCulture).IsValidLong());
            Assert.IsTrue(long.MinValue.ToString(CultureInfo.InvariantCulture).IsValidLong());
            Assert.IsTrue("1".IsValidLong());
            Assert.IsTrue("10".IsValidLong());
            Assert.IsTrue("0".IsValidLong());

            Assert.IsFalse("".IsValidLong(NumberStyle, Culture));
            Assert.IsFalse("jorn".IsValidLong(NumberStyle, Culture));
            Assert.IsFalse("false".IsValidLong(NumberStyle, Culture));
            Assert.IsFalse("1.1".Replace(".", Culture.NumberFormat.CurrencyDecimalSeparator).IsValidLong(NumberStyle, Culture));
            Assert.IsFalse("4545454.4545445".Replace(".", Culture.NumberFormat.CurrencyDecimalSeparator).IsValidLong(NumberStyle, Culture));
            Assert.IsFalse(double.MaxValue.ToString(CultureInfo.InvariantCulture).IsValidLong(NumberStyle, Culture));
            Assert.IsFalse(double.MinValue.ToString(CultureInfo.InvariantCulture).IsValidLong(NumberStyle, Culture));
            Assert.IsTrue(int.MaxValue.ToString(CultureInfo.InvariantCulture).IsValidLong(NumberStyle, Culture));
            Assert.IsTrue(int.MinValue.ToString(CultureInfo.InvariantCulture).IsValidLong(NumberStyle, Culture));
            Assert.IsTrue(long.MaxValue.ToString(CultureInfo.InvariantCulture).IsValidLong(NumberStyle, Culture));
            Assert.IsTrue(long.MinValue.ToString(CultureInfo.InvariantCulture).IsValidLong(NumberStyle, Culture));
            Assert.IsTrue("1".IsValidLong(NumberStyle, Culture));
            Assert.IsTrue("10".IsValidLong(NumberStyle, Culture));
            Assert.IsTrue("0".IsValidLong(NumberStyle, Culture));
        }
    }
}
