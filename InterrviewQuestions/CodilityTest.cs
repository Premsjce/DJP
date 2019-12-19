using System;
using System.Collections.Generic;

namespace InterviewQuestions
{
    public class CodilityTest
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A.Length < 2)
                return 0;

            //Dictionay is used for storing key value pair. WHere dictionary Key is array value, & dictionary value is array index
            Dictionary<int, int> valuePairs = new Dictionary<int, int>();
            
            //Basially code is checking if any value already exists in the dicionary, if its not, then its added
            //If its there, means there exists a pair, since will be moving forward in index enumeration
            //we will increment the exisitng value by 1. 
            foreach(var i in A)
            {
                if (!valuePairs.ContainsKey(i))                
                    valuePairs.Add(i, 1);                
                else                
                    valuePairs[i] = valuePairs[i] + 1;
            }

            /*
             * -- write your code in PostgreSQL 9.4
SELECT plays.id, plays.title, reservations.number_of_tickets
FROM plays INNER JOIN reservations ON reservations.play_id = plays.id

             */

            //n!(factorial  : (n * (n-1 ))/2
            var pairCount = 0;
            foreach (var pair in valuePairs)
            {
                var count = pair.Value;
                pairCount += (count * (count - 1)) / 2;
            }
            
            return pairCount;
        }
    }
}
