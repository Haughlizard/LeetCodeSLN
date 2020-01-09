using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN
{
    public class LeetCode92
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public static ListNode ReverseBetween(ListNode head, int m, int n)
        {
            if (head == null)
            {
                return null;
            }
            if (m == 0 || n == 0 || m >= n)
            {
                return head;
            }

            ListNode prev = null, curr = head, next = null;
            // 区间链表反转后的前驱节点，当m=1时，con为null（不存在这个前驱节点）
            ListNode con = null;
            // 区间链表反转后的后继节点
            ListNode tail = null;

            int index = 0;
            while (curr != null)
            {
                if (++index == m)
                {
                    con = prev;
                    tail = curr;
                }

                next = curr.next;
                // 反转区间内的节点
                if (m < index && index <= n)
                {
                    curr.next = prev;
                }
                // 后移下面两个指针
                prev = curr;
                curr = next;

                if (index == n)
                {
                    if (con != null)
                    {
                        // 连接区间节点的前驱节点
                        con.next = prev;
                    }
                    else
                    {
                        // 当m=1时，头节点设置为prev
                        head = prev;
                    }
                    // 连接区间节点的后继节点
                    tail.next = curr;
                }
            }
            return head;
        }
    }
}
