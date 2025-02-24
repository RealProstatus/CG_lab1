using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.ComponentModel;

namespace CG_lab1
{
    public abstract class Filter
    {

        public int clamp(int val, int min = 0, int max = 255) 
        {
            if (val < min)
                return min;
            if (val > max)
                return max;
            return val;
        }

        protected abstract Color calculateNewPixelColor(Bitmap source, int x, int y);

        public Bitmap processImage(Bitmap source, BackgroundWorker worker) 
        {
            Bitmap result = new Bitmap(source.Width, source.Height);

            for (int i = 0; i < source.Width; i++) 
            {
                worker.ReportProgress((int)((float)i / result.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for(int j = 0; j < source.Height; j++)
                {
                    result.SetPixel(i,j,calculateNewPixelColor(source,i,j));
                }
            }

                return result;
        }
    }
}
