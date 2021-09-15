using DataStructures;
using System;

namespace GeeksForGeeks.Trees
{
    public class NodeLevel
    {
        public static void Driver()
        {
            var rootNode = new BinaryNode(3);
            rootNode.Left = new BinaryNode(2);
            rootNode.Right = new BinaryNode(5);
            rootNode.Left.Left = new BinaryNode(1);
            rootNode.Left.Right = new BinaryNode(4);

            Console.WriteLine(GetNodeLevel(rootNode, -9));

        }

        private static int GetNodeLevel(BinaryNode rootNode, int key)
        {
            return GetNodeLevelUtility(rootNode, key, 1);
        }


        private static int GetNodeLevelUtility(BinaryNode node, int key, int level)
        {
            if (node == null) return 0;

            if (node.Data == key) return level;

            int downLevel = GetNodeLevelUtility(node.Left, key, level + 1);
            if (downLevel != 0)
                return downLevel;

            return GetNodeLevelUtility(node.Right, key, level + 1);
        }
    }
}