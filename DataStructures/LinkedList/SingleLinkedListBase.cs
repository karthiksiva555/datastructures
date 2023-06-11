using DataStructures.LinkedList;
using System;

namespace DataStructures
{
    public abstract class SingleLinkedListBase : LinkedListBase<SingleLinkedListNode>
    {
        public SingleLinkedListBase()
        {

        }

        public override string ToString()
        {
            var listItemsStr = string.Empty;
            var iterator = First;
            while (iterator != null)
            {
                listItemsStr += $" {iterator.Value}";
                iterator = iterator.Next;
            }
            return listItemsStr;
        }

        // O(n^2) - because there are nested loops
        public void Reverse()
        {
            if (Count<= 1) return;

            var current = Last;
            var oldLast = Last;

            while (current != null)
            {
                var previous = GetPrevious(current);
                if (previous != null) previous.Next = null;
                
                current.Next = previous;
                current = previous;
            }

            Last = First;
            First = oldLast;
        }

        // O(n) - three pointers, only one loop
        public void ReverseBetter()
        {
            SingleLinkedListNode prev = null, current = First;

            while (current != null)
            {
                var next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            First = prev;
        }

        private SingleLinkedListNode GetPrevious(SingleLinkedListNode node)
        {
            SingleLinkedListNode current = First;

            while(current.Next!=null)
            {
                if (current.Next == node) return current;
                current = current.Next;
            }

            return null;
        }

        public int GetKthNodeFromEnd(int k)
        {
            if (k > Count) 
                throw new ArgumentOutOfRangeException("k cannot be greater than the linked list node count");

            var pointer1 = First;
            var pointer2 = First;

            for (var i = 1; i < k; i++)
                pointer2 = pointer2.Next;

            while (pointer2.Next != null)
            {
                pointer1 = pointer1.Next;
                pointer2 = pointer2.Next;
            }
            return pointer1.Value;
        }

        public int[] FindMiddleNode()
        {
            if (First == null)
                throw new InvalidOperationException("The linked list is empty.");

            // 1 2 3 4 5 6 7 8
            var first = First;
            var second = First;

            while(second.Next!=null && second.Next.Next != null)
            {
                first = first.Next;
                second = second.Next.Next;
            }
            return second.Next!=null 
                ? new int[] { first.Value, first.Next.Value } 
                : new int[] { first.Value };
        }

        public bool HasLoop()
        {
            if (First == null)
                throw new InvalidOperationException("The linked list is empty");

            var slow = First;
            var fast = First;

            while(fast.Next!=null && fast.Next.Next!=null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast) return true;
            }

            return false;
        }

        // Creates a new linked list with loop
        public static SinglyLinkedList CreateLoop()
        {
            var singleLL = new SinglyLinkedList();
            singleLL.AddLast(1);
            singleLL.AddLast(2);

            var newNode1 = new SingleLinkedListNode(3);
            singleLL.AddLast(newNode1);
            var newnode2 = new SingleLinkedListNode(4)
            { Next = newNode1 };

            singleLL.AddLast(newnode2);

            //singleLL.TraverseList();
            return singleLL;
        }
    }
}
