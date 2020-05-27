using System;
using System.Collections.Generic;

namespace TechieDelight.Matrix
{
    public class ShortPathWithConstraint
    {
        public static void Driver()
        {
            int[,] matrix =
            {
                { 4, 4, 6, 5, 5, 1, 1, 1, 7, 4 },
                { 3, 6, 2, 4, 6, 5, 7, 2, 6, 6 },
                { 1, 3, 6, 1, 1, 1, 7, 1, 4, 5 },
                { 7, 5, 6, 3, 1, 3, 3, 1, 1, 7 },
                { 3, 4, 6, 4, 7, 2, 6, 5, 4, 4 },
                { 3, 2, 5, 1, 2, 5, 1, 2, 3, 4 },
                { 4, 2, 2, 2, 5, 2, 3, 7, 7, 3 },
                { 7, 2, 4, 3, 5, 2, 2, 3, 6, 3 },
                { 5, 1, 4, 2, 6, 4, 6, 7, 3, 7 },
                { 1, 4, 1, 7, 5, 3, 6, 5, 3, 4 }
            };

            int ROW = matrix.GetLength(0);
            int COL = matrix.GetLength(1);

            int sourceX = 0;
            int sourceY = 0;
            int destX = ROW - 1;
            int destY = COL - 1;
            bool[,] visited = new bool[ROW, COL];

            for (int row = 0; row < ROW; row++)
            {
                for (int col = 0; col < COL; col++)
                {
                    if (row == sourceX && sourceY == col)
                    {
                        findShortestPath(matrix, sourceX, sourceY, destX, destY, visited);
                    }
                }
            }
        }

        private static void findShortestPath(int[,] matrix, int sourceX, int sourceY, int destX, int destY, bool[,] visited)
        {
            if (sourceX == destX && sourceY == destY)
            {
                Console.WriteLine($"Shortest Distance is  0");
                return;
            }

            int[] ROWS = { 0, 0, -1, 1 };
            int[] COLS = { -1, 1, 0, 0 };

            var sourceNode = new MatrixNode(sourceX, sourceY, 0);
            Queue<MatrixNode> queue = new Queue<MatrixNode>();
            queue.Enqueue(sourceNode);

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();
                int currentX = currentNode.X;
                int currentY = currentNode.Y;

                if (currentX == destX && currentY == destY)
                {
                    Console.WriteLine($"Shortest Distance is  {currentNode.Distance}");
                    return;
                }

                for (int i = 0; i < 4; i++)
                {
                    int currentValue = matrix[currentX, currentY];
                    int nextX = currentX + (ROWS[i] * currentValue);
                    int nextY = currentY + (COLS[i] * currentValue);

                    if (IsSafeAndValid(matrix, nextX, nextY, visited))
                    {
                        visited[nextX, nextY] = true;
                        var nextNode = new MatrixNode(nextX, nextY, (currentValue + currentNode.Distance));
                        queue.Enqueue(nextNode);
                    }
                }
            }

            Console.WriteLine("Destination cannot be reached");
        }

        private static bool IsSafeAndValid(int[,] matrix, int nextX, int nextY, bool[,] visited)
        {
            var M = matrix.GetLength(0);
            var N = matrix.GetLength(1);
            return nextX >= 0 && nextX < M && nextY >= 0 && nextY < N && !visited[nextX, nextY];
        }
    }

    public class MatrixNode
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Distance { get; set; }
        public MatrixNode(int x, int y, int dist)
        {
            X = x;
            Y = y;
            Distance = dist;
        }
    }
}
