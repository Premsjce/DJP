using System;

namespace DynamicProgramming
{
    /*
        Objective: Given a rod of length n inches and a table of prices pi, i=1,2,…,n, 
        write an algorithm to find the maximum revenue rn obtainable by cutting up the rod and selling the pieces.
        This is very good basic problem after fibonacci sequence if you are new to Dynamic programming. 
        We will see how the dynamic programming is used to overcome the issues with recursion(Time Complexity).
    
        Given: Rod lengths are integers and For i=1,2,…,n we know the price pi of a rod of length i inches
    
        Example:
    
        Length	1	2	3	4	5	6	7	8	9	10
        Price	1	5	8	9	10	17	17	20	24	30
        
        for rod of length: 4
        Ways to sell :
        •	selling length : 4  ( no cuts) , Price: 9
        •	selling length : 1,1,1,1  ( 3 cuts) , Price: 4
        •	selling length : 1,1,2  ( 2 cuts) , Price: 7
        •	selling length : 2,2  ( 1 cut) , Price: 10
        •	selling length : 3, 1  ( 1 cut) , Price: 9
    
        Best Price for rod of length 4: 10
     */
    public class RodCuttingProblem
    {
        public static void Driver()
        {
            int[] value = { 5, 1, 2 };
            int len = 3;
            Console.WriteLine("Max profit for length is " + len + ":" + CalculateProfit(value, len));
            Console.WriteLine("Max profit for length is " + len + ":" + CalculateProfitWithDP(value, len));
        }
        
        //With recursive approach
        private static int CalculateProfit(int[] value, int len)
        {
            //Boundary checking
            if (len <= 0)
                return 0;
            int max = -1;

            for (int i = 0; i < len; i++)
            {
                max = Math.Max(max, (value[i] + CalculateProfit(value, len - (i + 1))));
            }

            return max;
        }

        //With Dynamic Programming approach
        private static int CalculateProfitWithDP(int[] value, int len)
        {
            int[] solution = new int[len + 1];
            solution[0] = 0;

            for (int i = 1; i <= len; i++)
            {
                int max = -1;
                for (int j = 0; j < i; j++)
                    max = Math.Max(max, (value[j] + solution[i - (j + 1)]));
                solution[i] = max;
            }
            return solution[len];
        }


    }
}
