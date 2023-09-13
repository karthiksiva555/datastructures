using DataStructures.Interfaces;
using System;

namespace DataStructures.LinkedList
{
    public class SingleLinkedListNode : LinkedListNodeBase<SingleLinkedListNode>
    {
        public SingleLinkedListNode(int value) : base(value)
        {

        }

        ~SingleLinkedListNode()
        {
            Console.WriteLine($"Single Linked list node Destructor called for node value :{Value}");
        }
    }
}
