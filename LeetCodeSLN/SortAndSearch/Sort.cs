using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN.SortAndSearch
{
    public class Sort
    {
        #region 冒泡排序
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="nums"></param>
        public void BubbleSort(int[] nums)
        {
            for(int i = 0; i < nums.Length - 1; i++)
            {
                for(int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                        Swap(nums, i, j);
                }
            }
        }
        #endregion

        #region 选择排序
        /// <summary>
        /// 选择排序
        /// </summary>
        /// <param name="nums"></param>
        public void SelectionSort(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[min] > nums[j])
                        min = j;
                }
                Swap(nums, i, min);
            }
        }
        #endregion

        #region 插入排序
        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="nums"></param>
        public void InsertSort(int[] nums)
        {
            for(int i = 1; i < nums.Length; i++)
            {
                int j = i - 1;
                int value = nums[i];
                for (; j >= 0; j--)
                {
                    if (nums[j] > value)
                        nums[j + 1] = nums[j];
                    else
                        break;
                }
                nums[j + 1] = value;
            }
        }
        #endregion

        #region 希尔排序
        /// <summary>
        /// 希尔排序
        /// </summary>
        /// <param name="nums"></param>
        public void ShellSort(int[] nums)
        {
            int N = nums.Length;
            int h = 1;
            while (h < N / 3)
            {
                h = 3 * h + 1;//1,4,13,40,121
            }
            while (h > 0)
            {
                for (int i = h; i < N; i++)
                {
                    int value = nums[i];
                    int j = i - h;
                    while (j >= 0 && nums[j] > value)
                    {
                        nums[j + h] = nums[j];
                        j -= h;
                    }
                    nums[j + h] = value;
                }
                h = h / 3;
            }
        }
        #endregion

        #region 快速排序
        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="nums"></param>
        public void QuickSort(int[] nums)
        {
            QuickSort(nums,0,nums.Length - 1);
        }

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
            Random rd = new Random();
            int pivotIndex = rd.Next(lo, hi);
            //int pivotIndex = lo + ((hi - lo) >> 1);
            var pivot = nums[pivotIndex];
            Swap(nums, pivotIndex, hi);
            int index = lo;
            for (int i = lo; i <= hi; i++)
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
        #endregion

        #region 归并排序
        private int[] aux;
        /// <summary>
        /// 归并排序
        /// </summary>
        /// <param name="nums"></param>
        public void MergeSort(int[] nums)
        {
            aux = new int[nums.Length];
            MergeSort(nums, 0, nums.Length - 1); 
        }

        public void MergeSort(int[] nums,int lo,int hi)
        {
            if (hi <= lo) return;
            int middle = lo + ((hi - lo)>>1);
            MergeSort(nums, lo, middle);
            MergeSort(nums, middle + 1, hi);
            Merge(nums, lo, middle, hi);
        }
        /// <summary>
        /// 合并有序数组方法1
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="lo"></param>
        /// <param name="mid"></param>
        /// <param name="hi"></param>
        private void Merge1(int[] nums,int lo,int mid,int hi)
        {
            int i = lo;
            int j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = nums[k];
            }
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) nums[k] = aux[j++];
                else if (j > hi) nums[k] = aux[i++];
                else if (aux[j] < aux[i]) nums[k] = aux[j++];
                else nums[k] = aux[i++];
            }
        }

        /// <summary>
        /// 合并有序数组方法2
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="lo"></param>
        /// <param name="mid"></param>
        /// <param name="hi"></param>
        private void Merge(int[] nums, int lo, int mid, int hi)
        {
            int[] tmp = new int[hi - lo+1];
            int index = 0;
            for(int i = lo,j = mid + 1; i <= mid || j <= hi;)
            {
                if (i > mid)
                    tmp[index++] = nums[j++];
                else if (j> hi)
                    tmp[index++] = nums[i++];
                else if (nums[i] <= nums[j])
                    tmp[index++] = nums[i++];
                else
                    tmp[index++] = nums[j++];

            }
            Array.Copy(tmp, 0, nums, lo, hi - lo + 1);
        }
        #endregion

        #region 堆排序
        /// <summary>
        /// 堆排序
        /// </summary>
        /// <param name="nums"></param>
        public void HeadSort(int[] nums)
        {
            int length = nums.Length;
            for (int i = nums.Length / 2; i >= 0; i--)
            {
                Heapfiy(nums, i, length);
            }

            for (int i = length; i > 1; i--)
            {
                Swap(nums, 0, i - 1);
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
        public void Heapfiy1(int[] nums, int i, int length)
        {
            int d = nums[i - 1];
            int child = 0;
            while (i <= length / 2)
            {
                child = 2 * i;
                if (child < length && nums[child - 1] < nums[child])
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
        #endregion

        #region 计数排序

        /// <summary>
        /// 计数排序
        /// </summary>
        /// <param name="nums"></param>
        public void CountingSort(int[] nums)
        {
            int max = nums[0];
            int min = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > max)
                    max = nums[i];
                else if (nums[i] < min)
                    min = nums[i];  
            }//找到数组中的最大值和最小值

            //根据最大值和最小值创建数组
            int[] bucket = new int[max - min + 1];

            //将待排序数组中每个数字出现的次数按规则填入数组中
            for(int i = 0; i < nums.Length; i++)
            {
                bucket[nums[i] - min]++;
            }
            int index = 0;
            //遍历数组,取出次数及原数字,填入原数组中
            for(int i = 0;i< max - min + 1; i++)
            {
                for(int j = 0; j < bucket[i]; j++)
                {
                    nums[index] = i + min;
                    index++;
                }
            }
        }

        #endregion

        #region 桶排序
        /// <summary>
        /// 桶排序
        /// </summary>
        /// <param name="nums"></param>
        public void BucketSort(int[] nums)
        {
            int bucketSize = 5;
            int max = nums[0];
            int min = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > max)
                    max = nums[i];
                else if (nums[i] < min)
                    min = nums[i];
            }//找到数组中的最大值和最小值

            int bucketCount = (max - min) / bucketSize + 1;
            List<int>[] buckets = new List<int>[bucketCount];

            // 利用映射函数将数据分配到各个桶中
            for (int i = 0; i < nums.Length; i++)
            {
                int index = (nums[i] - min) / bucketSize;
                if (buckets[index] == null)
                    buckets[index] = new List<int>();
                buckets[index].Add(nums[i]);
            }

            //桶中的数据进行排序
            for(int i = 0; i<buckets.Length; i++)
            {
                if(buckets[i]!=null)
                    buckets[i].Sort();
            }
            int offset = 0;
            //合并桶
            for(int i = 0; i < buckets.Length; i++)
            {
                if (buckets[i] != null)
                {
                    Array.Copy(buckets[i].ToArray(), 0, nums, offset, buckets[i].Count);
                    offset += buckets[i].Count;
                }
            }

        }
        #endregion

        #region 基数排序(未完成)
        public void RadixSort(int[] nums)
        {
            int max = nums.Max();

        }
        #endregion

        /// <summary>
        /// 交换数组两个元素
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void Swap(int[] nums, int i, int j)
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }
    }
}
