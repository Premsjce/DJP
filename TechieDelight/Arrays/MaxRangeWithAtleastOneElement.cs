using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechieDelight.Arrays
{
    public class MaxRangeWithAtleastOneElement
    {
        public static void Driver()
        {
            int[] first = { 2, 3, 4, 8, 10, 15 };
            int[] second = { 1, 5, 12 };
            int[] third = { 7, 8, 15, 16 };

            Console.WriteLine("\nEfficitent Approach");
            Console.WriteLine(FindMaxRangeEfficient(first, second, third));
        }

        private static Pair FindMaxRangeEfficient(int[] first, int[] second, int[] third)
        {
            int fPtr = 0, sPtr = 0, tPtr = 0;
            int maxDifference = int.MinValue;
            Pair pair = null;
            while(fPtr < first.Length && sPtr < second.Length && tPtr  < third.Length)
            {
                int low = Math.Min(Math.Min(first[fPtr], second[sPtr]), third[tPtr]);
                int high = Math.Max(Math.Max(first[fPtr], second[sPtr]), third[tPtr]);

                if(maxDifference < (high - low))
                {
                    maxDifference = high - low;
                    pair = Pair.Of(low, high);
                }

                if (first[fPtr] == low)
                    fPtr++;
                else if (second[sPtr] == low)
                    sPtr++;
                else
                    tPtr++;
            }

            return pair;
        }
    }
}
