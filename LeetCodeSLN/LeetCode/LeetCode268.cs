using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN
{
    public class LeetCode268
    {
        /// <summary>
        /// 返回缺失数字
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MissingNumber(int[] nums)
        {
            Array.Sort(nums);
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i)
                    return i;
            }
            return nums[nums.Length - 1] + 1;
        }
    }
}
