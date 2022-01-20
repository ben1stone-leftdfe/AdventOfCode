using Day10.Extensions;
using System.Collections.Generic;

namespace Day10
{
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
}
