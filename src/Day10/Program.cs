using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("../../../Data/input.txt").ToList();

            var NavigationSystem = new NavigationSystem(input);

            var partOneResult = NavigationSystem.GetSyntaxErrorScore();
            var partTwoResult = NavigationSystem.GetMiddleScore();

            Console.WriteLine($"{partOneResult}");
            Console.WriteLine($"{partTwoResult}");
        }
    }

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

    public class Line
    {
        private string _characters;
        private Stack<char> _currentStack;

        public char? CorruptingCharacter { get; set; }
        public bool IsCorrupt => CorruptingCharacter != null;

        public Line(string characters)
        {
            _characters = characters;
            _currentStack = TryResolveLine(out char? corruptingCharacter);

            CorruptingCharacter = corruptingCharacter;
        }

        public List<char> GetRemainingChunks()
        {
            var remainingChunks = new List<char>();

            while (_currentStack.Count > 0)
            {
                remainingChunks.Add(_currentStack.Pop().GetClosingBracket().Value);
            }

            return remainingChunks;
        }

        private Stack<char> TryResolveLine(out char? corruptingCharacter)
        {
            corruptingCharacter = null;
            var unresolvedChunks = new Stack<char>();

            foreach (var chunk in _characters)
            {
                if (chunk.IsOpeningBracket())
                {
                    unresolvedChunks.Push(chunk);
                }
                else
                {
                    if (unresolvedChunks.Count == 0 || chunk.GetOpeningBracket() != unresolvedChunks.Peek())
                    {
                        corruptingCharacter = chunk;
                        break;
                    }
                    else
                    {
                        unresolvedChunks.Pop();
                    }
                }
            }

            return unresolvedChunks;
        }
    }

    public static class CharExtensions
    {
        public static bool IsOpeningBracket(this char input)
        {
            return input == '(' || input == '{' || input == '[' || input == '<';
        }

        public static char? GetOpeningBracket(this char input)
        {
            if (input == ')') return '(';
            else if (input == '>') return '<';
            else if (input == '}') return '{';
            else if (input == ']') return '[';
            else
                return null;
        }

        public static char? GetClosingBracket(this char input)
        {
            if (input == '(') return ')';
            else if (input == '<') return '>';
            else if (input == '{') return '}';
            else if (input == '[') return ']';
            else
                return null;
        }
    }
}