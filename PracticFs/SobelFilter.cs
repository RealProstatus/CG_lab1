using CG_lab1.ParentClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1
{
    internal class SobelFilter : BorderProcessingFilter
    {
        public SobelFilter()
        {
            kernelX = new float[,] {
                {-1, 0, 1},
                {-2, 0, 2},
                {-1, 0, 1}
            };
            kernelY = new float[,] {
                {-1, -2, -1},
                {0, 0, 0},
                {1, 2, 1}
            };
        }
    }
}
