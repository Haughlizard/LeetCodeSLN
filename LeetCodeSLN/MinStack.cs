using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN
{
    /// <summary>
    /// 最小栈
    /// </summary>
    class MinStack
    {
        private int[] _items;

        private int[] _defaultArray = new int[4];

        //int minIndex = -1;
        private int _size;

        public MinStack()
        {
            _items = _defaultArray;

        }

        public void Push(int x)
        {
            EnsureCapacity(_size + 1);
            _size++;
            _items[_size] = x;
        }
        
        /// <summary>
        /// 动态扩容或者缩容
        /// </summary>
        /// <param name="min"></param>
        private void EnsureCapacity(int min)
        {
            if (_items.Length == min)
            {
                int[] newArray = new int[min * 2];
                Array.Copy(_items, 0, newArray, 0, _items.Length);
                _items = newArray;
            }
            else if(_items.Length <= min / 4)
            {
                int newCapacity = 4;
                if( min/2 >4)
                {
                    newCapacity = min / 2;
                }
                int[] newArray = new int[min / 2];
                Array.Copy(_items, 0, newArray, 0, _items.Length);
                _items = newArray;
            }
        }

        public void Pop()
        {
            EnsureCapacity(_size - 1);
            _size--;
            
        }

        public int Top()
        {
            return _items[_size];
        }

        /// <summary>
        /// 获取最小值
        /// </summary>
        /// <returns></returns>
        public int GetMin()
        {
            int min = _items[1];
            for(int i = 1; i <= _size; i++)
            {
                if (_items[i] < min)
                    min = _items[i];
            }
            return min;
        }
    }

    /// <summary>
    /// 打乱数组
    /// </summary>
    public class Solution
    {
        private int[] _items;

        public Solution(int[] nums)
        {
            _items = nums;
        }

        /** Resets the array to its original configuration and return it. */
        public int[] Reset()
        {
            return _items;
        }

        /** Returns a random shuffling of the array. */
        public int[] Shuffle()
        {
            var items = new List<int>(_items);
            for(int i = 1;i< items.Count; i++)
            {
                Random rd = new Random();
                var index = rd.Next() % (i + 1);
                if (index != i) {
                    int tmp = items[i];
                    items[i] = items[index];
                    items[index] = tmp;
                }
            }
            return items.ToArray();
        }
    }

}
