using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Queue
{
    public class PriorityQueueArray
    {
        // NSK solution
        //private int[] _queue;

        //private int _first, _last;

        //public PriorityQueueArray(int capacity)
        //{
        //    _queue = new int[capacity];
        //    _first = -1;
        //    _last = -1;
        //}

        //public bool IsEmpty => _last == -1;

        //public bool IsFull => _last == _queue.Length - 1;
        
        //public void Enqueue(int value)
        //{
        //    if (IsFull)
        //        throw new InvalidOperationException("Queue is full");

        //    if(IsEmpty)
        //    {
        //        _first = 0;
        //        _queue[++_last] = value;
        //    }
        //    else
        //    {
        //        for(int i=_last; i >=0; i--)
        //        {
        //            if(_queue[i] > value)
        //            {
        //                _queue[i + 1] = _queue[i];

        //                if(i==_first)
        //                {
        //                    _queue[i] = value;
        //                    _last++;
        //                    break;
        //                }
        //            }
        //            else if (_queue[i] <= value)
        //            {
        //                _last++;
        //                _queue[i+1] = value;
        //                break;
        //            }
        //        }
        //    }
        //}

        //public int Dequeue()
        //{
        //    if (IsEmpty)
        //        throw new InvalidOperationException("Queue is empty");

        //    var result = _queue[_first];
        //    _queue[_first] = 0;
        //    _first++; 
        //    return result;
        //}

        //public void Print()
        //{
        //    Console.WriteLine("The current queue is:");
        //    for(int i=_first; i<=_last; i++)
        //        Console.WriteLine(_queue[i]);
        //}

        // Mosh solution
        private int[] _queue;
        private int _count;

        public PriorityQueueArray(int capacity)
        {
            _queue = new int[capacity];
        }

        public bool IsFull => _count == _queue.Length;

        public bool IsEmpty => _count == 0;

        public void Enqueue(int value)
        {
            if (IsFull)
                throw new InvalidOperationException("Queue is full");
            var i = ShiftItemsToInsert(value);
            _queue[i] = value;
            _count++;
        }

        // Considering highest element has highest priority to get out of the queue
        // if the smallest element has highest priority, introduce a new variable _first
        public int Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty");
            
            var result = _queue[_count - 1];
            _queue[_count - 1] = 0;
            _count--;
            return result;
        }

        private int ShiftItemsToInsert(int value)
        {
            int i;
            for (i = _count - 1; i >= 0; i--)
            {
                if (_queue[i] <= value)
                    break;
                else
                    _queue[i + 1] = _queue[i];
            }

            return i + 1;
        }

        public void Print()
        {
            Console.WriteLine("The current queue is:");
            for(var i=0;i<_count; i++)
                Console.WriteLine(_queue[i]);
        }
    }
}
