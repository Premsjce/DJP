using System;
using System.Collections.Generic;

namespace InterviewQuestions
{
    public class NumberToWordConveter
    {
        public static void Driver()
        {
            Console.WriteLine("Enter a number between 0 to 999999999");
            var inputNo = Console.ReadLine();
            long number;
            if (!long.TryParse(inputNo, out number) || inputNo.Length > 9)
            {
                Console.WriteLine("Either a very long number Or Not a valid number, Please try again..");
                return;
            }

            var result = GetWordsFromNumber(number, inputNo.Length);
            Console.WriteLine($"Number in words for {number} is : {Environment.NewLine}{result}");
        }


        private static string GetWordsFromNumber(long number, int length)
        {
            if (number <= 20)
                return NumToWordDB.WordsForNumber[number];

            long[] splitInt = new long[3];

            for (int i = 0; i < 3; i++)
            {
                var unitsPlace = number % 10;
                number /= 10;
                var tensPlace = number % 10;
                number /= 10;
                var hundredsPlace = number % 10;
                number /= 10;
                splitInt[i] = (hundredsPlace * 100) + (tensPlace * 10) + unitsPlace;
            }

            var lowerThree = GetWordsUpto3DigitNumber(splitInt[0]);
            var middleThree = GetWordsUpto3DigitNumber(splitInt[1]);
            var topThree = GetWordsUpto3DigitNumber(splitInt[2]);

            var outputWord = string.Empty;

            if (string.IsNullOrEmpty(topThree))
            {
                if (string.IsNullOrEmpty(middleThree))
                    outputWord = lowerThree;
                else
                    outputWord = $"{middleThree} Thousand {lowerThree}";
            }
            else
            {
                if (string.IsNullOrEmpty(middleThree))
                    outputWord = $"{topThree} Million {lowerThree}";
                else
                    outputWord = $"{topThree} Million {middleThree} Thousand {lowerThree}";
            }

            return outputWord;
        }

        private static string GetWordsUpto3DigitNumber(long number)
        {
            if (number == 0)
                return string.Empty;

            var result = string.Empty;

            var units = number % 10;
            var tens = ((number / 10) * 10) % 100;
            var hundreds = number / 100;

            if (units == 0)
            {
                if (tens == 0)
                    result = $"{NumToWordDB.WordsForNumber[hundreds]} Hundred";
                else
                    result = $"{NumToWordDB.WordsForNumber[hundreds]} Hundred and {NumToWordDB.WordsForNumber[tens]}";

            }
            else if (tens == 0)
            {
                if (hundreds == 0)
                    result = $"{NumToWordDB.WordsForNumber[units]}";
                else
                    result = $"{NumToWordDB.WordsForNumber[hundreds]} and {NumToWordDB.WordsForNumber[units]}";
            }
            else if (hundreds == 0)
            {
                if (units == 0)
                    result = $"{NumToWordDB.WordsForNumber[tens]}";
                else
                    result = $"{NumToWordDB.WordsForNumber[tens]} {NumToWordDB.WordsForNumber[units]}";
            }
            else
            {
                result = $"{NumToWordDB.WordsForNumber[hundreds]} Hundred and {NumToWordDB.WordsForNumber[tens]} {NumToWordDB.WordsForNumber[units]}";
            }

            return result;
        }
    }


    public class NumToWordDB
    {
        static NumToWordDB() => InitializeDB();

        public static Dictionary<long, string> WordsForNumber = new Dictionary<long, string>();


        private static void InitializeDB()
        {
            WordsForNumber.Add(0, "Zero");

            WordsForNumber.Add(1, "One");
            WordsForNumber.Add(2, "Two");
            WordsForNumber.Add(3, "Three");
            WordsForNumber.Add(4, "Four");
            WordsForNumber.Add(5, "Five");
            WordsForNumber.Add(6, "Six");
            WordsForNumber.Add(7, "Seven");
            WordsForNumber.Add(8, "Eight");
            WordsForNumber.Add(9, "Nine");

            WordsForNumber.Add(11, "Eleven");
            WordsForNumber.Add(12, "Twelve");
            WordsForNumber.Add(13, "Thirteen");
            WordsForNumber.Add(14, "Fourteen");
            WordsForNumber.Add(15, "Fifteen");
            WordsForNumber.Add(16, "Sixteen");
            WordsForNumber.Add(17, "Seventeen");
            WordsForNumber.Add(18, "Eighteen");
            WordsForNumber.Add(19, "Nineteen");

            WordsForNumber.Add(10, "Ten");
            WordsForNumber.Add(20, "Twenty");
            WordsForNumber.Add(30, "Thirty");
            WordsForNumber.Add(40, "Fourty");
            WordsForNumber.Add(50, "Fifty");
            WordsForNumber.Add(60, "Sixty");
            WordsForNumber.Add(70, "Seventy");
            WordsForNumber.Add(80, "Eighty");
            WordsForNumber.Add(90, "Ninety");

            WordsForNumber.Add(100, "Hundred");
            WordsForNumber.Add(1000, "Thousand");
            WordsForNumber.Add(1000000, "Million");
            WordsForNumber.Add(1000000000, "Billion");
        }
    }
}
