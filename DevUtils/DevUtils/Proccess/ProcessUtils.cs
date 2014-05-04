using System;
using System.Diagnostics;
using System.Text;
using DevUtils._Interfaces.Proccess;

namespace DevUtils.Proccess
{
    /// <summary>
    /// <para>The <c>ProcessUtils</c> type provides an implementation of the
    /// <c>IProcessUtils</c> interface that provides utility methods for
    /// managing processes.</para>
    /// <para>Base project reference: https://github.com/cjaehnen/OpenLib.Utils </para>
    /// </summary>
    public class ProcessUtils : IProcessUtils
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
        public bool ExecuteProcess(ProcessStartInfo processInfo, out string output, out string errors)
        {
            var completed = false;
            output = null;
            errors = null;

            try
            {
                if (processInfo == null) 
                    return false;

                processInfo.RedirectStandardOutput = true;
                processInfo.RedirectStandardError = true;

                using (var process = Process.Start(processInfo))
                {
                    var outputBuilder = new StringBuilder();
                    var errorsBuilder = new StringBuilder();

                    while (process != null && !process.StandardOutput.EndOfStream)
                    {
                        outputBuilder.Append(process.StandardOutput.ReadLine());
                    }

                    while (process != null && !process.StandardError.EndOfStream)
                    {
                        errorsBuilder.Append(process.StandardError.ReadLine());
                    }

                    if (process != null) 
                        process.Close();

                    output = outputBuilder.ToString();
                    errors = errorsBuilder.ToString();

                    completed = String.IsNullOrWhiteSpace(errors) && String.IsNullOrEmpty(errors);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            if (String.IsNullOrEmpty(output) || String.IsNullOrWhiteSpace(output))
                output = null;

            if (String.IsNullOrEmpty(errors) || String.IsNullOrWhiteSpace(errors))
                errors = null;

            return completed;
        }
    }
}
