using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace DevUtils.Xml
{
    /// <summary>
    /// The <c>XmlExtensions</c> type provides extension XML.
    /// </summary>
    public static class XmlExtensions
    {
        /// <summary>
        /// Converts the specified object to an XML string representation.
        /// </summary>
        /// <param name="o">The object to convert to XML.</param>
        /// <returns>An XML string representation of the object.</returns>
        public static string ToXml(this object o)
        {
            try
            {
                string xml;

                if (o == null)
                    return null;

                using (var writer = new StringWriter())
                {
                    var serializer = new XmlSerializer(o.GetType());

                    serializer.Serialize(writer, o);
                    xml = writer.ToString();
                    writer.Close();
                }

                if (String.IsNullOrEmpty(xml) || String.IsNullOrWhiteSpace(xml))
                    xml = null;

                return xml;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }
    }
}
