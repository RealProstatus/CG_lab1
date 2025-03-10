using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1.Part7
{
    internal class WavesFilter : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap source, int x, int y)
        {
            int new_x = (int)(x + 20 * Math.Sin(2 * y * Math.PI / 60));

            new_x = clamp(new_x, 0, source.Width - 1);

            return source.GetPixel(new_x,y);
        }
    }
}
