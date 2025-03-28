using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1
{
    internal class EmbossingFilter : MatrixFilter
    {
        public EmbossingFilter()
        {
            kernel = new float[,]
            {
                { 0, 1, 0 },
                { 1, 0, -1 },
                { 0, -1, 0 }
            };
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            //применяем ядро
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = clamp(y + l, 0, sourceImage.Height - 1);

                    Color neidghbourColor = sourceImage.GetPixel(idX, idY);
                    resultR += neidghbourColor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neidghbourColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neidghbourColor.B * kernel[k + radiusX, l + radiusY];
                }
            }

            resultR += 128;
            resultG += 128;
            resultB += 128;

            return Color.FromArgb(clamp((int)resultR), clamp((int)resultG), clamp((int)resultB));
        }
    }
}
