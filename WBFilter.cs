using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class WBFilter : MyFilter
    {
        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color color = sourceImage.GetPixel(x, y);
            double intensity = 0.36 * color.R + 0.53 * color.G + 0.11 * color.B;
            return Color.FromArgb(color.A, (int)intensity, (int)intensity, (int)intensity);
        }
    }
}
