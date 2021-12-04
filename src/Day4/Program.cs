using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = FileReader.ReadStringsFromTextFile("../../../Data/input.txt").ToList();

            var numbersToCall = input[0].Split(",").Select(n => int.Parse(n)).ToList();
            var boards = CreateBoards(input);

            var game = new Game(numbersToCall, boards);

            // Part one

            var winningBoard = game.FindWinningBoard();
            var winningScore = winningBoard.BoardScore;

            Console.WriteLine($"Return {winningScore}");

            // Part two

            var losingBoard = game.FindLosingBoard();
            var losingScore = losingBoard.BoardScore;

            Console.WriteLine($"Last winner: {losingScore}");
        }

        private static List<Board> CreateBoards(List<string> input)
        {
            List<Board> boards = new List<Board>();

            for (var line = 2; line < input.Count; line += 6)
            {
                var lines = input.GetRange(line, 5);

                var rows = CreateRows(lines);

                boards.Add(new Board(rows));
            }

            return boards;
        }

        private static List<Row> CreateRows(List<string> lines)
        {
            List<Row> rows = new List<Row>();
          
            foreach (var line in lines)
            {
                var rowNumbers = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(num => int.Parse(num.Trim()));

                var cells = rowNumbers.Select(num => new Cell(num, false)).ToList();

                rows.Add(new Row(cells));
            }

            return rows;
        }
    }
}