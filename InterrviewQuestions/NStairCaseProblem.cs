using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class NStairCaseProblem
    {
        public static void Driver()
        {
            int stairs = 10;
            int[] set = { 1, 3, 5 };
            int result = GetNoOfCombinationOfStaies(stairs, set);
            Console.WriteLine($"No of Differenct combibation are : {result}");
        }

        //Dyamic Programming : With Memoization
        private static int GetNoOfCombinationOfStaies(int stairs, int[] set)
        {
            if (stairs < 0)
                return 0;
            int[] cache = new int[stairs + 1];
            cache[0] = 1;

            for (int i = 1; i <= stairs; i++)
                foreach (var s in set)
                    if (s <= i)
                        cache[i] += cache[i - s];

            return cache[stairs];
        }

        //Time consuming Recursive solution
        private static int GetNoOfCombinationOfStaiesRecursively(int stairs, int[] set)
        {
            if (stairs < 0)
                return 0;
            if (stairs == 0)
                return 1;
            int sum = 0;
            foreach (var num in set)
                sum += GetNoOfCombinationOfStaies(stairs - num, set);

            return sum;            
        }
    }
}
