using System.Collections.Generic;
using System.Linq;

namespace Gains
{
    public class NeighborhoodService
    {
        public List<Cell> GetVonNeumanNeighbors(Cell[,] currentCells, int positionX, int positionY, int maxX, int maxY)
        {
            var neighbors = new List<Cell>();
            if (positionX - 1 > 0)
            {
                if (currentCells[positionX - 1, positionY].IsUpdated && !currentCells[positionX - 1, positionY].IsLocked)
                    neighbors.Add(currentCells[positionX - 1, positionY]);
            }
            else if (positionX + 1 < maxX - 1)
            {
                if (currentCells[positionX + 1, positionY].IsUpdated && !currentCells[positionX + 1, positionY].IsLocked)
                    neighbors.Add(currentCells[positionX + 1, positionY]);
            }
            if (positionY - 1 > 0)
            {
                if (currentCells[positionX, positionY - 1].IsUpdated && !currentCells[positionX, positionY - 1].IsLocked)
                    neighbors.Add(currentCells[positionX, positionY - 1]);
            }
            if (positionY + 1 < maxY - 1)
            {
                if (currentCells[positionX, positionY + 1].IsUpdated && !currentCells[positionX, positionY + 1].IsLocked)
                    neighbors.Add(currentCells[positionX, positionY + 1]);
            }

            return neighbors.Count > 0 ? neighbors.GroupBy(x => x.CellColor).First().ToList() : neighbors;
        }

        public List<Cell> GetMooreNeighbors(Cell[,] currentCells, int positionX, int positionY, int maxX, int maxY)
        {
            var neighbors = new List<Cell>();

            if (positionX - 1 >= 0)
            {
                if (currentCells[positionX - 1, positionY].IsUpdated && !currentCells[positionX - 1, positionY].IsLocked)
                    neighbors.Add(currentCells[positionX - 1, positionY]);
            }
            if (positionX + 1 <= maxX - 1)
            {
                if (currentCells[positionX + 1, positionY].IsUpdated && !currentCells[positionX + 1, positionY].IsLocked)
                    neighbors.Add(currentCells[positionX + 1, positionY]);
            }
            if (positionY - 1 > 0)
            {
                if (currentCells[positionX, positionY - 1].IsUpdated && !currentCells[positionX, positionY - 1].IsLocked)
                    neighbors.Add(currentCells[positionX, positionY - 1]);
            }
            if (positionY + 1 < maxY - 1)
            {
                if (currentCells[positionX, positionY + 1].IsUpdated && !currentCells[positionX, positionY + 1].IsLocked)
                    neighbors.Add(currentCells[positionX, positionY + 1]);
            }
            if (positionY + 1 < maxY - 1 && positionX + 1 < maxX - 1)
            {
                if (currentCells[positionX + 1, positionY + 1].IsUpdated && !currentCells[positionX + 1, positionY + 1].IsLocked)
                    neighbors.Add(currentCells[positionX + 1, positionY + 1]);
            }
            if (positionY - 1 > 0 && positionX - 1 > 0)
            {
                if (currentCells[positionX - 1, positionY - 1].IsUpdated && !currentCells[positionX - 1, positionY - 1].IsLocked)
                    neighbors.Add(currentCells[positionX - 1, positionY - 1]);
            }
            if (positionY + 1 < maxY && positionX - 1 > 0)
            {
                if (currentCells[positionX - 1, positionY + 1].IsUpdated && !currentCells[positionX - 1, positionY + 1].IsLocked)
                    neighbors.Add(currentCells[positionX - 1, positionY + 1]);
            }
            if (positionY - 1 > 0 && positionX + 1 < maxX)
            {
                if (currentCells[positionX + 1, positionY - 1].IsUpdated && !currentCells[positionX + 1, positionY - 1].IsLocked)
                    neighbors.Add(currentCells[positionX + 1, positionY - 1]);
            }

            var test = 0;
            if (neighbors.Count > 0)
                test = neighbors.Count;

            return neighbors.Count > 0 ? neighbors.GroupBy(x => x.CellColor).First().ToList() : neighbors;
        }

        public List<Cell> GetFutherMooreNeighbors(Cell[,] currentCells, int positionX, int positionY, int maxX, int maxY)
        {
            var neighbors = new List<Cell>();

            if (positionY + 1 < maxY - 1 && positionX + 1 < maxX - 1)
            {
                if (currentCells[positionX + 1, positionY + 1].IsUpdated && !currentCells[positionX + 1, positionY + 1].IsLocked)
                    neighbors.Add(currentCells[positionX + 1, positionY + 1]);
            }
            if (positionY - 1 > 0 && positionX - 1 > 0)
            {
                if (currentCells[positionX - 1, positionY - 1].IsUpdated && !currentCells[positionX - 1, positionY - 1].IsLocked)
                    neighbors.Add(currentCells[positionX - 1, positionY - 1]);
            }
            if (positionY + 1 < maxY && positionX - 1 > 0)
            {
                if (currentCells[positionX - 1, positionY + 1].IsUpdated && !currentCells[positionX - 1, positionY + 1].IsLocked)
                    neighbors.Add(currentCells[positionX - 1, positionY + 1]);
            }
            if (positionY - 1 > 0 && positionX + 1 < maxX)
            {
                if (currentCells[positionX + 1, positionY - 1].IsUpdated && !currentCells[positionX + 1, positionY - 1].IsLocked)
                    neighbors.Add(currentCells[positionX + 1, positionY - 1]);
            }

            return neighbors.Count > 0 ? neighbors.GroupBy(x => x.CellColor).First().ToList() : neighbors;
        }

    }
}