using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent_Day_6
{
    class Program
    {
        const int arraysize = 500;

        static void Main(string[] args)
        {

            int[,] grid = new int[arraysize, arraysize];
            string[] lines = File.ReadAllLines(@"C:\Advent\Day6.txt");

            // Now go through and apply the manhattan formulas to all coords
            int[] Manhattan = new int[arraysize];
            for (int y=0; y < arraysize; y++)
            {
                for (int x=0; x < arraysize; x++)
                {
                    // Calc the distance to each item
                    for (int a = 0; a < lines.Length; a++)
                    {
                        string[] coord = lines[a].Split(',');
                        int p1 = Convert.ToInt16(coord[0]);
                        int q1 = Convert.ToInt16(coord[1]);

                        int p2 = y;
                        int q2 = x;

                        // Distance
                        int distance = Math.Abs(p1 - p2) + Math.Abs(q1 - q2);
                        grid[x,y] += distance;
                    }

                    if (grid[x,y] >= 10000)
                    {
                        grid[x, y] = 0;
                    }
                }
            }

            PrintArray(grid);

            // now count how many are within the range
            int nCountItems = 0;
            for (int y = 0; y < arraysize; y++)
            {
                for (int x = 0; x < arraysize; x++)
                {
                    if (grid[x, y] > 0)
                        nCountItems++;
                }
            }

            System.Console.WriteLine("MaxArea=" + nCountItems);
            return;
        }

        static void PrintArray(int[,] grid)
        {
            if (arraysize > 10)
                return;

            for (int a = 0; a < arraysize; a++)
            {
                for (int b = 0; b < arraysize; b++)
                {
                    System.Console.Write("| {0,3:N0}", grid[a, b]);
                }
                System.Console.WriteLine("");
            }

            System.Console.WriteLine("");
            System.Console.WriteLine("");

        }
    }
}
