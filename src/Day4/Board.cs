using Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    public class Board
    {
        private int _currentNumber;
        public List<Row> _rows;

        public bool LineComplete { get; set; }
        public int BoardScore => _currentNumber * SumUncheckedNumbers();

        public Board(List<Row> rows)
        {
            _rows = rows;
        }

        public bool CheckRow(Row row) => row.IsComplete;

        public bool MarkNumber(int number)
        {
            _currentNumber = number;

            var x = 0;
            var y = 0;

            foreach (var (row, rowNumber) in _rows.WithIndex())
            {
                var columnNumber = row.MarkCell(number);
                 
                if (columnNumber != -1)
                {
                    x = columnNumber;
                    y = rowNumber;
                }
            }

            var bingo = CheckRowsAndColumns(x, y);

            return bingo;
        }

        public int SumUncheckedNumbers() => _rows.Sum(row => row.GetTotalUnchecked());

        public bool CheckRowsAndColumns(int x, int y) => CheckRow(_rows[y]) || CheckColumn(x);
     
        public bool CheckColumn(int column) => _rows.All(r => r.Cells[column].Checked);
    }
}
