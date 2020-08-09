using System;

namespace InterviewQuestions
{
    class KnapSackZeroOne
    {
        public static void Driver()
        {
            int[] weights = { 5, 10, 20, 30 };
            int[] profits = { 500, 60, 100, 120 };
            int capacity = 50;
            int arrLength = weights.Length;

            int maxProfit = GetMaxProfitFromKnapSack(profits, weights, capacity, arrLength);
            Console.WriteLine(maxProfit);

            maxProfit = RevisionOneRecursive(profits, weights, capacity, arrLength);
            Console.WriteLine(maxProfit);


            maxProfit = RevisionOneDP(profits, weights, capacity);
            Console.WriteLine(maxProfit);
        }

        private static int GetMaxProfitFromKnapSackRecursively(int[] profits, int[] weights, int capacity, int arrLength)
        {
            if (arrLength == 0 || capacity == 0)
                return 0;

            if (weights[arrLength - 1] > capacity)
                return GetMaxProfitFromKnapSackRecursively(profits, weights, capacity, arrLength - 1);

            return Math.Max(
                profits[arrLength - 1] + GetMaxProfitFromKnapSackRecursively(profits, weights, capacity - weights[arrLength - 1], arrLength - 1),
                GetMaxProfitFromKnapSackRecursively(profits, weights, capacity, arrLength - 1));
        }

        private static int GetMaxProfitFromKnapSack(int[] profits, int[] weights, int capacity, int arrLength)
        {
            int[,] knapsack = new int[arrLength + 1, capacity + 1];

            for (int row = 0; row <= arrLength; row++)
            {
                for (int column = 0; column <= capacity; column++)
                {
                    if (row == 0 || column == 0)
                    {
                        knapsack[row, column] = 0;
                    }
                    else if (weights[row - 1] > column)
                    {
                        knapsack[row, column] = knapsack[row - 1, column];
                    }
                    else
                    {
                        knapsack[row, column] = Math.Max(
                            knapsack[row - 1, column],
                            profits[row - 1] + knapsack[row - 1, column - weights[row - 1]]);
                    }
                }
            }
            return knapsack[arrLength, capacity];
        }

        private static int GetMaxValueRecursively(int[] values, int[] weights, int Capacity, int index)
        {
            if (index == 0 || Capacity == 0) return 0;

            if (Capacity < weights[index - 1])
                return GetMaxValueRecursively(values, weights, Capacity, index - 1);

            return Math.Max(
                values[index - 1] + GetMaxValueRecursively(values, weights, Capacity - weights[index - 1], index - 1),
                GetMaxValueRecursively(values, weights, Capacity, index - 1));
        }

        private static int GetMaxValueFromDP(int[] values, int[] weights, int capacity, int index)
        {
            int[,] knapSack = new int[index + 1, capacity + 1];

            for (int row = 0; row <= index; row++)
            {
                for (int col = 0; col <= capacity; col++)
                {
                    if (row == 0 || col == 0)
                        knapSack[row, col] = 0;
                    else if (weights[row - 1] > col)
                        knapSack[row, col] = knapSack[row - 1, col];
                    else
                    {
                        knapSack[row, col] = Math.Max(
                            knapSack[row - 1, col],
                            values[row - 1] + knapSack[row - 1, col - weights[row - 1]]);
                    }
                }
            }

            return knapSack[index, capacity];
        }

        #region 9th August 2020
        
        //Solved one more time on 9thAugust2020 with Tabular method dynamic programming
        private static int MaxProfitWithTabularMethod(int[] values, int[] weights, int capacity, int index)
        {
            int[,] table = new int[values.Length + 1, capacity + 1];

            for (int currentRow = 0; currentRow <= values.Length; currentRow++)
            {
                for (int currentCol = 0; currentCol <= capacity; currentCol++)
                {
                    if (currentRow == 0 || currentCol == 0)
                    {
                        table[currentRow, currentCol] = 0;
                    }
                    else if (weights[currentRow - 1] > currentCol)
                    {
                        table[currentRow, currentCol] = table[currentRow - 1, currentCol];
                    }
                    else
                    {
                        table[currentRow, currentCol] = Math.Max(
                            table[currentRow - 1, currentCol],
                            values[currentRow - 1] + table[currentRow - 1, currentCol - weights[currentRow - 1]]);
                    }
                }
            }

            return table[values.Length, capacity];
        }

        //Revision One //9th August 2020
        private static int RevisionOneRecursive(int[] profits, int[] weights, int capacity, int arrLength)
        {
            if (arrLength == 0 || capacity == 0) return 0;

            if (weights[arrLength - 1] > capacity)
                return RevisionOneRecursive(profits, weights, capacity, arrLength - 1);

            return Math.Max(
                profits[arrLength - 1] + RevisionOneRecursive(profits, weights, capacity - weights[arrLength - 1], arrLength - 1),
                RevisionOneRecursive(profits, weights, capacity, arrLength - 1));
        }
        
        //Revision One //9th August 2020
        private static int RevisionOneDP(int[] profits, int[] weights, int capacity)
        {
            int[,] knapSack = new int[weights.Length + 1, capacity + 1];

            for (int row = 0; row <= weights.Length; row++)
            {
                for (int col = 0; col <= capacity; col++)
                {
                    if (row == 0 || col == 0)
                    {
                        knapSack[row, col] = 0;
                    }
                    else if (col < weights[row - 1])
                    {
                        knapSack[row, col] = knapSack[row - 1, col];
                    }
                    else
                    {
                        knapSack[row, col] = Math.Max(profits[row - 1] + knapSack[row - 1, col - weights[row - 1]], knapSack[row - 1, col]);
                    }

                }
            }

            return knapSack[weights.Length, capacity];
        }
        #endregion
    }
}
