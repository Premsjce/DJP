using System;

namespace TechieDelight.Arrays
{
    public class BinaryArrayLinearSort
    {
        public static void Driver()
        {
            int[] inputArray = { 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 };

            int[] output = SortInLinearTime(inputArray);

            foreach(var num in output)
                Console.Write($"{num} ");

            Console.WriteLine();
        }

        private static int[] SortInLinearTime(int[] inputArray)
        {
            var onesCount = 0;

            foreach (var num in inputArray)
                if (num == 1)
                    onesCount += 1;
                

            int[] output = new int[inputArray.Length];

            for (int i = onesCount; i < inputArray.Length; i++)
                output[i] = 1;

            return output;
        }
    }
}