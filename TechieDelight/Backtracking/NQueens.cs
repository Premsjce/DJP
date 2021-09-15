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
            GetCom(dimension);
        }

        public static IList<IList<string>> GetCom(int dimension)
        {
            int currentRow = 0;
            char[,] board = new char[dimension, dimension];

            //Initializing the Emplty Board
            for (int row = 0; row < dimension; row++)
                for (int col = 0; col < dimension; col++)
                    board[row, col] = '-';

            var output = new List<IList<string>>();
            PrintAllPossibleCombination(board, currentRow, output);
            
            //Printing the possible output combinations
            foreach(var o in output)
            {
                foreach(var i in o)
                    Console.WriteLine(i);
                Console.WriteLine();
            }

            return output;
        }

        private static void PrintAllPossibleCombination(char[,] board, int currentRow, List<IList<string>> output)
        {
            int dimension = board.GetLength(0);

            //It means we have reached a combination where all the Queens are places perfectly on board
            if (dimension == currentRow)
            {
                var currentCombination = new List<string>();
                for (int row = 0; row < dimension; row++)
                {
                    var cRow = string.Empty;
                    for (int col = 0; col < dimension; col++)
                        cRow += board[row, col];

                    currentCombination.Add(cRow);
                }
                output.Add(currentCombination);
                return;
            }

            for (int currentCol = 0; currentCol < dimension; currentCol++)
            {
                if (IsSafeToPlace(board, currentRow, currentCol))
                {
                    board[currentRow, currentCol] = 'Q';
                    PrintAllPossibleCombination(board, currentRow + 1, output);
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
            for (int row = currentRow, col = currentCol; row >= 0 && col >= 0; row--, col--)
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
