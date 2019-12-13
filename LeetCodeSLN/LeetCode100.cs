using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    public class LeetCode100
    {
        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            // p and q are both null
            if (p == null && q == null) return true;
            // one of p and q is null
            if (q == null || p == null) return false;
            if (p.val != q.val) return false;
            return IsSameTree(p.right, q.right) &&
                    IsSameTree(p.left, q.left);
        }  
    }
}
