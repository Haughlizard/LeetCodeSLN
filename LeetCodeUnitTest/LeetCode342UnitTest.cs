using System;
using LeetCodeSLN;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeUnitTest
{
    [TestClass]
    public class LeetCode342UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var result = LeetCode342.IsPowerOfFour(14);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var result = LeetCode342.IsPowerOfFour(16);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var result = LeetCode342.IsPowerOfFour(0);
            Assert.AreEqual(false, result);
        }
    }
}
