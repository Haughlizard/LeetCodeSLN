using System;
using LeetCodeSLN.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeUnitTest
{
    [TestClass]
    public class PriorityQueueUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            PriorityQueue<int> queue = new PriorityQueue<int>();
            Random rd = new Random();
            int N = 1000;
            int[] nums = new int[N];
            for(int i = 0; i < N; i++)
            {
                nums[i] = rd.Next(1, 100000);
                
            }
            for (int i = 0; i < N; i++)
            {
                //if (queue.Count == 11)
                //    queue.DeQueue();
                queue.EnQueue(nums[i]);
            }
            //Array.Sort(nums);
            //queue.DeQueue();
            //int[] min10 = new int[10]; 
            //for (int i = 10; i > 0; i--)
            //{
            //    min10[i-1] = queue.DeQueue();
            //}

            int index = N-1;
            foreach(var num in queue)
            {
                nums[index--] = num;
            }
        }
    }
}
