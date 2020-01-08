using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN.AboutMath
{
    public class Maths
    {
        /// <summary>
        /// 写一个程序，输出从 1 到 n 数字的字符串表示。
        /// 1. 如果 n 是3的倍数，输出“Fizz”；
        /// 2. 如果 n 是5的倍数，输出“Buzz”；
        /// 3.如果 n 同时是3和5的倍数，输出 “FizzBuzz”。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> FizzBuzz(int n)
        {
            var list = new string[n];
            for(int i = 1; i <= n; i++)
            {
                int j = i % 3;
                int k = i % 5;
                int index = i - 1;
                if (j == 0 && k == 0)
                    list[index] = "FizzBuzz";
                else if (j == 0)
                    list[index] = "Fizz";
                else if (k == 0)
                    list[index] = "Buzz";
                else list[index] = i.ToString();
            }
            return list;
        }

        public int CountPrimes(int n)
        {
            bool[] not = new bool[n + 1];
            int count = 0;

            for (int i = 2; i < n; i++)
            {
                if (not[i]) continue;
                count++;
                for (long j = (long)(i) * i; j < n; j += i)
                {
                    not[(int)j] = true;
                }
            }
            return count;
        }

        public static bool IsPrime(int candidate)
        {
            if ((candidate & 1) != 0)
            {
                int limit = (int)Math.Sqrt(candidate);
                for (int divisor = 3; divisor <= limit; divisor += 2)
                {
                    if ((candidate % divisor) == 0)
                        return false;
                }
                return true;
            }
            return (candidate == 2);
        }

        /// <summary>
        /// 判断n是否是3的幂次方
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfThree(int n)
        {
            int[] nums = new int[] { 1, 3, 9, 27, 81, 243, 729, 2187, 6561, 19683, 59049, 177147, 531441, 1594323, 4782969, 14348907, 43046721, 129140163, 387420489, 1162261467 };
            return (Array.BinarySearch(nums, n) >= 0);

        }

        
        /// <summary>
        /// 二进制表示中一的数目(汉明重量)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int HammingWeight(uint n)
        {
            int count=0;
            //对异或结果进行判断
            while (n != 0)
            {
                if ((n & 1) == 1)
                {//res此时为奇数，即最低位为1，异或结果为1，则表明该位上x和y是不同的，满足要求
                    count++;
                }
                n = n >> 1;
            }
            return count;
        }

        /// <summary>
        /// 两个整数之间的汉明距离指的是这两个数字对应二进制位不同的位置的数目。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int HammingDistance(int x, int y)
        {
            int res = x ^ y;//异或操作,此时res中1的数目即为x和y的汉明距离
            int count = 0;//计数器

            //对异或结果进行判断
            while (res != 0)
            {
                if ((res & 1) == 1)
                {//res此时为奇数，即最低位为1，异或结果为1，则表明该位上x和y是不同的，满足要求
                    count++;
                }
                res = res >> 1;
            }

            return count;
        }

        /// <summary>
        /// 颠倒二进制位
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public uint reverseBits(uint n)
        {
            long m = 0;
            for(int i = 0; i < 32; i++)
            {
                m = (m << 1) | ((n >> i) & 1);
            }
            return (uint)m;
        }

        public IList<IList<int>> Generate(int numRows)
        {
            List<IList<int>> list = new List<IList<int>>();
            for(int i = 0; i < numRows; i++)
            {
                List<int> ls = new List<int>();
                if (i == 0)
                {
                    ls.Add(1);
                    list.Add(ls);
                }
                else
                {
                    for(int j = 0; j < i + 1; j++)
                    {
                        var t = list[i - 1];
                        if (j == 0)
                            ls.Add(t[0]);
                        else if (j == i)
                        {
                            ls.Add(t[j-1]);
                        }
                        else
                        {
                            ls.Add(t[j-1] + t[j]);
                        }
                    }
                    list.Add(ls);
                }
            }
            return list;
        }

        /// <summary>
        /// 是否是有效的括号
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid(string s)
        {
            if (String.IsNullOrEmpty(s))
                return true;
            Dictionary<char, char> dic = new Dictionary<char, char>();
            dic.Add('(', ')');
            dic.Add('{', '}');
            dic.Add('[', ']');
            Stack<char> stack = new Stack<char>();
            foreach(var ch in s)
            {
                if (stack.Count == 0)
                {
                    if (IsRight(ch))
                        return false;
                    stack.Push(ch);
                }else
                {
                    if (IsLeft(ch))
                        stack.Push(ch);
                    else
                    {
                        if (dic[stack.Pop()] != ch)
                            return false;
                    }
                }
            }
            return stack.Count == 0;
        }

        private bool IsRight(char s)
        {
            return s == ')' || s == '}' || s == ']';
        }

        private bool IsLeft(char s)
        {
            return s == '(' || s == '{' || s == '[';
        }

        /// <summary>
        /// 缺失的数字
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MissingNumber(int[] nums)
        {
            if (nums.Length == 1)
            {
                if(nums[0]==1)
                    return 0;
                return 1;
            }
            
            Array.Sort(nums);
            for(int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[0] == 1)
                    return 0;
                if(nums[i+1]-nums[i] > 1)
                {
                    return i + 1;
                }
            }
            return nums.Length;
        }

        /// <summary>
        /// 数组表示的数加1
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public int[] PlusOne(int[] digits)
        {
            int step = 1;//需要加的值
            for(int i = digits.Length - 1; i >= 0; i--)
            {
                int add = digits[i] + step;
                if (add > 9)//加完后大于9,需要进位
                {
                    step = 1;//进位值设为1
                    digits[i] = add % 10;
                    if (i == 0)
                    {
                        int[] newArray = new int[digits.Length + 1];
                        newArray[0] = step;
                        Array.Copy(digits, 0, newArray, 1, digits.Length);
                        return newArray;
                    }
                }
                else
                {
                    digits[i] = add;
                    step = 0;
                }
            }
            return digits;
        }

        /// <summary>
        /// 移动0
        /// </summary>
        /// <param name="nums"></param>
        public void MoveZeroes(int[] nums)
        {
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    int k = i + 1;
                    for(; k < nums.Length; k++)
                    {
                        if(nums[k]!=0)
                        {
                            nums[i] = nums[k];
                            nums[k] = 0;
                            break;
                        }
                    }
                    if (k == nums.Length - 1)
                        break;
                }
            }
        }

        /// <summary>
        /// 顺时针旋转矩阵90°
        /// </summary>
        /// <param name="matrix"></param>
        public void Rotate(int[][] matrix)
        {

        }

        /// <summary>
        /// 数组向右旋转k个位置
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void Rotate(int[] nums, int k)
        {
            k = k % nums.Length;
            int tmp = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                int re = (i + k) % (nums.Length - 1);
                nums[re] = nums[i];
                
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int ArrayPairSum(int[] nums)
        {
            Array.Sort(nums);
            int sum = 0;
            for(int i = 0; i < nums.Length; i+=2)
            {
                sum += nums[i];
            }
            return sum;
        }

        /// <summary>
        ///  两数之和 II - 输入有序数组
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] numbers, int target)
        {
            return new int[] { -1, -1 };
        }

        /// <summary>
        /// 移除元素
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public int RemoveElement(int[] nums, int val)
        { 
            int right = nums.Length;
            int i = 0;
            for(; i < nums.Length;)
            {
                
                if (i >= right) break;
                if (nums[i] == val)
                {
                    for (int j = i; j < right - 1; j++)
                    {
                        nums[j] = nums[j + 1];
                    }
                    right -= 1;
                }
                else
                {
                    i++;
                }
            }
            return i;
        }

        /// <summary>
        /// 最大连续1
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int max = 0;
            int tmp = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    if(nums.Length > i + 1 && nums[i] == nums[i + 1])
                    {
                        tmp += 1;
                    }
                    else
                    {
                        if (max < tmp + 1)
                            max = tmp + 1;
                        tmp = 0;
                    }
                    
                }
            }
            return max;
        }

        /// <summary>
        /// 1056.混淆数
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public bool ConfusingNumber(int N)
        {

            //TODO:待完成
            return false;
        }


    }
}
