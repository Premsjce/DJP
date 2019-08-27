using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class RemoveDuplicatesFromString
    {
        public static void Driver()
        {
            Console.WriteLine("Enter any string for which duplicate needs to be removed");
            var enteredString = Console.ReadLine();
            var dupRemoved = RemoveDuplicateUsingBST(enteredString); //removeDuplicateSimple(enteredString);
            Console.WriteLine($"String without Duplicate is : {dupRemoved}");
        }

        private static string removeDuplicateSimple(string str)
        {
            var array = str.ToCharArray();
            Array.Sort(array);
            var tempAray = string.Empty;
            int curentIndex = 1;
            tempAray += array[0];
            while (curentIndex != array.Length)
            {
                if (array[curentIndex] != array[curentIndex - 1])
                    tempAray += array[curentIndex];
                curentIndex++;
            }

            return tempAray;
        }

        private static string RemoveDuplicateUsingBST(string str)
        {            
            var charArray = str.ToCharArray();
            var tempString = string.Empty;
            SortedSet<char> sortedChars = new SortedSet<char>();

            foreach (var chr in charArray)            
                sortedChars.Add(chr);            

            foreach (var chr in sortedChars)            
                tempString += chr;

            return tempString;
        }

    }
}
