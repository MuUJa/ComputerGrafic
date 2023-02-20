using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class BlurFilter : MatrixFilter
    {
        public BlurFilter(int size)
        {
            kernel = new float[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    kernel[i, j] = 1.0f / (float)(size * size);
                }
        }
    }
}
