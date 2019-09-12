using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class AVLTree
    {
        public static void Driver()
        {
            AVL avlTree = new AVL();
            for(int i = 1; i <= 40; i++)
                avlTree.Add(i);

            avlTree.DisplayTree();
            Console.WriteLine();

            avlTree.Delete(15);
            avlTree.DisplayTree();
            Console.WriteLine();

            avlTree.Delete(3);
            avlTree.DisplayTree();
            Console.WriteLine();
        }
    }

    public class AVL
    {
        #region Member
        private BinaryNode Root { get; set; }
        #endregion

        #region Insert

        public void Add(int data)
        {
            var newItem = new BinaryNode(data);
            if (Root == null)
                Root = newItem;
            else
                Root = RecursivelyInsert(Root, newItem);
        }

        private BinaryNode RecursivelyInsert(BinaryNode current, BinaryNode newItem)
        {
            if (current == null)
            {
                current = newItem;
                return current;
            }
            else if (newItem.Data < current.Data)
            {
                current.Left = RecursivelyInsert(current.Left, newItem);
                current = BalanceTree(current);
            }
            else if (newItem.Data > current.Data)
            {
                current.Right = RecursivelyInsert(current.Right, newItem);
                current = BalanceTree(current);
            }

            return current;
        }

        #endregion

        #region Find and Display
        public void Find(int data)
        {
            if(FindValue(data,Root).Data == data)
                Console.WriteLine($"{data} was found");
            else
                Console.WriteLine($"Nothing found");
        }

        private BinaryNode FindValue(int target, BinaryNode current)
        {
            if (target < current.Data)
                return FindValue(target, current.Left);
            else if (target > current.Data)
                return FindValue(target, current.Right);
            else
                return current;            
        }

        public void DisplayTree()
        {
            if(Root == null)
            {
                Console.WriteLine($"Tree is empty");
                return;
            }
            InOrderDisplay(Root);
        }

        private void InOrderDisplay(BinaryNode current)
        {
            if(current !=null)
            {
                InOrderDisplay(current.Left);
                Console.Write($"{current.Data} ");
                InOrderDisplay(current.Right);
            }
        }
        #endregion

        #region Balance Tree

        private BinaryNode BalanceTree(BinaryNode current)
        {
            var balanceFactor = GetBalanceFactor(current);

            //If BF is > 1, then its left heavy, else its right heavy
            if (balanceFactor > 1)
            {
                if (GetBalanceFactor(current.Left) > 0)
                {
                    //LeftRightRotation , Becuase insertion is left and right
                    current = LeftRightRotation(current);                    
                }
                else
                {
                    //RightRotatiaon : beacause insertion is LeftLeft
                    current = RightRotation(current);
                }
            }
            else if (balanceFactor < -1)
            {
                if (GetBalanceFactor(current.Right) > 0)
                {
                    //RightLeftRotation , Becuase insertion is right and left
                    current = RightLeftRotation(current);                    
                }
                else
                {
                    //Left rotataion : Because it Right Right insertion
                    current = LeftRotation(current);                    
                }
            }
            return current;
        }

        private int GetBalanceFactor(BinaryNode current)
        {
            int leftHeight = GetHeight(current.Left);
            int rightHeight = GetHeight(current.Right);

            return leftHeight - rightHeight;
        }

        private int GetHeight(BinaryNode node)
        {
            int height = 0;
            if (node != null)
            {
                var leftHeight = GetHeight(node.Left);
                var rightHeight = GetHeight(node.Right);
                height = Max(leftHeight, rightHeight) + 1;
            }

            return height;
        }

        private int Max(int first, int second) => first > second ? first : second;

        #endregion

        #region Delete

        public void Delete(int data)
        {
            Root = RecursivelyDelete(Root, data);
        }

        private BinaryNode RecursivelyDelete(BinaryNode current, int target)
        {
            if (current == null)
                return null;

            if (target < current.Data)
            {
                current.Left = RecursivelyDelete(current.Left, target);
            }
            else if(target > current.Data)
            {
                current.Right = RecursivelyDelete(current.Right, target);
            }
            //now the target is found
            else
            {
                if (current.Right != null)
                {

                    var minNode = GetMinNode(current.Right);
                    var tempNode = minNode;
                    minNode = current;
                    current = tempNode;

                    current = RecursivelyDelete(minNode, tempNode.Data);
                    current = BalanceTree(minNode);
                }
                else
                {
                    return current.Left;
                }
            }

            return current;
        }

        private BinaryNode GetMinNode(BinaryNode currentNode)
        {
            if (currentNode.Left == null)
                return currentNode;
            return GetMinNode(currentNode.Left);
        }

        private BinaryNode GetMaxNode(BinaryNode currentNode)
        {
            if (currentNode.Right == null)
                return currentNode;
            return GetMaxNode(currentNode.Right);
        }

        #endregion

        #region Rotataions

        private BinaryNode RightRotation(BinaryNode parent)
        {
            BinaryNode pivotNode = parent.Left;
            parent.Left = pivotNode.Right;
            pivotNode.Right = parent;
            return pivotNode;
        }

        private BinaryNode LeftRotation(BinaryNode parent)
        {
            BinaryNode pivotNode = parent.Right;
            parent.Right = pivotNode.Left;
            pivotNode.Left = parent;
            return pivotNode;
        }

        private BinaryNode LeftRightRotation(BinaryNode parent)
        {
            BinaryNode pivot = parent.Right;
            parent.Right = LeftRotation(pivot);
            return RightRotation(parent);            
        }

        private BinaryNode RightLeftRotation(BinaryNode parent)
        {
            BinaryNode pivot = parent.Left;
            parent.Left = RightRotation(pivot);
            return LeftRotation(parent);            
        }
        #endregion
    }
}
