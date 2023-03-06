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
        MyFilter filter_erosion;
        MyFilter filter_dilatation;
        public MMClose(int size) {
            filter_erosion = new MMErosion(size);
            filter_dilatation = new MMDilatation(size);
        }
        public MMClose(double[,] kernel)
        {
            filter_erosion = new MMErosion(kernel);
            filter_dilatation = new MMDilatation(kernel);
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {   
            Bitmap erosion = filter_erosion.processImage(sourceImage, worker);
            Bitmap result = filter_dilatation.processImage(erosion, worker);
            return result;
        }
        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y) { return Color.Black; } 
    }
}
