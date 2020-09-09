using System;


/// <summary>
/// Link : https://www.techiedelight.com/find-maximum-sum-submatrix-in-given-matrix/
/// </summary>
namespace TechieDelight.Matrix
{
    //Given a M*N Matirx, Calculate maximum sum of submatrix  of size K, in O(M*N) time complexity Where 0 < K < (M ,N) 
    public class MaxSumSubMatrix
    {
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
        }

        private static int CalculateMaxSubMatrixSum(int[,] matrix, int M, int N, int K)
        {
            //Create a sum matrix, where each cell will hold the sum value of all previous rows and cols + current cell

            int[,] sumMatrix = new int[M, N];
            sumMatrix[0, 0] = matrix[0, 0];

            for (int row = 0; row < M; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    if (row == 0 || col == 0)
                    {
                        if (row == 0)
                            sumMatrix[row, col] = matrix[row, col] + sumMatrix[row, col - 1];
                        else
                            sumMatrix[row, col] = matrix[row, col] + sumMatrix[row - 1, col];
                    }
                    else
                    {
                        sumMatrix[row, col] = matrix[row, col] + sumMatrix[row - 1, col] + sumMatrix[row, col - 1] - sumMatrix[row - 1, col - 1];
                    }
                }
            }
            int maxSum = int.MinValue;
            int currTotal = 0;
            
            //Now, Summatrix holds the sum of all the elements
            for (int row = K - 1; row < M; row++)
            {
                for (int col = K - 1; col < N; col++)
                {
                    currTotal = sumMatrix[row, col];
                    if (row - K > 0)
                    {
                        currTotal -= sumMatrix[row - K, col];
                    }
                    if (col - K > 0)
                    {
                        currTotal -= sumMatrix[row, col - K];
                    }
                    if (row - K > 0 && col - K > 0)
                    {
                        currTotal += sumMatrix[row - K, col - K];
                    }

                    //int currentCellSum = sumMatrix[row - K, col] - sumMatrix[row, col - K] + sumMatrix[row - K, col - K];
                    if (currTotal > maxSum)
                        maxSum = currTotal;
                }
            }

            return maxSum;
        }

    }
}
