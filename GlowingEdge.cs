using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class GlowingEdge: MatrixFilter
    {
        int size;
        public GlowingEdge(int size) { this.size = size; }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            MyFilter filter1 = new MedianFilter(size);
            MyFilter filter2 = new SobelFilter( );
            Bitmap bitmap1 = filter1.processImage(sourceImage, worker);
            Bitmap bitmap2 = filter2.processImage(bitmap1, worker);
            return bitmap2;
        }
    }
}
