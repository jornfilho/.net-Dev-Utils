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

        /// <summary>
        /// Converts the specified string containing XML to the specified type
        /// of T.
        /// </summary>
        /// <typeparam name="T">The type in which to convert from XML.</typeparam>
        /// <param name="xml">The string containing the XML to convert.</param>
        /// <returns>The converted type of T from XML.</returns>
        public static T FromXml<T>(this string xml)
        {
            try
            {
                var o = default(T);
                if (xml == null) 
                    return o;

                using (TextReader reader = new StringReader(xml))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    o = (T)serializer.Deserialize(reader);
                    reader.Close();
                }

                return o;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return default(T);
            }
        }
    }
}
