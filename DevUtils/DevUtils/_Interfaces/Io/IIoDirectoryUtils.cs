using System.Collections.Generic;
using System.Security.AccessControl;

namespace DevUtils._Interfaces.Io
{
    /// <summary>
    /// <para>The <c>IIoDirectoryUtils</c> type provides an interface containing utility
    /// methods for common I/O directory operations.</para>
    /// <para>Base project reference: https://github.com/cjaehnen/OpenLib.Utils </para>
    /// </summary>
    public interface IIoDirectoryUtils
    {
        /// <summary>
        /// Gets a value indicating if the specified path is a directory.
        /// </summary>
        /// <param name="path">The path to validate as a directory.</param>
        /// <returns>A value indicating if the specified path is a directory.</returns>
        bool IsDirectory(string path);

        /// <summary>
        /// Gets a value indicating if the specified directory exists.
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        /// <returns>A value indicating if the specified directory exists.</returns>
        bool DirectoryExists(string path);

        /// <summary>
        /// Creates the specified directory if it does not exist.
        /// </summary>
        /// <param name="path">The path to the directory to create.</param>
        /// <returns>A value indicating if the directory was created.</returns>
        bool CreateDirectory(string path);

        /// <summary>
        /// Gets a count indicating the number of subtirectories in the specified
        /// directory.
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        /// <returns>The number of the subdirectories in the directory.</returns>
        int GetCountOfSubdirectories(string path);

        /// <summary>
        /// Copies the specified source directory to the target path.
        /// </summary>
        /// <param name="sourcePath">The path to the source directory.</param>
        /// <param name="targetPath">The path to the target directory.</param>
        /// <returns>A value indicating the directory copied successfully.</returns>
        bool CopyDirectory(string sourcePath, string targetPath);

        /// <summary>
        /// Deletes all files and subdirectories in the specified directory.
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        /// <returns>A value indicating if all files and subdirectories in the specified directory were deleted.</returns>
        bool DeleteDirectoryContents(string path);

        /// <summary>
        /// Deletes the specified directory if it exists.
        /// </summary>
        /// <remarks>
        /// Recursively deletes all sub directories and files in the specified
        /// directory.
        /// </remarks>
        /// <param name="path">The path to the directory to delete.</param>
        /// <returns>A value indicating if the directory was deleted.</returns>
        bool DeleteDirectory(string path);

        /// <summary>
        /// Gets a directory permissions list
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        /// <returns>A list of permissions of indicate directory</returns>
        IList<FileSystemRights> GetDirectoryPermission(string path);

        /// <summary>
        /// Set a directory permission
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        /// <param name="permission">Permission to set on directory.</param>
        /// <returns>A value indicating if the permission was applied on directory.</returns>
        bool SetDirectoryPermission(string path, FileSystemRights permission);
        
        /// <summary>
        /// Set a directory permission list
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        /// <param name="permissions">Permissions to set on directory.</param>
        /// <returns>A value indicating if the permissions was applied on directory.</returns>
        bool SetDirectoryPermissions(string path, FileSystemRights[] permissions);
    }
}
