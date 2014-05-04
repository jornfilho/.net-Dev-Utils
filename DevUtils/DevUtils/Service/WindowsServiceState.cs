namespace DevUtils.Service
{
    /// <summary>
    /// <para>The <c>WindowsServiceState</c> type provides an enumeration for
    /// Windows service states.</para>
    /// <para>Base project reference: https://github.com/cjaehnen/OpenLib.Utils </para>
    /// </summary>
    public enum WindowsServiceState
    {
        /// <summary>
        /// Indicates the Windows service state is not available.
        /// </summary>
        NotAvailable,

        /// <summary>
        /// Indicates the Windows service state is running.
        /// </summary>
        Running,

        /// <summary>
        /// Indicates the Windows service state is stopped.
        /// </summary>
        Stopped,

        /// <summary>
        /// Indicates the Windows service state is failed.
        /// </summary>
        Failed
    }
}
