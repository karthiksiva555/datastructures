using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Queue
{
    public class CircularQueue
    {
        private int[] _queue;

        private int _first, _last;

        public int Count { get; set; }

        public CircularQueue(int capacity)
        {
            _queue = new int[capacity];
            _last = -1;
        }

        public void Enqueue(int value)
        {
            if (IsFull)
                throw new InvalidOperationException("Queue is full.");

            _last = (_last + 1) % _queue.Length;
            _queue[_last] = value;

            Count++;
        }

        public int Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty");

            var firstElement = _queue[_first];
            _queue[_first++] = 0;
            Count--;

            return firstElement;
        }

        public bool IsEmpty => Count == 0;

        public bool IsFull => Count == _queue.Length;

        public void Print()
        {
            Console.WriteLine("The current Queue:");
            foreach(var element in _queue)
                Console.WriteLine(element);
        }
    }
}
