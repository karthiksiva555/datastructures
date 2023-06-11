using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stack
{
    public class DoubleStack
    {
        private readonly int[] _stack;
        private int Top1 { get; set; }
        private int Top2 { get; set; }

        public int Count1 => Top1 + 1;

        public int Count2 => _stack.Length - Top2;

        public bool IsFull => Top1+1 == Top2;

        public bool IsEmpty1 => Count1 == 0;

        public bool IsEmpty2 => Count2 == 0;

        public DoubleStack(int length)
        {
            _stack = new int[length];
            Top1 = -1;
            Top2 = length;
        }

        public void Push1(int value)
        {
            if (IsFull)
                throw new StackOverflowException("Stack 1 is full");

            _stack[++Top1] = value;
        }

        public void Push2(int value)
        {
            if (IsFull)
                throw new StackOverflowException("Stack 2 is full");

            _stack[--Top2] = value;
        }

        public int Pop1()
        {
            if (IsEmpty1)
                throw new InvalidOperationException("Stack 1 is empty");

            return _stack[Top1--];
        }

        public int Pop2()
        {
            if (IsEmpty2)
                throw new InvalidOperationException("Stack 2 is empty");

            return _stack[Top2++];
        }
    }
}
