using Day5.Part1;
using Day5.Part2;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = FileReader.ReadStringsFromTextFile("../../../Data/input.txt").ToList();
            
            // Part one

            var partOnelines = input.Select(line => new Line(line));

            var calculator = new SignificantIntersectionsCalculator();

            var result = calculator.CalculateInteresections(partOnelines);

            Console.WriteLine($"Part one: {result}");

            // Part two

            var lines = new List<LineV2>();

            foreach (var line in input)
            {
                var points = line.Split(" -> ");

                lines.Add(new LineV2(new PositionV2(points[0]), new PositionV2(points[1])));
            }

            var grid = new Grid();

            grid.PlaceLines(lines);
            
            var result2 = grid.CountOfPointsGreaterThan(1);

            Console.WriteLine($"Part two: {result2}");
        }
    }
}
