using CG_lab1.ParentClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1.Part7
{
    internal class PrewittOperator : BorderProcessingFilter
    {
        public PrewittOperator()
        {
            kernelX = new float[,]
            {
                {-1, 0, 1 },
                {-1, 0, 1 },
                {-1, 0, 1 }
            };

            kernelY = new float[,]
            {
                {-1, -1, -1 },
                {0, 0, 0 },
                {1, 1, 1 }
            };
        }
    }
}
