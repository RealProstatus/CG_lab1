using CG_lab1.ParentClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1.Morphology
{
    //TopHat = исходное - открытие

    internal class TopHat : MorphFilter
    {
        public TopHat(bool[,] kernel = null) : base(kernel) { }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap opened = new Opening(kernel).processImage(sourceImage, worker);
            return FilterUtils.substractImages(sourceImage, opened);
        }

        protected override bool applyOperation(List<bool> neighbours)
        {
            throw new NotImplementedException();
        }

        protected override Color calculateNewPixelColor(Bitmap source, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
