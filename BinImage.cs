using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class BinImage : MyFilter
    {
        double avgIntensity = 0;
        protected override void PreProcessImage(Bitmap sourceImage)
        {
            double sum = 0;
            for (int x = 0; x < sourceImage.Width; x++) 
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    Color color = sourceImage.GetPixel(x, y);
                    double intensity = 0.36 * color.R + 0.53 * color.G + 0.11 * color.B;
                    sum += intensity;
                }
            avgIntensity = sum / ((double)sourceImage.Width * (double)sourceImage.Height);
        }
        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color color = sourceImage.GetPixel(x, y);
            double intensity = 0.36 * color.R + 0.53 * color.G + 0.11 * color.B;
            if (intensity < avgIntensity)
                return Color.Black;
            else
                return Color.White;
        }
    }
}
