using System.Collections.Generic;
using System.Linq;
using static Day5.Program;

namespace Day5.Part2
{
    public class Row
    {
        private List<Cell> _cells = new List<Cell>();

        public int Width => _cells.Count();

        public int CountIfGreaterThan(int value)
        {
            return _cells.Count(cell => cell._number > value);
        }

        public Row(int numberOfColumns)
        {
            _cells = new List<Cell>();

            for (var cell = 0; cell < numberOfColumns; cell++)
            {
                _cells.Add(new Cell());
            }
        }

        public void AddColumn(int numberOfColumns)
        {
            for (var i = 0; i < numberOfColumns; i++)
            {
                _cells.Add(new Cell());
            }
        }

        public void IncrementCell(int columnNumber) => _cells[columnNumber].IncrementCell();

    }
}
