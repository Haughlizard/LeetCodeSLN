using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN
{
    public class LeetCode724
    {
        public static int PivotIndex(int[] nums)
        {
            int ans = -1;
            int leftsum = 0;
            int rightsum = 0;
            //求出所有数的总和
            for (int i = 0; i < nums.Length; i++)
                rightsum += nums[i];

            for (int i = 0; i < nums.Length; i++)
            {
                rightsum -= nums[i];
                if (leftsum == rightsum)
                {
                    ans = i;
                    break;
                }
                else
                {
                    leftsum += nums[i];
                };
            };
            return ans;
        }
    }
}
