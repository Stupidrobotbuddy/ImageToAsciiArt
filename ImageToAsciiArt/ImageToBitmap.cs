using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;



namespace ImageToAsciiArt
{
    internal class ImageToBitmap
    {

        Bitmap _bitmap;
        private int width;
        private int height;
        int[,] ColorArray;
        

        public ImageToBitmap(string path)
        {
                _bitmap = new Bitmap(path);
                width = _bitmap.Width;
                height = _bitmap.Height;
                ColorArray = new int[width, height];
        }

        public int[,] GetBitmapGreyscaleColorArray(int chunksize)
        {
            int NumChunksX = width / chunksize;
            int NumChunksY = height / chunksize;
            

            for (int x = 0; x < NumChunksX; x++)
            {
                for (int y = 0; y < NumChunksY; y++)
                {
                    int startX = x * chunksize;
                    int startY = y * chunksize;
                    int endX = startX + chunksize;
                    int endY = startY + chunksize;

                    int total = 0;

                    for (int i = startX; i < endX; i++)
                    {
                        for (int j = startY; j < endY; j++)
                        {
                            Color _tint = _bitmap.GetPixel(i, j);

                            int value = (int)(0.299 * _tint.R + 0.587 * _tint.G + 0.114 * _tint.B);


                            total += value;
                        }
                    }
                    int averageTotal = (int)(total / Math.Pow(chunksize, 2));
                    ColorArray[x, y] = averageTotal;

                }
            }

            return ColorArray;
        }

    }
}
