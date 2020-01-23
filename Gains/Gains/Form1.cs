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
        private readonly GrainService _gainService;
        private readonly VonNeumanService _neumanService;
        private readonly InclusionService _inclusionService;
        private readonly ProbabilityService _propabilityService;
        private readonly BitmapService _bitmapService;
        private Cell[,] _cellStateTable;
        private Bitmap _bitmap;
        private readonly Random _random = new Random();
        private static readonly object SyncLock = new object();
        private List<int> NotRemovableIds;
        private int _textImportSizeX = 0;
        private int _textImportSizeY = 0;
        private bool _isGrainExist = false;

        public Form1()
        {
            _gainService = new GrainService();
            _colorService = new ColorService();
            _neumanService = new VonNeumanService();
            _inclusionService = new InclusionService();
            _propabilityService = new ProbabilityService();
            NotRemovableIds = new List<int>();
            _bitmapService = new BitmapService();
            InitializeComponent();
            InclusionType.Items.Add("Square");
            InclusionType.Items.Add("Circle");
            NeighberhoodType.Items.Add("VonNeuman");
            NeighberhoodType.Items.Add("Propability");
            MicrostructureType.Items.Add("DualPhase");
            MicrostructureType.Items.Add("Subculture");

            //Test
            SizeX.Text = "200";
            SizeY.Text = "200";
            Probability.Text = "10";
            InclusionSize.Text = "2";
            InclusionType.Text = "Square";
            NumberOfInclusions.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sizeX = int.Parse(SizeX.Text);
            var sizeY = int.Parse(SizeY.Text);
            var propability = int.Parse(Probability.Text);
            var z = 0;
            if (NotRemovableIds.Count != 0 && MicrostructureType.Text == "DualPhase" ||
                MicrostructureType.Text == "Subculture")
            {
                _gainService.SetLockOnGrains(sizeX, sizeY, _cellStateTable, NotRemovableIds, MicrostructureType.Text, _bitmap, pictureBox1);
            }

            if (NeighberhoodType.Text == "VonNeuman")
            {
                while (!IsEnd() && _isGrainExist && z != 500)
                {

                    for (int i = 0; i < sizeX; i++)
                    {
                        for (int j = 0; j < sizeY; j++)
                        {
                            if (!_cellStateTable[i, j].IsLocked)
                                _cellStateTable = _neumanService.AddNeighbor(i, j, _cellStateTable[i, j].CellColor, _cellStateTable, sizeX, sizeY);
                        }
                    }
                    _bitmap = _bitmapService.UpdateBitmap(_bitmap, _cellStateTable);
                    pictureBox1.Image = _bitmap;
                    pictureBox1.Show();
                    pictureBox1.Update();
                    _cellStateTable = _gainService.RemoveUpdateLockOnCells(_cellStateTable, sizeX, sizeY);
                    z++;
                }
            }

            if (NeighberhoodType.Text == "Propability")
            {
                while (!IsEnd() && _isGrainExist && z != 500)
                {
                    for (int i = 0; i < sizeX; i++)
                    {
                        for (int j = 0; j < sizeY; j++)
                        {
                            _cellStateTable = _propabilityService.AddNeighbor(i, j, _cellStateTable, sizeX, sizeY, propability, NotRemovableIds);
                        }
                    }
                    _bitmap = _bitmapService.UpdateBitmap(_bitmap, _cellStateTable);
                    pictureBox1.Image = _bitmap;
                    pictureBox1.Show();
                    pictureBox1.Update();
                    _cellStateTable = _gainService.RemoveUpdateLockOnCellsPropability(_cellStateTable, sizeX, sizeY);
                    z++;
                }
            }
        }

        private void GenerateSpace_Click(object sender, EventArgs e)
        {
            var sizeX = int.Parse(SizeX.Text);
            var sizeY = int.Parse(SizeY.Text);
            _cellStateTable = _gainService.InitCellTable(sizeX, sizeY);
            pictureBox1.Size = new Size(sizeX, sizeY);
            pictureBox1.BackColor = Color.White;
        }

        private void AddGains_Click(object sender, EventArgs e)
        {
            var sizeX = int.Parse(SizeX.Text);
            var sizeY = int.Parse(SizeY.Text);
             //_cellStateTable = _gainService.InitCellTable(sizeX, sizeY);
            _bitmap = _bitmapService.InitBitmap(sizeX, sizeY, _cellStateTable);
            var gains = _gainService.CreateGain(int.Parse(NumberOfGains.Text));
            _isGrainExist = true;
            _bitmap = _gainService.SetGainToBitmap(_bitmap, gains, ref _cellStateTable);
            pictureBox1.Image = _bitmap;
            pictureBox1.Show();
            pictureBox1.Update();
        }

        private void AddInclusions_Click(object sender, EventArgs e)
        {
            var sizeX = int.Parse(SizeX.Text);
            var sizeY = int.Parse(SizeY.Text);
            var inclusionsAmount = int.Parse(NumberOfInclusions.Text);
            var inclusionSize = int.Parse(InclusionSize.Text);

            if (_cellStateTable == null)
                _cellStateTable = _gainService.InitCellTable(sizeX, sizeY);

            _bitmap = _bitmapService.InitBitmap(sizeX, sizeY, _cellStateTable);

            var type = InclusionType.Text;

            for (int i = 0; i < inclusionsAmount; i++)
            {
                _cellStateTable = _inclusionService.AddInclusions(_cellStateTable, inclusionSize, type, sizeX, sizeY);
            }

            _bitmap = _bitmapService.UpdateBitmap(_bitmap, _cellStateTable);
            pictureBox1.Image = _bitmap;
            pictureBox1.Show();
            pictureBox1.Update();
        }

        private void AddInclusionsAfterSimulation_Click(object sender, EventArgs e)
        {
            var sizeX = int.Parse(SizeX.Text);
            var sizeY = int.Parse(SizeY.Text);
            var inclusionsAmount = int.Parse(NumberOfInclusions.Text);
            var inclusionSize = int.Parse(InclusionSize.Text);

            if (_cellStateTable == null)
                _cellStateTable = _gainService.InitCellTable(sizeX, sizeY);

            _bitmap = _bitmapService.InitBitmap(sizeX, sizeY, _cellStateTable);

            var type = InclusionType.Text;

            var inclusions =
                _inclusionService.GetInclusionsAfterSimulation(_cellStateTable, sizeX, sizeY, inclusionsAmount);

            _cellStateTable = _inclusionService.AddInclusions(_cellStateTable, inclusions, inclusionSize, type, sizeX, sizeY);

            _bitmap = _bitmapService.UpdateBitmap(_bitmap, _cellStateTable);
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

                _bitmap = _bitmapService.UpdateBitmap(_bitmap, _cellStateTable);
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
                        if (!NotRemovableIds.Contains(_cellStateTable[i, j].Id))
                            _cellStateTable[i, j].CellColor = Color.White;
                        _cellStateTable[i, j].IsUpdated = false;
                        _cellStateTable[i, j].IsLockedForPropabilityPurpose = false;
                    }
                }

                _bitmap = _bitmapService.UpdateBitmap(_bitmap, _cellStateTable);
                pictureBox1.Image = _bitmap;
                pictureBox1.Show();
                pictureBox1.Update();
            }

            _isGrainExist = false;
        }

        private void SetBou_Click(object sender, EventArgs e)
        {
            var sizeX = int.Parse(SizeX.Text);
            var sizeY = int.Parse(SizeY.Text);
            var inclusionSize = int.Parse(InclusionSize.Text);

            if (_cellStateTable == null)
                _cellStateTable = _gainService.InitCellTable(sizeX, sizeY);

            _bitmap = _bitmapService.InitBitmap(sizeX, sizeY, _cellStateTable);

            var type = InclusionType.Text;

            var inclusions =
                _inclusionService.GetInclusionsAfterSimulation(_cellStateTable, sizeX, sizeY);

            _cellStateTable = _inclusionService.AddInclusions(_cellStateTable, inclusions, inclusionSize, type, sizeX, sizeY);

            _bitmap = _bitmapService.UpdateBitmap(_bitmap, _cellStateTable);
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
            _bitmap = _bitmapService.UpdateBitmap(_bitmap, _cellStateTable);
            pictureBox1.Image = _bitmap;
            pictureBox1.Show();
            pictureBox1.Update();
            _isGrainExist = false;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (isGrainBoudariesModeActive.Checked)
            {
                var sizeX = int.Parse(SizeX.Text);
                var sizeY = int.Parse(SizeY.Text);
                var boundaries = _gainService.GetBoundaries(e, sizeX, sizeY, _cellStateTable);

                var inclusionSize = int.Parse(InclusionSize.Text);

                if (_cellStateTable == null)
                    _cellStateTable = _gainService.InitCellTable(sizeX, sizeY);

                _bitmap = _bitmapService.InitBitmap(sizeX, sizeY, _cellStateTable);

                var type = InclusionType.Text;

                _cellStateTable =
                    _inclusionService.AddInclusions(_cellStateTable, boundaries, inclusionSize, type, sizeX, sizeY);

                _bitmap = _bitmapService.UpdateBitmap(_bitmap, _cellStateTable);
                pictureBox1.Image = _bitmap;
                pictureBox1.Show();
                pictureBox1.Update();
            }

            if (MicrostructureType.Text == "Subculture" || MicrostructureType.Text == "DualPhase")
            {
                _gainService.GetNotRemovableGrainId(e, _cellStateTable, NotRemovableIds);
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

        private void label10_Click(object sender, EventArgs e)
        {

        }

        #region Input Output Opertions      
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
                            _textImportSizeX = Convert.ToInt32(lineArray[0]);
                            _textImportSizeY = Convert.ToInt32(lineArray[1]);
                            _cellStateTable = _gainService.InitCellTable(Convert.ToInt32(lineArray[0]), Convert.ToInt32(lineArray[1]));
                            firstLine = false;
                            continue;
                        }

                        if (x == _textImportSizeX)
                        {
                            x = 0;
                            y++;
                        }

                        if (x < _textImportSizeX && y < _textImportSizeY)
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

                    _bitmap = _bitmapService.InitBitmap(_textImportSizeX, _textImportSizeY, _cellStateTable);
                    _bitmap = _bitmapService.UpdateBitmap(_bitmap, _cellStateTable);
                    pictureBox1.Image = _bitmap;
                    pictureBox1.Show();
                    pictureBox1.Update();
                    _cellStateTable = _gainService.RemoveUpdateLockOnCells(_cellStateTable, _textImportSizeX, _textImportSizeY);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "jpg";
            saveDialog.Filter = "JPG images (*.jpg)|*.jpg";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = _bitmapService.InitBitmap(int.Parse(SizeX.Text), int.Parse(SizeY.Text), _cellStateTable);

                var fileName = saveDialog.FileName;
                bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void ImportJpg_Click(object sender, EventArgs e)
        {

            var openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";

            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;
            openFileDialog.ShowDialog();
            if (openFileDialog.CheckFileExists)
            {
                System.Drawing.Bitmap img = new System.Drawing.Bitmap(openFileDialog.FileName);
                _cellStateTable = _gainService.InitCellTable(img.Width, img.Height);
                SizeX.Text = img.Width.ToString();
                SizeY.Text = img.Height.ToString();
                for (int x = 0; x < img.Width; x++)
                {
                    for (int y = 0; y < img.Height; y++)
                    {
                        Color pixel = img.GetPixel(x, y);

                        _cellStateTable[x, y].Id = pixel.ToArgb();
                        _cellStateTable[x, y].CellColor = pixel;

                        if (_cellStateTable[x, y].CellColor == Color.White)
                        {
                            _cellStateTable[x, y].IsUpdated = false;
                        }
                    }
                }
                _bitmap = _bitmapService.InitBitmap(img.Width, img.Height, _cellStateTable);
                _bitmap = _bitmapService.UpdateBitmap(_bitmap, _cellStateTable);
                pictureBox1.Image = _bitmap;
                pictureBox1.Show();
                pictureBox1.Update();
                _cellStateTable = _gainService.RemoveUpdateLockOnCells(_cellStateTable, _textImportSizeX, _textImportSizeY);
            }
        }
        #endregion

        private void ForceCleanup_Click(object sender, EventArgs e)
        {
            var sizeX = int.Parse(SizeX.Text);
            var sizeY = int.Parse(SizeY.Text);
                for (int i = 0; i < sizeX; i++)
                {
                    for (int j = 0; j < sizeY; j++)
                    {
                        _cellStateTable[i, j].CellColor = Color.White;
                        _cellStateTable[i, j].Id = 0;
                        _cellStateTable[i, j].IsUpdated = false;
                        _cellStateTable[i, j].IsLockedForPropabilityPurpose = false;
                        _cellStateTable[i, j].IsLocked = false;
                        _cellStateTable[i, j].PositionX = 0;
                        _cellStateTable[i, j].PositionY = 0;
                    }
                }

                _bitmap = _bitmapService.UpdateBitmap(_bitmap, _cellStateTable);
                pictureBox1.Image = _bitmap;
                pictureBox1.Show();
                pictureBox1.Update();
            
        }
    }
}
