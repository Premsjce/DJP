using System.Collections.Generic;

namespace TechieDelight.Arrays
{
    public class SubArrayWithZeroSum
    {
        /*
         * https://www.techiedelight.com/check-subarray-with-0-sum-exists-not/
         * Check if in given array, any contiguous sub array has a net sum of 0
         */

        public static void Driver()
        {
            int[] array = { 3, 4, 7, 3, 1, 3, 1, -4, -2, -2 };

            var result = ZeroSumSubArray(array);
        }

        private static bool ZeroSumSubArray(int[] array)
        {
            HashSet<int> set = new HashSet<int>();
            int sum = 0;
            set.Add(sum);

            foreach(var num in array)
            {
                sum += num;

                if (set.Contains(sum))
                    return true;
                set.Add(sum);
            }

            return false;
        }
    }
}
