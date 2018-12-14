using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent_Day_3
{
    class Program
    {
        static int Main(string[] args)
        {

            int[,] fabric = new int[1001,1001];
            for (int x = 0; x < 1000; x++)
                for (int y = 0; y < 1000; y++)
                    fabric[x, y] = 0;

            string[] claims = File.ReadAllLines(@"C:\Advent\Day3.txt");

            for (int z = 0; z < claims.Length; z++)
            {

                string[] pieces = claims[z].Split(' ');
                string[] start = pieces[2].Split(',');
                string[] count = pieces[3].Split('x');

                for (int x = Convert.ToInt16(start[0]); x < Convert.ToInt16(start[0]) + Convert.ToInt16(count[0]); x++)
                {
                    int Ystart = Convert.ToInt16(start[1].Substring(0, start[1].Length - 1));
                    int Ystop = Convert.ToInt16(count[1]);
                    int Ymax = Ystart + Ystop;
                    for (int y = Ystart; y < Ymax; y++)
                        fabric[x, y]++;
                }
            }

            int squares = 0;
            for (int x = 0; x < 1001; x++)
                for (int y = 0; y < 1001; y++)
                    if (fabric[x, y] > 1)
                        squares++;

            System.Console.WriteLine("Overlap " + squares.ToString());

            int OnlyOne = 0;

            for (int z = 0; z < claims.Length; z++)
            {
                OnlyOne = 0;
                string[] pieces = claims[z].Split(' ');
                string[] start = pieces[2].Split(',');
                string[] count = pieces[3].Split('x');

                for (int x = Convert.ToInt16(start[0]); x < Convert.ToInt16(start[0]) + Convert.ToInt16(count[0]) && OnlyOne == 0; x++)
                {
                    int Ystart = Convert.ToInt16(start[1].Substring(0, start[1].Length - 1));
                    int Ystop = Convert.ToInt16(count[1]);
                    int Ymax = Ystart + Ystop;
                    for (int y = Ystart; y < Ymax && OnlyOne == 0; y++)
                    {
                        if (fabric[x, y] > 1)
                        {
                            OnlyOne = 1;
                        }
                    }
                }

                if (OnlyOne == 0)
                {
                    System.Console.WriteLine("OnlyOne " + pieces[z]);
                }
            }

            //int squares = 0;
            //for (int x = 0; x < 1001; x++)
            //   for (int y = 0; y < 1001; y++)
            //       if (fabric[x, y] > 1)
            //           squares++;

            //System.Console.WriteLine("Overlap " + squares.ToString());

            return 0;
        }
    }
}
