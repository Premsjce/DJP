using System;

namespace ProjectEuler
{
    /*
        The prime factors of 13195 are 5, 7, 13 and 29.
        What is the largest prime factor of the number 600851475143 ?
     */

    class Problem3_LargestPrimeFactor
    {
        public static void Driver()
        {            
            var Number = 600851475143;
            var result = GetLargestPrimeFactor(Number);
            Console.WriteLine(result);
        }

        private static long GetLargestPrimeFactor(long number)
        {
            long resultSum = number;            
            if (number % 2 == 0)
                resultSum = number / 2;

            long count = 3;
            while (true)
            {
                if (resultSum % count == 0)
                {
                    resultSum = resultSum / count;
                    if (resultSum == 1)
                        break;
                }
                else
                {
                    while (!IsPrimeNumber(count += 2)) ;
                }        
            }
            return count;         
        }

        private static bool IsPrimeNumber(long number)
        {
            if (number < 4)
                return number > 1;
            if (number % 2 == 0)
                return false;

            long limit = (long)Math.Sqrt(number);
            for (long i = 3; i < limit; i+=2)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

    }
}
