using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevUtils.test.Hash
{
    /// <summary>
    /// Randon test class
    /// </summary>
    [TestClass]
    public class Randon
    {
        /// <summary>
        /// Test CreateRandonHash method
        /// </summary>
        [TestMethod]
        public void CreateRandonHash()
        {
            var hashWith12 = DevUtils.Hash.GetRandom.CreateRandonHash(12);

            Assert.IsTrue(hashWith12.Length == 12, "Error creating random hash");
            Console.WriteLine(hashWith12);

            Assert.IsTrue(DevUtils.Hash.GetRandom.CreateRandonHash(-1).Length == 0, "Error creating random hash");
        }
    }
}
