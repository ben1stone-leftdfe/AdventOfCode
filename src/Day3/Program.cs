using Helpers;
using System;
using System.Linq;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var readings = FileReader.ReadStringsFromTextFile("../../../Data/input.txt").ToList();
            
            //Part one

            var analyser = new DiagnosticsAnalyser(readings);

            var powerConsumptionResult = analyser.GetPowerConsumption();

            Console.WriteLine($"Result: { powerConsumptionResult }");

            // Part two

            var partTwoAnalyser = new DiagnosticsAnalyserPart2(readings);

            var lifesupportResult = partTwoAnalyser.LifeSupportResult();

            Console.WriteLine($"Result: {lifesupportResult}");
        }
    }
}
