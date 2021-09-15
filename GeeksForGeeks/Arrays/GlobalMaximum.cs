using System;
using System.Collections.Generic;

namespace GeeksForGeeks.Arrays
{
    public class GlobalMaximum
    {
        public static void Driver()
        {
            List<int> arr = new List<int>() { 1, 2, 3, 5 };
            int m = 3;
            Console.WriteLine(FindGlobalMaximum(arr, m));
        }

        private static int FindGlobalMaximum(List<int> arr, int m)
        {
            int globalMax = 0;
            int smallestDiff = 0;
            int maximumDiff = arr[arr.Count - 1] - arr[0];

            while (smallestDiff <= maximumDiff)
            {
                int middleDiff = (smallestDiff + maximumDiff) / 2;

                if (IsSubsequencePresent(arr, m, middleDiff))
                {
                    globalMax = middleDiff;
                    smallestDiff = middleDiff + 1;
                }
                else
                    maximumDiff = middleDiff - 1;
            }

            return globalMax;
        }

        private static bool IsSubsequencePresent(List<int> arr, int m, int diff)
        {
            int count = 1;
            int lastElement = arr[0];

            for (int i = 1; i < arr.Count; i++)
            {
                if (arr[i] - lastElement >= diff)
                {
                    lastElement = arr[i];
                    count++;
                    if (count == m)
                        return true;
                }
            }

            return false;
        }
    }
}