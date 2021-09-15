using DataStructures;
using System;

namespace GeeksForGeeks.Trees
{
    public class PrintNodesAtGivenLevel
    {
        public static void Driver()
        {
            var rootNode = new BinaryNode(1);
            rootNode.Left = new BinaryNode(2);
            rootNode.Right = new BinaryNode(3);
            rootNode.Left.Left = new BinaryNode(4);
            rootNode.Left.Right = new BinaryNode(5);
            rootNode.Right.Left = new BinaryNode(8);

            PrintNodeAtLevel(rootNode, 3);
        }

        private static void PrintNodeAtLevel(BinaryNode node, int level)
        {
            if (node == null || level <= 0)
                return;

            if (level == 1)
            {
                Console.WriteLine(node.Data);
                return;
            }

            PrintNodeAtLevel(node.Left, level - 1);
            PrintNodeAtLevel(node.Right, level - 1);
        }
    }
}
