﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gains
{
    public partial class Form1 : Form
    {
        private readonly ColorService _colorService;
        private readonly GainService _gainService;
        private readonly VonNeumanService _neumanService;
        private readonly InclusionService _inclusionService;
        private readonly PropabilityService _propabilityService;
        private Cell[,] _cellStateTable;
        private Bitmap _bitmap;
        private readonly Random _random = new Random();
        private static readonly object SyncLock = new object();

        public Form1()
        {
            _gainService = new GainService();
            _colorService = new ColorService();
            _neumanService = new VonNeumanService();
            _inclusionService = new InclusionService();
            _propabilityService = new PropabilityService();
            InitializeComponent();
            InclusionType.Items.Add("Square");
            InclusionType.Items.Add("Circle");
            NeighberhoodType.Items.Add("VonNeuman");
            NeighberhoodType.Items.Add("Propability");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sizeX = int.Parse(SizeX.Text);
            var sizeY = int.Parse(SizeY.Text);
            var propability = 10;
            var z = 0;

            if (NeighberhoodType.Text == "VonNeuman")
            {
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

            if (NeighberhoodType.Text == "Propability")
            {
                while (z < 100)
                {
                    for (int i = 0; i < sizeX; i++)
                    {
                        for (int j = 0; j < sizeY; j++)
                        {
                            _cellStateTable = _propabilityService.AddNeighbor(i, j, _cellStateTable, sizeX, sizeY, propability);
                        }
                    }
                    _bitmap = UpdateBitmap(_bitmap, _cellStateTable);
                    pictureBox1.Image = _bitmap;
                    pictureBox1.Show();
                    pictureBox1.Update();
                    _cellStateTable = RemoveUpdateLockOnCellsPropability(_cellStateTable, sizeX, sizeY);
                    z++;
                }
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

            for (var i = 1; i < bitmap.Height - 1; i++)
            {
                for (var j = 1; j < bitmap.Width - 1; j++)
                {
                    bitmap.SetPixel(j, i, cellArray[j, i].CellColor);
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
                    bitmap.SetPixel(j, i, cellArray[j, i].CellColor);
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
        private Cell[,] RemoveUpdateLockOnCellsPropability(Cell[,] cells, int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (cells[i, j].CellColor == Color.White)
                        cells[i, j].IsUpdated = false;

                    cells[i, j].IsLocked = false;
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

        private void AddInclusions_Click(object sender, EventArgs e)
        {
            var sizeX = int.Parse(SizeX.Text);
            var sizeY = int.Parse(SizeY.Text);
            var inclusionsAmount = int.Parse(InclusionSize.Text);
            var inclusionSize = int.Parse(InclusionSize.Text);

            if (_cellStateTable == null)
                _cellStateTable = InitCellTable(sizeX, sizeY);

            _bitmap = InitBitmap(sizeX, sizeY, _cellStateTable);

            var type = InclusionType.Text;

            for (int i = 0; i < inclusionsAmount; i++)
            {
                _cellStateTable = _inclusionService.AddInclusions(_cellStateTable, inclusionSize, type, sizeX, sizeY);
            }

            _bitmap = UpdateBitmap(_bitmap, _cellStateTable);
            pictureBox1.Image = _bitmap;
            pictureBox1.Show();
            pictureBox1.Update();
        }

        private void AddInclusionsAfterSimulation_Click(object sender, EventArgs e)
        {
            var sizeX = int.Parse(SizeX.Text);
            var sizeY = int.Parse(SizeY.Text);
            var inclusionsAmount = int.Parse(InclusionSize.Text);
            var inclusionSize = int.Parse(InclusionSize.Text);

            if (_cellStateTable == null)
                _cellStateTable = InitCellTable(sizeX, sizeY);

            _bitmap = InitBitmap(sizeX, sizeY, _cellStateTable);

            var type = InclusionType.Text;

            var inclusions =
                _inclusionService.GetInclusionsAfterSimulation(_cellStateTable, inclusionsAmount, sizeX, sizeY);

            _cellStateTable = _inclusionService.AddInclusions(_cellStateTable, inclusions, inclusionSize, type, sizeX, sizeY);

            _bitmap = UpdateBitmap(_bitmap, _cellStateTable);
            pictureBox1.Image = _bitmap;
            pictureBox1.Show();
            pictureBox1.Update();
        }

        private void CleanUp_Click(object sender, EventArgs e)
        {
            var sizeX = int.Parse(SizeX.Text);
            var sizeY = int.Parse(SizeY.Text);

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    _cellStateTable[i, j].CellColor = Color.White;
                    _cellStateTable[i, j].IsUpdated = false;
                    _cellStateTable[i, j].IsLocked = false;
                }
            }
            _bitmap = UpdateBitmap(_bitmap, _cellStateTable);
            pictureBox1.Image = _bitmap;
            pictureBox1.Show();
            pictureBox1.Update();
        }

        private void SetBou_Click(object sender, EventArgs e)
        {
            var sizeX = int.Parse(SizeX.Text);
            var sizeY = int.Parse(SizeY.Text);
            var inclusionSize = int.Parse(InclusionSize.Text);

            if (_cellStateTable == null)
                _cellStateTable = InitCellTable(sizeX, sizeY);

            _bitmap = InitBitmap(sizeX, sizeY, _cellStateTable);

            var type = InclusionType.Text;

            var inclusions =
                _inclusionService.GetInclusionsAfterSimulation(_cellStateTable, sizeX, sizeY);

            _cellStateTable = _inclusionService.AddInclusions(_cellStateTable, inclusions, inclusionSize, type, sizeX, sizeY);

            _bitmap = UpdateBitmap(_bitmap, _cellStateTable);
            pictureBox1.Image = _bitmap;
            pictureBox1.Show();
            pictureBox1.Update();
        }

        private void CleanUpWithoutBoundaries_Click(object sender, EventArgs e)
        {
            var sizeX = int.Parse(SizeX.Text);
            var sizeY = int.Parse(SizeY.Text);

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (_cellStateTable[i, j].CellColor == Color.Black) continue;
                    _cellStateTable[i, j].CellColor = Color.White;
                    _cellStateTable[i, j].IsUpdated = false;
                    _cellStateTable[i, j].IsLocked = false;
                }
            }
            _bitmap = UpdateBitmap(_bitmap, _cellStateTable);
            pictureBox1.Image = _bitmap;
            pictureBox1.Show();
            pictureBox1.Update();
        }
    }
}
