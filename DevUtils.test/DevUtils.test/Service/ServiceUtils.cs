using System.Diagnostics;
using DevUtils.Service;
using DevUtils._Interfaces.Proccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DevUtils.test.Service
{
    /// <summary>
    /// ServiceUtils test class
    /// </summary>
    [TestClass]
    public class ServiceUtils
    {
        #region Params
        private const string Host = "Host1";
        private const string ServiceName = "Service1";

        private readonly Mock<IProcessUtils> _processUtils;
        private readonly DevUtils.Service.ServiceUtils _serviceUtils;
        #endregion

        #region Constructor
        /// <summary>
        /// Base test constructor
        /// </summary>
        public ServiceUtils()
        {
            _processUtils = new Mock<IProcessUtils>();
            _serviceUtils = new DevUtils.Service.ServiceUtils(_processUtils.Object);
        } 
        #endregion
        
        /// <summary>
        /// Test method GetServiceState with running result
        /// </summary>
        [TestMethod]
        public void TestRunningWindowsServiceStateIsReturned()
        {
            try
            {
                const WindowsServiceState expected = WindowsServiceState.Running;

                var output = "Service is RUNNING";
                string errors;

                _processUtils.Setup(m => m.ExecuteProcess(It.IsAny<ProcessStartInfo>(), out output, out errors)).Returns(true);

                var state = _serviceUtils.GetServiceState(Host, ServiceName);

                Assert.AreEqual(expected, state, "Error testing service state, expected WindowsServiceState.Running");
            }
            finally
            {
                _processUtils.VerifyAll();
            }
        }

        /// <summary>
        /// Test method GetServiceState with failed result
        /// </summary>
        [TestMethod]
        public void TestFailedWindowsServiceStateIsReturned()
        {
            try
            {
                const WindowsServiceState expected = WindowsServiceState.Failed;

                var output = "Service FAILED to start";
                var errors = "Logon error";

                _processUtils.Setup(m => m.ExecuteProcess(It.IsAny<ProcessStartInfo>(), out output, out errors)).Returns(true);

                var state = _serviceUtils.GetServiceState(Host, ServiceName);

                Assert.AreEqual(expected, state, "Error testing service state, expected WindowsServiceState.Failed");
            }
            finally
            {
                _processUtils.VerifyAll();
            }
        }

        /// <summary>
        /// Test method GetServiceState with stopped result
        /// </summary>
        [TestMethod]
        public void TestStoppedWindowsServiceStateIsReturned()
        {
            try
            {
                const WindowsServiceState expected = WindowsServiceState.Stopped;

                var output = "Service is STOPPED";
                string errors;

                _processUtils.Setup(m => m.ExecuteProcess(It.IsAny<ProcessStartInfo>(), out output, out errors)).Returns(true);

                var state = _serviceUtils.GetServiceState(Host, ServiceName);

                Assert.AreEqual(expected, state, "Error testing service state, expected WindowsServiceState.Stopped");
            }
            finally
            {
                _processUtils.VerifyAll();
            }
        }

        /// <summary>
        /// Test method GetServiceState with not available result
        /// </summary>
        [TestMethod]
        public void TestNotAvailableWindowsServiceStateIsReturnedWhenHostIsNull()
        {
            try
            {
                const WindowsServiceState expected = WindowsServiceState.NotAvailable;

                var state = _serviceUtils.GetServiceState(null, ServiceName);

                Assert.AreEqual(expected, state, "Error testing service state, expected WindowsServiceState.NotAvailable");
            }
            finally
            {
                _processUtils.VerifyAll();
            }
        }

        /// <summary>
        /// Test method GetServiceState with not available result
        /// </summary>
        [TestMethod]
        public void TestNotAvailableWindowsServiceStateIsReturnedWhenServiceNameIsNull()
        {
            try
            {
                const WindowsServiceState expected = WindowsServiceState.NotAvailable;

                var state = _serviceUtils.GetServiceState(Host, null);

                Assert.AreEqual(expected, state, "Error testing service state, expected WindowsServiceState.NotAvailable");
            }
            finally
            {
                _processUtils.VerifyAll();
            }
        }

        /// <summary>
        /// Test method ChangeServiceState setting start and success result
        /// </summary>
        [TestMethod]
        public void TestWindowsServiceIsStarted()
        {
            try
            {
                var output = "Service SUCCESSFULLY to started";
                string errors;

                _processUtils.Setup(m => m.ExecuteProcess(It.IsAny<ProcessStartInfo>(), out output, out errors)).Returns(true);

                var result = _serviceUtils.ChangeServiceState(Host, ServiceName, WindowsServiceAction.Start);

                Assert.IsTrue(result, "Error setting service state, expected true");
            }
            finally
            {
                _processUtils.VerifyAll();
            }
        }

        /// <summary>
        /// Test method ChangeServiceState setting start and failed result
        /// </summary>
        [TestMethod]
        public void TestWindowsServiceDoesNotStart()
        {
            try
            {
                var output = "Service FAILED to start";
                var errors = "Logon error";

                _processUtils.Setup(m => m.ExecuteProcess(It.IsAny<ProcessStartInfo>(), out output, out errors)).Returns(true);

                var result = _serviceUtils.ChangeServiceState(Host, ServiceName, WindowsServiceAction.Start);

                Assert.IsFalse(result, "Error setting service state, expected false");
            }
            finally
            {
                _processUtils.VerifyAll();
            }
        }

        /// <summary>
        /// Test method ChangeServiceState setting stop and success result
        /// </summary>
        [TestMethod]
        public void TestWindowsServiceIsStopped()
        {
            try
            {
                var output = "Service SUCCESSFULLY to stopped";
                string errors;

                _processUtils.Setup(m => m.ExecuteProcess(It.IsAny<ProcessStartInfo>(), out output, out errors)).Returns(true);

                var result = _serviceUtils.ChangeServiceState(Host, ServiceName, WindowsServiceAction.Stop);

                Assert.IsTrue(result, "Error setting service state, expected true");
            }
            finally
            {
                _processUtils.VerifyAll();
            }
        }

        /// <summary>
        /// Test method ChangeServiceState setting stop and failed result
        /// </summary>
        [TestMethod]
        public void TestWindowsServiceDoesNotStop()
        {
            try
            {
                var output = "Service FAILED to stop";
                var errors = "Unable to access process. Reboot Windows";

                _processUtils.Setup(m => m.ExecuteProcess(It.IsAny<ProcessStartInfo>(), out output, out errors)).Returns(true);

                var result = _serviceUtils.ChangeServiceState(Host, ServiceName, WindowsServiceAction.Stop);

                Assert.IsFalse(result, "Error setting service state, expected false");
            }
            finally
            {
                _processUtils.VerifyAll();
            }
        }
    }
}
