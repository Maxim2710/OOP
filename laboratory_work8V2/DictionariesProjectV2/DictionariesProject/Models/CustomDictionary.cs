using MyCustomCollections.Interfaces;
using System.Collections.Generic;

namespace MyCustomCollections.Models
{
    public class CustomDictionary<TKey, TValue> : ICustomDictionary<TKey, TValue>
    {
        private class Node
        {
            public TKey Key;
            public TValue Value;
            public Node Next;

            public Node(TKey key, TValue value, Node next = null)
            {
                Key = key;
                Value = value;
                Next = next;
            }
        }

        private Node _head;
        private int _count;

        public int Count => _count;

        public void Add(TKey key, TValue value)
        {
            if (ContainsKey(key))
                throw new ArgumentException($"Key {key} already exists.");

            _head = new Node(key, value, _head);
            _count++;
        }

        public bool Remove(TKey key)
        {
            Node prev = null;
            Node current = _head;

            while (current != null)
            {
                if (Equals(current.Key, key))
                {
                    if (prev == null)
                        _head = current.Next;
                    else
                        prev.Next = current.Next;

                    _count--;
                    return true;
                }

                prev = current;
                current = current.Next;
            }

            return false;
        }

        public TValue Get(TKey key)
        {
            Node current = _head;

            while (current != null)
            {
                if (Equals(current.Key, key))
                    return current.Value;

                current = current.Next;
            }

            throw new KeyNotFoundException($"Key {key} not found.");
        }

        public bool ContainsKey(TKey key)
        {
            Node current = _head;

            while (current != null)
            {
                if (Equals(current.Key, key))
                    return true;

                current = current.Next;
            }

            return false;
        }
    }
}