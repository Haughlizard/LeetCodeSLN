using System;
using LeetCodeSLN;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeUnitTest
{
    [TestClass]
    public class LeetCode561UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] nums = new int[]{ 1,4,3,2};
            var sum = LeetCode561.ArrayPairSum(nums);
            Assert.AreEqual(4, sum);
        }
    }
}
