// See https://aka.ms/new-console-template for more information

using DataStructures.Arrays;
using DataStructures.HashTable;
using DataStructures.Heap;
using DataStructures.LinkedList;
using DataStructures.Queue;
using DataStructures.Stack;
using DataStructures.Tree;

//Console.WriteLine("Hello, World!");

// Heaps
// var heap = new Heap();
// heap.Insert(15);
// heap.Insert(10);
// heap.Insert(3);
// heap.Insert(8);
// heap.Insert(12);
// heap.Insert(9);
// heap.Insert(4);
// heap.Insert(1);
// heap.Insert(24);
//
// heap.PrintHeap();
//
// heap.RemoveRoot();
// heap.RemoveRoot();
// heap.RemoveRoot();
// heap.PrintHeap();
//
// var unsorted = new []{ 32, 8, 19, 6, 45 };
// HeapSort.SortAscending(unsorted); // because heapsort is in-place algorithm
// Console.WriteLine($"Sorted Array in Ascending: {string.Join(",", unsorted)}");
// HeapSort.SortDescending(unsorted);
// Console.WriteLine($"Sorted Array in Descending: {string.Join(",", unsorted)}");

// var pq = new PriorityQueueHeap();
// pq.Enqueue(5);
// pq.Enqueue(25);
// pq.Enqueue(10);
// pq.Enqueue(15);
//
// pq.PrintQueue();
//
// Console.WriteLine($"first item from the queue: {pq.Dequeue()}");
//
// pq.PrintQueue();

// Heapify
var input = new[] { 5, 3, 8, 4, 1, 2 };
HeapSort.PrintArray(input);
HeapSort.Heapify(input);
HeapSort.PrintArray(input);

// AVL Trees
// var tree = new AvlTree();
// tree.Insert(10);
// tree.Insert(20);
// tree.Insert(30);

// var tree = new AvlTree();
// tree.Insert(10);
// tree.Insert(30);
// tree.Insert(20);

// var tree = new BinarySearchTreeLL();
// tree.Insert(15);
// tree.Insert(10);
// tree.Insert(5);
// tree.Insert(12);
// tree.Insert(20);
// tree.Insert(25);
// tree.Insert(17);
//tree.Insert(12);
//tree.Insert(14);
//Console.WriteLine($"Is the Binary Search Tree Balanced? {tree.IsBalanced()}");
//Console.WriteLine($"Is the Binary Search Tree Balanced? {tree.IsBalancedBetter()}");
//Console.WriteLine($"Is the Binary Search Tree Perfect? {tree.IsPerfect()}");

// Binary Trees
// --------------------------------------------------------------------------------

// Maximum value in BST
// var bst = new BinarySearchTreeLL();
// bst.Insert(5);
// bst.Insert(10);
// bst.Insert(3);
// bst.Insert(15);
// bst.Insert(9);
// bst.Insert(2);
// bst.Insert(20);
// bst.Insert(13);
// Console.WriteLine($"The maximum value in the tree: {bst.MaxValue()}");

// Size of the tree (number of nodes in a tree), // Number Of Leaf nodes in the tree // Max Value in the tree using recursion
// Tree Contains value // AreSiblings // Get Ancestors
// var binaryTree = new BinaryTreeLL();
// binaryTree.AddNode(20);
// binaryTree.AddNode(10);
// binaryTree.AddNode(30);
// binaryTree.AddNode(6);
// binaryTree.AddNode(21);
// binaryTree.AddNode(4);
// binaryTree.AddNode(3);
// binaryTree.AddNode(8);
// Console.WriteLine($"The size of the tree is: {binaryTree.Size()}");
// Console.WriteLine($"The number of leaves in the tree is: {binaryTree.CountLeaves()}");
// Console.WriteLine($"The Max value in the tree is: {binaryTree.MaxValue()}");
// Console.WriteLine($"The tree contains 10 : {binaryTree.TreeContains(10)}");
// Console.WriteLine($"Are 10, 6 are siblings? : {binaryTree.AreSiblings(10, 6)}");
// var ancestors = binaryTree.GetAncestors(8);
// ancestors.ForEach(Console.WriteLine);

// Distance K Nodes
// var binaryTree = new BinaryTreeLL();
// binaryTree.AddNode(20);
// binaryTree.AddNode(10);
// binaryTree.AddNode(30);
// binaryTree.AddNode(6);
// binaryTree.AddNode(21);
// binaryTree.AddNode(4);
// binaryTree.AddNode(3);
// binaryTree.AddNode(8);
// var k = 2;
// Console.WriteLine($"All Nodes with distance {k} from root:");
// binaryTree.PrintNodesWithDistanceK(k);
//binaryTree.LevelOrderTraversalUsingHeight();

