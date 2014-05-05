using System.Web.Configuration;
using DevUtils.WebConfig;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.WebConfig
{
    /// <summary>
    /// WebConfigExtensions validator test class
    /// </summary>
    [TestClass]
    public class WebConfigExtensions
    {
        private readonly DevUtils.WebConfig.WebConfigExtensions _extension = new DevUtils.WebConfig.WebConfigExtensions();
        
        private const string AppSettingsParam1 = "Hello World!";
        private const string AppSettingsParam2 = "Hello World 2!";
        
        private const string Connection1Name = "connection1";
        private const string Connection1ConnectionString = "test 1";
        private const string Connection1Provider = "provider 1";

        private const string Connection2Name = "connection2";
        private const string Connection2ConnectionString = "test 2";
        private const string Connection2Provider = "provider 2";


        /// <summary>
        /// Test GetFromAppSettings method
        /// </summary>
        [TestMethod]
        public void GetFromAppSettings()
        {
            var param1 = _extension.GetFromAppSettings("message");
            var param2 = _extension.GetFromAppSettings("message2");

            Assert.AreEqual(param1, AppSettingsParam1);
            Assert.AreEqual(param2, AppSettingsParam2);
        }

        /// <summary>
        /// Test GetFromConnectionString method
        /// </summary>
        [TestMethod]
        public void GetFromConnectionString()
        {
            var param1 = _extension.GetFromConnectionString(Connection1Name, ConnectionStringInformationType.ConnectionString);
            var param2 = _extension.GetFromConnectionString(Connection2Name, ConnectionStringInformationType.ConnectionString);

            Assert.AreEqual(param1, Connection1ConnectionString);
            Assert.AreEqual(param2, Connection2ConnectionString);

            param1 = _extension.GetFromConnectionString(Connection1Name, ConnectionStringInformationType.Name);
            param2 = _extension.GetFromConnectionString(Connection2Name, ConnectionStringInformationType.Name);

            Assert.AreEqual(Connection1Name, param1);
            Assert.AreEqual(Connection2Name, param2);

            param1 = _extension.GetFromConnectionString(Connection1Name, ConnectionStringInformationType.ProviderName);
            param2 = _extension.GetFromConnectionString(Connection2Name, ConnectionStringInformationType.ProviderName);

            Assert.AreEqual(Connection1Provider, param1);
            Assert.AreEqual(Connection2Provider, param2);
        }

        /// <summary>
        /// Test GetFromSystemWeb method
        /// Return as AuthenticationSection
        /// </summary>
        [TestMethod]
        public void GetFromSystemWeb_AsAuthenticationSection()
        {
            var result = _extension.GetFromSystemWeb<AuthenticationSection>(SystemWebSections.Authentication);
            Assert.IsInstanceOfType(result, typeof(AuthenticationSection));

            result = _extension.GetFromSystemWeb<AuthenticationSection>(SystemWebSections.Compilation);
            Assert.IsNotInstanceOfType(result, typeof(AuthenticationSection));
        }

        /// <summary>
        /// Test GetFromSystemWeb method
        /// Return as CompilationSection
        /// </summary>
        [TestMethod]
        public void GetFromSystemWeb_AsCompilationSection()
        {
            var result = _extension.GetFromSystemWeb<CompilationSection>(SystemWebSections.Compilation);
            Assert.IsInstanceOfType(result, typeof(CompilationSection));

            result = _extension.GetFromSystemWeb<CompilationSection>(SystemWebSections.Authentication);
            Assert.IsNotInstanceOfType(result, typeof(CompilationSection));
        }

        /// <summary>
        /// Test GetFromSystemWeb method
        /// Return as CustomErrorsSection
        /// </summary>
        [TestMethod]
        public void GetFromSystemWeb_AsCustomErrorsSection()
        {
            var result = _extension.GetFromSystemWeb<CustomErrorsSection>(SystemWebSections.CustomErrors);
            Assert.IsInstanceOfType(result, typeof(CustomErrorsSection));

            result = _extension.GetFromSystemWeb<CustomErrorsSection>(SystemWebSections.Authentication);
            Assert.IsNotInstanceOfType(result, typeof(CustomErrorsSection));
        }

        /// <summary>
        /// Test GetFromSystemWeb method
        /// Return as GlobalizationSection
        /// </summary>
        [TestMethod]
        public void GetFromSystemWeb_AsGlobalizationSection()
        {
            var result = _extension.GetFromSystemWeb<GlobalizationSection>(SystemWebSections.Globalization);
            Assert.IsInstanceOfType(result, typeof(GlobalizationSection));

            result = _extension.GetFromSystemWeb<GlobalizationSection>(SystemWebSections.Authentication);
            Assert.IsNotInstanceOfType(result, typeof(GlobalizationSection));
        }

        /// <summary>
        /// Test GetFromSystemWeb method
        /// Return as HttpRuntimeSection
        /// </summary>
        [TestMethod]
        public void GetFromSystemWeb_AsHttpRuntimeSection()
        {
            var result = _extension.GetFromSystemWeb<HttpRuntimeSection>(SystemWebSections.HttpRuntime);
            Assert.IsInstanceOfType(result, typeof(HttpRuntimeSection));

            result = _extension.GetFromSystemWeb<HttpRuntimeSection>(SystemWebSections.Authentication);
            Assert.IsNotInstanceOfType(result, typeof(HttpRuntimeSection));
        }

        /// <summary>
        /// Test GetFromSystemWeb method
        /// Return as IdentitySection
        /// </summary>
        [TestMethod]
        public void GetFromSystemWeb_AsIdentitySection()
        {
            var result = _extension.GetFromSystemWeb<IdentitySection>(SystemWebSections.Identity);
            Assert.IsInstanceOfType(result, typeof(IdentitySection));

            result = _extension.GetFromSystemWeb<IdentitySection>(SystemWebSections.Authentication);
            Assert.IsNotInstanceOfType(result, typeof(IdentitySection));
        }

        /// <summary>
        /// Test GetFromSystemWeb method
        /// Return as TraceSection
        /// </summary>
        [TestMethod]
        public void GetFromSystemWeb_AsTraceSection()
        {
            var result = _extension.GetFromSystemWeb<TraceSection>(SystemWebSections.Trace);
            Assert.IsInstanceOfType(result, typeof(TraceSection));

            result = _extension.GetFromSystemWeb<TraceSection>(SystemWebSections.Authentication);
            Assert.IsNotInstanceOfType(result, typeof(TraceSection));
        }
    }
}
