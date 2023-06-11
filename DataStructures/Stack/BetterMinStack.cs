using System;
using System.Collections.Generic;

namespace DataStructures.Stack
{
    /// <summary>
    /// This implementation uses an extra stack to maintan Min values
    /// Takes O(1) to return the min value even when we pop the current min value
    /// </summary>
    public class BetterMinStack
    {
        private readonly Stack<int> _stack;
        private readonly Stack<int> _minStack;

        public BetterMinStack()
        {
            _stack = new Stack<int>();
            _minStack = new Stack<int>();
        }

        public void Push(int value)
        {
            _stack.Push(value);

            if (_minStack.Count == 0)
                _minStack.Push(value);
            else
            {
                if (_minStack.Peek() > value)
                    _minStack.Push(value);
            }
        }

        public int Pop()
        {
            if (_stack.Count == 0)
                throw new InvalidOperationException("Stack is empty");

            var result = _stack.Pop();

            if (_minStack.Peek() == result)
                _minStack.Pop();

            return result;
        }

        public int Min() => _minStack.Peek();
    }
}
