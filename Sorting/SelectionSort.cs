using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class SelectionSort
    {
        public static void Driver()
        {
            var unsortedArray = new int[] { 25, 11, 65, 894, 23, 15, 848, 2365, 1021, 1020, 1, 0 };
            //var unsortedArray = new int[] { 3, 1, 0 };

            var sortedArray = SelectionSortAlgo(unsortedArray);

            foreach (var i in unsortedArray)
                Console.Write(i + " ");
            Console.WriteLine();
        }

        private static int[] SelectionSortAlgo(int[] unsortedArray)
        {
            
            for (int i = 0; i < unsortedArray.Length; i++)
            {
                var minIndex = i;
                for (int j = i + 1; j < unsortedArray.Length; j++)
                {
                    if (unsortedArray[j] < unsortedArray[minIndex])
                        minIndex = j;
                }

                //Swap 
                var temp = unsortedArray[i];
                unsortedArray[i] = unsortedArray[minIndex];
                unsortedArray[minIndex] = temp;
            }

            return unsortedArray;
        }
    }
}
