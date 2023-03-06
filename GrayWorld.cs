using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class GrayWorld : MyFilter
    {
        double avgR;
        double avgG;
        double avgB;
        protected override void PreProcessImage(Bitmap sourceImage)
        {
            avgB = 0;
            avgR = 0;
            avgG = 0;
            for (int i = 0; i < sourceImage.Width; i++)
                for(int j = 0; j < sourceImage.Height; j++)
                {
                    Color color = sourceImage.GetPixel(i, j);
                    avgR += (double)color.R / (sourceImage.Width * sourceImage.Height);
                    avgG += (double)color.G / (sourceImage.Height * sourceImage.Width);
                    avgB += (double)color.B / (sourceImage.Width * sourceImage.Height);
                }
        }
        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color color = sourceImage.GetPixel(x, y);
            double avg = (avgR + avgG + avgB) / 3;
            double R = color.R * avg / avgR;
            double G = color.G * avg / avgG;
            double B = color.B * avg / avgB;
            return Color.FromArgb(  Clamp((int)R, 0, 255),
                                    Clamp((int)G, 0, 255),
                                    Clamp((int)B, 0, 255));
        }
    }
}
