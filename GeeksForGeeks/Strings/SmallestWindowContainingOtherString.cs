using System;
using System.Collections.Generic;

namespace GeeksForGeeks.Strings
{
    public class SmallestWindowContainingOtherString
    {
        public static void Driver()
        {
            string input = "this is a test string";
            string pattern = "tist";

            Console.WriteLine(GetSmallestStringContainingPattern(input, pattern));
        }

        private static string GetSmallestStringContainingPattern(string input, string pattern)
        {
            if (input.Length < pattern.Length)
                throw new Exception("Such window cannot exists");

            //Will be using Sliding Window technique
            int leftPointer = 0;
            int rightPointer = leftPointer + 1;

            string result = input;

            while(rightPointer < input.Length)
            {
                string subString = input.Substring(leftPointer, rightPointer - leftPointer);

                if (IsStableWindow(subString, pattern))
                {
                    if (subString.Length < result.Length)
                        result = subString;
                    char chr = input[leftPointer++];
                    while (leftPointer < input.Length && input[leftPointer] == chr)
                        leftPointer++;
                }
                else
                    rightPointer++;

            }

            return result;
        }

        private static bool IsStableWindow(string substring, string pattern)
        {            
            Dictionary<char, int> substringMap = new Dictionary<char, int>();

            foreach(var ch in substring)
            {
                if (!substringMap.ContainsKey(ch))
                    substringMap.Add(ch,0);

                substringMap[ch] +=1;
            }

            foreach(var ch in pattern)
            {
                if (!substringMap.ContainsKey(ch)|| substringMap[ch] == 0)
                    return false;

                substringMap[ch] -= 1;
            }

            return true;
        }
    }
}
