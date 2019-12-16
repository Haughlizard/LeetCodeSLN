using System;
using LeetCodeSLN;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeUnitTest
{
    [TestClass]
    public class LeetCode88UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] nums1 = new int[6] {1,4,5,0,0,0 };
            int[] nums2 = new int[3] { 2, 6, 9 };
            LeetCode88.Merge(nums1, 3, nums2, 3);

            int[] expect = new int[6] { 1, 2, 4, 5, 6, 9 };
            CollectionAssert.AreEqual(nums1, expect);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[] nums1 = new int[5] {1,3,1,5,4 };
            var result = LeetCode532.FindPairs(nums1,0);
            Assert.AreEqual(1, result);
        }
    }
}
