using CG_lab1.ParentClasses;
using CG_lab1.Part10;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_lab1.Morphology
{
    //Град = дилатация - эрозия

    internal class Grad : MorphFilter
    {
        public Grad(bool[,] kernel = null): base(kernel) { }

        public override Bitmap processImage(Bitmap source, BackgroundWorker worker)
        {
            Bitmap dilated = new Dilation(kernel).processImage(source, worker);
            Bitmap erosed = new Erosion(kernel).processImage(source, worker);
            return FilterUtils.substractImages(dilated, erosed);
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
