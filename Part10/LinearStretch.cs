using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1.Part10
{
    internal class LinearStretch : Filter
    {
        public override Bitmap processImage(Bitmap source, BackgroundWorker worker)
        {
            int width = source.Width;
            int height = source.Height;
            Bitmap resultImage = new Bitmap(width, height);
            int totalPixels = width * height;

            int minR, maxR, minG, maxG, minB, maxB;
            minR = minG = minB = 255;
            maxR = maxG = maxB = 0;

            //определение min/max
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color pixel = source.GetPixel(x, y);
                    minR = Math.Min(minR, pixel.R);
                    minG = Math.Min(minG, pixel.G);
                    minB = Math.Min(minB, pixel.B);
                    maxR = Math.Max(maxR, pixel.R);
                    maxG = Math.Max(maxG, pixel.G);
                    maxB = Math.Max(maxB, pixel.B);
                }
            }

            //линейное растяжение
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color pixel = source.GetPixel(x, y);

                    int newR = clamp((pixel.R - minR) * 255 / (maxR - minR));
                    int newG = clamp((pixel.G - minG) * 255 / (maxG - minG));
                    int newB = clamp((pixel.B - minB) * 255 / (maxB - minB));

                    resultImage.SetPixel(x, y, Color.FromArgb(newR, newG, newB));

                    worker.ReportProgress((int)((float)(x * height + y) / totalPixels * 100));
                }
            }

            return resultImage;
        }

        protected override Color calculateNewPixelColor(Bitmap source, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
