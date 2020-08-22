using System;

namespace InterviewQuestions
{
    public class ExcelColumnNameToNumber
    {
        public static void Driver()
        {
            string input = "AAA";
            Console.WriteLine(TitleToNumber(input));
        }

        private static double TitleToNumber(string input)
        {
            double result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                result *= 26;
                result += input[i] - 'A' + 1;
            }
            return result;
        }
    }
}
