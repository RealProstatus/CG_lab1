using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1
{
    internal class GrayScaleFilter : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap source, int x, int y)
        {
            int r = source.GetPixel(x, y).R;
            int g = source.GetPixel(x, y).G;
            int b = source.GetPixel(x, y).B;

            int intensity = (int)(0.36f * r + 0.53f * g + 0.11f * b);

            return Color.FromArgb(intensity,intensity,intensity);
        }
    }
}
