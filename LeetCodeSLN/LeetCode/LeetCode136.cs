using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN
{
    public class LeetCode136
    {
        public static int SingleNumber1(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];
            Array.Sort(nums);
            for(int i = 0; i < nums.Length - 1; i += 2)
            {
                if (nums[i] != nums[i + 1])
                {
                    return nums[i];
                }
            }
            return nums[nums.Length-1];
        }

        /// <summary>
        /// 按位异或
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int SingleNumber(int[] nums)
        {
            //注意，这里为0而不是其它值得原因并不是盲目的：甲 按位异或 0 得 甲，甲 按位异或 甲 得 0
            int result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                // ^ 为C#提供的按位异或操作符，而 ^= 相似 += ,其效果等价于 result = result ^ nums[i]
                result ^= nums[i];
            }
            return result;
        }
    }
}
