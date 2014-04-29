using System.Globalization;

namespace DevUtils.PrimitivesExtensions
{
    /// <summary>
    /// Base primitive extensions default data
    /// </summary>
    public class BasePrimitivesExtensions
    {
        #region params
        //Bit extensions
        private const bool DefaultBoolConversion = false;
        private const bool DefaultBoolArrayAllowDefaultConversion = false;

        //Byte extensions
        private const NumberStyles DefaultByteNumberStyle = NumberStyles.None;
        private const byte DefaultByteConversion = 0;
        private const bool DefaultByteAllowDefaultConversion = false;
        private const bool DefaultByteArrayAllowDefaultConversion = false;

        //Int16 extensions
        private const NumberStyles DefaultShortNumberStyle = NumberStyles.Integer;
        private const short DefaultShortConversion = 0;
        private const bool DefaultShortAllowDefaultConversion = false;
        private const bool DefaultShortArrayAllowDefaultConversion = false;

        //Int32 extensions
        private const NumberStyles DefaultIntNumberStyle = NumberStyles.Integer;
        private const int DefaultIntConversion = 0;
        private const bool DefaultIntAllowDefaultConversion = false;
        private const bool DefaultIntArrayAllowDefaultConversion = false;

        //Int64 extensions
        private const NumberStyles DefaultLongNumberStyle = NumberStyles.Integer;
        private const long DefaultLongConversion = 0;
        private const bool DefaultLongAllowDefaultConversion = false;
        private const bool DefaultLongArrayAllowDefaultConversion = false;

        //Decimal extensions
        private const NumberStyles DefaultDecimalNumberStyle = NumberStyles.Float;
        private const decimal DefaultDecimalConversion = 0;
        private const bool DefaultDecimalAllowDefaultConversion = false;
        private const bool DefaultDecimalArrayAllowDefaultConversion = false;

        //Double extensions
        private const NumberStyles DefaultDoubleNumberStyle = NumberStyles.Float;
        private const double DefaultDoubleConversion = 0;
        private const bool DefaultDoubleAllowDefaultConversion = false;
        private const bool DefaultDoubleArrayAllowDefaultConversion = false;

        //Float extensions
        private const NumberStyles DefaultFloatNumberStyle = NumberStyles.Float;
        private const float DefaultFloatConversion = 0;
        private const bool DefaultFloatAllowDefaultConversion = false;
        private const bool DefaultFloatArrayAllowDefaultConversion = false; 
        #endregion

        #region TryParseBool and TryParseBoolArray
        /// <summary>
        /// Get default bool conversion value
        /// </summary>
        /// <returns>DefaultBoolConversion</returns>
        public static bool GetDefaultBoolConversionValue()
        {
            return DefaultBoolConversion;
        }

        /// <summary>
        /// Get default bool array allow default conversion value
        /// </summary>
        /// <returns>DefaultBoolArrayAllowDefaultConversion</returns>
        public static bool GetDefaultBoolArrayAllowDefaultConversion()
        {
            return DefaultBoolArrayAllowDefaultConversion;
        }
        #endregion

        #region TryParseByte and TryParseByteArray
        /// <summary>
        /// Get default byte number style
        /// </summary>
        /// <returns>Byte NumberStyles</returns>
        public static NumberStyles GetDefaultByteNumberStyle()
        {
            return DefaultByteNumberStyle;
        }

        /// <summary>
        /// Get default byte conversion value
        /// </summary>
        /// <returns>DefaultByteConversion</returns>
        public static byte GetDefaultByteConversionValue()
        {
            return DefaultByteConversion;
        }

        /// <summary>
        /// Get default byte allow default conversion
        /// </summary>
        /// <returns>DefaultByteAllowDefaultConversion</returns>
        public static bool GetDefaultByteAllowDefaultConversion()
        {
            return DefaultByteAllowDefaultConversion;
        }

        /// <summary>
        /// Get default byte array allow default conversion value
        /// </summary>
        /// <returns>DefaultByteArrayAllowDefaultConversion</returns>
        public static bool GetDefaultByteArrayAllowDefaultConversion()
        {
            return DefaultByteArrayAllowDefaultConversion;
        }
        #endregion

        #region TryParseShort and TryParseShortArray
        /// <summary>
        /// Get default short number style
        /// </summary>
        /// <returns>Short NumberStyles</returns>
        public static NumberStyles GetDefaultShortNumberStyle()
        {
            return DefaultShortNumberStyle;
        }

        /// <summary>
        /// Get default short conversion value
        /// </summary>
        /// <returns>DefaultShortConversion</returns>
        public static short GetDefaultShortConversionValue()
        {
            return DefaultShortConversion;
        }

        /// <summary>
        /// Get default short allow default conversion
        /// </summary>
        /// <returns>DefaultShortAllowDefaultConversion</returns>
        public static bool GetDefaultShortAllowDefaultConversion()
        {
            return DefaultShortAllowDefaultConversion;
        }

        /// <summary>
        /// Get default short array allow default conversion value
        /// </summary>
        /// <returns>DefaultShortArrayAllowDefaultConversion</returns>
        public static bool GetDefaultShortArrayAllowDefaultConversion()
        {
            return DefaultShortArrayAllowDefaultConversion;
        }
        #endregion

        #region TryParseInt and TryParseIntArray
        /// <summary>
        /// Get default int number style
        /// </summary>
        /// <returns>Int NumberStyles</returns>
        public static NumberStyles GetDefaultIntNumberStyle()
        {
            return DefaultIntNumberStyle;
        }

