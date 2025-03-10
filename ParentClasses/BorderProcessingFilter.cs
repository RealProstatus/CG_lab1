using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1.ParentClasses
{
    internal class BorderProcessingFilter : Filter
    {
        protected float[,] kernelX = null;
        protected float[,] kernelY = null;

        protected override Color calculateNewPixelColor(Bitmap source, int x, int y)
        {
            float grad_x_R = 0, grad_y_R = 0;
            float grad_x_G = 0, grad_y_G = 0;
            float grad_x_B = 0, grad_y_B = 0;

            int radius = 1;//т.к. матрица 3 на 3

            for (int dy = -radius; dy <= radius; dy++)
            {
                for (int dx = -radius; dx <= radius; dx++)
                {
                    int new_x = clamp(x + dx, 0, source.Width - 1);
                    int new_y = clamp(y + dy, 0, source.Height - 1);

                    Color pixel = source.GetPixel(new_x, new_y);

                    //сначала применяем матрицу по горизонтали
                    grad_x_R += pixel.R * kernelX[dx + radius, dy + radius];
                    grad_x_G += pixel.G * kernelX[dx + radius, dy + radius];
                    grad_x_B += pixel.B * kernelX[dx + radius, dy + radius];
                    //потом матрицу по вертикали
                    grad_y_R += pixel.R * kernelY[dx + radius, dy + radius];
                    grad_y_G += pixel.G * kernelY[dx + radius, dy + radius];
                    grad_y_B += pixel.B * kernelY[dx + radius, dy + radius];
                }
            }

            //цвет вдоль градиента
            int resR = clamp((int)Math.Sqrt(grad_x_R * grad_x_R + grad_y_R * grad_y_R));
            int resG = clamp((int)Math.Sqrt(grad_x_G * grad_x_G + grad_y_G * grad_y_G));
            int resB = clamp((int)Math.Sqrt(grad_x_B * grad_x_B + grad_y_B * grad_y_B));

            return Color.FromArgb(resR, resG, resB);
        }
    }
}
