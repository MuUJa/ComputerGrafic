﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGrafic
{
    internal class Transfer: MyFilter
    {
        int k, l;
       
        public Transfer(int x, int y) { 
            k = x;
            l = y;
 
        }
        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {            
            int idX = x+k;
            int idY = y+l;
            if (OwnershipСheck(idX,0,sourceImage.Width-1) && OwnershipСheck(idY, 0, sourceImage.Height-1))
            {
                return Color.FromArgb(sourceImage.GetPixel(x, y).A,
                                sourceImage.GetPixel(idX, idY).R,
                                sourceImage.GetPixel(idX, idY).G,
                                sourceImage.GetPixel(idX, idY).B);
            }
            else
            {
                return Color.FromArgb(0,
                                0,0,0);
            }
            
        }

        public bool OwnershipСheck(int value, int min, int max)
        {
            if (value < min)
                return false;
            if (value > max)
                return false;
            return true;
        }

    }

}
