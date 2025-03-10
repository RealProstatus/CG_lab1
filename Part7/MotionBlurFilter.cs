using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1.Part7
{
    internal class MotionBlurFilter : MatrixFilter
    {
        public MotionBlurFilter(int size) 
        {
            kernel = new float[size,size];

            float coeff = 1.0f / size;

            for (int i = 0; i < size; i++) 
            {
                kernel[i,i] = coeff;
            }
        }
    }
}
