namespace TechieDelight.String
{
    public static class StringExtensions
    {
        /// <summary>
        /// Logic to check of the given input string is the rotated palindrome
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isPalindrome"></param>
        /// <returns></returns>
        public static string IsRotatedPalindrame(this string str, out bool isPalindrome)
        {
            isPalindrome = true;

            if (str.Length <= 1)
                return str;

            if (str.IsPalindrome())
                return str;

            for (int i = 0; i < str.Length; i++)
            {
                if ((i + 1 < str.Length) && str[i] == str[i + 1])
                {
                    if (IsPalindrome(str, i, i + 1))
                    {
                        var firstPart = str.Substring(i + 1, str.Length - i-1 );
                        var secondPart = str.Substring(0, i+1);
                        return firstPart + secondPart;
                    }
                        
                }
            }
            isPalindrome = false;
            return str;
        }


        public static bool IsPalindrome(this string input)
        {
            return IsPalindrome(input, 0, input.Length - 1);
        }


        private static bool IsPalindrome(string sample, int initialPointer, int finalPointer)
        {
            if (sample.Length == 1)
                return true;

            int compCounter = 0;

            while (compCounter < sample.Length / 2)
            {
                if (sample[initialPointer] != sample[finalPointer])
                    return false;

                if (initialPointer == sample.Length)
                    initialPointer = 0;
                else
                    initialPointer++;

                if (finalPointer == 0)
                    finalPointer = sample.Length - 1;
                else
                    finalPointer--;

                compCounter++;
            }

            return true;
        }
    }
}
