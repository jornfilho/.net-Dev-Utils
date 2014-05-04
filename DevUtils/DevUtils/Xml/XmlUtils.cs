using System;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using DevUtils.Io;
using DevUtils._Interfaces.Io;
using DevUtils._Interfaces.Xml;

namespace DevUtils.Xml
{
    /// <summary>
    /// <para>The <c>XmlUtils</c> type provides an implementation of the
    /// <c>IXmlUtils</c> interface that provides utility methods for common
    /// XML operations.</para>
    /// <para>Base project reference: https://github.com/cjaehnen/OpenLib.Utils </para>
    /// </summary>
    public class XmlUtils : IXmlUtils
    {
        #region Params
        /// <summary>
        /// Gets or sets a reference to the <c>IIoFileUtils</c> for performing I/O
        /// file operations.
        /// </summary>
        private IIoFileUtils IoFileUtils { get; set; }

        /// <summary>
        /// Gets or sets a reference to the <c>IIoDirectoryUtils</c> for performing I/O
        /// directory operations.
        /// </summary>
        private IIoDirectoryUtils IoDirectoryUtils { get; set; } 
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the <c>XmlUtils</c> class.
        /// </summary>
        /// <param name="ioDirectoryUtils">A reference to the <c>IIoDirectoryUtils</c> for performing I/O directory operations.</param>
        /// <param name="ioFileUtils">A reference to the <c>IIoFileUtils</c> for performing I/O file operations.</param>
        public XmlUtils(IIoDirectoryUtils ioDirectoryUtils, IIoFileUtils ioFileUtils)
        {
            IoDirectoryUtils = ioDirectoryUtils;
            IoFileUtils = ioFileUtils;
        }

        /// <summary>
        /// Creates a new instance of the <c>XmlUtils</c> class.
        /// </summary>
        /// <param name="ioDirectoryUtils">A reference to the <c>IIoDirectoryUtils</c> for performing I/O directory operations.</param>
        public XmlUtils(IIoDirectoryUtils ioDirectoryUtils)
        {
            IoDirectoryUtils = ioDirectoryUtils;
        }

        /// <summary>
        /// Creates a new instance of the <c>XmlUtils</c> class.
        /// </summary>
        /// <param name="ioFileUtils">A reference to the <c>IIoFileUtils</c> for performing I/O file operations.</param>
        public XmlUtils(IIoFileUtils ioFileUtils)
        {
            IoFileUtils = ioFileUtils;
        }

        /// <summary>
        /// Creates a new instance of the <c>XmlUtils</c> class.
        /// </summary>
        public XmlUtils()
        {
            IoDirectoryUtils = new IoDirectoryUtils();
            IoFileUtils = new IoFileUtils();
        } 
        #endregion

        /// <summary>
        /// Create a XML document
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="fileName">The file name.</param>
        /// <param name="xml">The XML document as a string to validate.</param>
        /// <param name="xsd">The XSD schema as a string used for validation.</param>
        /// <param name="ns">The target namespace.</param>
        /// <returns>A value indicating if the XML was written.</returns>
        public bool CreateDocument(string path, string fileName, string xml, string xsd, string ns)
        {
            try
            {
                if (String.IsNullOrEmpty(path) || String.IsNullOrEmpty(fileName) || String.IsNullOrEmpty(xml))
                    return false;

                if (!ValidateDocument(xml, xsd, ns))
                    return false;

                if (!path.EndsWith("/"))
                    path = path + "/";

                if (!IoDirectoryUtils.DirectoryExists(path))
                    return false;

                if (!fileName.EndsWith(".xml", StringComparison.InvariantCultureIgnoreCase))
                    fileName = fileName + ".xml";

                if (IoFileUtils.FileExists(path + fileName))
                {
                    if (IoFileUtils.IsFileReadOnly(path + fileName))
                        if (!IoFileUtils.RemoveReadOnlyAttribute(path + fileName))
                            return false;

                    if (!IoFileUtils.DeleteFile(path + fileName))
                        return false;
                }

                var xmlDocument = new XDocument(XDocument.Parse(xml));
                xmlDocument.Save(path + fileName);
                
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Validates if the specified XML document conforms to the specified
        /// XSD schema containing the specified namespace.
        /// </summary>
        /// <param name="xml">The XML document as a string to validate.</param>
        /// <param name="xsd">The XSD schema as a string used for validation.</param>
        /// <param name="ns">The target namespace.</param>
        /// <returns>A value indicating if the validation succeeded.</returns>
        public bool ValidateDocument(string xml, string xsd, string ns)
        {
            try
            {
                var isValid = true;

                if (!string.IsNullOrWhiteSpace(xml) && !string.IsNullOrWhiteSpace(xsd) && !string.IsNullOrWhiteSpace(ns))
                {
                    var schemas = new XmlSchemaSet();
                    schemas.Add(ns, XmlReader.Create(new StringReader(xsd)));

                    var xDoc = XDocument.Parse(xml);
                    xDoc.Validate(schemas, (o, e) => { isValid = false; });
                }
                else
                    isValid = false;

                return isValid;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Gets the value of the specified XML element from the specified XML
        /// file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="element">The name of the XML element.</param>
        /// <param name="ns">An optional namespace for the XML element. (Set null to ignore)</param>
        /// <returns>The value of the specified XML element.</returns>
        public string GetElement(string path, string element, XNamespace ns)
        {
            try
            {
                var contents = IoFileUtils.ReadFileAsString(path);
                if (String.IsNullOrEmpty(contents) || String.IsNullOrWhiteSpace(contents))
                    return null;

                var xDoc = XDocument.Parse(contents);
                if (xDoc.Root == null)
                    return null;

                var el = ns != null 
                    ? xDoc.Root.Element(ns + element) 
                    : xDoc.Root.Element(element);

                //try ignore namespace
                if (el == null && ns != null)
                    el = xDoc.Root.Element(element);

                return el != null
                    ? String.IsNullOrEmpty(el.Value)
                        ? null
                        : el.Value
                    : null;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Updates the specified XML element with a value for the specified
        /// XML file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="element">The name of the XML element.</param>
        /// <param name="value">The value to update for the XML element.</param>
        /// <param name="ns">An optional namespace for the XML element. (Set null to ignore)</param>
        /// <returns>A value indicating if the XML element was updated.</returns>
        public bool UpdateElement(string path, string element, string value, XNamespace ns)
        {
            try
            {
                if (String.IsNullOrEmpty(path) || String.IsNullOrEmpty(element) || String.IsNullOrEmpty(value))
                    return false;

                if (!IoFileUtils.FileExists(path))
                    return false;

                if(IoFileUtils.IsFileReadOnly(path))
                    if (!IoFileUtils.RemoveReadOnlyAttribute(path))
                        return false;

                var contents = IoFileUtils.ReadFileAsString(path);

                if (String.IsNullOrEmpty(contents) || String.IsNullOrWhiteSpace(contents))
                    return false;

                var xDoc = XDocument.Parse(contents);
                if (xDoc.Root == null)
                    return false;

                var el = ns != null 
                    ? xDoc.Root.Element(ns + element) 
                    : xDoc.Root.Element(element);

                //try ignore namespage
                if (ns != null && el == null)
                    el = xDoc.Root.Element(element);

                if (el == null) 
                    return false;

                el.Value = value;

                return IoFileUtils.DeleteFile(path) && IoFileUtils.CreateFile(path, xDoc.ToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }
    }
}
