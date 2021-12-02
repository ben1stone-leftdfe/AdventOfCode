using Helpers;
using System;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringCommands = FileReader.ReadStringsFromTextFile("../../../Data/input.txt");

            var commandFactory = new CommandFactory();

            var commands = stringCommands.Select(c => commandFactory.CreateCommand(c)).ToList();

            // Part one

            var positionCalculator = new PositionCalculator();

            positionCalculator.AddCommands(commands);
            positionCalculator.ProcessCommands();

            var result = positionCalculator.Area;

            Console.WriteLine($"Result: {result}");

            // Part two

            positionCalculator = new PositionCalculator();

            var improvedCommands = stringCommands.Select(c => commandFactory.CreateImprovedCommand(c)).ToList();

            positionCalculator.AddCommands(improvedCommands);
            positionCalculator.ProcessCommands();

            var improveResult = positionCalculator.Area;

            Console.WriteLine($"Improved result: {improveResult}");
        }
    }
}
