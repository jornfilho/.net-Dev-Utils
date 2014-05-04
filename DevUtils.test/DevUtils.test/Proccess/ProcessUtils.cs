using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using DevUtils._Interfaces.Io;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.Proccess
{
    /// <summary>
    /// ProcessUtils test class
    /// </summary>
    [TestClass]
    public class ProcessUtils
    {
        #region Params
        private const string ProcessExe = "NuGet.exe";

        private IIoDirectoryUtils IoDir { get; set; }
        private IIoFileUtils IoFiles { get; set; } 
        private string ProcessDir { get; set; }
        private string ProcessPath { get; set; }
        private bool HasFolderPermission { get; set; }
        private bool HasFilePermission { get; set; } 

        private ProcessStartInfo _processInfo;
        private readonly DevUtils.Proccess.ProcessUtils _processUtils; 
        #endregion

        #region Constructor
        /// <summary>
        /// Base test constructor
        /// </summary>
        public ProcessUtils()
        {
            IoDir = new DevUtils.Io.IoDirectoryUtils();
            IoFiles = new DevUtils.Io.IoFileUtils();

            var directoryPermission = IoDir.GetDirectoryPermission(Directory.GetCurrentDirectory());
            HasFolderPermission = directoryPermission != null &&
                                  directoryPermission.Any(p => p == FileSystemRights.CreateDirectories || p == FileSystemRights.FullControl);
            HasFilePermission = directoryPermission != null &&
                                  directoryPermission.Any(p => p == FileSystemRights.CreateFiles || p == FileSystemRights.FullControl);

            if(!HasFolderPermission || !HasFilePermission)
                Assert.Inconclusive("Invalid credentials");

            #region nugetDir and file
		    var nugetDir = Directory.GetCurrentDirectory();
            var nugetDirMatch = false;
            for (var deep = 0; deep < 10; deep++)
            {
                if(nugetDirMatch)
                    break;

                var parent = IoDir.GetParentDirectory(nugetDir);
                if(parent == null)
                    Assert.Fail("Error getting nuget directory");

                foreach (var dir in parent.GetDirectories())
                {
                    if (!dir.Name.Equals("NuGet", StringComparison.InvariantCultureIgnoreCase)) 
                        continue;

                    ProcessDir = dir.FullName;
                    nugetDirMatch = true;
                    break;
                }

                nugetDir = parent.FullName;
            }
            if (!IoFiles.FileExists(ProcessDir + "/" + ProcessExe))
                Assert.Fail("Error getting nuget file");

            ProcessPath = ProcessDir + "/" + ProcessExe;

            if (!IoFiles.FileExists(Directory.GetCurrentDirectory() + "/" + ProcessExe))
            {
                if (!IoFiles.CopyFile(ProcessPath, Directory.GetCurrentDirectory() + "/" + ProcessExe))
                    Assert.Fail("Error coping nuget file file");
            }
	        #endregion
            
            _processInfo = new ProcessStartInfo(ProcessPath);
            _processUtils = new DevUtils.Proccess.ProcessUtils();

            _processInfo.CreateNoWindow = false;
            _processInfo.UseShellExecute = false;
            _processInfo.WorkingDirectory = ProcessDir;
            _processInfo.FileName = ProcessExe;
            _processInfo.WindowStyle = ProcessWindowStyle.Hidden;
        } 
        #endregion
        
        /// <summary>
        /// Test method ExecuteProcess with no output or errors
        /// </summary>
        [TestMethod]
        public void TestProccessExecutesAndCompletesWithNoOutputOrErrors()
        {
            try
            {
                if (!HasFilePermission)
                    return;

                // setup
                _processInfo.Arguments = "config";

                string output;
                string errors;

                // execute
                var completed = _processUtils.ExecuteProcess(_processInfo, out output, out errors);

                // assert
                Assert.IsTrue(completed, "Error executing proccess");
                Assert.IsNull(output, "Error executing proccess, expected no output");
                Assert.IsNull(errors, "Error executing proccess, expected no errors");
            }
            finally
            {
                if (HasFilePermission)
                    IoFiles.DeleteFile(Directory.GetCurrentDirectory() + "\\" + ProcessExe);
            }
        }

        /// <summary>
        /// Test method ExecuteProcess with output and no errors
        /// </summary>
        [TestMethod]
        public void TestProccessExecutesAndCompletesWithOutputAndNoErrors()
        {
            try
            {
                if (!HasFilePermission)
                    return;

                // setup
                _processInfo.Arguments = "sources";

                string output;
                string errors;

                // execute
                var completed = _processUtils.ExecuteProcess(_processInfo, out output, out errors);

                // assert
                Assert.IsTrue(completed, "Error executing proccess");
                Assert.IsNotNull(output, "Error executing proccess, expected output");
                Assert.IsNull(errors, "Error executing proccess, expected no errors");

                Console.WriteLine(output);
            }
            finally
            {
                if (HasFilePermission)
                    IoFiles.DeleteFile(Directory.GetCurrentDirectory() + "\\" + ProcessExe);
            }
        }

        /// <summary>
        /// Test method ExecuteProcess with errors and no output
        /// </summary>
        [TestMethod]
        public void TestProccessExecutesButDoesNotCompleteWithNoOutputAndErrors()
        {
            try
            {
                if (!HasFilePermission)
                    return;

                // setup
                _processInfo.Arguments = "config1";

                string output;
                string errors;

                // execute
                var completed = _processUtils.ExecuteProcess(_processInfo, out output, out errors);

                // assert
                Assert.IsFalse(completed, "Error executing proccess");
                Assert.IsNull(output, "Error executing proccess, expected no output");
                Assert.IsNotNull(errors, "Error executing proccess, expected errors");

                Console.WriteLine(errors);
            }
            finally
            {
                if (HasFilePermission)
                    IoFiles.DeleteFile(Directory.GetCurrentDirectory() + "\\" + ProcessExe);
            }
        }

        /// <summary>
        /// Test method ExecuteProcess with no complete, errors and output
        /// </summary>
        [TestMethod]
        public void TestProccessDoesNotExecuteOrCompleteWithNoOutputOrErrors()
        {
            try
            {
                if (!HasFilePermission)
                    return;

                // setup
                _processInfo = null;

                string output;
                string errors;

                // execute
                var completed = _processUtils.ExecuteProcess(_processInfo, out output, out errors);

                // assert
                Assert.IsFalse(completed, "Error executing proccess");
                Assert.IsNull(output, "Error executing proccess, expected output");
                Assert.IsNull(errors, "Error executing proccess, expected errors");
            }
            finally
            {
                if (HasFilePermission)
                    IoFiles.DeleteFile(Directory.GetCurrentDirectory() + "\\" + ProcessExe);
            }
        }

        /// <summary>
        /// Test method ExecuteProcess with no output or errors
        /// </summary>
        [TestMethod]
        public void GenerateNugetPackage()
        {
            try
            {
                if (!HasFilePermission)
                    return;

                string output;
                string errors;

                _processInfo.Arguments = "pack ../DevUtils/DevUtils/DevUtils.csproj -IncludeReferencedProjects -Prop Configuration=Release";
                var completed = _processUtils.ExecuteProcess(_processInfo, out output, out errors);

                Console.WriteLine("Complete generate: {0}", completed);
                Console.WriteLine("Output: {0}", output);
                Console.WriteLine("Errors: {0}", errors);
                Console.WriteLine("");

                if (!completed) 
                    return;

                _processInfo.Arguments = "push DevUtils.1.0.0.0.nupkg";
                completed = _processUtils.ExecuteProcess(_processInfo, out output, out errors);
                Console.WriteLine("Complete generate: {0}", completed);
                Console.WriteLine("Output: {0}", output);
                Console.WriteLine("Errors: {0}", errors);
            }
            finally
            {
                if (HasFilePermission)
                    IoFiles.DeleteFile(Directory.GetCurrentDirectory() + "\\" + ProcessExe);
            }
        }
    }
}
