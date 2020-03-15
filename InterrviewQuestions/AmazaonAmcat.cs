using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class AmazaonAmcat
    {
        public static void Driver()
        {

            int[,] grid = new int[,] 
            { 
                { 1, 1, 0, 0, 0 },
                { 0, 1, 0, 0, 1 },
                { 1, 0, 0, 1, 1 },
                { 0, 0, 0, 0, 0 },
                { 1, 1, 1, 0, 1 }
            };
            //Console.WriteLine("Number of islands is: " + numberAmazonTreasureTrucks(grid.GetLength(0), grid.GetLength(1), grid));

            var links = new List<List<int>>();

            links.Add(new List<int>() { 1, 2 });
            links.Add(new List<int>() { 1, 3 });
            links.Add(new List<int>() { 2, 4 });
            links.Add(new List<int>() { 3, 4 });
            links.Add(new List<int>() { 3, 6 });
            links.Add(new List<int>() { 6, 7 });
            links.Add(new List<int>() { 4, 5 });

            AmazaonAmcat amazaonAmcat = new AmazaonAmcat();
            var resutl = amazaonAmcat.criticalRouters(7, 7, links);

            foreach(var num in resutl)
                Console.Write(num + " ");
        }

        #region Question 1

        
        // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
        public static int numberAmazonTreasureTrucks(int rows, int column, int[,] grid)
        {
            // WRITE YOUR CODE HERE
            int popUpCount = 0;
            bool[,] visited = new bool[rows, column];

            for(int  currentRow = 0; currentRow < rows; currentRow++)
            {
                for (int currentCol = 0; currentCol < column; currentCol++)
                {
                    if(grid[currentRow,currentCol] == 1 && !visited[currentRow,currentCol])
                    {
                        FindNumberOfPopUpsByDFS(currentRow, currentCol, grid, visited);
                        popUpCount += 1;
                    }
                }
            }

            return popUpCount;

        }

        private static void FindNumberOfPopUpsByDFS(int currentRow, int currentCol, int[,] grid, bool[,] visited)
        {
            visited[currentRow, currentCol] = true;

            int[] ROWS = { 0, 0, -1, 1 };
            int[] COLS = { -1, 1, 0, 0 };

            for (int i = 0; i < 4; i++)
            {
                int nextRow = currentRow + ROWS[i];
                int nextCol = currentCol + COLS[i];

                if (IsSafeAndValid(nextRow, nextCol, grid, visited))
                {        
                    FindNumberOfPopUpsByDFS(nextRow, nextCol, grid, visited);

                    //Else Back track and make visited as false;
                    
                }
            }
        }

        public static bool IsSafeAndValid(int row, int col, int[,] grid, bool[,] visited)
        {
            return row >= 0 && row < grid.GetLength(0) && col >= 0 && col < grid.GetLength(1) &&
                grid[row, col] == 1 && !visited[row, col];
        }

        // METHOD SIGNATURE ENDS
        #endregion


        #region Question 2

        int CurrentRouter;
        int[] Routers;
        int[] Connections;

        Dictionary<int, IList<int>> routerGraph;
        List<int> result;

        // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
        public List<int> criticalRouters(int numRouters, int numLinks,
                                         List<List<int>> links)
        {
            // WRITE YOUR CODE HERE

            // Graph for router connections
            routerGraph = new Dictionary<int, IList<int>>();
            foreach (var link in links)
            {
                int firstNode = link[0];
                int secondNode = link[1];

                if (!routerGraph.ContainsKey(firstNode))
                    routerGraph.Add(firstNode, new List<int>());
                if (!routerGraph.ContainsKey(secondNode))
                    routerGraph.Add(secondNode, new List<int>());

                routerGraph[firstNode].Add(secondNode);
                routerGraph[secondNode].Add(firstNode);
            }

            Routers = new int[numRouters];
            Connections = new int[numLinks];
            CurrentRouter = 0;
            result = new List<int>();

            // Mark all the routers as Unvisted with -1
            for (int i = 0; i < numRouters; i++)
                Routers[i] = -1;

            // Start with the first Unvisted router
            for (int i = 0; i < numRouters; i++)
            {
                if (Routers[i] == -1)
                    DepthSearch(i, -1);
            }
            return result;
        }

        private void DepthSearch(int current, int previous)
        {
            Routers[current] = CurrentRouter;
            Connections[current] = CurrentRouter;
            CurrentRouter++;

            foreach (int next in routerGraph[CurrentRouter])
            {
                // If coming from the same previous node, igonore.
                if (next == previous)
                    continue;

                if (Routers[next - 1] == -1)
                {
                    // Visit the node
                    DepthSearch(next, current);

                    if (Routers[current] < Connections[next])
                        result.Add(current);
                }

                Connections[current] = Math.Min(Connections[current], Connections[next]);
            }
        }

        /*
         * 
         //Else Back track and make visited as false;
         
         */
        // METHOD SIGNATURE ENDS
        #endregion
    }
}