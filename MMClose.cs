using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class MMClose : MyFilter
    {
        MyFilter filter1;
        MyFilter filter2;
        public MMClose(int size) {
            filter1 = new MMErosion(size);
            filter2 = new MMDilatation(size);
        }
        public MMClose(double[,] kernel)
        {
            filter1 = new MMErosion(kernel);
            filter2 = new MMDilatation(kernel);
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {   
            Bitmap bitmap1 = filter1.processImage(sourceImage, worker);
            Bitmap bitmap2 = filter2.processImage(bitmap1, worker);
            return bitmap2;
        }
        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y) { return Color.Black; } 
    }
}
