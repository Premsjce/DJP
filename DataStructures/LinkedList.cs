using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Node
    {
        public Node(int data)
        {
            Data = data;
            Next = null;
        }

        public int Data { get; set; }
        public Node Next { get; set; }
    }

    public class LinkedList
    {
        public LinkedList(int data)
        {
            Head = new Node(data);
            First = Last = Head;
            Count = 1;
        }

        public Node Head { get; private set; }
        public int Count { get; private set; }
        public Node First { get; private set; }
        public Node Last { get; private set; }


        public void AddFirst(int data)
        {
            var newNode = new Node(data);
            newNode.Next = Head.Next;
            Head = newNode;
            Count++;
        }

        public void AddLast(int data)
        {

        }

        public void AddBefore(Node node,int data)
        {

        }

        public void AddAfter(Node node,int data)
        {

        }

        public void AddAfter(int index, int data)
        {

        }

        public void Delete(Node node)
        {

        }

        public void Delete(int index)
        {

        }

        public void Traverse(Node head)
        {

        }

        public Node Reverse()
        {
            Last = First;
            var firstNode = First;
            var secondNode = First.Next;

            while(secondNode != null)
            {
                var tempNode = secondNode.Next;
                secondNode.Next = firstNode;
                firstNode = secondNode;
                secondNode = tempNode;
            }
            Last.Next = null;
            First = secondNode;

            return First;
        }

    }
}
