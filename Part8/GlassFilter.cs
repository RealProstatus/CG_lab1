using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1.Part7
{
    internal class GlassFilter : Filter
    {
        Random random;

        public GlassFilter()
        {
            random = new Random();
        }

        protected override Color calculateNewPixelColor(Bitmap source, int x, int y)
        {
            int new_x = (int)(x + 10 * (random.NextDouble() - 0.5));
            int new_y = (int)(y + 10 * (random.NextDouble() - 0.5));

            new_x = clamp(new_x, 0, source.Width - 1);
            new_y = clamp(new_y, 0, source.Height - 1);

            return source.GetPixel(new_x, new_y);
        }
    }
}
