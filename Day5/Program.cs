using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent_Day_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string polymer = "";
            string shortest = "";
            string[] lines = File.ReadAllLines(@"C:\Advent\Day5.txt");

            int cMaxReduce = 'A';
            int cLength = 500000;

            for (int a = 65; a < 90; a++)
            {

                polymer = lines[0];

                // Reduce (Part 2)
                for (int z = 0; z < 50000 && z < polymer.Length; z++)
                {
                    if (polymer[z] == a || polymer[z] == a + 32)
                    {
                        polymer = Reduce(polymer, z--);
                    }
                }

                // React (Part 1)
                for (int z = 0; z < 50000 && z < polymer.Length - 1; z++)
                {
                    //Two checks
                    //  1. Before Upper
                    //  2. After Upper
                    if (polymer[z] + 32 == polymer[z + 1] || polymer[z] == polymer[z + 1] + 32)
                    {
                        polymer = React(polymer, z);
                        z = z - 2;
                        if (z < -1) z = -1;
                    }
                }

                if (polymer.Length < cLength)
                {
                    cLength = polymer.Length;
                    shortest = polymer;
                    cMaxReduce = a;
                }
            }

            System.Console.WriteLine(shortest);
            System.Console.WriteLine("Total Units Remaining=" + cLength + "  Best Reduce=" + (char)cMaxReduce);

            return;
        }

        private static string React(string source, int pos)
        {
            string tmp;

            tmp = source.Substring(0, pos);
            tmp += source.Substring(pos+2);

            return tmp;
        }
        private static string Reduce(string source, int pos)
        {
            string tmp;

            tmp = source.Substring(0, pos);
            tmp += source.Substring(pos + 1);

            return tmp;
        }
    }
}
