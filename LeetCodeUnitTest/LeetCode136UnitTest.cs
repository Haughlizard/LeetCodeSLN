using System;
using LeetCodeSLN;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeUnitTest
{
    [TestClass]
    public class LeetCode136UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] nums = new int[5] { 4,1,2,1,2 };
            var result = LeetCode136.SingleNumber(nums);
            Assert.AreEqual(4, result);
        }
    }
}
