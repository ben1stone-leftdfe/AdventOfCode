using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    public class Game
    {
        private int _completeBoards = 0;

        public List<int> NumbersToCall { get; set; }
        public List<Board> Boards { get; set; }

        public Game(List<int> numbers, List<Board> boards)
        {
            NumbersToCall = numbers;
            Boards = boards;
        }

        public Board FindWinningBoard()
        {
            foreach (var number in NumbersToCall)
            {
                var board = MarkNumberOnEachBoard(number);

                if (board != null)
                {
                    return board;
                }
            }

            return null;
        }

        public Board FindLosingBoard()
        { 
            foreach (var number in NumbersToCall)
            {
                var losingBoard = MarkNumberOnEachBoardLoser(number);

                if (losingBoard != null)
                    return losingBoard;
            }

            return null;
        }

        public Board MarkNumberOnEachBoard(int number)
        {
            foreach (var board in Boards.Where(b => b.LineComplete == false))
            {
                var bingo = board.MarkNumber(number);
              
                if (bingo)
                {
                    return board;
                }
            }

            return null;
        }

        public Board MarkNumberOnEachBoardLoser(int number)
        {
            foreach (var board in Boards.Where(b => b.LineComplete == false))
            {
                var bingo = board.MarkNumber(number);

                if (bingo)
                {
                    if (board.LineComplete == false)
                    {
                        _completeBoards++;
                        board.LineComplete = true;
                    }

                    if (_completeBoards == Boards.Count)
                    {
                        return board;
                    }
                }
            }

            return null;
        }
    }
}
