using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace CG_lab1
{
    class InvertFilter : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap source, int x, int y)
        {
            Color sourceColor = source.GetPixel(x, y);
            Color resultColor = Color.FromArgb(255 - sourceColor.R,
                255 - sourceColor.G, 255 - sourceColor.B);

            return resultColor;
        }
    }
}