// Wrong vs Correct BST validation
// var binaryTree = new BinaryTreeLL();
// binaryTree.AddNode(5);
// binaryTree.AddNode(3);
// binaryTree.AddNode(7);
// binaryTree.AddNode(2);
// binaryTree.AddNode(8);
//
// Console.WriteLine($"Wrong BST Validation Algorithm: Is the tree BST? {binaryTree.IsBinarySearchTreeWrong()}");
// Console.WriteLine($"Correct BST Validation Algorithm: Is the tree BST? {binaryTree.IsBinarySearchTree()}");
// var bst = new BinarySearchTreeLL();
// bst.Insert(5);
// bst.Insert(10);
// bst.Insert(3);
// bst.Insert(15);
// bst.Insert(9);
// bst.Insert(2);
// bst.Insert(20);
// bst.Insert(13);

//Console.WriteLine($"find result: {bst.Find(5)}");

//Console.WriteLine("Test Complete");

// var binaryTree = new BinaryTreeLL();
// binaryTree.AddNode(5);
// binaryTree.AddNode(10);
// binaryTree.AddNode(3);
// binaryTree.AddNode(15);
// binaryTree.AddNode(9);
// binaryTree.AddNode(2);
// binaryTree.AddNode(20);
// binaryTree.AddNode(13);

// Console.WriteLine($"Height of the binary tree: {binaryTree.Height()}");

// Console.WriteLine($"Is the tree BST: {binaryTree.IsBst(bst.Root)}");

//Console.WriteLine($"Is the tree BST: {binaryTree.IsBinarySearchTreeWrong()}");

// Tree Equals
//var binaryTreeCompare = new BinaryTreeLL();
//binaryTreeCompare.AddNode(5);
// binaryTreeCompare.AddNode(10);
// binaryTreeCompare.AddNode(3);
// binaryTreeCompare.AddNode(15);
// binaryTreeCompare.AddNode(9);
// binaryTreeCompare.AddNode(2);
// binaryTreeCompare.AddNode(20);
// binaryTreeCompare.AddNode(13);
// binaryTreeCompare.AddNode(25);

//Console.WriteLine($"Are the two trees are equal? : {binaryTree.Equals(binaryTreeCompare)}");

// Binary tree using LL
//var binaryTreLL = new BinaryTreeLL();
//binaryTreLL.AddNode(10);
//binaryTreLL.AddNode(20);
//binaryTreLL.AddNode(30);
//binaryTreLL.AddNode(40);
//binaryTreLL.AddNode(50);
//binaryTreLL.AddNode(60);
//binaryTreLL.AddNode(70);

//binaryTreLL.PreOrderTraversal();
//binaryTreLL.InOrderTraversal();
//binaryTreLL.PostOrderTraversal();
//binaryTreLL.LevelOrderTraversal();

//Console.WriteLine($" The element { 45 } exists : {binaryTreLL.SearchTree(45)}");
//Console.WriteLine($" The element { 40 } exists : {binaryTreLL.SearchTree(40)}");
//Console.WriteLine($" The element { 10 } exists : {binaryTreLL.SearchTree(10)}");

//Console.WriteLine($" Removing 20 from the tree");
//binaryTreLL.DeleteNode(20);
//binaryTreLL.LevelOrderTraversal();

// Hash Tables
// --------------------------------------------------------------------------------

//var uniquePairs = CSharpDictionary.GetNumberOfPairsWithKDiff(new int[] { 1, 7, 5, 9, 2, 12, 3 }, 2);
//Console.WriteLine(uniquePairs);

// var uniquePairs = CSharpDictionary.GetNumberOfPairsWithKDiffBetter(new int[] { 1, 7, 5, 9, 3, 4, 7 }, 2);
// Console.WriteLine(uniquePairs);
//
// var uniquePairsNsk = CSharpDictionary.GetNumberOfPairsWithKDiffBetterNsk(new int[] { 1, 7, 5, 9, 3, 4, 7 }, 2);
// Console.WriteLine(uniquePairsNsk);


//Console.WriteLine(CSharpDictionary.GetIndicesOfPairWithKDiff(new int[] {5, 25, 2, 11, 7, 15 }, 9));

//Console.WriteLine(CSharpDictionary.GetIndicesOfPairWithKDiffBetter(new int[] {5, 25, 2, 11, 7, 15 }, 9));

//var result = CSharpDictionary.GetMostFrequentNumber(new int[] { 1, 2, 2, 3, 3, 3, 4, 4, 5, 5 });
//Console.WriteLine(result);

