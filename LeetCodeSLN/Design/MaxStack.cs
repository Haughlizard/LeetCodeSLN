using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN.Design
{
    public class MaxStack
    {
        private Stack<int> _stack;
        private SortedList<int,int> _sortedList;
        private int _max;
        /** initialize your data structure here. */
        public MaxStack()
        {
            _stack = new Stack<int>();
            _sortedList = new SortedList<int, int>();
        }

        public void Push(int x)
        {
            _stack.Push(x);
            _sortedList.Add(x, 0);
        }

        public int Pop()
        {
            return _stack.Pop();
            //_sortedList.re
        }

        public int Top()
        {
            return _stack.Peek();
        }

        public int PeekMax()
        {
            return _sortedList.LastOrDefault().Key;
        }

        public int PopMax()
        {
            Stack<int> tmp = new Stack<int>();
            var max = _sortedList.LastOrDefault().Key;
            while (_stack.Peek() != max)
            {

            }
            return 0;

        }
    }
}
