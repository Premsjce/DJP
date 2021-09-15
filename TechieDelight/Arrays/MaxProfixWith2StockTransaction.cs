using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechieDelight.Arrays
{
    /*
     * https://www.techiedelight.com/find-maximum-profit-earned-from-at-most-two-stock-transactions/
     * Given a list of futuer prediction share prices, find max profit that can be earned by 
     * buying and selling shares at most twice with a constraint that a new transaction can only start
     * after previous transaction has been complete. 
     * i.e. we can only hold at most one share at a time
     */
    public class MaxProfixWith2StockTransaction
    {
        public static void Driver()
        {
            int[] stockPrices = { 2, 4, 7, 5, 4, 3, 5 };
            var maxProfit = GetMaxProfitFrom2Transactions(stockPrices);
            var maxProfit2 = GetMaxProfitFor2Stock(stockPrices);

            Console.WriteLine($"Maximum profit that can be achived with above prices are : {maxProfit}");

            Console.WriteLine($"Maximum profit that 2 Stoks: {maxProfit2}");
        }

        private static int GetMaxProfitFrom2Transactions(int[] stockPrices)
        {
            int n = stockPrices.Length;
            //Use auxillarry space
            int[] profits = new int[n];

            //First run to get Max price from right to left
            int maxSoFar = stockPrices[n - 1];
            profits[n - 1] = 0;

            for (int i = n - 2; i >= 0; i--)
            {
                profits[i] = Math.Max(profits[i + 1], maxSoFar - stockPrices[i]);
                maxSoFar = Math.Max(maxSoFar, stockPrices[i]);
            }

            //Second run which goes from left to right
            int minSoFar = stockPrices[0];
            for (int i = 1; i < n; i++)
            {
                profits[i] = Math.Max(profits[i - 1], (stockPrices[i] - minSoFar) + profits[i]);
                minSoFar = Math.Min(minSoFar, stockPrices[i]);
            }

            return profits[n - 1];
        }

        private static int GetMaxProfitFor2Stock(int[] prices)
        {
            int[] profits = new int[prices.Length];

            int maxSoFar = prices[prices.Length - 1];
            int maxProfitTillNow = int.MinValue;

            for (int i = prices.Length - 2; i >= 0; i--)
            {
                maxSoFar = Math.Max(maxSoFar, prices[i]);
                maxProfitTillNow = Math.Max(maxProfitTillNow, maxSoFar - prices[i]);
                profits[i] = maxProfitTillNow;
            }

            int minSoFar = prices[0];
            maxProfitTillNow = profits[0];

            for (int i = 1; i < prices.Length; i++)
            {
                int profitTillNow = prices[i] - minSoFar + profits[i];
                maxProfitTillNow = Math.Max(maxProfitTillNow, profitTillNow);
                profits[i] = maxProfitTillNow;
            }

            return profits[prices.Length - 1];
        }
    }
}