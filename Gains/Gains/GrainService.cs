using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Gains
{
    public class GrainService
    {
        private readonly ColorService _colorService;
        private readonly BitmapService _bitmapService;
        private readonly Random _random;
        private readonly object _syncLock;

        public GrainService()
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
            foreach (var gain in gains)
            {
                int randomX;
                int randomY;
                while (true)
                {
                    randomX = r.Next(bitmap.Size.Width);
                    randomY = r.Next(bitmap.Size.Height);
                    if (tabCells[randomX, randomY].CellColor == Color.White)
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
                    cells[i, j].IsLockedForPropabilityPurpose = false;
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
        public List<Cell> GetBoundaries(EventArgs e, int sizeX, int sizeY, Cell[,] cellStateTable)
        {
            var mouseEventArgs = e as MouseEventArgs;
            var x = mouseEventArgs.X;
            var y = mouseEventArgs.Y;
            var id = cellStateTable[x, y].Id;
            var boundaries = new List<Cell>();
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (i - 1 < 0 || i >= sizeX - 1 || j - 1 < 0 || j + 1 >= sizeY) continue;
                    if (cellStateTable[i, j].Id == id && id != cellStateTable[i + 1, j].Id ||
                        cellStateTable[i, j].Id == id && id != cellStateTable[i - 1, j].Id ||
                        cellStateTable[i, j].Id == id && id != cellStateTable[i, j + 1].Id ||
                        cellStateTable[i, j].Id == id && id != cellStateTable[i, j - 1].Id)
                    {
                        cellStateTable[i, j].PositionX = i;
                        cellStateTable[i, j].PositionY = j;
                        boundaries.Add(cellStateTable[i, j]);
                    }
                }
            }
            return boundaries;
        }
        public void GetNotRemovableGrainId(EventArgs e, Cell[,] cellStateTable, List<int> notRemovableIds)
        {
            var mouseEventArgs = e as MouseEventArgs;
            if (mouseEventArgs == null) return;
            var x = mouseEventArgs.X;
            var y = mouseEventArgs.Y;
            notRemovableIds.Add(cellStateTable[x, y].Id);
        }

        public void SetLockOnGrains(int sizeX, int sizeY, Cell[,] cellStateTable, List<int> notRemovableIds, string microstructureType, Bitmap bitmap, PictureBox pictureBox1)
        {
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (notRemovableIds.Contains(cellStateTable[i, j].Id))
                    {
                        cellStateTable[i, j].IsLocked = true;
                        if (microstructureType == "DualPhase")
                        {
                            cellStateTable[i, j].CellColor = Color.DeepPink;
                        }
                    }
                }
            }
            bitmap = _bitmapService.UpdateBitmap(bitmap, cellStateTable);
            pictureBox1.Image = bitmap;
            pictureBox1.Show();
            pictureBox1.Update();
        }
    }
}
