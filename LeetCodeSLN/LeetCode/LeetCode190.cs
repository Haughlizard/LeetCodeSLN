﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN
{
    class LeetCode190
    {
        /// <summary>
        /// 颠倒给定的 32 位无符号整数的二进制位。
        ///示例 1：
        ///输入: 00000010100101000001111010011100
        ///输出: 00111001011110000010100101000000
        ///解释: 输入的二进制串 00000010100101000001111010011100 表示无符号整数 43261596，
        ///      因此返回 964176192，其二进制表示形式为 00111001011110000010100101000000。
        ///示例 2：
        ///输入：11111111111111111111111111111101
        ///输出：10111111111111111111111111111111
        ///解释：输入的二进制串 11111111111111111111111111111101 表示无符号整数 4294967293，
        ///      因此返回 3221225471 其二进制表示形式为 10101111110010110010011101101001。
        ///来源：力扣（LeetCode）
        //链接：https://leetcode-cn.com/problems/reverse-bits
        ///著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static uint ReverseBits1(uint n)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < 32; i++)
            {
                sb.Append((n >> i & 0x01).ToString());
            }
            return Convert.ToUInt32(sb.ToString(), 2);
        }

        public static uint ReverseBits(uint n)
        {
            uint ans = 0;
            for (int i = 0; i < 32; ++i)
            {
                ans = ans | (((n >> i) & 0x1) << (31 - i));
            }
            return ans;
        }
    }
}
