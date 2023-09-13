using System;
using System.Linq;
using System.Text;

namespace DataStructures.Queue
{
    public class SuperQueueArray
    {
        private int[] queueArray;
        private int first, last=-1;

        /// <summary>
        /// Default capacity of Queue is 10
        /// </summary>
        public SuperQueueArray() => queueArray = new int[10];

        public SuperQueueArray(int capacity) => queueArray = new int[capacity];

        public int Length => queueArray.Length;

        public int Count => last - first + 1;

        public bool IsEmpty => first > last;

        public bool IsFull => last == queueArray.Length-1;

        public void Enqueue(int value)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Queue is full");
            }
            queueArray[++last] = value;  
        }

        public int Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            var dequeued = queueArray[first];
            queueArray[first++] = 0; // set the dequeued item to 0 to remove it from array.
            return dequeued;
        } 

        public int Peek() => queueArray[first];

        public bool Contains(int search) => queueArray.Contains(search);

        public void ForceEnqueue(int val)
        {
            if (IsFull) ResizeQueue(queueArray.Length * 2);
            queueArray[++last] = val;
        }

        private void ResizeQueue(int newCapacity) => Array.Resize(ref queueArray, newCapacity);

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = first; i <= last; i++)
            {
                sb.Append(queueArray[i]);
                if (i < last)
                {
                    sb.Append(",");
                }
            }
            
            return sb.ToString();
        }
    }
}
