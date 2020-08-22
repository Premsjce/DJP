using System;

namespace DataStructures
{
    public class BST
    {
        public static void Driver()
        {

            
            BinarySearchTree binarySearchTree = new BinarySearchTree();

            //binarySearchTree.InsertRange(new int[] { 16, 8, 24, 4, 12, 20, 28, 2, 6, 10, 14, 18, 22, 26, 30, 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25 });
            //binarySearchTree.Insert(27);
            //binarySearchTree.Insert(29);
            //binarySearchTree.Insert(31);

            binarySearchTree.InsertRange(new int[] { 4, 2, 6});
            Console.WriteLine();

            binarySearchTree.ValidBST();

            Console.WriteLine("In ordred traversing of Tree");
            binarySearchTree.InOrderTraversal(binarySearchTree.Root);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Reverse Order traversing of Tree");
            binarySearchTree.ReverseOrderTraversal(binarySearchTree.Root);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Pre Order traversing of Tree");
            binarySearchTree.PreOrderTraversal(binarySearchTree.Root);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Post Order traversing of Tree");
            binarySearchTree.PostOrderTraversal(binarySearchTree.Root);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("After deleting 4");
            binarySearchTree.Remove(binarySearchTree.Root, 4);
            binarySearchTree.InOrderTraversal(binarySearchTree.Root);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("After deleting 27");
            binarySearchTree.Remove(binarySearchTree.Root, 27);
            binarySearchTree.InOrderTraversal(binarySearchTree.Root);
            Console.WriteLine();


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

        private void InsertIteratively(int data)
        {
            var currentNode = Root;
            while (true)
            {
                if (data < currentNode.Data)
                {
                    if (currentNode.Left == null)
                    {
                        var newNode = new BinaryNode(data);
                        currentNode.Left = newNode;
                        return;
                    }
                    currentNode = currentNode.Left;
                }
                else if (data > currentNode.Data)
                {
                    if (currentNode.Right == null)
                    {
                        var newNode = new BinaryNode(data);
                        currentNode.Right = newNode;
                        return;
                    }
                    currentNode = currentNode.Right;
                }
                else
                {
                    Console.WriteLine("In Binary search tree, all the value mush be unique");
                }
            }
        }

        public void InsertRange(int[] range)
        {
            if (Root == null)
            {
                Root = new BinaryNode(range[0]);
            }

            for(int i = 1; i < range.Length;i++)
                InsertRecursively(Root, range[i]);
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

            //Iterative Approach
            //InsertIteratively(data);
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
                //Case 1 : Only One or Zero child
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;

                //Case 2 : 2 Children
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

            if (root != null)
                Console.Write(root.Data + " ");

            if (root.Right != null)
                InOrderTraversal(root.Right);
        }

        public void PreOrderTraversal(BinaryNode root)
        {
            if (root != null)
                Console.Write($"{root.Data} ");

            if (root.Left != null)
                PreOrderTraversal(root.Left);

            if (root.Right != null)
                PreOrderTraversal(root.Right);

        }

        public void PostOrderTraversal(BinaryNode root)
        {

            if (root.Left != null)
                PostOrderTraversal(root.Left);

            if (root.Right != null)
                PostOrderTraversal(root.Right);

            if (root != null)
                Console.Write($"{root.Data} ");

        }

        public void ReverseOrderTraversal(BinaryNode root)
        {
            if (root.Right != null)
                ReverseOrderTraversal(root.Right);

            if (root != null)
                Console.Write(root.Data + " ");

            if (root.Left != null)
                ReverseOrderTraversal(root.Left);
        }

        public bool ValidBST()
        {
            return SimpletBSTValidation(Root);
            //return ValidBSTSimplified(Root, null, null);

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

        public bool SimpletBSTValidation(BinaryNode root)
        {
            if (root == null)
                return true;
            if (root.Left != null && root.Left.Data > root.Data)
                return false;

            if (root.Right != null && root.Right.Data < root.Data)
                return false;

            return SimpletBSTValidation(root.Left) && SimpletBSTValidation(root.Right);

        }

    }
}
