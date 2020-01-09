using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN
{
    public class MyHashSet
    {

        #region private members
        /// <summary>
        /// 容量上限
        /// </summary>
        private double m_limitedMaxRate;

        /// <summary>
        /// 容量下限
        /// </summary>
        private double m_limitedMinRate;

        /// <summary>
        /// 链表最大长度（链表中链表节点最大数量）
        /// </summary>
        private int m_linklistNodeMaxCount;

        /// <summary>
        /// 初始容量大小
        /// </summary>
        private int m_initCapacity;

        /// <summary>
        /// 内部容器（数组）
        /// </summary>
        private LinkedList<int>[] m_innerArray;

        /// <summary>
        /// 内部容器中，已填充槽位的数量
        /// </summary>
        private int m_elementCount;
        #endregion

        public MyHashSet()
        {
            //设定值
            m_limitedMaxRate = 0.9;
            m_limitedMinRate = 0.1;
            m_linklistNodeMaxCount = 10;
            m_initCapacity = 64;

            //变动值
            m_innerArray = new LinkedList<int>[m_initCapacity];
            m_elementCount = 0;
        }

        public void Add(int key)
        {
            if (Contains(key)) return;

            m_elementCount = LoopAdd(key, m_innerArray, m_elementCount);

            //扩容，容量为原来的2倍
            if (1.0 * m_elementCount / m_innerArray.Length > m_limitedMaxRate) MoveItem(new LinkedList<int>[m_innerArray.Length * 2]);
        }

        public void Remove(int key)
        {
            var posTemp = LoopFindKey(key);
            if (posTemp == -1) return;

            m_innerArray[posTemp].Remove(key);
            if (m_innerArray[posTemp].Count == 0)
            {
                m_innerArray[posTemp] = null;
                m_elementCount--;

                if (m_initCapacity == m_innerArray.Length || 1.0 * m_elementCount / m_innerArray.Length >= m_limitedMinRate) return;

                //缩容，减少为原来的 1/2
                MoveItem(new LinkedList<int>[m_innerArray.Length / 2]);
            }
        }

        public bool Contains(int key)
        {
            return LoopFindKey(key) != -1;
        }

        #region Tools
        /// <summary>
        /// 向指定的集合中添加项，并返回添加到了哪个槽位
        /// </summary>
        private int LoopAdd(int key, LinkedList<int>[] array, int elementCount)
        {
            var indexTemp = key % array.Length;
            for (int i = 0; i < array.Length; i++)
            {
                var newIndexTemp = (i + indexTemp) % array.Length;

                if (array[newIndexTemp] == null)
                {
                    array[newIndexTemp] = new LinkedList<int>();
                    elementCount++;
                }

                if (array[newIndexTemp].Count < m_linklistNodeMaxCount)
                {
                    array[newIndexTemp].AddLast(key);
                    return elementCount;
                }
            }

            throw new Exception("RecursiveAdd");
        }

        /// <summary>
        /// 负责往新的集合中迁移数据（扩容、缩容）
        /// </summary>
        private void MoveItem(LinkedList<int>[] newArray)
        {
            var m_newElementCount = 0;
            foreach (var arrItem in m_innerArray)
            {
                if (arrItem == null) continue;

                foreach (var innerItem in arrItem) m_newElementCount = LoopAdd(innerItem, newArray, m_newElementCount);
            }

            Array.Clear(m_innerArray, 0, m_innerArray.Length);

            m_innerArray = newArray;
            m_elementCount = m_newElementCount;
        }

        /// <summary>
        /// 在集合中查找项，并返回所在的槽位
        /// 返回-1，表示不存在查找项
        /// </summary>
        private int LoopFindKey(int key)
        {
            var indexTemp = key % m_innerArray.Length;
            for (int i = 0; i < m_innerArray.Length; i++)
            {
                var newIndexTemp = (i + indexTemp) % m_innerArray.Length;

                if (m_innerArray[newIndexTemp] == null) return -1;
                if (m_innerArray[newIndexTemp].Contains(key)) return newIndexTemp;
            }

            return -1;
        }
        #endregion
    }
}
