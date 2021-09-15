using System;

namespace TechieDelight.DivideAndConquer
{
    public class BinarySearch
    {
        public static void Driver()
        {
            int[] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 117, 18, 19, 20 };
            var index = BinarySearchAlgo(sortedArray, 19, 0 , sortedArray.Length -1);
            Console.WriteLine($"Index of item 19 is : {index}");
        }

        private static int BinarySearchAlgo(int[] sortedArray, int item, int leftPointer, int rightPointer)
        {
            if (leftPointer > rightPointer)
                return -1;

            int middle = (leftPointer + rightPointer) / 2;
            if (sortedArray[middle] == item)
                return middle;

            if (sortedArray[middle] > item)
                return BinarySearchAlgo(sortedArray, item, leftPointer, middle);
            else
                return BinarySearchAlgo(sortedArray, item, middle+1, rightPointer);
        }
    }
}
