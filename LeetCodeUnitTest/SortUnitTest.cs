using System;
using LeetCodeSLN.SortAndSearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeUnitTest
{
    [TestClass]
    public class SortUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Sort st = new Sort();
            Random rd = new Random();
            int N = 10000;
            int[] nums = new int[N];
            for(int i = 0; i < N; i++)
            {
                nums[i] = rd.Next(1, 100000);
            }
            st.MergeSort(nums);
        }
    }
}
