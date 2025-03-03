using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1
{
    internal class Rotate : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap source, int x, int y)
        {
            int k = x;
            int l = y;
            int miu = 25;

            int x0 = source.Width/2;
            int y0 = source.Height/2;

            int new_x = (int)((k - x0) * Math.Cos(miu) - (l - y0) * Math.Sin(miu) + x0);
            int new_y = (int)((k - x0) * Math.Sin(miu) + (l - y0) * Math.Cos(miu) + y0);

            if ((new_x >= 0) && (new_x < source.Width) && (new_y >= 0) && (new_y < source.Height))
                return source.GetPixel(new_x, new_y);

            return Color.Black;
        }
    }
}
