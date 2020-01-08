using System;
using LeetCodeSLN.DataStructure;
using LeetCodeSLN.Heap;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeUnitTest
{
    [TestClass]
    public class HeapUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Heap heap = new Heap();
            //int[] nums = new int[] {5,7,3,2,6 };
            
            //for (int i = nums.Length - 1; i >= 0; i--)
            //{
            //    heap.Heapfiy(nums, i, nums.Length);
            //}
            int N = 1000000;
            int[] nums = new int[N];
            Random random = new Random();
            for (int i = 0; i < N; i++)
            {
                int a = random.Next(0, 10000000);
                nums[i] = a;
            }
            heap.HeadSort(nums);
            //heap.QuickSort(nums, 0, nums.Length - 1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            ArrayClass ac = new ArrayClass();
            string a = "21";
            string b = "2";
            int result = string.Compare(a, b);
        }
    }
}
