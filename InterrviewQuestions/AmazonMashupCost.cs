using System;
using System.Collections;
using System.Collections.Generic;

namespace InterviewQuestions
{
    public class AmazonMashupCost
    {
        public static void Driver()
        {
            Console.WriteLine(GetProcessingCost(new int[] { 1, 2, 4, 9 }));

            Console.WriteLine(FindSmallestPositiveInteger(new int[] { -3, -1, 1, 2, 3, 4 }));
        }

        public static int GetProcessingCost(int[] inputSongs)
        {
            //Base validation
            if (inputSongs.Length <= 0)
                return -1;

            if (inputSongs.Length == 1)
                return inputSongs[0];

            int totalCost = inputSongs[0] + inputSongs[1];
            int mashupCost = inputSongs[0] + inputSongs[1];
            for (int i = 2; i < inputSongs.Length; i++)
            {
                totalCost += inputSongs[i];
                mashupCost += totalCost;
            }

            return mashupCost;

        }
        
        public static int FindSmallestPositiveInteger(int[] inputArray)
        {
            //Base validation 
            if (inputArray == null || inputArray.Length == 0)
                return 0;

            int minNum = int.MaxValue;
            int maxNum = int.MinValue;

            for (int i = 0; i < inputArray.Length; i++)
            {
                maxNum = Math.Max(maxNum, inputArray[i]);
                if (inputArray[i] > 0)
                    minNum = Math.Min(minNum, inputArray[i]);

                if (inputArray[i] <= 0)
                    inputArray[i] = 1;
            }

            if (minNum == int.MaxValue || minNum > 1)
                return 1;

            int position;
            for (int i = 0; i < inputArray.Length; i++)
            {
                position = Math.Abs(inputArray[i]);
                if (position - minNum >= inputArray.Length)
                    continue;
                inputArray[position - minNum] = -Math.Abs(inputArray[position - minNum]);
            }

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] > 0)
                    return i + 1;

            }
            return maxNum + 1;

        }
    }
}
