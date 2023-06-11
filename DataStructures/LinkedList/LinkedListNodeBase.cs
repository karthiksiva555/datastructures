using System;

namespace DataStructures.LinkedList
{
    public abstract class LinkedListNodeBase<T>
    {
        public virtual T Next { get; set; }

        public virtual int Value { get; set; }

        public LinkedListNodeBase(int val)
        {
            Value = val;
        }

        ~LinkedListNodeBase()
        {
            Console.WriteLine($"Linked list base Descructor called for node value :{Value}");
        }
    }
}
