using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class MedianFilter : MyFilter
    {
        int radius;
        public MedianFilter(int radius) { this.radius = radius; }
        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int size = 2 * radius + 1;
            int[] pixelsR = new int[size * size];
            int[] pixelsG = new int[size * size];
            int[] pixelsB = new int[size * size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    int idX = Clamp(x + i - radius, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + j - radius, 0, sourceImage.Height - 1);
                    Color color = sourceImage.GetPixel(idX, idY);
                    pixelsR[i + j * size] = color.R;
                    pixelsG[i + j * size] = color.G;
                    pixelsB[i + j * size] = color.B;
                }
            Array.Sort(pixelsR);
            Array.Sort(pixelsB);
            Array.Sort(pixelsG);
            return Color.FromArgb(sourceImage.GetPixel(x, y).A,
                pixelsR[(int)(size * size / 2)],
                pixelsG[(int)(size * size / 2)],
                pixelsB[(int)(size * size / 2)]);
        }
    }
}
