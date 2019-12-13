using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LeetCodeSLN.LeetCode92;

namespace LeetCodeSLN
{
    public class LeetCode82
    {
        /// <summary>
        /// 给定一个排序链表，删除所有含有重复数字的节点，只保留原始链表中 没有重复出现 的数字。
        ///示例 1:
        ///输入: 1->2->3->3->4->4->5
        ///输出: 1->2->5
        ///示例 2:
        ///输入: 1->1->1->2->3
        ///输出: 2->3
        ///来源：力扣（LeetCode）
        ///链接：https://leetcode-cn.com/problems/remove-duplicates-from-sorted-list-ii
        ///著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicates(ListNode head)
        {
            //TODO

            // 1.base cases
            if (head == null || head.next == null) return head;

            // 2.哑节点,快慢指针
            ListNode dummy = new ListNode(-1);
            dummy.next = head;
            ListNode slow = dummy;
            ListNode fast = head;

            // 3.1 fast 遍历链表,让fast 去嗅探不相等元素
            // 3.2 slow.next == fast --> slow 与 fast 之间没有重复元素，slow 动。
            // 3.3 slow.next != fast --> slow 与 fast 之间存在重复元素，让slow指向的元素跳过这些重复元素，slow 不动。
            while (fast != null)
            {
                if (fast.val != fast.next?.val)
                {
                    if (slow.next == fast)     //   3.2 & 3.3 
                    {
                        slow = fast;
                    }
                    else
                    {
                        slow.next = fast.next;
                    }
                }
                fast = fast.next;
            }
            return dummy.next;
        }
    }
}
