using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class MMOpen : MatrixFilter
    {
        MyFilter filter_dilatation;
        MyFilter filter_erosion;

        public MMOpen(int size) {
            filter_dilatation = new MMDilatation(size);
            filter_erosion = new MMErosion(size); 
        }
        public MMOpen(double[,] kernel) 
        { 
            this.kernel = kernel;
            filter_dilatation = new MMDilatation(kernel);
            filter_erosion = new MMErosion(kernel);
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            
            Bitmap dilatation = filter_dilatation.processImage(sourceImage, worker);
            Bitmap result = filter_erosion.processImage(dilatation, worker);
            return result;
        }
    }
}
