using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN
{
    public class LeetCode88
    {
        /// <summary>
        /// 合并两个有序数组
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public static void Merge1(int[] nums1, int m, int[] nums2, int n)
        {
            //先合并数组
            Array.Copy(nums2, 0 , nums1, m, n);
            //排序
            Array.Sort(nums1);
        }

        /// <summary>
        /// 遍历数组2,寻找数组1中需要插入的位置
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            for(int i = 0; i < nums2.Length; i++) {
                int j = m - 1 + i;
                for (; j >= 0; j--)
                {
                    if (nums1[j] > nums2[i])
                    {
                        nums1[j + 1] = nums1[j];
                    }else
                    {
                        nums1[j + 1] = nums1[j];
                        break;
                    }
                }

                nums1[j+1] = nums2[i];
            }
        }

        /// <summary>
        /// 第一个错误的版本(二分查找)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FirstBadVersion(int n)
        {
            int left = 1;
            int right = n;
            int mid = 0;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (IsBadVersion(mid))
                {
                    if (!IsBadVersion(mid - 1))
                    {
                        return mid;
                    }
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return -1;
        }

        private bool IsBadVersion(int n)
        {
            return false;
        }
    }
}
