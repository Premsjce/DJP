using System;
using System.Collections.Generic;

namespace InterviewQuestions.UiPath
{
    public class QueueUsingStack
    {
        public static void Driver()
        {
            QueueByStack queueByStack = new QueueByStack();

            queueByStack.Enqueue(10);
            queueByStack.Enqueue(20);
            queueByStack.Enqueue(30);
            queueByStack.Enqueue(40);
            Console.WriteLine(queueByStack.Dequeue());
            Console.WriteLine(queueByStack.Dequeue());
            Console.WriteLine(queueByStack.Peek());
            Console.WriteLine(queueByStack.Dequeue());
            Console.WriteLine(queueByStack.Peek());
            Console.WriteLine(queueByStack.Dequeue());
        }
    }

    public class QueueByStack
    {
        private static Stack<int> InputStack = new Stack<int>();
        private static Stack<int> OutputStack = new Stack<int>();

        public void Enqueue(int num)
        {
            while (OutputStack.Count > 0)
                InputStack.Push(OutputStack.Pop());
            OutputStack.Push(num);
            while (InputStack.Count > 0)
                OutputStack.Push(InputStack.Pop());
        }

        public int Dequeue()
        {
            if (OutputStack.Count <= 0)
                throw new Exception("Queue is Empty");
            return OutputStack.Pop();
        }

        public int Peek() => OutputStack.Peek();
    }
}
