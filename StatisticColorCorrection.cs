using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGrafic
{
    class StatisticColorCorrection : MyFilter
    {
        Bitmap baseImage;

        double expectR = 0;
        double expectG = 0;
        double expectB = 0;
        double expectR1 = 0;
        double expectG1 = 0;
        double expectB1 = 0;
        double dispersionR = 0;
        double dispersionG = 0;
        double dispersionB = 0;
        double dispersionR1 = 0;
        double dispersionG1 = 0;
        double dispersionB1 = 0;
        public StatisticColorCorrection()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image files | *.png; *.jpg; *.bmp; | All Filles (*.*) | *.*",
                Title = "Open an Reference Image File"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                baseImage = new Bitmap(ofd.FileName);
            }
        }
        protected override void PreProcessImage(Bitmap sourceImage)
        {
            for (int i = 0; i < baseImage.Width; i++)
                for (int j = 0; j < baseImage.Height; j++)
                {
                    Color color = baseImage.GetPixel(i, j);
                    int n = baseImage.Width * baseImage.Height;
                    expectR += color.R / n;
                    expectG += color.G / n;
                    expectB += color.B / n;
                    dispersionR += CalcDispersion(color.R, expectR, n);
                    dispersionG += CalcDispersion(color.G, expectG, n);
                    dispersionB += CalcDispersion(color.B, expectB, n);
                }
            for (int i = 0; i < sourceImage.Width; i++)
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color color = sourceImage.GetPixel(i, j);
                    int n = sourceImage.Width * sourceImage.Height;
                    expectR1 += color.R / n;
                    expectG1 += color.G / n;
                    expectB1 += color.B / n;
                    dispersionR1 += CalcDispersion(color.R, expectR, n);
                    dispersionG1 += CalcDispersion(color.G, expectG, n);
                    dispersionB1 += CalcDispersion(color.B, expectB, n);
                }
        }
        protected double CalcDispersion(double c, double expect, double n)
        {
            return (c - expect) * (c - expect) / n;
        }
        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color color = sourceImage.GetPixel(x, y);
            double R = expectR + (color.R - expectR1) * dispersionR / dispersionR1;
            double G = expectG + (color.G - expectG1) * dispersionG / dispersionG1;
            double B = expectB + (color.B - expectB1) * dispersionB / dispersionB1;
            return Color.FromArgb(Clamp((int)R, 0, 255),
                Clamp((int)G, 0, 255), Clamp((int)B, 0, 255));
        }
    }
}
