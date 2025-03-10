using CG_lab1.ParentClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1.Part7
{
    internal class SharrOperator : BorderProcessingFilter
    {
        public SharrOperator()
        {
            kernelX = new float[,]
            {
                {3, 0, -3 },
                {10, 0, -10 },
                {3, 0, -3 }
            };

            kernelY = new float[,]
            {
                {3, 10, 3 },
                {0, 0, 0 },
                {-3, -10, -3 }
            };
        }
    }
}
