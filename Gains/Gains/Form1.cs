using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gains
{
    public partial class Form1 : Form
    {
        private readonly ColorService _colorService;
        private readonly GainService _gainService;
        private readonly VonNeumanService _neumanService;
        private Cell[,] _cellStateTable;
        private Bitmap _bitmap;

        public Form1()
        {
            _gainService = new GainService();
            _colorService = new ColorService();
            _neumanService = new VonNeumanService();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sizeX = int.Parse(SizeX.Text);
            var sizeY = int.Parse(SizeY.Text);
            var z = 0;
            while (z < 100)
            {
                for (int i = 0; i < sizeX; i++)
                {
                    for (int j = 0; j < sizeY; j++)
                    {
                        _cellStateTable = _neumanService.AddNeighbor(i, j, _cellStateTable[i, j].CellColor, _cellStateTable, sizeX, sizeY);
                    }
                }
                _bitmap = UpdateBitmap(_bitmap, _cellStateTable);
                pictureBox1.Image = _bitmap;
                pictureBox1.Show();
                pictureBox1.Update();
                _cellStateTable = RemoveUpdateLockOnCells(_cellStateTable, sizeX, sizeY);
                z++;
            }
        }

        private Cell[,] InitCellTable(int sizeX, int sizeY)
        {
            var cellArray = new Cell[sizeX, sizeY];

            for (var i = 0; i < sizeX; i++)
            {
                for (var j = 0; j < sizeY; j++)
                {
                    cellArray[i, j] = new Cell { CellColor = _colorService.GetDefaultColor() };
                }
            }

            return cellArray;
        }
        private static Bitmap InitBitmap(int sizeX, int sizeY, Cell[,] cellArray)
        {
            var bitmap = new Bitmap(sizeX, sizeY);

            for (var i = 0; i < bitmap.Height; i++)
            {
                for (var j = 0; j < bitmap.Width; j++)
                {
                    bitmap.SetPixel(i, j, cellArray[i, j].CellColor);
                }
            }

            return bitmap;
        }
        private static Bitmap UpdateBitmap(Bitmap bitmap, Cell[,] cellArray)
        {
            for (var i = 0; i < bitmap.Height; i++)
            {
                for (var j = 0; j < bitmap.Width; j++)
                {
                    bitmap.SetPixel(i, j, cellArray[i, j].CellColor);
                }
            }
            return bitmap;
        }

        private Cell[,] RemoveUpdateLockOnCells(Cell[,] cells, int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    cells[i, j].IsUpdated = false;
                }
            }
            return cells;
        }

        private void GenerateSpace_Click(object sender, EventArgs e)
        {
            var sizeX = int.Parse(SizeX.Text);
            var sizeY = int.Parse(SizeY.Text);
            pictureBox1.Size = new Size(sizeX, sizeY);
            pictureBox1.BackColor = Color.White;
        }

        private void AddGains_Click(object sender, EventArgs e)
        {
            var sizeX = int.Parse(SizeX.Text);
            var sizeY = int.Parse(SizeY.Text);
            _cellStateTable = InitCellTable(sizeX, sizeY);
            _bitmap = InitBitmap(sizeX, sizeY, _cellStateTable);
            var gains = _gainService.CreateGain(int.Parse(NumberOfGains.Text));
            _bitmap = _gainService.SetGainToBitmap(_bitmap, gains, ref _cellStateTable);
            pictureBox1.Image = _bitmap;
            pictureBox1.Show();
            pictureBox1.Update();
        }
    }
}
