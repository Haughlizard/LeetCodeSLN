using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN.DataStructure
{
    
    public class ArrayClass
    {
        /// <summary>
        /// 查找错误的元素
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] FindErrorNums(int[] nums)
        {
            //TODO:待完成
            return new int[] { 0, 0 };
        }

        /// <summary>
        /// 给定一组非负整数，重新排列它们的顺序使之组成一个最大的整数。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public string LargestNumber(int[] nums)
        {
            string[] snums = new string[nums.Length];
            for(int i = 0;i <nums.Length;i++)
            {
                snums[i] = nums[i].ToString();
            }
            Array.Sort(snums);
            StringBuilder sb = new StringBuilder();
            for(int i = snums.Length - 1; i >= 0; i--)
            {
                sb.Append(snums[i]);
            }
            return sb.ToString();
        }

        /**
         * @param buf Destination buffer
         * @param n   Number of characters to read
         * @return    The number of actual characters read
        */
        public int Read(char[] buf, int n)
        {
            //TODO:待完成
            return 0;
            //int count = n / 4;
            //int end = n % 4;
            //bool isEnd = false;
            //List<char> list = new List<char>();
            //for(int i = 0; i < count; i++)
            //{
            //    char[] t = new char[4];
            //    int readCount = Read4(t);

            //    for(int j = 0; j < readCount; j++)
            //    {
            //        list.Add(t[j]);
            //    }
            //    if (readCount < 4)
            //    {
            //        isEnd = true;
            //        break;
            //    }
                    
            //}
            //char[] tmp = new char[4];
            //if (!isEnd)
            //{
            //    Read4(tmp);
            //    for(int i = 0; i < end; i++)
            //    {
            //        list.Add(tmp[i]);
            //    }
            //}

            //return list.Count;
        }

        /// <summary>
        /// 检测大写字母
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool DetectCapitalUse(string word)
        {
            char[] cs = word.ToArray();
            int upper = 0;//大写字母个数
            int lower = 0;//小写字母个数
            for (int i = 0; i < cs.Length; i++)
            {
                if (cs[i] >= 'a')
                {
                    lower++;
                }
                else
                {
                    upper++;
                }
            }
            if (upper == cs.Length)
            { //全大写
                return true;
            }
            if (lower == cs.Length)
            {//全小写
                return true;
            }
            if (upper == 1 && cs[0] < 'a')
            {//首字母大写
                return true;
            }
            return false;
        }
    }
}
