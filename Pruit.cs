using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class Pruit : SobelFilter
    {
        public Pruit()
        {
            double[] a = { 1, 1, 1 };
            double[] b = { -1, 0, 1 };
            CalculateKernel(a, b);
        }
    }
}
