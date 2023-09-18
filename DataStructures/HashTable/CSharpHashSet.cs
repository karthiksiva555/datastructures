using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashTable
{
    public class CustomIntEqualityComparer : IEqualityComparer<int>
    {
        public bool Equals(int x, int y)
        {
            // Your custom comparison logic here
            return x % 2 == y % 2; // Example: Compare integers based on whether they are even or odd.
        }

        public int GetHashCode(int obj)
        {
            // Your custom hash code generation logic here
            return obj % 2; // Example: Hash code based on whether the integer is even or odd.
        }
    }
    
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

        public void HashSetOperations()
        {
            var set = new HashSet<int> { 2,2,3,3,5,4,6,4,5,6,4};

            // Add
            set.Add(1);

            // Print
            Print();
            
            // Contains
            Console.WriteLine($"Set contains item 6: {set.Contains(6)}");
            
            Console.WriteLine($"Set contains item 5 using custom equality comparer: {set.Contains(5, new CustomIntEqualityComparer())}");

            List<int> newSet = new() { 3, 4, 3, 4 };
            Console.WriteLine($"The set contains some elements in newSet? {set.Overlaps(newSet)}");

            // Remove
            set.Remove(5);
            set.RemoveWhere(item => item == 6);
            
            set.Clear();
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
