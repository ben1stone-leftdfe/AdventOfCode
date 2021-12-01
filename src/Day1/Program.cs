using Helpers;
using System;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var report = FileReader.ReadIntegersFromTextFile("../../../Data/input.txt");

            var analyser = new SonarSweepAnalyser();

            var result = analyser.GetDepthIncreasingCount(report);

            Console.WriteLine($"Count: {result}");
        }
    }
}
