using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN
{
    public class LeetCode561
    {
        public static int ArrayPairSum(int[] nums)
        {
            Array.Sort(nums);
            int sum = 0;
            for(int i = 0; i < nums.Length; i += 2)
            {
                sum += nums[i];
            }
            return sum;
        }
    }
}
