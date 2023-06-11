using DataStructures.Interfaces;
using System;
using System.Linq;

namespace DataStructures.Stack
{
    public class SuperStackArray : ISuperStackInt
    {
        private int Top { get; set; }
        private int[] stackArray;
        public int Length => stackArray.Length;
        public bool IsEmpty => Top == -1;
        public bool IsFull => Top == stackArray.Length - 1;
        public int Count => Top + 1;

        public SuperStackArray()
        {
            Top = -1;
            stackArray = new int[10]; // default size of the stack is 10
        }

        public SuperStackArray(int capacity)
        {
            Top = -1;
            stackArray = new int[capacity];
        }
        
        public void DeleteStack()
        {
            stackArray = null;
            Top = -1;
        }

        public int Peek() => stackArray[Top];

        public int Pop() => stackArray[Top--];

        public void Push(int value) => stackArray[++Top] = value;

        public void ForcePush(int value)
        {
            if (IsFull)
                ResizeSuperStack(stackArray.Length * 2);
            Push(value);
        }

        public bool Contains(int search) => stackArray.Contains(search);

        private void ResizeSuperStack(int newCapacity)
        {
            Array.Resize<int>(ref stackArray, newCapacity);
        }
    }
}
