using System.Collections.Generic;
using System.Linq;

namespace Day10
{
    public class NavigationSystem : Calculator
    {
        private List<Line> _lines;

        public NavigationSystem(List<string> input)
        {
            _lines = input.Select(line => new Line(line)).ToList();
        }

        public int GetSyntaxErrorScore()
        {
            var corruptLines = _lines.Where(line => line.IsCorrupt == true);

            return CalculateSyntaxErrorScore(corruptLines);
        }

        public long GetMiddleScore()
        {
            var incompleteLines = _lines.Where(line => line.IsCorrupt == false);

            var lineScores = CalculateLineScores(incompleteLines);

            var orderedScores = lineScores.OrderBy(line => line).ToList();

            return orderedScores[(orderedScores.Count - 1) / 2];
        }
    }
}
