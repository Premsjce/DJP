using System;

namespace TechieDelight.Arrays
{
    public class MaxDiffBetweenTwoElementsWithConstraint
    {
        public static void Driver()
        {
            int[] array = { 2, 7, 9, 5, 1, 3, 5 };

            var result = GetMaxDiff(array);
            Console.WriteLine($"Max diff from given array is : {result}");
        }

        //Solving in linear time
        //Start from right and traverse toward left
        private static int GetMaxDiff(int[] array)
        {
            int maxDiff = int.MinValue;
            int maxSoFar = array[array.Length - 1];

            for (int i = array.Length - 2; i >= 0; i--)
            {
                if (array[i] > maxSoFar)
                    maxSoFar = array[i];
                else
                    maxDiff = Math.Max(maxDiff, maxSoFar - array[i]);
            }
            return maxDiff;
        }
    }
}
