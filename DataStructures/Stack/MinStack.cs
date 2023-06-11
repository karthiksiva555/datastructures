using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stack
{
    /// <summary>
    /// This implementation takes O(n) to recalculate min value when we pop one
    /// </summary>
    public class MinStack
    {
        private int Top { get; set; }

        private int MinValue { get; set; }

        private int[] _stack;

        public MinStack(int capacity)
        {
            _stack = new int[capacity];
            Top = -1;
            MinValue = int.MaxValue;
        }

        public bool IsEmpty => Top == -1;

        public int Min() => MinValue;

        public bool IsFull => Top == _stack.Length - 1;

        public void Push(int value)
        {
            if (IsFull)
                throw new StackOverflowException("Stack is full");

            _stack[++Top] = value;

            if (value < MinValue)
                MinValue = value;
        }

        public int Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");

            var result = _stack[Top--];

            if (result == MinValue)
                RecalculateMinValue();

            return result;
        }

        /// <summary>
        /// This takes O(n) to do a Pop everytime we pop the min value
        /// To return the min value in O(1), have two stacks: one for actual values, other for min values
        /// </summary>
        private void RecalculateMinValue()
        {
            var minValue = int.MaxValue;
            for (var i = 0; i <= Top; i++)
                if (_stack[i] < minValue)
                    minValue = _stack[i];
            MinValue = minValue;
        }
    }
}
