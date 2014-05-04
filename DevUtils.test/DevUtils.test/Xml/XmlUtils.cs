using System.IO;
using System.Linq;
using System.Security.AccessControl;
using DevUtils._Interfaces.Io;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace DevUtils.test.Xml
{
    /// <summary>
    /// XmlUtils validator test class
    /// </summary>
    [TestClass]
    public class XmlUtils
    {
        #region Params
        private IIoDirectoryUtils IoDir { get; set; }
        private IIoFileUtils IoFiles { get; set; } 
        private string TestFolder { get; set; }
        private string TestFile { get; set; }
        private bool HasFolderPermission { get; set; }
        private bool HasFilePermission { get; set; } 
        private DevUtils.Xml.XmlUtils DevUtilsXmlUtils { get; set; }
        private XNamespace Ns { get; set; }
        private string Xsd { get; set; }
        private XElement E1 { get; set; }
        private XElement E2 { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Set default data to test class
        /// </summary>
        public XmlUtils()
        {
            IoDir = new DevUtils.Io.IoDirectoryUtils();
            IoFiles = new DevUtils.Io.IoFileUtils();
            TestFolder = "_TestContent";
            TestFile = "testXmlFile.xml";
            
            var directoryPermission = IoDir.GetDirectoryPermission(Directory.GetCurrentDirectory());
            
            HasFolderPermission = directoryPermission != null &&
                                  directoryPermission.Any(p => p == FileSystemRights.CreateDirectories || p == FileSystemRights.FullControl);
            HasFilePermission = directoryPermission != null &&
                                directoryPermission.Any(p => p == FileSystemRights.CreateFiles || p == FileSystemRights.FullControl);

            DevUtilsXmlUtils = new DevUtils.Xml.XmlUtils();

            Ns = "namespace";

            Xsd = @"<xsd:schema xmlns:xsd='http://www.w3.org/2001/XMLSchema'>
                      <xsd:element name='root'>
                        <xsd:complexType>
                          <xsd:sequence>
                            <xsd:element name='items' minOccurs='1' maxOccurs='1'>
                              <xsd:complexType>
                                <xsd:sequence>
                                  <xsd:element name='item' minOccurs='1' />
                                </xsd:sequence>
                              </xsd:complexType>                                
                            </xsd:element>
                            <xsd:element name='count' minOccurs='1' maxOccurs='1' />
                          </xsd:sequence>
                        </xsd:complexType>
                      </xsd:element>
                    </xsd:schema>";

            E1 = new XElement(Ns + "root",
                      new XElement(Ns + "items",
                          new XElement(Ns + "item", "foo"),
                          new XElement(Ns + "item", "bar")),
                      new XElement(Ns + "count", "2")
                );

            E2 = new XElement("root",
                    new XElement("items",
                        new XElement("item", "foo"),
                        new XElement("item", "bar")),
                    new XElement("count", "2")
                );
        } 
        #endregion

        /// <summary>
        /// Test method CreateDocument
        /// </summary>
        [TestMethod]
        public void CreateDocument()
        {
            try
            {
                if (!HasFilePermission || !HasFolderPermission)
                    return;

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");

                Assert.IsFalse(DevUtilsXmlUtils.CreateDocument(TestFolder + "//", TestFile, null, Xsd, Ns.NamespaceName), "Error validating xml, expected false");
                Assert.IsFalse(DevUtilsXmlUtils.CreateDocument(TestFolder + "//", TestFile, E1.ToString(), null, Ns.NamespaceName), "Error validating xml, expected false");
                Assert.IsFalse(DevUtilsXmlUtils.CreateDocument(TestFolder + "//", TestFile, E1.ToString(), Xsd, null), "Error validating xml, expected false");
                Assert.IsFalse(DevUtilsXmlUtils.CreateDocument(TestFolder + "//", TestFile, E1.ToString(), Xsd, Ns.NamespaceName), "Error validating xml, expected false");

                Assert.IsFalse(DevUtilsXmlUtils.CreateDocument("a//", TestFile, E2.ToString(), Xsd, Ns.NamespaceName), "Error validating xml, expected false");
                Assert.IsFalse(DevUtilsXmlUtils.CreateDocument(null, TestFile, E2.ToString(), Xsd, Ns.NamespaceName), "Error validating xml, expected false");

                Assert.IsFalse(DevUtilsXmlUtils.CreateDocument(TestFolder + "//", null, E2.ToString(), Xsd, Ns.NamespaceName), "Error validating xml, expected false");
                
                Assert.IsTrue(DevUtilsXmlUtils.CreateDocument(TestFolder + "//", TestFile, E2.ToString(), Xsd, Ns.NamespaceName), "Error validating xml, expected true");
                Assert.IsTrue(IoFiles.FileExists(TestFolder + "//" + TestFile), "Error creating xml file");
            }
            finally
            {
                if (HasFolderPermission)
                    IoDir.DeleteDirectory(TestFolder + "//");
            }
        }

        /// <summary>
        /// Test method ValidateDocument
        /// </summary>
        [TestMethod]
        public void ValidateDocument()
        {
            Assert.IsFalse(DevUtilsXmlUtils.ValidateDocument(null, Xsd, Ns.NamespaceName), "Error validating xml, expected false");
            Assert.IsFalse(DevUtilsXmlUtils.ValidateDocument(E1.ToString(), null, Ns.NamespaceName), "Error validating xml, expected false");
            Assert.IsFalse(DevUtilsXmlUtils.ValidateDocument(E1.ToString(), Xsd, null), "Error validating xml, expected false");
            Assert.IsFalse(DevUtilsXmlUtils.ValidateDocument(E1.ToString(), Xsd, Ns.NamespaceName), "Error validating xml, expected false");
            Assert.IsTrue(DevUtilsXmlUtils.ValidateDocument(E2.ToString(), Xsd, Ns.NamespaceName), "Error validating xml, expected true");
        }

        /// <summary>
        /// Test method GetElement
        /// </summary>
        [TestMethod]
        public void GetElement()
        {
            try
            {
                if (!HasFilePermission || !HasFolderPermission)
                    return;

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");

                Assert.IsFalse(DevUtilsXmlUtils.CreateDocument(TestFolder + "//", TestFile, null, Xsd, Ns.NamespaceName), "Error validating xml, expected false");
                Assert.IsFalse(DevUtilsXmlUtils.CreateDocument(TestFolder + "//", TestFile, E1.ToString(), null, Ns.NamespaceName), "Error validating xml, expected false");
                Assert.IsFalse(DevUtilsXmlUtils.CreateDocument(TestFolder + "//", TestFile, E1.ToString(), Xsd, null), "Error validating xml, expected false");
                Assert.IsFalse(DevUtilsXmlUtils.CreateDocument(TestFolder + "//", TestFile, E1.ToString(), Xsd, Ns.NamespaceName), "Error validating xml, expected false");

                Assert.IsFalse(DevUtilsXmlUtils.CreateDocument("a//", TestFile, E2.ToString(), Xsd, Ns.NamespaceName), "Error validating xml, expected false");
                Assert.IsFalse(DevUtilsXmlUtils.CreateDocument(null, TestFile, E2.ToString(), Xsd, Ns.NamespaceName), "Error validating xml, expected false");

                Assert.IsFalse(DevUtilsXmlUtils.CreateDocument(TestFolder + "//", null, E2.ToString(), Xsd, Ns.NamespaceName), "Error validating xml, expected false");

                Assert.IsTrue(DevUtilsXmlUtils.CreateDocument(TestFolder + "//", TestFile, E2.ToString(), Xsd, Ns.NamespaceName), "Error validating xml, expected true");
                Assert.IsTrue(IoFiles.FileExists(TestFolder + "//" + TestFile), "Error creating xml file");

                var value = DevUtilsXmlUtils.GetElement(TestFolder + "//" + TestFile, "count", Ns.NamespaceName);
                Assert.AreEqual("2", value, "Error getting element value, espected 2");

                value = DevUtilsXmlUtils.GetElement(TestFolder + "//" + TestFile, "count", null);
                Assert.AreEqual("2", value, "Error getting element value, espected 2");

                value = DevUtilsXmlUtils.GetElement(TestFolder + "//" + TestFile, "foo", Ns);
                Assert.IsNull(value, "Error getting element value, espected null");

                value = DevUtilsXmlUtils.GetElement(TestFolder + "//" + TestFile, "foo", null);
                Assert.IsNull(value, "Error getting element value, espected null");
                
            }
            finally
            {
                if (HasFolderPermission)
                    IoDir.DeleteDirectory(TestFolder + "//");
            }
        }

        /// <summary>
        /// Test method UpdateElement
        /// </summary>
        [TestMethod]
        public void UpdateElement()
        {
            try
            {
                if (!HasFilePermission || !HasFolderPermission)
                    return;

                Assert.IsFalse(IoDir.DirectoryExists(TestFolder + "//"), "Invalid directory path");
                Assert.IsTrue(IoDir.CreateDirectory(TestFolder + "//"), "Error creating directory");
                Assert.IsTrue(IoDir.DirectoryExists(TestFolder + "//"), "Error creating directory");

                Assert.IsTrue(DevUtilsXmlUtils.CreateDocument(TestFolder + "//", TestFile, E2.ToString(), Xsd, Ns.NamespaceName), "Error validating xml, expected true");
                Assert.IsTrue(IoFiles.FileExists(TestFolder + "//" + TestFile), "Error creating xml file");

                var value = DevUtilsXmlUtils.GetElement(TestFolder + "//" + TestFile, "count", Ns.NamespaceName);
                Assert.AreEqual("2", value, "Error getting element value, espected 2");
                
                Assert.IsTrue(DevUtilsXmlUtils.UpdateElement(TestFolder + "//" + TestFile, "count", "3", Ns.NamespaceName), "Error setting element value");
                value = DevUtilsXmlUtils.GetElement(TestFolder + "//" + TestFile, "count", Ns.NamespaceName);
                Assert.AreEqual("3", value, "Error getting element value, espected 3");

                value = DevUtilsXmlUtils.GetElement(TestFolder + "//" + TestFile, "count", null);
                Assert.AreEqual("3", value, "Error getting element value, espected 3");

                Assert.IsTrue(DevUtilsXmlUtils.UpdateElement(TestFolder + "//" + TestFile, "count", "2", Ns.NamespaceName), "Error setting element value");
                value = DevUtilsXmlUtils.GetElement(TestFolder + "//" + TestFile, "count", Ns.NamespaceName);
                Assert.AreEqual("2", value, "Error getting element value, espected 2");

            }
            finally
            {
                if (HasFolderPermission)
                    IoDir.DeleteDirectory(TestFolder + "//");
            }
        }
    }
}
