using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Strings
{
    public class ReverseWordsInString
    {
        public static void Driver()
        {
            string input = "geeks quiz practice code";
            string output = GetReveresedWordsString(input);
            Console.WriteLine($"Input  : {input}{Environment.NewLine}output : {output}");

            string expected = "code practice quiz geeks";
            Console.WriteLine(expected);
            Console.WriteLine(output == expected);
        }

        private static string GetReveresedWordsString(string input)
        {
            StringBuilder builder = new StringBuilder();
            int index = 0;
            List<string> reveresedStringArray = new List<string>();

            while (index < input.Length)
            {
                builder.Clear();
                while (index < input.Length && input[index] != ' ')
                    builder.Append(input[index++]);
                index++;
                reveresedStringArray.Add(builder.ToString());
            }

            builder.Clear();

            for (int i = reveresedStringArray.Count - 1; i >= 0; i--)
            {
                builder.Append(reveresedStringArray[i]);
                if(i != 0)
                    builder.Append(' ');
            }


            return builder.ToString();
        }
    }
}