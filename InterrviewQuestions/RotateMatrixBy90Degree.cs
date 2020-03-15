using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class RotateMatrixBy90Degree
    {

        public static void Driver()
        {
            int[,] matrix =
                {
                    {1, 8, 3, 6, 5},
                    {11,2, 5, 6, 4},
                    {3, 6, 8, 3, 1},
                    {12,4, 5, 2, 2},
                    {11, 5, 9, 3, 6}
                };

            Console.WriteLine("Before Transormation");
            int M = matrix.GetLength(0);
            int N = matrix.GetLength(1);
            for (int row = 0; row < M; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }


            Console.WriteLine("After Transormation");
            RotateMatrixInplace(matrix);
            M = matrix.GetLength(0);
            N = matrix.GetLength(1);
            for (int row = 0; row < M; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static int[,] RotateMatrixWithExtraSpace(int[,] matrix)
        {
            int M = matrix.GetLength(0);
            int N = matrix.GetLength(1);

            int[,] rotMatrix = new int[N, M];

            for (int row = 0; row < M; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    rotMatrix[col, M - row - 1] = matrix[row, col];
                }
            }

            return rotMatrix;
        }

        private static void RotateMatrixInplace(int[,] matrix)
        {
            int M = matrix.GetLength(0);

            for (int row = 0; row < (M / 2); row++)
            {
                for (int col = row; col < (M - row - 1); col++)
                {
                    int temp = matrix[row, col];
                    matrix[row, col] = matrix[M - 1- col, row];
                    matrix[M - 1- col, row] = matrix[M - 1- row, M - 1 - col];
                    matrix[M - 1 - row, M - 1 - col] = matrix[col, M - 1- row];
                    matrix[col, M - 1 - row] = temp;
                }
            }
        }
    }
}
