namespace Day5.Part1
{
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

        public bool IsDiagonal => Start.X != End.X && Start.Y != End.Y;
        public bool IsVertical => Start.X == End.X;
        public bool IsHorizontal => Start.Y == End.Y;
    }
}
