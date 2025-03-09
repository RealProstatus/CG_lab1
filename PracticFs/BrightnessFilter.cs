using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1
{
    internal class BrightnessFilter : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap source, int x, int y)
        {
            int k = 75;

            int r = clamp(k + source.GetPixel(x, y).R);
            int g = clamp(k + source.GetPixel(x, y).G);
            int b = clamp(k + source.GetPixel(x, y).B);

            return Color.FromArgb(r, g, b);
        }
    }
}
