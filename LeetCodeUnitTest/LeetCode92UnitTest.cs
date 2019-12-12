using System;
using LeetCodeSLN;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LeetCodeSLN.LeetCode92;

namespace LeetCodeUnitTest
{
    [TestClass]
    public class LeetCode92UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ListNode listNode1 = new ListNode(1);
            ListNode listNode2 = new ListNode(2);
            listNode1.next = listNode2;
            ListNode listNode3 = new ListNode(3);
            listNode2.next = listNode3;
            ListNode listNode4 = new ListNode(4);
            listNode3.next = listNode4;
            ListNode listNode5= new ListNode(5);
            listNode4.next = listNode5;
            ListNode listNode6 = new ListNode(6);
            listNode5.next = listNode6;
            ReverseBetween(listNode1, 4, 5);
        }
    }
}
