using System;
using System.Collections.Generic;

namespace TechieDelight.DP
{
    /// <summary>
    /// https://www.techiedelight.com/0-1-knapsack-problem/
    /// We are given a set of  items, each item with a Weight and Value
    /// We need to determine the number of items to each include in a collection
    /// so that the total weight is less than or equal to given limit and the 
    /// total value is as large as possible
    /// </summary>
    public class ZeroOneKnapsack
    {
        public static void Drvier()
        {
            int[] weights = { 1, 2, 3, 8, 7, 4 };
            int[] values = { 20, 5, 10, 40, 15, 25 };
            int TotalCapacity = 10;
            int Length = weights.Length - 1;

            int maxValue = FindMaxCapacityByMemoization(weights, values, Length, TotalCapacity, new Dictionary<string, int>());
            //int maxValue = FindMaxCapacityByTabulation(weights, values, TotalCapacity);
            Console.WriteLine($"Max capcaity from given inputs : {maxValue}");
        }

        //Time complexity is exponential  : O(2^ 2n);, becuase we are all occurences at each stage
        private static int FindMaxCapacityByRecursion(int[] weights, int[] values, int totalCapcaity, int index)
        {
            if (totalCapcaity < 0)
                return int.MinValue;

            if (index < 0 || totalCapcaity == 0)
                return 0;

            var includeValue = FindMaxCapacityByRecursion(weights, values, totalCapcaity - weights[index], index - 1) + values[index];
            var excludeValue = FindMaxCapacityByRecursion(weights, values, totalCapcaity, index - 1);

            return Math.Max(includeValue, excludeValue);
        }

        //A better solution would be to use dynamic solution approach..
        //Since proble exhibits overlapping subproblem and optimal substructure properties
        private static int FindMaxCapacityByMemoization(int[] weights, int[] values, int length, int totalCapacity, Dictionary<string, int> lookUp)
        {
            if (totalCapacity < 0)
                return int.MinValue;

            if (length < 0 || totalCapacity == 0)
                return 0;

            string uniqueKey = length + "||" + totalCapacity;

            if (lookUp.ContainsKey(uniqueKey))
                return lookUp[uniqueKey];

            int include = FindMaxCapacityByMemoization(weights, values, length - 1, totalCapacity - weights[length], lookUp) + values[length];
            int exclude = FindMaxCapacityByMemoization(weights, values, length - 1, totalCapacity, lookUp);

            lookUp.Add(uniqueKey, Math.Max(include, exclude));
            return lookUp[uniqueKey];
        }

        private static int FindMaxCapacityByTabulation(int[] weights, int[] values, int totalCapcaity)
        {
            int[,] knapSack = new int[weights.Length + 1, totalCapcaity + 1];

            for(int row =0; row <= weights.Length; row++)
            {
                for(int col =0; col <= totalCapcaity; col++)
                {
                    if (row == 0 || col == 0)
                        knapSack[row, col] = 0;
                    else if (col < weights[row - 1])
                        knapSack[row, col] = knapSack[row - 1, col];
                    else
                    {
                        var include = values[row - 1] + knapSack[row - 1, col - weights[row - 1]];
                        var exclude = knapSack[row - 1, col];
                        knapSack[row, col] = Math.Max(include, exclude);
                    }
                }
            }

            return knapSack[weights.Length, totalCapcaity];
        }
    }
}