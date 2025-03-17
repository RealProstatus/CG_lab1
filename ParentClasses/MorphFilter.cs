using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG_lab1;

namespace CG_lab1.ParentClasses
{
    public static class FilterUtils
    {
        public static Bitmap substractImages(Bitmap img1, Bitmap img2)
        {
            Bitmap res = new Bitmap(img1.Width, img1.Height);
            for (int x = 0; x < img1.Width; x++)
            {
                for(int y = 0; y < img1.Height; y++)
                {
                    Color px1 = img1.GetPixel(x, y);
                    Color px2 = img2.GetPixel(x, y);

                    int r = Math.Max(px1.R - px2.R, 0);
                    int g = Math.Max(px1.G - px2.G, 0);
                    int b = Math.Max(px1.B - px2.B, 0);

                    res.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return res;
        }
    }

    public abstract class MorphFilter : Filter
    {
        protected bool[,] kernel;
        //если true - то точка активная
        protected int kernelWidth, kernelHeight;

        public MorphFilter(bool[,] kernel = null)
        {
            if(kernel == null)
            {
                this.kernel = new bool[,]
                {
                    {true, true, true },
                    {true, true, true },
                    {true, true, true }
                };
            }
            else
            {
                this.kernel = kernel;
            }
            kernelWidth = this.kernel.GetLength(0);
            kernelHeight = this.kernel.GetLength(1);
        }

        protected abstract bool applyOperation(List<bool> neighbours);

        public void setKernel(bool[,] kernel)
        {
            this.kernel = kernel;
        }
    }
}
