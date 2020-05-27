using System;

namespace TechieDelight.DivideAndConquer
{
    public class BinarySearch
    {
        public static void Driver()
        {
            int[] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 117, 18, 19, 20 };
            BinarySearchAlgo(sortedArray, 19, 0 , sortedArray.Length -1);
        }

        private static void BinarySearchAlgo(int[] sortedArray, int item, int start, int last)
        {
            int middle = (start + last) / 2;
            if(sortedArray[middle] == item)
            {
                Console.Write($"Found {item} at index location {middle} ");
                return;
            }

            if (sortedArray[middle] > item)
                BinarySearchAlgo(sortedArray, item, start, middle);
            else
                BinarySearchAlgo(sortedArray, item, middle+1, last);
        }
    }
}
