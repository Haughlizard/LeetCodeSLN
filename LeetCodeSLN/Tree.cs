using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN
{
    public class Tree
    {
        private void Inorder(TreeNode node, List<int> list)
        {
            if (node != null)
            {
                Inorder(node.left, list);
                list.Add(node.val);
                Inorder(node.right, list);
            }
        }

        private bool IsSorted(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] >= list[i + 1])
                    return false;
            }
            return true;
        }

        public bool IsValidBST(TreeNode root)
        {

            if (root == null) return true;

            List<int> list = new List<int>();
            Inorder(root, list); // BST经过中序遍历 List中的元素是升序且不重复的.

            return IsSorted(list);
        }

        /// <summary>
        /// 层次遍历(广度优先遍历)(递归)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder1(TreeNode root)
        {
            List<IList<int>> list = new List<IList<int>>();//结果数组
            return root == null ? list : LevelOrder(root, 0, list);//如果null就直接返回 否则开始递归
        }
        private List<IList<int>> LevelOrder(TreeNode node, int level, List<IList<int>> list)
        {
            //当前层没有创建数组
            if (list.Count == level)
            {
                list.Add(new List<int>());
            }
            list[level].Add(node.val);//将当前节点的值添加到对应的层
            if (node.left != null)
            {
                list = LevelOrder(node.left, level + 1, list);
            }
            if (node.right != null)
            {
                list = LevelOrder(node.right, level + 1, list);
            }
            return list;
        }

        /// <summary>
        /// 迭代实现
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder2(TreeNode root)
        {
            List<IList<int>> list = new List<IList<int>>();//结果数组
            if (root == null)
            {
                return list;
            }
            Queue<KeyValuePair<TreeNode, int>> queue = new Queue<KeyValuePair<TreeNode, int>>();//节点 层,数据对组成的队列
            queue.Enqueue(new KeyValuePair<TreeNode, int>(root, 0));//将根节点加入队列中
            while (queue.Count > 0)
            {
                var kvp = queue.Dequeue();
                if (list.Count == kvp.Value)
                {
                    list.Add(new List<int>());
                }
                list[kvp.Value].Add(kvp.Key.val);
                if (kvp.Key.left != null)
                {
                    queue.Enqueue(new KeyValuePair<TreeNode, int>(kvp.Key.left, kvp.Value + 1));
                }
                if (kvp.Key.right != null)
                {
                    queue.Enqueue(new KeyValuePair<TreeNode, int>(kvp.Key.right, kvp.Value + 1));
                }
            }
            return list;
        }

        /// <summary>
        /// 是否是对称二叉树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSymmetric(TreeNode root)
        {
            return Ismirror(root, root);
        }

        bool Ismirror(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)//都为NULL
                return true;
            if (p == null || q == null)//有一个为NULL
                return false;
            if (p.val == q.val)
                return Ismirror(p.left, q.right) && Ismirror(p.right, q.left);
            return false;
        }


        /// <summary>
        /// 二叉树的最大深度
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth(TreeNode root)
        {
            return (root == null) ? 0 : Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }

        /// <summary>
        /// 前序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <param name="list"></param>
        public void PreOrder(TreeNode root,List<int> list) 
        {
            if (root != null)
            {
                list.Add(root.val);
                PreOrder(root.left, list);
                PreOrder(root.right, list);
            }
        }

        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <param name="list"></param>
        public void InOrder(TreeNode root, List<int> list)
        {
            if (root != null)
            {
                InOrder(root.left, list);
                list.Add(root.val);
                InOrder(root.right, list);
            }
        }

        /// <summary>
        /// 后序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <param name="list"></param>
        public void AfterOrder(TreeNode root, List<int> list)
        {
            if (root != null)
            {
                PreOrder(root.left, list);
                PreOrder(root.right, list);
                list.Add(root.val);
            }
        }


    }
}
