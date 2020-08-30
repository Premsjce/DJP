using System;
using System.Collections.Generic;

namespace InterviewQuestions.UiPath
{
    public class StackUsingQueue
    {
        public static void Driver()
        {
            var StackByQueue = new StackByQueue();
            StackByQueue.Push(10);
            StackByQueue.Push(20);
            StackByQueue.Push(30);
            StackByQueue.Push(40);

            Console.WriteLine(StackByQueue.Pop());
            Console.WriteLine(StackByQueue.Peek());
            Console.WriteLine(StackByQueue.Pop());
            Console.WriteLine(StackByQueue.Pop());
            Console.WriteLine(StackByQueue.Pop());

        }
    }


    public class StackByQueue
    {
        private static Queue<int> InputQueue = new Queue<int>();
        private static Queue<int> OutputQueue = new Queue<int>();

        public int Count { get; } = OutputQueue.Count;

        public void Push(int num)
        {
            while (OutputQueue.Count > 0)
                InputQueue.Enqueue(OutputQueue.Dequeue());

            OutputQueue.Enqueue(num);
            while (InputQueue.Count > 0)
                OutputQueue.Enqueue(InputQueue.Dequeue());
        }

        public int Pop()
        {

            if (OutputQueue.Count <= 0)
                throw new Exception("Stack is Empty");

            return OutputQueue.Dequeue();
        }

        public int Peek() => OutputQueue.Peek();
    }
}
