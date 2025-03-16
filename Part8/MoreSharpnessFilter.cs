using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1.Part7
{
    internal class MoreSharpnessFilter : MatrixFilter
    {
        public MoreSharpnessFilter()
        {
            kernel = new float[,]
            {
                {-1, -1, -1 },
                {-1, 9, -1 },
                {-1, -1, -1 }
            };
        }
    }
}
