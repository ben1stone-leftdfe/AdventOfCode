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

            var lines = input.Select(lineString => new Line(lineString));

            var result = CalculateInteresections(lines);

            Console.WriteLine($"Hello World! {result}");
        }

        public static int CalculateInteresections(IEnumerable<Line> lines)
        {
            var maxHeight = 0;
            var maxWidth = 0;

            foreach (var line in lines)
            {
                if (line.Start.x > maxWidth)
                {
                    maxWidth = line.Start.x;
                }
                if (line.End.x > maxWidth)
                {
                    maxWidth = line.End.x;
                }
                if (line.Start.y > maxHeight)
                {
                    maxHeight = line.Start.y;
                }
                if (line.End.y > maxHeight)
                {
                    maxHeight = line.End.y;
                }
            }

            var grid = new int[maxHeight + 1, maxWidth + 1];

            foreach (var line in lines.Where(line => line.IsDiagonal == false))
            {
                if (line.IsVertical)
                { 
                    for (var y = 0; y < maxHeight; y++)
                    {
                        if (line.Start.y >= y && line.End.y <= y || line.Start.y <= y && line.End.y >= y)
                        {
                            grid[y, line.Start.x] = grid[y, line.Start.x] + 1;
                        }
                    }
                }

                if (line.IsHorizontal)
                {
                    for (var x = 0; x < maxWidth; x++)
                    {
                        if (line.Start.x >= x && line.End.x <= x || line.Start.x <= x && line.End.x >= x)
                        {
                            grid[line.Start.y, x] = grid[line.Start.y, x] + 1;
                        }
                    }
                }
            }

            var pointsGreaterThan1 = 0;

            for (var y = 0; y <= maxHeight ; y++)
            {
                for (var x = 0; x <= maxWidth; x++)
                {
                    if (grid[y, x] >= 2)
                    {
                        pointsGreaterThan1++;
                    }
                }
            }

            return pointsGreaterThan1;
        }
    }

    public class Position
    {
        public int x { get; set; }
        public int y { get; set; }

        public Position(string input)
        {
            var coordinate = input.Split(",");

            x = int.Parse(coordinate[0]);
            y = int.Parse(coordinate[1]);
        }
    }

    public class Line
    {
        public Position Start { get; set; }
        public Position End { get; set; }

        public Line(string input)
        {
            var points = input.Split(" -> ");

            Start = new Position(points[0]);
            End = new Position(points[1]);
        }

        public bool IsDiagonal => Start.x != End.x && Start.y != End.y;
        public bool IsVertical => Start.x == End.x;
        public bool IsHorizontal => Start.y == End.y;
    }
}
