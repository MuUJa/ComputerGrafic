using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGrafic
{
    public partial class Form1 : Form
    {
        Bitmap image;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image files | *.png; *.jpg; *.bmp; | All Filles (*.*) | *.*",
                Title = "Open an Image File"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(ofd.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "PNG Image|*.png|JPeg Image|*.jpg|Bitmap Image|*.bmp",
                Title = "Save an Image File"
            };
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();

                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        image.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                        break;

                    case 2:
                        image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 3:
                        image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                }
                fs.Close();
            }
        }

        private void invertColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertFilter filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((MyFilter)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                image = newImage;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar2.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyFilter filter = new BlurFilter(5);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void gaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyFilter filter = new GaussianFilter(2, 0.84);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyFilter filter = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
            
        }

        private void blackWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyFilter filter = new WBFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void sharpeningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyFilter filter = new Sharpning(1);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void addConstantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyFilter filter = new AddConstantFilter(-20);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void binImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyFilter filter = new BinImage();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void medianFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyFilter filter = new MedianFilter(1);
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void shcharrsOperatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyFilter filter = new Shcharr();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void pruitOperatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyFilter filter = new Pruit();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MyFilter filter = new MaxFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void embossingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyFilter filter = new Embossing();
            backgroundWorker1.RunWorkerAsync(filter);
            MyFilter filter2 = new AddConstantFilter(100);
            backgroundWorker1.RunWorkerAsync(filter2);
        }

        private void mMOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyFilter filter = new MMOpen(5);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void mMCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyFilter filter = new MMClose(5);
            backgroundWorker1.RunWorkerAsync(filter);
        }
    }
}
