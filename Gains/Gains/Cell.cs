using System.Drawing;

namespace Gains
{
    public class Cell
    {
        public Color CellColor { get; set; }
        public bool IsUpdated { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        //public Cell()
        //{
        //    CellColor = Color.Black;
        //}
    }
}