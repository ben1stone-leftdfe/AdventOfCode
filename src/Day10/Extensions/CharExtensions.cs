namespace Day10.Extensions
{
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
