using System;
using System.Globalization;
using System.Linq;
using DevUtils.PrimitivesExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.PrimitivesExtensions
{
    /// <summary>
    /// Test class ByteExtensions
    /// </summary>
    [TestClass]
    public class ByteExtensions
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
        private byte DefaultValue { get; set; }
        private NumberStyles NumberStyle { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Test constructor
        /// </summary>
        public ByteExtensions()
        {
            Culture = CultureInfo.CurrentCulture;
            DefaultValue = 100;

            ConvertibleStringValue = "200";
            ConvertibleByteValue = 200;
            ConvertibleNullableByteValue = 200;
            ConvertibleNullableDecimalValue = ConvertibleNullableByteValue;
            ConvertibleDecimalValue = ConvertibleByteValue;
            ConvertibleNullableShortValue = ConvertibleNullableByteValue;
            ConvertibleShortValue = ConvertibleByteValue;
            ConvertibleNullableLongValue = ConvertibleNullableByteValue;
            ConvertibleLongValue = ConvertibleByteValue;
            ConvertibleNullableIntValue = ConvertibleNullableByteValue;
            ConvertibleIntValue = ConvertibleByteValue;
            ConvertibleNullableDoubleValue = ConvertibleNullableByteValue + 0.2d;
            ConvertibleDoubleValue = ConvertibleByteValue + 0.2d;
            ConvertibleNullableFloatValue = ConvertibleNullableByteValue + 0.2f;
            ConvertibleFloatValue = ConvertibleByteValue + 0.2f;
            NumberStyle = NumberStyles.None;
            
        } 
        #endregion

        /// <summary>
        /// Test TryParseByte method from string value
        /// </summary>
        [TestMethod]
        public void TryParseByte_FromString()
        {
            var invalidValue1 = double.MaxValue.ToString(CultureInfo.InvariantCulture);
            var invalidValue2 = double.MinValue.ToString(CultureInfo.InvariantCulture);

            #region full method
            var success = ConvertibleStringValue.TryParseByte(DefaultValue, 
                BasePrimitivesExtensions.GetDefaultByteAllowDefaultConversion(), 
                BasePrimitivesExtensions.GetDefaultByteNumberStyle(), 
                BasePrimitivesExtensions.GetCurrentCulture());

            var invalid1 = invalidValue1.TryParseByte(DefaultValue, 
                BasePrimitivesExtensions.GetDefaultByteAllowDefaultConversion(), 
                BasePrimitivesExtensions.GetDefaultByteNumberStyle(), 
                BasePrimitivesExtensions.GetCurrentCulture());

            var invalid2 = invalidValue2.TryParseByte(DefaultValue, 
                BasePrimitivesExtensions.GetDefaultByteAllowDefaultConversion(), 
                BasePrimitivesExtensions.GetDefaultByteNumberStyle(), 
                BasePrimitivesExtensions.GetCurrentCulture());

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting string to byte");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to byte");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to byte");
            #endregion

            #region without allowZero param
            success = ConvertibleStringValue.TryParseByte(DefaultValue,
                BasePrimitivesExtensions.GetDefaultByteNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid1 = invalidValue1.TryParseByte(DefaultValue,
                BasePrimitivesExtensions.GetDefaultByteNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid2 = invalidValue2.TryParseByte(DefaultValue,
                BasePrimitivesExtensions.GetDefaultByteNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting string to byte");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to byte");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to byte");
            #endregion

            #region without allowZero and DefaultValue params
            success = ConvertibleStringValue.TryParseByte(BasePrimitivesExtensions.GetDefaultByteNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid1 = invalidValue1.TryParseByte(BasePrimitivesExtensions.GetDefaultByteNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            invalid2 = invalidValue2.TryParseByte(BasePrimitivesExtensions.GetDefaultByteNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting string to byte");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting string to byte");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting string to byte");
            #endregion

            #region without number style and culture params
            success = ConvertibleStringValue.TryParseByte(DefaultValue,
                BasePrimitivesExtensions.GetDefaultByteAllowDefaultConversion());

            invalid1 = invalidValue1.TryParseByte(DefaultValue,
                BasePrimitivesExtensions.GetDefaultByteAllowDefaultConversion());

            invalid2 = invalidValue2.TryParseByte(DefaultValue,
                BasePrimitivesExtensions.GetDefaultByteAllowDefaultConversion());

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting string to byte");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to byte");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to byte");
            #endregion

            #region without number style, culture and allowZero params
            success = ConvertibleStringValue.TryParseByte(DefaultValue);
            invalid1 = invalidValue1.TryParseByte(DefaultValue);
            invalid2 = invalidValue2.TryParseByte(DefaultValue);

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting string to byte");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting string to byte");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting string to byte");
            #endregion

            #region simple conversion
            success = ConvertibleStringValue.TryParseByte();
            invalid1 = invalidValue1.TryParseByte();
            invalid2 = invalidValue2.TryParseByte();

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting string to byte");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting string to byte");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting string to byte");
            #endregion
        }

        /// <summary>
        /// Test TryParseByte method from nullable byte value
        /// </summary>
        [TestMethod]
        public void TryParseByte_NullableByte()
        {
            #region full method
            var success = ConvertibleNullableByteValue.TryParseByte(DefaultValue);
            var invalid = ((byte?)null).TryParseByte(DefaultValue);

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting nullable byte to byte");
            Assert.AreEqual(invalid, DefaultValue, "Error converting nullable byte to byte");
            #endregion

            #region simple method
            success = ConvertibleNullableByteValue.TryParseByte();
            invalid = ((byte?)null).TryParseByte();

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting nullable byte to byte");
            Assert.AreEqual(invalid, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting nullable byte to byte");
            #endregion
        }

        /// <summary>
        /// Test TryParseByte method from short and nullable short values
        /// </summary>
        [TestMethod]
        public void TryParseByte_FromShortAndNullableShort()
        {
            const short invalidValue1 = short.MaxValue;
            short? nullableInvalidValue1 = short.MaxValue;
            const short invalidValue2 = short.MinValue;
            short? nullableInvalidValue2 = short.MinValue;
            
            #region short - full method
            var success = ConvertibleShortValue.TryParseByte(DefaultValue);
            var invalid1 = invalidValue1.TryParseByte(DefaultValue);
            var invalid2 = invalidValue2.TryParseByte(DefaultValue);

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting short to byte");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting short to byte");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting short to byte");
            #endregion

            #region short - without DefaultValue param
            success = ConvertibleShortValue.TryParseByte();
            invalid1 = invalidValue1.TryParseByte();
            invalid2 = invalidValue2.TryParseByte();

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting short to byte");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting short to byte");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting short to byte");
            #endregion

            #region short? - full method
            success = ConvertibleNullableShortValue.TryParseByte(DefaultValue);
            invalid1 = nullableInvalidValue1.TryParseByte(DefaultValue);
            invalid2 = nullableInvalidValue2.TryParseByte(DefaultValue);

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting short? to byte");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting short? to byte");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting short? to byte");
            #endregion

            #region short? - without DefaultValue param
            success = ConvertibleNullableShortValue.TryParseByte();
            invalid1 = nullableInvalidValue1.TryParseByte();
            invalid2 = nullableInvalidValue2.TryParseByte();

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting short? to byte");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting short? to byte");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting short? to byte");
            #endregion

        }
        
        /// <summary>
        /// Test TryParseByte method from int and nullable int values
        /// </summary>
        [TestMethod]
        public void TryParseByte_FromIntAndNullableInt()
        {
            const int invalidValue1 = int.MaxValue;
            int? nullableInvalidValue1 = int.MaxValue;
            const int invalidValue2 = int.MinValue;
            int? nullableInvalidValue2 = int.MinValue;
            
            #region int - full method
            var success = ConvertibleIntValue.TryParseByte(DefaultValue);
            var invalid1 = invalidValue1.TryParseByte(DefaultValue);
            var invalid2 = invalidValue2.TryParseByte(DefaultValue);

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting int to byte");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting int to byte");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting int to byte");
            #endregion

            #region int - without DefaultValue param
            success = ConvertibleIntValue.TryParseByte();
            invalid1 = invalidValue1.TryParseByte();
            invalid2 = invalidValue2.TryParseByte();

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting int to byte");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting int to byte");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting int to byte");
            #endregion

            #region int? - full method
            success = ConvertibleNullableIntValue.TryParseByte(DefaultValue);
            invalid1 = nullableInvalidValue1.TryParseByte(DefaultValue);
            invalid2 = nullableInvalidValue2.TryParseByte(DefaultValue);

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting int? to byte");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting int? to byte");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting int? to byte");
            #endregion

            #region int? - without DefaultValue param
            success = ConvertibleNullableIntValue.TryParseByte();
            invalid1 = nullableInvalidValue1.TryParseByte();
            invalid2 = nullableInvalidValue2.TryParseByte();

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting int? to byte");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting int? to byte");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting int? to byte");
            #endregion
            
        }

        /// <summary>
        /// Test TryParseByte method from long and nullable long values
        /// </summary>
        [TestMethod]
        public void TryParseByte_FromLongAndNullableLong()
        {
            const long invalidValue1 = long.MaxValue;
            long? nullableInvalidValue1 = long.MaxValue;
            const long invalidValue2 = long.MinValue;
            long? nullableInvalidValue2 = long.MinValue;
            
            #region long - full method
            var success = ConvertibleLongValue.TryParseByte(DefaultValue);
            var invalid1 = invalidValue1.TryParseByte(DefaultValue);
            var invalid2 = invalidValue2.TryParseByte(DefaultValue);

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting long to byte");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting long to byte");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting long to byte");
            #endregion

            #region long - without DefaultValue param
            success = ConvertibleLongValue.TryParseByte();
            invalid1 = invalidValue1.TryParseByte();
            invalid2 = invalidValue2.TryParseByte();

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting long to byte");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting long to byte");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting long to byte");
            #endregion

            #region long? - full method
            success = ConvertibleNullableLongValue.TryParseByte(DefaultValue);
            invalid1 = nullableInvalidValue1.TryParseByte(DefaultValue);
            invalid2 = nullableInvalidValue2.TryParseByte(DefaultValue);

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting long? to byte");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting long? to byte");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting long? to byte");
            #endregion

            #region long? - without DefaultValue param
            success = ConvertibleNullableLongValue.TryParseByte();
            invalid1 = nullableInvalidValue1.TryParseByte();
            invalid2 = nullableInvalidValue2.TryParseByte();

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting long? to byte");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting long? to byte");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting long? to byte");
            #endregion

        }

        /// <summary>
        /// Test TryParseByte method from decimal and nullable decimal values
        /// </summary>
        [TestMethod]
        public void TryParseByte_FromDecimalAndNullableDecimal()
        {
            const decimal invalidValue1 = decimal.MaxValue;
            decimal? nullableInvalidValue1 = decimal.MaxValue;
            const decimal invalidValue2 = decimal.MinValue;
            decimal? nullableInvalidValue2 = decimal.MinValue;
            
            #region decimal - full method
            var success = ConvertibleDecimalValue.TryParseByte(DefaultValue);
            var invalid1 = invalidValue1.TryParseByte(DefaultValue);
            var invalid2 = invalidValue2.TryParseByte(DefaultValue);

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting decimal to byte");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting decimal to byte");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting decimal to byte");
            #endregion

            #region decimal - without DefaultValue param
            success = ConvertibleDecimalValue.TryParseByte();
            invalid1 = invalidValue1.TryParseByte();
            invalid2 = invalidValue2.TryParseByte();

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting decimal to byte");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting decimal to byte");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting decimal to byte");
            #endregion

            #region decimal? - full method
            success = ConvertibleNullableDecimalValue.TryParseByte(DefaultValue);
            invalid1 = nullableInvalidValue1.TryParseByte(DefaultValue);
            invalid2 = nullableInvalidValue2.TryParseByte(DefaultValue);

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting decimal? to byte");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting decimal? to byte");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting decimal? to byte");
            #endregion

            #region decimal? - without DefaultValue param
            success = ConvertibleNullableDecimalValue.TryParseByte();
            invalid1 = nullableInvalidValue1.TryParseByte();
            invalid2 = nullableInvalidValue2.TryParseByte();

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting decimal? to byte");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting decimal? to byte");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting decimal? to byte");
            #endregion

        }

        /// <summary>
        /// Test TryParseByte method from double and nullable double values
        /// </summary>
        [TestMethod]
        public void TryParseByte_FromDoubleAndNullableDouble()
        {
            const double invalidValue1 = double.MaxValue;
            double? nullableInvalidValue1 = double.MaxValue;
            const double invalidValue2 = double.MinValue;
            double? nullableInvalidValue2 = double.MinValue;
            
            #region double - full method
            var success = ConvertibleDoubleValue.TryParseByte(DefaultValue);
            var invalid1 = invalidValue1.TryParseByte(DefaultValue);
            var invalid2 = invalidValue2.TryParseByte(DefaultValue);

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting double to byte");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting double to byte");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting double to byte");
            #endregion

            #region double - without DefaultValue param
            success = ConvertibleDoubleValue.TryParseByte();
            invalid1 = invalidValue1.TryParseByte();
            invalid2 = invalidValue2.TryParseByte();

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting double to byte");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting double to byte");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting double to byte");
            #endregion

            #region double? - full method
            success = ConvertibleNullableDoubleValue.TryParseByte(DefaultValue);
            invalid1 = nullableInvalidValue1.TryParseByte(DefaultValue);
            invalid2 = nullableInvalidValue2.TryParseByte(DefaultValue);

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting double? to byte");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting double? to byte");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting double? to byte");
            #endregion

            #region double? - without DefaultValue param
            success = ConvertibleNullableDoubleValue.TryParseByte();
            invalid1 = nullableInvalidValue1.TryParseByte();
            invalid2 = nullableInvalidValue2.TryParseByte();

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting double? to byte");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting double? to byte");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting double? to byte");
            #endregion

        }

        /// <summary>
        /// Test TryParseByte method from float and nullable float values
        /// </summary>
        [TestMethod]
        public void TryParseByte_FromFloatAndNullableFloat()
        {
            const float invalidValue1 = float.MaxValue;
            float? nullableInvalidValue1 = float.MaxValue;
            const float invalidValue2 = float.MinValue;
            float? nullableInvalidValue2 = float.MinValue;
            
            #region float - full method
            var success = ConvertibleFloatValue.TryParseByte(DefaultValue);
            var invalid1 = invalidValue1.TryParseByte(DefaultValue);
            var invalid2 = invalidValue2.TryParseByte(DefaultValue);

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting float to byte");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting float to byte");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting float to byte");
            #endregion

            #region float - without DefaultValue param
            success = ConvertibleFloatValue.TryParseByte();
            invalid1 = invalidValue1.TryParseByte();
            invalid2 = invalidValue2.TryParseByte();

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting float to byte");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting float to byte");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting float to byte");
            #endregion

            #region float? - full method
            success = ConvertibleNullableFloatValue.TryParseByte(DefaultValue);
            invalid1 = nullableInvalidValue1.TryParseByte(DefaultValue);
            invalid2 = nullableInvalidValue2.TryParseByte(DefaultValue);

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting float? to byte");
            Assert.AreEqual(invalid1, DefaultValue, "Error converting float? to byte");
            Assert.AreEqual(invalid2, DefaultValue, "Error converting float? to byte");
            #endregion

            #region float? - without DefaultValue param
            success = ConvertibleNullableFloatValue.TryParseByte();
            invalid1 = nullableInvalidValue1.TryParseByte();
            invalid2 = nullableInvalidValue2.TryParseByte();

            Assert.AreEqual(success, ConvertibleByteValue, "Error converting float? to byte");
            Assert.AreEqual(invalid1, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting float? to byte");
            Assert.AreEqual(invalid2, BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting float? to byte");
            #endregion

        }

        /// <summary>
        /// Teste method TryParseByte from object value
        /// </summary>
        [TestMethod]
        public void TryParseByte_FromObject()
        {
            var objectValid = (object)1;
            var objectInvalid = (object)"a";

            Assert.AreEqual(objectValid.TryParseByte(), Byte.Parse(objectValid.ToString()), "Error converting object value to byte");
            Assert.AreEqual(objectInvalid.TryParseByte(), BasePrimitivesExtensions.GetDefaultByteConversionValue(), "Error converting object value to byte");

            Assert.AreEqual(objectValid.TryParseByte(2), Byte.Parse(objectValid.ToString()), "Error converting object value to byte");
            Assert.AreEqual(objectInvalid.TryParseByte(2), 2, "Error converting object value to byte");
        }

        /// <summary>
        /// Teste method TryParseByteArray and overload
        /// </summary>
        [TestMethod]
        public void TryParseByteArray()
        {
            const string successValue1 = "10";
            const string successValue2 = "20";
            var errorValue1 = double.MaxValue.ToString(CultureInfo.InvariantCulture);
            var errorValue2 = double.MinValue.ToString(CultureInfo.InvariantCulture);

            var successByteValues = new[] { successValue1.TryParseByte(), successValue2.TryParseByte() };
            var successValues = new[] { successValue1, successValue2 };
            var errorValues = new[] { errorValue1, errorValue2 };
            var mixedValues = new[] { successValue1, successValue2, errorValue1, errorValue2};

            #region full method (with number format), without default, dont return defult conversion
            var successConversion = string.Join(",", successValues).TryParseByteArray(null, false, 
                BasePrimitivesExtensions.GetDefaultByteNumberStyle(), 
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(successConversion, "Error converting string to byte array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to byte array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to byte array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to byte array");

            var falseConversions = string.Join(",", errorValues).TryParseByteArray(null, false,
                BasePrimitivesExtensions.GetDefaultByteNumberStyle(), 
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(falseConversions, "Error converting string to byte array");
            Assert.IsFalse(falseConversions.Any(), "Error converting string to byte array");

            var mixedConversions = string.Join(",", mixedValues).TryParseByteArray(null, false,
                BasePrimitivesExtensions.GetDefaultByteNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(mixedConversions, "Error converting string to byte array");
            Assert.IsFalse(mixedConversions.Any(a=> !successByteValues.Contains(a)), "Error converting string to byte array");
            Assert.IsTrue(mixedConversions.Count() == successByteValues.Count(), "Error converting string to byte array");
            #endregion

            #region partial method (with number format), without default
            successConversion = string.Join(",", successValues).TryParseByteArray(null, 
                BasePrimitivesExtensions.GetDefaultByteNumberStyle(), 
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(successConversion, "Error converting string to byte array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to byte array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to byte array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to byte array");

            falseConversions = string.Join(",", errorValues).TryParseByteArray(null,
                BasePrimitivesExtensions.GetDefaultByteNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(falseConversions, "Error converting string to byte array");
            Assert.IsFalse(falseConversions.Any(f => !f.Equals(BasePrimitivesExtensions.GetDefaultByteConversionValue())), "Error converting string to byte array");

            mixedConversions = string.Join(",", mixedValues).TryParseByteArray(null,
                BasePrimitivesExtensions.GetDefaultByteNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(mixedConversions, "Error converting string to byte array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a) && !a.Equals(BasePrimitivesExtensions.GetDefaultByteConversionValue())), "Error converting string to byte array");
            Assert.IsTrue((mixedConversions.Count() - falseConversions.Count()) == successByteValues.Count(), "Error converting string to byte array");
            #endregion

            #region simple method (with number format)
            successConversion = string.Join(",", successValues).TryParseByteArray(
                BasePrimitivesExtensions.GetDefaultByteNumberStyle(), 
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(successConversion, "Error converting string to byte array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to byte array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to byte array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to byte array");

            falseConversions = string.Join(",", errorValues).TryParseByteArray(
                BasePrimitivesExtensions.GetDefaultByteNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(falseConversions, "Error converting string to byte array");
            Assert.IsFalse(falseConversions.Any(a => !a.Equals(BasePrimitivesExtensions.GetDefaultByteConversionValue())), "Error converting string to byte array");

            mixedConversions = string.Join(",", mixedValues).TryParseByteArray(
                BasePrimitivesExtensions.GetDefaultByteNumberStyle(),
                BasePrimitivesExtensions.GetCurrentCulture());
            Assert.IsNotNull(mixedConversions, "Error converting string to byte array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a) && !a.Equals(BasePrimitivesExtensions.GetDefaultByteConversionValue())), "Error converting string to byte array");
            Assert.IsTrue((mixedConversions.Count() - falseConversions.Count()) == successByteValues.Count(), "Error converting string to byte array");
            #endregion

            #region full method (without number format), without default, dont return defult conversion
            successConversion = string.Join(",", successValues).TryParseByteArray(null, false);
            Assert.IsNotNull(successConversion, "Error converting string to byte array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to byte array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to byte array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to byte array");

            falseConversions = string.Join(",", errorValues).TryParseByteArray(null, false);
            Assert.IsNotNull(falseConversions, "Error converting string to byte array");
            Assert.IsFalse(falseConversions.Any(), "Error converting string to byte array");

            mixedConversions = string.Join(",", mixedValues).TryParseByteArray(null, false);
            Assert.IsNotNull(mixedConversions, "Error converting string to byte array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a)), "Error converting string to byte array");
            Assert.IsTrue(mixedConversions.Count() == successByteValues.Count(), "Error converting string to byte array");
            #endregion

            #region partial method (without number format), without default
            successConversion = string.Join(",", successValues).TryParseByteArray(null);
            Assert.IsNotNull(successConversion, "Error converting string to byte array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to byte array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to byte array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to byte array");

            falseConversions = string.Join(",", errorValues).TryParseByteArray(null);
            Assert.IsNotNull(falseConversions, "Error converting string to byte array");
            Assert.IsFalse(falseConversions.Any(a => !a.Equals(BasePrimitivesExtensions.GetDefaultByteConversionValue())), "Error converting string to byte array");

            mixedConversions = string.Join(",", mixedValues).TryParseByteArray(null);
            Assert.IsNotNull(mixedConversions, "Error converting string to byte array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a) && !a.Equals(BasePrimitivesExtensions.GetDefaultByteConversionValue())), "Error converting string to byte array");
            Assert.IsTrue((mixedConversions.Count() - falseConversions.Count()) == successByteValues.Count(), "Error converting string to byte array");
            #endregion

            #region simple method (without number format)
            successConversion = string.Join(",", successValues).TryParseByteArray();
            Assert.IsNotNull(successConversion, "Error converting string to byte array");
            Assert.IsTrue(successConversion.Any(), "Error converting string to byte array");
            Assert.IsFalse(successConversion.Any(a => !successByteValues.Contains(a)), "Error converting string to byte array");
            Assert.IsTrue(successConversion.Count() == successByteValues.Count(), "Error converting string to byte array");

            falseConversions = string.Join(",", errorValues).TryParseByteArray();
            Assert.IsNotNull(falseConversions, "Error converting string to byte array");
            Assert.IsFalse(falseConversions.Any(a => !a.Equals(BasePrimitivesExtensions.GetDefaultByteConversionValue())), "Error converting string to byte array");

            mixedConversions = string.Join(",", mixedValues).TryParseByteArray();
            Assert.IsNotNull(mixedConversions, "Error converting string to byte array");
            Assert.IsFalse(mixedConversions.Any(a => !successByteValues.Contains(a) && !a.Equals(BasePrimitivesExtensions.GetDefaultByteConversionValue())), "Error converting string to byte array");
            Assert.IsTrue((mixedConversions.Count() - falseConversions.Count()) == successByteValues.Count(), "Error converting string to byte array");
            #endregion
        }

        /// <summary>
        /// Teste method IsValidByte and overloads
        /// </summary>
        [TestMethod]
        public void IsValidByte()
        {
            Assert.IsFalse("-1".IsValidByte());
            Assert.IsFalse("1.1".IsValidByte());
            Assert.IsFalse("".IsValidByte());
            Assert.IsFalse("jorn".IsValidByte());
            Assert.IsFalse("false".IsValidByte());
            Assert.IsFalse("400".IsValidByte());
            Assert.IsTrue("1".IsValidByte());
            Assert.IsTrue("10".IsValidByte());
            Assert.IsTrue("0".IsValidByte());

            Assert.IsFalse("-1".IsValidByte(NumberStyle, Culture));
            Assert.IsFalse("1.1".IsValidByte(NumberStyle, Culture));
            Assert.IsFalse("".IsValidByte(NumberStyle, Culture));
            Assert.IsFalse("jorn".IsValidByte(NumberStyle, Culture));
            Assert.IsFalse("false".IsValidByte(NumberStyle, Culture));
            Assert.IsFalse("400".IsValidByte(NumberStyle, Culture));
            Assert.IsTrue("1".IsValidByte(NumberStyle, Culture));
            Assert.IsTrue("10".IsValidByte(NumberStyle, Culture));
            Assert.IsTrue("0".IsValidByte(NumberStyle, Culture));
        }
    }
}
