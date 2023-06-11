using System;
using System.Collections.Generic;

namespace DataStructures.HashTable
{
    public class CustomHashTableChaining
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
        
        private readonly LinkedList<Entry>[] _entries;
        
        public CustomHashTableChaining(int capacity = 10)
        {
            _entries = new LinkedList<Entry>[capacity];
        }

        public void Put(int key, string value)
        {
            var bucket = GetOrCreateBucket(key);
            var entry = GetEntryByKey(key);
            if (entry != null)
            {
                entry.Value = value;
                return;
            }

            bucket.AddLast(new Entry(key, value));
        }

        public string Get(int key)
        {
            var entry = GetEntryByKey(key);

            return entry?.Value;
        }

        public void Remove(int key)
        {
            var entry = GetEntryByKey(key);
            var bucket = GetBucket(key);

            if (entry != null && bucket != null)
            {
                bucket.Remove(entry);
                return;
            }
            
            throw new InvalidOperationException("Key not found");
        }

        private Entry GetEntryByKey(int key)
        {
            var index = GetHash(key);

            if (_entries[index] != null)
            {
                foreach (var entry in _entries[index])
                {
                    if (entry.Key == key)
                        return entry;
                }
            }
            return null;
        }

        private LinkedList<Entry> GetBucket(int key)
        {
            return _entries[GetHash(key)];
        }

        private LinkedList<Entry> GetOrCreateBucket(int key)
        {
            var index = GetHash(key);
            if (_entries[index] == null)
                _entries[index] = new LinkedList<Entry>();
            return _entries[index];
        }

        private int GetHash(int key) => key % _entries.Length;
    }
}
