using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class AddConstantFilter : MyFilter
    {
        int constant;
        public AddConstantFilter(int constant) { this.constant = constant; }
        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color color = sourceImage.GetPixel(x, y);
            int a = Clamp(color.A + constant, 0, 255);
            int b = Clamp(color.B + constant, 0, 255);
            int r = Clamp(color.R + constant, 0, 255);
            int g = Clamp(color.G + constant, 0, 255);
            return Color.FromArgb(a, b, r, g);
        }
    }
}