//var customHashTableOA = new CustomHashTableOpenAddressing(10);
//customHashTableOA.Put(1, "Siva");
//customHashTableOA.Put(2, "New Test string");
//customHashTableOA.Put(11, "Narisetty");
//customHashTableOA.Put(21, "Karthik");
//customHashTableOA.Put(31, "another test");
//customHashTableOA.Put(41, "loop test");
//customHashTableOA.Put(12, "Test string 7");
//customHashTableOA.Put(7, "Test string 8");
//customHashTableOA.Put(15, "Test string 9");
//customHashTableOA.Put(19, "test string 10");
//customHashTableOA.Put(41, "loop test new");
//customHashTableOA.Put(115, "items full");

//Console.WriteLine(customHashTableOA.Get(21));

// var customHashTable = new CustomHashTableChaining();
// customHashTable.Put(2, "Siva");
// customHashTable.Put(12, "Karthik");
// customHashTable.Put(22, "Narisetty");
// customHashTable.Put(32, "New Test");
// customHashTable.Put(32, "Just Test");
//
// customHashTable.Put(3, "Vaish");
// customHashTable.Put(4, "Baskaran");
//
// Console.WriteLine(customHashTable.Get(22));
//
// customHashTable.Remove(2);
// customHashTable.Remove(3);
// customHashTable.Remove(32);

//Console.WriteLine("Test Complete");


//var items = new int[] { 1, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 };
//var set = new CSharpHashSet<int>(items);

//var input = "a green apple";
//var set = new CSharpHashSet<char>();
//Console.WriteLine(set.FindFirstRepeatedValue(input.ToCharArray()));
//set.Print();

// var setOps = new CSharpHashSet<int>();
// setOps.HashSetOperations();

// var result = CSharpDictionary.GetFirstNonRepeatingChar("a green apple");
// Console.WriteLine(result);

// CSharpDictionary.DictionaryOperations();
// CSharpHashTable.HashTableOperations();
// CSharpHashTable.HashFunctionOperations();

//----------------------------------------------------------------------------------
// Queues

//var stack = new StackWithTwoQueues();

//stack.Push(10);
//stack.Push(20);
//stack.Push(30);
//stack.Push(40);

//Console.WriteLine(stack.Pop());          
//var queue = new Queue<int>();
//queue.Enqueue(10);
//queue.Enqueue(20);
//queue.Enqueue(30);
//queue.Enqueue(40);
//queue.Enqueue(50);

//var result = CSharpQueue.ReverseFirstKElements(queue, 3);

//foreach(var element in result)
//    Console.WriteLine(element);

// Priority Queue
// var emergencyQueue = new PriorityQueue<string, int>();
// emergencyQueue.Enqueue("Fever", 2);
// emergencyQueue.Enqueue("Ear infection", 3);
// emergencyQueue.Enqueue("Heart attack", 1);
// emergencyQueue.Enqueue("Arm Pain", 4);
//
// var getPatient1 = emergencyQueue.Dequeue();
// Console.WriteLine(getPatient1);
// var getPatient2 = emergencyQueue.Dequeue();
// Console.WriteLine(getPatient2);
// var getPatient3 = emergencyQueue.Dequeue();
// Console.WriteLine(getPatient3);

//var pQueue = new PriorityQueueArray(5);

//Console.WriteLine(pQueue.Dequeue());

//pQueue.Enqueue(2);
//pQueue.Enqueue(3);
//pQueue.Enqueue(5);
//pQueue.Enqueue(1);
//pQueue.Enqueue(4);
//pQueue.Dequeue();
//pQueue.Dequeue();

//pQueue.Print();

//var queue = new QueueWithTwoStacks();

//queue.Enqueue(10);
//queue.Enqueue(20);
//queue.Enqueue(30);
//queue.Enqueue(40);
//queue.Dequeue();
//queue.Print();

//var circularQueue = new CircularQueue(5);
//circularQueue.Enqueue(5);
//circularQueue.Enqueue(10);
//circularQueue.Enqueue(20);
//circularQueue.Enqueue(30);
//circularQueue.Enqueue(40);
//circularQueue.Dequeue();

//circularQueue.Print();

//circularQueue.Enqueue(50);

//circularQueue.Dequeue();
//circularQueue.Enqueue(55);
//circularQueue.Print();

// Queue implementation with Array
// var queue = new SuperQueueArray();
// queue.Enqueue(10);
// queue.Enqueue(20);
// queue.Enqueue(30);
// queue.Enqueue(40);
// Console.WriteLine(queue);
// var removed = queue.Dequeue();
// Console.WriteLine("Removed: "+ removed);
// removed = queue.Dequeue();
// Console.WriteLine("Removed: "+ removed);
// Console.WriteLine(queue);

//var input = new Queue<int>();
//input.Enqueue(10);
//input.Enqueue(20);
//input.Enqueue(30);

//foreach(var item in input)
//    Console.WriteLine(item);

