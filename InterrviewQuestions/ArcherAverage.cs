using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class ArcherAverage
    {
        public static void Driver()
        {
            double[] currentScores = { 6, 8, 6.5, 9, 7, 5.5 };
            int n = GetMinimumShotsForAverage(currentScores);
            Console.WriteLine(n);
        }

        //Say each following shot will be perfect 10
        private static int GetMinimumShotsForAverage(double[] currentScores)
        {
            int noOfShots = currentScores.Length;
            double currentSum = 0.0;
            foreach(var score in currentScores)
                currentSum += score;

            double netAverage = currentSum / noOfShots;

            while(netAverage < 9.5)
            {
                noOfShots += 1;
                currentSum += 10;
                netAverage = currentSum / noOfShots;
            }

            return noOfShots;
        }
    }
}
