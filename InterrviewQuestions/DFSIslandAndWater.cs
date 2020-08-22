using System;

namespace InterviewQuestions
{
    public class DFSIslandAndWater
    {
        public static void Driver()
        {
            int[,] M = new int[,] { { 1, 1, 1, 1, 1 },
                                    { 0, 0, 1, 0, 1 },
                                    { 1, 1, 1, 0, 1 },
                                    { 0, 0, 0, 0, 1 },
                                    { 1, 0, 1, 0, 1 } };
            int max = 6;
            Console.WriteLine($"Number of islands gretaer that count {max} is: " + NoOfIslands(M, max));
        }

        public static int NoOfIslands(int[,] islands, int max)
        {
            var ROWSLENGTH  = islands.GetLength(0);
            var COLUMNSLENGTH = islands.GetLength(1);
            bool[,] visited = new bool[ROWSLENGTH, COLUMNSLENGTH];
            int maxlandCount = 0;

            for (int row = 0; row < ROWSLENGTH; ++row)
            {
                for(int column = 0; column < COLUMNSLENGTH; ++column)
                {
                    if (islands[row, column] == 1 && !visited[row, column])
                    {
                        var count  = DFS(islands, row, column, visited, ROWSLENGTH, COLUMNSLENGTH);
                        if (count > max)
                            maxlandCount++;
                    }
                }
            }

            return maxlandCount;
        }

        private static int DFS(int[,] islands, int row, int column, bool[,] visited, int ROWSLENGTH, int COLUMNSLENGTH)
        {
            visited[row, column] = true;            

            //Sorrounding islands reaching vector. 8 values will be there around islands all the time
            int[] rowNumber = new int[] { -1, -1, -1,  0, 0,  1, 1, 1 };
            int[] colNumber = new int[] { -1,  0,  1, -1, 1, -1, 0, 1 };
            var result = 1;

            //Recursively call for all connected neighbours
            for (int i = 0; i < 8; ++i)
            {
                int nextRow = row + rowNumber[i];
                int nextCol = column + colNumber[i];
                if (nextRow >= 0 && nextRow < ROWSLENGTH && nextCol >= 0 && nextCol < COLUMNSLENGTH && islands[nextRow, nextCol] == 1 && !visited[nextRow, nextCol])
                {
                    result += DFS(islands, nextRow, nextCol, visited, ROWSLENGTH, COLUMNSLENGTH) + 1;
                }   
            }

            return result;
        }
    }
}

