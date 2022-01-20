using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day7
{
    class Program
    {
        private Dictionary<int, int> _dictionary;

        static void Main(string[] args)
        {
            _dictionary = new Dictionary<int, int>();

            var input = File.ReadAllText("../../../Data/input.txt");

            var totalFuelUsed = PartOne(input);            

            Console.WriteLine($"Result: {totalFuelUsed}");
        }
        
        private static int PartOne(string input)
        {
            var crabPositions = input.Split(",").Select(x => int.Parse(x)).ToList();

            var max = crabPositions.Max();
            var min = crabPositions.Min();

            var totalFuelUsed = int.MaxValue;

            for (var x = min; x < max; x++)
            {
                var targetPosition = x;
                var moves = 0;

                foreach (var crab in crabPositions)
                {
                    moves += Math.Abs(targetPosition - crab);
                }

                if (moves < totalFuelUsed)
                {
                    totalFuelUsed = moves;
                }
            }

            return totalFuelUsed;
        }

        private static int PartTwo(string input)
        {
            var crabPositions = input.Split(",").Select(x => int.Parse(x)).ToList();

            var max = crabPositions.Max();
            var min = crabPositions.Min();

            var totalFuelUsed = int.MaxValue;

            for (var x = min; x < max; x++)
            {
                var targetPosition = x;
                var fuelUsed = 0;

                foreach (var crab in crabPositions)
                {
                    fuelUsed += Math.Abs(targetPosition - crab);
                }

                if (fuelUsed < totalFuelUsed)
                {
                    totalFuelUsed = fuelUsed;
                }
            }

            return totalFuelUsed;
        }

    }

    //public class Squad
    //{
    //    public List<CrabSubmarine> Crabs { get; set; }
    //}

    //public class CrabSubmarine
    //{
    //    public int X { get; set; }
    //}
}
