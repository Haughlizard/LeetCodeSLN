﻿using System;
using LeetCodeSLN;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeUnitTest
{
    [TestClass]
    public class LeetCode724UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] nums = new int[] { 1,2,3,4,5,6,4};
            var result = LeetCodeSLN.LeetCode724.PivotIndex(nums);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string S = "baabc";
            var result = LeetCode1047.RemoveDuplicates(S);
            Assert.AreEqual("c", result);
        }
    }
}
