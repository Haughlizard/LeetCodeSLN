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
        /// <summary>
        /// 是否是回文字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsPalindrome(string s)
        {
            s = s.ToLower();
            int left = 0;
            int right = s.Length - 1;
            while (left <= right)
            {
                if (!char.IsLetterOrDigit(s[left]))
                    {
                    left++;
                    continue;
                }
                if(!char.IsLetterOrDigit(s[right]))
                {
                    right--;
                    continue;
                }
                if (s[left++] != s[right--])
                    return false;
            }
            return true;
        }

        public string ReverseWords(string s)
        {
            //TODO:待完成
            //var newstr = Reverse(s);
            var t = s.Split(' ').SkipWhile(p => String.IsNullOrEmpty(p.Trim()));
            //t.
            return string.Join(" ", t.Reverse());
        }

        /// <summary>
        /// 反转字符串单词
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseWords1(string s)
        {
            string[] strs = s.Split(' ');
            for (int i = 0; i < strs.Length; i++)
            {
                strs[i] = Reverse(strs[i]);
            }

            return string.Join(" ", strs);
        }



        private string Reverse(string s)
        {
            var chars = s.Trim().ToArray();
            int left = 0;
            int right = chars.Length - 1;
            while (left <= right)
            {
                var tmp = chars[left];
                chars[left] = chars[right];
                chars[right] = tmp;
                left++;
                right--;
            }
            return string.Join("", chars);
        }

        /// <summary>
        /// 二进制求和
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string AddBinary(string a, string b)
        {
            string step = "0";
            string[] sum = new string[a.Length >= b.Length ? a.Length + 1 : b.Length + 1];
            int index = sum.Length - 1;
            for(int i = a.Length - 1, j = b.Length - 1; i >= 0 || j >= 0; j--, i--)
            {
                if (i >= 0 && j >= 0)
                {
                    if(a[i]=='1'&&b[j]=='1')
                    {
                        if(step=="1")
                        {
                            sum[index] = "1";
                            step = "1";
                        }else
                        {
                            sum[index] = "0";
                            step = "1";
                        }
                        index--;
                    }else if (a[i] == '1'||b[j]=='1')
                    {
                        if (step == "1")
                        {
                            sum[index] = "0";
                            step = "1";
                        }
                        else
                        {
                            sum[index] = "1";
                            step = "0";
                        }
                        index--;
                    }else
                    {
                        sum[index] = step;
                        step = "0";
                        index--;
                    }
                }else if (i >= 0)
                {
                    if (a[i] == '1')
                    {
                        if (step == "1")
                        {
                            sum[index] = "0";
                            step = "1";
                        }
                        else
                        {
                            sum[index] = "1";
                            step = "0";
                        }
                        index--;
                    }else
                    {
                        sum[index] = step;
                        step = "0";
                        index--;
                    }
                }else if(j>=0)
                {
                    if (b[j] == '1')
                    {
                        if (step == "1")
                        {
                            sum[index] = "0";
                            step = "1";
                        }
                        else
                        {
                            sum[index] = "1";
                            step = "0";
                        }
                        index--;
                    }
                    else
                    {
                        sum[index] = step;
                        step = "0";
                        index--;
                    }
                }
            }
            if (step == "1")
            {
                sum[0] = "1";
            }
            return string.Join("", sum);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public int StrStr(string haystack, string needle)
        {
            if (String.IsNullOrEmpty(needle)) return 0;
           for(int i = 0; i < haystack.Length; i++)
            {
                for(int j = 0; j < needle.Length; j++)
                {
                    if(i+j < haystack.Length)
                    {
                        if (haystack[i + j] != needle[j])
                        {
                            break;
                        }else
                        {
                            if (j == needle.Length - 1)
                            {
                                return i;
                            }
                        }
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// 最长的回文子串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome(string s)
        {
            //TODO:待完成
            return string.Empty;
        }

        /// <summary>
        /// IP地址无效化
        /// 使用内置ReplaceAPI
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public string DefangIPaddr1(string address)
        {
            //速度没有使用StringBuilder的版本快
            return address.Replace(".", "[.]");
        }

        /// <summary>
        /// IP地址无效化
        /// 使用StringBuilder
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public string DefangIPaddr2(string address)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < address.Length; i++)
            {
                if (address[i] != '.')
                {
                    sb.Append(address[i]);
                }
                else
                {
                    sb.Append('[').Append(address[i]).Append(']');
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 亲密字符串
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public bool BuddyStrings(String A, String B)
        {
            if (A.Length != B.Length)
            {
                return false;
            }
            else if (A.Equals(B))
            {
                for (int i = 0; i < A.Length; i++)
                    if (A.IndexOf(A[i]) != i)
                        return true;
            }
            int count = 0;
            char strA1 = char.MinValue, strA2 = char.MinValue, strB1 = char.MinValue, strB2 = char.MinValue;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] != B[i])
                {
                    count++;
                    if (count == 1)
                    {
                        strA1 = A[i];
                        strB1 = B[i];
                    }
                    if (count == 2)
                    {
                        strA2 = A[i];
                        strB2 = B[i];
                    }
                }
                if (count > 2)
                    return false;
            }
            return count == 2 && strA1 == strB2 && strA2 == strB1;
        }

        /// <summary>
        /// 删除无效括号
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string MinRemoveToMakeValid(string s)
        {
            //TODO: 删除无效括号
            return s;
        }


    }
}
