using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class MMBlackHat : MatrixFilter
    {
        MyFilter opening;
        public MMBlackHat(int size)
        {
            opening = new MMOpen(size);
        }
        public MMBlackHat(double[,] kernel)
        {
            opening = new MMOpen(kernel);
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap opBmp = opening.processImage(sourceImage, worker);
            Bitmap result = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color cs = sourceImage.GetPixel(i, j);
                    Color co = opBmp.GetPixel(i, j);
                    double intensity = 0.36 * cs.R + 0.53 * cs.G + 0.11 * cs.B;
                    int R = Clamp(co.R - (int)intensity, 0, 255);
                    int G = Clamp(co.G - (int)intensity, 0, 255);
                    int B = Clamp(co.B - (int)intensity, 0, 255);
                    result.SetPixel(i, j, Color.FromArgb(R, G, B));
                }

            return result;
        }
        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return base.CalculateNewPixelColor(sourceImage, x, y);
        }
    }
}
