using System;
using System.Globalization;
using System.Linq;
using DevUtils.PrimitivesExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.PrimitivesExtensions
{
    /// <summary>
    /// Test class IntExtensions
    /// </summary>
    [TestClass]
    public class IntExtensions
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
        private int DefaultValue { get; set; }
        private NumberStyles NumberStyle { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Test constructor
        /// </summary>
        public IntExtensions()
        {
            Culture = CultureInfo.CurrentCulture;
            DefaultValue = 100;

            ConvertibleStringValue = "200";
            ConvertibleIntValue = 200;
            ConvertibleNullableIntValue = 200;
            ConvertibleNullableDecimalValue = ConvertibleNullableIntValue;
            ConvertibleDecimalValue = ConvertibleIntValue;
            ConvertibleNullableShortValue = (short?)ConvertibleNullableIntValue;
            ConvertibleShortValue = (short)ConvertibleIntValue;
            ConvertibleNullableLongValue = ConvertibleNullableIntValue;
            ConvertibleLongValue = ConvertibleIntValue;
            ConvertibleNullableByteValue = (byte?)ConvertibleNullableIntValue;
            ConvertibleByteValue = (byte)ConvertibleIntValue;
            ConvertibleNullableDoubleValue = ConvertibleNullableIntValue + 0.2d;
            ConvertibleDoubleValue = ConvertibleIntValue + 0.2d;
            ConvertibleNullableFloatValue = ConvertibleNullableIntValue + 0.2f;
            ConvertibleFloatValue = ConvertibleIntValue + 0.2f;
            NumberStyle = NumberStyles.Integer;
            
        } 
        #endregion

        /// <summary>
        /// Test TryParseInt method from string value
        /// </summary>
        [TestMethod]
        public void TryParseInt_FromString()
        {
            var invalidValue1 = double.MaxValue.ToString(CultureInfo.InvariantCulture);
            var invalidValue2 = double.MinValue.ToString(CultureInfo.InvariantCulture);
            
            #region full method
            var success = ConvertibleStringValue.TryParseInt(DefaultValue,
                BasePrimitivesExtensions.GetDefaultIntAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            var invalid1 = invalidValue1.TryParseInt(DefaultValue,
                BasePrimitivesExtensions.GetDefaultIntAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            var invalid2 = invalidValue2.TryParseInt(DefaultValue,
                BasePrimitivesExtensions.GetDefaultIntAllowDefaultConversion(),
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting string to int");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to int");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to int");
            #endregion

            #region without allowZero param
            success = ConvertibleStringValue.TryParseInt(DefaultValue,
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid1 = invalidValue1.TryParseInt(DefaultValue,
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid2 = invalidValue2.TryParseInt(DefaultValue,
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting string to int");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to int");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to int");
            #endregion

            #region without allowZero and DefaultValue params
            success = ConvertibleStringValue.TryParseInt(BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid1 = invalidValue1.TryParseInt(BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid2 = invalidValue2.TryParseInt(BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting string to int");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting string to int");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting string to int");
            #endregion

            #region without number style and culture params
            success = ConvertibleStringValue.TryParseInt(DefaultValue,
                BasePrimitivesExtensions.GetDefaultIntAllowDefaultConversion());

            invalid1 = invalidValue1.TryParseInt(DefaultValue,
                BasePrimitivesExtensions.GetDefaultIntAllowDefaultConversion());

            invalid2 = invalidValue2.TryParseInt(DefaultValue,
                BasePrimitivesExtensions.GetDefaultIntAllowDefaultConversion());

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting string to int");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to int");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to int");
            #endregion

            #region without number style, culture and allowZero params
            success = ConvertibleStringValue.TryParseInt(DefaultValue);
            invalid1 = invalidValue1.TryParseInt(DefaultValue);
            invalid2 = invalidValue2.TryParseInt(DefaultValue);

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting string to int");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to int");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to int");
            #endregion

            #region simple conversion
            success = ConvertibleStringValue.TryParseInt();
            invalid1 = invalidValue1.TryParseInt();
            invalid2 = invalidValue2.TryParseInt();

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting string to int");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting string to int");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting string to int");
            #endregion
        }

        /// <summary>
        /// Test TryParseInt method from nullable int value
        /// </summary>
        [TestMethod]
        public void TryParseInt_NullableInt()
        {
            #region full method
            var success = ConvertibleNullableIntValue.TryParseInt(DefaultValue);
            var invalid = ((int?)null).TryParseInt(DefaultValue);

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting nullable int to int");
            Assert.AreEqual(invalid, DefaultValue, "Error converting nullable int to int");
            #endregion

            #region simple method
            success = ConvertibleNullableIntValue.TryParseInt();
            invalid = ((int?)null).TryParseInt();

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting nullable int to int");
            Assert.AreEqual(invalid, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting nullable int to int");
            #endregion
        }

        /// <summary>
        /// Test TryParseInt method from byte and nullable byte values
        /// </summary>
        [TestMethod]
        public void TryParseInt_FromByteAndNullableByte()
        {
            #region byte - full method
            var success = ConvertibleByteValue.TryParseInt();
            Assert.AreEqual(success, ConvertibleIntValue, "Error converting byte to int");
            #endregion

            #region byte? - full method
            success = ConvertibleNullableByteValue.TryParseInt(DefaultValue);
            var invalid1 = ((byte?)null).TryParseInt(DefaultValue);

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting byte? to int");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting byte? to int");
            #endregion

            #region byte? - without DefaultValue param
            success = ConvertibleNullableByteValue.TryParseInt();
            invalid1 = ((byte?)null).TryParseInt();

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting byte? to int");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting byte? to int");
            #endregion

        }

        /// <summary>
        /// Test TryParseInt method from short and nullable short values
        /// </summary>
        [TestMethod]
        public void TryParseInt_FromShortAndNullableShort()
        {
            #region byte - full method
            var success = ConvertibleShortValue.TryParseInt();
            Assert.AreEqual(success, ConvertibleIntValue, "Error converting byte to int");
            #endregion

            #region byte? - full method
            success = ConvertibleNullableShortValue.TryParseInt(DefaultValue);
            var invalid1 = ((short?)null).TryParseInt(DefaultValue);

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting byte? to int");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting byte? to int");
            #endregion

            #region byte? - without DefaultValue param
            success = ConvertibleNullableShortValue.TryParseInt();
            invalid1 = ((short?)null).TryParseInt();

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting byte? to int");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting byte? to int");
            #endregion

        }

        /// <summary>
        /// Test TryParseInt method from long and nullable long values
        /// </summary>
        [TestMethod]
        public void TryParseInt_FromLongAndNullableLong()
        {
            const long invalidValue1 = long.MaxValue;
            long? nullableInvalidValue1 = long.MaxValue;
            const long invalidValue2 = long.MinValue;
            long? nullableInvalidValue2 = long.MinValue;
            
            #region long - full method
            var success = ConvertibleLongValue.TryParseInt(DefaultValue);
            var invalid1 = invalidValue1.TryParseInt(DefaultValue);
            var invalid2 = invalidValue2.TryParseInt(DefaultValue);

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting long to int");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting long to int");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting long to int");
            #endregion

            #region long - without DefaultValue param
            success = ConvertibleLongValue.TryParseInt();
            invalid1 = invalidValue1.TryParseInt();
            invalid2 = invalidValue2.TryParseInt();

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting long to int");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting long to int");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting long to int");
            #endregion

            #region long? - full method
            success = ConvertibleNullableLongValue.TryParseInt(DefaultValue);
            invalid1 = nullableInvalidValue1.TryParseInt(DefaultValue);
            invalid2 = nullableInvalidValue2.TryParseInt(DefaultValue);

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting long? to int");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting long? to int");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting long? to int");
            #endregion

            #region long? - without DefaultValue param
            success = ConvertibleNullableLongValue.TryParseInt();
            invalid1 = nullableInvalidValue1.TryParseInt();
            invalid2 = nullableInvalidValue2.TryParseInt();

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting long? to int");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting long? to int");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting long? to int");
            #endregion

        }

        /// <summary>
        /// Test TryParseInt method from decimal and nullable decimal values
        /// </summary>
        [TestMethod]
        public void TryParseInt_FromDecimalAndNullableDecimal()
        {
            const decimal invalidValue1 = decimal.MaxValue;
            decimal? nullableInvalidValue1 = decimal.MaxValue;
            const decimal invalidValue2 = decimal.MinValue;
            decimal? nullableInvalidValue2 = decimal.MinValue;
            
            #region decimal - full method
            var success = ConvertibleDecimalValue.TryParseInt(DefaultValue);
            var invalid1 = invalidValue1.TryParseInt(DefaultValue);
            var invalid2 = invalidValue2.TryParseInt(DefaultValue);

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting decimal to int");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting decimal to int");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting decimal to int");
            #endregion

            #region decimal - without DefaultValue param
            success = ConvertibleDecimalValue.TryParseInt();
            invalid1 = invalidValue1.TryParseInt();
            invalid2 = invalidValue2.TryParseInt();

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting decimal to int");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting decimal to int");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting decimal to int");
            #endregion

            #region decimal? - full method
            success = ConvertibleNullableDecimalValue.TryParseInt(DefaultValue);
            invalid1 = nullableInvalidValue1.TryParseInt(DefaultValue);
            invalid2 = nullableInvalidValue2.TryParseInt(DefaultValue);

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting decimal? to int");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting decimal? to int");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting decimal? to int");
            #endregion

            #region decimal? - without DefaultValue param
            success = ConvertibleNullableDecimalValue.TryParseInt();
            invalid1 = nullableInvalidValue1.TryParseInt();
            invalid2 = nullableInvalidValue2.TryParseInt();

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting decimal? to int");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting decimal? to int");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting decimal? to int");
            #endregion

        }

        /// <summary>
        /// Test TryParseInt method from double and nullable double values
        /// </summary>
        [TestMethod]
        public void TryParseInt_FromDoubleAndNullableDouble()
        {
            const double invalidValue1 = double.MaxValue;
            double? nullableInvalidValue1 = double.MaxValue;
            const double invalidValue2 = double.MinValue;
            double? nullableInvalidValue2 = double.MinValue;
            
            #region double - full method
            var success = ConvertibleDoubleValue.TryParseInt(DefaultValue);
            var invalid1 = invalidValue1.TryParseInt(DefaultValue);
            var invalid2 = invalidValue2.TryParseInt(DefaultValue);

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting double to int");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting double to int");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting double to int");
            #endregion

            #region double - without DefaultValue param
            success = ConvertibleDoubleValue.TryParseInt();
            invalid1 = invalidValue1.TryParseInt();
            invalid2 = invalidValue2.TryParseInt();

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting double to int");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting double to int");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting double to int");
            #endregion

            #region double? - full method
            success = ConvertibleNullableDoubleValue.TryParseInt(DefaultValue);
            invalid1 = nullableInvalidValue1.TryParseInt(DefaultValue);
            invalid2 = nullableInvalidValue2.TryParseInt(DefaultValue);

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting double? to int");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting double? to int");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting double? to int");
            #endregion

            #region double? - without DefaultValue param
            success = ConvertibleNullableDoubleValue.TryParseInt();
            invalid1 = nullableInvalidValue1.TryParseInt();
            invalid2 = nullableInvalidValue2.TryParseInt();

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting double? to int");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting double? to int");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting double? to int");
            #endregion

        }

        /// <summary>
        /// Test TryParseInt method from float and nullable float values
        /// </summary>
        [TestMethod]
        public void TryParseInt_FromFloatAndNullableFloat()
        {
            const float invalidValue1 = float.MaxValue;
            float? nullableInvalidValue1 = float.MaxValue;
            const float invalidValue2 = float.MinValue;
            float? nullableInvalidValue2 = float.MinValue;
            
            #region float - full method
            var success = ConvertibleFloatValue.TryParseInt(DefaultValue);
            var invalid1 = invalidValue1.TryParseInt(DefaultValue);
            var invalid2 = invalidValue2.TryParseInt(DefaultValue);

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting float to int");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting float to int");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting float to int");
            #endregion

            #region float - without DefaultValue param
            success = ConvertibleFloatValue.TryParseInt();
            invalid1 = invalidValue1.TryParseInt();
            invalid2 = invalidValue2.TryParseInt();

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting float to int");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting float to int");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting float to int");
            #endregion

            #region float? - full method
            success = ConvertibleNullableFloatValue.TryParseInt(DefaultValue);
            invalid1 = nullableInvalidValue1.TryParseInt(DefaultValue);
            invalid2 = nullableInvalidValue2.TryParseInt(DefaultValue);

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting float? to int");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting float? to int");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting float? to int");
            #endregion

            #region float? - without DefaultValue param
            success = ConvertibleNullableFloatValue.TryParseInt();
            invalid1 = nullableInvalidValue1.TryParseInt();
            invalid2 = nullableInvalidValue2.TryParseInt();

            Assert.AreEqual(success, ConvertibleIntValue, "Error converting float? to int");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting float? to int");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting float? to int");
            #endregion

        }

        /// <summary>
        /// Teste method TryParseInt from object value
        /// </summary>
        [TestMethod]
        public void TryParseInt_FromObject()
        {
            var objectValid = (object)1;
            var objectInvalid = (object)"a";

            Assert.AreEqual(objectValid.TryParseInt(), Int32.Parse(objectValid.ToString()), "Error converting object value to int32");
            Assert.AreEqual(objectInvalid.TryParseInt(), BasePrimitivesExtensions.GetDefaultIntConversionValue(), "Error converting object value to int32");

            Assert.AreEqual(objectValid.TryParseInt(2), Int32.Parse(objectValid.ToString()), "Error converting object value to int32");
            Assert.AreEqual(objectInvalid.TryParseInt(2), 2, "Error converting object value to int32");
        }

        /// <summary>
        /// Teste method TryParseIntArray and overload
        /// </summary>
        [TestMethod]
        public void TryParseIntArray()
        {
            const string successValue1 = "10";
            const string successValue2 = "20";
            var errorValue1 = double.MaxValue.ToString(CultureInfo.InvariantCulture);
            var errorValue2 = double.MinValue.ToString(CultureInfo.InvariantCulture);

            var successByteValues = new[] { successValue1.TryParseInt(), successValue2.TryParseInt() };
            var successValues = new[] { successValue1, successValue2 };
            var errorValues = new[] { errorValue1, errorValue2 };
            var mixedValues = new[] { successValue1, successValue2, errorValue1, errorValue2 };

            #region full method (with number format), without default, dont return defult conversion
            var successConversion = string.Join(",", successValues).TryParseIntArray(null, false,
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(successConversion, "Error converting string to int array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to int array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to int array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to int array");

            var falseConversions = string.Join(",", errorValues).TryParseIntArray(null, false,
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(falseConversions, "Error converting string to int array");
            Assert.IsFalse(falseConversions.Any(), "Error converting string to int array");

            var mixedConversions = string.Join(",", mixedValues).TryParseIntArray(null, false,
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(mixedConversions, "Error converting string to int array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a)), "Error converting string to int array");
            Assert.IsTrue(mixedConversions.Count() == successByteValues.Count(), "Error converting string to int array");
            #endregion

            #region partial method (with number format), without default
            successConversion = string.Join(",", successValues).TryParseIntArray(null,
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(successConversion, "Error converting string to int array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to int array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to int array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to int array");

            falseConversions = string.Join(",", errorValues).TryParseIntArray(null,
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(falseConversions, "Error converting string to int array");
            Assert.IsFalse(falseConversions.Any(a=>!a.Equals(BasePrimitivesExtensions.GetDefaultIntConversionValue())), "Error converting string to int array");

            mixedConversions = string.Join(",", mixedValues).TryParseIntArray(null,
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(mixedConversions, "Error converting string to int array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a) && !a.Equals(BasePrimitivesExtensions.GetDefaultIntConversionValue())), "Error converting string to int array");
            Assert.IsTrue((mixedConversions.Count() - falseConversions.Count()) == successByteValues.Count(), "Error converting string to int array");
            #endregion

            #region simple method (with number format)
            successConversion = string.Join(",", successValues).TryParseIntArray(
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(successConversion, "Error converting string to int array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to int array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to int array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to int array");

            falseConversions = string.Join(",", errorValues).TryParseIntArray(
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(falseConversions, "Error converting string to int array");
            Assert.IsFalse(falseConversions.Any(a => !a.Equals(BasePrimitivesExtensions.GetDefaultIntConversionValue())), "Error converting string to int array");

            mixedConversions = string.Join(",", mixedValues).TryParseIntArray(
                BasePrimitivesExtensions.GetDefaultIntNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(mixedConversions, "Error converting string to int array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a) && !a.Equals(BasePrimitivesExtensions.GetDefaultIntConversionValue())), "Error converting string to int array");
            Assert.IsTrue((mixedConversions.Count() - falseConversions.Count()) == successByteValues.Count(), "Error converting string to int array");
            #endregion

            #region full method (without number format), without default, dont return defult conversion
            successConversion = string.Join(",", successValues).TryParseIntArray(null, false);
            Assert.IsNotNull(successConversion, "Error converting string to int array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to int array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to int array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to int array");

            falseConversions = string.Join(",", errorValues).TryParseIntArray(null, false);
            Assert.IsNotNull(falseConversions, "Error converting string to int array");
            Assert.IsFalse(falseConversions.Any(a => !a.Equals(BasePrimitivesExtensions.GetDefaultIntConversionValue())), "Error converting string to int array");

            mixedConversions = string.Join(",", mixedValues).TryParseIntArray(null, false);
            Assert.IsNotNull(mixedConversions, "Error converting string to int array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a) && !a.Equals(BasePrimitivesExtensions.GetDefaultIntConversionValue())), "Error converting string to int array");
            Assert.IsTrue((mixedConversions.Count() - falseConversions.Count()) == successByteValues.Count(), "Error converting string to int array");
            #endregion

            #region partial method (without number format), without default
            successConversion = string.Join(",", successValues).TryParseIntArray(null);
            Assert.IsNotNull(successConversion, "Error converting string to int array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to int array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to int array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to int array");

            falseConversions = string.Join(",", errorValues).TryParseIntArray(null);
            Assert.IsNotNull(falseConversions, "Error converting string to int array");
            Assert.IsFalse(falseConversions.Any(a => !a.Equals(BasePrimitivesExtensions.GetDefaultIntConversionValue())), "Error converting string to int array");

            mixedConversions = string.Join(",", mixedValues).TryParseIntArray(null);
            Assert.IsNotNull(mixedConversions, "Error converting string to int array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a) && !a.Equals(BasePrimitivesExtensions.GetDefaultIntConversionValue())), "Error converting string to int array");
            Assert.IsTrue((mixedConversions.Count() - falseConversions.Count()) == successByteValues.Count(), "Error converting string to int array");
            #endregion

            #region simple method (without number format)
            successConversion = string.Join(",", successValues).TryParseIntArray();
            Assert.IsNotNull(successConversion, "Error converting string to int array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to int array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to int array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to int array");

            falseConversions = string.Join(",", errorValues).TryParseIntArray();
            Assert.IsNotNull(falseConversions, "Error converting string to int array");
            Assert.IsFalse(falseConversions.Any(a => !a.Equals(BasePrimitivesExtensions.GetDefaultIntConversionValue())), "Error converting string to int array");

            mixedConversions = string.Join(",", mixedValues).TryParseIntArray();
            Assert.IsNotNull(mixedConversions, "Error converting string to int array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a) && !a.Equals(BasePrimitivesExtensions.GetDefaultIntConversionValue())), "Error converting string to int array");
            Assert.IsTrue((mixedConversions.Count() - falseConversions.Count()) == successByteValues.Count(), "Error converting string to int array");
            #endregion
        }

        /// <summary>
        /// Teste method IsValidInt and overloads
        /// </summary>
        [TestMethod]
        public void IsValidInt()
        {
            Assert.IsFalse(long.MaxValue.ToString(CultureInfo.InvariantCulture).IsValidInt());
            Assert.IsFalse(long.MinValue.ToString(CultureInfo.InvariantCulture).IsValidInt());
            Assert.IsFalse("1.1".IsValidInt());
            Assert.IsFalse("".IsValidInt());
            Assert.IsFalse("jorn".IsValidInt());
            Assert.IsFalse("false".IsValidInt());
            Assert.IsTrue("1".IsValidInt());
            Assert.IsTrue("10".IsValidInt());
            Assert.IsTrue("0".IsValidInt());
            Assert.IsTrue("-1".IsValidInt());

            Assert.IsFalse(long.MaxValue.ToString(CultureInfo.InvariantCulture).IsValidInt(NumberStyle, Culture));
            Assert.IsFalse(long.MinValue.ToString(CultureInfo.InvariantCulture).IsValidInt(NumberStyle, Culture));
            Assert.IsFalse("1.1".IsValidInt(NumberStyle, Culture));
            Assert.IsFalse("".IsValidInt(NumberStyle, Culture));
            Assert.IsFalse("jorn".IsValidInt(NumberStyle, Culture));
            Assert.IsFalse("false".IsValidInt(NumberStyle, Culture));
            Assert.IsTrue("1".IsValidInt(NumberStyle, Culture));
            Assert.IsTrue("10".IsValidInt(NumberStyle, Culture));
            Assert.IsTrue("0".IsValidInt(NumberStyle, Culture));
            Assert.IsTrue("-1".IsValidInt(NumberStyle, Culture));
        }
    }
}
