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
    public class IoUtils : IIoUtils
    {
        #region Directory
        /// <summary>
        /// Gets a value indicating if the specified path is a directory.
        /// </summary>
        /// <param name="path">The path to validate as a directory.</param>
        /// <returns>A value indicating if the specified path is a directory.</returns>
        public bool IsDirectory(string path)
        {
            try
            {
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
        /// Copies the specified source directory to the target path.
        /// </summary>
        /// <param name="sourcePath">The path to the source directory.</param>
        /// <param name="targetPath">The path to the target directory.</param>
        /// <returns>A value indicating the directory copied successfully.</returns>
        public bool CopyDirectory(string sourcePath, string targetPath)
        {
            try
            {
                var source = new DirectoryInfo(sourcePath);
                var target = new DirectoryInfo(targetPath);

                if (!source.Exists) 
                    return false;

                var sourceCount = source.GetFiles().Length;

                if (sourceCount <= 0) 
                    return false;
                
                if (!target.Exists)
                    target.Create();

                foreach (var file in source.GetFiles())
                    file.CopyTo(Path.Combine(target.FullName, file.Name));

                return target.GetFiles().Length == sourceCount;
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
                var directory = new DirectoryInfo(path);

                if (directory.Exists) 
                    return true;

                directory.Create();

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
                var directory = new DirectoryInfo(path);

                if (!directory.Exists) 
                    return false;

                foreach (var file in directory.GetFiles())
                    file.Delete();

                foreach (var subDirectory in directory.GetDirectories())
                {
                    DeleteDirectoryContents(subDirectory.FullName);
                    subDirectory.Delete();
                }

                return directory.GetFiles().Length == 0;
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
                var directory = new DirectoryInfo(path);

                if (directory.Exists)
                    directory.Delete(true);

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        } 
        #endregion

        #region File
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
        /// Copies the specified source file to the target file path.
        /// </summary>
        /// <param name="sourcePath">The path to the source file.</param>
        /// <param name="targetPath">The path to the target file.</param>
        /// <returns>A value indicating the file copied successfully.</returns>
        public bool CopyFile(string sourcePath, string targetPath)
        {
            try
            {
                var source = new FileInfo(sourcePath);

                if (!source.Exists) 
                    return false;

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
                string contents;
                var file = new FileInfo(path);

                if (!file.Exists) 
                    return null;

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

                return !file.Exists
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

                if (file.Exists)
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
                var file = new FileInfo(path);

                if (file.Exists)
                    return null;

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
                    if (!File.Exists(file) || (File.GetAttributes(file) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly) 
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
                var file = new FileInfo(path);

                if (!file.Exists) 
                    return false;
                
                file.Delete();
                
                return !new FileInfo(path).Exists;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        } 
        #endregion
    }
}
