using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN
{
    /// <summary>
    /// 自除数 是指可以被它包含的每一位数除尽的数。
    ///例如，128 是一个自除数，因为 128 % 1 == 0，128 % 2 == 0，128 % 8 == 0。
    ///还有，自除数不允许包含 0 。
    ///给定上边界和下边界数字，输出一个列表，列表的元素是边界（含边界）内所有的自除数。
    ///示例 1：
    ///输入： 
    ///上边界left = 1, 下边界right = 22
    ///输出： [1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 15, 22]
    ///注意：
    ///每个输入参数的边界满足 1 <= left <= right <= 10000。
    ///来源：力扣（LeetCode）
    ///链接：https://leetcode-cn.com/problems/self-dividing-numbers
    ///著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    class LeetCode728
    {
        public IList<int> SelfDividingNumbers(int left, int right)
        {
            IList<int> list = new List<int>();

            for(int i = left; i <= right; i++)
            {
                if(IsSelfDividingNumber(i))
                {
                    list.Add(i);
                }
            }
            return list;
        }

        private static bool IsSelfDividingNumber(int num)
        {
            int temp = 0;
            int n = num;
            while (num > 0)
            {
                temp = num % 10;
                if (temp == 0 || n % temp != 0)
                {
                    return false;
                }
                num = num / 10;
            }
            return true;
        }

        
    }
}
