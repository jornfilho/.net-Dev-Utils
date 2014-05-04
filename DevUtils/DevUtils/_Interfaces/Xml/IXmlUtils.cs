using System.Xml.Linq;

namespace DevUtils._Interfaces.Xml
{
    /// <summary>
    /// <para>The <c>IXmlUtils</c> type provides an interface containing utility
    /// methods for common XML operations.</para>
    /// <para>Base project reference: https://github.com/cjaehnen/OpenLib.Utils </para>
    /// </summary>
    public interface IXmlUtils
    {
        /// <summary>
        /// Create a XML document
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="fileName">The file name.</param>
        /// <param name="xml">The XML document as a string to validate.</param>
        /// <param name="xsd">The XSD schema as a string used for validation.</param>
        /// <param name="ns">The target namespace.</param>
        /// <returns>A value indicating if the XML was written.</returns>
        bool CreateDocument(string path, string fileName, string xml, string xsd, string ns);

        /// <summary>
        /// Validates if the specified XML document conforms to the specified
        /// XSD schema containing the specified namespace.
        /// </summary>
        /// <param name="xml">The XML document as a string to validate.</param>
        /// <param name="xsd">The XSD schema as a string used for validation.</param>
        /// <param name="ns">The target namespace.</param>
        /// <returns>A value indicating if the validation succeeded.</returns>
        bool ValidateDocument(string xml, string xsd, string ns);

        /// <summary>
        /// Gets the value of the specified XML element from the specified XML
        /// file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="element">The name of the XML element.</param>
        /// <param name="ns">An optional namespace for the XML element. (Set null to ignore)</param>
        /// <returns>The value of the specified XML element.</returns>
        string GetElement(string path, string element, XNamespace ns);

        /// <summary>
        /// Updates the specified XML element with a value for the specified
        /// XML file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="element">The name of the XML element.</param>
        /// <param name="value">The value to update for the XML element.</param>
        /// <param name="ns">An optional namespace for the XML element. (Set null to ignore)</param>
        /// <returns>A value indicating if the XML element was updated.</returns>
        bool UpdateElement(string path, string element, string value, XNamespace ns);
    }
}
