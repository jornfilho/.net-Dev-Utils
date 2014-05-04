using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using DevUtils.Interfaces.Io;

namespace DevUtils.Io
{
    /// <summary>
    /// <para>The <c>IoUtils</c> type provides an implementation of the 
    /// <c>IIoUtils</c> interface that provides utility methods for common I/O operations.</para>
    /// <para>Reference project: https://github.com/cjaehnen/OpenLib.Utils </para> 
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
                var file = new FileInfo(path);

                return !FileExists(path)
                    ? null
                    : file.Open(FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
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
        /// Writes the specified contents to the specified file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="contents">The contents of the file.</param>
        /// <returns>A value indicating if the file was written.</returns>
        public bool WriteFile(string path, string contents)
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
                if (FileExists(path))
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
    }
}
