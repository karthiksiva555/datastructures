using System;
using System.Collections.Generic;

namespace DataStructures.Tree
{
    // Unit tests yet to be written
    public class BinaryTreeLL : IBinaryTree
    {
        public BinaryTreeNode Root { get; set; }
        
        public BinaryTreeLL()
        {
            
        }

        #region Traversal

        public void PreOrderTraversal()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("   Pre-Order Traversal of Binary Tree   ");
            Console.WriteLine("----------------------------------------------");
            PreOrderTraversal(Root);
        }

        public void InOrderTraversal()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("   In-Order Traversal of Binary Tree   ");
            Console.WriteLine("----------------------------------------------");
            InOrderTraversal(Root);
        }

        public void PostOrderTraversal()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("   Post-Order Traversal of Binary Tree   ");
            Console.WriteLine("----------------------------------------------");
            PostOrderTraversal(Root);
        }

        // 1. pre-order: Root (Left) (Right)
        public virtual void PreOrderTraversal(BinaryTreeNode node)
        {
            //Base condition
            if (node == null) return;

            // print the value 
            Console.WriteLine(node.Value);

            // traverse left and then Right sub-tree
            PreOrderTraversal(node.Left);
            PreOrderTraversal(node.Right);
        }

        // 2. in-order 
        public void InOrderTraversal(BinaryTreeNode node)
        {
            //Base condition
            if (node == null) return;

            InOrderTraversal(node.Left);
            Console.WriteLine(node.Value);
            InOrderTraversal(node.Right);
        }

        // 3. post-order
        public void PostOrderTraversal(BinaryTreeNode node)
        {
            //Base condition
            if (node == null) return;

            PostOrderTraversal(node.Left);
            PostOrderTraversal(node.Right);
            Console.WriteLine(node.Value);
        }

        // 4. Level Order Traversal
        public void LevelOrderTraversal()
        {
            if (Root == null) return;

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("   Level-Order Traversal of Binary Tree   ");
            Console.WriteLine("----------------------------------------------");
            
            var node = Root;
            var queue = new Queue<BinaryTreeNode>();
            queue.Enqueue(node);
            while (queue.Count != 0)
            {
                var newNode = queue.Dequeue();
                Console.WriteLine(newNode.Value);
                if(newNode.Left!=null) queue.Enqueue(newNode.Left);
                if(newNode.Right!=null) queue.Enqueue(newNode.Right);
            }
        }

        #endregion

        public void AddNode(int value)
        {
            if (Root == null)
            {
                var node = new BinaryTreeNode(value);
                Root = node;
            }
            else
            {
                // do level order traversal and findout the next available vacant node
                var queue = new Queue<BinaryTreeNode>();
                var newNode = new BinaryTreeNode(value);
                queue.Enqueue(Root);
                while (queue.Count != 0)
                {
                    var node = queue.Dequeue();
                    if (node.Left == null)
                    {
                        node.Left = newNode;
                        break;
                    }
                    else if (node.Right == null)
                    {
                        node.Right = newNode;
                        break;
                    }
                    else
                    {
                        queue.Enqueue(node.Left);
                        queue.Enqueue(node.Right);
                    }
                }
            }
        }

        public void DeleteNode(int value)
        {
            if (Root == null) return;

            if (Root.Value == value)
            {
                DeleteNode(Root, value);
                return;
            }

            var queue = new Queue<BinaryTreeNode>();

            queue.Enqueue(Root);
            while (queue.Count != 0)
            {
                var newNode = queue.Dequeue();
                if (newNode.Left?.Value == value || newNode.Right?.Value == value)
                    DeleteNode(newNode, value);
                else
                {
                    if (newNode.Left != null) queue.Enqueue(newNode.Left);
                    if (newNode.Right != null) queue.Enqueue(newNode.Right);
                }
            }
        }

        private void DeleteNode(BinaryTreeNode node, int value)
        {
            // if node is Root
            // Handle it later

            var nodeToDelete = node.Left?.Value == value ? node.Left :
                node.Right?.Value == value ? node.Right :
                null;

            if (nodeToDelete == null) return;

            var isLeft = node.Left.Value == value;

            if (nodeToDelete.Left == null && nodeToDelete.Right == null)
                _ = isLeft ? node.Left = null : node.Right = null;
            else if (nodeToDelete.Left != null && nodeToDelete.Right != null)
            {
                var rightNode = nodeToDelete.Right;
                _ = isLeft ? node.Left = nodeToDelete.Left : node.Right = nodeToDelete.Left;
                _ = isLeft ? node.Left.Right = rightNode : node.Right.Right = nodeToDelete.Left;
            }
            else if (nodeToDelete.Left != null)
                _ = isLeft ? node.Left = nodeToDelete.Left : node.Right = nodeToDelete.Left;
            else
                _ = isLeft ? node.Left = nodeToDelete.Right : node.Right = nodeToDelete.Right;
        }

        public bool SearchTree(int value)
        {
            // as Level Order traversal uses queue, which is faster than system stack (used by recursion)
            // use Level Order traversal 
            if (Root == null) return false;
            if (Root.Value == value) return true;

            var queue = new Queue<BinaryTreeNode>();

            queue.Enqueue(Root);
            while (queue.Count != 0)
            {
                var newNode = queue.Dequeue();
                if (newNode == null) return false;
                if (newNode.Value == value) return true;
                queue.Enqueue(newNode.Left);
                queue.Enqueue(newNode.Right);
            }
            return false;
        }

        public void DeleteTree()
        {
            Root = null;
        }
    }
}
