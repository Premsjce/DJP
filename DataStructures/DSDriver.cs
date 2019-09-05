using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class DSDriver
    {
        static void Main(string[] args)
        {
            //GraphDS.Driver();
            //BST.Driver();
            //AVLTree.Driver();
            Console.WriteLine("Enter number");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Tabulation : ");
            Console.WriteLine(FindFibonacciDPTabulation(number));

            Console.Write("Memoization : ");
            Console.WriteLine(FindFibonacciDPMemoization(number));

            //Console.Write("Recursion : ");
            //Console.WriteLine(FindFibonacciRecursive(number));

            Console.WriteLine("Press Enter to close");
            Console.ReadLine();
        }

        static long[] FibSeries = new long[100];
        private static long FindFibonacciDPTabulation(int number)
        {

            FibSeries[0] = 0;
            FibSeries[1] = 1;

            for (int i = 2; i <= number; i++)            
                FibSeries[i] = FibSeries[i - 1] + FibSeries[i - 2];

            return FibSeries[number];
        }


        private static long FindFibonacciDPMemoization(int number)
        {
            if(number < 2)
            {
                FibSeries[0] = 0;
                FibSeries[0] = 1;
                return FibSeries[number];
            }

            if (FibSeries[number] != 0)
                return FibSeries[number];

            FibSeries[number] = FibSeries[number - 1] + FibSeries[number - 2];
            return FibSeries[number];
        }

        private static long FindFibonacciRecursive(int number)
        {
            if (number < 2)
                return number;
            return FindFibonacciRecursive(number - 1) + FindFibonacciRecursive(number - 2);
        }
    }
}
