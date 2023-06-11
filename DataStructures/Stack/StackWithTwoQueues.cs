using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stack
{
    public class StackWithTwoQueues
    {
        private Queue<int> _queue1;
        private Queue<int> _queue2;

        public StackWithTwoQueues()
        {
            _queue1 = new Queue<int>();
            _queue2 = new Queue<int>();
        }

        public void Push(int value)
        {
            _queue1.Enqueue(value);
        }

        // NSK Solution: Uses an extra array
        //public int Pop()
        //{
        //    if (_queue2.Count == 0)
        //    {
        //        // Reverse the first queue and enqueue to second
        //        var queue1Copy = _queue1.ToArray();

        //        for (int i = queue1Copy.Length-1; i >= 0; i--)
        //            _queue2.Enqueue(queue1Copy[i]);

        //    }
        //    return _queue2.Dequeue();
        //}

        public int Pop()
        {
            // Move everything except the last element
            while (_queue1.Count > 1)
                _queue2.Enqueue(_queue1.Dequeue());

            var result = _queue1.Dequeue();
            SwapQueues();

            return result;
        }

        private void SwapQueues()
        {
            var queueCopy = _queue1;
            _queue1 = _queue2;
            _queue2 = queueCopy;
        }
    }
}
