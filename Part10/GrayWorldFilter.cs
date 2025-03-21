﻿using System;
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
        public override Bitmap processImage(Bitmap source, BackgroundWorker worker)
        { 
            int width = source.Width;
            int height = source.Height;
            long sumR = 0, sumG = 0, sumB = 0;
            int totalPixels = width * height;

            Bitmap result = new Bitmap(width, height);

            //находим суммарное значение каждого канала
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color c = source.GetPixel(x, y);
                    sumR += c.R;
                    sumG += c.G;
                    sumB += c.B;
                }
            }
            //находим средние значения
            float avgR = sumR / (float)totalPixels;
            float avgG = sumG / (float)totalPixels;
            float avgB = sumB / (float)totalPixels;
            float avg = (float)((avgB + avgG + avgR) / 3.0);

            //масштабируем каждый канал исходного пикселя
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color c = source.GetPixel(x, y);
                    int r = (int)(c.R * avg / avgR);
                    int g = (int)(c.G * avg / avgG);
                    int b = (int)(c.B * avg / avgB);

                    r = clamp(r);
                    g = clamp(g);
                    b = clamp(b);

                    result.SetPixel(x, y, Color.FromArgb(r, g, b));
                }

                int progress = (int)((float)y / height * 100);
                worker.ReportProgress(progress);
            }

            return result;
        }

        protected override Color calculateNewPixelColor(Bitmap source, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
