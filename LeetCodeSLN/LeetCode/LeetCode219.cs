using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN
{
    /// <summary>
    /// 给定一个整数数组和一个整数 k，
    /// 判断数组中是否存在两个不同的索引 i 和 j，
    /// 使得 nums [i] = nums [j]，并且 i 和 j 的差的绝对值最大为 k。
    /// 示例 1:
    /// 输入: nums = [1,2,3,1], k = 3
    /// 输出: true
    /// 示例 2:
    /// 输入: nums = [1,0,1,1], k = 1
    /// 输出: true
    /// 示例 3:
    /// 输入: nums = [1,2,3,1,2,3], k = 2
    /// 输出: false
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode-cn.com/problems/contains-duplicate-ii
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    class LeetCode219
    {
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            if (nums.Length <= 0)
                return false;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]) && ((i - map[nums[i]]) <= k))
                {
                    return true;
                }
                map.Add(nums[i], i);
            }
            return false;
        }
    }
}
