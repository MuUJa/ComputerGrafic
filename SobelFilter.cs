using System;
using System.Drawing;

namespace ComputerGrafic
{
    internal class SobelFilter : MatrixFilter
    {
        public SobelFilter(bool vertical = true)
        {
            int[] a = { 3, 10, 3 };
            int[] b = { 1, 0, -1 };
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
        //    return Color.FromArgb(0, 0, 0);
        //}
    }
}