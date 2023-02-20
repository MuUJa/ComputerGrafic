using System;
using System.Drawing;

namespace ComputerGrafic
{
    internal class SobelFilter : MatrixFilter
    {
        public SobelFilter(bool vertical = true)
        {
            float[] a = { 3, 10, 3 };
            float[] b = { 1, 0, -1 };
            kernel = new float[3, 3];
            for (int i = 0; i < a.Length; i++)
                for(int j = 0; j < b.Length; j++)
                    if (vertical)
                        kernel[i,j] += a[i] * b[j];
                    else
                        kernel[j,i] += a[i] * b[j];
            Console.Write(kernel);

        }
        //protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        //{
        //    int radiusX = kernel.GetLength(0) / 2;
        //    int radiusY = kernel.GetLength(1) / 2;

        //    double resultA = 0;
        //    double resultR = 0;
        //    double resultG = 0;
        //    double resultB = 0;
        //    for (int i = -radiusY; i < radiusY; i++)
        //    {
        //        for (int j = -radiusX; j < radiusX; j++)
        //        {
        //            int idX = Clamp(x + j, 0, sourceImage.Width - 1);
        //            int idY = Clamp(y + j, 0, sourceImage.Height - 1);
        //            Color neighborColor = sourceImage.GetPixel(idX, idY);
        //            resultA += neighborColor.A * kernel[j + radiusX, i + radiusY];
        //            resultR += neighborColor.R * kernel[j + radiusX, i + radiusY];
        //            resultG += neighborColor.G * kernel[j + radiusX, i + radiusY];
        //            resultB += neighborColor.B * kernel[j + radiusX, i + radiusY];
        //        }
        //    }
        //    double resultA1 = 0;
        //    double resultR1 = 0;
        //    double resultG1 = 0;
        //    double resultB1 = 0;
        //    for (int i = -radiusY; i < radiusY; i++)
        //    {
        //        for (int j = -radiusX; j < radiusX; j++)
        //        {
        //            int idX = Clamp(x + j, 0, sourceImage.Width - 1);
        //            int idY = Clamp(y + j, 0, sourceImage.Height - 1);
        //            Color neighborColor = sourceImage.GetPixel(idX, idY);
        //            resultA1 += neighborColor.A * kernel[i + radiusY, j + radiusX];
        //            resultR1 += neighborColor.R * kernel[i + radiusY, j + radiusX];
        //            resultG1 += neighborColor.G * kernel[i + radiusY, j + radiusX];
        //            resultB1 += neighborColor.B * kernel[i + radiusY, j + radiusX];
        //        }
        //    }
        //    resultA = Math.Sqrt(resultA * resultA + resultA1 * resultA1);
        //    resultB = Math.Sqrt(resultB * resultB + resultB1 * resultB1);
        //    resultG = Math.Sqrt(resultG * resultG + resultG1 * resultG1);
        //    resultR = Math.Sqrt(resultR * resultR + resultR1 * resultR1);
        //    resultA = Clamp((int)resultA, 0, 255);
        //    resultR = Clamp((int)resultR, 0, 255);
        //    resultG = Clamp((int)resultG, 0, 255);
        //    resultB = Clamp((int)resultB, 0, 255);

        //    return Color.FromArgb((int)resultA, (int)resultR, (int)resultG, (int)resultB);
        //}
    }
}