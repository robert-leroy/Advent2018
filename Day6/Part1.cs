using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent_Day_6
{
    class Part1
    {
        const int arraysize = 500;

        static void Main(string[] args)
        {

            int[,] grid = new int[arraysize, arraysize];
            string[] lines = File.ReadAllLines(@"C:\Advent\Day6.txt");

            // Map the input coords
            for (int z = 0; z < lines.Length; z++)
            {
                string[] coord = lines[z].Split(',');
                int y = Convert.ToInt16(coord[0]);
                int x = Convert.ToInt16(coord[1]);
                grid[x,y] = z+1;
            }

            PrintArray(grid);

            // Now go through and apply the manhattan formulas to all coords
            //for (int a = 0; a < lines.Length; a++)
            //{
            //    for (int b = 0; b < lines.Length; b++)
            //    {
            //        string[] coord = lines[a].Split(',');
            //        int p1 = Convert.ToInt16(coord[0]);
            //        int q1 = Convert.ToInt16(coord[1]);
            //        coord = lines[b].Split(',');
            //        int p2 = Convert.ToInt16(coord[0]);
            //        int q2 = Convert.ToInt16(coord[1]);

            //        int p = Math.Abs(p1 - p2);
            //        int q = Math.Abs(q1 - q2);

            //        int y = 0;
            //        do {
            //            for (int x = 0; x < q; x++)
            //            {
            //                if (grid[x, y] == 0)
            //                    grid[x, y] = a+1;
            //                else
            //                    grid[x, y] = 9;
            //            }
            //        } while (y++ < p);  
            //    }
            //}

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
                        Manhattan[a] = distance;
                    }

                    // Find nearest item
                    int nMaxDist = arraysize;
                    int nItem = 0;
                    for (int a = 0; a < lines.Length; a++)
                    {
                        if (Manhattan[a] == nMaxDist)
                        {
                            nItem = 0;
                        }
                        if (Manhattan[a] < nMaxDist)
                        {
                            nMaxDist = Manhattan[a];
                            nItem = a + 1;
                        }
                    }

                    grid[x, y] = nItem;
                }
            }

            PrintArray(grid);

            // now calculate the max 
            int[] nCountLines = new int[arraysize];

            for (int y = 0; y < arraysize; y++)
            {
                for (int x = 0; x < arraysize; x++)
                {
                    if (grid[x, y] > 0)
                        nCountLines[grid[x, y]]++;
                }
            }

            //Kill the "infinite" items
            for (int x=0; x < arraysize; x++)
            {
                nCountLines[grid[x,0]] = 0;
                nCountLines[grid[x, arraysize-1]] = 0;
                nCountLines[grid[0, x]] = 0;
                nCountLines[grid[arraysize-1, x]] = 0;

            }
            System.Console.WriteLine("MaxSize=" + nCountLines.Max());
            return;
        }

        static void PrintArray(int[,] grid)
        {
            return;
            for (int a = 0; a < arraysize; a++)
            {
                for (int b = 0; b < arraysize; b++)
                {
                    System.Console.Write(grid[a, b]);
                }
                System.Console.WriteLine("");
            }

            System.Console.WriteLine("");
            System.Console.WriteLine("");

        }
    }
}
