﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN
{
    /// <summary>
    /// 给定一个正整数，返回它在 Excel 表中相对应的列名称
    /// 例如，
    ///    1 -> A
    ///    2 -> B
    ///    3 -> C
    ///    ...
    ///    26 -> Z
    ///    27 -> AA
    ///    28 -> AB 
    ///    ...
    /// 示例 1:
    /// 输入: 1
    /// 输出: "A"
    /// 示例 2:
    /// 输入: 28
    /// 输出: "AB"
    /// 示例 3:
    /// 输入: 701
    /// 输出: "ZY"
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode-cn.com/problems/excel-sheet-column-title
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    class LeetCode168
    {
        public string ConvertToTitle(int n)
        {
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (n <= 0)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            while (n > 0)
            {
                n--;
                sb.Insert(0,alphabets[n % 26]);
                n = n / 26;
            }
            return sb.ToString();
        }
    }
}
