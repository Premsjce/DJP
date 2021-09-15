using System;
using System.Collections.Generic;

namespace Sorting
{
    public class HeapSort
    {
        public static void Driver()
        {
            int[] array = { 55, 25, 89, 34, 12, 19, 78, 95, 1, 100,1 };

            Console.WriteLine("Unsorted Array");
            PrintArray(array);

            MinHeap heapDataStructure = new MinHeap();
            foreach(var num in array)
                heapDataStructure.Push(num);

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
    }

    public class MinHeap
    {
        private List<int> _baseHeap;

        public MinHeap()
        {
            _baseHeap = new List<int>();
        }

        public void Push(int item)
        {
            _baseHeap.Add(item);
            HeapifyUp();
        }

        public int Pop()
        {
            if (_baseHeap.Count == 0)
                throw new Exception("Heap is empty");

            var lastIndex = _baseHeap.Count - 1;
            var item = _baseHeap[0];
            _baseHeap[0] = _baseHeap[lastIndex];
            _baseHeap.RemoveAt(lastIndex);
            HeapifyDown();
            return item;
        }

        public int Peek()
        {
            if (_baseHeap.Count == 0)
                throw new Exception("Heap is empty");
            return _baseHeap[0];
        }


        private void HeapifyUp()
        {
            int childIndex = _baseHeap.Count - 1;
            int parentIndex = (childIndex - 1) / 2;

            while (_baseHeap[parentIndex] > _baseHeap[childIndex] && parentIndex >= 0)
            {
                Swap(parentIndex, childIndex);
                childIndex = parentIndex;
                parentIndex = (childIndex - 1) / 2; ;
            }
        }

        private void HeapifyDown()
        {
            int heapLength = _baseHeap.Count;
            int parentIndex = 0;

            int leftChildIndex = (2 * parentIndex) + 1;
            int rightChildIndex = (2 * parentIndex) + 2;

            while (leftChildIndex < heapLength && rightChildIndex < heapLength
                && (_baseHeap[parentIndex] > _baseHeap[leftChildIndex] || _baseHeap[parentIndex] > _baseHeap[rightChildIndex]))
            {
                if (_baseHeap[leftChildIndex] < _baseHeap[rightChildIndex])
                {
                    Swap(parentIndex, leftChildIndex);
                    parentIndex = leftChildIndex;
                }
                else
                {
                    Swap(parentIndex, rightChildIndex);
                    parentIndex = rightChildIndex;
                }                

                leftChildIndex = (2 * parentIndex) + 1;
                rightChildIndex = (2 * parentIndex) + 2;
            }
        }

        private void Swap(int parentIndex, int childIndex)
        {
            var temp = _baseHeap[parentIndex];
            _baseHeap[parentIndex] = _baseHeap[childIndex];
            _baseHeap[childIndex] = temp;
        }
    }

    
}
