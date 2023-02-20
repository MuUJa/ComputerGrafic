using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class InvertFilter : MyFilter
    {
        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y) 
        { 
            Color color = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(color.A, 255 - color.R, 255 - color.G, 255 - color.B);  
            return resultColor;
        }
    }
}
