using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashTable
{
    public class CSharpHashSet<T>
    {
        private readonly HashSet<T> _set;
        public CSharpHashSet()
        {
            _set = new HashSet<T>();
        }

        public CSharpHashSet(T[] initial)
        {
            _set = new HashSet<T>(initial);
        }

        public T FindFirstRepeatedValue(T[] input)
        {
           foreach(var item in input)
            {
                if (_set.Contains(item)) return item;

                _set.Add(item);
            }

            return default;
        }

        public void Print()
        {
            Console.WriteLine("The current set is:");
            foreach(var item in _set)
                Console.WriteLine(item);
        }
    }
}
