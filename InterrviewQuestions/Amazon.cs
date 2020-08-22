using System;
using System.Collections.Generic;

namespace InterviewQuestions
{
    public class Amazon
    {
        public static void Driver()
        {
            var result = ExcelColumnNumber("ZZ");
            Console.WriteLine(result);
        }

        //Q. In the column of excel sheet instead of numbers, column are represented by letter string. 
        //e.g.- A, Z, AA, ABC etc. Given such string, write a function that return that equivalent column number.
        private static double ExcelColumnNumber(string columnName)
        {
            //base 26 number system
            int length = columnName.Length;
            int basePos = length - 1;
            double result = 0;
            for (int i = 0; i < length; i++)
            {
                var pos = Math.Pow(26, i);
                char ch = columnName[basePos];
                var temp = ch - 64;
                result += temp * pos;
                basePos--;
            }
            return result;
        }
    }
}
