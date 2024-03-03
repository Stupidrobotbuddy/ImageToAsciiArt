using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Intrinsics.X86;

namespace ImageToAsciiArt
{
    internal class BitmapToAscii
    {
        
        int[,] Values;
        string[,] ConvertedValues;
        ImageToBitmap bittermap;

        public BitmapToAscii(ImageToBitmap bitmap)
        {
            bittermap = bitmap;
            Values = bittermap.GetBitmapGreyscaleColorArray(2);
            ConvertedValues = new string[Values.GetLength(0), Values.GetLength(1)]; 
            ConvertedValues = ConvertValues(Values);
        }

        public void run()
        {
            for (int x = 0; x < this.ConvertedValues.GetLength(0); x++)
            {
                for (int y = 0; y < this.ConvertedValues.GetLength(1); y++)
                {
                    Console.Write(ConvertedValues[x, y] + "");

                }
                Console.WriteLine();
            }
        }

        string[,] ConvertValues(int[,] values){

            for (int x = 0; x < values.GetLength(0); x++){

                for (int y = 0; y < values.GetLength(1); y++){

                    int temp = values[x, y];
                    int converter = temp % 10;

                    switch (converter)
                    {
                        case 0:
                            ConvertedValues[x, y] = ".";
                            break;
                        case 1:
                            ConvertedValues[x, y] = ":";
                            break;
                        case 2:
                            ConvertedValues[x, y] = "-";
                            break;
                        case 3:
                            ConvertedValues[x, y] = "(";
                            break;
                        case 4:
                            ConvertedValues[x, y] = "=";
                            break;
                        case 5:
                            ConvertedValues[x, y] = "{";
                            break;
                        case 6:
                            ConvertedValues[x, y] = "#";
                            break;
                        case 7:
                            ConvertedValues[x, y] = "$";
                            break;
                        case 8:
                            ConvertedValues[x, y] = "%";
                            break;
                        case 9:
                            ConvertedValues[x, y] = "@";
                            break;
                        default:
                            ConvertedValues[x, y] = "";
                            break;
                    }


                }
            }

            return ConvertedValues;
        }


    }
}
