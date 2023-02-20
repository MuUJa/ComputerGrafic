using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class Sharpning : MatrixFilter
    {
        public Sharpning(int type = 0)
        {
            switch (type) {
                case 0:
                    kernel = new float[,] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
                    break;
                case 1:
                    kernel = new float[,] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } };
                    break;
            }
        }
    }
}
