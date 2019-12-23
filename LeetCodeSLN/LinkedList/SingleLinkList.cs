using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN.LinkedList
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    /// <summary>
    /// 单链表相关操作
    /// </summary>
    class SingleLinkedList
    {
        public static void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            return head;
        }

        /// <summary>
        /// 反转链表
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            ListNode pre = null;//前一个节点
            ListNode cur = head;//当前节点

            while (cur != null)
            {
                ListNode tmpNode = cur.next;//暂存下一个节点
                cur.next = pre;//当前节点指向上一个节点
                pre = cur;//上个节点右移
                cur = tmpNode;//当前节点右移
            }
            return pre;
        }

        /// <summary>
        /// 合并有序列表
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);
            ListNode cur = dummyHead;
            while (l1 != null || l2 != null)
            {
                if (l1 != null && l2 != null)
                {
                    if (l1.val < l2.val)
                    {
                        cur.next = l1;
                        cur = cur.next;
                        l1 = l1.next;
                    }
                    else
                    {
                        cur.next = l2;
                        cur = cur.next;
                        l2 = l2.next;
                    }
                }
                else if (l1 == null)//l1已空
                {
                    cur.next = l2;//直接链接剩下的l2
                    break;
                }
                else//l2已空
                {
                    cur.next = l1;//链接剩下的l1
                    break;
                }
            }
            return dummyHead.next;
        }

        /// <summary>
        /// 是否是回文链表
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome(ListNode head)
        {
            ListNode newHead = head;
            return false;

        }

        /// <summary>
        /// 是否有环
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null)
                return false;
            ListNode temp = head;
            while (temp != null && head != null)
            {
                head = head.next;
                if (temp.next != null)
                {
                    temp = temp.next.next;
                    if (temp != null && temp == head)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 两两交换链表节点
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            ListNode next = head.next;
            head.next = SwapPairs(next.next);
            next.next = head;
            return next;
        }
    }
}
