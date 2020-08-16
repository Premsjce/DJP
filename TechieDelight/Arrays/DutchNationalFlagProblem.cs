using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechieDelight.Arrays
{
    public class DutchNationalFlagProblem
    {
        //Sort the given array containing 0,1,2 in linear time

        public static void Driver()
        {
            //int[] array = { 1, 2,0, 1, 2, 1, 1, 0, 2, 0, 2, 1, 0, 1, 2 };
            int[] array = { 1, 2, 0, 1, 2 };


            Console.WriteLine("Initial array");
            Console.WriteLine(); Console.WriteLine();
            foreach (var num in array)
                Console.Write(num + " ");

            Console.WriteLine();
            Console.WriteLine();
            //var result = SortUsingCountSort(array);

            var result = SortUsingLinearPartiting(array);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Final output array passed back to called");
            Console.WriteLine(); Console.WriteLine();
            foreach (var num in result)
                Console.Write(num + " " );
        }

        //One solution is to use the count sort,where we count number of occurences
        //of 0's, 1's and 2's 
        //And the udpated the number as per count, requires 2 traversal of array
        private static int[] SortUsingCountSort(int[] array)
        {
            int zeroCounter = 0;
            int oneCounter = 0;
            int twoCounter = 0;

            foreach(var num in array)
            {
                if (num == 0) zeroCounter++;
                else if (num == 1) oneCounter++;
                else if (num == 2) twoCounter++;
                else throw new Exception("Array contains number other that 0,1,2");
            }
            int counter = 0;
            for (int i = 0; i < zeroCounter; i++)
                array[counter++] = 0;

            for (int i = 0; i < oneCounter; i++)
                array[counter++] = 1;
            for (int i = 0; i < twoCounter; i++)
                array[counter++] = 2;

            return array;
        }

        //Other solution is to use the alternative apprach : Linear-time partition routine, i.e. use a pivot
        //value less than Pivot
        //value equal to Pivot
        //value greater than pivot
        //For this problem we use 1 as a Pivot
        private static int[] SortUsingLinearPartiting(int[] array)
        {
            int startPoint = 0;
            int midPoint = 0;
            int endPoint = array.Length-1;
            int pivot = 1;

            while(midPoint <= endPoint)
            {
                if (array[midPoint] < pivot)         //Means current element is 0, and it needs to be moved to startingpoint, increment start and mid                
                    swap(array, startPoint++, midPoint++);
                else if (array[midPoint] > pivot)    //Curent elemtent is >1 , and needs to be on move to end point,  and decrement just end point
                    swap(array, midPoint, endPoint--);
                else
                    midPoint++;

                //Print after each loop
                foreach(var num in array)
                    Console.Write(num + " ");
                Console.WriteLine();
            }

            return array;
        }

        //Just a utility function to swap the elements of the array
        private static void swap(int[] inputArray, int i, int j)
        {
            int temp = inputArray[i];
            inputArray[i] = inputArray[j];
            inputArray[j] = temp;
        }
    }
}
