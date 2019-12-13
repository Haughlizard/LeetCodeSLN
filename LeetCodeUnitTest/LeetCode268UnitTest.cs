using System;
using LeetCodeSLN;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LeetCodeSLN.LeetCode92;

namespace LeetCodeUnitTest
{
    [TestClass]
    public class LeetCode268UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] nums = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int result = LeetCode268.MissingNumber(nums);
            Assert.AreEqual(0, result);
        }
    }
}
