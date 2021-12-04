using Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    public class Row
    {
        public List<Cell> Cells { get; }

        public bool IsComplete => Cells.All(cell => cell.Checked == true); 

        public Row(List<Cell> cells)
        {
            Cells = cells;
        }

        public int GetTotalUnchecked()
        { 
            return Cells.Where(cell => cell.Checked == false).Sum(cell => cell.Value);
        }

        public int MarkCell(int numberToMark)
        {
            foreach (var (cell, columnNumber) in Cells.WithIndex())
            {
                if (cell.Value == numberToMark)
                {
                    cell.CheckCell();
                    return columnNumber;
                }
            }

            return -1;
        }
    }
}