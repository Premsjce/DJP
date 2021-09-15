using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechieDelight.Backtracking
{
    /// <summary>
    /// https://www.techiedelight.com/chess-knight-problem-find-shortest-path-source-destination/
    /// Given a chess board, find the shortest distance(minimum number of steps taken) by a knight
    /// to reach a given destination from a given source
    /// </summary>
    public class ChessKnightShortestPath
    {
        public static void Driver()
        {
            int boardSize = 8;
            var sourceNode = new ChessNode(0, 7);
            var destinationNode = new ChessNode(7, 0);

            int result = FindShortestPathUsingBFS(sourceNode, destinationNode, boardSize);

            Console.WriteLine($"Minimum Steps required : {result}");
        }

        private static int FindShortestPathUsingBFS(ChessNode sourceNode, ChessNode destinationNode, int boardSize)
        {
            if (sourceNode.X == destinationNode.X && sourceNode.Y == destinationNode.Y)
                return 0;

            bool[,] visited = new bool[boardSize, boardSize];

            Queue<ChessNode> queue = new Queue<ChessNode>();
            queue.Enqueue(sourceNode);

            //Next possible 8 moves for a knight

            int[] ROWS = { -1, -1, -2, -2, 1, 1, 2, 2 };
            int[] COLS = { -2, 2, -1, 1, -2, 2, -1, 1 };

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                if (currentNode.X == destinationNode.X && currentNode.Y == destinationNode.Y)
                    return currentNode.Distance;

                for (int i = 0; i < 8; i++)
                {
                    var nextX = currentNode.X + ROWS[i];
                    var nextY = currentNode.Y + COLS[i];

                    if (IsSafeAndValid(nextX, nextY, boardSize, visited))
                    {
                        visited[nextX, nextY] = true;
                        var nextNode = new ChessNode(nextX, nextY, currentNode.Distance + 1);
                        queue.Enqueue(nextNode);
                    }
                }
            }

            return int.MaxValue;
        }

        private static bool IsSafeAndValid(int row, int col, int boardSize, bool[,] visited)
        {
            return row >= 0 && row < boardSize && col >= 0 && col < boardSize && !visited[row, col];
        }
    }

    public class ChessNode
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Distance { get; set; }

        public ChessNode(int x, int y, int distance = 0)
        {
            X = x;
            Y = y;
            Distance = distance;
        }
    }
}