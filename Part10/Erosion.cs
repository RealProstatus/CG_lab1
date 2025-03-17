using CG_lab1.ParentClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1.Part10
{
    internal class Erosion : MorphFilter
    {
        public Erosion(bool[,] kernel = null): base(kernel) { }

        protected override bool applyOperation(List<bool> neighbours)
        {
            return neighbours.TrueForAll(x => x);
        }

        protected override Color calculateNewPixelColor(Bitmap source, int x, int y)
        {
            List<Color> neighbours = new List<Color>();
            int stDx = -(kernelWidth / 2);
            int endDx = (kernelWidth % 2 == 0) ? (kernelWidth / 2 - 1) : (kernelWidth / 2);
            int stDy = -(kernelHeight / 2);
            int endDy = (kernelHeight % 2 == 0) ? (kernelHeight / 2 - 1) : (kernelHeight / 2);

            for (int dy = stDy; dy <= endDy; dy++)
            {
                for(int dx = stDx;dx <= endDx; dx++)
                {
                    int idX = clamp(x + dx, 0, source.Width - 1);
                    int idY = clamp(y + dy, 0, source.Height - 1);

                    if (kernel[dx - stDx, dy - stDx])
                        neighbours.Add(source.GetPixel(idX, idY));
                }
            }

            return neighbours.OrderByDescending(color => (0.2125 * color.R) +(0.7154 * color.G) + (0.0721 * color.B)).Last();
        }
    }
}
