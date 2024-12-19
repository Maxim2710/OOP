namespace CollectionsProject.Models;

using System;
using System.Collections;
using System.Collections.Generic;

// Кастомная коллекция
public class CustomCollection<T>
{
    private T[] _items;
    private int _size;

    public CustomCollection()
    {
        _items = new T[4];
        _size = 0;
    }

    public int Count => _size;

    public void Add(T item)
    {
        EnsureCapacity();
        _items[_size++] = item;
    }

    public void Clear()
    {
        _items = new T[4];
        _size = 0;
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < _size; i++)
        {
            if (Equals(_items[i], item))
                return i;
        }
        return -1;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > _size)
            throw new ArgumentOutOfRangeException(nameof(index));

        EnsureCapacity();
        for (int i = _size; i > index; i--)
        {
            _items[i] = _items[i - 1];
        }
        _items[index] = item;
        _size++;
    }

    public bool Remove(T item)
    {
        int index = IndexOf(item);
        if (index < 0) return false;

        for (int i = index; i < _size - 1; i++)
        {
            _items[i] = _items[i + 1];
        }
        _items[--_size] = default!;
        return true;
    }

    public void Reverse()
    {
        for (int i = 0; i < _size / 2; i++)
        {
            T temp = _items[i];
            _items[i] = _items[_size - i - 1];
            _items[_size - i - 1] = temp;
        }
    }

    public void Sort()
    {
        Array.Sort(_items, 0, _size, Comparer<T>.Create((x, y) =>
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            if (x.GetType() == y.GetType() && x is IComparable comparableX && y is IComparable comparableY)
            {
                return comparableX.CompareTo(comparableY);
            }
            return string.Compare(x?.ToString(), y?.ToString(), StringComparison.Ordinal);
        }));
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));

        if (arrayIndex < 0 || arrayIndex > array.Length)
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));

        if (array.Length - arrayIndex < _size)
            throw new ArgumentException("Размер целевого массива недостаточен.");

        for (int i = 0; i < _size; i++)
        {
            array[arrayIndex + i] = _items[i];
        }
    }

    private void EnsureCapacity()
    {
        if (_size == _items.Length)
        {
            Array.Resize(ref _items, _items.Length * 2);
        }
    }
}
