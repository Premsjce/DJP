using System;

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
            var sample = "MALAYALAM";
            bool result;
            var palString = sample.IsRotatedPalindrame(out result);

            if(result)
                Console.WriteLine($"{sample} is a rotated palindrome of string {palString}");
            else
                Console.WriteLine($"{sample} is not a rotated palindrome of anything ;)");
        }
    }
}
