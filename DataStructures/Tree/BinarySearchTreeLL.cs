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
    }
}
