using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class MMGradient : MyFilter
    {
        MyFilter filter_erosion;
        MyFilter filter_dilatation;
        public MMGradient(int size)
        {
            filter_erosion = new MMErosion(size);
            filter_dilatation = new MMDilatation(size);
        }
        public MMGradient(double[,] kernel)
        {
            filter_erosion = new MMErosion(kernel);
            filter_dilatation = new MMDilatation(kernel);
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap erosion = filter_erosion.processImage(sourceImage, worker);
            Bitmap dilatation = filter_dilatation.processImage(sourceImage, worker);
            Bitmap result = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
                for(int j = 0; j < sourceImage.Height; j++)
                {
                    Color cd = dilatation.GetPixel(i, j);
                    Color ed = erosion.GetPixel(i, j);
                    int R = Clamp(cd.R - ed.R, 0, 255);
                    int G = Clamp(cd.G - ed.G, 0, 255);
                    int B = Clamp(cd.B - ed.B, 0, 255);
                    result.SetPixel(i, j, Color.FromArgb(R, G, B));
                }

            return result;
        }
        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y) { return Color.Black; }
    }
}
