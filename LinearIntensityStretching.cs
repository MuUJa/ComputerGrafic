using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class LinearIntensityStretching : MyFilter
    {
        double max_intensity = 0;
        double min_intensity = 255;
        protected override void PreProcessImage(Bitmap sourceImage)
        {
            for (int i = 0; i < sourceImage.Width; i++)
                for(int j = 0; j < sourceImage.Height; j++)
                {
                    Color color = sourceImage.GetPixel(i, j);
                    double intensity = 0.36 * color.R + 0.53 * color.G + 0.11 * color.B;
                    if (intensity > max_intensity) max_intensity = intensity;
                    if (intensity < min_intensity) min_intensity = intensity;
                }
        }
        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color color = sourceImage.GetPixel(x, y);
            double R = (color.R - min_intensity) * 255 / (max_intensity - min_intensity);
            double G = (color.G - min_intensity) * 255 / (max_intensity - min_intensity);
            double B = (color.B - min_intensity) * 255 / (max_intensity - min_intensity);
            return Color.FromArgb(Clamp((int)R, 0, 255), Clamp((int)G, 0, 255), Clamp((int)B, 0, 255));
        }
    }
}
