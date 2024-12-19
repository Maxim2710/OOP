using MyCustomCollections.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionariesProject.Models
{
    public class CustomDictionaryWithKeyValuePair<TKey, TValue> : ICustomDictionary<TKey, TValue>
    {
        private List<KeyValuePair<TKey, TValue>> _data = new();

        public int Count => _data.Count;

        public void Add(TKey key, TValue value)
        {
            if (ContainsKey(key))
                throw new ArgumentException($"Key {key} already exists.");

            _data.Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        public bool Remove(TKey key)
        {
            for (int i = 0; i < _data.Count; i++)
            {
                if (EqualityComparer<TKey>.Default.Equals(_data[i].Key, key))
                {
                    _data.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public TValue Get(TKey key)
        {
            foreach (var kvp in _data)
            {
                if (EqualityComparer<TKey>.Default.Equals(kvp.Key, key))
                    return kvp.Value;
            }

            throw new KeyNotFoundException($"Key {key} not found.");
        }

        public bool ContainsKey(TKey key)
        {
            foreach (var kvp in _data)
            {
                if (EqualityComparer<TKey>.Default.Equals(kvp.Key, key))
                    return true;
            }

            return false;
        }
    }
}
