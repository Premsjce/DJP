using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    class KnapSackZeroOne
    {
        public static void Driver()
        {
            int[] profits = { 60, 100, 120 };
            int[] weights = { 10, 20, 30 };
            int Capacity = 50;
            int arrLength = profits.Length;

            int maxProfit = GetMaxProfitFromKnapSack(profits, weights, Capacity, arrLength);
            Console.WriteLine(maxProfit);
        }

        private static int GetMaxProfitFromKnapSackRecursively(int[] profits, int[] weights, int capacity, int arrLength)
        {
            if (arrLength == 0 || capacity == 0)
                return 0;

            if (weights[arrLength - 1] > capacity)
                return GetMaxProfitFromKnapSackRecursively(profits, weights, capacity, arrLength - 1);
            else
                return Math.Max(profits[arrLength - 1] + GetMaxProfitFromKnapSackRecursively(profits, weights, capacity - weights[arrLength - 1], arrLength - 1),
                    GetMaxProfitFromKnapSackRecursively(profits, weights, capacity, arrLength - 1));
        }

        private static int GetMaxProfitFromKnapSack(int[] profits, int[] weights, int capacity, int arrLength)
        {            
            int[,] knapsack = new int[arrLength + 1, capacity + 1];

            for (int row = 0; row <= arrLength; row++)
            {
                for(int column=  0; column <= capacity; column++)
                {
                    if (row == 0 || column == 0)
                        knapsack[row, column] = 0;
                    else if (weights[row - 1] <= column)
                    {
                        knapsack[row, column] = Math.Max(
                            knapsack[row - 1, column],
                            profits[row - 1] + knapsack[row - 1, column - weights[row - 1]]);
                    }
                    else
                        knapsack[row, column] = knapsack[row - 1, column];
                        
                }
            }
            return knapsack[arrLength, capacity];
        }
    }
}
