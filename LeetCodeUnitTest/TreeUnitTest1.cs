using System;
using LeetCodeSLN;
using LeetCodeSLN.AboutMath;
using LeetCodeSLN.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
