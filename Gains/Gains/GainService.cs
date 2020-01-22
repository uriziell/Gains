using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gains
{
    public class GainService
    {
        private readonly ColorService _colorService;
        private readonly Random _random;
        private readonly object _syncLock;

        public GainService()
        {
            _colorService = new ColorService();
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
                var randomX = r.Next(bitmap.Size.Width);
                var randomY = r.Next(bitmap.Size.Height);
                bitmap.SetPixel(randomX, randomY, gain.CellColor);
                tabCells[randomX, randomY].CellColor = gain.CellColor;
                tabCells[randomX, randomY].IsUpdated = true;
                tabCells[randomX, randomY].IsLocked = false;
                tabCells[randomX, randomY].Id = gain.Id;
            }
            return bitmap;
        }
    }
}
