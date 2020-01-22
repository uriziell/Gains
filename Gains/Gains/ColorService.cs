using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gains
{
    public class ColorService
    {
        private Random r = new Random();
        private static readonly object SyncLock = new object();

        public List<Cell> SetColorsToCells(List<Cell> cells)
        {
            foreach (var cell in cells)
            {
                cell.CellColor = GetRandomColor();
            }

            return cells;
        }

        public Color GetRandomColor()
        {
            lock (SyncLock)
            {
                return Colors(r.Next(9));
            }
        }

        public Color GetDefaultColor()
        {
            return Color.White;
        }

        public Color Colors(int val)
        {
            switch (val)
            {
                case 0: return Color.Red;
                case 1: return Color.Blue;
                case 2: return Color.Pink;
                case 3: return Color.Orange;
                case 4: return Color.Purple;
                case 5: return Color.Brown;
                case 6: return Color.DarkBlue;
                case 7: return Color.Coral;
                case 8: return Color.MediumPurple;
                case 9: return Color.Tomato;
                default: return Color.Red;
            }
        }

        public Color GetBlackColor()
        {
            return Color.Black;
        }
    }
}
