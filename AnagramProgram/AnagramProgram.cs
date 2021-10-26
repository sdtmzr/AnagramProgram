#define PERFORMANCE_TEST

using System;
using AnagramProgram.Resourses;
using AnagramLibrary;
using System.Diagnostics;

namespace Program
{
    class AnagramProgram
    {
        static void Main()
        {
            IAnagram anagram = new Anagram();
#if PERFORMANCE_TEST
            Stopwatch stopWatch = new Stopwatch();
            int numberOfCycles = 100000;
            stopWatch.Start();
            for (int i = 0; i < numberOfCycles; i++)
            {
                anagram.CreateAnagram(PerfomanceTest.loremIpsumText);
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            string averageTime = String.Format("{0:0.0000}", ts.TotalMilliseconds / numberOfCycles);
            Console.WriteLine("RunTime {0}", elapsedTime);
            Console.WriteLine("AverageTime {0}ms", averageTime);
            return;
#endif
            Console.WriteLine(Messages.welcomeMessage, Messages.programName, Messages.developer, Messages.developmentDate,
                Messages.developmentLanguage, Messages.actionToStart);
            string result = anagram.CreateAnagram(Console.ReadLine());
            Console.WriteLine(Messages.resultMessage, result);
            Console.ReadLine();
        }
    }
}