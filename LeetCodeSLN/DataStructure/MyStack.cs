using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN.DataStructure
{
    
    public class MyStack1
    {
        /// <summary>
        /// 根据每日 气温 列表，请重新生成一个列表，
        /// 对应位置的输入是你需要再等待多久温度才会升高超过该日的天数。
        /// 如果之后都不会升高，请在该位置用 0 来代替。
        /// 例如，给定一个列表 temperatures = [73, 74, 75, 71, 69, 72, 76, 73]，
        /// 你的输出应该是[1, 1, 4, 2, 1, 1, 0, 0]。
        /// 提示：气温 列表长度的范围是[1, 30000]。
        /// 每个气温的值的均为华氏度，都是在[30, 100] 范围内的整数。
        /// </summary>
        public int[] DailyTemperatures(int[] T)
        {
            return new int[0];
        }

        /// <summary>
        /// 逆波兰表达式求值
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        public int EvalRPN(string[] tokens)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < tokens.Length; i++) {
                int n = 0;
                if (Int32.TryParse(tokens[i],out n))
                {
                    stack.Push(n);
                }
                else
                {
                    int a = stack.Pop();
                    int b = stack.Pop();
                    stack.Push(Calculate(tokens[i], b, a));
                }
            }

            return stack.Pop();
        }

        /// <summary>
        /// 计算结果
        /// </summary>
        /// <param name="s">运算符</param>
        /// <param name="a">运算符左边的数</param>
        /// <param name="b">运算符右边的数</param>
        /// <returns></returns>
        private int Calculate(string s,int a,int b)
        {
            switch (s)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "/":
                    return a / b;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// 给定一个经过编码的字符串，返回它解码后的字符串。
        /// 编码规则为: k[encoded_string]，表示其中方括号内部的 encoded_string 正好重复 k 次。
        /// 注意 k 保证为正整数。
        /// 你可以认为输入字符串总是有效的；输入字符串中没有额外的空格，且输入的方括号总是符合格式要求的。
        /// 此外，你可以认为原始数据不包含数字，所有的数字只表示重复的次数 k ，
        /// 例如不会出现像 3a 或 2[4] 的输入。
        /// 示例:
        /// s = "3[a]2[bc]", 返回 "aaabcbc".
        /// s = "3[a2[c]]", 返回 "accaccacc".
        /// s = "2[abc]3[cd]ef", 返回 "abcabccdcdcdef".
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string DecodeString(string s)
        {
            //TODO:字符串解码
            return string.Empty;
        }

        /// <summary>
        /// 接雨水
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap(int[] height)
        {
            return 1;
        }
    }

    /// <summary>
    /// 队列实现栈
    /// </summary>
    public class MyStack
    {
        private Queue<int> _queue;
        private Queue<int> _assQueue;
        private int top = 0;
        /** Initialize your data structure here. */
        public MyStack()
        {
            _queue = new Queue<int>();
            _assQueue = new Queue<int>();
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            top = x;
            _queue.Enqueue(x);
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            int o = 0;
            while (_queue.Count > 1)
            {
                _assQueue.Enqueue(_queue.Dequeue());
            }
            if (_queue.Count > 0)
            {
                o = _queue.Dequeue();
                
                while (_assQueue.Count> 0)
                {
                    if(_assQueue.Count==1)
                        top = _assQueue.Peek();
                    _queue.Enqueue(_assQueue.Dequeue());
                }
            }
            return o;
        }

        /** Get the top element. */
        public int Top()
        {
            return top;
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return _queue.Count == 0;
        }
    }

    /// <summary>
    /// 用栈实现队列
    /// </summary>
    public class MyQueue
    {
        private Stack<int> _data;
        private Stack<int> _tmp;
        private int head;
        /** Initialize your data structure here. */
        public MyQueue()
        {
            _data = new Stack<int>();
            _tmp = new Stack<int>();
        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            if (_data.Count == 0)
                head = x;
            _data.Push(x);
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            int o = 0;
            while (_data.Count > 1)
            {
                _tmp.Push(_data.Pop());
            }

            if(_data.Count>0)
            {
                o = _data.Pop();
                if (_data.Count == 0 &&_tmp.Count>0)
                    head = _tmp.Peek();
                while (_tmp.Count > 0)
                {
                    _data.Push(_tmp.Pop());
                }
            }
            return o;
        }

        /** Get the front element. */
        public int Peek()
        {
            return head;
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return _data.Count == 0;
        }
    }


    /// <summary>
    /// 实现基本的哈希表
    /// </summary>
    public class MyHashSet
    {

        /** Initialize your data structure here. */
        public MyHashSet()
        {

        }

        public void Add(int key)
        {

        }

        public void Remove(int key)
        {

        }

        /** Returns true if this set contains the specified element */
        public bool Contains(int key)
        {
            return false;
        }
    }
}
