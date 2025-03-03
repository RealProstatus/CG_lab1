﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1
{
    internal class SharpnessFilter : MatrixFilter 
    {
        public SharpnessFilter()
        {
            kernel = new float[,]
            {
                {0, -1, 0 },
                {-1, 5, -1 },
                {0, -1, 0 }
            };
        }
    }
}
