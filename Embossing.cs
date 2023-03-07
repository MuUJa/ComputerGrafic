using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class Embossing : MatrixFilter
    {
        public Embossing()
        {
            kernel = new double[3, 3] { { 0, 1, 0 }, { 1, 0, -1 }, { 0, -1, 0 } };
        }
        protected override int NormalizeComponent(double component)
        {
            component += 255;
            component /= 2;
            return Clamp((int)component, 0, 255);
        }
    }
}
