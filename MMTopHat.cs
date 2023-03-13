using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class MMTopHat : MyFilter
    {
        MyFilter closing;
        public MMTopHat(int size)
        {
            closing = new MMClose(size);
        }
        public MMTopHat(double[,] kernel)
        {
            closing = new MMClose(kernel);
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap clBmp = closing.processImage(sourceImage, worker);
            Bitmap result = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color cs = sourceImage.GetPixel(i, j);
                    Color cc = clBmp.GetPixel(i, j);
                    double intensity = 0.36 * cs.R + 0.53 * cs.G + 0.11 * cs.B;
                    int R = Clamp((int)intensity - cc.R, 0, 255);
                    int G = Clamp((int)intensity - cc.G, 0, 255);
                    int B = Clamp((int)intensity - cc.B, 0, 255);
                    result.SetPixel(i, j, Color.FromArgb(R, G, B));
                }

            return result;
        }

        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
