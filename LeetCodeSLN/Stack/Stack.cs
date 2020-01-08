using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN.Stack
{
    public class Stack
    {
        #region 1021. 删除最外层的括号
        /// <summary>
        /// 1021. 删除最外层的括号
        /// 不使用栈
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public string RemoveOuterParentheses(string S)
        {
            Stack<char> stack = new Stack<char>();
            StringBuilder sb = new StringBuilder();
            int startIndex = 0;
            int a = 0;
            for(int i=0; i < S.Length; i++)
            {
                if (S[i] == '(') a++;
                else a--;
                
                if (a == 0)
                {
                    var div = S.Substring(startIndex, i - startIndex + 1);
                    if (div.Length >= 4)
                    {
                        sb.Append(div.Substring(1, div.Length - 2));
                    }
                    startIndex = i + 1;
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 1021. 删除最外层的括号
        /// 使用栈
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public string RemoveOuterParentheses1(string S)
        {
            Stack<char> stack = new Stack<char>();
            StringBuilder sb = new StringBuilder();
            int startIndex = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == '(') stack.Push(S[i]);
                else stack.Pop();

                if (stack.Count == 0)
                {
                    var div = S.Substring(startIndex, i - startIndex + 1);
                    if (div.Length >= 4)//小于长度小于4的有效括号()被置为""
                    {
                        sb.Append(div.Substring(1, div.Length - 2));
                    }
                    startIndex = i + 1;
                }
            }
            return sb.ToString();
        }
        #endregion

        public int Calculate(string s)
        {
            //TODO:待完成
            return 0;
        }

        /// <summary>
        /// 逆波兰表达式求值
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        public int EvalRPN(string[] tokens)
        {
            Stack<int> stack = new Stack<int>();
            foreach(var s in tokens)
            {
                if(s == "+"|| s == "-"|| s == "*"|| s == "/")
                {
                    var right = stack.Pop();
                    var left = stack.Pop();
                    var result = 0;
                    switch (s)
                    {
                        case "+":
                            result = left + right;
                            break;
                        case "-":
                            result = left - right;
                            break;
                        case "*":
                            result = left * right;
                            break;
                        case "/":
                            result = left / right;
                            break;
                    }
                    stack.Push(result);
                }else
                {
                    stack.Push(int.Parse(s));
                }
            }
            return stack.Pop();
        }


    }
}
