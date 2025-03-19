using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG_lab1
{
    public partial class KernelSelector : Form
    {
        public bool[,] UserKernel {  get; private set;}
        private CheckBox[,] checkBoxes;
        private int kWidth, kHeight;
        private List<Control> gridControls = new List<Control>();
        private NumericUpDown udColumns, udRows;

        private void InitaializeControls()
        {
            Label lCol = new Label();
            lCol.Text = "Столбцы:";
            lCol.Location = new Point(10,10);
            AutoSize = true;
            this.Controls.Add(lCol);

            udColumns = new NumericUpDown();
            udColumns.Minimum = 1;
            udColumns.Value = kWidth;
            udColumns.Location = new Point(150,10);
            udColumns.Width = 60;
            this.Controls.Add(udColumns);
            udColumns.ValueChanged += KernelSize_ValueChanged;

            Label lRows = new Label();
            lRows.Text = "Строки:";
            lRows.Location = new Point(10, 50);
            AutoSize = true;
            this.Controls.Add(lRows);

            udRows = new NumericUpDown();
            udRows.Minimum = 1;
            udRows.Value = kWidth;
            udRows.Location = new Point(150, 50);
            udRows.Width = 60;
            this.Controls.Add(udRows);
            udRows.ValueChanged += KernelSize_ValueChanged;

        }

        private void KernelSize_ValueChanged(object sender, EventArgs e)
        {
            kWidth = (int)udColumns.Value;
            kHeight = (int)udRows.Value;
            CreateKernelGrid();
        }

        private void CreateKernelGrid()
        {
            //очистка элементов сетки
            foreach(var elem in gridControls)
            {
                this.Controls.Remove(elem);
                elem.Dispose();
            }
            gridControls.Clear();

            checkBoxes = new CheckBox[kWidth, kHeight];
            int cellSize = 30;

            int stY = 80;//стартовая позиция для размещения
            //заполнение
            for(int y = 0; y < kHeight; y++)
            {
                for(int x = 0; x < kWidth; x++)
                {
                    CheckBox cB = new CheckBox();
                    cB.Checked = true;
                    cB.Size = new Size(cellSize, cellSize);
                    cB.Location = new Point(x * cellSize, y * cellSize + stY);

                    checkBoxes[x,y] = cB;
                    this.Controls.Add(cB);
                    gridControls.Add(cB);
                }
            }

            //кнопка для подтверждения
            Button apply = new Button();
            apply.Text = "Применить";
            apply.Location = new Point(0, kHeight * cellSize + stY);
            apply.Size = new Size(kWidth*cellSize, 50);

            apply.Click += Apply_Click;
            this.Controls.Add(apply);
            gridControls.Add(apply);
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            UserKernel = new bool[kWidth, kHeight];

            for(int x = 0; x < kWidth; x++)
            {
                for(int y = 0;y < kHeight; y++)
                {
                    UserKernel[x, y] = checkBoxes[x, y].Checked;
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public KernelSelector(int w = 3, int h = 3)
        {
            kWidth = w;
            kHeight = h;
            UserKernel = new bool[kWidth, kHeight];
            InitializeComponent();
            InitaializeControls();
            CreateKernelGrid();
        }
    }
}
