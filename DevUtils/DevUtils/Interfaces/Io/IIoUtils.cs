using System.IO;

namespace DevUtils.Interfaces.Io
{
    /// <summary>
    /// <para>The <c>IIoUtils</c> type provides an interface containing utility
    /// methods for common I/O operations.</para>
    /// <para>Reference project: https://github.com/cjaehnen/OpenLib.Utils </para> 
    /// </summary>
    public interface IIoUtils
    {
        #region Directory
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
        /// Copies the specified source directory to the target path.
        /// </summary>
        /// <param name="sourcePath">The path to the source directory.</param>
        /// <param name="targetPath">The path to the target directory.</param>
        /// <returns>A value indicating the directory copied successfully.</returns>
        bool CopyDirectory(string sourcePath, string targetPath);

        /// <summary>
        /// Creates the specified directory if it does not exist.
        /// </summary>
        /// <param name="path">The path to the directory to create.</param>
        /// <returns>A value indicating if the directory was created.</returns>
        bool CreateDirectory(string path);

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
        #endregion

        #region File
        /// <summary>
        /// Gets a value indicating if the specified file exists.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>A value indicating if the specified file exists.</returns>
        bool FileExists(string path);

        /// <summary>
        /// Gets a count indicating the number of files in the specified
        /// directory.
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        /// <returns>The number of the files in the directory.</returns>
        int GetCountOfFilesInDirectory(string path);

        /// <summary>
        /// Copies the specified source file to the target file path.
        /// </summary>
        /// <param name="sourcePath">The path to the source file.</param>
        /// <param name="targetPath">The path to the target file.</param>
        /// <returns>A value indicating the file copied successfully.</returns>
        bool CopyFile(string sourcePath, string targetPath);

        /// <summary>
        /// Reads and returns the contents of the specified file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>The contents of the file.</returns>
        string ReadFileAsString(string path);

        /// <summary>
        /// Reads and returns the contents of the specified file as a file
        /// stream.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>The contents of the file as a file stream.</returns>
        FileStream ReadFileAsStream(string path);

        /// <summary>
        /// Gets a value indicating if the specified file is read only.
        /// </summary>
        /// <param name="path">The path to the file to determine if it is read only.</param>
        /// <returns>A value indicating if the specified file is read only.</returns>
        bool IsFileReadOnly(string path);

        /// <summary>
        /// Writes the specified contents to the specified file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="contents">The contents of the file.</param>
        /// <returns>A value indicating if the file was written.</returns>
        bool WriteFile(string path, string contents);

        /// <summary>
        /// Creates a file text writer used to create file output.
        /// </summary>
        /// <remarks>
        /// This implementation returns a <see cref="StreamWriter" />.
        /// </remarks>
        /// <param name="path">The path to the file.</param>
        /// <returns>A <see cref="TextWriter" /> used to write the file.</returns>
        TextWriter CreateFileTextWriter(string path);

        /// <summary>
        /// Deletes all files in the specified directory.
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        /// <returns>The count of files deleted from the directory.</returns>
        int DeleteFiles(string path);

        /// <summary>
        /// Deletes the specified file from the file system.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>A value indicating if the file was deleted.</returns>
        bool DeleteFile(string path); 
        #endregion
    }
}
