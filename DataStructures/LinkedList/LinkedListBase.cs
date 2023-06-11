using DataStructures.Interfaces;
using System;

namespace DataStructures.LinkedList
{
    public abstract class LinkedListBase<T> : ILinkedList<T>
        where T : LinkedListNodeBase<T>
    {
        public virtual T First { get; set; }

        // Should we have Last for Singly Linked List?
        public virtual T Last { get; set; }

        // instead of looping through the whole list everytime Count is called, have a private variable
        // increase / decrease this count when an item is added/deleted 
        public virtual int Count
        {
            get
            {
                var count = 0;
                var iterator = First;
                while (iterator != null)
                {
                    count++;
                    iterator = iterator.Next;
                }
                return count;
            }
        }

        public virtual void ClearList()
        {
            First = null; // this should ideally delete the whole list; cannot be tested as Descructors cannot be called manually
        }

        private T GetNewObject(int value)
        {
            var args = new object[] { value };
            var classInstance = (T)Activator.CreateInstance(typeof(T), args);
            return classInstance;
        }

        public virtual void AddAfter(T node, int value) => AddAfter(node, GetNewObject(value));

        public virtual void AddAfter(T node, T newNode)
        {
            newNode.Next = node.Next;
            node.Next = newNode;

            if (node == Last) Last = newNode;
        }

        public virtual void AddFirst(int value) => AddFirst(GetNewObject(value));

        public virtual void AddFirst(T node)
        {
            if (Last == null) Last = node;
            if (First != null) node.Next = First;

            First = node;
        }

        public virtual void AddLast(int value) => AddLast(GetNewObject(value));

        public virtual void AddLast(T node)
        {
        if (First == null) First = node;
        if (Last != null) Last.Next = node;

        Last = node;
        }

        public virtual bool Contains(int value)
        {
            var iterator = First;
            while (iterator != null)
            {
                if (iterator.Value == value) return true;
                iterator = iterator.Next;
            }
            return false;
        }

        /// <summary>
        /// returns the first node of list where value matches the parameter
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual T Find(int value)
        {
            var iterator = First;
            while (iterator != null)
            {
                if (iterator.Value == value) return iterator;
                iterator = iterator.Next;
            }
            return null;
        }

        public virtual T FindLast(int value)
        {
            var iterator = First;
            T lastMatch = null;
            while (iterator != null)
            {
                if (iterator.Value == value) lastMatch = iterator;
                iterator = iterator.Next;
            }
            return lastMatch;
        }

        public virtual void RemoveAfter(T node)
        {
            if (node == Last) return;

            var iterator = First;
            while (iterator != null)
            {
                if (iterator == node)
                {
                    iterator.Next = iterator.Next.Next;
                    break;
                }
                iterator = iterator.Next;
            }
        }

        public virtual void RemoveFirst() => First = First.Next;

        public virtual void RemoveLast()
        {
            var iterator = First;
            while (iterator.Next != Last)
                iterator = iterator.Next;
            iterator.Next = null;
            Last = iterator;
        }

        public virtual void TraverseList()
        {
            Console.WriteLine("The current List:");
            Console.WriteLine("-----------------------------------------");
            var iterator = First;
            while (iterator != null)
            {
                Console.WriteLine($"{iterator.Value}");
                iterator = iterator.Next;
            }
            Console.WriteLine("-----------------------------------------");
        }
    }
}
