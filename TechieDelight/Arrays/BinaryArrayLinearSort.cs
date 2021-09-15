using System;

namespace TechieDelight.Arrays
{
    public class BinaryArrayLinearSort
    {
        public static void Driver()
        {
            int[] inputArray = { 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 };

            //int[] output = SortInLinearTime(inputArray);

            SortInLinearTimeNoExtraSpace(inputArray);
            foreach (var num in inputArray)
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

        private static void SortInLinearTimeNoExtraSpace(int[] inputArray)
        {
            if (inputArray.Length < 2)
                return ;

            int zeroPointer = 0;
            int onePointer = inputArray.Length - 1;

            while(zeroPointer < onePointer)
            {
                if (inputArray[zeroPointer] == 0)
                    zeroPointer++;

                if (inputArray[onePointer] == 1)
                    onePointer--;

                if (zeroPointer < onePointer && inputArray[zeroPointer] > inputArray[onePointer])
                {
                    inputArray[onePointer--] = 1;
                    inputArray[zeroPointer++] = 0;
                }
            }
            
        }
    }
}