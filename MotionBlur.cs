using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class MotionBlur : MatrixFilter
    {
        public MotionBlur(int size)
        {
            kernel = new double[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    if (i != j)
                        kernel[i, j] = 0;
                    else
                        kernel[i, j] = 1.0 / (double)size;
                }
        }
    }
}
