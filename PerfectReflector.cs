using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class PerfectReflector : MyFilter
    {
        int maxR;
        int maxG;
        int maxB;
        protected override void PreProcessImage(Bitmap sourceImage)
        {
            double max_intensity = 0;
            for (int i = 0; i < sourceImage.Width; i++)
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color color = sourceImage.GetPixel(i, j);
                    double intensity = 0.36 * color.R + 0.53 * color.G + 0.11 * color.B;
                    if (max_intensity < intensity)
                    {
                        max_intensity = intensity;
                        maxR = color.R;
                        maxG = color.G;
                        maxB = color.B;
                    }
                }
        }
        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color color = sourceImage.GetPixel(x, y);
            double R = color.R * 255 / maxR;
            double G = color.G * 255 / maxG;
            double B = color.B * 255 / maxB;
            return Color.FromArgb(  Clamp((int)R, 0, 255),
                                    Clamp((int)G, 0, 255),
                                    Clamp((int)B, 0, 255));
        }
    }
}
