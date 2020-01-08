using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN.Heap
{
    public class Heap
    {
        /// <summary>
        /// 堆排序
        /// </summary>
        /// <param name="nums"></param>
        public void HeadSort(int[] nums)
        {
            int length = nums.Length;
            for(int i = nums.Length/2; i >= 0; i--)
            {
                Heapfiy(nums, i, length);
            }

            for(int i = length; i > 1; i--)
            {
                Swap(nums, 0, i-1);
                length--;
                Heapfiy(nums, 0, length);
            }
        }

        /// <summary>
        /// 建堆
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="i"></param>
        /// <param name="length"></param>
        public void Heapfiy1(int[] nums,int i,int length)
        {
            int d = nums[i - 1];
            int child = 0;
            while (i <= length / 2)
            {
                child = 2 * i;
                if (child < length && nums[child - 1]< nums[child])
                {
                    child++;
                }
                if (!(d < nums[child - 1]))
                    break;
                nums[i - 1] = nums[child - 1];
                i = child;
            }
            nums[i - 1] = d;
        }

        /// <summary>
        /// 建堆
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="i"></param>
        /// <param name="length"></param>
        public void Heapfiy(int[] nums, int i, int length)
        {
            if (i < length)
            {
                int left = i * 2 + 1;
                int right = i * 2 + 2;
                int max = i;
                if (left < length)
                {
                    if (nums[max] < nums[left])
                        max = left;
                }

                if (right < length)
                {
                    if (nums[max] < nums[right])
                        max = right;
                }

                if (max != i)
                {
                    Swap(nums, max, i);
                    Heapfiy(nums, max, length);
                }
            }
        }

        private void Swap(int[] nums,int i,int j)
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }

        /// <summary>
        /// 找到数组第K大元素
        /// 先排序 再从最后取出第K个元素
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthLargest(int[] nums, int k)
        {
            Array.Sort(nums);
            return nums[nums.Length - k];
        }

        # region 找到数组第K大元素
        /// <summary>
        /// 找到数组第K大元素
        /// 利用堆的性质 建堆
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthLargest1(int[] nums, int k)
        {
            int length = nums.Length;
            for (int i = nums.Length / 2; i >= 1; i--)
            {
                Heapfiy(nums, i, length);
            }

            int count = 0;
            for (int i = length; i > 1; i--)
            {
                Swap(nums, 0, i - 1);
                count++;
                if (count == k)
                    return nums[nums.Length - k];
                length--;
                Heapfiy(nums, 1, length);
            }
            return nums[nums.Length-k];
        }

        /// <summary>
        /// 找到数组第K大元素
        /// 快速选择排序
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthLargest3(int[] nums, int k)
        {
            int size = nums.Length;
            // kth largest is (N - k)th smallest
            return QuickSelect(nums,0, size - 1, size - k);
        }

        private int Partition(int[] nums,int lo,int hi,int pivotIndex)
        {
            int pivot = nums[pivotIndex];
            Swap(nums, pivotIndex, hi);
            int store_index = lo;
            for(int i = lo; i<= hi; i++)
            {
                if (nums[i] < pivot)
                {
                    Swap(nums, store_index, i);
                    store_index++;
                }
            }
            Swap(nums, store_index, hi);
            return store_index;
        }

        private int QuickSelect(int[] nums, int lo, int hi, int k_smallest)
        {
            if (lo == hi) // 数组只含有一个元素
                return nums[lo]; // 直接返回该元素

            // select a random pivot_index
            Random random_num = new Random();
            int pivot_index = random_num.Next(lo,hi);//随机选择中枢索引
            //处理数组,并返回新中枢索引,此时pivot_index即为第pivot_index小的元素
            pivot_index = Partition(nums, lo, hi, pivot_index);

            // 如果pivot_index等于k_smallest,返回结果
            if (k_smallest == pivot_index)
                return nums[k_smallest];
            
            else if (k_smallest < pivot_index)
                //递归查找左边部分
                return QuickSelect(nums,lo, pivot_index - 1, k_smallest);
            else
                //递归查找右边部分
                return QuickSelect(nums, pivot_index + 1, hi, k_smallest);
        }

        #endregion

        /// <summary>
        /// 找到第n个丑数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NthUglyNumber(int n)
        {
            //TODO:待完成
            return 0;
        }
        #region 前K个高频元素
        /// <summary>
        /// 前K个高频元素
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<int> TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach(var num in nums)
            {
                if (dic.ContainsKey(num))
                    dic[num] += 1;
                else
                    dic.Add(num, 0);
            }
            //List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>(dic);
            //QuickSort(list, 0, list.Count - 1);
            //var ls= list.GetRange(list.Count - k, k);
            //return (from num in ls
            //       select num.Key).ToList();
            var keys = dic.Keys.ToArray();
            var values = dic.Values.ToArray();
            Array.Sort(values, keys);
            var result = new List<int>();
            for (int i = keys.Length - 1; i >= keys.Length - k; i--)
                result.Add(keys[i]);
            return result;
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        public void QuickSort(List<KeyValuePair<int, int>> nums, int lo, int hi)
        {
            if (lo >= hi)
                return;
            int pivot = Partition(nums, lo, hi);
            QuickSort(nums, lo, pivot - 1);
            QuickSort(nums, pivot + 1, hi);
        }

        private int Partition(List<KeyValuePair<int, int>> nums, int lo, int hi)
        {
            int pivotIndex = lo + ((hi - lo) >> 1);
            var pivot = nums[pivotIndex];
            Swap(nums, pivotIndex, hi);
            int index = lo;
            for (int i = lo; i <= hi; i++)
            {
                if (nums[i].Value < pivot.Value)
                {
                    Swap(nums, index, i);
                    index++;
                }
            }
            Swap(nums, index, hi);
            return index;
        }

        private void Swap(List<KeyValuePair<int, int>> nums, int i, int j)
        {
            var tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }
        #endregion

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        public void QuickSort(int[] nums,int lo,int hi)
        {
            if (lo >= hi)
                return;
            int pivot = Partition(nums, lo, hi);
            QuickSort(nums, lo, pivot - 1);
            QuickSort(nums, pivot + 1, hi);
        }

        private int Partition(int[] nums,int lo,int hi)
        {
            int pivotIndex = lo + ((hi - lo) >> 1);
            int pivot = nums[pivotIndex];
            Swap(nums, pivotIndex, hi);
            int index = lo;
            for(int i = lo; i <= hi; i++)
            {
                if (nums[i] < pivot)
                {
                    Swap(nums, index, i);
                    index++;
                }
            }
            Swap(nums, index, hi);
            return index;
        }
    }
}
