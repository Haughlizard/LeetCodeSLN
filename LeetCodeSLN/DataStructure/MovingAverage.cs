using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN.DataStructure
{
    /// <summary>
    /// 给定一个整数数据流和一个窗口大小，根据该滑动窗口的大小，计算其所有整数的移动平均值。
    /// 示例:
    /// MovingAverage m = new MovingAverage(3);
    ///    m.next(1) = 1
    /// m.next(10) = (1 + 10) / 2
    /// m.next(3) = (1 + 10 + 3) / 3
    /// m.next(5) = (10 + 3 + 5) / 3
    /// </summary>
    public class MovingAverage
    {
        private int[] _items;
        private int head;
        private int winSize;
        private int size;
        /** Initialize your data structure here. */
        public MovingAverage(int size)
        {
            _items = new int[size];
            this.winSize = size;
            this.size = 0;
            head = -1;
        }

        public double Next(int val)
        {
            if (size < winSize)
                size++; 
            head = (head + 1) % winSize;
            _items[head] = val;
            double sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += _items[i];
            }
            return sum / size;
        }
    }
}
