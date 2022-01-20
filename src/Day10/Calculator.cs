using System.Collections.Generic;

namespace Day10
{
    public class Calculator
    {
        protected int CalculateSyntaxErrorScore(IEnumerable<Line> corruptLines)
        {
            var syntaxErrorScore = 0;

            foreach (var line in corruptLines)
            {
                syntaxErrorScore += PartOneCharScore(line.CorruptingCharacter.Value);
            }

            return syntaxErrorScore;
        }

        protected List<long> CalculateLineScores(IEnumerable<Line> incompleteLines)
        {
            var lineScores = new List<long>();

            foreach (var line in incompleteLines)
            {
                var remainingChunks = line.GetRemainingChunks();

                var lineScore = GetLineScore(remainingChunks);

                lineScores.Add(lineScore);
            }

            return lineScores;
        }

        private long GetLineScore(List<char> chunks)
        {
            long score = 0;

            foreach (var chunk in chunks)
            {
                score = (score * 5) + PartTwoCharScore(chunk);
            }

            return score;
        }

        private int PartOneCharScore(char input)
        {
            switch (input)
            {
                case ')': return 3;
                case ']': return 57;
                case '}': return 1197;
                case '>': return 25137;

                default: return 0;
            }
        }

        private int PartTwoCharScore(char input)
        {
            switch (input)
            {
                case ')': return 1;
                case ']': return 2;
                case '}': return 3;
                case '>': return 4;

                default: return 0;
            }
        }
    }
}
