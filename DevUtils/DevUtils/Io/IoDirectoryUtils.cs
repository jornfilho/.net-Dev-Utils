using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using DevUtils._Interfaces.Io;

namespace DevUtils.Io
{
    /// <summary>
    /// <para>The <c>IoDirectoryUtils</c> type provides an implementation of the 
    /// <c>IIoDirectoryUtils</c> interface that provides utility methods for common 
    /// I/O directory operations.</para>
    /// <para>Base project reference: https://github.com/cjaehnen/OpenLib.Utils </para> 
    /// </summary>
    public class IoDirectoryUtils : IIoDirectoryUtils
    {
        /// <summary>
        /// Gets a value indicating if the specified path is a directory.
        /// </summary>
        /// <param name="path">The path to validate as a directory.</param>
        /// <returns>A value indicating if the specified path is a directory.</returns>
        public bool IsDirectory(string path)
        {
            try
            {
                if (String.IsNullOrEmpty(path))
                    return false;

                return !Path.HasExtension(path);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating if the specified directory exists.
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        /// <returns>A value indicating if the specified directory exists.</returns>
        public bool DirectoryExists(string path)
        {
            try
            {
                return new DirectoryInfo(path).Exists;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Creates the specified directory if it does not exist.
        /// </summary>
        /// <param name="path">The path to the directory to create.</param>
        /// <returns>A value indicating if the directory was created.</returns>
        public bool CreateDirectory(string path)
        {
            try
            {
                if (DirectoryExists(path))
                    return true;

                new DirectoryInfo(path).Create();

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Gets a count indicating the number of subtirectories in the specified
        /// directory.
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        /// <returns>The number of the subdirectories in the directory.</returns>
        public int GetCountOfSubdirectories(string path)
        {
            try
            {
                if (!DirectoryExists(path))
                    return 0;

                var source = new DirectoryInfo(path);
                var result = 0;

                foreach (var dir in source.GetDirectories())
                {
                    result += 1;
                    result += GetCountOfSubdirectories(dir.FullName);
                }

                return result;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return 0;
            }
        }

        /// <summary>
        /// Copies the specified source directory to the target path.
        /// </summary>
        /// <param name="sourcePath">The path to the source directory.</param>
        /// <param name="targetPath">The path to the target directory.</param>
        /// <returns>A value indicating the directory copied successfully.</returns>
        public bool CopyDirectory(string sourcePath, string targetPath)
        {
            try
            {
                if (!DirectoryExists(sourcePath))
                    return false;

                var source = new DirectoryInfo(sourcePath);
                var target = new DirectoryInfo(targetPath);

                if (!DirectoryExists(targetPath))
                    target.Create();

                var sourceCount = source.GetFiles().Length;
                if (sourceCount <= 0)
                    return true;

                foreach (var file in source.GetFiles())
                    file.CopyTo(Path.Combine(target.FullName, file.Name));

                foreach (var subDirectory in source.GetDirectories())
                    if (CreateDirectory(subDirectory.FullName))
                        CopyDirectory(subDirectory.FullName, target.FullName + "//" + subDirectory.Name);

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Deletes all files and subdirectories in the specified directory.
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        /// <returns>A value indicating if all files and subdirectories in the specified directory were deleted.</returns>
        public bool DeleteDirectoryContents(string path)
        {
            try
            {
                if (!DirectoryExists(path))
                    return false;

                var directory = new DirectoryInfo(path);

                foreach (var file in directory.GetFiles())
                    file.Delete();

                foreach (var subDirectory in directory.GetDirectories())
                {
                    DeleteDirectoryContents(subDirectory.FullName);
                    subDirectory.Delete();
                }

                return (directory.GetFiles().Length == 0) && (directory.GetDirectories().Length == 0);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Deletes the specified directory if it exists.
        /// </summary>
        /// <remarks>
        /// Recursively deletes all sub directories and files in the specified
        /// directory.
        /// </remarks>
        /// <param name="path">The path to the directory to delete.</param>
        /// <returns>A value indicating if the directory was deleted.</returns>
        public bool DeleteDirectory(string path)
        {
            try
            {
                if (DirectoryExists(path))
                    new DirectoryInfo(path).Delete(true);

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        } 

        /// <summary>
        /// Gets a directory permissions list
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        /// <returns>A list of permissions of indicate directory</returns>
        public IList<FileSystemRights> GetDirectoryPermission(string path)
        {
            try
            {
                if (!DirectoryExists(path))
                    return null;

                IList<FileSystemRights> result = new List<FileSystemRights>();
                var dSecurity = Directory.GetAccessControl(new DirectoryInfo(path).FullName);
                foreach (FileSystemAccessRule rule in dSecurity.GetAccessRules(true, true, typeof(NTAccount)))
                    result.Add(rule.FileSystemRights);

                return result;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Set a directory permission
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        /// <param name="permission">Permission to set on directory.</param>
        /// <returns>A value indicating if the permission was applied on directory.</returns>
        public bool SetDirectoryPermission(string path, FileSystemRights permission)
        {
            try
            {
                if (!DirectoryExists(path))
                    return false;

                // *** Add Access Rule to the actual directory itself
                var accessRule = new FileSystemAccessRule("Users", permission,
                                            InheritanceFlags.None,
                                            PropagationFlags.NoPropagateInherit,
                                            AccessControlType.Allow);

                var info = new DirectoryInfo(path);
                var security = info.GetAccessControl(AccessControlSections.Access);

                bool result;
                security.ModifyAccessRule(AccessControlModification.Set, accessRule, out result);

                if (!result)
                    return false;

                // *** Always allow objects to inherit on a directory
                const InheritanceFlags iFlags = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;

                // *** Add Access rule for the inheritance
                accessRule = new FileSystemAccessRule("Users", permission,
                                            iFlags,
                                            PropagationFlags.InheritOnly,
                                            AccessControlType.Allow);

                security.ModifyAccessRule(AccessControlModification.Add, accessRule, out result);

                if (!result)
                    return false;

                info.SetAccessControl(security);

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Set a directory permission list
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        /// <param name="permissions">Permissions to set on directory.</param>
        /// <returns>A value indicating if the permissions was applied on directory.</returns>
        public bool SetDirectoryPermissions(string path, FileSystemRights[] permissions)
        {
            try
            {
                if (!DirectoryExists(path) || permissions == null || !permissions.Any())
                    return false;

                foreach (var permission in permissions)
                    if (!SetDirectoryPermission(path, permission))
                        return false;

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }
    }
}
