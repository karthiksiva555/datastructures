using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Interfaces
{
    public interface IGenericStack<T>
    {
        int Count { get; }

        bool IsEmpty { get; }

        bool IsFull { get; }

        T Peek();

        T Pop();

        void Push(T value);

        void DeleteStack();
    }
}
