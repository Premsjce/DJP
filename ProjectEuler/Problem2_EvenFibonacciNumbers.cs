﻿using System;

namespace ProjectEuler
{
    /*
     * Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:

            1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...

        By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
     */
    class Problem2_EvenFibonacciNumbers
    {
        public static void Driver()
        {
            var maxNum = 4000000;
            var result = GetEvenFibonacciNumbers(maxNum);
            Console.WriteLine(result);
        }

        private static int GetEvenFibonacciNumbers(int maxNum)
        {
            var sum = 0;
            var result = 0;
            var fib1 = 1;
            var fib2 = 1;
             
            while(sum < maxNum)
            {
                if (result % 2 == 0)
                    sum += result;

                result = fib1 + fib2;
                fib1 = fib2;
                fib2 = result;
            }

            return sum;
        }
    }
}