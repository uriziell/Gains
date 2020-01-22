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
            if (color == Color.White || cells[positionX, positionY].IsUpdated || color == Color.Black)
                return cells;
            if (positionX - 1 >= 0 && cells[positionX - 1, positionY] != null &&
                cells[positionX - 1, positionY].CellColor == Color.White && cells[positionX - 1, positionY].IsUpdated == false
                && cells[positionX - 1, positionY].CellColor != Color.Black)
            {
                cells[positionX - 1, positionY].CellColor = color;
                cells[positionX - 1, positionY].IsUpdated = true;
                cells[positionX - 1, positionY].Id = cells[positionX, positionY].Id;
            }

            if (positionX + 1 < maxRangeX && cells[positionX + 1, positionY] != null &&
                cells[positionX + 1, positionY].CellColor == Color.White && cells[positionX + 1, positionY].IsUpdated == false
                && cells[positionX + 1, positionY].CellColor != Color.Black)
            {
                cells[positionX + 1, positionY].CellColor = color;
                cells[positionX + 1, positionY].IsUpdated = true;
                cells[positionX + 1, positionY].Id = cells[positionX, positionY].Id;

            }

            if (positionY - 1 >= 0 && cells[positionX, positionY - 1] != null &&
                cells[positionX, positionY - 1].CellColor == Color.White && cells[positionX, positionY - 1].IsUpdated == false
                && cells[positionX, positionY - 1].CellColor != Color.Black)
            {
                cells[positionX, positionY - 1].CellColor = color;
                cells[positionX, positionY - 1].IsUpdated = true;
                cells[positionX, positionY - 1].Id = cells[positionX, positionY].Id;
            }

            if (positionY + 1 < maxRangeY && cells[positionX, positionY + 1] != null &&
                cells[positionX, positionY + 1].CellColor == Color.White && cells[positionX, positionY + 1].IsUpdated == false
                && cells[positionX, positionY + 1].CellColor != Color.Black)
            {
                cells[positionX, positionY + 1].CellColor = color;
                cells[positionX, positionY + 1].Id = cells[positionX, positionY].Id;
                cells[positionX, positionY + 1].IsUpdated = true;
            }

            return cells;
        }
    }
}
