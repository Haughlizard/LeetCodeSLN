using System;
using LeetCodeSLN;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeUnitTest
{
    [TestClass]
    public class LeetCode14UnitTest
    {
        [TestMethod]
        public void LeetCode14TestMethod1()
        {
            string[] strings = new string[3] { "flight","flower","flow"};
            var prefix = LeetCode14.LongestCommonPrefix(strings);
            Assert.AreEqual("fl", prefix);
        }

        [TestMethod]
        public void LeetCode14TestMethod2()
        {
            string[] strings = new string[3] { "dog", "racecar", "car" };
            var prefix = LeetCode14.LongestCommonPrefix(strings);
            Assert.AreEqual("", prefix);
        }

        [TestMethod]
        public void LeetCode14TestMethod3()
        {
            string[] strings = new string[2] { "aa", "a"};
            var prefix = LeetCode14.LongestCommonPrefix(strings);
            Assert.AreEqual("a", prefix);
        }
    }
}
