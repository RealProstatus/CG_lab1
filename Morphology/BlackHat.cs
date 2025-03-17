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
    //Black hat = закрытие - исходное

    internal class BlackHat : MorphFilter
    {

        public BlackHat(bool[,] kernel = null) : base(kernel) { }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap closed = new Closing(kernel).processImage(sourceImage, worker);
            return FilterUtils.substractImages(closed, sourceImage);
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
