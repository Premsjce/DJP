using System;

namespace InterviewQuestions
{
    public class OpenText
    {
        public static void Driver()
        {
            Console.WriteLine(SolutionForProblemTwo("abccbd", new int[] { 0, 1, 2, 3, 4, 5 }));
        }

        /// <summary>
        /// Given a Number N, add the number (i.e if 14 is given then 1 + 4 = 5)
        /// Now return next number after N, where when numbers is added , should be twice
        /// i.e. for 14, answer should be 19  (1+ 9 = 10). because 10 = 2* 5
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public static int SolutionForProblemOne(int N)
        {
            int mainSum = GetSum(N.ToString());
            int counter = N + 1;

            while(GetSum(counter.ToString()) < (2*mainSum))
            {
                counter += 1;
            }

            return counter;
        }

        private static int GetSum(string s)
        {
            int sum = 0;
            foreach (var ch in s)
            {
                var num = Convert.ToInt32(ch.ToString());
                sum += num;
            }
            return sum;
        }

        /// <summary>
        /// Each index char in S has its value in arra c, now if any char is removed in S, then its value is C[index],
        /// Return minimum cost requred, to remove any characrters from S, such that no 2 chars are identical
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int SolutionForProblemTwo(string s, int[] c)
        {
            if (s.Length != c.Length)
                return int.MinValue;

            int minSum = 0;
            int prevIndex = 0;
            
            for(int currentIndex = 1; currentIndex < s.Length; currentIndex++)
            {
                if (s[prevIndex] == s[currentIndex])
                    minSum += Math.Min(c[prevIndex], c[currentIndex]);
                prevIndex = currentIndex;
            }

            return minSum;
        }
    }
}
