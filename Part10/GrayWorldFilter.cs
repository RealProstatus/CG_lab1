using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1.Part10
{
    internal class GrayWorldFilter : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap source, int x, int y)
        {
            return source.GetPixel(x, y);
        }
    }
}
