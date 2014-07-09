using System;
using System.Diagnostics;

namespace DevUtils.ObjectExtensions
{
    /// <summary>
    ///     Object extension
    /// </summary>
    public static class ObjectExtension
    {
        /// <summary>
        ///     Checks if an object is null
        /// </summary>
        /// <param name="obj"> Object to check </param>
        /// <returns> Flag indicating whether the object is null </returns>
        public static bool IsNull(this object obj)
        {
            try
            {
                return obj == null;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }
    }
}