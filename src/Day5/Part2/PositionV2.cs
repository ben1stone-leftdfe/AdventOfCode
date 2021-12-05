namespace Day5.Part2
{
    public class PositionV2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public PositionV2(string input)
        {
            var coordinate = input.Split(",");

            X = int.Parse(coordinate[0]);
            Y = int.Parse(coordinate[1]);
        }

        public PositionV2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public PositionV2 GetNextPosition(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return new PositionV2(X, Y - 1);

                case Direction.NorthEast:
                    return new PositionV2(X + 1, Y - 1);

                case Direction.East:
                    return new PositionV2(X + 1, Y);

                case Direction.SouthEast:
                    return new PositionV2(X + 1, Y + 1);

                case Direction.South:
                    return new PositionV2(X, Y + 1);

                case Direction.SouthWest:
                    return new PositionV2(X - 1, Y + 1);

                case Direction.West:
                    return new PositionV2(X - 1, Y);

                default:
                    return new PositionV2(X - 1, Y - 1);
            }
        }
    }
}
