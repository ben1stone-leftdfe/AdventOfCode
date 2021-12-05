namespace Day5.Part2
{
    public class Node
    {
        public PositionV2 Position { get; set; }
        public Node Next { get; set; }

        public Node(PositionV2 start, PositionV2 end, Direction direction)
        {
            Position = start;

            if (start.X != end.X || start.Y != end.Y)
            {
                Next = new Node(start.GetNextPosition(direction), end, direction);
            }
        }
    }
}
