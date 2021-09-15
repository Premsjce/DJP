using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechieDelight.Backtracking
{
    /// <summary>
    /// https://www.techiedelight.com/print-possible-knights-tours-chessboard/
    /// Given a chessboard, print all sequence of moves of a knight on a chessboard, 
    /// such that knight visits every square only once
    /// </summary>
    public class ChessKnightAllPossibleTour
    {
        public static int GlobalCounter = 0;
        public static void Driver()
        {
            //this question will use DFS algorithm, since we have to touch every cell only once 
            //and if the cell can't be reached then we need to backtrack

            int boardSize = 5;
            int[,] chessBoard = new int[boardSize, boardSize];

            int currentCount = 1;
            KnightTourDFS(chessBoard, 0, 0, boardSize, currentCount);

            Console.WriteLine(GlobalCounter);
        }

        private static void PrintBoard(int boardSize, int[,] board)
        {
            for (int r = 0; r < boardSize; r++)
            {
                for (int c = 0; c < boardSize; c++)
                    Console.Write($"{board[r, c]} ");
                Console.WriteLine();
            }
            Console.WriteLine();
            GlobalCounter += 1;
        }

        private static void KnightTourDFS(int[,] chessBoard, int row, int col, int boardSize, int currentCount)
        {
            if (currentCount >= (boardSize*boardSize))
            {
                PrintBoard(boardSize, chessBoard);
                GlobalCounter += 1;
                return;
            }

            chessBoard[row, col] = currentCount;

            int[] ROWS = { -1, -1, -2, -2, 1, 1, 2, 2 };
            int[] COLS = { -2, 2, -1, 1, -2, 2, -1, 1 };

            for (int i = 0; i< 8;i++)
            {
                var nextRow = row + ROWS[i];
                var nextCol = col + COLS[i];

                if (IsSafeAndValid(nextRow, nextCol, boardSize, chessBoard))
                    KnightTourDFS(chessBoard, nextRow, nextCol, boardSize, currentCount + 1);
            }

            //Backtracking
            chessBoard[row, col] = 0;            
        }

        public static bool IsSafeAndValid(int row, int col, int boardSize, int[,] board)
        {
            return row >= 0 && row < boardSize && col >= 0 && col < boardSize && board[row, col] == 0;
        }
    }
}