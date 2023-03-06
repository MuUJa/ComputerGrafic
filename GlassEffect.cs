using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{

    internal class GlassEffect : MyFilter
    {
        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color color = sourceImage.GetPixel(x, y);
            Random rand = new Random();
            int idX = (int)(x + (rand.NextDouble() - 0.5) * 10);
            int idY = (int)(y + (rand.NextDouble() - 0.5) * 10);
            if (Check(idX, 0, sourceImage.Width - 1) && Check(idY, 0, sourceImage.Height - 1))
            {
                return Color.FromArgb(sourceImage.GetPixel(idX, idY).A,
                    sourceImage.GetPixel(idX, idY).R,
                    sourceImage.GetPixel(idX, idY).G,
                    sourceImage.GetPixel(idX, idY).B);
            }
            else
                return Color.FromArgb(0, 0, 0, 0);

        }
        private bool Check(int value, int min, int max)
        {
            if (value < min)
                return false;
            if (value > max)
                return false;
            return true;
        }
    }
}
