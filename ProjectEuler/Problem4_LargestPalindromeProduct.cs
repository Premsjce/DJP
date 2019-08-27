using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    /*
     * A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
        Find the largest palindrome made from the product of two 3-digit numbers.
     */
    class Problem4_LargestPalindromeProduct
    {
        public static void Driver()
        {
            int numberOfDigits = 5;
            var result = GetLargestPalidrome(numberOfDigits);
            Console.WriteLine(result);
        }

        private static long GetLargestPalidrome(int numberOfDigits)
        {
            int MaxNum = 9;
            int MinNum = 1;
            long longestPalindrome = 0;

            for (int i = 1; i < numberOfDigits; i++)
            {
                MaxNum *= 10;
                MaxNum += 9;
                MinNum *= 10;
            }            

            for (int i = MaxNum; i > MinNum; i--)
            {                
                for (int j = MaxNum; j > MinNum; j--)
                {
                    var product = i * j;                    
                    if (longestPalindrome > product)
                        break;

                    if (IsPlaindrome(product))
                    {
                        longestPalindrome = product;
                    }
                        
                }
            }
            return longestPalindrome;
        }

        private static bool IsPlaindrome(long num)
        {
            return GetReverseNumber(num) == num;
        }

        private static long GetReverseNumber(long num)
        {
            long revNum = 0;
            while (num > 0)
            {
                var temp = num % 10;
                num /= 10;
                revNum += temp;
                if(num>0)
                    revNum *= 10;
            }
            return revNum;
        }
    }
}
