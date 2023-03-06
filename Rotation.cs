using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class Rotation:MatrixFilter
    {
        int x0, y0;
        double _alpha;
        public Rotation(int x, int y, double size)
        {
            x0 = x;
            y0 = y;
            _alpha = size;
        }
        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {


            int idX = (int)((x-x0) * Math.Cos(_alpha) - (y - y0) * Math.Sin(_alpha) + x0);
            int idY = (int)((x-x0) * Math.Sin(_alpha) + (y - y0) * Math.Cos(_alpha) + y0);
            if (OwnershipСheck(idX, 0, sourceImage.Width - 1) && OwnershipСheck(idY, 0, sourceImage.Height - 1))
            {
                return Color.FromArgb(sourceImage.GetPixel(x, y).A,
                                sourceImage.GetPixel(idX, idY).R,
                                sourceImage.GetPixel(idX, idY).G,
                                sourceImage.GetPixel(idX, idY).B);
            }
            else
            {
                return Color.FromArgb(0,
                                0, 0, 0);
            }

        }

        public bool OwnershipСheck(int value, int min, int max)
        {
            if (value < min)
                return false;
            if (value > max)
                return false;
            return true;
        }
    }
}
