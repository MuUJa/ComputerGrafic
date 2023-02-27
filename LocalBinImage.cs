using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class LocalBinImage : MyFilter
    {
        int radius;
        public LocalBinImage(int radius) { this.radius = radius; }
        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            double avgIntensity = 0;
            for (int i = -radius; i <= +radius; i++)
                for (int j = -radius; j <= +radius; j++)
                {
                    int idX = Clamp(x + j, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + j, 0, sourceImage.Height - 1);
                    Color color = sourceImage.GetPixel(idX, idY);
                    double intensity = 0.36 * color.R + 0.53 * color.G + 0.11 * color.B;
                    avgIntensity += intensity; 
                }
            avgIntensity /= (radius*2 + 1) * (1 + 2*radius);
            Color curColor = sourceImage.GetPixel(x, y);
            double curIntensity = 0.36 * curColor.R + 0.53 * curColor.G + 0.11 * curColor.B;
            if (curIntensity > avgIntensity)
                return Color.White;
            else
                return Color.Black;
        }
    }
}
