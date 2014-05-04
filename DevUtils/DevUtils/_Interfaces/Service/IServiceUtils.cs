using DevUtils.Service;

namespace DevUtils._Interfaces.Service
{
    /// <summary>
    /// <para>The <c>IServiceUtils</c> type provides an interface containing
    /// utility methods for managing Windows services.</para>
    /// <para>Base project reference: https://github.com/cjaehnen/OpenLib.Utils </para>
    /// </summary>
    public interface IServiceUtils
    {
        /// <summary>
        /// Gets the state of the specified Windows service on the specified
        /// host.
        /// </summary>
        /// <param name="host">The name of the host to connect to where the Windows service resides.</param>
        /// <param name="serviceName">The name of the Windows service.</param>
        /// <returns>The state of the Windows service.</returns>
        WindowsServiceState GetServiceState(string host, string serviceName);

        /// <summary>
        /// Changes the state of the specified Windows service using the
        /// specified action.
        /// </summary>
        /// <param name="host">The name of the host to connect to where the Windows service resides.</param>
        /// <param name="serviceName">The name of the Windows service.</param>
        /// <param name="action">The action in which to perform on the Windows service.</param>
        /// <returns>A value indicating if the state of the Windows service was changed.</returns>
        bool ChangeServiceState(string host,string serviceName,WindowsServiceAction action);
    }
}
