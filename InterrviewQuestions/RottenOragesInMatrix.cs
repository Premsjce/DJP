using System;
using System.Collections.Generic;

namespace InterviewQuestions
{
    public class OrangeNode
    {
        public int X { get; set; }
        public int Y { get; set; }

        public OrangeNode(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    class RottenOragesInMatrix
    {
        public static void Driver()
        {
            int[][] grid = new int[3][];
            grid[0] = new int[3] { 2, 1, 1 };
            grid[1] = new int[3] { 1, 1, 0 };
            grid[2] = new int[3] { 0, 1, 1 };

            int result = RottenOrangeTimeFrame(grid);
            Console.WriteLine(result);
        }

        public static int RottenOrangeTimeFrame(int[][] grid)
        {
            int fresh = 0;
            int timeFrame = 0;
            int R = grid.Length;
            int C = grid[0].Length;


            Queue<OrangeNode> queue = new Queue<OrangeNode>();

            //Enquing all the rottern oranged
            for (int row = 0; row < R; row++)
            {
                for (int col = 0; col < C; col++)
                {
                    if (grid[row][col] == 2)
                        queue.Enqueue(new OrangeNode(row, col));
                    else if (grid[row][col] == 1)
                        fresh++;    
                }
            }

            OrangeNode delimtter = new OrangeNode(-1, -1);

            if (fresh == 0) return 0;

            int[] ROWS = { 0, 0, -1, 1 };
            int[] COLS = { -1, 1, 0, 0 };

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                if(node.X == -1 && node.Y == -1)
                    timeFrame += 1;
                    
                int row = node.X;
                int col = node.Y;

                bool nodeAdded = false;
                for (int i = 0; i < 4; i++)
                {
                    int nextRow = row + ROWS[i];
                    int nextCol = col + COLS[i];
                    if (!IsSafe(nextRow, nextCol, R, C, grid))
                        continue;

                    nodeAdded = true;
                    grid[nextRow][nextCol] = 2;
                    queue.Enqueue(new OrangeNode(nextRow, nextCol));
                    fresh--;           
                }

                if(nodeAdded)                
                    queue.Enqueue(delimtter);
                
            }

            if (fresh > 0)
                return -1;
            return timeFrame ;
        }

        public static bool IsSafe(int row, int col, int R, int C, int[][] grid)
        {
            return row >= 0 && row < R && col >= 0 && col < C && grid[row][col] == 1;
        }
    }
}
