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

            HeapDataStructure heapDataStructure = new HeapDataStructure();
            heapDataStructure.AddRange(array);

            Console.WriteLine();
            Console.WriteLine("Sorted Array");
            for (int i = 0;i < array.Length;i++)
                Console.Write(heapDataStructure.Pop() + "\t");

            //HeapSortAlgo(array, array.Length);

            //Console.WriteLine();
            //Console.WriteLine("Sorted Array");
            //PrintArray(array);

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

    public class HeapDataStructure
    {
        private List<int> baseHeap = new List<int>();

        public void AddRange(int[] nums)
        {
            foreach (var num in nums)
                Push(num);
        }

        public void Push(int num)
        {
            baseHeap.Add(num);
            HeapifyUp();
        }

        public int Pop()
        {
            var lastIndex = baseHeap.Count - 1;
            var num = baseHeap[0];
            baseHeap[0] = baseHeap[lastIndex];
            baseHeap.RemoveAt(lastIndex);
            HeapifyDown();
            return num;
        }
        
        public int Peek() => baseHeap[0];

        private void HeapifyUp()
        {
            int currentIndex = baseHeap.Count - 1;
            int parentIndex = (currentIndex - 1) / 2;

            while (currentIndex > 0)
            {
                if(baseHeap[currentIndex] < baseHeap[parentIndex])
                {
                    var temp = baseHeap[parentIndex];
                    baseHeap[parentIndex] = baseHeap[currentIndex];
                    baseHeap[currentIndex] = temp;
                }
                currentIndex = parentIndex;
                parentIndex = (currentIndex - 1) / 2;
            }

        }
        
        private void HeapifyDown()
        {
            int currentIndex = 0;
            int leftChild = (currentIndex * 2) + 1;
            int rightChild = (currentIndex * 2) + 2;

            while (leftChild < baseHeap.Count && rightChild < baseHeap.Count && (baseHeap[currentIndex] > baseHeap[leftChild] || baseHeap[currentIndex] > baseHeap[rightChild]))
            {
                if(baseHeap[leftChild] < baseHeap[rightChild])
                {
                    var temp = baseHeap[leftChild];
                    baseHeap[leftChild] = baseHeap[currentIndex];
                    baseHeap[currentIndex] = temp;

                    currentIndex = leftChild;
                }
                else
                {
                    var temp = baseHeap[rightChild];
                    baseHeap[rightChild] = baseHeap[currentIndex];
                    baseHeap[currentIndex] = temp;

                    currentIndex = rightChild;
                }
                leftChild = (currentIndex * 2) + 1;
                rightChild = (currentIndex * 2) + 2;
            }
        }
    }
}
