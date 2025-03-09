﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1
{
    internal class MatrixFilter : Filter
    {
        protected float[,] kernel = null;
        protected MatrixFilter() { }

        public MatrixFilter(float[,] kernel)
        {
            this.kernel = kernel;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for(int l = -radiusY; l <= radiusY; l++)
            {
                for(int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = clamp(y + l, 0, sourceImage.Height - 1);

                    Color neidghbourColor = sourceImage.GetPixel(idX, idY);
                    resultR += neidghbourColor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neidghbourColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neidghbourColor.B * kernel[k + radiusX, l + radiusY];
                }
            }
            
            return Color.FromArgb(
                        clamp((int)resultR, 0, 255),
                        clamp((int)resultG, 0, 255),
                        clamp((int)resultB, 0, 255)
                        );
        }
    }
}
