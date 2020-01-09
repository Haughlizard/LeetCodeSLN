using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN.DataStructure
{
    public class PriorityQueue<T>:IEnumerable<T> where T:IComparable
    {
        private T[] _items;
        private int _size = 0;
        private const int _defaultCapacity = 4;
        static readonly T[] _emptyArray = new T[0];

        public PriorityQueue()
        {
            _items = _emptyArray;
        }

        public PriorityQueue(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentException("队列容量不能小于0", nameof(capacity));
            if (capacity == 0)
                _items = _emptyArray;
            else
                _items = new T[capacity];
        }

        public int Count
        {
            get { return _size; }
        }

        public int Capacity
        {
            get
            {
                return _items.Length;
            }
            private set
            {
                if (value < _size)
                    throw new ArgumentException("容量大小不能小于队列中数据的大小",nameof(value));
                if (value != _items.Length)
                {
                    if (value > 0)
                    {
                        T[] newItems = new T[value];
                        if (_size > 0)
                        {
                            Array.Copy(_items, 0, newItems, 0, _size);
                        }
                        _items = newItems;
                    }
                    else
                    {
                        _items = _emptyArray;
                    }
                }
            }
        }

        public void EnQueue(T t)
        {
            if (_size == _items.Length) EnsureCapacity(_size + 1);
            _items[_size++] = t;// 得到新插入值所在位置。
            int index = _size - 1;
            while (index > 0)
            {   // 它的父节点位置坐标
                int parentIndex = (index - 1) / 2;// 如果父节点的值小于子节点的值，你不满足堆的条件，那么就交换值
                if (_items[index].CompareTo( _items[parentIndex])>0)
                {
                    Swap(_items, index, parentIndex);
                    index = parentIndex;
                }
                else
                {   // 否则表示这条路径上的值已经满足降序，跳出循环
                    break;
                }
            }
        }

        public T DeQueue()
        {
            var result = _items[0];// 将最后位置的值放到根节点位置
            _items[0] = _items[--_size];//最后一个值赋给第一个值
            int index = 0;// 通过循环，保证父节点的值不能小于子节点。
            while (true)
            {
                int leftIndex = 2 * index + 1; // 左子节点
                int rightIndex = 2 * index + 2; // 右子节点
                // leftIndex >= _size 表示这个子节点还没有值。
                if (leftIndex >= _size)
                    break;
                int maxIndex = leftIndex;
                if (_items[leftIndex].CompareTo( _items[rightIndex]) < 0)
                    maxIndex = rightIndex;
                if (_items[index].CompareTo ( _items[maxIndex]) < 0 )
                {
                    Swap(_items, index, maxIndex);
                    index = maxIndex;
                }
                else
                {
                    break;
                }
            }
            return result;
        }

        public void Clear()
        {
            _size = 0;
            Capacity = 0;
        }

        private void EnsureCapacity(int min)
        {
            if (_items.Length < min)
            {
                int newCapacity = _items.Length == 0 ? _defaultCapacity : _items.Length * 2;
                if (newCapacity < min) newCapacity = min;
                Capacity = newCapacity;//复制数组的操作在属性的set方法里面做
            }
        }

        private void Swap(T[] items,int i,int j)
        {
            var tmp = items[i];
            items[i] = items[j];
            items[j] = tmp;
        }

        
        public IEnumerator<T> GetEnumerator()
        {
            return new PriorityQueueEnumertor(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new PriorityQueueEnumertor(this);
        }

        private class PriorityQueueEnumertor:IEnumerator<T>
        {
            private PriorityQueue<T> _queue;
            private T current;
            private int index;

            internal PriorityQueueEnumertor(PriorityQueue<T> queue)
            {
                this._queue = queue;
                index = 0;
                current = default(T);
            }

            public T Current
            {
                get { return current; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                var localList = _queue;

                if ((uint)index < (uint)localList._size)
                {
                    current = localList._items[index];
                    index++;
                    return true;
                }else
                {
                    return false;
                }
            }

            public void Reset()
            {
                index = 0;
                current = default(T);
            }
        }
    }
}
