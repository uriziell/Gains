using System;
using System.Collections.Generic;
using System.Drawing;

namespace Gains
{
    public class InclusionService
    {
        private readonly ColorService _colorService;
        private readonly Random _random;
        private object SyncLock;

        public InclusionService()
        {
            _colorService = new ColorService();
            _random = new Random();
            SyncLock = new object();
        }

        public Cell[,] AddInclusions(Cell[,] cellStateTable, int inclusionSize, string type, int sizeX, int sizeY)
        {
            var gains = new List<Cell>();

            int x, y = 0;

            lock (SyncLock)
            {
                x = _random.Next(inclusionSize, sizeX - inclusionSize);
                y = _random.Next(inclusionSize, sizeY - inclusionSize);
            }

            if (type == "Square")
                for (int j = 0; j < inclusionSize - 1; j++)
                {
                    for (int k = 0; k < inclusionSize - 1; k++)
                    {
                        cellStateTable[x + j, y + k].CellColor = Color.Black;
                        cellStateTable[x + j, y + j].IsUpdated = false;
                    }
                }
            else if (type == "Circle")
                for (int k = 1; k < sizeX - 1; k++)
                {
                    for (int j = 1; j < sizeY - 1; j++)
                    {
                        var d = Math.Sqrt(Math.Pow(k - x, 2) + Math.Pow(j - y, 2));
                        if (!(d <= inclusionSize)) continue;
                        cellStateTable[k, j].CellColor = Color.Black;
                        cellStateTable[k, j].IsUpdated = false;
                    }
                }

            return cellStateTable;
        }

        public List<Cell> GetInclusionsAfterSimulation(Cell[,] cellStateTable, int sizeX, int sizeY, int inclusionsAmount = 0)
        {
            var allInclusions = new List<Cell>();
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (i + 1 < sizeX && cellStateTable[i, j].CellColor != cellStateTable[i + 1, j].CellColor)
                    {
                        cellStateTable[i, j].PositionX = i;
                        cellStateTable[i, j].PositionY = j;
                        allInclusions.Add(cellStateTable[i, j]);
                    }
                }
            }

            if (inclusionsAmount == 0)
                return allInclusions;

            var inclusions = new List<Cell>();
            for (int i = 0; i < inclusionsAmount; i++)
            {
                lock (SyncLock)
                {
                    var index = _random.Next(allInclusions.Count);
                    allInclusions[index].CellColor = Color.Black;
                    inclusions.Add(allInclusions[index]);
                }
            }

            return inclusions;
        }

        public Cell[,] AddInclusions(Cell[,] cellStateTable, List<Cell> inclusions, int inclusionSize, string type, int sizeX, int sizeY)
        {
            foreach (var inclusion in inclusions)
            {
                var x = inclusion.PositionX;
                var y = inclusion.PositionY;

                if (type == "Square")
                    for (int j = 0; j < inclusionSize - 1; j++)
                    {
                        for (int k = 0; k < inclusionSize - 1; k++)
                        {
                            cellStateTable[x + j, y + k].CellColor = Color.Black;
                            cellStateTable[x + j, y + j].IsUpdated = false;
                        }
                    }
                else if (type == "Circle")
                    for (int k = 1; k < sizeX - 1; k++)
                    {
                        for (int j = 1; j < sizeY - 1; j++)
                        {
                            var d = Math.Sqrt(Math.Pow(k - x, 2) + Math.Pow(j - y, 2));
                            if (!(d <= inclusionSize)) continue;
                            cellStateTable[k, j].CellColor = Color.Black;
                            cellStateTable[k, j].IsUpdated = false;
                        }
                    }
            }

            return cellStateTable;
        }
    }
}