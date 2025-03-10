using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1
{
    internal class EmbossingFilter : MatrixFilter
    {
        public EmbossingFilter()
        {
            kernel = new float[,]
            {
                { 0, 1, 0 },
                { 1, 0, -1 },
                { 0, -1, 0 }
            };
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color clr = base.calculateNewPixelColor(sourceImage, x, y);

            int res = clamp(clr.R + 100);

            return Color.FromArgb(res, res, res);        
        }
    }
}
