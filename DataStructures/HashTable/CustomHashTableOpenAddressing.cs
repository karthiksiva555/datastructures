using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashTable
{
    public class CustomHashTableOpenAddressing
    {
        private class Entry
        {
            public int Key { get; set; }
            public string Value { get; set; }

            public Entry(int key, string value)
            {
                Key = key;
                Value = value;
            }
        }

        private Entry[] _entries;

        public CustomHashTableOpenAddressing(int capacity)
        {
            _entries = new Entry[capacity];
        }

        public void Put(int key, string value)
        {
            var index = GetIndex(key);
            if (index == -1)
                throw new InvalidOperationException("Hash table is full");

            _entries[index] = new Entry(key, value);
        }

        public string Get(int key)
        {
            var index = GetIndex(key);
            if (index < 0 || index > _entries.Length) return null;

            var entry = _entries[index];
            return entry?.Value;
        }

        public void Remove(int key)
        {
            var index = GetIndex(key);

            if (index < 0 || index > _entries.Length) throw new InvalidOperationException("Key not found");

            _entries[index] = null;
        }

        private int GetIndex(int key)
        {
            var steps = 0;
            var index = GetHash(key);

            while (_entries[index] != null && steps != _entries.Length)
            {
                if (_entries[index].Key == key) return index;
                if (++steps == _entries.Length) return -1;
                //index = GetLinearProbingIndex(index);
                //index = GetQuadraticProbingIndex(index, steps);
                index = GetDoubleHashingIndex(index, steps);
            }
            return index;
        }

        private int GetLinearProbingIndex(int index) => (index + 1) % _entries.Length;

        private int GetQuadraticProbingIndex(int index, int step) => (index + step * step) % _entries.Length;

        private int GetDoubleHashingIndex(int index, int step) => (index + step * GetHash2(index)) % _entries.Length;

        private int GetHash2(int index) => 5 - (index % 5);
        
        private int GetHash(int key) => key % _entries.Length;
    }
}
