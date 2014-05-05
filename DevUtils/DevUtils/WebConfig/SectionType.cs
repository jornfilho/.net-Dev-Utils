namespace DevUtils.WebConfig
{
    /// <summary>
    /// Web config section types
    /// </summary>
    public enum SectionType
    {
        /// <summary>
        /// App settings section
        /// </summary>
        AppSettings,

        /// <summary>
        /// Connection string section
        /// </summary>
        ConnectionStrings,

        /// <summary>
        /// System.web section
        /// </summary>
        SystemWeb,

        //TODO: methods on webconfig extensions to GET and SET custom attributes
        ///// <summary>
        ///// Custom section
        ///// </summary>
        //Custom
    }
}
