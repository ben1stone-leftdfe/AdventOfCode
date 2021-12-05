namespace Day5.Part2
{
    public class LineV2
    {
        public Direction Direction { get; set; }
        public Node StartingNode { get; set; }

        public LineV2(PositionV2 start, PositionV2 end)
        {
            Direction = GetDirection(start, end);

            StartingNode = new Node(start, end, Direction);
        }

        private Direction GetDirection(PositionV2 startPosition, PositionV2 endPosition)
        {
            if (startPosition.X < endPosition.X)
            {
                if (startPosition.Y < endPosition.Y)
                {
                    return Direction.SouthEast;
                }
                else if (startPosition.Y == endPosition.Y)
                {
                    return Direction.East;
                }
                else
                {
                    return Direction.NorthEast;
                }
            }
            else if (startPosition.X > endPosition.X)
            {
                if (startPosition.Y > endPosition.Y)
                {
                    return Direction.NorthWest;
                }
                else if (startPosition.Y < endPosition.Y)
                {
                    return Direction.SouthWest;
                }
                else
                {
                    return Direction.West;
                }
            }
            else
            {
                if (startPosition.Y > endPosition.Y)
                {
                    return Direction.North;
                }
                else
                {
                    return Direction.South;
                }
            }
        }
    }
}
