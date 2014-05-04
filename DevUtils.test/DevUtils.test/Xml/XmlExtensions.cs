using DevUtils.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.Xml
{
    /// <summary>
    /// XmlUtils validator test class
    /// </summary>
    [TestClass]
    public class XmlExtensions
    {
        #region Params
        private readonly string _xml;
        private User _user;
        #endregion

        #region Constructor
        /// <summary>
        /// Set default data to test class
        /// </summary>
        public XmlExtensions()
        {
            _user = new User(1, "user1");

            _xml = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n" +
                    "<User xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n" +
                    "  <Id>1</Id>\r\n" +
                    "  <UserName>user1</UserName>\r\n" +
                    "</User>";
        } 
        #endregion

        #region Auxiliar
        /// <summary>
        /// The <c>User</c> type provides a private class that is used to
        /// test methods in the <c>TestObjectExtensions</c> type.
        /// </summary>
        /// <remarks>
        /// This class is only intended for testing purposes and should not be
        /// used in production code.
        /// </remarks>
        public class User
        {
            /// <summary>
            /// User id
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// User name
            /// </summary>
            public string UserName { get; set; }

            /// <summary>
            /// Base class constructor
            /// </summary>
            public User() { }

            /// <summary>
            /// Base class constructor
            /// </summary>
            /// <param name="id">User id</param>
            /// <param name="userName">User name</param>
            public User(int id, string userName)
            {
                Id = id;
                UserName = userName;
            }
        } 
        #endregion

        /// <summary>
        /// Test method ToXml, valid object
        /// </summary>
        [TestMethod]
        public void TestObjectIsConvertedToXmlString()
        {
            _user = new User(1, "user1");
            var result = _user.ToXml();

            // assert
            Assert.IsNotNull(result, "Error converting object to XML");
            Assert.AreEqual(_xml, result, "Error converting objecto to XML");
        }

        /// <summary>
        /// Test method ToXml, null object
        /// </summary>
        [TestMethod]
        public void TestObjectIsNotConvertedToXmlStringWhenObjectIsNull()
        {
            _user = null;
            var result = _user.ToXml();

            // assert
            Assert.IsNull(result, "Error converting object to XML");
        }
    }
}
