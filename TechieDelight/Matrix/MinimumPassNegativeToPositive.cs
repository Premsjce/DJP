using System;
using System.Collections;
using System.Collections.Generic;

namespace TechieDelight.Matrix
{
    /// <summary>
    /// https://www.techiedelight.com/find-minimum-passes-required-convert-negative-values-matrix/
    /// Given m*n Matrix of integers whose each cell can contain negative, zero or positive value,
    /// determine the minimum number of passes needed to convert all negative to positive,
    /// Only cell whose value is non-zero postive, can change its adjacent cells to positive
    /// Up, Down, Forward and Backward
    /// </summary>
    public class MinimumPassNegativeToPositive
    {
        public static void Driver()
        {
            //4*5 Matrix
            const int M = 4, N = 5;
            var matrix = new int[M,N]
            {
               { -1, -9, 0, -1, 0 },
               { -8, -3, -2, 9, -7 },
               { 2, 0, 0, -6, 0 },
               { 0, -7, -3, 5, -4 }
            };

            var passes = MinPassesRequired(matrix, M, N);
            if(passes != int.MaxValue)
                Console.WriteLine($"Minimum Passed required for given Matrix is  : {passes}");
            else
                Console.WriteLine($"Some cell in the Matrix cannot be reached");
        }

        private static int MinPassesRequired(int[,] matrix, int m, int n)
        {
            Queue<MatrixPoint> originalQueue = new Queue<MatrixPoint>();
            Queue<MatrixPoint> bufferQueue = new Queue<MatrixPoint>();

            for (int row = 0; row < m; row++)
                for (int col = 0; col < n; col++)
                    if (matrix[row, col] > 0)
                        originalQueue.Enqueue(new MatrixPoint(row,col));

            int totalPasses = 0;

            int[] ROWS = { 0, 0, -1, 1 };
            int[] COLS = { -1, 1, 0, 0 };

            while (originalQueue.Count > 0)
            {
                TransferQueue(originalQueue, bufferQueue);
                
                while(bufferQueue.Count > 0)
                {
                    var currentPositiveCell = bufferQueue.Dequeue();

                    for (int i = 0; i < 4; i++)
                    {
                        int nextRow = currentPositiveCell.X + ROWS[i];
                        int nextCol = currentPositiveCell.Y + COLS[i];

                        if (IsSafeAndValidNegativeCell(matrix, m, n, nextRow, nextCol))
                        {
                            matrix[nextRow, nextCol] *= -1;
                            originalQueue.Enqueue(new MatrixPoint(nextRow, nextCol));
                        }
                    }
                }
                

                totalPasses += 1;
            }

            return AnyNegativeValuePresent(matrix, m, n) ? int.MaxValue : totalPasses -1;
        }

        private static void TransferQueue(Queue<MatrixPoint> origianlQueue, Queue<MatrixPoint> bufferQueue)
        {
            bufferQueue.Clear();
            while (origianlQueue.Count > 0)
                bufferQueue.Enqueue(origianlQueue.Dequeue());
        }

        private static bool AnyNegativeValuePresent(int[,] matrix, int M, int N)
        {
            for(int row = 0; row < M; row++)
                for(int col = 0; col < N; col++)
                    if (matrix[row, col] < 0)
                        return true;

            return false;
        }

        private static bool IsSafeAndValidNegativeCell(int[,] matrix, int M, int N, int nextRow, int nextCol)
        {
            return nextRow >= 0 && nextRow < M && nextCol >=0 && nextCol < N && matrix[nextRow,nextCol] < 0;
        }
    }

    public class MatrixPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public MatrixPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}