using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN.Strings
{
    public class Strings
    {
        /// <summary>
        /// 反转字符串
        /// </summary>
        /// <param name="s"></param>
        public void ReverseString(char[] s)
        {
            int left = 0;
            int right = s.Length-1;
            while (left < right)
            {
                var tmp = s[left];
                s[left++] = s[right];
                s[right--] = tmp;
            }
        }

        /// <summary>
        /// 整数反转
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int Reverse(int x)
        {
            return 0;
        }

        /// <summary>
        /// 第一个不重复字符的索引
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int FirstUniqChar(string s)
        {
            for(int i = 0; i < s.Length; i++)
            {
                if(s.LastIndexOf(s[i])==s.IndexOf(s[i]))
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// 是否是字母易位词(超时未通过)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram1(string s, string t)
        {
            if (s.Length != t.Length) return false;

            char[] chars = s.ToCharArray();
            for(int i = 0; i < t.Length; i++)
            {
                if(s.Contains(t[i]))
                    s = s.Remove(s.IndexOf(t[i]), 1);
            }

            if (String.IsNullOrEmpty(s))
                return true;
            return false;
        }

        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;
            var chars = s.ToArray();
            var chart = t.ToArray();
            Array.Sort(chars);
            Array.Sort(chart);
            for(int i = 0; i < chars.Length; i++)
            {
                if (chars[i] != chart[i])
                    return false;
            }
            return true;
        }
    }
}
