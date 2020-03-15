using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class NQueens
    {
        private const int N = 8;

        private static bool isSafe(char[,] mat, int row, int col)
        {
            //Check if Q is in Same Column
            for (int i = 0; i < row; i++)
            {
                if (mat[i, col] == 'Q')
                    return false;
            }

            //check for diagnol \
            for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (mat[i, j] == 'Q') return false;
            }

            //check for diagnol /
            for (int i = row, j = col; i >= 0 && j < N; i--, j++)
            {
                if (mat[i, j] == 'Q') return false;
            }

            return true;
        }

        private static void nQueen(char[,] mat, int r)
        {
            if (r == N)
            {
                //print the board
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                        Console.Write(mat[i, j] + " ");
                    Console.WriteLine();
                }
                Console.WriteLine();
                return;
            }

            //Place every queen at every square/Column at current row, and recur for valid combination
            for (int col = 0; col < N; col++)
            {
                if (isSafe(mat, r, col))
                {
                    mat[r, col] = 'Q';
                    nQueen(mat, r + 1);

                    //Else Backtrack and make it as -
                    mat[r, col] = '-';
                }
            }
        }

        public static void Driver()
        {

            // Mat[,] keeps track of position of Queens in
            // the current configuration
            char[,] mat = new char[N, N];

            // initialize mat[][] by '-'
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    mat[i, j] = '-';
                }
            }

            nQueen(mat, 0);
        }
    }
}
