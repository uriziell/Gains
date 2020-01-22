using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gains
{
    public class GainService
    {
        private readonly ColorService _colorService;
        private readonly BitmapService _bitmapService;
        private readonly Random _random;
        private readonly object _syncLock;

        public GainService()
        {
            _colorService = new ColorService();
            _bitmapService = new BitmapService();
            _random = new Random();
            _syncLock = new object();
        }
        public List<Cell> CreateGain(int numberOfGains)
        {
            var gains = new List<Cell>();
            for (var i = 0; i < numberOfGains; i++)
            {
                var id = 0;
                lock (_syncLock)
                {
                    id = _random.Next();
                }
                gains.Add(new Cell
                {
                    CellColor = _colorService.GetRandomColor(),
                    Id = id
                });
            }

            return gains;
        }
        public Bitmap SetGainToBitmap(Bitmap bitmap, List<Cell> gains, ref Cell[,] tabCells)
        {
            var r = new Random();
            int randomX;
            int randomY;
            foreach (var gain in gains)
            {
                while (true)
                {                              
                     randomX = r.Next(bitmap.Size.Width);
                     randomY = r.Next(bitmap.Size.Height);
                    if(tabCells[randomX,randomY].CellColor == Color.White )
                        break;
                }

                bitmap.SetPixel(randomX, randomY, gain.CellColor);
                tabCells[randomX, randomY].CellColor = gain.CellColor;
                tabCells[randomX, randomY].IsUpdated = true;
                tabCells[randomX, randomY].IsLockedForPropabilityPurpose = false;
                tabCells[randomX, randomY].Id = gain.Id;
            }
            return bitmap;
        }

        public Cell[,] InitCellTable(int sizeX, int sizeY)
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

        public Cell[,] RemoveUpdateLockOnCells(Cell[,] cells, int x, int y)
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
        public Cell[,] RemoveUpdateLockOnCellsPropability(Cell[,] cells, int x, int y)
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
        public List<Cell> GetBoundaries(EventArgs e, int sizeX, int sizeY, Cell[,] _cellStateTable)
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
        public void GetNotRemovableGrainId(EventArgs e, Cell[,] _cellStateTable, List<int> NotRemovableIds)
        {
            var mouseEventArgs = e as MouseEventArgs;
            var x = mouseEventArgs.X;
            var y = mouseEventArgs.Y;
            NotRemovableIds.Add(_cellStateTable[x, y].Id);
        }

        public void SetLockOnGrains(int sizeX, int sizeY, Cell[,] _cellStateTable, List<int> NotRemovableIds, string MicrostructureType, Bitmap _bitmap, PictureBox pictureBox1)
        {
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (NotRemovableIds.Contains(_cellStateTable[i, j].Id))
                    {
                        _cellStateTable[i, j].IsLocked = true;
                        if (MicrostructureType == "DualPhase")
                        {
                            _cellStateTable[i, j].CellColor = Color.DeepPink;
                        }
                    }
                }
            }
            _bitmap = _bitmapService.UpdateBitmap(_bitmap, _cellStateTable);
            pictureBox1.Image = _bitmap;
            pictureBox1.Show();
            pictureBox1.Update();
        }
    }
}
