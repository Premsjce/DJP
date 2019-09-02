using System;

namespace ProjectEuler
{
    class Problem7_10001stPrimeNumber
    {
        public static void Driver()
        {
            long primeNumber = GetNthPrimeNumber(10001);
            Console.WriteLine(primeNumber);            
        }

        private static long GetNthPrimeNumber(int number)
        {
            long primeNumber = 3;
            int primeNumberCounter = 1;

            while (primeNumberCounter < number)
            {
                if (IsPrimeNumber(primeNumber))
                    primeNumberCounter++;
                primeNumber += 2;
            }
            primeNumber -= 2;
            return primeNumber;
        }

        private static bool IsPrimeNumber(long number)
        {
            if (number < 4)
                return number > 1;
            if (number % 2 == 0)
                return false;

            long limit = (long)Math.Sqrt(number);
            for (long i = 3; i <= limit; i += 2)
            {
                if (number % i == 0)
                    return false;
            }
            return true;

        }
    }
}
