using DataStructures.LinkedList;

namespace DataStructures.Queue
{
    public class SuperQueueLL
    {
        public SingleLinkedListNode First { get; set; }
        public SingleLinkedListNode Last { get; set; }

        public SuperQueueLL()
        {
            First = null;
            Last = null;
        }

        public bool IsEmpty => First == null && Last == null;

        public void Enqueue(int value)
        {
            var newNode = new SingleLinkedListNode(value);

            // first node of queue
            if (Last == null && First == null) First = Last = newNode;
            else
            {
                Last.Next = newNode;
                Last = newNode;
            }
        }

        public int Dequeue()
        {
            if (IsEmpty) return -1;
            if (First == Last) Last = null;
            var result = First.Value;
            First = First.Next;
            return result;
        }

        public int Peek()
        {
            if (IsEmpty) return -1;
            return First.Value;
        }

        public bool Contains(int search)
        {
            var i = First;
            while(i != null)
            {
                if (i.Value == search) return true;
                i = i.Next;
            }

            return false;
        }

        public void DeleteQueue()
        {
            First = Last = null;
        }

        public int Count
        {
            get {
                var count = 0;
                var i = First;
                while (i != null)
                {
                    count++;
                    i = i.Next;
                }

                return count;
            }
        }
    }
}
