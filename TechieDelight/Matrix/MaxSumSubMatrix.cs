using System;

namespace TechieDelight.Matrix
{
    /// <summary>
    /// Link : https://www.techiedelight.com/find-maximum-sum-submatrix-in-given-matrix/
    /// Given a M*N Matirx, Calculate maximum sum of submatrix  of size K, in O(M*N) 
    /// time complexity Where 0 < K < (M ,N) 
    /// </summary>
    public class MaxSumSubMatrix
    {
        private static int Kx = 0;
        private static int Ky = 0;
        public static void Driver()
        {
            int[,] matrix =
            {
                { 3, -4, 6, -5, 1 },
                { 1, -2, 8, -4, -2 },
                { 3, -8, 9, 3, 1 },
                { -7, 3, 4, 2, 7 },
                { -3, 7, -5, 7, -6 }
            };

            int M = matrix.GetLength(0);
            int N = matrix.GetLength(1);
            int K = 3;

            int maxSum = CalculateMaxSubMatrixSum(matrix, M, N, K);
            Console.WriteLine($"Maximum sum is  : {maxSum}");

            for (int r = 0; r < K; r++)
            {
                for (int c = 0; c < K; c++)
                {
                    int row = r + Kx - K + 1;
                    int col = c + Ky - K + 1;
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }

        }

        private static int CalculateMaxSubMatrixSum(int[,] matrix, int M, int N, int K)
        {
            //Create a sum matrix, where each cell will hold the sum value of all previous rows and cols + current cell
            int[,] sumMatrix = new int[M, N];
            sumMatrix[0, 0] = matrix[0, 0];


            for (int row = 1; row < M; row++)
            {
                sumMatrix[row, 0] = matrix[row, 0] + sumMatrix[row - 1, 0];
            }

            for (int col = 1; col < N; col++)
            {
                sumMatrix[0, col] = matrix[0, col] + sumMatrix[0, col - 1];
            }

            for (int row = 1; row < M; row++)
            {
                for (int col = 1; col < N; col++)
                {
                    sumMatrix[row, col] = matrix[row, col] + sumMatrix[row - 1, col] + sumMatrix[row, col - 1] - sumMatrix[row - 1, col - 1];
                }
            }

            int maxSum = int.MinValue;
            int currTotal = 0;

            //Now, summatrix holds the sum of all the elements and we need to find K matrix sum and take maximum possible k sum
            for (int row = K - 1; row < M; row++)
            {
                for (int col = K - 1; col < N; col++)
                {
                    currTotal = sumMatrix[row, col];
                    if (row - K >= 0)
                        currTotal -= sumMatrix[row - K, col];
                    if (col - K >= 0)
                        currTotal -= sumMatrix[row, col - K];
                    if (row - K >= 0 && col - K >= 0)
                        currTotal += sumMatrix[row - K, col - K];

                    //int currentCellSum = sumMatrix[row - K, col] - sumMatrix[row, col - K] + sumMatrix[row - K, col - K];
                    if (currTotal > maxSum)
                    {
                        Kx = row;
                        Ky = col;
                        maxSum = currTotal;
                    }
                }
            }

            return maxSum;
        }
    }
}