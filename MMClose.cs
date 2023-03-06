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
        int size;
        public MMClose(int size) { this.size = size; }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {   
            MyFilter filter1 = new MMErosion(size);
            MyFilter filter2 = new MMDilatation(size);
            Bitmap bitmap1 = filter1.processImage(sourceImage, worker);
            Bitmap bitmap2 = filter2.processImage(bitmap1, worker);
            return bitmap2;
        }
        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y) { return Color.Black; } 
    }
}
