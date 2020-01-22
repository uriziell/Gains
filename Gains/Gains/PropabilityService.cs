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
        public Cell[,] AddNeighbor(int positionX, int positionY, Cell[,] cells, int maxRangeX, int maxRangeY,
            int probability, int microstructureId)
        {
            if (cells[positionX, positionY].IsUpdated || cells[positionX,positionY].CellColor == Color.Black ) return cells;
            if (_neighborhoodService.GetMooreNeighbors(cells, positionX, positionY, maxRangeX, maxRangeY).Count >= 5)
            {
                var cell = _neighborhoodService.GetMooreNeighbors(cells, positionX, positionY, maxRangeX, maxRangeY).GroupBy(x => x.CellColor).First().ToList()[0];
                var color = cell.CellColor;
                var id = cell.Id;
                if (cells[positionX, positionY].CellColor == Color.Black || microstructureId != 0 && cells[positionX,positionY].Id == microstructureId) return cells;
                cells[positionX, positionY].Id = id;
                cells[positionX, positionY].CellColor = color;
                cells[positionX, positionY].IsUpdated = true;
                cells[positionX, positionY].IsLockedForPropabilityPurpose = true;
            }
            else if (_neighborhoodService.GetVonNeumanNeighbors(cells, positionX, positionY, maxRangeX, maxRangeY).Count >= 3)
            {
                if (cells[positionX, positionY].CellColor == Color.Black || microstructureId != 0 && cells[positionX, positionY].Id == microstructureId) return cells;
                var cell = _neighborhoodService.GetVonNeumanNeighbors(cells, positionX, positionY, maxRangeX, maxRangeY).GroupBy(x => x.CellColor).First().ToList()[0];
                var color = cell.CellColor;
                var id = cell.Id;
                cells[positionX, positionY].Id = id;
                cells[positionX, positionY].CellColor = color;
                cells[positionX, positionY].IsUpdated = true;
                cells[positionX, positionY].IsLockedForPropabilityPurpose = true;
            }
            else if (_neighborhoodService.GetFutherMooreNeighbors(cells, positionX, positionY, maxRangeX, maxRangeY).Count >= 3)
            {
                if (cells[positionX, positionY].CellColor == Color.Black || microstructureId != 0 && cells[positionX, positionY].Id == microstructureId) return cells;
                var cell = _neighborhoodService.GetFutherMooreNeighbors(cells, positionX, positionY, maxRangeX, maxRangeY).GroupBy(x => x.CellColor).First().ToList()[0];
                var color = cell.CellColor;
                var id = cell.Id;
                cells[positionX, positionY].Id = id;
                cells[positionX, positionY].CellColor = color;
                cells[positionX, positionY].IsUpdated = true;
                cells[positionX, positionY].IsLockedForPropabilityPurpose = true;
            }
            else
            {
                if (cells[positionX, positionY].CellColor == Color.Black || microstructureId != 0 && cells[positionX, positionY].Id == microstructureId || cells[positionX, positionY].IsUpdated) return cells;
                var result = 0;
                lock (SyncLock)
                {
                    result = _random.Next(100);
                }

                int test = 0;
                Cell cell;
                var neighbors = _neighborhoodService.GetMooreNeighbors(cells, positionX, positionY, maxRangeX, maxRangeY);
                if (neighbors.Count > 0)
                {
                    cell = neighbors.GroupBy(x => x.CellColor).First().ToList()[0];

                    if (result >= probability)
                        return cells;
                    cells[positionX, positionY].CellColor = cell.CellColor;
                    cells[positionX, positionY].IsUpdated = true;
                    cells[positionX, positionY].IsLockedForPropabilityPurpose = true;
                    cells[positionX, positionY].Id = cell.Id;
                }
            }

            return cells;
        }

    }
}
