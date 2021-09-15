using System;
using System.Collections.Generic;

namespace TechieDelight.String
{
    public class LongestPalindromicSubstring
    {
        public static void Driver()
        {
            string input = "ABBDCACB";
            Dictionary<string, string> lookUp = new Dictionary<string, string>();
            Console.WriteLine(LongestPalindrome(input, 0, input.Length - 1, lookUp));
        }

        private static string LongestPalindrome(string word, int leftPointer, int rightPointer, Dictionary<string, string> lookUp)
        {
            string uniqueKey = leftPointer + " || " + rightPointer;

            if (lookUp.ContainsKey(uniqueKey))
                return lookUp[uniqueKey];

            if (IsPalindrome(word, leftPointer, rightPointer))
            {
                lookUp.Add(uniqueKey, word.Substring(leftPointer, rightPointer - leftPointer + 1));
            }
            else
            {
                var leftString = LongestPalindrome(word, leftPointer + 1, rightPointer, lookUp);
                var rightString = LongestPalindrome(word, leftPointer, rightPointer - 1, lookUp);

                if (leftString.Length > rightString.Length)
                    lookUp.Add(uniqueKey, leftString);
                else
                    lookUp.Add(uniqueKey, rightString);
            }

            return lookUp[uniqueKey];
        }

        private static bool IsPalindrome(string word, int leftPointer, int rightPointer)
        {
            while (leftPointer < rightPointer)
            {
                if (word[leftPointer++] != word[rightPointer--])
                    return false;
            }

            return true;
        }
    }
}