//var output = CSharpQueue.ReverseQueue(input);

//foreach (var item in output)
//    Console.WriteLine(item);

//var singleLL = SingleLinkedListBase.CreateLoop();
//Console.WriteLine(singleLL.HasLoop());

// CSharpLinkedList linkedList = new CSharpLinkedList();
// linkedList.Operations();

//var singleLL = new SinglyLinkedList();
//singleLL.AddFirst(2);
////Console.WriteLine(singleLL.GetKthNodeFromEnd(3));
//singleLL.AddLast(3);
//singleLL.AddFirst(4);
//singleLL.AddLast(5);
//singleLL.AddAfter(singleLL.First, 6);
//singleLL.AddAfter(singleLL.Last, 7);

//singleLL.TraverseList();

//var str = "siva karthik";
//var hash = str.GetHashCode();

//var middleNodes = singleLL.FindMiddleNode();

//foreach (var nodeValue in middleNodes)
//    Console.WriteLine(nodeValue);

//singleLL.Reverse();
//singleLL.ReverseBetter();
//singleLL.TraverseList();

//Console.WriteLine(singleLL.GetKthNodeFromEnd(4));

//singleLL.RemoveFirst();
//singleLL.RemoveFirst();
//singleLL.RemoveLast();
//singleLL.TraverseList();
////Console.WriteLine(singleLL.ToString());
//Console.WriteLine($"Count of List:{singleLL.Count}");
//singleLL.ClearList();

//var newnode = new SuperLinkedListNode(30);
//Console.WriteLine(newnode.Value);
//newnode = null;

//Console.WriteLine(singleLL.Last.Value);
//var node = new LinkedListNode<int>(2);
////var node2 = new LinkedListNode<int>(2);
//tel.AddFirst(node);
//tel.AddAfter(node, 20);

//Console.WriteLine(tel.First.Value);

// node.
//Stack<int> stack = new Stack<int>();

//Queue<int> queue = new Queue<int>();

// Generic Stack
// int stack using generic stack
//var genericStack = new GenericStackArray<int>();
//genericStack.Push(10);
//genericStack.PrintStack();
//genericStack.Push(20);
//genericStack.DoPeek();
//genericStack.DoPop();
//genericStack.PrintStack();

// string stack using generic stack
//var genStringStack = new GenericStackArray<string>(15);
//genStringStack.Push("siva");
//genStringStack.Push("karthik");
//genStringStack.PrintStack();
//genStringStack.DoPeek();
//genStringStack.Push("narisetty");
//genStringStack.PrintStack();
//genStringStack.DoPop();
//genStringStack.PrintStack();

//var inBuiltArray = new ArrayList(2);
//inBuiltArray.Add("test");
//inBuiltArray.Add(2);
//inBuiltArray.Add(3.5);

//foreach(var ele in inBuiltArray)
//{
//    Console.WriteLine(ele);
//}

//// OOB Linkedlist in C#
//LinkedList<int> linkedList = new LinkedList<int>();
//linkedList.AddFirst(10);
//linkedList.AddLast(20);
//linkedList.AddAfter(linkedList.First, 30);

//foreach(var node in linkedList)
//    Console.WriteLine(node.ToString());

//foreach (var node in linkedList.Reverse())
//    Console.WriteLine(node.ToString());

// var output1 = CSharpStack.ReverseString("siva karthik");
// Console.WriteLine(output1);

// var output2 = CSharpStack.ReverseString(null);
// Console.WriteLine(output2);


// var input = "(([1]+<2>))"; // "", "(", ")"
// var isBalanced = CSharpStack.IsExpressionBalanced(null);
// Console.WriteLine(isBalanced);

// var input = "(([1]+<2>))"; // "", "(", ")"
// var isBalanced = CSharpStack.IsExpressionBalancedNoDict(input);
// Console.WriteLine(isBalanced);

// // Dynamic Array
// var dynamicArray = new DynamicArray(4);
// dynamicArray.Insert(10);
// dynamicArray.Insert(20);
// dynamicArray.Insert(30);
// dynamicArray.Insert(40);
// dynamicArray.Insert(50);
// dynamicArray.Print();
// dynamicArray.DeleteAt(2);
// dynamicArray.Print();
// Console.WriteLine($"Max value in array is {dynamicArray.MaxValue()}");
// Console.WriteLine($"Array contains 40: {dynamicArray.Contains(40)}");
// var intersect = dynamicArray.Intersect(new int[] { 20, 40, 80 });
// Console.WriteLine("[{0}]", string.Join(",", intersect));
// dynamicArray.Reverse();
// dynamicArray.InsertAt(25, 2);
// dynamicArray.InsertAt(35, 4);
// dynamicArray.Print();

Console.ReadKey();