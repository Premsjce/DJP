using System;

namespace TechieDelight.Arrays
{

    /*
     * https://www.techiedelight.com/find-minimum-range-given-arrays/
     * Given 3 sorted array of variable length, efficiently compute the minimum range
     * with atleast one element from each array
     * 
     * ex input : [3,6,8,10,15], [1,2,5], [4,8,15,16]
     * Ouptut Min range : [3-5] , because 3,4,5 are min range element in each array respectively 
     */
    public class MinRangeWithAtleastOneElement
    {

        public static void Driver()
        {
            int[] first = { 2, 3, 4, 8, 10, 15 };
            int[] second = { 1, 5, 12 };
            int[] third = { 7, 8, 15, 16 };

            Console.WriteLine("\nnaive Approach");
            Console.WriteLine(FindMinRangeNaive(first,second,third));
            Console.WriteLine("\nEfficitent Approach");
            Console.WriteLine(FindMinRangeEfficient(first, second, third));

        }


        //Brute force apporach has O(n^3) time complexity solution i.e
        //go for each and every combination and get min and max
        //keep track of diff and for the combination for which diff is less , that range is minimum,
        //its not a Efficient apprach
        //Range will be minimum for those pair with low and high are near to each other.
        public static Pair FindMinRangeNaive(int[] arrayOne, int[] arrayTwo, int[] arrayThree)
        {
            //Create a pair to store the resule
            Pair pair = null;
            int diff = int.MaxValue;

            //Tripple loop, not efficient
            for (int i = 0; i < arrayOne.Length; i++)
            {
                for (int j = 0; j < arrayTwo.Length; j++)
                {
                    for (int k = 0; k < arrayThree.Length; k++)
                    {
                        //Find minimum and maximum in current tripplets
                        int low = Math.Min(Math.Min(arrayOne[i], arrayTwo[j]), arrayThree[k]);
                        int high = Math.Max(Math.Max(arrayOne[i], arrayTwo[j]), arrayThree[k]);

                        //Update the minimum difference and if the current difference is more then store the result
                        if (diff > (high - low))
                        {
                            pair = Pair.Of(low, high);
                            diff = high - low;
                        }
                    }
                }
            }
            return pair;
        }

        //Can be sovled in linear time as well. Since we know that all the ararys are sorted
        //We need to go to each and every combination
        //Idea is to compute the range from the selected triplet
        //Take a 3 pointer approach, and start a while loop comparing each pinter to length
        //For every compbination, increment the lowest pointer to next count

        public static Pair FindMinRangeEfficient(int[] first, int[] second, int[] third)
        {
            int firstLength = 0;
            int secondLength = 0;
            int thirdLength = 0;

            int diff = int.MaxValue;
            Pair pair = null;

            //int[] first =     { 2, 3, 4, 8, 10, 15 };
            //int[] second =    { 1, 5, 12 };
            //int[] third =     { 7, 8, 15, 16 };

            while (firstLength < first.Length && secondLength < second.Length && thirdLength < third.Length)
            {
                //Find minimum and maximum in current tripplets
                int low = Math.Min(Math.Min(first[firstLength], second[secondLength]), third[thirdLength]);
                int high = Math.Max(Math.Max(first[firstLength], second[secondLength]), third[thirdLength]);

                if (diff > high - low)
                {
                    diff = high - low;
                    pair = Pair.Of(low, high);
                }

                //Advance the index of the array that has Min value
                if (first[firstLength] == low)
                    firstLength++;
                else if (second[secondLength] == low)
                    secondLength++;
                else
                    thirdLength++;
            }

            return pair;
        }
    }

    public class Pair
    {
        private int first;
        private int second;

        private Pair(int fir, int sec)
        {
            first = fir;
            second = sec;
        }

        public static Pair Of(int frst, int scnd) => new Pair(frst, scnd);

        public override string ToString() => $"[{first} , {second}]";
    }
}