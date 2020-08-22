using System;

namespace InterviewQuestions
{
    class StringReversal
    {
        public static void Driver()
        {
            Console.WriteLine("Enter a string to be reversed");
            var inpt = Console.ReadLine();
            Console.WriteLine("Reveresed string is :");
            Console.WriteLine(RecursiverReverse(inpt, inpt.Length));
        }

        private static string RecursiverReverse(string inpt, int length)
        {
            if (length < 2)
                return inpt;

            return inpt[length-1].ToString() + RecursiverReverse(inpt, --length);

        }
    }
}
