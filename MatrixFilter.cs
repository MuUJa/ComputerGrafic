using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class MatrixFilter : MyFilter
    {
        protected float[,] kernel;
        protected MatrixFilter() { }
        public MatrixFilter(float[,] kernel) { this.kernel = kernel; }
        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            float resultA = 0;
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for (int i = -radiusY; i < radiusY; i++)
            {
                for (int j = -radiusX; j < radiusX; j++)
                {
                    int idX = Clamp(x + j, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + j, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultA += neighborColor.A * kernel[j + radiusX, i + radiusY];
                    resultR += neighborColor.R * kernel[j + radiusX, i + radiusY];
                    resultG += neighborColor.G * kernel[j + radiusX, i + radiusY];
                    resultB += neighborColor.B * kernel[j + radiusX, i + radiusY];
                }
            }
            resultA = Clamp((int)resultA, 0, 255);
            resultR = Clamp((int)resultR, 0, 255);
            resultG = Clamp((int)resultG, 0, 255);
            resultB = Clamp((int)resultB, 0, 255);

            return Color.FromArgb((int)resultA, (int)resultR, (int)resultG, (int)resultB);
            //return Color.FromArgb((int)resultR, (int)resultG, (int)resultB);
        }
    }
}
