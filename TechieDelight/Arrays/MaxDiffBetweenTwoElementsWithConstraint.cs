using System;

namespace TechieDelight.Arrays
{
    public class MaxDiffBetweenTwoElementsWithConstraint
    {
        public static void Driver()
        {
            int[] array = { 2, 7, 9, 5, 1, 3, 5 };

            var naiveResult = GetMaxDiffBruteForce(array);
            var efficientResult = GetMaxDiff(array);
            var simpleResult = GetDiffWithMaxAndMinNumbers(array);
            Console.WriteLine($"Max diff Brute Force : {naiveResult}");
            Console.WriteLine($"Max diff Efficient   : {efficientResult}");
            Console.WriteLine($"Max diff Efficient   : {simpleResult}");
        }

        //Time Complexity is O(n^2)
        private static int GetMaxDiffBruteForce(int[] array)
        {
            int maxDiff = int.MinValue;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    var diff = array[j] - array[i];
                    maxDiff = Math.Max(diff, maxDiff);
                }
            }
            return maxDiff;
        }

        //Solving in linear time, Start from right and traverse toward left
        private static int GetMaxDiff(int[] array)
        {
            int maxDifference = int.MinValue;
            int maxSoFar = array[array.Length - 1];

            for(int i = array.Length-2; i >=0; i--)
            {
                maxSoFar = Math.Max(maxSoFar, array[i]);
                maxDifference = Math.Max(maxDifference, maxSoFar - array[i]);
            }

            return maxDifference;
        }

        //Constraint is that larger elemetn appears after the smaller element
        private static int GetDiffWithMaxAndMinNumbers(int[] array)
        {
            int maxNum = array[array.Length - 1];
            int diff = int.MinValue;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                maxNum = Math.Max(maxNum, array[i]);
                diff = Math.Max(diff, maxNum - array[i]);
            }

            return diff;            
        }
    }
}
