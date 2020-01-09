using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN
{
    public class LeetCode342
    {
        /// <summary>
        /// 判断是否是4的幂次方
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool IsPowerOfFour(int num)
        {
            if (num == 1) return true;
            else if (num == 0) return false;
            else return IsPowerOfFour(num / 4) && num % 4 == 0;

        }
    }
}
