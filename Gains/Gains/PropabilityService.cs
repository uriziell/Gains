using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gains
{
    public class PropabilityService
    {
        private readonly NeighborhoodService _neighborhoodService;
        private readonly Random _random;
        private readonly object SyncLock;

        public PropabilityService()
        {
            _neighborhoodService = new NeighborhoodService();
            _random = new Random();
            SyncLock = new object();
        }
        public Cell[,] AddNeighbor(int positionX, int positionY, Cell[,] cells, int maxRangeX, int maxRangeY, int probability = 90)
        {
            if (cells[positionX, positionY].IsUpdated) return cells;
            if (_neighborhoodService.GetMooreNeighbors(cells, positionX, positionY, maxRangeX, maxRangeY).Count >= 5)
            {
                var col = _neighborhoodService.GetMooreNeighbors(cells, positionX, positionY, maxRangeX, maxRangeY)[0]
                    .CellColor;
                cells[positionX, positionY].CellColor = col;
                cells[positionX, positionY].IsUpdated = true;
                cells[positionX, positionY].IsLocked = true;
            }
            else if (_neighborhoodService.GetVonNeumanNeighbors(cells, positionX, positionY, maxRangeX, maxRangeY).Count >= 3)
            {
                var col = _neighborhoodService.GetMooreNeighbors(cells, positionX, positionY, maxRangeX, maxRangeY)
                    .GroupBy(x => x.CellColor).First().Key;
                cells[positionX, positionY].CellColor = col;
                cells[positionX, positionY].IsUpdated = true;
                cells[positionX, positionY].IsLocked = true;
            }
            else if (_neighborhoodService.GetFutherMooreNeighbors(cells, positionX, positionY, maxRangeX, maxRangeY).Count >= 3)
            {
                var col = _neighborhoodService.GetMooreNeighbors(cells, positionX, positionY, maxRangeX, maxRangeY)
                    .GroupBy(x => x.CellColor).First().Key;
                cells[positionX, positionY].CellColor = col;
                cells[positionX, positionY].IsUpdated = true;
                cells[positionX, positionY].IsLocked = true;
            }
            else
            {
                var result = 0;
                lock (SyncLock)
                {
                    result = _random.Next(100);
                }

                int test = 0;
                Color col;
                var neighbors = _neighborhoodService.GetMooreNeighbors(cells, positionX, positionY, maxRangeX, maxRangeY);
                if (neighbors.Count > 0)
                {
                    col = neighbors.GroupBy(x => x.CellColor).First().Key;

                    if (result >= probability)
                        return cells;
                    cells[positionX, positionY].CellColor = col;
                    cells[positionX, positionY].IsUpdated = true;
                    cells[positionX, positionY].IsLocked = true;
                }
            }

            return cells;
        }

    }
}
