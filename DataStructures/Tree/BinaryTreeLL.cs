using System;
using System.Collections.Generic;

namespace DataStructures.Tree
{
    // Unit tests yet to be written
    public class BinaryTreeLL : IBinaryTree
    {
        public BinaryTreeNode? Root { get; set; }
       
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
        protected virtual void PreOrderTraversal(BinaryTreeNode? node)
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
        protected virtual void InOrderTraversal(BinaryTreeNode? node)
        {
            //Base condition
            if (node == null) return;

            InOrderTraversal(node.Left);
            Console.WriteLine(node.Value);
            InOrderTraversal(node.Right);
        }

        // 3. post-order
        protected virtual  void PostOrderTraversal(BinaryTreeNode? node)
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

        public void LevelOrderTraversalUsingHeight()
        {
            var height = Height(Root);

            for (var i = 0; i <= height; i++)
            {
                PrintNodesWithDistanceK(i);
            }
        }
        
        #endregion

        public void PrintNodesWithDistanceK(int k)
        {
            PrintNodesWithDistanceK(Root, k);
        }

        private void PrintNodesWithDistanceK(BinaryTreeNode? node, int k)
        {
            if (node == null) return;
            
            if (k == 0)
            {
                Console.WriteLine(node.Value);
                return;
            }
            
            PrintNodesWithDistanceK(node.Left, k-1);
            PrintNodesWithDistanceK(node.Right, k-1);
        }
        
        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTree(Root, int.MinValue, int.MaxValue);
        }
        
        public bool IsBinarySearchTreeWrong()
        {
            return IsBinarySearchTreeWrong(Root);
        }
        
        /// <summary>
        /// IsBinarySearchTreeWrong() is to check if the current tree is BST or not, but this method can take any tree as input
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBst(BinaryTreeNode? root)
        {
            // return IsBinarySearchTreeWrong(root);
            return IsBinarySearchTree(root, int.MinValue, int.MaxValue);
        }

        private bool IsBinarySearchTree(BinaryTreeNode? node, int min, int max)
        {
            if (node == null)
                return true;

            // Is the root satisfying BST?
            if (node.Value <= min || node.Value >= max)
                return false;

            return IsBinarySearchTree(node.Left, min, node.Value) && IsBinarySearchTree(node.Right, node.Value, max);
        }
        
        // This algorithm is wrong as it only checks if the current subtree is satisfying BST or not; it doesn't check if the current subtree is satisfying BST as a whole
        // Example: construct the tree with 5, 3, 7, 2, 8, 9; this algorithm says this is a valid BST but 8 gets inserted as right child of 3 in the left subtree of root 5. As per BST, all the values in left subtree must be less than the root => but child 8 is greater than root 5 => this is not a valid BST
        // To fix this: When validating a node, we should check each and every node in that subtree (child, grandchild etc) but this is not efficient as we will be validating same node multiple times: For example: tree => 5, 3, 7, 2, 4, 9=> nodes 2, 4 are validated when validating 5 and also 3. Memoization may fix this issue if we want to go this route but additional space required and time complexity increases as we need to check hashtable (node, isValid) everytime.
        private bool IsBinarySearchTreeWrong(BinaryTreeNode? node)
        {
            if (node == null)
                return true;
            
            if (node.Left == null && node.Right == null)
                return true;

            // The && operator helps with early termination; when root is not bst, left and right are not evaluated. when root is bst but left is not, right is not evaluated.
            return (node.Left == null || node.Left.Value < node.Value) && (node.Right == null || node.Right.Value > node.Value) // IsRootBst?
                && IsBinarySearchTreeWrong(node.Left) // Is left subtree BST?
                && IsBinarySearchTreeWrong(node.Right); // Is right subtree BST?
        }
        
        /// <summary>
        /// Checks if the current tree is equal to the tree passed as argument
        /// Two trees are equal if => roots, left subtrees and right subtrees are equal
        /// </summary>
        /// <param name="tree">The tree to compare</param>
        /// <returns>True if two trees are equal; false otherwise</returns>
        public bool Equals(BinaryTreeLL? tree)
        {
            if (tree == null)
            {
                return false;
            }
            
            return Equals(Root, tree.Root);
        }

        // Equals is using the Pre-Order traversal; because, we get the root note first and then left, right
        private static bool Equals(BinaryTreeNode? node1, BinaryTreeNode? node2)
        {
            // if both nodes are null => equal
            if (node1 == null && node2 == null)
                return true;

            if (node1 == null || node2 == null)
                return false;

            return node1.Value == node2.Value && Equals(node1.Left, node2.Left) && Equals(node1.Right, node2.Right);
        }

        public int Height()
        {
            return Height(Root);
        }
        
        private static int Height(BinaryTreeNode? node)
        {
            if (node == null)
            {
                return -1;
            }
            
            if (node.Left == null && node.Right == null)
            {
                return 0;
            }

            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }
        
        public void AddNode(int value)
        {
            if (Root == null)
            {
                var node = new BinaryTreeNode(value);
                Root = node;
            }
            else
            {
                // do level order traversal and find out the next available vacant node
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

                    if (node.Right == null)
                    {
                        node.Right = newNode;
                        break;
                    }
                    queue.Enqueue(node.Left);
                    queue.Enqueue(node.Right);
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

        #region Exercises

        // Size of the node => number of nodes in the tree 
        public int Size() => Size(Root);
        
        private static int Size(BinaryTreeNode? node)
        {
            if (node == null) return 0;

            return 1 + Size(node.Left) + Size(node.Right);
        }

        public int CountLeaves() => CountLeaves(Root);

        private static int CountLeaves(BinaryTreeNode? node)
        {
            if (node == null) return 0;

            if (node.Left == null && node.Right == null) return 1;

            return CountLeaves(node.Left) + CountLeaves(node.Right);
        }

        public int MaxValue() => MaxValue(Root);

        private static int MaxValue(BinaryTreeNode? node)
        {
            if (node == null) return -1;

            return Math.Max(node.Value, Math.Max(MaxValue(node.Left), MaxValue(node.Right)));
        }

        public bool TreeContains(int value) => TreeContains(Root, value);

        private static bool TreeContains(BinaryTreeNode? node, int value)
        {
            if (node == null) return false;

            return node.Value == value || TreeContains(node.Left, value) || TreeContains(node.Right, value);
        }

        public bool AreSiblings(int val1, int val2) => AreSiblings(Root, val1, val2);

        private static bool AreSiblings(BinaryTreeNode? node, int val1, int val2)
        {
            if (node == null) return false;

            if (node.Left!=null && node.Right!=null && ((node.Left.Value == val1 && node.Right.Value == val2) || (node.Left.Value == val2 && node.Right.Value == val1))) return true;

            return AreSiblings(node.Left, val1, val2) || AreSiblings(node.Right, val1, val2);
        }

        public List<int> GetAncestors(int val)
        {
            var ancestors = new List<int>();
            GetAncestors(Root, val, ancestors);

            return ancestors;
        } 
        
        private static bool GetAncestors(BinaryTreeNode? node, int val, ICollection<int> ancestors)
        {
            if (node == null) return false;
            
            if(node.Value == val) return true;

            ancestors.Add(node.Value);
            return GetAncestors(node.Left, val, ancestors) || GetAncestors(node.Right, val, ancestors);
        } 

        #endregion
    }
}
