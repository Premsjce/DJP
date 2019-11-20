using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class BinarySearchTreeOrNot
    {
        public static void Driver()
        {
            Nody node = new Nody(3);
            node.Left = new Nody(2);
            node.Right = new Nody(5);
            node.Left.Left = new Nody(1);
            node.Right.Left = new Nody(4);

            BinaryTree binaryTree = new BinaryTree(node);
            if(binaryTree.IsBinarySearchTree)            
                Console.WriteLine($"Given tree is a Valid Binary Search Tree");
            else
                Console.WriteLine($"Not a Valid Binary Search Tree, Better luck next time");
        }
    }

    public class Nody
    {
        public Nody(int _data) => Data = _data;
        public Nody Left { get; set; }
        public Nody Right { get; set; }
        public int Data { get; set; }
    }

    public class BinaryTree
    {
        public BinaryTree(Nody rootNode) => Root = rootNode;
        public Nody Root { get; set; }
        public bool IsBinarySearchTree => IsValidBinarySearchTree(Root, int.MinValue, int.MaxValue);


        //First Approach.. Easier one
        //When firstcall happens then minValue = int.MinValue and maxValue = int.MaxValue
        private bool IsValidBinarySearchTree(Nody rootNode, int minValue, int maxValue)
        {
            if (rootNode == null)
                return true;

            if (rootNode.Left != null && rootNode.Left.Data > rootNode.Data)
                return false;

            if (rootNode.Right != null && rootNode.Right.Data < rootNode.Data)
                return false;

            return IsValidBinarySearchTree(rootNode.Left, minValue, rootNode.Data) && IsValidBinarySearchTree(rootNode.Right, rootNode.Data, maxValue);
        }

        //Second Approach.. Bit complex to understand
        private bool IsValidBinarySearchTree(Nody rootNode, Nody leftNode, Nody rightNode)
        {
            if (rootNode == null)
                return true;

            if (leftNode != null && leftNode.Data > rootNode.Data)
                return false;

            if (rightNode != null && rightNode.Data < rootNode.Data)
                return false;

            return IsValidBinarySearchTree(rootNode.Left, leftNode, rootNode) && IsValidBinarySearchTree(rootNode.Right, rootNode, rightNode);
        }
    }

    public class SelfBalancingBinarySearchTree : BinaryTree
    {
        public SelfBalancingBinarySearchTree(Nody rootNode) : base(rootNode) { }
    }
}
