using System.Diagnostics;

namespace DevUtils._Interfaces.Proccess
{
    /// <summary>
    /// <para>The <c>IProcessUtils</c> type provides an interface containing
    /// utility methods for managing processes.</para>
    /// <para>Base project reference: https://github.com/cjaehnen/OpenLib.Utils </para>
    /// </summary>
    public interface IProcessUtils
    {
        /// <summary>
        /// Executes the process defined in the <see cref="ProcessStartInfo" />
        /// object and outputs the standard output and errors, if any, into the
        /// specified output parameters, respectively.
        /// </summary>
        /// <param name="processInfo">A <see cref="ProcessStartInfo" /> object containing information to start the process.</param>
        /// <param name="output">An output parameter to contain the standard output of the process.</param>
        /// <param name="errors">An output parameter to contain the standard errors, if any, of the process.</param>
        /// <returns>A value indicating if the process completed successfully.</returns>
        bool ExecuteProcess(ProcessStartInfo processInfo, out string output, out string errors);
    }
}
