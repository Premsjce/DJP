using System;
using System.Diagnostics;
using System.Threading;

namespace InterviewQuestions
{
    class FindFibonacci
    {
        public static void Driver()
        {
            Console.WriteLine("Please enter the number you want to find fibonnaci till");
            var number = int.Parse(Console.ReadLine());
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine(NormalFibonnaci(number));
            stopwatch.Stop();
            Console.WriteLine($"Recursive Program : {stopwatch.ElapsedMilliseconds}");

            //stopwatch.Restart();
            //Console.WriteLine(DynamicProgrammingFibonacci(number));
            //stopwatch.Stop();
            //Console.WriteLine($"Dynamic Program : {stopwatch.ElapsedMilliseconds}");
        }

        //its recursice
        private static decimal NormalFibonnaci(int number)
        {
            if (number <= 1)
                return number;
            return NormalFibonnaci(number - 1) + NormalFibonnaci(number - 2);
        }

        //its iterative code
        private static decimal DynamicProgrammingFibonacci(int number)
        {
            //Storing one exra index for case 0
            decimal[] fib = new decimal[number+1];

            //initial values
            fib[0] = 0;
            fib[1] = 1;

            for (int i = 2; i <= number; i++)
                fib[i] = fib[i - 1] + fib[i - 2];

            return fib[number];
        }
    }
}
