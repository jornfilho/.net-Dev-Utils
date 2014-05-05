using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace DevUtils.WebConfig
{
    /// <summary>
    /// Web config extension class.
    /// Provide methods to manipulate web.config and app.config files
    /// </summary>
    public class WebConfigExtensions
    {
        /// <summary>
        /// Get param value from appsettings section
        /// </summary>
        /// <param name="paramName">Param name</param>
        /// <returns>Value of indicated param on appsettings node</returns>
        public string GetFromAppSettings(string paramName)
        {
            try
            {
                return WebConfigurationManager.AppSettings[paramName];
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Get param value from connectionstring section
        /// </summary>
        /// <param name="paramName">Connection name</param>
        /// <param name="informationType">Connection information type to return</param>
        /// <returns>Value of indicated type from selected connection string on connectionstring node</returns>
        public string GetFromConnectionString(string paramName, ConnectionStringInformationType informationType)
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
        /// <para>Get section from system.web setcion on web.config / app.config</para>
        /// </summary>
        /// <typeparam name="T">Section class to return</typeparam>
        /// <param name="section">Section type</param>
        /// <returns>system.web section or null</returns>
        public T GetFromSystemWeb<T>(SystemWebSections section) where T : class
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
    }
}
