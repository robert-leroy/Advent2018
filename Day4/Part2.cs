using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent_Day_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Guard, Minutes in the Hour
            int[,] arrHoursSlept = new int[100, 60];
            int[,] arrGuardID = new int[100,2];
            DateTime dtSleepStart = DateTime.Now;
            DateTime dtSleepStop = DateTime.Now;
            TimeSpan tsSleepHours = new TimeSpan();
            int nCurrentGuard = 0;
            int nGuardCount = 0;

            string[] claims = File.ReadAllLines(@"C:\Advent\Day4.txt");

            for (int z = 0; z < claims.Length; z++)
            {
                string[] claimParts = claims[z].Split(',');

                DateTime dtEvent = Convert.ToDateTime(claimParts[5]);
                int nGuard = Convert.ToInt16(claimParts[4]);

                // First Time
                if (nCurrentGuard == 0)
                    nCurrentGuard = nGuard;

                if (nCurrentGuard != nGuard)
                {

                    int sleepMinutes = (int)tsSleepHours.TotalMinutes;

                    System.Console.WriteLine("Guard=" + nCurrentGuard.ToString() + "  " + "Total Sleep=" + sleepMinutes.ToString());

                    arrGuardID[nGuardCount,0] = nCurrentGuard;
                    arrGuardID[nGuardCount, 1] = sleepMinutes;
                    nCurrentGuard = nGuard;
                    nGuardCount++;
                    tsSleepHours = TimeSpan.Zero;
                }

                if (claimParts[3].Contains("Guard"))
                {
                    //No Op
                }
                else
                {
                    if (claimParts[3].Contains("falls"))
                        dtSleepStart = dtEvent;
                    else
                    {
                        dtSleepStop = dtEvent;
                        tsSleepHours += dtSleepStop - dtSleepStart;

                        int nStartMin = dtSleepStart.Minute;
                        int nStopMin = dtSleepStop.Minute;

                        for (int x = nStartMin; x < nStopMin; x++)
                        {
                            arrHoursSlept[nGuardCount, x]++;
                        }
                    }
                }
            }

            int nMaxGuardID = 0;
            int nMaxGuardHours = 0;
            int nMaxMinute = 0;
            int nMaxMinuteHour = 0;

            for (int z=0; z < nGuardCount; z++)
            {
                for (int a = 0; a < 60; a++)
                {
                    if (arrHoursSlept[z,a] > nMaxMinute)
                    {
                        nMaxMinute = arrHoursSlept[z, a];
                        nMaxMinuteHour = a;
                        nMaxGuardID = arrGuardID[z, 0];
                        System.Console.WriteLine("New Max Guard=" + nMaxGuardID.ToString() + "  MaxMinute=" + nMaxMinute.ToString() + "  MaxMinuteHours=" + nMaxMinuteHour.ToString());
                    }
                }
            }

            System.Console.WriteLine("Answer is " + (nMaxGuardID * nMaxMinuteHour).ToString());
        }
    }
}
