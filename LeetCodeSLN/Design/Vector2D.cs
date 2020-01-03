using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN.Design
{
    /// <summary>
    /// 展开二维向量
    /// </summary>
    public class Vector2D
    {
        private Queue<int> _queue;
        public Vector2D(int[][] v)
        {
            _queue = new Queue<int>();
            foreach(var arr in v)
            {
                foreach(var n in arr)
                {
                    _queue.Enqueue(n);
                }
            }
        }

        public int Next()
        {
            return _queue.Dequeue();
        }

        public bool HasNext()
        {
            return _queue.Count > 0;
        }
    }
}
