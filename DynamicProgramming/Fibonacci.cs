using System;
using System.Diagnostics;

namespace DynamicProgramming
{
    class Fibonacci
    {
        static long[] resultExists;

        public static void Driver()
        {

            Stopwatch stopwatch = new Stopwatch();
            long number = 100;

            //stopwatch.Start();
            //var result = GetFibonacciRecursively(number);
            //stopwatch.Stop();
            //Console.WriteLine($"Recursive function for {number} takes {stopwatch.ElapsedMilliseconds / 1000} seconds, \nand result is {result}");
            //Console.WriteLine();

            stopwatch.Restart();
            resultExists = new long[number + 1];
            var result = GetFibonacciByMemoization(number);
            stopwatch.Stop();
            Console.WriteLine($"Memoization function for {number} takes {stopwatch.ElapsedMilliseconds } Milliseconds, \nand result is {result}");
            Console.WriteLine();


            stopwatch.Restart();
            resultExists = new long[number + 1];
            result = GetFibonaciByIteration(number);
            stopwatch.Stop();
            Console.WriteLine($"Iteration function for {number} takes {stopwatch.ElapsedMilliseconds  } Milliseconds, \nand result is {result}");
            Console.WriteLine();
        }



        public static long GetFibonacciRecursively(long number)
        {
            if (number < 2)
                return number;
            return GetFibonacciRecursively(number - 1) + GetFibonacciRecursively(number - 2);
        }

        //Top Down approach : Memoization
        public static long GetFibonacciByMemoization(long number)
        {
            if (resultExists[number] == 0)
            {
                if (number < 2)
                    resultExists[number] = number;
                else
                    resultExists[number] = GetFibonacciByMemoization(number - 1) + GetFibonacciByMemoization(number - 2);
            }

            return resultExists[number];
        }

        //Botton up approach : Tabulation
        public static long GetFibonaciByIteration(long number)
        {
            if (number < 2)
                return number;

            long[] lookp = new long[number + 1];
            lookp[0] = 0;
            lookp[1] = 1;

            for (int i = 2; i <= number; i++)
                lookp[i] = lookp[i - 1] + lookp[i - 2];

            return lookp[number];
        }
    }
}
