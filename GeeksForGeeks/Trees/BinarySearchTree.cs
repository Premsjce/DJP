using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Trees
{
    public class BinarySearchTree
    {
        public static void Drvier()
        {
            var rootNode = new BinaryNode(6);
            rootNode.Left = new BinaryNode(-13);
            rootNode.Left.Right = new BinaryNode(-8);
            rootNode.Right = new BinaryNode(14);
            rootNode.Right.Left = new BinaryNode(13);
            rootNode.Right.Left.Left = new BinaryNode(7);
            rootNode.Right.Right = new BinaryNode(15);

            Console.WriteLine(IsBSTSimplified(rootNode, null, null));
        }

        private static bool IsTreeABinarySearchTree(BinaryNode rootNode)
        {
            if (rootNode == null)
                return true;

            if (rootNode.Left != null && rootNode.Left.Data > rootNode.Data)
                return false;
            
            if (rootNode.Right != null && rootNode.Right.Data < rootNode.Data)
                return false;

            return IsTreeABinarySearchTree(rootNode.Left) && IsTreeABinarySearchTree(rootNode.Right);
        }

        private static bool IsBSTUtility(BinaryNode node, int minValue, int maxValue)
        {
            if (node == null)
                return true;

            if (node.Data < minValue || node.Data > maxValue)
                return false;


            return IsBSTUtility(node.Left, minValue, node.Data - 1) && IsBSTUtility(node.Right, node.Data + 1, maxValue);
        }

        private static bool IsBSTSimplified(BinaryNode rootNode, BinaryNode leftNode, BinaryNode rightNode)
        {
            if (rootNode == null)
                return true;

            if (leftNode != null && rootNode.Data < leftNode.Data)
                return false;

            if (rightNode != null && rootNode.Data > rightNode.Data)
                return false;

            return IsBSTSimplified(rootNode.Left, leftNode, rootNode) && IsBSTSimplified(rootNode.Right, rootNode, rightNode);
        }
    }
}
