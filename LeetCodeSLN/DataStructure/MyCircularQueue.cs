using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN.DataStructure
{
    /// <summary>
    /// 循环队列
    /// </summary>
    public class MyCircularQueue
    {
        private int[] _items;
        private int head;
        private int tail;
        private int size;
       
        /** Initialize your data structure here. Set the size of the queue to be k. */
        public MyCircularQueue(int k)
        {
            _items = new int[k];
            head = -1;
            tail = -1;
            size = k;
        }

        /** Insert an element into the circular queue. Return true if the operation is successful. */
        public bool EnQueue(int value)
        {
            if (IsFull() == true)
            {
                return false;
            }
            if (IsEmpty() == true)
            {
                head = 0;
            }
            tail = (tail + 1) % size;
            _items[tail] = value;
            return true;
        }

        /** Delete an element from the circular queue. Return true if the operation is successful. */
        public bool DeQueue()
        {
            if (IsEmpty() == true)
            {
                return false;
            }
            if (head == tail)
            {
                head = -1;
                tail = -1;
                return true;
            }
            head = (head + 1) % size;
            return true;
        }

        /** Get the front item from the queue. */
        public int Front()
        {
            if (IsEmpty() == true)
            {
                return -1;
            }
            return _items[head];
        }

        /** Get the last item from the queue. */
        public int Rear()
        {
            if (IsEmpty() == true)
            {
                return -1;
            }
            return _items[tail];
        }

        /** Checks whether the circular queue is empty or not. */
        public bool IsEmpty()
        {
            return head == -1;
        }

        /** Checks whether the circular queue is full or not. */
        public bool IsFull()
        {
            return ((tail + 1) % size) == head;
        }
    }
}
