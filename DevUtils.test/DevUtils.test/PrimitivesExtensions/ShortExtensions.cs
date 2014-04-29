using System.Globalization;
using System.Linq;
using DevUtils.PrimitivesExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.PrimitivesExtensions
{
    /// <summary>
    /// Test class ShortExtensions
    /// </summary>
    [TestClass]
    public class ShortExtensions
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
        private short DefaultValue { get; set; }
        private NumberStyles NumberStyle { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Test constructor
        /// </summary>
        public ShortExtensions()
        {
            Culture = CultureInfo.CurrentCulture;
            DefaultValue = 100;

            ConvertibleStringValue = "200";
            ConvertibleShortValue = 200;
            ConvertibleNullableShortValue = 200;
            ConvertibleNullableDecimalValue = ConvertibleNullableShortValue;
            ConvertibleDecimalValue = ConvertibleShortValue;
            ConvertibleNullableLongValue = ConvertibleNullableShortValue;
            ConvertibleLongValue = ConvertibleShortValue;
            ConvertibleNullableIntValue = ConvertibleNullableShortValue;
            ConvertibleIntValue = ConvertibleShortValue;
            ConvertibleNullableByteValue = (byte?)ConvertibleNullableShortValue;
            ConvertibleByteValue = (byte)ConvertibleShortValue;
            ConvertibleNullableDoubleValue = ConvertibleNullableShortValue + 0.2d;
            ConvertibleDoubleValue = ConvertibleShortValue + 0.2d;
            ConvertibleNullableFloatValue = ConvertibleNullableShortValue + 0.2f;
            ConvertibleFloatValue = ConvertibleShortValue + 0.2f;
            NumberStyle = NumberStyles.Integer;
            
        } 
        #endregion

        /// <summary>
        /// Test TryParseShort method from string value
        /// </summary>
        [TestMethod]
        public void TryParseShort_FromString()
        {
            var invalidValue1 = long.MaxValue.ToString(CultureInfo.InvariantCulture);
            var invalidValue2 = long.MinValue.ToString(CultureInfo.InvariantCulture);
            
            #region full method
            var success = ConvertibleStringValue.TryParseShort(DefaultValue,
                BasePrimitivesExtensions.GetDefaultShortAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            var invalid1 = invalidValue1.TryParseShort(DefaultValue,
                BasePrimitivesExtensions.GetDefaultShortAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            var invalid2 = invalidValue2.TryParseShort(DefaultValue,
                BasePrimitivesExtensions.GetDefaultShortAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting string to short");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to short");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to short");
            #endregion

            #region without allowZero param
            success = ConvertibleStringValue.TryParseShort(DefaultValue,
                BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid1 = invalidValue1.TryParseShort(DefaultValue,
                BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid2 = invalidValue2.TryParseShort(DefaultValue,
                BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting string to short");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to short");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to short");
            #endregion

            #region without allowZero and DefaultValue params
            success = ConvertibleStringValue.TryParseShort(BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid1 = invalidValue1.TryParseShort(BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid2 = invalidValue2.TryParseShort(BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting string to short");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting string to short");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting string to short");
            #endregion

            #region without number style and culture params
            success = ConvertibleStringValue.TryParseShort(DefaultValue,
                BasePrimitivesExtensions.GetDefaultShortAllowDefaultConversion());

            invalid1 = invalidValue1.TryParseShort(DefaultValue,
                BasePrimitivesExtensions.GetDefaultShortAllowDefaultConversion());

            invalid2 = invalidValue2.TryParseShort(DefaultValue,
                BasePrimitivesExtensions.GetDefaultShortAllowDefaultConversion());

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting string to short");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to short");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to short");
            #endregion

            #region without number style, culture and allowZero params
            success = ConvertibleStringValue.TryParseShort(DefaultValue);
            invalid1 = invalidValue1.TryParseShort(DefaultValue);
            invalid2 = invalidValue2.TryParseShort(DefaultValue);

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting string to short");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to short");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to short");
            #endregion

            #region simple conversion
            success = ConvertibleStringValue.TryParseShort();
            invalid1 = invalidValue1.TryParseShort();
            invalid2 = invalidValue2.TryParseShort();

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting string to short");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting string to short");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting string to short");
            #endregion
        }

        /// <summary>
        /// Test TryParseShort method from nullable short value
        /// </summary>
        [TestMethod]
        public void TryParseShort_NullableShort()
        {
            #region full method
            var success = ConvertibleNullableShortValue.TryParseShort(DefaultValue);
            var invalid = ((short?)null).TryParseShort(DefaultValue);

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting nullable short to short");
            Assert.AreEqual(invalid, DefaultValue, "Error converting nullable short to short");
            #endregion

            #region simple method
            success = ConvertibleNullableShortValue.TryParseShort();
            invalid = ((short?)null).TryParseShort();

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting nullable short to short");
            Assert.AreEqual(invalid, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting nullable short to short");
            #endregion
        }

        /// <summary>
        /// Test TryParseShort method from short and nullable short values
        /// </summary>
        [TestMethod]
        public void TryParseShort_FromByteAndNullableByte()
        {
            #region byte - full method
            var success = ConvertibleByteValue.TryParseShort();
            Assert.AreEqual(success, ConvertibleShortValue,"Error converting byte to short");
            #endregion

            #region byte? - full method
            success = ConvertibleNullableByteValue.TryParseShort(DefaultValue);
            var invalid1 = ((byte?)null).TryParseShort(DefaultValue);

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting byte? to short");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting byte? to short");
            #endregion

            #region byte? - without DefaultValue param
            success = ConvertibleNullableByteValue.TryParseShort();
            invalid1 = ((byte?)null).TryParseShort();

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting byte? to short");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting byte? to short");
            #endregion

        }

        /// <summary>
        /// Test TryParseShort method from int and nullable int values
        /// </summary>
        [TestMethod]
        public void TryParseShort_FromIntAndNullableInt()
        {
            const int invalidValue1 = int.MaxValue;
            int? nullableInvalidValue1 = int.MaxValue;
            const int invalidValue2 = int.MinValue;
            int? nullableInvalidValue2 = int.MinValue;
            
            #region int - full method
            var success = ConvertibleIntValue.TryParseShort(DefaultValue);
            var invalid1 = invalidValue1.TryParseShort(DefaultValue);
            var invalid2 = invalidValue2.TryParseShort(DefaultValue);

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting int to short");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting int to short");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting int to short");
            #endregion

            #region int - without DefaultValue param
            success = ConvertibleIntValue.TryParseShort();
            invalid1 = invalidValue1.TryParseShort();
            invalid2 = invalidValue2.TryParseShort();

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting int to short");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting int to short");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting int to short");
            #endregion

            #region int? - full method
            success = ConvertibleNullableIntValue.TryParseShort(DefaultValue);
            invalid1 = nullableInvalidValue1.TryParseShort(DefaultValue);
            invalid2 = nullableInvalidValue2.TryParseShort(DefaultValue);

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting int? to short");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting int? to short");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting int? to short");
            #endregion

            #region int? - without DefaultValue param
            success = ConvertibleNullableIntValue.TryParseShort();
            invalid1 = nullableInvalidValue1.TryParseShort();
            invalid2 = nullableInvalidValue2.TryParseShort();

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting int? to short");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting int? to short");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting int? to short");
            #endregion

        }

        /// <summary>
        /// Test TryParseShort method from long and nullable long values
        /// </summary>
        [TestMethod]
        public void TryParseShort_FromLongAndNullableLong()
        {
            const long invalidValue1 = long.MaxValue;
            long? nullableInvalidValue1 = long.MaxValue;
            const long invalidValue2 = long.MinValue;
            long? nullableInvalidValue2 = long.MinValue;
            
            #region long - full method
            var success = ConvertibleLongValue.TryParseShort(DefaultValue);
            var invalid1 = invalidValue1.TryParseShort(DefaultValue);
            var invalid2 = invalidValue2.TryParseShort(DefaultValue);

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting long to short");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting long to short");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting long to short");
            #endregion

            #region long - without DefaultValue param
            success = ConvertibleLongValue.TryParseShort();
            invalid1 = invalidValue1.TryParseShort();
            invalid2 = invalidValue2.TryParseShort();

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting long to short");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting long to short");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting long to short");
            #endregion

            #region long? - full method
            success = ConvertibleNullableLongValue.TryParseShort(DefaultValue);
            invalid1 = nullableInvalidValue1.TryParseShort(DefaultValue);
            invalid2 = nullableInvalidValue2.TryParseShort(DefaultValue);

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting long? to short");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting long? to short");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting long? to short");
            #endregion

            #region long? - without DefaultValue param
            success = ConvertibleNullableLongValue.TryParseShort();
            invalid1 = nullableInvalidValue1.TryParseShort();
            invalid2 = nullableInvalidValue2.TryParseShort();

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting long? to short");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting long? to short");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting long? to short");
            #endregion

        }

        /// <summary>
        /// Test TryParseShort method from decimal and nullable decimal values
        /// </summary>
        [TestMethod]
        public void TryParseShort_FromDecimalAndNullableDecimal()
        {
            const decimal invalidValue1 = decimal.MaxValue;
            decimal? nullableInvalidValue1 = decimal.MaxValue;
            const decimal invalidValue2 = decimal.MinValue;
            decimal? nullableInvalidValue2 = decimal.MinValue;
            
            #region decimal - full method
            var success = ConvertibleDecimalValue.TryParseShort(DefaultValue);
            var invalid1 = invalidValue1.TryParseShort(DefaultValue);
            var invalid2 = invalidValue2.TryParseShort(DefaultValue);

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting decimal to short");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting decimal to short");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting decimal to short");
            #endregion

            #region decimal - without DefaultValue param
            success = ConvertibleDecimalValue.TryParseShort();
            invalid1 = invalidValue1.TryParseShort();
            invalid2 = invalidValue2.TryParseShort();

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting decimal to short");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting decimal to short");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting decimal to short");
            #endregion

            #region decimal? - full method
            success = ConvertibleNullableDecimalValue.TryParseShort(DefaultValue);
            invalid1 = nullableInvalidValue1.TryParseShort(DefaultValue);
            invalid2 = nullableInvalidValue2.TryParseShort(DefaultValue);

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting decimal? to short");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting decimal? to short");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting decimal? to short");
            #endregion

            #region decimal? - without DefaultValue param
            success = ConvertibleNullableDecimalValue.TryParseShort();
            invalid1 = nullableInvalidValue1.TryParseShort();
            invalid2 = nullableInvalidValue2.TryParseShort();

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting decimal? to short");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting decimal? to short");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting decimal? to short");
            #endregion

        }

        /// <summary>
        /// Test TryParseShort method from double and nullable double values
        /// </summary>
        [TestMethod]
        public void TryParseShort_FromDoubleAndNullableDouble()
        {
            const double invalidValue1 = double.MaxValue;
            double? nullableInvalidValue1 = double.MaxValue;
            const double invalidValue2 = double.MinValue;
            double? nullableInvalidValue2 = double.MinValue;
            
            #region double - full method
            var success = ConvertibleDoubleValue.TryParseShort(DefaultValue);
            var invalid1 = invalidValue1.TryParseShort(DefaultValue);
            var invalid2 = invalidValue2.TryParseShort(DefaultValue);

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting double to short");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting double to short");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting double to short");
            #endregion

            #region double - without DefaultValue param
            success = ConvertibleDoubleValue.TryParseShort();
            invalid1 = invalidValue1.TryParseShort();
            invalid2 = invalidValue2.TryParseShort();

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting double to short");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting double to short");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting double to short");
            #endregion

            #region double? - full method
            success = ConvertibleNullableDoubleValue.TryParseShort(DefaultValue);
            invalid1 = nullableInvalidValue1.TryParseShort(DefaultValue);
            invalid2 = nullableInvalidValue2.TryParseShort(DefaultValue);

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting double? to short");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting double? to short");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting double? to short");
            #endregion

            #region double? - without DefaultValue param
            success = ConvertibleNullableDoubleValue.TryParseShort();
            invalid1 = nullableInvalidValue1.TryParseShort();
            invalid2 = nullableInvalidValue2.TryParseShort();

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting double? to short");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting double? to short");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting double? to short");
            #endregion

        }

        /// <summary>
        /// Test TryParseShort method from float and nullable float values
        /// </summary>
        [TestMethod]
        public void TryParseShort_FromFloatAndNullableFloat()
        {
            const float invalidValue1 = float.MaxValue;
            float? nullableInvalidValue1 = float.MaxValue;
            const float invalidValue2 = float.MinValue;
            float? nullableInvalidValue2 = float.MinValue;
            
            #region float - full method
            var success = ConvertibleFloatValue.TryParseShort(DefaultValue);
            var invalid1 = invalidValue1.TryParseShort(DefaultValue);
            var invalid2 = invalidValue2.TryParseShort(DefaultValue);

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting float to short");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting float to short");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting float to short");
            #endregion

            #region float - without DefaultValue param
            success = ConvertibleFloatValue.TryParseShort();
            invalid1 = invalidValue1.TryParseShort();
            invalid2 = invalidValue2.TryParseShort();

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting float to short");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting float to short");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting float to short");
            #endregion

            #region float? - full method
            success = ConvertibleNullableFloatValue.TryParseShort(DefaultValue);
            invalid1 = nullableInvalidValue1.TryParseShort(DefaultValue);
            invalid2 = nullableInvalidValue2.TryParseShort(DefaultValue);

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting float? to short");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting float? to short");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting float? to short");
            #endregion

            #region float? - without DefaultValue param
            success = ConvertibleNullableFloatValue.TryParseShort();
            invalid1 = nullableInvalidValue1.TryParseShort();
            invalid2 = nullableInvalidValue2.TryParseShort();

            Assert.AreEqual(success, ConvertibleShortValue,"Error converting float? to short");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting float? to short");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultShortConversionValue(), "Error converting float? to short");
            #endregion

        }

        /// <summary>
        /// Teste method TryParseShortArray and overload
        /// </summary>
        [TestMethod]
        public void TryParseShortArray()
        {
            const string successValue1 = "10";
            const string successValue2 = "20";
            var errorValue1 = long.MaxValue.ToString(CultureInfo.InvariantCulture);
            var errorValue2 = long.MinValue.ToString(CultureInfo.InvariantCulture);

            var successByteValues = new[] { successValue1.TryParseShort(), successValue2.TryParseShort() };
            var successValues = new[] { successValue1, successValue2 };
            var errorValues = new[] { errorValue1, errorValue2 };
            var mixedValues = new[] { successValue1, successValue2, errorValue1, errorValue2 };

            #region full method (with number format), without default, dont return defult conversion
            var successConversion = string.Join(",", successValues).TryParseShortArray(null, false,
                BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(successConversion, "Error converting string to short array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to short array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to short array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to short array");

            var falseConversions = string.Join(",", errorValues).TryParseShortArray(null, false,
                BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(falseConversions, "Error converting string to short array");
            Assert.IsFalse(falseConversions.Any(), "Error converting string to short array");

            var mixedConversions = string.Join(",", mixedValues).TryParseShortArray(null, false,
                BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(mixedConversions, "Error converting string to short array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a)), "Error converting string to short array");
            Assert.IsTrue(mixedConversions.Count() == successByteValues.Count(), "Error converting string to short array");
            #endregion

            #region partial method (with number format), without default
            successConversion = string.Join(",", successValues).TryParseShortArray(null,
                BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(successConversion, "Error converting string to short array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to short array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to short array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to short array");

            falseConversions = string.Join(",", errorValues).TryParseShortArray(null,
                BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(falseConversions, "Error converting string to short array");
            Assert.IsFalse(falseConversions.Any(), "Error converting string to short array");

            mixedConversions = string.Join(",", mixedValues).TryParseShortArray(null,
                BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(mixedConversions, "Error converting string to short array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a)), "Error converting string to short array");
            Assert.IsTrue(mixedConversions.Count() == successByteValues.Count(), "Error converting string to short array");
            #endregion

            #region simple method (with number format)
            successConversion = string.Join(",", successValues).TryParseShortArray(
                BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(successConversion, "Error converting string to short array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to short array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to short array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to short array");

            falseConversions = string.Join(",", errorValues).TryParseShortArray(
                BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(falseConversions, "Error converting string to short array");
            Assert.IsFalse(falseConversions.Any(), "Error converting string to short array");

            mixedConversions = string.Join(",", mixedValues).TryParseShortArray(
                BasePrimitivesExtensions.GetDefaultShortNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(mixedConversions, "Error converting string to short array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a)), "Error converting string to short array");
            Assert.IsTrue(mixedConversions.Count() == successByteValues.Count(), "Error converting string to short array");
            #endregion

            #region full method (without number format), without default, dont return defult conversion
            successConversion = string.Join(",", successValues).TryParseShortArray(null, false);
            Assert.IsNotNull(successConversion, "Error converting string to short array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to short array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to short array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to short array");

            falseConversions = string.Join(",", errorValues).TryParseShortArray(null, false);
            Assert.IsNotNull(falseConversions, "Error converting string to short array");
            Assert.IsFalse(falseConversions.Any(), "Error converting string to short array");

            mixedConversions = string.Join(",", mixedValues).TryParseShortArray(null, false);
            Assert.IsNotNull(mixedConversions, "Error converting string to short array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a)), "Error converting string to short array");
            Assert.IsTrue(mixedConversions.Count() == successByteValues.Count(), "Error converting string to short array");
            #endregion

            #region partial method (without number format), without default
            successConversion = string.Join(",", successValues).TryParseShortArray(null);
            Assert.IsNotNull(successConversion, "Error converting string to short array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to short array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to short array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to short array");

            falseConversions = string.Join(",", errorValues).TryParseShortArray(null);
            Assert.IsNotNull(falseConversions, "Error converting string to short array");
            Assert.IsFalse(falseConversions.Any(), "Error converting string to short array");

            mixedConversions = string.Join(",", mixedValues).TryParseShortArray(null);
            Assert.IsNotNull(mixedConversions, "Error converting string to short array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a)), "Error converting string to short array");
            Assert.IsTrue(mixedConversions.Count() == successByteValues.Count(), "Error converting string to short array");
            #endregion

            #region simple method (without number format)
            successConversion = string.Join(",", successValues).TryParseShortArray();
            Assert.IsNotNull(successConversion, "Error converting string to short array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to short array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to short array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to short array");

            falseConversions = string.Join(",", errorValues).TryParseShortArray();
            Assert.IsNotNull(falseConversions, "Error converting string to short array");
            Assert.IsFalse(falseConversions.Any(), "Error converting string to short array");

            mixedConversions = string.Join(",", mixedValues).TryParseShortArray();
            Assert.IsNotNull(mixedConversions, "Error converting string to short array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a)), "Error converting string to short array");
            Assert.IsTrue(mixedConversions.Count() == successByteValues.Count(), "Error converting string to short array");
            #endregion
        }

        /// <summary>
        /// Teste method IsValidShort and overload
        /// </summary>
        [TestMethod]
        public void IsValidShort()
        {
            Assert.IsFalse("".IsValidShort());
            Assert.IsFalse("jorn".IsValidShort());
            Assert.IsFalse("false".IsValidShort());
            Assert.IsFalse("1.1".Replace(".", Culture.NumberFormat.CurrencyDecimalSeparator).IsValidShort());
            Assert.IsFalse("4545454.4545445".Replace(".", Culture.NumberFormat.CurrencyDecimalSeparator).IsValidShort());
            Assert.IsFalse(double.MaxValue.ToString(CultureInfo.InvariantCulture).IsValidShort());
            Assert.IsFalse(double.MinValue.ToString(CultureInfo.InvariantCulture).IsValidShort());
            Assert.IsFalse(int.MaxValue.ToString(CultureInfo.InvariantCulture).IsValidShort());
            Assert.IsFalse(int.MinValue.ToString(CultureInfo.InvariantCulture).IsValidShort());
            Assert.IsTrue(byte.MaxValue.ToString(CultureInfo.InvariantCulture).IsValidShort());
            Assert.IsTrue(byte.MinValue.ToString(CultureInfo.InvariantCulture).IsValidShort());
            Assert.IsTrue("1".IsValidShort());
            Assert.IsTrue("10".IsValidShort());
            Assert.IsTrue("0".IsValidShort());
            Assert.IsTrue("-15".IsValidShort());

            Assert.IsFalse("".IsValidShort(NumberStyle, Culture));
            Assert.IsFalse("jorn".IsValidShort(NumberStyle, Culture));
            Assert.IsFalse("false".IsValidShort(NumberStyle, Culture));
            Assert.IsFalse("1.1".Replace(".", Culture.NumberFormat.CurrencyDecimalSeparator).IsValidShort(NumberStyle, Culture));
            Assert.IsFalse("4545454.4545445".Replace(".", Culture.NumberFormat.CurrencyDecimalSeparator).IsValidShort(NumberStyle, Culture));
            Assert.IsFalse(double.MaxValue.ToString(CultureInfo.InvariantCulture).IsValidShort(NumberStyle, Culture));
            Assert.IsFalse(double.MinValue.ToString(CultureInfo.InvariantCulture).IsValidShort(NumberStyle, Culture));
            Assert.IsFalse(int.MaxValue.ToString(CultureInfo.InvariantCulture).IsValidShort(NumberStyle, Culture));
            Assert.IsFalse(int.MinValue.ToString(CultureInfo.InvariantCulture).IsValidShort(NumberStyle, Culture));
            Assert.IsTrue(byte.MaxValue.ToString(CultureInfo.InvariantCulture).IsValidShort(NumberStyle, Culture));
            Assert.IsTrue(byte.MinValue.ToString(CultureInfo.InvariantCulture).IsValidShort(NumberStyle, Culture));
            Assert.IsTrue("1".IsValidShort(NumberStyle, Culture));
            Assert.IsTrue("10".IsValidShort(NumberStyle, Culture));
            Assert.IsTrue("0".IsValidShort(NumberStyle, Culture));
            Assert.IsTrue("-10".IsValidShort(NumberStyle, Culture));
        }
    }
}
