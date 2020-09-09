using System;

namespace InterviewQuestions
{
    public class LongestPalindromeSubstring
    {
        public static void Driver()
        {
            var str = "abasadbasmd";
            Console.WriteLine(GetLongestPalindrome(str, 0, str.Length - 1));

            //Can be done in O(n^2)time
            //brute force apporach will take O(n^3) time
            //Manacher's algorithms will take O(n) linear time
        }

        private static int GetLongestPalindrome(string str, int leftIndex, int rightIndex)
        {
            if (leftIndex > rightIndex)
                return 0;

            if (str[leftIndex] == str[rightIndex])
               return  GetLongestPalindrome(str, leftIndex++, rightIndex--);

            return Math.Max(GetLongestPalindrome(str, leftIndex+1, rightIndex),
                GetLongestPalindrome(str, leftIndex, rightIndex-1)) + 1;
        }
    }
}
