using System;

namespace ProjectEuler
{
    //If we list all the natural numbers below 10 that are multiples of 3 or 5, 
    //we get 3, 5, 6 and 9. The sum of these multiples is 23.
    //Find the sum of all the multiples of 3 or 5 below 1000.
    class Problem1_MultiplesOf3And5
    {
        public static void Driver()
        {
            var MaxNum = 1000;
            int result = GetSumOfMultiplesOf3And5(MaxNum);
            Console.WriteLine(result);
        }

        private static int GetSumOfMultiplesOf3And5(int maxNum)
        {
            var sum = 0;
            for (int i = 1; i < maxNum; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;
            }
            return sum;
        }
    }
}
