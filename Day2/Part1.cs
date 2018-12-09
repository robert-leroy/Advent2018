using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent_Day_2
{
    class Part1
    {
        public static int nCurrentLetter;

        static void Main(string[] args)
        {

            int twos = 0;
            int threes = 0;

            List<char> ListUsedLetters = new List<char>();

            string[] lines = File.ReadAllLines(@"C:\Advent\Day2.txt");

            foreach (string boxID in lines)
            {
                int[] counts = new int[boxID.Length];
                for (int x = 0; x < boxID.Length; x++)
                {
                    counts[x] = 1;
                    nCurrentLetter = boxID[x];

                    if (ListUsedLetters.Find(FindLetter) == 0)
                    {
                        ListUsedLetters.Add(boxID[x]);
                        for (int y = x + 1; y < boxID.Length; y++)
                        {
                            if (boxID[x] == boxID[y])
                                counts[x]++;
                        }
                    }
                }

                for (int z = 0; z < counts.Length; z++)
                {
                    if (counts[z] == 2)
                    {
                        twos++;
                        break;
                    }
                }

                for (int z = 0; z < counts.Length; z++)
                {
                    if (counts[z] == 3)
                    {
                        threes++;
                        break;
                    }
                }

                ListUsedLetters.Clear();
            }

            System.Console.WriteLine("CheckSum of " + twos.ToString() + " * " + threes.ToString() + " " + (twos * threes).ToString());
            return;
        }

        private static bool FindLetter(char n)
        {
            return n == nCurrentLetter;
        }
    }
}
