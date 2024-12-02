using MyCustomCollections.Interfaces;
using System.Collections.Generic;

namespace MyCustomCollections.Models
{
    public class CustomDictionary<TKey, TValue> : IСustomDictionary<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> _data = new();

        public int Count => _data.Count;

        public void Add(TKey key, TValue value)
        {
            if (_data.ContainsKey(key))
                throw new ArgumentException($"Key {key} already exists.");
            _data[key] = value;
        }

        public bool Remove(TKey key)
        {
            return _data.Remove(key);
        }

        public TValue Get(TKey key)
        {
            if (!_data.ContainsKey(key))
                throw new KeyNotFoundException($"Key {key} not found.");
            return _data[key];
        }

        public bool ContainsKey(TKey key)
        {
            return _data.ContainsKey(key);
        }
    }
}
