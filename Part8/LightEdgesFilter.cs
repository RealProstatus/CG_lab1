using CG_lab1.ParentClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1.Part7
{
    internal class LightEdgesFilter : BorderProcessingFilter
    {
        private int radius;

        public LightEdgesFilter() 
        {
            //будем использовать фильтр Собеля
            //для выделения границ
            kernelX = new float[,]
            {
                {-1, 0, 1 },
                {-2, 0, 2 },
                {-1, 0, 1}
            };

            kernelY = new float[,]
            {
                {-1, -2, -1 },
                {0, 0, 0 },
                {1, 2, 1 }
            };

            radius = 1;
        }

        protected override Color calculateNewPixelColor(Bitmap source, int x, int y)
        {
            Color medianClr = miniMedianFilter(source, x, y);

            Color edgeClr = base.calculateNewPixelColor(source, x, y);

            return miniMaxFilter(source, x, y, edgeClr);
        }

        private Color miniMedianFilter(Bitmap source, int x, int y)
        {
            List<int> R = new List<int>();
            List<int> G = new List<int>();
            List<int> B = new List<int>();

            for(int dy = -radius; dy <= radius; dy++)
            {
                for(int dx = -radius; dx <= radius; dx++)
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

            int mid = R.Count / 2;
            return Color.FromArgb(R[mid], G[mid], B[mid]);
        }

        private Color miniMaxFilter(Bitmap source, int x, int y, Color baseClr)
        {
            int maxR = baseClr.R;
            int maxG = baseClr.G;
            int maxB = baseClr.B;

            for(int dy = -radius; dy <= radius; dy++)
            {
                for(int dx = -radius; dx <= radius; dx++)
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
