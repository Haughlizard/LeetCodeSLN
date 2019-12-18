using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN
{
    class LeetCode334
    {
        /// <summary>
        /// 给定一个未排序的数组，判断这个数组中是否存在长度为 3 的递增子序列。
        /// 数学表达式如下:
        /// 如果存在这样的 i, j, k, 且满足 0 ≤ i<j<k ≤ n-1，
        /// 使得arr[i] < arr[j] < arr[k] ，返回 true ; 否则返回 false 。
        /// 说明: 要求算法的时间复杂度为 O(n)，空间复杂度为 O(1) 。
        /// 示例 1:
        /// 输入: [1,2,3,4,5]
        /// 输出: true
        /// 示例 2:
        /// 输入: [5,4,3,2,1]
        /// 输出: false
        /// 来源：力扣（LeetCode）
        /// 链接：https://leetcode-cn.com/problems/increasing-triplet-subsequence
        /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool IncreasingTriplet(int[] nums)
        {
            int a = int.MaxValue;
            int b = int.MaxValue;
            foreach (var e in nums)
            {
                if (e <= a)//最小的值
                {
                    a = e;
                }
                else if (e <= b)//第二小的值
                {
                    b = e;
                }
                else
                {
                    return true;//存在第三小的值,返回true
                }
            }
            return false;//否则返回false
        }
    }
}
