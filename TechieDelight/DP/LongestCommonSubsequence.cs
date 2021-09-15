using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechieDelight.DP
{
    /// <summary>
    /// https://www.techiedelight.com/longest-common-subsequence/
    /// The Longest Common Subsequence (LCS) problem is finding the longest subsequence present in given two sequences 
    /// in the same order, i.e., find the longest sequence which can be obtained from the first original sequence 
    /// by deleting some items and from the second original sequence by deleting other items.
    /// </summary>
    public class LongestCommonSubsequence
    {
        public static void Driver()
        {
            string first = "ABCBDAB";
            string second = "BDCABA";


            //int result = LCSRecursion(first, second, first.Length, second.Length);
            
            //int result = LCSRecursionFromBeginning(first, second, first.Length, second.Length);

            //Dictionary<string, int> lookup = new Dictionary<string, int>();
            //int resulta = FindLCSMemoization(first, second, first.Length, second.Length, lookup);
            //Console.WriteLine(resulta);
            //return;

            //Finding all the subsequences
            //var resulasa = FindLCSTabulation(first, second, first.Length, second.Length);
            //Console.WriteLine(resulasa);
            //return;

            int[,] lookupTable = new int[first.Length + 1, second.Length + 1];
            var result = FindLCSGetList(first, second, first.Length, second.Length, lookupTable);

            HashSet<string> set = new HashSet<string>();
            result.ForEach(r => set.Add(r));
            foreach (var n in set)
                Console.WriteLine($"Longest Length of common subsequence is {n}");
        }

        //Naive solution with O(2^(m+n)) time complexity
        private static int LCSRecursion(string firstString, string secondString, int firstLength, int secondLength)
        {
            if (firstLength == 0 || secondLength == 0)
                return 0;

            if (firstString[firstLength - 1] == secondString[secondLength - 1])
                return LCSRecursion(firstString, secondString, firstLength - 1, secondLength - 1) + 1;
            else
                return Math.Max(LCSRecursion(firstString, secondString, firstLength, secondLength - 1),
                    LCSRecursion(firstString, secondString, firstLength - 1, secondLength));

        }

        private static int LCSRecursionFromBeginning(string firstString, string secondString, int firstPointer, int secondPointer)
        {
            if (firstPointer == firstString.Length || secondPointer == secondString.Length)
                return 0;

            if (firstString[firstPointer] == secondString[secondPointer])
                return LCSRecursionFromBeginning(firstString, secondString, firstPointer + 1, secondPointer + 1) + 1;

            return Math.Max(LCSRecursionFromBeginning(firstString, secondString, firstPointer + 1, secondPointer),
                LCSRecursionFromBeginning(firstString, secondString, firstPointer, secondPointer + 1));
        }

        //DP with Top Down (Memoization), Time complexxity is  O(mn)
        private static int FindLCSMemoization(string first, string second, int fLength, int sLength, Dictionary<string, int> lookUp)
        {
            if (fLength == 0 || sLength == 0)
                return 0;

            var uniqueKey = fLength + "||" + sLength;

            if (lookUp.ContainsKey(uniqueKey))
                return lookUp[uniqueKey];

            if (first[fLength - 1] == second[sLength - 1])
                lookUp.Add(uniqueKey, FindLCSMemoization(first, second, fLength - 1, sLength - 1, lookUp) + 1);
            else
            {
                var max = Math.Max(
                    FindLCSMemoization(first, second, fLength, sLength - 1, lookUp),
                    FindLCSMemoization(first, second, fLength - 1, sLength, lookUp));
                lookUp.Add(uniqueKey, max);
            }

            return lookUp[uniqueKey];
        }

        //DP with BottomUp(Tabulation), Time complexity is O(mn)
        public static int FindLCSTabulation(string first, string second, int fLength, int sLength)
        {
            if (fLength == 0 || sLength == 0)
                return 0;
            int[,] lookUpTable = new int[fLength + 1, sLength + 1];


            for (int i = 1; i <= fLength; i++)
            {
                for (int j = 1; j <= sLength; j++)
                {
                    if (first[i - 1] == second[j - 1])
                        lookUpTable[i, j] = lookUpTable[i - 1, j - 1] + 1;
                    else
                        lookUpTable[i, j] = Math.Max(lookUpTable[i - 1, j], lookUpTable[i, j-1]);
                }
            }


            return lookUpTable[fLength,sLength];
        }

        //Get All LCS strings
        private static List<string> FindLCSGetList(string first, string second, int fLength, int sLength, int[,] lookupTable)
        {
            if (fLength == 0 || sLength == 0)
            {
                var newList = new List<string>();
                newList.Add("");
                return newList;
            }


            //if last char of X and Y matches then
            if (first[fLength - 1] == second[sLength - 1])
            {
                var lcs = FindLCSGetList(first, second, fLength - 1, sLength - 1, lookupTable);

                for (int i = 0; i < lcs.Count; i++)
                    lcs[i] = lcs[i] + first[fLength - 1];

                return lcs;
            }

            if (lookupTable[fLength - 1, sLength] > lookupTable[fLength, sLength - 1])
                return FindLCSGetList(first, second, fLength - 1, sLength, lookupTable);

            if (lookupTable[fLength, sLength - 1] > lookupTable[fLength - 1, sLength])
                return FindLCSGetList(first, second, fLength, sLength - 1, lookupTable);

            var top = FindLCSGetList(first, second, fLength - 1, sLength, lookupTable);
            var left = FindLCSGetList(first, second, fLength, sLength - 1, lookupTable);

            top.AddRange(left);
            return top;
        }
    }
}
