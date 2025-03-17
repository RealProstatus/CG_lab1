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
            InvertFilter filter = new InvertFilter();
            applyFilter(filter);
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
            Filter filter = new BlurFilter();
            applyFilter(filter);
        }

        private void гауссовоРазмытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new GaussianFilter();
            applyFilter(filter);
        }

        private void чбToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new GrayScaleFilter();
            applyFilter(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new SepiaFilter();
            applyFilter(filter);
        }

        private void яркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new BrightnessFilter();
            applyFilter(filter);
        }
        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new SharpnessFilter();
            applyFilter(filter);
        }

        private void переносToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Transfer();
            applyFilter(filter);
        }

        private void поворотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Rotate();
            applyFilter(filter);
        }

        private void фильтрСобеляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new SobelFilter();
            applyFilter(filter);
        }

        private void тиснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new EmbossingFilter();
            applyFilter(filter);
        }

        private void волныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new WavesFilter();
            applyFilter(filter);
        }

        private void стеклоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new GlassFilter();
            applyFilter(filter);
        }

        private void motionBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new MotionBlurFilter(7);
            applyFilter(filter);
        }

        private void резкостьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Filter filter = new MoreSharpnessFilter();
            applyFilter(filter);
        }

        private void операторЩарраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new SharrOperator();
            applyFilter(filter);
        }

        private void операторПрюиттаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new PrewittOperator();
            applyFilter(filter);
        }

        private void светящиесяКраяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new LightEdgesFilter();
            applyFilter(filter);
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
    }
}
