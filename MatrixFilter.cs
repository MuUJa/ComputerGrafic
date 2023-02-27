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
        protected double[,] kernel;
        protected MatrixFilter() { }
        public MatrixFilter(double[,] kernel) { this.kernel = kernel; }
        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            double resultA = sourceImage.GetPixel(x, y).A;
            double resultR = 0, resultG = 0, resultB = 0;
            DefaultSet(ref resultR, ref resultG, ref resultB);
            for (int i = -radiusY; i <= radiusY; i++)
            {
                for (int j = -radiusX; j <= radiusX; j++)
                {
                    int idX = Clamp(x + j, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + j, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    //resultA += neighborColor.A * kernel[j + radiusX, i + radiusY];
                    resultR = CalculateComponent(resultR, neighborColor.R, j + radiusX, i + radiusY);
                    resultG = CalculateComponent(resultG, neighborColor.G, j + radiusX, i + radiusY);
                    resultB = CalculateComponent(resultB, neighborColor.B, j + radiusX, i + radiusY);
                }
            }
            //resultA = Clamp((int)resultA, 0, 255);
            resultR = Clamp((int)resultR, 0, 255);
            resultG = Clamp((int)resultG, 0, 255);
            resultB = Clamp((int)resultB, 0, 255);

            return Color.FromArgb((int)resultA, (int)resultR, (int)resultG, (int)resultB);
            //return Color.FromArgb((int)resultR, (int)resultG, (int)resultB);
        }
        protected virtual double CalculateComponent(double result, int cur_color, int x, int y)
        {
            return (result + cur_color * kernel[x, y]);
        }
        protected virtual void DefaultSet(ref double R, ref double G, ref double B)
        {
            R = 0; G = 0; B = 0;
        }
    }
}
