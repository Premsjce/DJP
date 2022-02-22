using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class Microsoft
    {
        public static void Driver()
        {
            var solutionOne = QuestionOne("asdasd", 7);
            //var solutionTwo = QuestionTwo();
            var solutionThree = QuestionThree("WWW");
            Console.WriteLine(solutionThree);
        }

        private static int QuestionOne(string s, int K)
        {
            return -1;
        }

        private static int QuestionTwo(string S, int N)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (string.IsNullOrEmpty(S))
                return N * 2;

            HashSet<string> reservedSeats = ParseReservedSeats(S);

            Dictionary<string, bool> seatMap = new Dictionary<string, bool>();

            foreach (var seat in reservedSeats)
            {
                if (!seatMap.ContainsKey(seat))
                    seatMap.Add(seat, true);

                seatMap[seat] = true;
            }
            int newlyAllocatedSeats = 0;
            char[] COLUMNS = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K' };

            for (int row = 1; row <= N; row++)
            {
                var seatNumbers = GetSeatNumbersOnRow(row);

                if (!reservedSeats.Contains(seatNumbers[1])
                    && !reservedSeats.Contains(seatNumbers[2])
                    && !reservedSeats.Contains(seatNumbers[3])
                    && !reservedSeats.Contains(seatNumbers[4]))
                {
                    newlyAllocatedSeats += 1;
                    if (!reservedSeats.Contains(seatNumbers[5])
                        && !reservedSeats.Contains(seatNumbers[6])
                        && !reservedSeats.Contains(seatNumbers[7])
                        && !reservedSeats.Contains(seatNumbers[8]))
                        newlyAllocatedSeats += 1;
                }
                else if (!reservedSeats.Contains(seatNumbers[3])
                        && !reservedSeats.Contains(seatNumbers[4])
                        && !reservedSeats.Contains(seatNumbers[5])
                        && !reservedSeats.Contains(seatNumbers[6]))
                    newlyAllocatedSeats += 1;
                else if (!reservedSeats.Contains(seatNumbers[5])
                        && !reservedSeats.Contains(seatNumbers[6])
                        && !reservedSeats.Contains(seatNumbers[7])
                        && !reservedSeats.Contains(seatNumbers[8]))
                    newlyAllocatedSeats += 1;
            }

            return newlyAllocatedSeats;




        }

        public static List<string> GetSeatNumbersOnRow(int rowNumber)
        {
            var seatNumbers = new List<string>();

            char[] COLUMNS = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K' };
            for (int col = 0; col < 8; col++)
                seatNumbers.Add(rowNumber + COLUMNS[col].ToString());

            return seatNumbers;

        }

        public static HashSet<string> ParseReservedSeats(string input)
        {
            var researvedSeats = new HashSet<string>();

            var seats = input.Split(' ');
            foreach (var seat in seats)
                researvedSeats.Add(seat);

            return researvedSeats;
        }

        private static int QuestionThree(string S)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int leftRIndex = -1;
            int rightRIndex = -1;
            int totalRs = 0;

            int leftPointer = 0;
            int rightPointer = S.Length - 1;

            long swapCount = 0;

            while (leftPointer < rightPointer)
            {
                if (leftRIndex == -1 && S[leftPointer] == 'R')
                    leftRIndex = leftPointer;

                if (rightRIndex == -1 && S[rightPointer] == 'R')
                    rightRIndex = rightPointer;

                if (S[leftPointer] == 'R')
                    totalRs += 1;

                if (S[rightPointer] == 'R')
                    totalRs += 1;

                leftPointer += 1;
                rightPointer -= 1;
            }

            if (totalRs == 0)
                return 0;

            swapCount = (rightRIndex - leftRIndex) - totalRs + 1;

            if (swapCount >= 99999)
                return -1;

            return (int)swapCount;
        }
    }
}
