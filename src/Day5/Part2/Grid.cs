using System.Collections.Generic;
using System.Linq;

namespace Day5.Part2
{
    public class Grid
    {
        private int _numberOfColumns => _rows[0].Width;

        private List<Row> _rows = new List<Row>() { new Row(1) };

        public void PlaceLines(List<LineV2> lines)
        {
            foreach (var line in lines)
            {
                PlaceLine(line);
            }
        }

        private void PlaceLine(LineV2 line) => PlaceNode(line.StartingNode);

        private void PlaceNode(Node node)
        {
            var position = node.Position;

            if (position.Y >= _rows.Count)
            {
                AddRows((position.Y - _rows.Count) + 1);
            }

            if (position.X >= _numberOfColumns)
            {
                AddColumns((position.X - _numberOfColumns) + 1);
            }

            _rows[position.Y].IncrementCell(position.X);

            if (node.Next != null)
            {
                PlaceNode(node.Next);
            }
        }

        private void AddRows(int numberOfRows)
        {
            for (var row = 0; row < numberOfRows; row++)
            {
                _rows.Add(new Row(_numberOfColumns));
            }
        }

        private void AddColumns(int numberOfColumns)
        {
            foreach (var row in _rows)
            {
                row.AddColumn(numberOfColumns);
            }
        }

        public int CountOfPointsGreaterThan(int value) => _rows.Sum(row => row.CountIfGreaterThan(value));
    }
}
