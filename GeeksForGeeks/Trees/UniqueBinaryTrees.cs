using System;
using System.Collections.Generic;

namespace GeeksForGeeks.Trees
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }


    public class UniqueBinaryTrees
    {
        public static void Driver()
        {
            int n = 3;

            var result = GetUniqueTreesRecursive(1, n);

            foreach (var node in result)
            {
                PreOrder(node);
                Console.WriteLine();
            }
        }

        private static void PreOrder(TreeNode node)
        {
            if (node == null)
                return;

            Console.Write(node.val + " ");
            PreOrder(node.left);
            PreOrder(node.right);
        }

        public static List<TreeNode> GetUniqueTreesRecursive(int start, int end)
        {
            var list = new List<TreeNode>();

            if (start > end)
            {
                list.Add(null);
                return list;
            }

            for (int i = start; i <= end; i++)
            {
                List<TreeNode> leftTree = GetUniqueTreesRecursive(start, i - 1);
                List<TreeNode> rightTree = GetUniqueTreesRecursive(i + 1, end);

                for (int j = 0; j < leftTree.Count; j++)
                {
                    var leftNode = leftTree[j];
                    for (int k = 0; k < rightTree.Count; k++)
                    {
                        var rightNode = rightTree[k];
                        var node = new TreeNode(i);
                        node.left = leftNode;
                        node.right = rightNode;

                        list.Add(node);
                    }
                }

            }
            return list;
        }
    }
}