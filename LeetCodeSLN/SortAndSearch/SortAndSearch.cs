using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN.SortAndSearch
{
    public class SortAndSearch
    {
        /// <summary>
        /// 合并两个数组
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            for(int i = n-1; i >= 0; i--)
            {
                for (int j = m - 1; j >= 0; j--)
                {
                    if (nums1[j] > nums2[i])
                    {
                        nums1[j + 1] = nums1[j];
                    }
                    else
                    {
                        nums1[j + 1] = nums2[i];
                    }
                }
            }
        }
    }
}
