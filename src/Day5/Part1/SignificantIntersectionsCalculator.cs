using System.Collections.Generic;
using System.Linq;

namespace Day5.Part1
{
    public class SignificantIntersectionsCalculator
    {
        public int CalculateInteresections(IEnumerable<Line> lines)
        {
            var maxHeight = 0;
            var maxWidth = 0;

            foreach (var line in lines)
            {
                if (line.Start.X > maxWidth)
                {
                    maxWidth = line.Start.X;
                }
                if (line.End.X > maxWidth)
                {
                    maxWidth = line.End.X;
                }
                if (line.Start.Y > maxHeight)
                {
                    maxHeight = line.Start.Y;
                }
                if (line.End.Y > maxHeight)
                {
                    maxHeight = line.End.Y;
                }
            }

            var grid = new int[maxHeight + 1, maxWidth + 1];

            foreach (var line in lines.Where(line => line.IsDiagonal == false))
            {
                if (line.IsVertical)
                {
                    for (var y = 0; y < maxHeight; y++)
                    {
                        if (line.Start.Y >= y && line.End.Y <= y || line.Start.Y <= y && line.End.Y >= y)
                        {
                            grid[y, line.Start.X] = grid[y, line.Start.X] + 1;
                        }
                    }
                }

                if (line.IsHorizontal)
                {
                    for (var x = 0; x < maxWidth; x++)
                    {
                        if (line.Start.X >= x && line.End.X <= x || line.Start.X <= x && line.End.X >= x)
                        {
                            grid[line.Start.Y, x] = grid[line.Start.Y, x] + 1;
                        }
                    }
                }
            }

            var pointsGreaterThan1 = 0;

            for (var y = 0; y <= maxHeight; y++)
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
}
