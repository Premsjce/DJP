using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.UiPath
{
    public class SpecialStack
    {
        public static void Driver()
        {

            MinStack minStack = new MinStack();

            minStack.Push(3);
            minStack.Push(5);
            minStack.Push(6);
            minStack.Push(1);
            minStack.Push(2);
            minStack.Push(8);
            minStack.Push(-1);

            Console.WriteLine(minStack.Pop());
            Console.WriteLine(minStack.GetMin());
            Console.WriteLine(minStack.Pop());
            Console.WriteLine(minStack.GetMin());
            Console.WriteLine(minStack.Pop());
            Console.WriteLine(minStack.GetMin());
            Console.WriteLine(minStack.Pop());
            Console.WriteLine(minStack.GetMin());
        }
    }

    public class MinStack
    {
        private static Stack<int> baseStack = new Stack<int>();
        private int minElement;

        public void Push(int num)
        {
            if(baseStack.Count == 0)
            {
                baseStack.Push(num);
                minElement = num;
                return;
            }

            if(num > minElement)
            {
                baseStack.Push(num);
                return;
            }

            int modNum = (2 * num) - minElement;
            baseStack.Push(modNum);
            minElement = num;
        }

        public int GetMin() => minElement;

        public int Pop()
        {
            if (baseStack.Count == 0)
                throw new Exception("Emty stack");

            var item = baseStack.Pop();
            if (item >= minElement)
                return item;

            var originalNum = minElement;
            minElement = (2 * minElement) - item;            
            return originalNum;
        }

        public int Peek() => baseStack.Peek();
    }
}
