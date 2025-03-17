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
        public Erosion(bool[,] kernel): base(kernel) { }

        protected override bool applyOperation(List<bool> neighbours)
        {
            return neighbours.TrueForAll(x => x);
        }

        protected override Color calculateNewPixelColor(Bitmap source, int x, int y)
        {
            List<bool> neighbours = new List<bool>();
            int radius = kernelSize / 2;

            for(int dy = -radius; dy <= radius; dy++)
            {
                for(int dx = -radius;dx <= radius; dx++)
                {
                    int idX = clamp(x + dx, 0, source.Width - 1);
                    int idY = clamp(y + dy, 0, source.Height - 1);

                    if (kernel[dx + radius, dy + radius])
                        neighbours.Add(source.GetPixel(idX, idY).R > 128);
                }
            }

            return applyOperation(neighbours) ? Color.White : Color.Black;
        }
    }
}
