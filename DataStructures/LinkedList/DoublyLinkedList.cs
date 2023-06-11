using DataStructures.Interfaces;
using System;

namespace DataStructures.LinkedList
{
    public class DoublyLinkedList : LinkedListBase<DoubleLinkedListNode>, IReverseTraverse
    {
        public override void AddFirst(DoubleLinkedListNode node)
        {
            if (First != null) First.Previous = node;
            base.AddFirst(node);
        }

        public override void AddLast(DoubleLinkedListNode node)
        {
            if (Last != null) node.Previous = Last;
            base.AddLast(node);            
        }

        public override void AddAfter(DoubleLinkedListNode node, DoubleLinkedListNode newNode)
        {
            newNode.Previous = node;
            if(node!=Last) node.Next.Previous = newNode;

            base.AddAfter(node, newNode); 
        }

        public virtual void AddBefore(DoubleLinkedListNode node, int value) => AddBefore(node, new DoubleLinkedListNode(value));

        public virtual void AddBefore(DoubleLinkedListNode node, DoubleLinkedListNode newNode)
        {
            if(node != First)
            {
                node.Previous.Next = newNode;
                newNode.Previous = node.Previous;
            }
            else
                First = newNode;

            newNode.Next = node;
            node.Previous = newNode;
        }

        public virtual void RemoveBefore(DoubleLinkedListNode node)
        {
            if (node == First) return;
            node.Previous.Previous.Next = node;
            node.Previous = node.Previous.Previous;
        }

        public override void RemoveFirst()
        {
            First.Next.Previous = null;
            base.RemoveFirst();
        }

        public override void RemoveLast()
        {
            Last.Previous.Next = null;
            Last = Last.Previous;
        }

        public override void RemoveAfter(DoubleLinkedListNode node)
        {
            if (node == Last) return;

            node.Next.Next.Previous = node;
            node.Next = node.Next.Next;
        }

        public virtual void ReverseTraverseList()
        {
            Console.WriteLine("The current List:");
            Console.WriteLine("-----------------------------------------");
            var iterator = Last;
            while (iterator != null)
            {
                Console.WriteLine($"{iterator.Value}");
                iterator = iterator.Previous;
            }
            Console.WriteLine("-----------------------------------------");
        }

        public override DoubleLinkedListNode FindLast(int value)
        {
            var iterator = Last;
            while (iterator != null)
            {
                if (iterator.Value == value) return iterator;
                iterator = iterator.Previous;
            }
            return null;
        }
    }
}
