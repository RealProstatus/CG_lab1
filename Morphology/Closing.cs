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

    //закрытие = дилатация, затем эрозия
{
    internal class Closing : MorphFilter
    {
        public Closing(bool[,] kernel = null): base(kernel) { }

        public override Bitmap processImage(Bitmap source, BackgroundWorker worker)
        {
            Bitmap res = new Dilation(kernel).processImage(source, worker);
            return new Erosion(kernel).processImage(res, worker);
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
