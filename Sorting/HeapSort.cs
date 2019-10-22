using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class HeapSort
    {
        public static void Driver()
        {
            int[] array = { 55, 25, 89, 34, 12, 19, 78, 95, 1, 100 };

            Console.WriteLine("Unsorted Array");
            PrintArray(array);

            HeapSortAlgo(array, array.Length);

            Console.WriteLine();
            Console.WriteLine("Sorted Array");
            PrintArray(array);

            Console.WriteLine();
        }

        private static void PrintArray(int[] array)
        {
            foreach (var num in array)
                Console.Write(num + "\t");
        }

        private static void HeapSortAlgo(int[] array, int length)
        {
            for (int index = length / 2 - 1; index >= 0; index--)
                HeapifyUp(array, length, index);

            for (int i = length - 1; i >= 0; i--)
            {
                //Swap last element (root element) with indeices
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;
                HeapifyUp(array, i, 0);
            }
        }

        private static void HeapifyUp(int[] array, int length, int index)
        {
            int largest = index;
            int left = 2 * index + 1;
            int right = 2 * index + 2;

            if (left < length && array[left] > array[largest])
                largest = left;

            if (right < length && array[right] > array[largest])
                largest = right;

            if (largest != index)
            {
                //Swap
                int temp = array[index];
                array[index] = array[largest];
                array[largest] = temp;
                HeapifyUp(array, length, largest);
            }

        }
    }
}
