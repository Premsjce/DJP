using System;
using System.Collections.Generic;

namespace InterviewQuestions
{
    public class LargestHistogram
    {
        public static void Driver()
        {
            int[] histogram = { 3, 4, 5, 4, 3, 1, 4 };
            //int[] hist = new int[] { 6, 2, 5, 4, 5, 1, 6 };

            int result = FindLargestHistogram(histogram);

            Console.WriteLine(result);
        }

        private static int FindLargestHistogram(int[] histogram)
        {
            if (histogram.Length == 0) return 0;

            if (histogram.Length == 1) return histogram[0];

            Stack<int> stack = new Stack<int>();
            int maxArea = 0;
            int index = 0;
            while (index < histogram.Length)
            {
                if(stack.Count == 0 || histogram[index] >= histogram[stack.Peek()])
                {
                    stack.Push(index);
                    index += 1;
                }
                else
                {
                    var topIndex = stack.Pop();
                    var currentArea = histogram[topIndex] * (stack.Count == 0 ? index : (index - stack.Peek() - 1));

                    if (currentArea > maxArea)
                        maxArea = currentArea;
                }
            }

            while (stack.Count > 0)
            {
                var topIndex = stack.Pop();
                var currentArea = histogram[topIndex] * (stack.Count == 0 ? index : (index - stack.Peek() - 1));
                if (currentArea > maxArea)
                    maxArea = currentArea;
            }

            return maxArea;
        }
    }
}
