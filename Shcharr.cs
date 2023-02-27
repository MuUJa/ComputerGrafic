using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class Shcharr : SobelFilter
    {
        public Shcharr()
        {
            double[] a = {3, 10, 3 };
            double[] b = {-1, 0, 1 };
            CalculateKernel(a, b);
        }
    }
}
