using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1.Part10
{
    internal class IdealReflector : Filter
    {
        public override Bitmap processImage(Bitmap source, BackgroundWorker worker)
        {
            int width = source.Width;
            int height = source.Height;
            Bitmap resultImage = new Bitmap(width, height);
            int totalPixels = width * height;

            int maxR = 0, maxG = 0, maxB = 0;

            //определение максимальных значений R, G, B
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color pixel = source.GetPixel(x, y);
                    maxR = Math.Max(maxR, pixel.R);
                    maxG = Math.Max(maxG, pixel.G);
                    maxB = Math.Max(maxB, pixel.B);
                }
            }

            //коррекция каналов каждого пискселя исх. изображения
            for (int x = 0; x < width; x++)
            {
                worker.ReportProgress((int)((float)(x) / width * 100));
                for (int y = 0; y < height; y++)
                {
                    Color pixel = source.GetPixel(x, y);

                    int newR = clamp(pixel.R * 255 / maxR, 0, 255);
                    int newG = clamp(pixel.G * 255 / maxG, 0, 255);
                    int newB = clamp(pixel.B * 255 / maxB, 0, 255);

                    resultImage.SetPixel(x, y, Color.FromArgb(newR, newG, newB));

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
