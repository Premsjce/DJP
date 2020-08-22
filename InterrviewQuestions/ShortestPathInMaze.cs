using System;

namespace InterviewQuestions
{
    public class ShortestPathInMaze
    {
        // M x N matrix
        private const int M = 10;
        private const int N = 10;

        public static void Driver()
        {
            int[,] mat ={
                { 1, 1, 1, 1, 1, 0, 0, 1, 1, 1 },
                { 0, 1, 1, 1, 1, 1, 0, 1, 0, 1 },
                { 0, 0, 1, 0, 1, 1, 1, 0, 0, 1 },
                { 1, 0, 1, 1, 1, 0, 1, 1, 0, 1 },
                { 0, 0, 0, 1, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 1, 1, 0, 0, 1, 1, 0 },
                { 0, 0, 0, 0, 1, 0, 0, 1, 0, 1 },
                { 0, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
                { 1, 1, 1, 1, 1, 0, 0, 1, 1, 1 },
                { 0, 0, 1, 0, 0, 1, 1, 0, 0, 1 }};

            // construct a matrix to keep track of visited cells
            int[,] visited = new int[M, N];
            int min_dist = FindShortestPath(mat, visited, 0, 0, 7, 5, int.MaxValue, 0);

            if (min_dist != int.MaxValue)
                Console.WriteLine("The shortest path from source to destination has length " + min_dist);
            else
                Console.WriteLine("Destination can't be reached from source");
        }

        private static bool IsSafe(int[,] mat, int[,] visited, int x, int y)
        {
            return !(mat[x, y] == 0 || visited[x, y] != 0);
        }

        private static bool IsValid(int x, int y)
        {
            return x >= 0 && x < M && y >= 0 && y < N;
        }

        private static int FindShortestPath(int[,] mat, int[,] visited, int i, int j, int x, int y, int minDist, int distance)
        {
            //If destination is found, then return the min distance
            if (i == x && y == j)
                return Math.Min(minDist, distance);

            //Mark the cell as visited
            visited[i, j] = 1;
            int[] R = { 1, -1, 0, 0 };
            int[] C = { 0, 0, -1, 1 };

            for (int item = 0; item < 4; item++)
            {
                if (IsValid(i + R[item], j + C[item]) && IsSafe(mat, visited, i + R[item], j + C[item]))
                {
                    minDist = FindShortestPath(mat, visited, i + R[item], j + C[item], x, y, minDist, distance + 1);
                }
            }

            //Backtracking and resetting to 0
            visited[i, j] = 0;

            return minDist;
        }
    }
}
