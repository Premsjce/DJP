using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return inpt[length - 1].ToString();
            return inpt[length-1].ToString() + RecursiverReverse(inpt, --length);

        }
    }
}
