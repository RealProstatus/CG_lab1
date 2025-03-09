using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1
{
    internal class GaussianFilter : MatrixFilter
    {
        public void createGaussianKernel(int radius, int sigma)
        {
            int kernel_size = 1 + radius * 2;
            kernel = new float[kernel_size, kernel_size];

            float norm = 0;

            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    kernel[i + radius, j + radius] =
                        (float)(Math.Exp(-(i * i + j * j) / (sigma * sigma)));
                    norm += kernel[i + radius, j + radius];
                }
            }

            for (int i = 0; i < kernel_size; i++)
                for (int j = 0; j < kernel_size; j++)
                    kernel[i, j] /= norm;
        }

        public GaussianFilter()
        {
            createGaussianKernel(3, 2);
        }
    }
}
