using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
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
        private static int MicrostructureId = 0;
        private int textImportSizeX = 0;
        private int textImportSizeY = 0;

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
            MicrostructureType.Items.Add("DualPhase");
            MicrostructureType.Items.Add("Subculture");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sizeX = int.Parse(SizeX.Text);
            var sizeY = int.Parse(SizeY.Text);
            var propability = 10;
            var z = 0;
            if (MicrostructureId != 0 && MicrostructureType.Text == "DualPhase" ||
                MicrostructureType.Text == "Subculture")
            {
                SetLockOnGrains(sizeX, sizeY);
            }

            if (NeighberhoodType.Text == "VonNeuman")
            {
                while (!IsEnd())
                {

                    for (int i = 0; i < sizeX; i++)
                    {
                        for (int j = 0; j < sizeY; j++)
                        {
                            if (!_cellStateTable[i, j].IsLocked)
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
                while (!IsEnd())
                {
                    for (int i = 0; i < sizeX; i++)
                    {
                        for (int j = 0; j < sizeY; j++)
                        {
                            _cellStateTable = _propabilityService.AddNeighbor(i, j, _cellStateTable, sizeX, sizeY, propability, MicrostructureId);
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

                    cells[i, j].IsLockedForPropabilityPurpose = false;
                }
            }
            return cells;
        }

        private void GenerateSpace_Click(object sender, EventArgs e)
        {
            var sizeX = int.Parse(SizeX.Text);
            var sizeY = int.Parse(SizeY.Text);
            _cellStateTable = InitCellTable(sizeX, sizeY);
            pictureBox1.Size = new Size(sizeX, sizeY);
            pictureBox1.BackColor = Color.White;
        }

        private void AddGains_Click(object sender, EventArgs e)
        {
            var sizeX = int.Parse(SizeX.Text);
            var sizeY = int.Parse(SizeY.Text);
            // _cellStateTable = InitCellTable(sizeX, sizeY);
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
                _inclusionService.GetInclusionsAfterSimulation(_cellStateTable, sizeX, sizeY, inclusionsAmount);

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

            if (MicrostructureType.Text != "Subculture" && MicrostructureType.Text != "DualPhase")
            {
                for (int i = 0; i < sizeX; i++)
                {
                    for (int j = 0; j < sizeY; j++)
                    {
                        _cellStateTable[i, j].CellColor = Color.White;
                        _cellStateTable[i, j].IsUpdated = false;
                        _cellStateTable[i, j].IsLockedForPropabilityPurpose = false;
                    }
                }

                _bitmap = UpdateBitmap(_bitmap, _cellStateTable);
                pictureBox1.Image = _bitmap;
                pictureBox1.Show();
                pictureBox1.Update();
            }
            else
            {
                for (int i = 0; i < sizeX; i++)
                {
                    for (int j = 0; j < sizeY; j++)
                    {
                        if (_cellStateTable[i, j].Id != MicrostructureId)
                            _cellStateTable[i, j].CellColor = Color.White;
                        _cellStateTable[i, j].IsUpdated = false;
                        _cellStateTable[i, j].IsLockedForPropabilityPurpose = false;
                    }
                }

                _bitmap = UpdateBitmap(_bitmap, _cellStateTable);
                pictureBox1.Image = _bitmap;
                pictureBox1.Show();
                pictureBox1.Update();
            }
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
                    _cellStateTable[i, j].IsLockedForPropabilityPurpose = false;
                }
            }
            _bitmap = UpdateBitmap(_bitmap, _cellStateTable);
            pictureBox1.Image = _bitmap;
            pictureBox1.Show();
            pictureBox1.Update();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (isGrainBoudariesModeActive.Checked)
            {
                var sizeX = int.Parse(SizeX.Text);
                var sizeY = int.Parse(SizeY.Text);
                var boundaries = GetBoundaries(e, sizeX, sizeY);

                var inclusionSize = int.Parse(InclusionSize.Text);

                if (_cellStateTable == null)
                    _cellStateTable = InitCellTable(sizeX, sizeY);

                _bitmap = InitBitmap(sizeX, sizeY, _cellStateTable);

                var type = InclusionType.Text;

                _cellStateTable =
                    _inclusionService.AddInclusions(_cellStateTable, boundaries, inclusionSize, type, sizeX, sizeY);

                _bitmap = UpdateBitmap(_bitmap, _cellStateTable);
                pictureBox1.Image = _bitmap;
                pictureBox1.Show();
                pictureBox1.Update();
            }

            if (MicrostructureType.Text == "Subculture" || MicrostructureType.Text == "DualPhase")
            {
                GetNotRemovableGrainId(e);
            }
        }

        private bool IsEnd()
        {
            var sizeX = int.Parse(SizeX.Text);
            var sizeY = int.Parse(SizeY.Text);
            var counter = 0;
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (_cellStateTable[i, j].CellColor == Color.White)
                        counter++;
                }
            }
            return counter == 0;
        }

        private List<Cell> GetBoundaries(EventArgs e, int sizeX, int sizeY)
        {
            var mouseEventArgs = e as MouseEventArgs;
            var x = mouseEventArgs.X;
            var y = mouseEventArgs.Y;
            var id = _cellStateTable[x, y].Id;
            var boundaries = new List<Cell>();
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (i - 1 < 0 || i >= sizeX - 1 || j - 1 < 0 || j + 1 >= sizeY) continue;
                    if (_cellStateTable[i, j].Id == id && id != _cellStateTable[i + 1, j].Id ||
                        _cellStateTable[i, j].Id == id && id != _cellStateTable[i - 1, j].Id ||
                        _cellStateTable[i, j].Id == id && id != _cellStateTable[i, j + 1].Id ||
                        _cellStateTable[i, j].Id == id && id != _cellStateTable[i, j - 1].Id)
                    {
                        _cellStateTable[i, j].PositionX = i;
                        _cellStateTable[i, j].PositionY = j;
                        boundaries.Add(_cellStateTable[i, j]);
                    }
                }
            }
            return boundaries;
        }

        private void GetNotRemovableGrainId(EventArgs e)
        {
            var mouseEventArgs = e as MouseEventArgs;
            var x = mouseEventArgs.X;
            var y = mouseEventArgs.Y;
            MicrostructureId = _cellStateTable[x, y].Id;
        }

        private void SetLockOnGrains(int sizeX, int sizeY)
        {
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (_cellStateTable[i, j].Id == MicrostructureId)
                    {
                        _cellStateTable[i, j].IsLocked = true;
                        if (MicrostructureType.Text == "DualPhase")
                        {
                            _cellStateTable[i, j].CellColor = Color.DeepPink;
                        }
                    }
                }
            }

            _bitmap = UpdateBitmap(_bitmap, _cellStateTable);
            pictureBox1.Image = _bitmap;
            pictureBox1.Show();
            pictureBox1.Update();
        }


        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void ExportTxt_Click(object sender, EventArgs e)
        {
            var sizeX = int.Parse(SizeX.Text);
            var sizeY = int.Parse(SizeY.Text);

            StringBuilder fileContent = new StringBuilder();

            fileContent.AppendLine("Image width and height");
            fileContent.AppendLine(String.Format("{0} {1}", sizeX, sizeY));
            fileContent.AppendLine("ID R G B");

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {

                    string linContent = String.Format("{0} {1} {2} {3}", _cellStateTable[i, j].Id, _cellStateTable[i, j].CellColor.R, _cellStateTable[i, j].CellColor.G, _cellStateTable[i, j].CellColor.B);
                    fileContent.AppendLine(linContent);
                }
            }
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.ShowDialog();
            if (dialog.CheckPathExists)
            {
                System.IO.File.WriteAllText(dialog.FileName, fileContent.ToString());
            }
        }

        private void ImportTxt_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "All Files (*.*)|*.*";

            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;
            openFileDialog.ShowDialog();
            if (openFileDialog.CheckFileExists)
            {
                using (StreamReader file = new StreamReader(openFileDialog.FileName))
                {
                    string line;
                    int x = 0; int y = 0; bool firstLine = true;
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] lineArray = line.Split(' ');
                        if (!Int32.TryParse(lineArray[0], out int value))
                            continue;
                        if (firstLine)
                        {
                            textImportSizeX = Convert.ToInt32(lineArray[0]);
                            textImportSizeY = Convert.ToInt32(lineArray[1]);
                            _cellStateTable = InitCellTable(Convert.ToInt32(lineArray[0]), Convert.ToInt32(lineArray[1]));
                            firstLine = false;
                            continue;
                        }

                        if (x == textImportSizeX)
                        {
                            x = 0;
                            y++;
                        }

                        if (x < textImportSizeX && y < textImportSizeY)
                        {
                            _cellStateTable[x, y].Id = Convert.ToInt32(lineArray[0]);
                            _cellStateTable[x, y].CellColor = Color.FromArgb(255,
                                Convert.ToInt32(lineArray[1]),
                                Convert.ToInt32(lineArray[2]),
                                Convert.ToInt32(lineArray[3]));
                            if (_cellStateTable[x, y].CellColor == System.Drawing.Color.White)
                            {
                                _cellStateTable[x, y].Id = 0;
                            }
                        }
                        x++;
                    }

                    _bitmap = InitBitmap(textImportSizeX, textImportSizeY, _cellStateTable);
                    _bitmap = UpdateBitmap(_bitmap, _cellStateTable);
                    pictureBox1.Image = _bitmap;
                    pictureBox1.Show();
                    pictureBox1.Update();
                    _cellStateTable = RemoveUpdateLockOnCells(_cellStateTable, textImportSizeX, textImportSizeY);
                }
            }
        }
    }
}
