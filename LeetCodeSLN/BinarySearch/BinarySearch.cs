using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN.BinarySearch
{
    public class BinarySearch
    {
        /// <summary>
        /// 1064 不动点
        /// 暴力解法
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int FixedPoint1(int[] A)
        {
            for(int i = 0; i < A.Length; i++)
            {
                if (i == A[i])
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// 1064 不动点
        /// 二分查找 
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int FixedPoint(int[] A)
        {
            int left = 0;
            int right = A.Length - 1;
            int mid = 0;
            int index = -1;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (A[mid] > mid)
                    right = mid - 1;
                else if (A[mid] < mid)
                    left = mid + 1;
                else
                {
                    index = mid;
                    right = mid - 1;
                }
            }
            return index;
        }

        /// <summary>
        /// 1150. 检查一个数是否在数组中占绝大多数
        /// 暴力法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool IsMajorityElement1(int[] nums, int target)
        {
            int cnt = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                    cnt++;
                if (cnt > nums.Length / 2)
                    return true;
            }
            return false;
        }

        /// <summary>
        ///  1150. 检查一个数是否在数组中占绝大多数
        ///  二分查找
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool IsMajorityElement(int[] nums, int target)
        {
            int indexMin = FindIndex(nums, target, true);
            int indexMax = FindIndex(nums, target, false);

            if (indexMax == -1)
                return false;

            return indexMax - indexMin + 1 > nums.Length / 2;

        }
        private int FindIndex(int[] nums,int target, bool isMin)
        {
            int left = 0;
            int right = nums.Length - 1;
            int mid = 0;
            int index = -1;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (nums[mid] < target)
                    left = mid + 1;
                else if (nums[mid] > target)
                    right = mid - 1;
                else
                {
                    index = mid;
                    if (isMin)
                    {
                        right = mid - 1;
                    }else
                    {
                        left = mid + 1;
                    }
                }
            }
            return index;

        }

        /// <summary>
        /// 山脉数组的峰顶索引
        /// 二分查找
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int PeakIndexInMountainArray1(int[] A)
        {
            int left = 0, right = A.Length - 1;
            int mid = 0;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (mid == 0 || mid == A.Length - 1)
                    return mid;
                else if (A[mid - 1] < A[mid] && A[mid] < A[mid + 1])
                    left = mid + 1;
                else if (A[mid - 1] > A[mid] && A[mid] > A[mid + 1])
                    right = mid - 1;
                else
                {
                    return mid;
                }
            }
            return -1;
        }

        /// <summary>
        /// 寻找比目标字母大的最小字母
        /// </summary>
        /// <param name="letters"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public char NextGreatestLetter(char[] letters, char target)
        {
            return new char();
        }

        /// <summary>
        /// 392. 判断子序列
        /// 暴力破解法
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsSubsequence1(string s, string t)
        {
            string tmp = t;
            int i = 0;
            foreach (var ch in s)
            {
                bool isContains = false;
                for(; i < tmp.Length; i++)
                {
                    if (ch == tmp[i])
                    {
                        i = i + 1;
                        isContains = true;
                        break;
                    }
                }
                if (!isContains)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 392. 判断子序列
        /// 双指针法
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsSubsequence(string s, string t)
        {
            int sIndex = 0, tIndex = 0;
            while (sIndex < s.Length && tIndex < t.Length)
            {
                if(s[sIndex]==t[tIndex])
                {
                    sIndex++;
                }
                tIndex++;
            }

            return sIndex == s.Length;
        }

        #region 1095. 山脉数组中查找目标值
        /// <summary>
        /// 1095. 山脉数组中查找目标值
        /// </summary>
        /// <param name="target"></param>
        /// <param name="mountainArr"></param>
        /// <returns></returns>
        public int FindInMountainArray(int target, MountainArray mountainArr)
        {
            int peakIndex = PeakIndexInMountainArray(mountainArr);
            if (target > mountainArr.Get(peakIndex))
                return -1;

            int minLeft = BinarySearchLeft(target, peakIndex, mountainArr);
            if (minLeft != -1)
                return minLeft;

            int minRight = BinarySearchRight(target, peakIndex + 1, mountainArr);
            return minRight;
        }

        private int BinarySearchLeft(int target, int high, MountainArray mountainArr)
        {
            int left = 0, right = high, mid = 0;
            int min = -1;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (mountainArr.Get(mid) > target)
                    right = mid - 1;
                else if (mountainArr.Get(mid) < target)
                    left = mid + 1;
                else
                {
                    min = mid;
                    right = mid - 1;
                }
            }
            return min;
        }

        private int BinarySearchRight(int target, int low, MountainArray mountainArr)
        {
            int left = low, right = mountainArr.Length()-1, mid = 0;
            int min = -1;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (mountainArr.Get(mid) < target)
                    right = mid - 1;
                else if (mountainArr.Get(mid) > target)
                    left = mid + 1;
                else
                {
                    min = mid;
                    right = mid - 1;
                }
            }
            return min;
        }

        /// <summary>
        /// 查找峰顶索引
        /// </summary>
        /// <param name="mountainArr"></param>
        /// <returns></returns>
        private int PeakIndexInMountainArray(MountainArray A)
        {
            int left = 0, right = A.Length() - 1;
            int mid = 0;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (mid == 0)
                {
                    if(A.Get(mid) < A.Get(mid + 1))
                        return mid + 1;
                    else
                        return mid;
                }else if (mid == A.Length() - 1)
                {
                    if (A.Get(mid - 1) > A.Get(mid))
                        return mid - 1;
                    else
                        return mid;
                }  
                else if (A.Get(mid - 1) < A.Get(mid) && A.Get(mid) < A.Get(mid + 1))
                    left = mid + 1;
                else if (A.Get(mid - 1) > A.Get(mid) && A.Get(mid) > A.Get(mid + 1))
                    right = mid - 1;
                else
                {
                    return mid;
                }
            }
            return -1;
        }
        #endregion
    }

    public class MountainArray
    {
        int[] _num;
        public MountainArray(int[] nums)
        {
            _num = nums;
        }

        public int Get(int index)
        {
            return _num[index];
        }

        public int Length()
        {
            return _num.Length;
        }
    }
}
