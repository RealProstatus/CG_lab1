using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using CG_lab1.Part7;
using System.IO;
using System.Drawing.Imaging;
using CG_lab1.Part10;
using static System.Net.WebRequestMethods;
using CG_lab1.Morphology;

namespace CG_lab1
{
    public partial class Form1 : Form
    {

        private Bitmap image;
        private Stack<Bitmap> historyStack;

        public Form1()
        {
            historyStack = new Stack<Bitmap>();
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.png; *.jpg; *.bmp; | All Files (*.*) | *.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                historyStack.Push(image);

                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }

        }
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image == null) return;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Сохранить изображение";
            saveFileDialog.Filter = "Image files | *.png; *.jpg; *.bmp; | All Files (*.*) | *.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(saveFileDialog.FileName).ToLower();
                ImageFormat format = ImageFormat.Png;

                switch (extension)
                {
                    case ".bmp":
                        format = ImageFormat.Bmp; break;
                    case ".jpg":
                    case ".jpeg":
                        format = ImageFormat.Jpeg; break;
                }

                image.Save(saveFileDialog.FileName, format);
            }
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(new InvertFilter());
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filter)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                image = newImage;
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(new BlurFilter());
        }

        private void гауссовоРазмытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(new GaussianFilter());
        }

        private void чбToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(new GrayScaleFilter());
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(new SepiaFilter());
        }

        private void яркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(new BrightnessFilter());
        }
        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(new SharpnessFilter());
        }

        private void переносToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(new Transfer());
        }

        private void поворотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(new Rotate());
        }

        private void фильтрСобеляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(new SobelFilter());
        }

        private void тиснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(new EmbossingFilter());
        }

        private void волныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(new WavesFilter());
        }

        private void стеклоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(new GlassFilter());
        }

        private void motionBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(new MotionBlurFilter(7));
        }

        private void резкостьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            applyFilter(new MoreSharpnessFilter());
        }

        private void операторЩарраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(new SharrOperator());
        }

        private void операторПрюиттаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(new PrewittOperator());
        }

        private void светящиесяКраяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(new LightEdgesFilter());
        }

        private void applyFilter(Filter filter)
        {
            if (image == null || filter == null) return;

            historyStack.Push(new Bitmap(image));

            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (historyStack.Count() > 0)
            {
                image = historyStack.Pop();
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }
        private void медианныйToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            applyFilter(new MedianFilter());
        }

        private void максимумToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            applyFilter(new MaxFilter());
        }

        private void эрозияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(new Erosion());
        }

        private void dilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(new Dilation());
        }

        private void закрытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            applyFilter(new Closing());
        }
    }
}
