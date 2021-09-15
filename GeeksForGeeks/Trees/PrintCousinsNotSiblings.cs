using DataStructures;
using System;

namespace GeeksForGeeks.Trees
{
    public class PrintCousinsNotSiblings
    {
        public static void Driver()
        {
            var rootNode = new BinaryNode(1);
            rootNode.Left = new BinaryNode(2);
            rootNode.Right = new BinaryNode(3);
            rootNode.Left.Left = new BinaryNode(4);
            rootNode.Left.Right = new BinaryNode(5);
            rootNode.Right.Left = new BinaryNode(6);
            rootNode.Right.Right = new BinaryNode(7);

            PrintCousins(rootNode, 5);
        }

        private static void PrintCousins(BinaryNode node, int key)
        {
            int level = GetNodeLevel(node, key, 1);
            var parentNode = GetParentNode(node, key);

            PrintSameLevelNodes(node, parentNode, level);

        }

        private static void PrintSameLevelNodes(BinaryNode node, BinaryNode parentNode, int level)
        {
            if (node == null || level < 2)
                return;

            if( level == 2)
            {
                if (node.Data == parentNode.Data)
                    return;

                if (node.Left != null)
                    Console.Write($"{node.Left.Data} ");
                
                if (node.Right != null)
                    Console.Write($"{node.Right.Data} ");
            }
            else if(level > 2)
            {
                PrintSameLevelNodes(node.Left, parentNode, level - 1);
                PrintSameLevelNodes(node.Right, parentNode, level - 1);
            }
        }

        private static BinaryNode GetParentNode(BinaryNode node, int key)
        {
            if (node == null)
                return null;
            
            if (node.Left != null && node.Left.Data == key)
                return node;

            if (node.Right != null && node.Right.Data == key)
                return node;

            var pNode = GetParentNode(node.Left, key);
            if (pNode != null)
                return pNode;
            
            return GetParentNode(node.Right, key);
        }

        private static int GetNodeLevel(BinaryNode node, int key, int level)
        {
            if (node == null)
                return 0;
            if (node.Data == key)
                return level;

            int lowLevel = GetNodeLevel(node.Left, key, level + 1);
            if (lowLevel > 0)
                return lowLevel;

            return GetNodeLevel(node.Right, key, level + 1);
        }
    }
}
