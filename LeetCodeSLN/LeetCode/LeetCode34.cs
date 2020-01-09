using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN
{
    /// <summary>
    /// 给定一个按照升序排列的整数数组 nums，和一个目标值 target。找出给定目标值在数组中的开始位置和结束位置。
    ///你的算法时间复杂度必须是 O(log n) 级别。
    ///如果数组中不存在目标值，返回[-1, -1]。
    ///示例 1:
    ///输入: nums = [5,7,7,8,8,10], target = 8
    ///输出: [3,4]
    /// 示例 2:
    ///输入: nums = [5,7,7,8,8,10], target = 6
    ///输出: [-1,-1]
    ///来源：力扣（LeetCode）
    ///链接：https://leetcode-cn.com/problems/find-first-and-last-position-of-element-in-sorted-array
    ///著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    class LeetCode34
    {
        /// <summary>
        /// 暴力破解法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SearchRange1(int[] nums, int target)
        {
            int left = -1;
            int right = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    left = i;
                    right = i;
                    while (i + 1 < nums.Length && nums[i + 1] == target)
                    {
                        right += 1;
                        i += 1;
                    }
                    break;
                }

            }
            return new int[] { left, right };
        }

        /// <summary>
        /// 二分查找法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SearchRange(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            int privot = (left + right) / 2;
            while (left <= right)
            {
                privot = (left + right) / 2;
                if (nums[privot] > target)
                {
                    right = privot - 1;
                } else if (nums[privot] < target)
                {
                    left = privot + 1;
                } else
                {
                    int rangeLeft = privot;
                    int rangeRight = privot;
                    while (rangeLeft - 1 >= 0 && nums[rangeLeft - 1] == target)
                    {
                        rangeLeft -= 1;
                    }

                    while (rangeRight + 1 < nums.Length && nums[rangeRight + 1] == target)
                    {
                        rangeRight += 1;
                    }
                    return new int[] { rangeLeft, rangeRight };
                }
            }
            return new int[] { -1, -1 };
        }
    }
}
