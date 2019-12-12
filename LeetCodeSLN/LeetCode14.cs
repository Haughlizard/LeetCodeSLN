using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN
{
    public class LeetCode14
    {
        /// <summary>
        /// 查找最长公共前缀
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0 || strs[0] == "") return "";
            for(int i = 0; i < strs[0].Length; i++)
            {
                for(int j = 1; j < strs.Length; j++)
                {
                    if (strs[j] == "") return "";

                    if (i < strs[j].Length)
                    {
                        if (strs[j][i] != strs[0][i])
                        {
                            return strs[0].Substring(0, i);
                        }
                    }else
                    {
                        return strs[0].Substring(0, i);
                    }
                }
            }
            return strs[0];
        }
    }
}
