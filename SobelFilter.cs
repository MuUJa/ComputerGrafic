using System;
using System.Drawing;

namespace ComputerGrafic
{
    internal class SobelFilter : MatrixFilter
    {
        new double[,,] kernel;
        public SobelFilter(bool vertical = true)
        {
            double[] a = { 1, 2, 1};
            double[] b = { -1, 0, 1 };
            CalculateKernel(a, b);
        }
        protected void CalculateKernel(double[] a, double[] b)
        {
            kernel = new double[2, 3, 3];
            for (int t = 0; t < 2; t++)
            {
                for (int i = 0; i < a.Length; i++)
                    for (int j = 0; j < b.Length; j++)
                    {
                        kernel[t, i, j] += a[t * i + (1 - t) * j] * b[t * j + (1 - t) * i];
                    }
            }
        }
        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            double[] R = new double[] { 0, 0 };
            double[] G = new double[] { 0, 0 };
            double[] B = new double[] { 0, 0 };
            for (int t = 0; t < 2; t++)
                for (int i = -radiusY; i <= radiusY; i++)
                {
                    for (int j = -radiusX; j <= radiusX; j++)
                    {
                        int idX = Clamp(x + j, 0, sourceImage.Width - 1);
                        int idY = Clamp(y + j, 0, sourceImage.Height - 1);
                        Color neighborColor = sourceImage.GetPixel(idX, idY);
                        R[t] += neighborColor.R * kernel[t, j + radiusX, i + radiusY];
                        G[t] += neighborColor.G * kernel[t, j + radiusX, i + radiusY];
                        B[t] += neighborColor.B * kernel[t, j + radiusX, i + radiusY];
                    }
                }
            double resultR = Math.Sqrt(R[0] * R[0] + R[1] * R[1]);
            double resultG = Math.Sqrt(G[0] * G[0] + G[1] * G[1]);
            double resultB = Math.Sqrt(B[0] * B[0] + B[1] * B[1]);

            return Color.FromArgb(sourceImage.GetPixel(x, y).A,
                                    Clamp((int)resultR, 0, 255),
                                    Clamp((int)resultG, 0, 255),
                                    Clamp((int)resultB, 0, 255) );
        }
    }
}