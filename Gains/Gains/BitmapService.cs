using System.Drawing;

namespace Gains
{
    public class BitmapService
    {
        public Bitmap InitBitmap(int sizeX, int sizeY, Cell[,] cellArray)
        {
            var bitmap = new Bitmap(sizeX, sizeY);

            for (var i = 1; i < bitmap.Height - 1; i++)
            {
                for (var j = 1; j < bitmap.Width - 1; j++)
                {
                    bitmap.SetPixel(j, i, cellArray[j, i].CellColor);
                }
            }

            return bitmap;
        }

        public Bitmap UpdateBitmap(Bitmap bitmap, Cell[,] cellArray)
        {
            for (var i = 0; i < bitmap.Height; i++)
            {
                for (var j = 0; j < bitmap.Width; j++)
                {
                    bitmap.SetPixel(j, i, cellArray[j, i].CellColor);
                }
            }
            return bitmap;
        }
    }
}