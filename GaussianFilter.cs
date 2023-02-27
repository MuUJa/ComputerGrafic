using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class GaussianFilter : MatrixFilter
    {
        public GaussianFilter(int radius, double sigma) { CreateGaussianKernel(radius, sigma); }
        public void CreateGaussianKernel(int radius, double sigma)
        {
            int size = radius * 2 + 1;
            kernel = new double[size, size];
            double normalizer = 0;
            for (int i = -radius; i < radius; i++)
                for (int j = -radius; j < radius; j++)
                {
                    kernel[i + radius, j + radius] = (double)(Math.Exp(-i*i + j*j) / (sigma * sigma));
                    normalizer += kernel[i + radius, j + radius];
                }
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    kernel[i, j] /= normalizer;
        }
    }
}
