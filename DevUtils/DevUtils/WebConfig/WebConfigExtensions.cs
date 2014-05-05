using System;
using System.Configuration;
using System.Diagnostics;
using System.Web.Configuration;

namespace DevUtils.WebConfig
{
    /// <summary>
    /// Web config extension class.
    /// Provide methods to manipulate web.config and app.config files
    /// </summary>
    public static class WebConfigExtensions
    {
        #region appsettings section
        /// <summary>
        /// Get param value from appsettings section
        /// </summary>
        /// <param name="paramName">Param name</param>
        /// <returns>Value of indicated param on appsettings node</returns>
        public static string GetFromAppSettings(string paramName)
        {
            try
            {
                if (String.IsNullOrEmpty(paramName) || String.IsNullOrWhiteSpace(paramName))
                    return null;

                return ConfigurationManager.AppSettings[paramName];
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Create or modify appsettings section
        /// </summary>
        /// <param name="paramName">Param name</param>
        /// <param name="paramValue">New param value</param>
        /// <returns>Operation result</returns>
        public static bool SetToAppSettings(string paramName, string paramValue)
        {
            try
            {
                if (String.IsNullOrEmpty(paramName) || String.IsNullOrWhiteSpace(paramName))
                    return false;

                var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (configuration.AppSettings == null)
                    return false;

                if (configuration.AppSettings.Settings[paramName] == null)
                    configuration.AppSettings.Settings.Add(paramName, paramValue);
                else
                    configuration.AppSettings.Settings[paramName].Value = paramValue;

                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Delete from appsettings section
        /// </summary>
        /// <param name="paramName">Param name</param>
        /// <returns>Operation result</returns>
        public static bool DeleteFromAppSettings(string paramName)
        {
            try
            {
                if (String.IsNullOrEmpty(paramName) || String.IsNullOrWhiteSpace(paramName))
                    return false;

                var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (configuration.AppSettings == null)
                    return false;

                if (configuration.AppSettings.Settings[paramName] == null)
                    return false;

                configuration.AppSettings.Settings.Remove(paramName);

                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        } 
        #endregion

        #region connectionstring section
        /// <summary>
        /// Get param value from connectionstring section
        /// </summary>
        /// <param name="paramName">Connection name</param>
        /// <param name="informationType">Connection information type to return</param>
        /// <returns>Value of indicated type from selected connection string on connectionstring node</returns>
        public static string GetFromConnectionString(string paramName, ConnectionStringInformationType informationType)
        {
            try
            {
                var connection = WebConfigurationManager.ConnectionStrings[paramName];
                if (connection == null)
                    return null;

                switch (informationType)
                {
                    case ConnectionStringInformationType.ConnectionString:
                        return connection.ConnectionString;
                    case ConnectionStringInformationType.Name:
                        return connection.Name;
                    case ConnectionStringInformationType.ProviderName:
                        return connection.ProviderName;
                }

                return null;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Modify a connection string value on connectionstring section
        /// </summary>
        /// <param name="paramName">Connection name</param>
        /// <param name="informationType">Connection information type to modify value</param>
        /// <param name="paramValue">New value for information type on connection string</param>
        /// <returns>Operation result</returns>
        public static bool SetToConnectionString(string paramName, ConnectionStringInformationType informationType, string paramValue)
        {
            try
            {
                var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (configuration.ConnectionStrings == null)
                    return false;

                if (configuration.ConnectionStrings.ConnectionStrings[paramName] == null)
                    return false;

                switch (informationType)
                {
                    case ConnectionStringInformationType.ConnectionString:
                        configuration.ConnectionStrings.ConnectionStrings[paramName].ConnectionString = paramValue;
                        break;
                    case ConnectionStringInformationType.Name:
                        configuration.ConnectionStrings.ConnectionStrings[paramName].Name = paramValue;
                        break;
                    case ConnectionStringInformationType.ProviderName:
                        configuration.ConnectionStrings.ConnectionStrings[paramName].ProviderName = paramValue;
                        break;
                }

                configuration.Save();
                ConfigurationManager.RefreshSection("connectionStrings");

                return true;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        } 
        #endregion

        #region system.web section
        /// <summary>
        /// <para>Get section from system.web setcion on web.config / app.config</para>
        /// </summary>
        /// <typeparam name="T">Section class to return</typeparam>
        /// <param name="section">Section type</param>
        /// <returns>system.web section or null</returns>
        public static T GetFromSystemWeb<T>(SystemWebSections section) where T : class
        {
            try
            {
                switch (section)
                {
                    case SystemWebSections.Authentication:
                        var authenticationSection = WebConfigurationManager.GetSection("system.web/authentication") as AuthenticationSection;

                        return authenticationSection == null
                            ? default(T)
                            : authenticationSection as T;

                    case SystemWebSections.Compilation:
                        var compilationSection = WebConfigurationManager.GetSection("system.web/compilation") as CompilationSection;

                        return compilationSection == null
                            ? default(T)
                            : compilationSection as T;

                    case SystemWebSections.CustomErrors:
                        var customErrorsSection = WebConfigurationManager.GetSection("system.web/customErrors") as CustomErrorsSection;

                        return customErrorsSection == null
                            ? default(T)
                            : customErrorsSection as T;

                    case SystemWebSections.Globalization:
                        var globalizationSection = WebConfigurationManager.GetSection("system.web/globalization") as GlobalizationSection;

                        return globalizationSection == null
                            ? default(T)
                            : globalizationSection as T;

                    case SystemWebSections.HttpRuntime:
                        var httpRuntimeSection = WebConfigurationManager.GetSection("system.web/httpRuntime") as HttpRuntimeSection;

                        return httpRuntimeSection == null
                            ? default(T)
                            : httpRuntimeSection as T;

                    case SystemWebSections.Identity:
                        var identitySection = WebConfigurationManager.GetSection("system.web/identity") as IdentitySection;

                        return identitySection == null
                            ? default(T)
                            : identitySection as T;

                    case SystemWebSections.Trace:
                        var traceSection = WebConfigurationManager.GetSection("system.web/trace") as TraceSection;

                        return traceSection == null
                            ? default(T)
                            : traceSection as T;

                    default:
                        return default(T);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        } 
        #endregion
    }
}
