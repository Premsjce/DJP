using System;

namespace Sorting
{
    public class MergeSort
    {
        public static void Driver()
        {
            int[] numbers = { 99, 11, 73, 05, 88, 144, 1, 29, 99 };
            int length = numbers.Length - 1;

            MergeRecursive(numbers, 0, length);

            Console.WriteLine("After recursion");
            for (int i = 0; i < numbers.Length; i++) Console.Write($"{numbers[i]} ");
            Console.WriteLine();
        }

        private static void MergeRecursive(int[] numbers, int left, int right)
        {
            if (right > left)
            {
                int middle = (right + left) / 2;
                MergeRecursive(numbers, left, middle);
                MergeRecursive(numbers, middle + 1, right);

                MergSortAlgo(numbers, left, middle + 1, right);
            }
        }

        private static void MergSortAlgo(int[] numbers, int leftStart, int rightStart, int rightEnd)
        {
            int[] tempArray = new int[rightEnd + 1];
            int tempPosition = leftStart;
            int noOfElements = rightEnd - leftStart + 1;
            int leftEnd = rightStart - 1;

            while (leftStart <= leftEnd && rightStart <= rightEnd)
            {
                if (numbers[leftStart] <= numbers[rightStart])
                {
                    tempArray[tempPosition] = numbers[leftStart];
                    tempPosition++;
                    leftStart++;
                }
                else
                {
                    tempArray[tempPosition] = numbers[rightStart];
                    tempPosition++;
                    rightStart++;
                }
            }

            while (leftStart <= leftEnd)
            {
                tempArray[tempPosition] = numbers[leftStart];
                tempPosition++;
                leftStart++;
            }


            while (rightStart <= rightEnd)
            {
                tempArray[tempPosition] = numbers[rightStart];
                tempPosition++;
                rightStart++;
            }

            for (int i = 0; i < noOfElements; i++)
            {
                numbers[rightEnd] = tempArray[rightEnd];
                rightEnd--;
            }

        }
    }
}
