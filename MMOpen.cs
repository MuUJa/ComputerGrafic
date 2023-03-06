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
        MyFilter filter1;
        MyFilter filter2;

        public MMOpen(int size) { 
            filter1 = new MMDilatation(size);
            filter2 = new MMErosion(size); 
        }
        public MMOpen(double[,] kernel) 
        { 
            this.kernel = kernel;
            filter1 = new MMDilatation(kernel);
            filter2 = new MMErosion(kernel);
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            
            Bitmap bitmap1 = filter1.processImage(sourceImage, worker);
            Bitmap bitmap2 = filter2.processImage(bitmap1, worker);
            return bitmap2;
        }
    }
}
