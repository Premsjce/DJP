using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechieDelight.DP
{
    public class LongestCommonSubsequence
    {
        public static void Driver()
        {
            string first = "ABCBDAB";
            string second = "BDCABA";

            Dictionary<string, int> lookup = new Dictionary<string, int>();
            //int result = FindLCSRecursion(first, second, first.Length, second.Length);
            //int result = FindLCSMemoization(first, second, first.Length, second.Length, lookup);
            //int result = FindLCSTabulation(first, second, first.Length, second.Length);

            //Finding all the subsequences
            int[,] lookupTable = new int[first.Length + 1, second.Length + 1];
            FindLCSTabulation(first, second, first.Length, second.Length, lookupTable);
            var result = FindLCSGetList(first, second, first.Length, second.Length, lookupTable);

            HashSet<string> set = new HashSet<string>();
            result.ForEach(r => set.Add(r));
            foreach (var n in set)
                Console.WriteLine($"Longest Length of common subsequence is {n}");
        }

        //Time complexity is  O(2^(m+n))
        private static int FindLCSRecursion(string first, string second, int firstLength, int secondLength)
        {
            if (firstLength == 0 || secondLength == 0)
                return 0;

            if (first[firstLength - 1] == second[secondLength - 1])
                return FindLCSRecursion(first, second, firstLength - 1, secondLength - 1) + 1;

            return Math.Max(FindLCSRecursion(first, second, firstLength - 1, secondLength),
                            FindLCSRecursion(first, second, firstLength, secondLength - 1));
        }

        //DP with Top Down (Memoization), Time complexxity is  O(mn)
        private static int FindLCSMemoization(string first, string second, int firstLength, int secondLength, Dictionary<string, int> lookup)
        {
            if (firstLength == 0 || secondLength == 0)
                return 0;

            //Constructing a unique key for lookup
            string key = firstLength + "|" + secondLength;

            if (lookup.ContainsKey(key))
                return lookup[key];

            if (first[firstLength - 1] == second[secondLength - 1])
                lookup.Add(key, FindLCSMemoization(first, second, firstLength - 1, secondLength - 1, lookup) + 1);
            else
                lookup.Add(key, Math.Max(FindLCSMemoization(first, second, firstLength, secondLength - 1, lookup),
                                         FindLCSMemoization(first, second, firstLength - 1, secondLength, lookup)));

            return lookup[key];
        }

        //DP with BottomUp(Tabulation), Time complexity is O(mn)
        private static int FindLCSTabulation(string first, string second, int firstLength, int secondLength, int[,] lookupTable)
        {
            //int[,] lookupTable = new int[firstLength + 1, secondLength + 1];

            for (int i = 1; i <= firstLength; i++)
            {
                for (int j = 1; j <= secondLength; j++)
                {
                    if (first[i - 1] == second[j - 1])
                        lookupTable[i, j] = lookupTable[i - 1, j - 1] + 1;
                    else
                        lookupTable[i, j] = Math.Max(lookupTable[i - 1, j], lookupTable[i, j - 1]);
                }
            }
            return lookupTable[firstLength, secondLength];
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
