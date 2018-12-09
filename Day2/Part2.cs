using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent_Day_2
{
    class Part2
    {
        
        static void Main(string[] args)
        {

            int diff = 0;

            string[] boxes = File.ReadAllLines(@"C:\Advent\Day2.txt");

            for (int x=0; x<boxes.Length - 1; x++)
            {
                string boxID1 = boxes[x];

                for (int y = x + 1; y < boxes.Length; y++)
                {

                    string boxID2 = boxes[y];
                    diff = 0;

                    for (int z = 0; z < boxID1.Length && diff < 2; z++)
                    {
                        if (boxID1[z] != boxID2[z])
                            diff++;
                    }

                    if (diff == 1)
                    {
                        System.Console.Write("Matching Box = ");
                        for (int a=0; a<boxID1.Length; a++)
                        {
                            if (boxID1[a] == boxID2[a])
                            {
                                System.Console.Write(boxID1[a]);
                            }
                        }
                        System.Console.WriteLine("");
                        System.Console.WriteLine("Done");
                    }
                }
            }

            return;
        }
    }
}
