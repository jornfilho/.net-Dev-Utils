using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DevUtils.PrimitivesExtensions
{
    /// <summary>
    /// Static bool extension
    /// </summary>
    public static class BoolExtensions
    {
        #region string
        /// <summary>
        /// <para>Try parse string bool (true,false,0,1) to boolean value</para>
        /// </summary>
        /// <param name="strValue">string to convert</param>
        /// <param name="defaultValue">default return value</param>
        /// <returns>bool result</returns>
        public static bool TryParseBool(this string strValue, bool defaultValue)
        {
            if (strValue == "1" || strValue == "0" || strValue == "-1")
                return strValue == "1";

            if (!String.IsNullOrEmpty(strValue) && (strValue.ToLower() == "true" || strValue.ToLower() == "false" || strValue.ToLower() == "undefined"))
                return strValue.ToLower() == "true";

            bool boolValue;
            return bool.TryParse(strValue, out boolValue) 
                ? boolValue 
                : defaultValue;
        }

        /// <summary>
        /// <para>Try parse string bool (true,false,0,1) to boolean value</para>
        /// <para>Default value is false</para>
        /// </summary>
        /// <param name="strValue">string to convert</param>
        /// <returns>bool result</returns>
        public static bool TryParseBool(this string strValue)
        {
            return strValue.TryParseBool(BasePrimitivesExtensions.GetDefaultBoolConversionValue());
        }
        #endregion

        #region object
        /// <summary>
        /// <para>Try parse object bool to boolean value</para>
        /// </summary>
        /// <param name="objValue">object to convert</param>
        /// <param name="defaultValue">default return value</param>
        /// <returns>bool result</returns>
        public static bool TryParseBool(this object objValue, bool defaultValue)
        {
            if (objValue == null)
                return defaultValue;

            try
            {
                bool boolValue;
                return bool.TryParse(objValue.ToString(), out boolValue)
                    ? boolValue
                    : defaultValue;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// <para>Try parse object to boolean value</para>
        /// <para>Default value is false</para>
        /// </summary>
        /// <param name="objValue">object to convert</param>
        /// <returns>bool result</returns>
        public static bool TryParseBool(this object objValue)
        {
            return objValue.TryParseBool(BasePrimitivesExtensions.GetDefaultBoolConversionValue());
        }
        #endregion

        #region string to bool array
        /// <summary>
        /// Parse string array in bool array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <param name="allowDefaultConversion">Allow default tryparse values</param>
        /// <returns>bool array</returns>
        public static bool[] TryParseBoolArray(this string strValue, bool[] defaultValue, bool allowDefaultConversion)
        {
            if (String.IsNullOrEmpty(strValue))
                return defaultValue ?? new bool[]{};

            var boolList = defaultValue != null 
                ? defaultValue.ToList() 
                : new List<bool>();

            foreach (var l in strValue.Split(','))
            {
                var strBool = l ?? "";

                if (String.IsNullOrEmpty(strBool) || strBool == "-1" || strBool.ToLower() == "undefined")
                {
                    if (allowDefaultConversion)
                        boolList.Add(BasePrimitivesExtensions.GetDefaultBoolConversionValue());
                        
                    continue;
                }


                if (strBool == "1" || strBool == "0")
                {
                    boolList.Add(strBool == "1");
                    continue;
                }


                if (strBool.ToLower() == "true" || strBool.ToLower() == "false")
                {
                    boolList.Add(strBool.ToLower() == "true");
                    continue;
                }
                    

                bool boolConvert;
                if (!bool.TryParse(strBool, out boolConvert))
                {
                    if (allowDefaultConversion)
                        boolList.Add(BasePrimitivesExtensions.GetDefaultBoolConversionValue());
                }
                else
                    boolList.Add(boolConvert);
                    
            }

            return boolList.ToArray();
        }

        /// <summary>
        /// Parse string array in bool array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <param name="defaultValue">default value when default tryparse</param>
        /// <returns>bool array</returns>
        public static bool[] TryParseBoolArray(this string strValue, bool[] defaultValue)
        {
            return strValue.TryParseBoolArray(defaultValue, BasePrimitivesExtensions.GetDefaultBoolArrayAllowDefaultConversion());
        }

        /// <summary>
        /// Parse string array in bool array
        /// </summary>
        /// <param name="strValue">string to parse</param>
        /// <returns>bool array</returns>
        public static bool[] TryParseBoolArray(this string strValue)
        {
            return strValue.TryParseBoolArray(null, BasePrimitivesExtensions.GetDefaultBoolArrayAllowDefaultConversion());
        }
        #endregion
        
        #region IsValidBool
        /// <summary>
        /// Test if string value is a valid boolean value
        /// </summary>
        /// <param name="strValue">string value</param>
        /// <returns>true/false</returns>
        public static bool IsValidBool(this string strValue)
        {
            try
            {
                if (String.IsNullOrEmpty(strValue))
                    return false;

                if (strValue == "1" || strValue.ToLower() == "true")
                    return true;

                bool parsed;
                if (Boolean.TryParse(strValue, out parsed))
                    return parsed;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return false;
        } 
        #endregion
    }
}
