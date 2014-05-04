using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using DevUtils._Interfaces.Io;

namespace DevUtils.Io
{
    /// <summary>
    /// <para>The <c>IoFileUtils</c> type provides an implementation of the 
    /// <c>IIoFileUtils</c> interface that provides utility methods for common 
    /// I/O file operations.</para>
    /// <para>Base project reference: https://github.com/cjaehnen/OpenLib.Utils </para> 
    /// </summary>
    public class IoFileUtils : IIoFileUtils
    {
        #region Params
        private IoDirectoryUtils IoDirectory { get; set; } 
        #endregion

        #region Constructor
        /// <summary>
        /// Base class constructor
        /// </summary>
        public IoFileUtils()
        {
            IoDirectory = new IoDirectoryUtils();
        } 
        #endregion

        /// <summary>
        /// Gets a value indicating if the specified file exists.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>A value indicating if the specified file exists.</returns>
        public bool FileExists(string path)
        {
            try
            {
                return new FileInfo(path).Exists;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Reads and returns the contents of the specified file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>The contents of the file.</returns>
        public string ReadFileAsString(string path)
        {
            try
            {
                if (!FileExists(path))
                    return null;

                string contents;
                var file = new FileInfo(path);

                using (var stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        contents = reader.ReadToEnd();
                        reader.Close();
                    }

                    stream.Close();
                }

                return contents;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Reads and returns the contents of the specified file as a file
        /// stream.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>The contents of the file as a file stream.</returns>
        public FileStream ReadFileAsStream(string path)
        {
            try
            {
                return !FileExists(path)
                    ? null
                    : new FileInfo(path).Open(FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Writes the specified contents to the specified file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="contents">The contents of the file.</param>
        /// <returns>A value indicating if the file was written.</returns>
        public bool CreateFile(string path, string contents)
        {
            try
            {
                bool fileWritten;

                if (string.IsNullOrWhiteSpace(contents))
                    return false;

                var file = new FileInfo(path);

                using (var stream = file.OpenWrite())
                {
                    using (var writer = new StreamWriter(stream, Encoding.UTF8, contents.Length))
                    {
                        writer.Write(contents);

                        writer.Close();
                        stream.Close();

                        fileWritten = file.Exists;
                    }
                }

                return fileWritten;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Creates a read only file for the specified file or sets the file
        /// to read only if it already exists.
        /// </summary>
        /// <param name="path">The path to the file to set as read only.</param>
        /// <param name="contents">The contents of the file.</param>
        /// <returns>A value indicating if the specified file is read only.</returns>
        public bool CreateReadOnlyFile(string path, string contents)
        {
            try
            {
                if (!CreateFile(path, contents))
                    return false;

                using (var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.ReadOnly);
                    stream.Close();
                }

                return IsFileReadOnly(path);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Creates a file text writer used to create file output.
        /// </summary>
        /// <remarks>
        /// This implementation returns a <see cref="StreamWriter" />.
        /// </remarks>
        /// <param name="path">The path to the file.</param>
        /// <returns>A <see cref="TextWriter" /> used to write the file.</returns>
        public TextWriter CreateFileTextWriter(string path)
        {
            try
            {
                if (!FileExists(path))
                    return null;

                var file = new FileInfo(path);

                Stream stream = file.OpenWrite();

                return new StreamWriter(stream);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Copies the specified source file to the target file path.
        /// </summary>
        /// <param name="sourcePath">The path to the source file.</param>
        /// <param name="targetPath">The path to the target file.</param>
        /// <returns>A value indicating the file copied successfully.</returns>
        public bool CopyFile(string sourcePath, string targetPath)
        {
            try
            {
                if (!FileExists(sourcePath))
                    return false;

                if (FileExists(targetPath))
                    DeleteFile(targetPath);

                var source = new FileInfo(sourcePath);

                var target = new FileInfo(targetPath);
                source.CopyTo(target.FullName);

                return target.Exists;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }
        
        /// <summary>
        /// Deletes all files in the specified directory.
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        /// <returns>The count of files deleted from the directory.</returns>
        public int DeleteFiles(string path)
        {
            try
            {
                var count = 0;

                foreach (var file in Directory.GetFiles(path))
                {
                    if (!FileExists(file) || (File.GetAttributes(file) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                        continue;

                    File.Delete(file);
                    count++;
                }

                return count;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return 0;
            }
        }

        /// <summary>
        /// Deletes the specified file from the file system.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>A value indicating if the file was deleted.</returns>
        public bool DeleteFile(string path)
        {
            try
            {
                if (!FileExists(path))
                    return false;

                var file = new FileInfo(path);

                file.Delete();

                return !new FileInfo(path).Exists;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating if the specified file is read only.
        /// </summary>
        /// <param name="path">The path to the file to determine if it is read only.</param>
        /// <returns>A value indicating if the specified file is read only.</returns>
        public bool IsFileReadOnly(string path)
        {
            try
            {
                var isReadOnly = false;
                var file = new FileInfo(path);

                if (FileExists(path))
                    isReadOnly = file.IsReadOnly;

                return isReadOnly;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Remove read only attribute from file.
        /// </summary>
        /// <param name="path">The path to the file to remove read only attribute.</param>
        /// <returns>A value indicating if the specified file is not read only.</returns>
        public bool RemoveReadOnlyAttribute(string path)
        {
            try
            {
                if (!FileExists(path))
                    return false;

                if (!IsFileReadOnly(path))
                    return true;

                var attributes = File.GetAttributes(path);
                attributes = attributes & ~FileAttributes.ReadOnly;
                File.SetAttributes(path, attributes);

                return !IsFileReadOnly(path);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Gets a count indicating the number of files in the specified
        /// directory.
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        /// <returns>The number of the files in the directory.</returns>
        public int GetCountOfFilesInDirectory(string path)
        {
            try
            {
                return Directory.GetFiles(path).Length;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return 0;
            }
        }

        /// <summary>
        /// Gets a count indicating the number of files in the specified
        /// directory and subdirectories.
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        /// <returns>The number of the files in the directory and subdirectories.</returns>
        public int GetCountOfFilesInDirectoryAndSubdirectories(string path)
        {
            try
            {
                if (!IoDirectory.DirectoryExists(path))
                    return 0;

                var source = new DirectoryInfo(path);

                var result = GetCountOfFilesInDirectory(path);
                foreach (var subdirectories in source.GetDirectories())
                    result += GetCountOfFilesInDirectoryAndSubdirectories(subdirectories.FullName);

                return result;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return 0;
            }
        }
    }
}
