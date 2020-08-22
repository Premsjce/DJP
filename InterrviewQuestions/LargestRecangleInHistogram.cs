using System;
using System.Collections.Generic;

namespace InterviewQuestions
{
    public class LargestRecangleInHistogram
    {
        public static void Driver()
        {
            int[] hist = { 1,2,3,4,5,3,3,2};
            Console.WriteLine(GetMaxArea(hist));
        }

        private static int GetMaxArea(int[] histogram)
        {
            Stack<int> stack = new Stack<int>(histogram.Length);
            int maxArea = 0;
            int index = 0;

            while(index < histogram.Length)
            {
                if(stack.Count == 0 || histogram[stack.Peek()] <= histogram[index])
                {
                    stack.Push(index++);
                }
                else
                {
                    int currentMax = stack.Pop();
                    int area = histogram[currentMax] * (stack.Count == 0 ? 1 : index - 1 - stack.Peek());
                    maxArea = area > maxArea ? area : maxArea;
                }
            }

            while (stack.Count !=0)
            {
                int currentMax = stack.Pop();
                int area = histogram[currentMax] * (stack.Count == 0 ? index - 1 : index - 1 - stack.Peek());
                maxArea = area > maxArea ? area : maxArea;
            }

            return maxArea;
        }
    }


}
