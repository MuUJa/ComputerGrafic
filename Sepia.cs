using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class Sepia : MyFilter
    {
        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            double Intensity = (0.36 * sourceColor.R + 0.53 * sourceColor.G + 0.11 * sourceColor.B);
            int k = 30;
            double R = (Intensity + 2 * k);
            double G = (Intensity + 0.5f * k);
            double B = (Intensity - 1 * k);
            Color resultColor = Color.FromArgb(
                Clamp((int)R, 0, 255),
                Clamp((int)G, 0, 255),
                Clamp((int)B, 0, 255));
            return resultColor;
        }
    }
}
