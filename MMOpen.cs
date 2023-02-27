using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class MMOpen : MatrixFilter
    {
        public MMOpen(int size = 3)
        {
            kernel = new double[size, size];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    kernel[i, j] = 1.0;
        }
        protected override double CalculateComponent(double result, int cur_color, int x, int y)
        {
            if (kernel[x, y] > 0 && result < cur_color)
                return cur_color;
            return result;
        }
    }
}
