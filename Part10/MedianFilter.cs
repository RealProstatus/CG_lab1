using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1.Part10
{
    internal class MedianFilter : Filter
    {
        private int radius;

        public MedianFilter(int radius = 1)
        {
            this.radius = radius;
        }

        protected override Color calculateNewPixelColor(Bitmap source, int x, int y)
        {
            List<byte> R = new List<byte>();
            List<byte> G = new List<byte>();
            List<byte> B = new List<byte>();

            for(int dy = -radius; dy <= radius; dy++)
            {
                for(int dx = -radius;dx <= radius; dx++)
                {
                    int idX = clamp(x + dx, 0, source.Width - 1);
                    int idY = clamp(y + dy, 0, source.Height - 1);
                    Color px = source.GetPixel(idX, idY);

                    R.Add(px.R);
                    G.Add(px.G);
                    B.Add(px.B);
                }
            }

            R.Sort();
            G.Sort();
            B.Sort();

            int mid = R.Count() / 2;

            return Color.FromArgb(R[mid], G[mid], B[mid]);
        }
    }
}
