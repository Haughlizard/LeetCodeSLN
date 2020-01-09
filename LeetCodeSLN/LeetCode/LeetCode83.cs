using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LeetCodeSLN.LeetCode92;

namespace LeetCodeSLN
{
    public class LeetCode83
    {
        /// <summary>
        /// 给定一个排序链表，删除所有重复的元素，使得每个元素只出现一次。
        /// 示例 1:
        ///输入: 1->1->2
        ///输出: 1->2
        ///示例 2:
        ///输入: 1->1->2->3->3
        ///输出: 1->2->3
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) return null;
            var tmp = head;
            while (tmp.next != null)
            {
                if(tmp.val == tmp.next.val)
                {
                    tmp.next = tmp.next.next;
                }else
                {
                    tmp = tmp.next;
                }
            }
            return head;
        }
    }
}
