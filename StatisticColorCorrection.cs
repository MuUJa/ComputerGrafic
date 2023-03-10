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

        double[,] expectation;
        double[,] dispersion;
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
            Bitmap [] images = new Bitmap[] {baseImage, sourceImage};
            expectation = new double[2,3];
            dispersion = new double[2, 3];
            for (int t = 0; t < 2; t++)
            {
                Bitmap image = images[t];
                int n = image.Height * image.Width;
                for (int i = 0; i < image.Width; i++)
                    for (int j = 0; j < image.Height; j++)
                    {
                        Color color = image.GetPixel(i, j);
                        int[] colorComponent = new int[] { color.R, color.G, color.B };
                        for (int k = 0; k < colorComponent.Length; k++)
                        {
                            int c = colorComponent[k];
                            expectation[t, k] += c / n;
                            dispersion[t, k] += CalcDispersion(c, n);
                        }
                    }
            }
        }
        protected double CalcDispersion(double c, double n)
        {
            double expect = c / n;
            return (c - expect) * (c - expect) / n;
        }
        protected override Color CalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color color = sourceImage.GetPixel(x, y);
            double[] compColor = new double[3] { color.R, color.G, color.B };
            double[] resCompColor = new double[3];
            for (int i = 0; i < 3; i++)
            { 
                resCompColor[i] = expectation[0, i] + (compColor[i] - expectation[1, i]) *
                    dispersion[0, i] / dispersion[1, i];
            }
            return Color.FromArgb(Clamp((int)resCompColor[0], 0, 255),
                Clamp((int)resCompColor[1], 0, 255), Clamp((int)resCompColor[2], 0, 255));
        }
    }
}
