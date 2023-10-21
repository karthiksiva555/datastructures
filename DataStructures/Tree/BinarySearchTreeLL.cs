using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree
{
    public class BinarySearchTreeLL
    {
        public BinaryTreeNode? Root { get; set; }

        public void Insert(int value)
        {
            if (Root == null)
            {
                Root = new BinaryTreeNode(value);
                return;
            }

            var node = GetNode(value);
            if (node.Value > value)
                node.Left = new BinaryTreeNode(value);
            else
                node.Right = new BinaryTreeNode(value);
        }

        private BinaryTreeNode GetNode(int value)
        {
            var current = Root;
            BinaryTreeNode prev = null;
            while (current != null)
            {
                prev = current;
                current = current.Value < value ? current.Right : current.Left;
            }
            
            return prev;
        }

        /// <summary>
        /// checks if the tree has a node with a given value 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Find(int value)
        {
            var current = Root;
            
            while (current != null)
            {
                if (current.Value == value) return true;
                current = current.Value < value ? current.Right : current.Left;
            }

            return false;
        }

        public int MaxValue()
        {
            if (Root == null)
                throw new InvalidOperationException("Operation cannot be performed because the tree is empty");
         
            return MaxValue(Root);
        }

        // In BST, the max value will be at the right most leaf
        private static int MaxValue(BinaryTreeNode node)
        {
            return node.Right == null ? node.Value : MaxValue(node.Right);
        }

        private static int Height(BinaryTreeNode? node)
        {
            if (node == null) return 0;

            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }
        
        #region AVL Tree Exercises

        public bool IsPerfect()
        {
            var leafDepth = -1;
            return IsPerfect(Root, 0, ref leafDepth);
        }

        // Alternative Algorithm to check if tree is perfect:
        // return size() == (Math.pow(2, height() + 1) - 1); => total number of nodes in tree must be equal to 2^(h+1) -1 where h is height
        private static bool IsPerfect(BinaryTreeNode? node, int depth, ref int leafDepth)
        {
            if (node == null) return true;

            // Leaf scenario: if visiting first leaf => leafDepth is currently -1, so set the current depth as leafDepth
            //                if not visiting leaf node, leafDepth is already set, so check if the depth of current leaf node matches with depth of previously visited leaf nodes 
            if (node.Left == null && node.Right == null)
            {
                if (leafDepth == -1)
                    leafDepth = depth;
                if (depth != leafDepth)
                    return false;
            }

            // If the current node doesn't have both children => tree is not perfect => return false
            if ((node.Left == null && node.Right != null) || (node.Right == null && node.Left != null))
                return false;

            // increase the depth by 1 and check if both left and right subtrees are perfect
            return IsPerfect(node.Left, depth + 1, ref leafDepth) && IsPerfect(node.Right, depth + 1, ref leafDepth);
        }
        
        
        public bool IsBalancedBetter()
        {
            return CheckHeight(Root) != -1;
        }
        
        private static int CheckHeight(BinaryTreeNode? node)
        {
            if (node == null) return 0;

            var leftHeight = CheckHeight(node.Left);
            if (leftHeight == -1)
                return -1; // Left subtree is not balanced, no need to check the right subtree

            var rightHeight = CheckHeight(node.Right);
            if (rightHeight == -1)
                return -1; // Right subtree is not balanced.

            if (Math.Abs(leftHeight - rightHeight) > 1)
                return -1; // Tree is unbalanced at current node
            
            return Math.Max(leftHeight, rightHeight) + 1;
        }
        
        
        public bool IsBalanced()
        {
            return IsBalanced(Root);
        }
        
        /// <summary>
        /// This algorithm works but takes O(n^2) as
        /// We calculate the height of each node ahead => O(n)
        /// We make recursive calls on each node to IsBalanced => O(n)
        /// Each node => height calculation * IsBalanced => O(n^2) 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static bool IsBalanced(BinaryTreeNode? node)
        {
            if (node == null) return true;

            return Math.Abs(Height(node.Left) - Height(node.Right)) <= 1 && IsBalanced(node.Left) &&
                   IsBalanced(node.Right);
        } 
        
        private static int BalanceFactor(BinaryTreeNode? node)
        {
            if (node == null) return 0;

            if (node.Left == null && node.Right == null) return -1;
            
            return 1 + Math.Abs(BalanceFactor(node.Left) - BalanceFactor(node.Right));
        }

        // private static int HeightDifference(BinaryTreeNode? node)
        // {
        //     if (node == null) return 0;
        //
        //     if (node.Left == null && node.Right == null) return -1;
        //
        //     return 1 + Math.Abs(HeightDifference(node.Left) - HeightDifference(node.Right));
        // }

        #endregion
    }
}
