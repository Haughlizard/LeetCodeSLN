using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LeetCodeSLN.LeetCode92;

namespace LeetCodeSLN
{
    public class LeetCode147
    {
        /// <summary>
        /// 对无序链表进行插入排序
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode InsertionSortList(ListNode head)
        {
            ListNode dummy = new ListNode(0), pre;
            dummy.next = head;

            while (head != null && head.next != null)
            {
                if (head.val <= head.next.val)
                {
                    head = head.next;
                    continue;
                }
                pre = dummy;

                while (pre.next.val < head.next.val) pre = pre.next;

                ListNode curr = head.next;
                head.next = curr.next;
                curr.next = pre.next;
                pre.next = curr;
            }
            return dummy.next;
        }
    }
}
