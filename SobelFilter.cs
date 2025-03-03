using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1
{
    internal class SobelFilter : MatrixFilter
    {
        private void initFilter(bool horizontal)
        {
            if (horizontal)
            {
                kernel = new float[,] {
                {-1, 0, 1 },
                { -2, 0, 2},
                { -1, 0, 1}
                };
            }
            else
            {
                kernel = new float[,] {
                {-1, -2, -1 },
                { 0, 0, 0},
                { 1, 2, 1}
                };
            }
        }

        public SobelFilter(bool horizontal)
        {
            initFilter(horizontal);
        }
    }
}
