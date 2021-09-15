using System;
using System.Collections.Generic;

namespace LeetCode
{
    /// <summary>
    /// https://leetcode.com/problems/longest-valid-parentheses/
    /// Given a string containing just the characters '(' and ')', 
    /// find the length of the longest valid (well-formed) parentheses substring.
    /// </summary>
    public class LongestValidParenthesis
    {
        public static void Driver()
        {
            Console.WriteLine(GetLongestValidParenthesisLenght("()(()"));
        }

        private static int GetLongestValidParenthesisLenght(string s)
        {
            if (s.Length < 2)
                return 0;
            int lengthTillNow = 0;
            int maxTillNow = 0;
            Stack<char> charStack = new Stack<char>();

            //  "()(()"
            foreach (var ch in s)
            {
                if (charStack.Count == 0 || ch == '(')
                    charStack.Push(ch);
                else
                {
                    if (charStack.Peek() == '(')
                    {
                        lengthTillNow += 2;
                        maxTillNow = Math.Max(maxTillNow, lengthTillNow);
                        charStack.Pop();
                    }
                }
            }
            return maxTillNow;
        }
    }
}