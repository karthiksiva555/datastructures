using DataStructures.Interfaces;
using System;
using System.Collections.Generic;

namespace DataStructures.Stack
{
    public class GenericStackArray<T> : IGenericStack<T>
    {
        private T[] genArray;

        public GenericStackArray(int size = 10)
        {
            genArray = new T[size]; // default size of the array is 10
        }

        public int Top { get; set; } = -1;

        public int Count => Top + 1;

        public bool IsEmpty => genArray == null || Top == -1;

        public bool IsFull => Top + 1 == genArray.Length;

        public void Push(T value) {

            if (IsFull) throw new Exception("Array is full!");
            genArray[++Top] = value;
        }
        public T Peek() => !IsEmpty ? genArray[Top] : throw new Exception("Array is empty!");

        public T Pop() => IsEmpty ? throw new Exception("Array is empty") : genArray[Top--];

        public void PrintStack()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Array is Empty");
                return;
            }
            Console.WriteLine("The stack at the current moment:");
            for (var i = Top; i > -1; i--)
                Console.WriteLine($"{genArray[i]}");
        }

        public void DoPeek() => Console.WriteLine($"The element at the top of the stack: {Peek()}");

        public void DoPop() => Console.WriteLine($"The element removed from the stack: {Pop()}");

        public void DeleteStack()
        {
            Top = -1;
            genArray = null;
        }
    }
}
