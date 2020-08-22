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
            //RBLTree.Driver();
            //TrieDS.Driver();


            //Console.WriteLine("Enter number");
            //int number = int.Parse(Console.ReadLine());

            //Console.Write("Tabulation : ");
            //Console.WriteLine(FindFibonacciDPTabulation(number));

            //Console.Write("Memoization : ");
            //Console.WriteLine(FindFibonacciDPMemoization(number));

            //Console.Write("Recursion : ");
            //Console.WriteLine(FindFibonacciRecursive(number));

            //GraphDS.Driver();

            Console.WriteLine("Press Enter to close");
            Console.ReadLine();
        }

        
        private static long FindFibonacciDPTabulation(int number)
        {
            long[] fibArray = new long[number+1];
            fibArray[0] = 0;
            fibArray[1] = 1;

            for (int i = 2; i <= number; i++)            
                fibArray[i] = fibArray[i - 1] + fibArray[i - 2];

            return fibArray[number];
        }

        static long[] FibSeries = new long[100];
        private static long FindFibonacciDPMemoization(int number)
        {
            if(number < 2)
            {
                FibSeries[0] = 0;
                FibSeries[1] = 1;
                return FibSeries[number];
            }

            if (FibSeries[number] != 0)
                return FibSeries[number];

            FibSeries[number] = FindFibonacciDPMemoization(number - 1) + FindFibonacciDPMemoization(number -2);
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
