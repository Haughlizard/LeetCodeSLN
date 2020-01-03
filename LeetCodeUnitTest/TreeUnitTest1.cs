using System;
using LeetCodeSLN;
using LeetCodeSLN.AboutMath;
using LeetCodeSLN.Strings;
using LeetCodeSLN.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LeetCodeSLN.SortAndSearch;
using LeetCodeSLN.Design;
using LeetCodeSLN.BinarySearch;

namespace LeetCodeUnitTest
{
    [TestClass]
    public class TreeUnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Tree tree = new Tree();

            TreeNode root = new TreeNode(1);
            TreeNode left = new TreeNode(2);
            TreeNode right = new TreeNode(2);
            TreeNode leftLeft = new TreeNode(3);
            TreeNode leftRight = new TreeNode(4);
            TreeNode rightLeft = new TreeNode(4);
            TreeNode rightRight = new TreeNode(3);
            root.left = left;
            root.right = right;
            left.left = leftLeft;
            left.right = leftRight;
            right.left = rightLeft;
            right.right = rightRight;

            var IsSymmetric = tree.IsSymmetric(root);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[] nums = new int[] { 1,2,3,4,5,6,7,8,9,10,11,12,15};

            Solution solution = new Solution(nums);

            var nums1 = solution.Shuffle();
            var nums2 = solution.Shuffle();
        }

        [TestMethod]
        public void TestMethod3()
        {
            Maths mt = new Maths();
            int[] nums = new int[] { 1,1 };
            var length = mt.FindMaxConsecutiveOnes(nums);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Strings mt = new Strings();
            string a = "hello";
            string b = "ll";
            var length = mt.StrStr(a,b);
        }

        [TestMethod]
        public void TestMethod5()
        {
            MovingAverage avg = new MovingAverage(1);
            var a = avg.Next(4);
            var b = avg.Next(0);
            var c = avg.Next(3);
            var d = avg.Next(4);
        }

        [TestMethod]
        public void TestMethod6()
        {
            string s = "aaa";
            var ch = s[0];
            int count = 1000000000;
            int a = 231312312;
            int b = 100000000;
            System.Diagnostics.Stopwatch sw1 = new System.Diagnostics.Stopwatch();
            sw1.Start();
            for(int i = 0; i < count; i++)
            {
                int c = (a + b) / 2;
            }
            sw1.Stop();
            var time1 = sw1.ElapsedMilliseconds;
            System.Diagnostics.Stopwatch sw2 = new System.Diagnostics.Stopwatch();
            sw2.Start();
            for (int i = 0; i < count; i++)
            {
                int c = (a + b) >> 1;
            }
            sw2.Stop();
            var time2 = sw2.ElapsedMilliseconds;
        }

        [TestMethod]
        public void TestMethod7()
        {
            string a = "ab";
            string b = "aa";
            SortAndSearch ss = new SortAndSearch();
            var istrue =ss.Multiply("99999","0");
        }

        [TestMethod]
        public void TestMethod8()
        {
            string a = "aaabbvvtrtgfdhfdfhhhh";
            SortAndSearch ss = new SortAndSearch();
            var istrue = ss.FrequencySort(a);
        }

        [TestMethod]
        public void TestMethod9()
        {
            Trie trie = new Trie();
            trie.Insert("apple");
            var b1 = trie.Search("app");
            trie.Insert("app");
            var b2 = trie.StartsWith("appl");
        }

        [TestMethod]
        public void TestMethod10()
        {
            BinarySearch bs = new BinarySearch();
            //int[] A = new int[] { -10, -5, -2, 0, 4, 5, 6, 7, 8, 9, 10};
            //var index = bs.FixedPoint(A);

            //int[] nums = new int[] { 2, 4, 5, 5, 5, 5, 5, 6, 6 };
            //var ismajor = bs.IsMajorityElement(nums, 5);
            //string s = "abc";
            //string t = "ahbgdc";
            //var issub = bs.IsSubsequence(s, t);

            int[] nums = new int[] { 3, 5, 3, 2, 0};
            var ma = new MountainArray(nums);

            var index = bs.FindInMountainArray(5, ma);
        }
    }
}
