﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechieDelight.Arrays
{
    public class SlidingWindowsToCountOnes
    {
        public static void Driver()
        {
            //int[] array = { 0, 1, 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1 };
            int[] array = { 0, 0, 1, 0, 1, 1, 1, 0, 1, 1 };

            int count = GetMaxOnesByReplacingOneZero(array);
            Console.WriteLine($"With current array, max one's achieved by single 0 replacement is  : {count}");

            count = GetMaxOnesByReplacingOneZeroRevision(array);
            Console.WriteLine($"With current array, max one's achieved by single 0 replacement is  : {count}");


            count = GetMaxOnesBySimpleMethod(array);
            Console.WriteLine($"Simple Method without Sliding windows technique : {count}");
        }

        private static int GetMaxOnesByReplacingOneZero(int[] array)
        {
            //{ 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1 };

            int leftPointer = 0;        //Represent windows starting index which is 1 including converted 0
            int zerosCount = 0;         //Number of zeros in current window
            int onesCount = 0;          //Number of ones in current window

            int currentZeroIndex = -1;  //Max number of ones in current
            int prevZeroIndex = -1;     //Previous index of 0

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
                {
                    prevZeroIndex = i;
                    zerosCount++;
                }
                
                //If the window becomes unstable, then we need to rebalance it with following constraints 
                if(zerosCount == 2)
                {
                    //If there are more that 2 zeros in current window, then move the prev zero index should be moved to current zero
                    //Need to reach the 0
                    while(array[leftPointer] != 0)
                        leftPointer += 1;

                    //Move the Current starting pointer (leftPointer) to next one
                    leftPointer += 1;

                    //Decrement the zeros count in present indez
                    zerosCount = 1;
                }

                if (i - leftPointer + 1 > onesCount)
                {
                    onesCount = i - leftPointer + 1;
                    currentZeroIndex = prevZeroIndex;
                }
            }

            //To reaturn the max array length that can be formed from converting a single 0 to 1 is stored in onesCount
            //return onesCount;

            //To return the index for which the replacement has to be done is stored in currentZeroIndex variable
            return currentZeroIndex;
        }
        
        private static int GetMaxOnesByReplacingOneZeroRevision(int[] array)
        {
            int leftPointer = 0, zerosCount = 0, onesCount = 0;
            int  currentZeroIndex = -1, prevZeroIndex = -1;

            for(int i = 0; i< array.Length; i++)
            {
                if(array[i] == 0)
                {
                    prevZeroIndex = i;
                    zerosCount += 1;
                }

                //Stabilizing the window
                if(zerosCount == 2)
                {
                    while(array[leftPointer] != 0)
                    {
                        leftPointer += 1;
                    }

                    //move to next starting one in the current window
                    leftPointer += 1;
                    zerosCount -= 1;
                }

                if(onesCount < i - leftPointer)
                {
                    onesCount = i - leftPointer;
                    currentZeroIndex = prevZeroIndex;
                }
            }

            //To return index where replacement needs to be done
            return currentZeroIndex;

            //To get max count return onesCount
            //return onesCount;
        }

        private static int GetMaxOnesBySimpleMethod(int[] array)
        {
            if (array.Length == 0)
                return -1;

            if (array.Length == 1)
                return array[0] == 0 ? 1 : 0;

            //Add 1's count in array
            for(int i = 1; i < array.Length; i++)
            {
                if (array[i] == 1)
                    array[i] += array[i - 1];
            }

            int count = 0;
            //Add consecutive one count in array, start from right to left
            for (int i = array.Length - 1; i >= 0; i--)
            {
                count = Math.Max(count, array[i]);

                if (array[i] != 0)
                    array[i] = count;
                else
                    count = 0;
            }

            int maxOnesCount = 0;
            int indexOfZero = 0;

            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
                {
                    if (i == 0 && maxOnesCount < array[i + 1] + 1)
                    {
                            maxOnesCount = array[i + 1] + 1;
                            indexOfZero = i;
                    }
                    else if (i == array.Length - 1 && maxOnesCount < array[i - 1] + 1)
                    {
                        maxOnesCount = array[i - 1] + 1;
                        indexOfZero = i;
                    }
                    else if(maxOnesCount < (array[i - 1] + 1 + array[i + 1]))
                    {
                        maxOnesCount = array[i - 1] + 1 + array[i + 1];
                        indexOfZero = i;
                    }
                }
            }

            return indexOfZero;
        }
    }
}
