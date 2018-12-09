using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Advent_Day_1___Part_2
{
    class Program
    {
        static int nCurrentFrequency = 0;
        static void Main(string[] args)
        {
            int nChange = 0;
            List<int> nAllFrequencies = new List<int>();
            int x = 0;

            while (true)
            {
                string[] lines = File.ReadAllLines(@"C:\Advent\Day1.txt");
                foreach (string line in lines)
                {
                    nChange = Convert.ToInt32(line);
                    nCurrentFrequency += nChange;

                    if (nAllFrequencies.Find(FindFrequency) > 0)
                    {
                        System.Console.WriteLine("Found Duplicate at " + nCurrentFrequency.ToString());
                        System.Console.WriteLine("Loop number " + x.ToString());
                        return;
                    }
                    nAllFrequencies.Add(nCurrentFrequency);
                }
                x++;
            }
        }

        private static bool FindFrequency(int n)
        {
            return n == nCurrentFrequency;
        }
    }
}
