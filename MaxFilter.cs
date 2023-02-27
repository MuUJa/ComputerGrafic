using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class MaxFilter : MyFilter
    {
        int constMin = 100;

        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color color = sourceImage.GetPixel(x, y);
            int R = color.R;
            int G = color.G;
            int B = color.B;
            if (color.R < constMin)
                R = 0;
            if (color.G < constMin)
                G = 0;
            if(color.B < constMin)
                B = 0;
            return Color.FromArgb(color.A, R, G, B);
        }
    }
}
