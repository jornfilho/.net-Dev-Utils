using System;
using System.Diagnostics;
using DevUtils.Proccess;
using DevUtils._Interfaces.Proccess;
using DevUtils._Interfaces.Service;

namespace DevUtils.Service
{
    /// <summary>
    /// <para>The <c>ServiceUtils</c> type provides an implementation of the
    /// <c>IServiceUtils</c> interface that provides utility methods for
    /// managing Windows services.</para>
    /// <para>Base project reference: https://github.com/cjaehnen/OpenLib.Utils </para>
    /// </summary>
    public class ServiceUtils : IServiceUtils
    {
        #region Params
        private const string ServiceCommand = "sc";
        private const string FailedState = "FAILED";
        private const string RunningState = "RUNNING";
        private const string StoppedState = "STOPPED";

        /// <summary>
        /// Gets or sets a reference to the <c>IProcessUtils</c> for managing
        /// processes.
        /// </summary>
        private IProcessUtils ProcessUtils { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the <c>ServiceUtils</c> class.
        /// </summary>
        /// <param name="processUtils">A reference to the <c>IProcessUtils</c> for managing processes.</param>
        public ServiceUtils(IProcessUtils processUtils)
        {
            ProcessUtils = processUtils;
        }

        /// <summary>
        /// Creates a new instance of the <c>ServiceUtils</c> class.
        /// </summary>
        public ServiceUtils()
        {
            ProcessUtils = new ProcessUtils();
        }
        #endregion

        /// <summary>
        /// Creates a <c>ProcessStartInfo</c> object using the specified process
        /// arguments.
        /// </summary>
        /// <param name="processArgs">The arguments to be passed to the process.</param>
        /// <returns>A populated <c>ProcessStartInfo</c> ibject with process arguments.</returns>
        private static ProcessStartInfo CreateProcessInfo(string processArgs)
        {
            try
            {
                return new ProcessStartInfo
                {
                    CreateNoWindow = false,
                    UseShellExecute = false,
                    FileName = ServiceCommand,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Arguments = processArgs
                };
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Gets the state of the specified Windows service on the specified
        /// host.
        /// </summary>
        /// <param name="host">The name of the host to connect to where the Windows service resides.</param>
        /// <param name="serviceName">The name of the Windows service.</param>
        /// <returns>The state of the Windows service.</returns>
        public WindowsServiceState GetServiceState(string host, string serviceName)
        {
            try
            {
                var state = WindowsServiceState.NotAvailable;

                if (string.IsNullOrWhiteSpace(host) || string.IsNullOrWhiteSpace(serviceName)) 
                    return state;

                var processInfo = CreateProcessInfo(string.Format("\\\\{0} query \"{1}\"", host, serviceName));
                if (processInfo == null)
                    return state;

                string output;
                string errors;

                ProcessUtils.ExecuteProcess(processInfo, out output, out errors);

                if (!output.Contains(FailedState))
                {
                    if (output.Contains(RunningState))
                        state = WindowsServiceState.Running;
                    else if (output.Contains(StoppedState))
                        state = WindowsServiceState.Stopped;
                }
                else
                    state = WindowsServiceState.Failed;

                return state;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return WindowsServiceState.NotAvailable;
            }
        }

        /// <summary>
        /// Changes the state of the specified Windows service using the
        /// specified action.
        /// </summary>
        /// <param name="host">The name of the host to connect to where the Windows service resides.</param>
        /// <param name="serviceName">The name of the Windows service.</param>
        /// <param name="action">The action in which to perform on the Windows service.</param>
        /// <returns>A value indicating if the state of the Windows service was changed.</returns>
        public bool ChangeServiceState(string host,string serviceName,WindowsServiceAction action)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(host) || string.IsNullOrWhiteSpace(serviceName)) 
                    return false;

                var processInfo = CreateProcessInfo(string.Format("\\\\{0} {1} \"{2}\"", host, action.ToString().ToLower(), serviceName));
                if (processInfo == null)
                    return false;

                string output;
                string errors;

                ProcessUtils.ExecuteProcess(processInfo, out output, out errors);

                return !output.Contains(FailedState);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }
    }
}
