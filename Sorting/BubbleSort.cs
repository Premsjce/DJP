using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    //Bubble up the highest or lowest number in array
    class BubbleSort
    {
        public static void Driver()
        {
            var unsortedArray = new int[] { 25, 11, 65, 894, 23, 15, 848, 2365, 1021, 1020, 1, 0 };
            var sortedArray = BubbleSortAlgo(unsortedArray);

            foreach(var i in unsortedArray)
                Console.Write(i + " ");
            Console.WriteLine();
        }

        private static int[] BubbleSortAlgo(int[] unsortedArray)
        {
            for (int i = 0; i < unsortedArray.Length; i++)
            {
                for (int j = 0; j < unsortedArray.Length - 1; j++)
                {
                    if (unsortedArray[j] > unsortedArray[j + 1])
                    {
                        //Swap numbers
                        var temp = unsortedArray[j+1];
                        unsortedArray[j+1] = unsortedArray[j];
                        unsortedArray[j] = temp;
                    }
                }
            }

            return unsortedArray;
        }
    }
}
