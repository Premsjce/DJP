using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechieDelight.Backtracking
{
    public class NQueens
    {
        public static void Driver()
        {
            int dimension = 5;
            int currentRow = 0;


            char[,] board = new char[dimension, dimension];

            for (int row = 0; row < dimension; row++)
                for (int col = 0; col < dimension; col++)
                    board[row, col] = '-';

            PrintAllPossibleCombination(board, currentRow);
        }

        private static void PrintAllPossibleCombination(char[,] board, int currentRow)
        {
            int dimension = board.GetLength(0);
            if ( dimension == currentRow)
            {
                for (int row = 0; row < dimension; row++)
                {
                    for (int col = 0; col < dimension; col++)
                    {
                        Console.Write(board[row, col] + " ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
                return;
            }

            for (int currentCol = 0; currentCol < board.GetLength(0); currentCol++)
            {
                if (IsSafeToPlace(board, currentRow, currentCol))
                {
                    board[currentRow, currentCol] = 'Q';
                    PrintAllPossibleCombination(board, currentRow + 1);
                    board[currentRow, currentCol] = '-';
                }
            }
        }
        
        private static bool IsSafeToPlace(char[,] board, int currentRow, int currentCol)
        {
            int dimension = board.GetLength(0);
            
            //If 2 queens share same COLUMN, then return FALSE
            for (int row = 0; row < currentRow; row++)
                if (board[row, currentCol] == 'Q')
                    return false;

            //Return FALSE, if 2 queens share same backward diagonal "\"
            for(int row = currentRow, col = currentCol; row >=0 && col >=0; row--, col--)
                if (board[row, col] == 'Q')
                    return false;

            //Return FALSE, if 2 queens share same forward diagonal "/"
            for (int row = currentRow, col = currentCol; row >= 0 && col < dimension; row--, col++)
                if (board[row, col] == 'Q')
                    return false;
            
            return true;
        }
    }
}
