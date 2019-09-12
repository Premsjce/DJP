using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class RBLTree
    {
        public static void Driver()
        {
            var rbTree = new RedBlackTree<int, string>();

            for (int i = 1; i <= 40; i++)
                rbTree.Add(i, $"Item : {i}");

            rbTree.DisplayTree();
        }
    }

    public class RedBlackTree<TKey,TData>
    {
        public RedBlackTreeNode<TKey,TData> Root { get; private set; }
        private readonly RedBlackTreeNode<TKey, TData> leaf = RedBlackTreeNode<TKey, TData>.CreateLeaf();

        public RedBlackTree() => Root = leaf;        

        public void Add(TKey key, TData data)
        {
            var node = RedBlackTreeNode<TKey, TData>.CreateNode(key, data, NodeColor.Red, key.GetHashCode());
            Insert(node);
        }

        private void Insert(RedBlackTreeNode<TKey, TData> node)
        {
            var parentForInsertion = leaf;
            var tempNode = Root;

            //When tempNode becomes a leaf node, then new node can be insterted at that place,
            //And that leafNode's parent is present in parentForInsertion
            while (tempNode != leaf)
            {
                parentForInsertion = tempNode;
                tempNode = node.HashKey < tempNode.HashKey ? tempNode.Left : tempNode.Right;
            }

            node.Parent = parentForInsertion;

            if (parentForInsertion == leaf)
                Root = node;
            else if (node.HashKey < parentForInsertion.HashKey)
                parentForInsertion.Left = node;
            else
                parentForInsertion.Right = node;

            node.Left = node.Right = leaf;
            node.Color = NodeColor.Red;

            InsertFixUp(node);
        }

        private void InsertFixUp(RedBlackTreeNode<TKey, TData> node)
        {
            while(node.Parent.Color == NodeColor.Red)
            {
                if(node.Parent == node.GrandParent.Left)
                {
                    if(node.Uncle.Color == NodeColor.Red)
                    {
                        node.Parent.Color = NodeColor.Black;
                        node.Uncle.Color = NodeColor.Black;
                        node.GrandParent.Color = NodeColor.Red;
                        node = node.GrandParent;
                    }
                    else
                    {
                        if(node == node.Parent.Right)
                        {
                            node = node.Parent;
                            RotateLeft(node);
                        }

                        node.Parent.Color = NodeColor.Black;
                        node.GrandParent.Color = NodeColor.Red;
                        RotateRight(node.GrandParent);
                    }
                }
                else
                {
                    if(node.Uncle.Color == NodeColor.Red)
                    {
                        node.Parent.Color = NodeColor.Black;
                        node.Color = NodeColor.Black;
                        node.GrandParent.Color = NodeColor.Red;
                        node = node.GrandParent;
                    }
                    else
                    {
                        if(node == node.Parent.Left)
                        {
                            node = node.Parent;
                            RotateRight(node);
                        }
                        node.Parent.Color = NodeColor.Black;
                        node.GrandParent.Color = NodeColor.Red;
                        RotateLeft(node.GrandParent);
                    }

                }
            }

            Root.Color = NodeColor.Black;
        }

        private void RotateLeft(RedBlackTreeNode<TKey, TData> node)
        {
            var pivotNode = node.Right;
            node.Right = pivotNode.Left;

            if (pivotNode.Left != leaf)
                pivotNode.Left.Parent = node;

            pivotNode.Parent = node.Parent;

            if (node.Parent == leaf)
                Root = pivotNode;
            else if (node == node.Parent.Left)
                node.Parent.Left = pivotNode;
            else
                node.Parent.Right = pivotNode;

            pivotNode.Left = node;
            node.Parent = pivotNode;
            
        }

        private void RotateRight(RedBlackTreeNode<TKey, TData> node)
        {
            var pivotNode = node.Left;
            node.Left = pivotNode.Right;

            if (pivotNode.Right != leaf)
                pivotNode.Right.Parent = node;

            pivotNode.Parent = node.Parent;

            if (node.Parent == leaf)
                Root = pivotNode;
            else if (node == node.Parent.Left)
                node.Parent.Left = pivotNode;
            else
                node.Parent.Right = pivotNode;

            pivotNode.Right = node;
            node.Parent = pivotNode;
        }

        public void DisplayTree()
        {
            RecursiveInOrderDisplay(Root);
        }

        private void RecursiveInOrderDisplay(RedBlackTreeNode<TKey, TData> root)
        {
            if (root.Left != null)
                RecursiveInOrderDisplay(root.Left);
            if(root.Data != null)
                Console.WriteLine(root.Data);
            if (root.Right != null)
                RecursiveInOrderDisplay(root.Right);
        }
    }

    public enum NodeColor
    {
        Red,
        Black
    }

    public class RedBlackTreeNode<TKey, TData>
    {
        public readonly TData Data;
        public readonly TKey Key;
        public readonly int HashKey;
        public readonly bool IsLeaf;
        public NodeColor Color;

        public RedBlackTreeNode<TKey, TData> Parent;
        public RedBlackTreeNode<TKey, TData> Left;
        public RedBlackTreeNode<TKey, TData> Right;

        public RedBlackTreeNode<TKey, TData> GrandParent => Parent?.Parent;
        public RedBlackTreeNode<TKey, TData> Sibling => Parent == null ? null : Parent.Right == this ? Parent.Left : Parent.Right;
        public RedBlackTreeNode<TKey, TData> Uncle => Parent?.Sibling;


        public static RedBlackTreeNode<TKey, TData> CreateLeaf()
        {
            return new RedBlackTreeNode<TKey, TData>();
        }

        public static RedBlackTreeNode<TKey, TData> CreateNode(TKey key, TData data, NodeColor color, int hashKey)
        {
            return new RedBlackTreeNode<TKey, TData>(key, data, color, hashKey);
        }

        internal RedBlackTreeNode(TKey key, TData data, NodeColor color, int hashKey)
        {
            Key = key;
            Data = data;
            Color = color;
            HashKey = hashKey;
        }

        internal RedBlackTreeNode()
        {
            IsLeaf = true;
            Color = NodeColor.Black;
            HashKey = 0;
        }


    }
}
