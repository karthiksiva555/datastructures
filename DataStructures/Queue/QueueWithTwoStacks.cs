using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Queue
{
    public class QueueWithTwoStacks
    {
        private Stack<int> _stack1;
        private Stack<int> _stack2;

        public QueueWithTwoStacks()
        {
            _stack1 = new Stack<int>();
            _stack2 = new Stack<int>();
        }

        // Runtime complexity: O(1)
        public void Enqueue(int value)
        {
            _stack1.Push(value);
        }

        // Runtime complexity: O(n) because, when the second stack is empty, we would have to move all the elements from stack 1 to stack 2.  
        public int Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty");

            if (_stack2.Count != 0) return _stack2.Pop();
            
            while (_stack1.Count > 0)
                _stack2.Push(_stack1.Pop());

            return _stack2.Pop();
        }

        public bool IsEmpty() => _stack1.Count == 0 && _stack2.Count == 0; 

        public void Print()
        {
            var tempStack = new Stack<int>();
            var stack1 = _stack1.Reverse();
            var stack2 = _stack2;

            while (stack2.Count > 0)
                tempStack.Push(stack2.Pop());

            foreach (var element in stack1)
                tempStack.Push(element);

            while(tempStack.Count > 0)
                Console.WriteLine(tempStack.Pop());

        }
    }
}
