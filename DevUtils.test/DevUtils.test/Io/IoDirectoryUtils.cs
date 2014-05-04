using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class IoDirectoryUtils
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
        public IoDirectoryUtils()
        {
            IoDir = new DevUtils.Io.IoDirectoryUtils();
            IoFiles = new DevUtils.Io.IoFileUtils();
            TestFolder = "_TestContent";
            TestFolderCopy = TestFolder+"_Copy";

            var directoryPermission = IoDir.GetDirectoryPermission(System.IO.Directory.GetCurrentDirectory());
            HasFolderPermission = directoryPermission != null &&
                                  directoryPermission.Any(p => p == FileSystemRights.CreateDirectories || p == FileSystemRights.FullControl);
            HasFilePermission = directoryPermission != null &&
                                  directoryPermission.Any(p => p == FileSystemRights.CreateFiles || p == FileSystemRights.FullControl);
        } 
        #endregion

        /// <summary>
        /// Test IsDirectory method
        /// </summary>
        [TestMethod]
        public void IsDirectory()
        {
            Assert.IsFalse(IoDir.IsDirectory(""), "Error validating directory");
            Assert.IsFalse(IoDir.IsDirectory("/Class.cs"), "Error validating directory");
            Assert.IsTrue(IoDir.IsDirectory("/"), "Error validating directory");
            Assert.IsTrue(IoDir.IsDirectory("/_TestContent/"), "Error validating directory");
        }

        /// <summary>
        /// Test DirectoryExists method
        /// </summary>
        [TestMethod]
        public void DirectoryExists()
        {
            try
            {
                if(!HasFolderPermission)
                    return;

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");
            }
            finally
            {
                if (HasFolderPermission)
                    IoDir.DeleteDirectory(TestFolder + "//");
            }
        }

        /// <summary>
        /// Test CreateDirectory method
        /// </summary>
        [TestMethod]
        public void CreateDirectory()
        {
            try
            {
                if (!HasFolderPermission)
                    return;

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");
            }
            finally
            {
                if (HasFolderPermission)
                    IoDir.DeleteDirectory(TestFolder + "//");
            }
        }

        /// <summary>
        /// Test GetCountOfSubdirectories method
        /// </summary>
        [TestMethod]
        public void GetCountOfSubdirectories()
        {
            try
            {
                if (!HasFolderPermission)
                    return;

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");

                for (var d = 0; d < 5; d++)
                    IoDir.CreateDirectory(TestFolder + "//" + d + "//");

                Assert.IsTrue(IoDir.GetCountOfSubdirectories(TestFolder + "//") == 5, "Error counting subdirectories");
            }
            finally
            {
                if (HasFolderPermission)
                    IoDir.DeleteDirectory(TestFolder + "//");
            }
        }

        /// <summary>
        /// Test CopyDirectory method
        /// </summary>
        [TestMethod]
        public void CopyDirectory()
        {
            try
            {
                if (!HasFolderPermission || !HasFilePermission)
                    return;

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");

                for (var d = 0; d < 5; d++)
                {
                    if (d == 0)
                        for (var i = 0; i < 20; i++)
                            IoFiles.CreateFile(TestFolder + "//" + i + ".txt", i.ToString(CultureInfo.InvariantCulture));


                    IoDir.CreateDirectory(TestFolder + "//" + d + "//");

                    for (var i = 0; i < 20; i++)
                        IoFiles.CreateFile(TestFolder + "//" + d + "//" + i + ".txt", i.ToString(CultureInfo.InvariantCulture));
                }

                Assert.IsFalse(IoDir.DirectoryExists(TestFolderCopy + "//"), "Invalid directory path");
                IoDir.CopyDirectory(TestFolder, TestFolderCopy);
                Assert.IsTrue(IoDir.DirectoryExists(TestFolderCopy + "//"), "Error creating directory");

                var mainFilesCount = IoFiles.GetCountOfFilesInDirectoryAndSubdirectories(TestFolder + "//");
                var copyFilesCount = IoFiles.GetCountOfFilesInDirectoryAndSubdirectories(TestFolderCopy + "//");

                Console.WriteLine("Main folder files count: {0}", mainFilesCount);
                Console.WriteLine("Copy folder files count: {0}", copyFilesCount);

                Assert.IsTrue(mainFilesCount == copyFilesCount, "Error coping files");
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
        /// Test DeleteDirectoryContents method
        /// </summary>
        [TestMethod]
        public void DeleteDirectoryContents()
        {
            try
            {
                if (!HasFolderPermission || !HasFilePermission)
                    return;

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");

                for (var d = 0; d < 5; d++)
                {
                    if (d == 0)
                        for (var i = 0; i < 20; i++)
                            IoFiles.CreateFile(TestFolder + "//" + i + ".txt", i.ToString(CultureInfo.InvariantCulture));


                    IoDir.CreateDirectory(TestFolder + "//" + d + "//");

                    for (var i = 0; i < 20; i++)
                        IoFiles.CreateFile(TestFolder + "//" + d + "//" + i + ".txt", i.ToString(CultureInfo.InvariantCulture));
                }

                var mainFilesCount = IoFiles.GetCountOfFilesInDirectoryAndSubdirectories(TestFolder + "//");
                var mainFoldersCount = IoDir.GetCountOfSubdirectories(TestFolder + "//");
                Assert.IsTrue(mainFilesCount > 0, "Error counting files on directory");
                Assert.IsTrue(mainFoldersCount > 0, "Error counting subdirectories");

                Console.WriteLine("Files count: {0}", mainFilesCount);
                Console.WriteLine("Subdirectories count: {0}", mainFoldersCount);

                Assert.IsTrue(IoDir.DeleteDirectoryContents(TestFolder + "//"), "Error deleting directory content");

                mainFilesCount = IoFiles.GetCountOfFilesInDirectoryAndSubdirectories(TestFolder + "//");
                mainFoldersCount = IoDir.GetCountOfSubdirectories(TestFolder + "//");
                Console.WriteLine("\nFiles count: {0}", mainFilesCount);
                Console.WriteLine("Subdirectories count: {0}", mainFoldersCount);

                Assert.IsTrue(mainFilesCount == mainFoldersCount && mainFilesCount == 0, "Error deleting files and subdirectories");
            }
            finally
            {
                if (HasFolderPermission)
                    IoDir.DeleteDirectory(TestFolder + "//");
            }
        }

        /// <summary>
        /// Test DeleteDirectory method
        /// </summary>
        [TestMethod]
        public void DeleteDirectory()
        {
            try
            {
                if (!HasFolderPermission || !HasFilePermission)
                    return;

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");

                for (var d = 0; d < 5; d++)
                {
                    if (d == 0)
                        for (var i = 0; i < 20; i++)
                            IoFiles.CreateFile(TestFolder + "//" + i + ".txt", i.ToString(CultureInfo.InvariantCulture));


                    IoDir.CreateDirectory(TestFolder + "//" + d + "//");

                    for (var i = 0; i < 20; i++)
                        IoFiles.CreateFile(TestFolder + "//" + d + "//" + i + ".txt", i.ToString(CultureInfo.InvariantCulture));
                }

                Assert.IsTrue(IoDir.DeleteDirectory(TestFolder + "//"), "Error deleting directory");
                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
            }
            finally
            {
                if (HasFolderPermission)
                    IoDir.DeleteDirectory(TestFolder + "//");
            }
        }

        /// <summary>
        /// Test GetDirectoryPermission method
        /// </summary>
        [TestMethod]
        public void GetDirectoryPermission()
        {
            try
            {
                if (!HasFolderPermission)
                    return;

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");
                
                Assert.IsTrue(IoDir.GetDirectoryPermission(TestFolder + "//").Any(), "Error getting directory permissions");
            }
            finally
            {
                if (HasFolderPermission)
                    IoDir.DeleteDirectory(TestFolder + "//");
            }
        }

        /// <summary>
        /// Test SetDirectoryPermission method
        /// </summary>
        [TestMethod]
        public void SetDirectoryPermission()
        {
            try
            {
                if (!HasFolderPermission)
                    return;

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");

                var permissions = IoDir.GetDirectoryPermission(TestFolder + "//");
                Assert.IsTrue(permissions.Any(), "Error getting directory permissions");

                FileSystemRights? newPermission = null;
                foreach (var permission in (FileSystemRights[])Enum.GetValues(typeof(FileSystemRights)))
                {
                    if (permissions.All(p => p != permission))
                    {
                        newPermission = permission;
                        break;
                    }
                }

                Assert.IsNotNull(newPermission, "Error getting permission");
                Console.WriteLine("Permission to set: {0}", newPermission);
                
                var permissionProccessResult = IoDir.SetDirectoryPermission(TestFolder + "//", (FileSystemRights)newPermission);
                Assert.IsTrue(permissionProccessResult, "Error setting directory permission");
                
                permissions = IoDir.GetDirectoryPermission(TestFolder + "//");
                Assert.IsNotNull(permissions.FirstOrDefault(p => p == newPermission), "Error setting permission");
            }
            finally
            {
                if (HasFolderPermission)
                    IoDir.DeleteDirectory(TestFolder + "//");
            }
        }

        /// <summary>
        /// Test SetDirectoryPermissions method
        /// </summary>
        [TestMethod]
        public void SetDirectoryPermissions()
        {
            try
            {
                if (!HasFolderPermission)
                    return;

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");

                var permissions = IoDir.GetDirectoryPermission(TestFolder + "//");
                Assert.IsTrue(permissions.Any(), "Error getting directory permissions");

                IList<FileSystemRights> newPermissions = new List<FileSystemRights>();
                foreach (var permission in (FileSystemRights[])Enum.GetValues(typeof(FileSystemRights)))
                    if (permissions.All(p => p != permission))
                        newPermissions.Add(permission);

                Assert.IsNotNull(newPermissions, "Error getting permissions");
                Assert.IsTrue(newPermissions.Any(), "Error getting permissions");
                Console.WriteLine("Permission to set: {0}", string.Join(", ", newPermissions));

                var permissionProccessResult = IoDir.SetDirectoryPermissions(TestFolder + "//", newPermissions.ToArray());
                Assert.IsTrue(permissionProccessResult, "Error setting directory permissions");

                permissions = IoDir.GetDirectoryPermission(TestFolder + "//");
                foreach (var ps in newPermissions)
                    Assert.IsNotNull(permissions.FirstOrDefault(p => p == ps), "Error setting permission: {0}", ps);
            }
            finally
            {
                if (HasFolderPermission)
                    IoDir.DeleteDirectory(TestFolder + "//");
            }
        }
    }
}
