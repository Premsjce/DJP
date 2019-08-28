using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Problem6_SumSquareDifference
    {
        public static void Driver()
        {
            int n = 100;
            var result = GetSumSquareDiff(n);
            Console.WriteLine(result);
        }

        private static long GetSumSquareDiff(int numbers)
        {
            int SumOfSquares = 0;
            int SumOfNumbers = 0;

            for(int i=1; i<= numbers;i++)
            {
                SumOfNumbers += i;
                SumOfSquares += (i * i);
            }

            return (SumOfNumbers * SumOfNumbers) - SumOfSquares;
        }
    }
}
