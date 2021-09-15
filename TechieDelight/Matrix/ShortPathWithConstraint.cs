using System;
using System.Collections.Generic;

namespace TechieDelight.Matrix
{
    /// <summary>
    /// https://www.techiedelight.com/find-shortest-path-source-destination-matrix-satisfies-given-constraints/
    /// Given N*N of positive integers, find the shortest path from the first cell of the matrix 
    /// to its last cell that satisfies the given constraints
    /// 1. We can move exactly K steps from any cell in matrix where K is the value of the cell
    /// </summary>
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
            int destX = 9;
            int destY = 9;
            bool[,] visited = new bool[ROW, COL];

            MatrixNode node = null;
            for (int row = 0; row < ROW; row++)
            {
                for (int col = 0; col < COL; col++)
                {
                    if (row == sourceX && sourceY == col)
                    {
                       node = FindShortestPath(matrix, sourceX, sourceY, destX, destY, visited);
                    }
                }
            }

            if (node == null)
                Console.WriteLine("Destination node cannot be reached");
            else
            {
                var jumps = PrintPath(node) -1;
                Console.WriteLine("\nTotal jumps from source to destination is  : " + jumps);
            }       
        }

        private static MatrixNode FindShortestPath(int[,] matrix, int sourceX, int sourceY, int destX, int destY, bool[,] visited)
        {
            int[] ROWS = { 0, 0, -1, 1 };
            int[] COLS = { -1, 1, 0, 0 };

            var sourceNode = new MatrixNode(sourceX, sourceY, null);
            Queue<MatrixNode> queue = new Queue<MatrixNode>();
            queue.Enqueue(sourceNode);

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();
                int currentX = currentNode.X;
                int currentY = currentNode.Y;

                if (currentX == destX && currentY == destY)
                    return currentNode;

                for (int i = 0; i < 4; i++)
                {
                    int currentValue = matrix[currentX, currentY];
                    int nextX = currentX + (ROWS[i] * currentValue);
                    int nextY = currentY + (COLS[i] * currentValue);

                    if (IsSafeAndValid(matrix, nextX, nextY, visited))
                    {
                        visited[nextX, nextY] = true;
                        var nextNode = new MatrixNode(nextX, nextY, currentNode);
                        queue.Enqueue(nextNode);
                    }
                }
            }
            return null;
        }

        private static int PrintPath(MatrixNode node)
        {
            if (node == null)
                return 0;
            
            var jump = PrintPath(node.Parent);
            Console.Write($"({node.X},{node.Y}) ");
            return jump + 1;
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
        public MatrixNode Parent { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public MatrixNode(int x, int y, MatrixNode parent)
        {
            X = x;
            Y = y;
            Parent = parent;
        }
    }
}
