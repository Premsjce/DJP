using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechieDelight.Arrays
{
    /// <summary>
    /// https://www.techiedelight.com/find-duplicate-element-limited-range-array/
    /// Find duplicate element in a limited range array
    /// Ex : 
    /// Input:  { 1, 2, 3, 4, 4 }
    /// Output: The duplicate element is 4
    /// Input:  { 1, 2, 3, 4, 2 }
    /// Output: The duplicate element is 2
    /// </summary>
    public class DuplicateInLimitedRange
    {
        public static void Driver()
        {
            int[] inputArray = {  };
            Console.WriteLine($"Duplicate Number is  {FindDuplicate(inputArray)}");
            Console.WriteLine($"Duplicate Number is  without Extra space is : {FindDuplicateWithoutExtraSpace(inputArray)}");
        }

        private static int FindDuplicate(int[] inputArray)
        {
            HashSet<int> unique = new HashSet<int>();
            foreach (var num in inputArray)
            {
                if (unique.Contains(num))
                    return num;

                unique.Add(num);
            }
            return -1;
        }

        private static int FindDuplicateWithoutExtraSpace(int[] inputArray)
        {
            if (inputArray.Length <= 1)
                return -1;

            int counter = 0;
            int pointer = 0;
            while (counter <= inputArray.Length)
            {
                var currentNum = inputArray[pointer];
                if (currentNum > 0)
                    inputArray[pointer] *= -1;
                else
                    return pointer;

                pointer = currentNum;
                counter++;
            }

            return -1;
        }
    }
}
