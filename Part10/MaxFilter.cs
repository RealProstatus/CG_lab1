using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1.Part10
{
    internal class MaxFilter : Filter
    {
        private int radius;

        public MaxFilter(int radius = 1)
        {
            this.radius = radius;
        }

        protected override Color calculateNewPixelColor(Bitmap source, int x, int y)
        {
            byte maxR = 0, maxB = 0, maxG = 0;

            for(int dx = -radius; dx <= radius; dx++)
            {
                for(int dy = -radius; dy <= radius; dy++)
                {
                    int idX = clamp(x + dx, 0, source.Width - 1);
                    int idY = clamp(y + dy, 0, source.Height - 1);
                    Color px = source.GetPixel(idX, idY);

                    maxR = Math.Max(maxR, px.R);
                    maxG = Math.Max(maxG, px.G);
                    maxB = Math.Max(maxB, px.B);
                }
            }

            return Color.FromArgb(maxR, maxG, maxB);
        }
    }
}
