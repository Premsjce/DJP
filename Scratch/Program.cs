using System;
using System.Collections.Generic;

namespace Scratch
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(GuessGame(10));

            //AccesModifiers.Driver();

            //var list = new List<int>();
            //list.Add(73);
            //list.Add(67);
            //list.Add(38);
            //list.Add(33);
            //Console.WriteLine(GradingStudents(list));
            int[] ar = { 10, 20, 20, 10, 10, 30, 50, 10, 20 };
            Console.WriteLine(SockMerchant(ar));



            int[] A = { 2, 4, -6, 0, -1, 0, 0, 2 };
            if (ZeroSumSubarray(A))
                Console.WriteLine("Subarray exists");
            else
                Console.WriteLine("Subarray do not exist");
        }

        public static List<int> GradingStudents(List<int> grades)
        {
            var result = new List<int>();

            foreach (var grade in grades)
            {
                if (grade > 38 && (grade % 5) > 2)
                {
                    result.Add(grade + (5 - (grade % 5)));
                }
                else
                {
                    result.Add(grade);
                }
            }

            return result;
        }

        private static bool ZeroSumSubarray(int[] A)
        {
            // create an empty set to store sum of elements of each
            // sub-array A[0..i] where 0 <= i < arr.length
            HashSet<int> set = new HashSet<int>();

            // insert 0 into set to handle the case when sub-array with
            // 0 sum starts from index 0
            set.Add(0);

            int sum = 0;

            // traverse the given array
            for (int i = 0; i < A.Length; i++)
            {
                // sum of elements so far
                if (A[i] != 0)
                {
                    sum += A[i];

                    // if sum is seen before, we have found a sub-array with 0 sum
                    if (set.Contains(sum))
                    {
                        return true;
                    }

                    // insert sum so far into set
                    set.Add(sum);
                }

            }

            // we reach here when no sub-array with 0 sum exists
            return false;
        }

        // Complete the sockMerchant function below.
        public static int SockMerchant(int[] ar)
        {
            Dictionary<int, bool> hashMap = new Dictionary<int, bool>();
            int count = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (!hashMap.ContainsKey(ar[i]))
                    hashMap.Add(ar[i], true);
                else
                    hashMap[ar[i]] = !hashMap[ar[i]];
            }

            foreach (var key in hashMap.Keys)
            {
                if (hashMap[key])
                    count += 1;
            }

            
            return count;

        }

        public static int GuessAPI(int num)
        {
            if (num == 6) return 0;
            else if (num > 6) return 1;
            else return -1;
        }

        public static int GuessGame(int n)
        {
            int middle = n / 2;
            var guessNum = GuessAPI(middle);

            if (guessNum == 0)
                return middle;
            else if (guessNum == -1)
                return GuessGame(2*n);
            else
                return GuessGame(middle + 1);
        }
    }
}
