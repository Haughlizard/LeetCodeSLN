using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSLN
{
    class LeetCode223
    {
        /// <summary>
        /// 在二维平面上计算出两个由直线构成的矩形重叠后形成的总面积。
        ///每个矩形由其左下顶点和右上顶点坐标表示，如图所示。
        ///示例:
        ///输入: -3, 0, 3, 4, 0, -1, 9, 2
        ///输出: 45
        ///说明: 假设矩形面积不会超出 int 的范围。
        ///来源：力扣（LeetCode）
        ///链接：https://leetcode-cn.com/problems/rectangle-area
        ///著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <param name="E"></param>
        /// <param name="F"></param>
        /// <param name="G"></param>
        /// <param name="H"></param>
        /// <returns></returns>
        public static int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H)
        {
            int area1 = (C - A) * (D - B);
            int area2 = (G - E) * (H - F);
            if (E >= C || G <= A || H <= B || F >= D)
            {
                // 不相交
                return area1 + area2;
            }

            int leftBottomX = Math.Max(A, E);
            int leftBottomY = Math.Max(B, F);
            int rightUpX = Math.Min(C, G);
            int rightUpY = Math.Min(D, H);
            int commonArea = (rightUpX - leftBottomX) * (rightUpY - leftBottomY);
            return area1 + area2 - commonArea;
        }
    }
}
