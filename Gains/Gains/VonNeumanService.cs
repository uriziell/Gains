using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gains
{
    public class VonNeumanService
    {
        public Cell[,] AddNeighbor(int positionX, int positionY, Color color, Cell[,] cells, int maxRangeX, int maxRangeY)
        {
            if (cells[positionX, positionY].IsUpdated || color == Color.Black || GetVonNeumanNeighbors(cells, positionX, positionY, maxRangeX, maxRangeY).Count == 0)
                return cells;

            var cell = GetVonNeumanNeighbors(cells, positionX, positionY, maxRangeX, maxRangeY).GroupBy(x => x.CellColor).First().ToList()[0];
            color = cell.CellColor;
            var id = cell.Id;
            cells[positionX, positionY].Id = id;
            cells[positionX, positionY].CellColor = color;
            cells[positionX, positionY].IsUpdated = true;
            cells[positionX, positionY].IsLockedForPropabilityPurpose = true;


            return cells;
        }

        public List<Cell> GetVonNeumanNeighbors(Cell[,] currentCells, int positionX, int positionY, int maxX, int maxY)
        {
            var neighbors = new List<Cell>();
            if (positionX - 1 > 0)
            {
                if (currentCells[positionX - 1, positionY].IsUpdated && !currentCells[positionX - 1, positionY].IsLockedForPropabilityPurpose)
                    neighbors.Add(currentCells[positionX - 1, positionY]);
            }
            if (positionX + 1 < maxX)
            {
                if (currentCells[positionX + 1, positionY].IsUpdated && !currentCells[positionX + 1, positionY].IsLockedForPropabilityPurpose)
                    neighbors.Add(currentCells[positionX + 1, positionY]);
            }
            if (positionY - 1 > 0)
            {
                if (currentCells[positionX, positionY - 1].IsUpdated && !currentCells[positionX, positionY - 1].IsLockedForPropabilityPurpose)
                    neighbors.Add(currentCells[positionX, positionY - 1]);
            }
            if (positionY + 1 < maxY)
            {
                if (currentCells[positionX, positionY + 1].IsUpdated && !currentCells[positionX, positionY + 1].IsLockedForPropabilityPurpose)
                    neighbors.Add(currentCells[positionX, positionY + 1]);
            }

            return neighbors.Count > 0 ? neighbors.GroupBy(x => x.CellColor).First().ToList() : neighbors;
        }
    }
}
