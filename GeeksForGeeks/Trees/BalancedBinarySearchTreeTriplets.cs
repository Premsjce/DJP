using DataStructures;
using System;
using System.Collections.Generic;

namespace GeeksForGeeks.Trees
{
    public class BalancedBinarySearchTreeTriplets
    {
        public static void Driver()
        {
            /*
             *                     6
             *                    /  \
             *                   /    \
             *                 -13     14
             *                  \      / \
             *                   \    /   \
             *                  -8   13   15
             *                       /   
             *                      /
             *                     7 
             */
            var rootNode = new BinaryNode(6);
            rootNode.Left = new BinaryNode(-13);
            rootNode.Left.Right = new BinaryNode(-8);
            rootNode.Right = new BinaryNode(14);
            rootNode.Right.Left = new BinaryNode(13);
            rootNode.Right.Left = new BinaryNode(7);
            rootNode.Right.Right = new BinaryNode(15);

            Console.WriteLine(IstripletPresentWithOofNSpace(rootNode, 99));
        }

        private static bool IsTripletPresentWithZeroSum(BinaryNode node)
        {

            return false;
        }

        //Using O(N) extra space
        private static bool IstripletPresentWithOofNSpace(BinaryNode rootNode, int sum)
        {
            List<int> sortedArray = new List<int>();
            InorderTraversal(rootNode, sortedArray);

            for (int i = 0; i < sortedArray.Count - 2; i++)
            {
                int leftPointer = i + 1;
                int rightPointer = sortedArray.Count - 1;

                while (leftPointer < rightPointer)
                {
                    var calcSum = sortedArray[i] + sortedArray[leftPointer] + sortedArray[rightPointer];
                    
                    if (calcSum  == sum)
                        return true;

                    if (calcSum < sum)
                        leftPointer += 1;
                    else
                        rightPointer -= 1;
                }
            }

            return false;            
        }

        private static void InorderTraversal(BinaryNode node, List<int> sortedArray)
        {
            if (node == null)
                return;

            InorderTraversal(node.Left, sortedArray);
            sortedArray.Add(node.Data);
            InorderTraversal(node.Right, sortedArray); 
        }
    }
}
