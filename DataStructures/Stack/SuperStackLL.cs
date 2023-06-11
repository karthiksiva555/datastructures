using DataStructures.Interfaces;
using DataStructures.LinkedList;

namespace DataStructures.Stack
{
    public class SuperStackLL : ISuperStackInt
    {
        public SingleLinkedListNode Top { get; set; }
        public SuperStackLL()
        {
            Top = null;
        }

        public void Push(int value)
        {
            var newNode = new SingleLinkedListNode(value);
            if (Top != null) newNode.Next = Top;
            Top = newNode;
        }

        public int Pop()
        {
            if (IsEmpty) return -1;
            var result = Top.Value;
            Top = Top.Next;

            return result;
        }

        public int Peek()
        {
            return Top.Value;
        }

        public int Count
        {
            get
            {
                var i = Top;
                var count = 0;
                while (i != null)
                {
                    count++;
                    i = i.Next;
                }
                return count;
            }
        }

        public bool Contains(int search)
        {
            var i = Top;
            while (i != null)
            {
                if (i.Value == search) return true;
                i = i.Next;
            }
            return false;
        }

        public void DeleteStack()
        {
            Top = null;
        }

        public bool IsEmpty => Top == null;
    }
}
