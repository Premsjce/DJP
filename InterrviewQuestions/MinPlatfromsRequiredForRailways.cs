using Sorting;
using System;

namespace InterviewQuestions
{
    public class MinPlatfromsRequiredForRailways
    {
        public static void Driver()
        {
            int[] arrivals = { 0900, 0940, 0950, 1100, 1500, 1800 };
            int[] departures = { 0910, 1200, 1120, 1130, 1900, 2000 };

            int platforms = GetMinPlatforms(arrivals, departures);
            Console.WriteLine($"Minimum platoforms required are : {platforms}");
        }

        private static int GetMinPlatforms(int[] arrivals, int[] departures)
        {
            MergeSort.MergeRecursive(arrivals, 0, arrivals.Length - 1);
            MergeSort.MergeRecursive(departures, 0, departures.Length - 1);

            int arrivalPointer = 0;
            int departurePointer = 0;
            int currentPlatforms = 0;
            int totalPlatforms = int.MinValue;

            while(arrivalPointer < arrivals.Length && departurePointer < departures.Length)
            {
                if(arrivals[arrivalPointer] < departures[departurePointer])
                {
                    currentPlatforms += 1;
                    arrivalPointer += 1;
                }
                else
                {
                    currentPlatforms -= 1;
                    departurePointer += 1;
                }

                if (totalPlatforms < currentPlatforms)
                    totalPlatforms = currentPlatforms;
            }

            return totalPlatforms;
        }
    }
}
