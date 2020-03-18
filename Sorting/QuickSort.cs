using System;

namespace Sorting
{
    public class QuickSort
    {
        public static void Driver()
        {
            int[] numbers = { 99, 11, 73, 05, 88, 144, 1, 29, 99 };
            Console.WriteLine("Before Sorting");
            foreach (var num in numbers)
                Console.Write(num + " ");

            QuickSortArray(numbers, 0, numbers.Length - 1);

            Console.WriteLine("After Sorting");
            foreach (var num in numbers)
                Console.Write(num + " ");

        }

        private static void QuickSortArray(int[] numbers, int start, int end)
        {
            if (start >= end) return;

            int partitionIndex = PartitionArray(numbers, start, end);

            QuickSortArray(numbers, start, partitionIndex - 1);
            QuickSortArray(numbers, partitionIndex + 1, end);
        }

        //Dealing with Indices here
        private static int PartitionArray(int[] numbers, int start, int end)
        {
            int pivot = numbers[end];
            int pIndex = start;
            for (int i = start; i < end; i++)
            {
                if (numbers[i] <= pivot)
                {
                    SwapNumbers(numbers, i, pIndex);
                    pIndex += 1;
                }
            }
            SwapNumbers(numbers, pIndex, end);
            return pIndex;
        }

        private static void SwapNumbers(int[] numbers, int start, int i)
        {
            var temp = numbers[start];
            numbers[start] = numbers[i];
            numbers[i] = temp;

        }
    }
}
