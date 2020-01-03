using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN.Design
{
    /// <summary>
    /// 锯齿迭代器
    /// </summary>
    public class ZigzagIterator
    {
        private Queue<int> _queue;
        public ZigzagIterator(IList<int> v1, IList<int> v2)
        {
            _queue = new Queue<int>();
            for(int i = 0; i < v1.Count; i++)
            {
                _queue.Enqueue(v1[i]);
                if (i < v2.Count)
                {
                    _queue.Enqueue(v2[i]);
                }
            }

            if (v1.Count < v2.Count)
            {
                for(int i = v1.Count; i < v2.Count; i++)
                {
                    _queue.Enqueue(v2[i]);
                }
            }
        }

        public bool HasNext()
        {
            return _queue.Count > 0;
        }

        public int Next()
        {
            return _queue.Dequeue();
        }
    }
}
