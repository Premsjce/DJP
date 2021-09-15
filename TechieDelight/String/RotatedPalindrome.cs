using System;
using System.Linq;

namespace TechieDelight.String
{
    /// <summary>
    /// Check if a string is a rotated palindrome or not
    /// https://www.techiedelight.com/check-given-string-rotated-palindrome-not.
    /// CBAABCD  is a rotated palindrome as it is a rotation of palindrome ABCDCBA 
    /// BAABCC is a rotated palindrome as it is a rotation of palindrome ABCCBA
    /// </summary>
    public class RotatedPalindrome
    {        
        
        public static void Driver()
        {
            var sample = "ilaPdetatoRFIkcehCCheckIFRtatedPalindromeemordn";
            var output = CheckIFRotatedPalindrome(sample);

            if (output.Item1)
                Console.WriteLine($"{sample} is a rotated palindrome of string {output.Item2}");
            else
                Console.WriteLine($"{sample} is not a rotated palindrome of anything ;)");
        }

        private static Tuple<bool,string> CheckIFRotatedPalindrome(string input)
        {
            if (input.IsPalindrome())
                return new Tuple<bool, string>(true, input);

            for(int i = 0; i< input.Length;i++)
            {
                if(i+ 1 < input.Length && input[i] == input[i+1])
                {
                    string str = input.Substring(i + 1) + input.Substring(0, i+1);
                    if (IsPalindrome(str))
                        return  new Tuple<bool, string>(true, str);
                }
            }
            return new Tuple<bool, string>(false, null);
        }

        private static bool IsPalindrome(string input)
        {
            int firstPointer = 0;
            int lastPointer = input.Length - 1;

            while(firstPointer < lastPointer)
            {
                if (input[firstPointer++] != input[lastPointer--])
                    return false;

            }

            return true;
        }
    }
}
