using System;

namespace TechieDelight.Arrays
{
    public class MaxProfixFromKStockTransactions
    {
        public static void Driver()
        {
            int[] array = { 2, 4, 7, 5, 4, 3, 5 };
            int k = 3;
            int result = GetMaxProfit(array, k);
            Console.WriteLine($"{result}");
        }

        private static int GetMaxProfit(int[] prices, int k)
        {
            int n = prices.Length;

            //profits[i][j] stores max profit gained by doing most i transaction till jth day
            int[,] profits = new int[k + 1, n + 1];

            //fill profit[,] from bottom up fashion
            for (int i = 0; i <= k; i++)
            {
                int prevDiff = int.MinValue;
                for(int j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0)
                        profits[i, j] = 0;
                    else
                    {
                        prevDiff = Math.Max(prevDiff, profits[i - 1, j - 1] -  prices[i-j]);
                        profits[i, j] = Math.Max(profits[i, j - 1], prices[j] + prevDiff);
                    }   
                }
            }
            return profits[k, n - 1]; ;
        }

    }
}
