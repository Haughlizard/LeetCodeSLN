using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN
{
    class LeetCode700
    {
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null) return null;
            if (root.val == val) return root;
            else
            {
                if (root.val < val)
                {
                    //根据二叉搜索树的性质,查找值比当前节点值大,在右子树查找
                    return SearchBST(root.right,val);
                }
                else
                {
                    //根据二叉搜索树的性质,查找值小于等与当前节点值,在左子树查找
                    return SearchBST(root.left, val);
                }
            }
        }
    }
}
