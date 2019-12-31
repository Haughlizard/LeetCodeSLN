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

        public bool IsIsomorphic(string s, string t)
        {
            
            return true;
        }

        /// <summary>
        /// 判断n是否是快乐数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsHappy(int n)
        {
            HashSet<int> set = new HashSet<int>(new int[] { 4, 16, 37, 58, 89, 145, 42, 20 });
            int cnt = n;
            while (true)
            {
                int tmp = cnt;
                cnt = 0;
                while (tmp >= 1)
                {
                    int m = tmp % 10;
                    cnt += m*m;
                    tmp = (tmp - m) / 10;
                }

                if (cnt == 1)
                {
                    return true;
                }else
                {
                    if (set.Contains(cnt))
                        return false;
                }
            }
        }

        /// <summary>
        /// 字符串相乘
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public string Multiply(string num1, string num2)
        {
            List<string> step = new List<string>();
            for(int i = num2.Length-1; i>=0;i--)
            {
                var result = SingleMultity(num1, num2[i]);
                for (int j =num2.Length-1-i;j>0;j--)
                {
                    result.Add("0");
                }
                step = Add(step, result);
            }
            var ending = String.Join("", step).TrimStart('0');
            return string.IsNullOrEmpty(ending) ? "0" : ending;
        }

        public List<string> Add(List<string> num1,List<string> num2)
        {
            List<string> result = new List<string>();
            int step = 0;
            for(int m = num1.Count-1,n = num2.Count - 1;m>=0||n>=0;)
            {
                if (m >= 0 && n >= 0)
                {
                    int mult = int.Parse(num1[m]) + int.Parse(num2[n]) + step;
                    result.Insert(0,(mult % 10).ToString());
                    step = (mult - (mult % 10)) / 10;
                    
                }
                else if(m>=0)
                {
                    int mult = int.Parse(num1[m])  + step;
                    result.Insert(0, (mult % 10).ToString());
                    step = (mult - (mult % 10)) / 10;
                 
                }else if(n>=0)
                {
                    int mult = int.Parse(num2[n]) + step;
                    result.Insert(0, (mult % 10).ToString());
                    step = (mult - (mult % 10)) / 10;
                    
                }
                m--;n--;
            }
            if (step != 0)
            {
                result.Insert(0, step.ToString());
            }
            return result;
        }

        public List<string> SingleMultity(string num1,char ch)
        {
            List<string> result = new List<string>();
            int step = 0;
            for(int i = num1.Length - 1; i >= 0; i--)
            {
                int mult = int.Parse(num1[i].ToString()) * int.Parse(ch.ToString()) + step;
                result.Insert(0, (mult % 10).ToString());
                step = (mult - (mult % 10)) / 10;
            }
            if (step != 0)
            {
                result.Insert(0, step.ToString());
            }
            return result.ToList();
        }

        /// <summary>
        /// s中字符出现的频率重新组合
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string FrequencySort(string s)
        {
            List<char> listCh = new List<char>();
            List<int> listNum = new List<int>();
            foreach(var ch in s)
            {
                if (listCh.Contains(ch))
                {
                    listNum[listCh.IndexOf(ch)] += 1;
                }else
                {
                    listCh.Add(ch);
                    listNum.Add(1);
                }
            }

            for(int i = 0; i < listNum.Count-1; i++)
            {
                for(int j = i + 1; j < listNum.Count; j++)
                {
                    if(listNum[j]>listNum[i])
                    {
                        var tmp = listNum[i];
                        listNum[i] = listNum[j];
                        listNum[j] = tmp;

                        var tmps = listCh[i];
                        listCh[i] = listCh[j];
                        listCh[j] = tmps;
                    }
                }
            }

            var sb = new StringBuilder();
            for(int i = 0; i < listNum.Count; i++)
            {
                for(int j=0; j< listNum[i]; j++)
                {
                    sb.Append(listCh[i]);
                }
            }
            return sb.ToString();
        }
    }
}