        /// <summary>
        /// Get default int conversion value
        /// </summary>
        /// <returns>DefaultIntConversion</returns>
        public static int GetDefaultIntConversionValue()
        {
            return DefaultIntConversion;
        }

        /// <summary>
        /// Get default int allow default conversion
        /// </summary>
        /// <returns>DefaultIntAllowDefaultConversion</returns>
        public static bool GetDefaultIntAllowDefaultConversion()
        {
            return DefaultIntAllowDefaultConversion;
        }

        /// <summary>
        /// Get default int array allow default conversion value
        /// </summary>
        /// <returns>DefaultIntArrayAllowDefaultConversion</returns>
        public static bool GetDefaultIntArrayAllowDefaultConversion()
        {
            return DefaultIntArrayAllowDefaultConversion;
        }
        #endregion

        #region TryParseLong and TryParseLongArray
        /// <summary>
        /// Get default long number style
        /// </summary>
        /// <returns>Long NumberStyles</returns>
        public static NumberStyles GetDefaultLongNumberStyle()
        {
            return DefaultLongNumberStyle;
        }

        /// <summary>
        /// Get default long conversion value
        /// </summary>
        /// <returns>DefaultDecimalConversion</returns>
        public static long GetDefaultLongConversionValue()
        {
            return DefaultLongConversion;
        }

        /// <summary>
        /// Get default long allow default conversion
        /// </summary>
        /// <returns>DefaultLongAllowDefaultConversion</returns>
        public static bool GetDefaultLongAllowDefaultConversion()
        {
            return DefaultLongAllowDefaultConversion;
        }

        /// <summary>
        /// Get default long array allow default conversion value
        /// </summary>
        /// <returns>DefaultLongArrayAllowDefaultConversion</returns>
        public static bool GetDefaultLongArrayAllowDefaultConversion()
        {
            return DefaultLongArrayAllowDefaultConversion;
        }
        #endregion

        #region TryParseDecimal and TryParseDecimalArray
        /// <summary>
        /// Get default decimal number style
        /// </summary>
        /// <returns>Decimal NumberStyles</returns>
        public static NumberStyles GetDefaultDecimalNumberStyle()
        {
            return DefaultDecimalNumberStyle;
        }

        /// <summary>
        /// Get default decimal conversion value
        /// </summary>
        /// <returns>DefaultDecimalConversion</returns>
        public static decimal GetDefaultDecimalConversionValue()
        {
            return DefaultDecimalConversion;
        }

        /// <summary>
        /// Get default decimal allow default conversion
        /// </summary>
        /// <returns>DefaultDecimalAllowDefaultConversion</returns>
        public static bool GetDefaultDecimalAllowDefaultConversion()
        {
            return DefaultDecimalAllowDefaultConversion;
        }

        /// <summary>
        /// Get default decimal array allow default conversion value
        /// </summary>
        /// <returns>DefaultDecimalArrayAllowDefaultConversion</returns>
        public static bool GetDefaultDecimalArrayAllowDefaultConversion()
        {
            return DefaultDecimalArrayAllowDefaultConversion;
        }
        #endregion

        #region TryParseDouble and TryParseDoubleArray
        /// <summary>
        /// Get default Double number style
        /// </summary>
        /// <returns>Double NumberStyles</returns>
        public static NumberStyles GetDefaultDoubleNumberStyle()
        {
            return DefaultDoubleNumberStyle;
        }

        /// <summary>
        /// Get default Double conversion value
        /// </summary>
        /// <returns>DefaultDoubleConversion</returns>
        public static double GetDefaultDoubleConversionValue()
        {
            return DefaultDoubleConversion;
        }

        /// <summary>
        /// Get default Double allow default conversion
        /// </summary>
        /// <returns>DefaultDoubleAllowDefaultConversion</returns>
        public static bool GetDefaultDoubleAllowDefaultConversion()
        {
            return DefaultDoubleAllowDefaultConversion;
        }

        /// <summary>
        /// Get default Double array allow default conversion value
        /// </summary>
        /// <returns>DefaultDoubleArrayAllowDefaultConversion</returns>
        public static bool GetDefaultDoubleArrayAllowDefaultConversion()
        {
            return DefaultDoubleArrayAllowDefaultConversion;
        }
        #endregion

        #region TryParseFloat and TryParseFloatArray
        /// <summary>
        /// Get default float number style
        /// </summary>
        /// <returns>Float NumberStyles</returns>
        public static NumberStyles GetDefaultFloatNumberStyle()
        {
            return DefaultFloatNumberStyle;
        }

        /// <summary>
        /// Get default float conversion value
        /// </summary>
        /// <returns>DefaultFloatConversion</returns>
        public static float GetDefaultFloatConversionValue()
        {
            return DefaultFloatConversion;
        }

        /// <summary>
        /// Get default float allow default conversion
        /// </summary>
        /// <returns>DefaultFloatAllowDefaultConversion</returns>
        public static bool GetDefaultFloatAllowDefaultConversion()
        {
            return DefaultFloatAllowDefaultConversion;
        }

        /// <summary>
        /// Get default float array allow default conversion value
        /// </summary>
        /// <returns>DefaultFloatArrayAllowDefaultConversion</returns>
        public static bool GetDefaultFloatArrayAllowDefaultConversion()
        {
            return DefaultFloatArrayAllowDefaultConversion;
        }
        #endregion

        #region global
        /// <summary>
        /// Get current system culture
        /// </summary>
        /// <returns>Current CultureInfo</returns>
        public static CultureInfo GetCurrentCulture()
        {
            return CultureInfo.CurrentCulture;
        }
        #endregion
    }
}
