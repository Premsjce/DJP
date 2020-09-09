using System;

namespace InterviewQuestions
{
    public class CircularArrayBinarySearch
    {
        public static void Driver()
        {
            int[] circularArray = { 90, 2, 6, 78, 82, 88, 89 };
            int numberToFind = 82;
            int result = GetItemInLogTime(circularArray, numberToFind);
            Console.WriteLine($"Index of the number to be found is : {result}");
        }

        //Idea is to find the pivot by binary search
        //Then divide the array into 2 sub arrays
        //Find the element in sub array by binary searh
        private static int GetItemInLogTime(int[] circularArray, int numberToFind)
        {
            int pivot = FindPivotByBinarySearch(circularArray, 0, circularArray.Length - 1);

            if (pivot == -1)
                return BinarySearch(circularArray, 0, circularArray.Length - 1, numberToFind);

            if (circularArray[pivot] == numberToFind)
                return pivot;

            if (circularArray[0] <= numberToFind)
                return BinarySearch(circularArray, 0, pivot - 1, numberToFind);

            return BinarySearch(circularArray, pivot + 1, circularArray.Length - 1, numberToFind);

        }

        //Its a recursive methos, performing binary search
        private static int FindPivotByBinarySearch(int[] circularArray, int low, int high)
        {
            //Base cases
            if (high < low) return -1;
            if (high == low) return low;

            int mid = (high + low) / 2;

            if (mid < high && circularArray[mid] > circularArray[mid + 1])
                return mid;

            if (mid > low && circularArray[mid] < circularArray[mid - 1])
                return mid - 1;

            if (circularArray[low] >= circularArray[mid])
                return FindPivotByBinarySearch(circularArray, low, mid - 1);

            return FindPivotByBinarySearch(circularArray, mid + 1, high);
        }

        public static int BinarySearch(int[] array, int low, int high, int key)
        {
            //Base conditions
            if (high < low) return -1;

            int mid = low + ((high - low) / 2);

            if (array[mid] == key) return mid;

            if (key < array[mid])
                return BinarySearch(array, low, mid - 1, key);
            return BinarySearch(array, mid + 1, high, key);

        }
    }
}
