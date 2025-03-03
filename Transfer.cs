using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1
{
    internal class Transfer : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap source, int x, int y)
        {
            int k = 50;
            
            if (x + k >= source.Width)
            {
                return Color.Black;
            }
            
            return source.GetPixel(x+k, y);
        }
    }
}
