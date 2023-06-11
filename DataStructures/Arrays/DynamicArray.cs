using System;
using System.Linq;

namespace DataStructures.Arrays
{
    // This array gets resized when ran out of space for new items
    public class DynamicArray
    {
        private int[] _array;
        private int _count;

        public DynamicArray()
        {
            _array = new int[3]; // Default size is made 3 to be able to test it easily
        }

        public DynamicArray(int capacity)
        {
            _array = new int[capacity];
        }

        public void Insert(int value)
        {
            if(_array.Length <= _count)
                Array.Resize(ref _array, _count * 2);                
            
            _array[_count++] = value;
        }

        public void DeleteAt(int index)
        {
            if (_count == 0 || index >= _count)
                throw new ArgumentOutOfRangeException();

            for (var i = index-1; i < _count-1; i++)
                _array[i] = _array[i+1];

            _count--;
            _array[_count] = 0;
        }

        public bool Contains(int value)
        {
            return _array.Contains(value);
        }

        public int IndexOf(int value)
        {
            for (var i = 0; i < _count; i++)
                if (_array[i] == value)
                    return i;
            
            return -1;
        }

        public void Print()
        {
            Console.WriteLine("--------Array---------");
            foreach(var arrayItem in _array)
            {
                Console.WriteLine(arrayItem);
            }
        }

        public int ValueAt(int index) => _array[index];

        // Manually implement max method on array
        public int MaxValue()
        {
            if (_count == 0) return -1;

            var maximum = -1;

            for(var i=0; i<_count; i++)
            {
                if (_array[i] > maximum)
                    maximum = _array[i];
            }

            return maximum;
        }

        public int[] ToArray()
        {
            return _array;
        }

        public int[] Intersect(int[] array2)
        {
            var arrayLength = Math.Min(array2.Length, _count);
            var intersectValues = new DynamicArray(arrayLength);

            for(var i = 0; i < _count; i++)
            {
                if (array2.Contains(_array[i]))
                    intersectValues.Insert(_array[i]);
            }
            return intersectValues.ToArray();
        }

        public void Reverse()
        {
            var begin = 0;
            var end = _count-1;

            while (end > begin)
                Swap(begin++, end--);
        }

        private void Swap(int index1, int index2)
        {
            (_array[index1], _array[index2]) = (_array[index2], _array[index1]);
        }

        public void InsertAt(int value, int index)
        {
            if (_array.Length == _count)
                Array.Resize(ref _array, _count * 2);

            for (var i = _count; i > index; i--)
                _array[i] = _array[i - 1];

            _array[index] = value;
            _count++;
        }
    }
}
