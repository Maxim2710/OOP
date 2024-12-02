namespace CollectionsProject.Models;

using System;
using System.Collections;
using System.Collections.Generic;

public class CustomEnumerable : IEnumerable<int>
{
    private readonly int[] _items;

    public CustomEnumerable(int[] items) => _items = items;

    public IEnumerator<int> GetEnumerator() => new CustomEnumerator(_items);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private class CustomEnumerator : IEnumerator<int>
    {
        private readonly int[] _items;
        private int _position = -1;

        public CustomEnumerator(int[] items) => _items = items;

        public int Current
        {
            get
            {
                if (_position < 0 || _position >= _items.Length)
                    throw new InvalidOperationException("Текущая позиция недействительна.");
                return _items[_position];
            }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            _position++;
            return _position < _items.Length;
        }

        public void Reset() => _position = -1;

        public void Dispose()
        {
            // Освобождение ресурсов, если необходимо.
        }
    }
}
