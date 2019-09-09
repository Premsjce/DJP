using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class BST
    {
        public static void Driver()
        {
            BinarySearchTree binarySearchTree = new BinarySearchTree();

            binarySearchTree.Insert(16);
            binarySearchTree.Insert(8);
            binarySearchTree.Insert(24);
            binarySearchTree.Insert(4);
            binarySearchTree.Insert(12);
            binarySearchTree.Insert(20);
            binarySearchTree.Insert(28);
            binarySearchTree.Insert(2);
            binarySearchTree.Insert(6);
            binarySearchTree.Insert(10);
            binarySearchTree.Insert(14);
            binarySearchTree.Insert(18);
            binarySearchTree.Insert(22);
            binarySearchTree.Insert(26);
            binarySearchTree.Insert(30);
            binarySearchTree.Insert(1);
            binarySearchTree.Insert(3);
            binarySearchTree.Insert(5);
            binarySearchTree.Insert(7);
            binarySearchTree.Insert(9);
            binarySearchTree.Insert(11);
            binarySearchTree.Insert(13);
            binarySearchTree.Insert(15);
            binarySearchTree.Insert(17);
            binarySearchTree.Insert(19);
            binarySearchTree.Insert(21);
            binarySearchTree.Insert(23);
            binarySearchTree.Insert(25);
            binarySearchTree.Insert(27);
            binarySearchTree.Insert(29);
            binarySearchTree.Insert(31);


            

            Console.WriteLine("In ordred traversing of Tree");
            binarySearchTree.InOrderTraversal(binarySearchTree.Root);
            Console.WriteLine();
            Console.WriteLine("After deleting 4");
            binarySearchTree.Remove(binarySearchTree.Root, 4);
            binarySearchTree.InOrderTraversal(binarySearchTree.Root);

            Console.WriteLine();
            Console.WriteLine("After deleting 27");
            binarySearchTree.Remove(binarySearchTree.Root, 27);
            binarySearchTree.InOrderTraversal(binarySearchTree.Root);

            Console.WriteLine();
            Console.WriteLine("Is is valid binary tree {0}", binarySearchTree.ValidBST());
        }
    }

    public class BinaryNode
    {
        public BinaryNode(int data)
        {
            Data = data;
            Left = Right = null;
        }

        public int Data { get; set; }
        public BinaryNode Left { get; set; }
        public BinaryNode Right { get; set; }
    }

    public class BinarySearchTree
    {

        public BinaryNode Root { get; private set; }


        private BinaryNode InsertRecursively(BinaryNode root, int data)
        {
            if (root == null)
            {
                root = new BinaryNode(data);
                return root;
            }
            if (data > root.Data)
                root.Right = InsertRecursively(root.Right, data);
            else if (data < root.Data)
                root.Left =  InsertRecursively(root.Left, data);
            else
                throw new InvalidOperationException("all the data should be unique in BST");

            return root;
        }

        public void Insert(int data)
        {
            if (Root == null)
            {
                Root = new BinaryNode(data);
                return;
            }

            //Recursive approarch
            InsertRecursively(Root, data);

            #region Iterative Approach
            //var currentNode = Root;
            //while (true)
            //{
            //    if (data < currentNode.Data)
            //    {
            //        if (currentNode.Left == null)
            //        {
            //            var newNode = new BinaryNode(data);
            //            currentNode.Left = newNode;
            //            return;
            //        }
            //        currentNode = currentNode.Left;
            //    }
            //    else if (data > currentNode.Data)
            //    {
            //        if (currentNode.Right == null)
            //        {
            //            var newNode = new BinaryNode(data);
            //            currentNode.Right = newNode;
            //            return;
            //        }
            //        currentNode = currentNode.Right;
            //    }
            //    else
            //    {
            //        Console.WriteLine("In Binary search tree, all the value mush be unique");
            //    }
            //}
            #endregion
        }

        public BinaryNode Search(int data)
        {
            if (Root == null)
            {
                Console.WriteLine("There are no nodes in tree");
                return null;
            }
            var currentNode = Root;
            while (currentNode != null)
            {
                if (data < currentNode.Data)
                    currentNode = currentNode.Left;
                else if (data > currentNode.Data)
                    currentNode = currentNode.Right;
                else
                    return currentNode;
            }
            Console.WriteLine("Value cannot be found");
            return null;
        }
        
        public BinaryNode Remove(BinaryNode root, int data)
        {
            if (root == null)
                return root;
            else if (data < root.Data)
                root.Left = Remove(root.Left, data);
            else if (data > root.Data)
                root.Right = Remove(root.Right, data);
            else
            {
                //Case 1 : Only one or Zero child
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;

                //Case 3 : 2 Children
                root.Data = GetMinNode(root.Right).Data;  //Or get Max in root's left subtree
                root.Right = Remove(root.Right, root.Data);
            }
            return root;
        }

        private BinaryNode GetMinNode(BinaryNode root)
        {
            if (root.Left == null)
                return root;
            return GetMinNode(root.Left);
        }

        public void InOrderTraversal(BinaryNode root)
        {
            if (root.Left != null)
                InOrderTraversal(root.Left);

            Console.Write(root.Data + " ");

            if (root.Right != null)
                InOrderTraversal(root.Right);
            return;
        }

        public bool ValidBST()
        {
            return ValidBSTSimplified(Root, null, null);
            
            //return ValidBST(Root,int.MaxValue, int.MinValue);
        }

        private bool ValidBST(BinaryNode node, int max, int min)
        {
            if (node == null)
                return true;

            if (node.Data < min || node.Data > max)
                return false;

            return ValidBST(node.Left, node.Data, min) && ValidBST(node.Right, max, node.Data);
        }

        private bool ValidBSTSimplified(BinaryNode rootNode, BinaryNode leftNode, BinaryNode rightNode)
        {
            if (rootNode == null)
                return true;

            if (leftNode != null && rootNode.Data <= leftNode.Data)
                return false;

            if (rightNode != null && rootNode.Data >= rightNode.Data)
                return false;

            return ValidBSTSimplified(rootNode.Left, leftNode, rootNode) && ValidBSTSimplified(rootNode.Right, rootNode, rightNode);
        }

    }
}
