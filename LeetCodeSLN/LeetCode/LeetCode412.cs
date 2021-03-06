﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN
{
    /// <summary>
    /// 写一个程序，输出从 1 到 n 数字的字符串表示。
    ///1. 如果 n是3的倍数，输出“Fizz”；
    ///2. 如果 n是5的倍数，输出“Buzz”；
    ///3.如果 n同时是3和5的倍数，输出 “FizzBuzz”。
    ///示例：
    ///n = 15,
    ///返回:
    ///["1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz"]
    ///来源：力扣（LeetCode）
    ///链接：https://leetcode-cn.com/problems/fizz-buzz
    ///著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    class LeetCode412
    {

        public IList<string> FizzBuzz(int n)
        {
            IList<string> list = new List<string>();
            for(int i = 1; i <= n; i++)
            {
                int m = i % 3;
                int l = i % 5;
                if (m == 0 && l == 0)
                    list.Add("FizzBuzz");
                else if (m == 0)
                    list.Add("Fizz");
                else if (l == 0)
                    list.Add("Buzz"); 
                else
                    list.Add(i.ToString());
            }
            return list;
        }
    }
}
