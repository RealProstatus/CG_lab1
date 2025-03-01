using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1
{
    internal class SobelFilter : MatrixFilter
    {
        private void initFilter(bool horizontal)
        {
            if (horizontal)
            {
                kernel = new float[3, 3];
                
            }
        }
    }
}
