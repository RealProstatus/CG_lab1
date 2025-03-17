using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1.Part10
{
    internal class ColorCorrectionFilter : Filter
    {
        private Color reference;
        private Color goal;

        public ColorCorrectionFilter(Color reference, Color goal)
        {
            this.reference = reference;
            this.goal = goal;
        }

        public override Bitmap processImage(Bitmap source, BackgroundWorker worker)
        {
            //коэффициенты для каждого канала
            double scaleR = (reference.R == 0) ? 1.0 : (double)goal.R / reference.R;
            double scaleG = (reference.G == 0) ? 1.0 : (double)goal.G / reference.G;
            double scaleB = (reference.B == 0) ? 1.0 : (double)goal.B / reference.B;

            int width = source.Width;
            int height = source.Height;
            Bitmap result = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color c = source.GetPixel(x, y);
                    int r = (int)(c.R * scaleR);
                    int g = (int)(c.G * scaleG);
                    int b = (int)(c.B * scaleB);

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
