using System;

namespace DataStructures.LinkedList
{
    public class CircularLinkedList : DoublyLinkedList
    {
        public override int Count
        {
            get
            {
                var count = 0;
                if (First == null) return count;
                var iterator = First;
                do
                {
                    count++;
                    iterator = iterator.Next;
                } while (iterator != First);
                return count;
            }
        }

        public override void AddFirst(DoubleLinkedListNode node)
        {
            if(First == null && Last == null)
            {
                node.Next = node;
                node.Previous = node;
                First = node;
                Last = node;
            }
            else
            {
                if (Last != null) Last.Next = node;
                node.Previous = Last;

                base.AddFirst(node);
            }
        }

        public override void AddLast(DoubleLinkedListNode node)
        {
            node.Next = First;
            if (First != null) First.Previous = node;

            base.AddLast(node);
        }

        public override void AddAfter(DoubleLinkedListNode node, DoubleLinkedListNode newNode)
        {
            newNode.Previous = node;
            newNode.Next = node.Next;
            node.Next.Previous = newNode;
            node.Next = newNode;
            
            if (node == Last) Last = newNode;
        }

        public override void RemoveFirst()
        {
            Last.Next = First.Next;
            First.Next.Previous = Last;
            First = First.Next;
        }

        public override void RemoveLast()
        {
            Last.Previous.Next = First;
            First.Previous = Last.Previous;
            Last = Last.Previous;
        }

        public override void RemoveAfter(DoubleLinkedListNode node)
        {
            if (node == Last) First = First.Next;

            node.Next.Next.Previous = node;
            node.Next = node.Next.Next;
        }

        public override void TraverseList()
        {
            Console.WriteLine("The current List:");
            Console.WriteLine("-----------------------------------------");
            var iterator = First;
            do
            {
                Console.WriteLine($"{iterator.Value}");
                iterator = iterator.Next;
            } while (iterator != First);
            Console.WriteLine("-----------------------------------------");
        }

        public override void ReverseTraverseList()
        {
            Console.WriteLine("The current List:");
            Console.WriteLine("-----------------------------------------");
            var iterator = Last;
            do
            {
                Console.WriteLine($"{iterator.Value}");
                iterator = iterator.Previous;
            } while (iterator != Last) ;
            Console.WriteLine("-----------------------------------------");
        }

        public override DoubleLinkedListNode Find(int value)
        {
            var iterator = First;
            do
            {
                if (iterator.Value == value) return iterator;
                iterator = iterator.Next;
            } while (iterator != First);
            return null;
        }

        public override DoubleLinkedListNode FindLast(int value)
        {
            var iterator = Last;
            do
            {
                if (iterator.Value == value) return iterator;
                iterator = iterator.Previous;
            } while (iterator != Last);
            return null;
        }

        public override bool Contains(int value)
        {
            var iterator = First;
            do
            {
                if (iterator.Value == value) return true;
                iterator = iterator.Next;
            } while (iterator != First);
            return false;
        }

        public override string ToString()
        {
            var listItemsStr = string.Empty;
            var iterator = First;
            do
            {
                listItemsStr += $" {iterator.Value}";
                iterator = iterator.Next;
            } while (iterator != First);
            return listItemsStr;
        }
    }
}
