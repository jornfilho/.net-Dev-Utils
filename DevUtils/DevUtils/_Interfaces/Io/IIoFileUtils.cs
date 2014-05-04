using System.IO;

namespace DevUtils._Interfaces.Io
{
    /// <summary>
    /// <para>The <c>IIoFileUtils</c> type provides an interface containing utility
    /// methods for common I/O file operations.</para>
    /// <para>Base project reference: https://github.com/cjaehnen/OpenLib.Utils </para> 
    /// </summary>
    public interface IIoFileUtils
    {
        /// <summary>
        /// Gets a value indicating if the specified file exists.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>A value indicating if the specified file exists.</returns>
        bool FileExists(string path);

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
        /// Writes the specified contents to the specified file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="contents">The contents of the file.</param>
        /// <returns>A value indicating if the file was written.</returns>
        bool CreateFile(string path, string contents);

        /// <summary>
        /// Creates a read only file for the specified file or sets the file
        /// to read only if it already exists.
        /// </summary>
        /// <param name="path">The path to the file to set as read only.</param>
        /// <param name="contents">The contents of the file.</param>
        /// <returns>A value indicating if the specified file is read only.</returns>
        bool CreateReadOnlyFile(string path, string contents);

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
        /// Copies the specified source file to the target file path.
        /// </summary>
        /// <param name="sourcePath">The path to the source file.</param>
        /// <param name="targetPath">The path to the target file.</param>
        /// <returns>A value indicating the file copied successfully.</returns>
        bool CopyFile(string sourcePath, string targetPath);

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

        /// <summary>
        /// Gets a value indicating if the specified file is read only.
        /// </summary>
        /// <param name="path">The path to the file to determine if it is read only.</param>
        /// <returns>A value indicating if the specified file is read only.</returns>
        bool IsFileReadOnly(string path);

        /// <summary>
        /// Remove read only attribute from file.
        /// </summary>
        /// <param name="path">The path to the file to remove read only attribute.</param>
        /// <returns>A value indicating if the specified file is not read only.</returns>
        bool RemoveReadOnlyAttribute(string path);
        
        /// <summary>
        /// Gets a count indicating the number of files in the specified
        /// directory.
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        /// <returns>The number of the files in the directory.</returns>
        int GetCountOfFilesInDirectory(string path);

        /// <summary>
        /// Gets a count indicating the number of files in the specified
        /// directory and subdirectories.
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        /// <returns>The number of the files in the directory and subdirectories.</returns>
        int GetCountOfFilesInDirectoryAndSubdirectories(string path);
    }
}
