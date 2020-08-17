using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class DistinctArrayFormationBySwapping2Numbers
    {
        public static void Driver()
        {
            int[] numbers = { 2, 3, 2, 3, 3 };
            int result = GetNoOfDistinctArray(numbers);
            Console.WriteLine("Total distint combinations can be : " + result);
        }

        private static int GetNoOfDistinctArray(int[] numbers)
        {
            //if its 0, the also combincation is 1
            //if array size is 1, then no of combinaiton is 1
            //if array size is 2, then no of combination is 2
            //if array size is 3, then no of combination is 3
            //if array size is 4, then no of combination is 5
            //It adds on previous 2 values, kind of fibonacci sequence

            //i.e for n numbers, soluntion will be (n-1) + (n-2)

            int[] combinations = new int[numbers.Length + 1];
            combinations[0] = 1;
            combinations[1] = 1;

            for (int i = 2; i <= numbers.Length; i++)
            {
                combinations[i] = combinations[i - 1] + combinations[i - 2];
            }

            return combinations[numbers.Length];
        }
    }
}
