using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using DevUtils._Interfaces.Io;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.Io
{
    /// <summary>
    /// IO utils directory test class
    /// </summary>
    [TestClass]
    public class IoFileUtils
    {
        #region params
        private IIoDirectoryUtils IoDir { get; set; } 
        private IIoFileUtils IoFiles { get; set; } 
        private string TestFolder { get; set; } 
        private string TestFolderCopy { get; set; } 
        private bool HasFolderPermission { get; set; } 
        private bool HasFilePermission { get; set; } 
        #endregion

        #region constructor
        /// <summary>
        /// Base test constructor
        /// </summary>
        public IoFileUtils()
        {
            IoDir = new DevUtils.Io.IoDirectoryUtils();
            IoFiles = new DevUtils.Io.IoFileUtils();
            TestFolder = "_TestContent";
            TestFolderCopy = TestFolder+"_Copy";

            var directoryPermission = IoDir.GetDirectoryPermission(Directory.GetCurrentDirectory());
            HasFolderPermission = directoryPermission != null &&
                                  directoryPermission.Any(p => p == FileSystemRights.CreateDirectories || p == FileSystemRights.FullControl);
            HasFilePermission = directoryPermission != null &&
                                directoryPermission.Any(p => p == FileSystemRights.CreateFiles || p == FileSystemRights.FullControl);
        } 
        #endregion

        /// <summary>
        /// Test FileExists method
        /// </summary>
        [TestMethod]
        public void FileExists()
        {
            try
            {
                if(!HasFilePermission || !HasFolderPermission)
                    return;

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");

                Assert.IsFalse(IoFiles.FileExists(TestFolder + "//0.txt"), "Invalid file path");
                IoFiles.CreateFile(TestFolder + "//0.txt", "0");
                Assert.IsTrue(IoFiles.FileExists(TestFolder + "//0.txt"), "Error creating file");
            }
            finally
            {
                if (HasFolderPermission)
                    IoDir.DeleteDirectory(TestFolder + "//");
            }
        }

        /// <summary>
        /// Test ReadFileAsString method
        /// </summary>
        [TestMethod]
        public void ReadFileAsString()
        {
            try
            {
                if (!HasFilePermission || !HasFolderPermission)
                    return;

                const string fileContent = "test content";

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");

                Assert.IsFalse(IoFiles.FileExists(TestFolder + "//0.txt"), "Invalid file path");
                IoFiles.CreateFile(TestFolder + "//0.txt", fileContent);
                Assert.IsTrue(IoFiles.FileExists(TestFolder + "//0.txt"), "Error creating file");

                Assert.AreEqual(IoFiles.ReadFileAsString(TestFolder + "//0.txt"), fileContent, "Error getting file content");
            }
            finally
            {
                if (HasFolderPermission)
                    IoDir.DeleteDirectory(TestFolder + "//");
            }
        }
        
        /// <summary>
        /// Test ReadFileAsStream method
        /// </summary>
        [TestMethod]
        public void ReadFileAsStream()
        {
            FileStream file1 = null;
            FileStream file2 = null;
            try
            {
                if (!HasFilePermission || !HasFolderPermission)
                    return;

                const string fileContent = "test content";

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");

                Assert.IsFalse(IoFiles.FileExists(TestFolder + "//0.txt"), "Invalid file path");
                IoFiles.CreateFile(TestFolder + "//0.txt", fileContent);
                Assert.IsTrue(IoFiles.FileExists(TestFolder + "//0.txt"), "Error creating file");

                Assert.IsFalse(IoFiles.FileExists(TestFolder + "//1.txt"), "Invalid file path");
                IoFiles.CreateFile(TestFolder + "//1.txt", fileContent);
                Assert.IsTrue(IoFiles.FileExists(TestFolder + "//1.txt"), "Error creating file");

                Assert.AreEqual(IoFiles.ReadFileAsString(TestFolder + "//0.txt"), fileContent, "Error getting file content");
                Assert.AreEqual(IoFiles.ReadFileAsString(TestFolder + "//1.txt"), fileContent, "Error getting file content");

                file1 = IoFiles.ReadFileAsStream(TestFolder + "//0.txt");
                file2 = IoFiles.ReadFileAsStream(TestFolder + "//1.txt");
                
                Assert.IsNotNull(file1, "Error getting file content");
                Assert.IsNotNull(file2, "Error getting file content");
            }
            finally
            {
                if (file1 != null)
                {
                    file1.Close();
                    file1.Dispose();
                }


                if (file2 != null)
                {
                    file2.Close();
                    file2.Dispose();
                }
                    

                if (HasFolderPermission)
                    IoDir.DeleteDirectory(TestFolder + "//");
            }
        }

        /// <summary>
        /// Test CreateFile method
        /// </summary>
        [TestMethod]
        public void CreateFile()
        {
            try
            {
                if (!HasFilePermission || !HasFolderPermission)
                    return;

                const string fileContent = "test content";

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");

                Assert.IsFalse(IoFiles.FileExists(TestFolder + "//0.txt"), "Invalid file path");
                IoFiles.CreateFile(TestFolder + "//0.txt", fileContent);
                Assert.IsTrue(IoFiles.FileExists(TestFolder + "//0.txt"), "Error creating file");

                Assert.AreEqual(IoFiles.ReadFileAsString(TestFolder + "//0.txt"), fileContent, "Error getting file content");
            }
            finally
            {
                if (HasFolderPermission)
                    IoDir.DeleteDirectory(TestFolder + "//");
            }
        }

        /// <summary>
        /// Test CreateReadOnlyFile method
        /// </summary>
        [TestMethod]
        public void CreateReadOnlyFile()
        {
            try
            {
                if (!HasFilePermission || !HasFolderPermission)
                    return;

                const string fileContent = "test content";

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");

                Assert.IsFalse(IoFiles.FileExists(TestFolder + "//0.txt"), "Invalid file path");
                Assert.IsTrue(IoFiles.CreateReadOnlyFile(TestFolder + "//0.txt", fileContent), "Error creating file");
                Assert.IsTrue(IoFiles.FileExists(TestFolder + "//0.txt"), "Error creating file");
                Assert.AreEqual(IoFiles.ReadFileAsString(TestFolder + "//0.txt"), fileContent, "Error getting file content");
                Assert.IsTrue(IoFiles.RemoveReadOnlyAttribute(TestFolder + "//0.txt"), "Error getting file content");
            }
            finally
            {
                if (HasFolderPermission)
                    IoDir.DeleteDirectory(TestFolder + "//");
            }
        }

        /// <summary>
        /// Test CreateFileTextWriter method
        /// </summary>
        [TestMethod]
        public void CreateFileTextWriter()
        {
            TextWriter file1 = null;
            try
            {
                if (!HasFilePermission || !HasFolderPermission)
                    return;

                const string fileContent = "test content";

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");

                Assert.IsFalse(IoFiles.FileExists(TestFolder + "//0.txt"), "Invalid file path");
                IoFiles.CreateFile(TestFolder + "//0.txt", fileContent);
                Assert.IsTrue(IoFiles.FileExists(TestFolder + "//0.txt"), "Error creating file");

                Assert.AreEqual(IoFiles.ReadFileAsString(TestFolder + "//0.txt"), fileContent, "Error getting file content");

                file1 = IoFiles.CreateFileTextWriter(TestFolder + "//0.txt");
                
                Assert.IsNotNull(file1, "Error getting file content");
            }
            finally
            {
                if (file1 != null)
                {
                    file1.Close();
                    file1.Dispose();
                }

                if (HasFolderPermission)
                    IoDir.DeleteDirectory(TestFolder + "//");
            }
        }
        
        /// <summary>
        /// Test CopyFile method
        /// </summary>
        [TestMethod]
        public void CopyFile()
        {
            try
            {
                if (!HasFilePermission || !HasFolderPermission)
                    return;

                const string fileContent = "test content";

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");

                Assert.IsFalse(IoFiles.FileExists(TestFolder + "//0.txt"), "Invalid file path");
                IoFiles.CreateFile(TestFolder + "//0.txt", fileContent);
                Assert.IsTrue(IoFiles.FileExists(TestFolder + "//0.txt"), "Error creating file");


                Assert.IsTrue(IoFiles.CopyFile(TestFolder + "//0.txt", TestFolder + "//1.txt"), "Error coping file");
                Assert.IsTrue(IoFiles.FileExists(TestFolder + "//1.txt"), "Error creating file");

                Assert.AreEqual(IoFiles.ReadFileAsString(TestFolder + "//0.txt"), fileContent, "Error getting file content");
                Assert.AreEqual(IoFiles.ReadFileAsString(TestFolder + "//1.txt"), fileContent, "Error getting file content");
            }
            finally
            {
                if (HasFolderPermission)
                    IoDir.DeleteDirectory(TestFolder + "//");
            }
        }

        /// <summary>
        /// Test DeleteFiles method
        /// </summary>
        [TestMethod]
        public void DeleteFiles()
        {
            try
            {
                if (!HasFolderPermission || !HasFilePermission)
                    return;

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");

                IList<string> files = new List<string>();
                for (var i = 0; i < 20; i++)
                    files.Add(TestFolder + "//" + i + ".txt");

                foreach (var file in files)
                    IoFiles.CreateFile(file, file);

                Assert.IsTrue(IoFiles.DeleteFiles(TestFolder + "//") == files.Count, "Error deleting files");
                
            }
            finally
            {
                if (HasFolderPermission)
                {
                    IoDir.DeleteDirectory(TestFolder + "//");
                    IoDir.DeleteDirectory(TestFolderCopy + "//");
                }
            }
        }

        /// <summary>
        /// Test DeleteFile method
        /// </summary>
        [TestMethod]
        public void DeleteFile()
        {
            try
            {
                if (!HasFolderPermission || !HasFilePermission)
                    return;

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");

                IList<string> files = new List<string>();
                for (var i = 0; i < 20; i++)
                    files.Add(TestFolder + "//" + i + ".txt");

                foreach (var file in files)
                    IoFiles.CreateFile(file, file);

                foreach (var file in files)
                    Assert.IsTrue(IoFiles.DeleteFile(file), "Error deleting file: {0}", file);

            }
            finally
            {
                if (HasFolderPermission)
                {
                    IoDir.DeleteDirectory(TestFolder + "//");
                    IoDir.DeleteDirectory(TestFolderCopy + "//");
                }
            }
        }

        /// <summary>
        /// Test IsFileReadOnly method
        /// </summary>
        [TestMethod]
        public void IsFileReadOnly()
        {
            try
            {
                if (!HasFilePermission || !HasFolderPermission)
                    return;

                const string fileContent = "test content";

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");

                Assert.IsFalse(IoFiles.FileExists(TestFolder + "//0.txt"), "Invalid file path");
                Assert.IsTrue(IoFiles.CreateReadOnlyFile(TestFolder + "//0.txt", fileContent), "Error creating file");
                Assert.IsTrue(IoFiles.FileExists(TestFolder + "//0.txt"), "Error creating file");
                Assert.AreEqual(IoFiles.ReadFileAsString(TestFolder + "//0.txt"), fileContent, "Error getting file content");

                Assert.IsTrue(IoFiles.IsFileReadOnly(TestFolder + "//0.txt"), "Error creating read only file");
                Assert.IsTrue(IoFiles.RemoveReadOnlyAttribute(TestFolder + "//0.txt"), "Error removing read only file attribute");
            }
            finally
            {
                if (HasFolderPermission)
                    IoDir.DeleteDirectory(TestFolder + "//");
            }
        }

        /// <summary>
        /// Test RemoveReadOnlyAttribute method
        /// </summary>
        [TestMethod]
        public void RemoveReadOnlyAttribute()
        {
            try
            {
                if (!HasFilePermission || !HasFolderPermission)
                    return;

                const string fileContent = "test content";

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");

                Assert.IsFalse(IoFiles.FileExists(TestFolder + "//0.txt"), "Invalid file path");
                Assert.IsTrue(IoFiles.CreateReadOnlyFile(TestFolder + "//0.txt", fileContent), "Error creating file");
                Assert.IsTrue(IoFiles.FileExists(TestFolder + "//0.txt"), "Error creating file");
                Assert.AreEqual(IoFiles.ReadFileAsString(TestFolder + "//0.txt"), fileContent, "Error getting file content");

                Assert.IsTrue(IoFiles.IsFileReadOnly(TestFolder + "//0.txt"), "Error creating read only file");
                Assert.IsTrue(IoFiles.RemoveReadOnlyAttribute(TestFolder + "//0.txt"), "Error removing read only file attribute");
            }
            finally
            {
                if (HasFolderPermission)
                    IoDir.DeleteDirectory(TestFolder + "//");
            }
        }

        /// <summary>
        /// Test GetCountOfFilesInDirectory method
        /// </summary>
        [TestMethod]
        public void GetCountOfFilesInDirectory()
        {
            try
            {
                if (!HasFolderPermission || !HasFilePermission)
                    return;

                const int filesCount = 20;

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");

                for (var d = 0; d < 5; d++)
                {
                    if (d == 0)
                        for (var i = 0; i < filesCount; i++)
                            IoFiles.CreateFile(TestFolder + "//" + i + ".txt", i.ToString(CultureInfo.InvariantCulture));
                    
                    IoDir.CreateDirectory(TestFolder + "//" + d + "//");

                    for (var i = 0; i < filesCount; i++)
                        IoFiles.CreateFile(TestFolder + "//" + d + "//" + i + ".txt", i.ToString(CultureInfo.InvariantCulture));
                }

                var mainFilesCount = IoFiles.GetCountOfFilesInDirectory(TestFolder + "//");
                
                Console.WriteLine("Main folder files count: {0}", mainFilesCount);

                Assert.IsTrue(mainFilesCount == filesCount, "Error counting files");
            }
            finally
            {
                if (HasFolderPermission)
                    IoDir.DeleteDirectory(TestFolder + "//");
            }
        }

        /// <summary>
        /// Test GetCountOfFilesInDirectoryAndSubdirectories method
        /// </summary>
        [TestMethod]
        public void GetCountOfFilesInDirectoryAndSubdirectories()
        {
            try
            {
                if (!HasFolderPermission || !HasFilePermission)
                    return;

                const int filesCount = 20;
                const int foldersCount = 5;

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");

                for (var d = 0; d < foldersCount; d++)
                {
                    if (d == 0)
                        for (var i = 0; i < filesCount; i++)
                            IoFiles.CreateFile(TestFolder + "//" + i + ".txt", i.ToString(CultureInfo.InvariantCulture));

                    IoDir.CreateDirectory(TestFolder + "//" + d + "//");

                    for (var i = 0; i < filesCount; i++)
                        IoFiles.CreateFile(TestFolder + "//" + d + "//" + i + ".txt", i.ToString(CultureInfo.InvariantCulture));
                }

                var mainFilesCount = IoFiles.GetCountOfFilesInDirectoryAndSubdirectories(TestFolder + "//");

                Console.WriteLine("Main folder files count: {0}", mainFilesCount);

                Assert.IsTrue(mainFilesCount == ((filesCount * foldersCount)+filesCount), "Error counting files");
            }
            finally
            {
                if (HasFolderPermission)
                    IoDir.DeleteDirectory(TestFolder + "//");
            }
        }
    }
}
