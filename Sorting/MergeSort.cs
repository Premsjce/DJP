using System;

namespace Sorting
{
    public class MergeSort
    {
        public static void Driver()
        {
            int[] numbers = { 99, 11, 73, 05, 88, 144, 1, 29, 99,};
            int length = numbers.Length - 1;

            MergeRecursive(numbers, 0, length);
            var result = MergerRecursiveWithReturn(numbers);

            Console.WriteLine("After recursion");
            for (int i = 0; i < result.Length; i++) Console.Write($"{result[i]} ");
            Console.WriteLine();
        }

        #region Inplace sorting         
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
        #endregion

        #region Returning Sorted array and Merging
        private static int[] MergerRecursiveWithReturn(int[] numbers)
        {
            if (numbers.Length <= 1)
                return numbers;

            var middle = numbers.Length / 2;
            int[] leftArray = new int[middle];
            int[] rightArray;            

            if (numbers.Length % 2 == 0)
                rightArray = new int[middle];
            else
                rightArray = new int[middle + 1];

            //populate right and left array
            for (int i = 0; i < middle; i++)
                leftArray[i] = numbers[i];

            int Rightindex = 0;
            for(int i = middle; i < numbers.Length; i++)            
                rightArray[Rightindex++] = numbers[i];

            leftArray = MergerRecursiveWithReturn(leftArray);
            rightArray = MergerRecursiveWithReturn(rightArray);

            return Merger(leftArray, rightArray);
        }

        private static int[] Merger(int[] arrayOne, int[] arrayTwo)
        {
            var resultArray = new int[arrayOne.Length + arrayTwo.Length];
            int leftArrayIndex = 0, rightArrayIndex = 0;

            for (int i = 0; i < resultArray.Length; i++)
            {
                if (leftArrayIndex < arrayOne.Length && rightArrayIndex < arrayTwo.Length)
                {
                    if (arrayOne[leftArrayIndex] > arrayTwo[rightArrayIndex])
                        resultArray[i] = arrayTwo[rightArrayIndex++];
                    else
                        resultArray[i] = arrayOne[leftArrayIndex++];
                }
                else if(leftArrayIndex < arrayOne.Length)
                    resultArray[i] = arrayOne[leftArrayIndex++];
                else
                    resultArray[i] = arrayTwo[rightArrayIndex++];
            }

            return resultArray;
        }
        #endregion

    }
}
