namespace CollectionsProject.Services;

using System;
using System.Collections.Generic;

// Реализация стека
public class CustomStack<T>
{
    private T[] _items;
    private int _size;

    public CustomStack()
    {
        _items = new T[4];
        _size = 0;
    }

    public void Push(T item)
    {
        EnsureCapacity();
        _items[_size++] = item;
    }

    public T Pop()
    {
        if (_size == 0)
            throw new InvalidOperationException("Стек пуст.");

        T item = _items[--_size];
        _items[_size] = default!;
        return item;
    }

    public T Peek()
    {
        if (_size == 0)
            throw new InvalidOperationException("Стек пуст.");

        return _items[_size - 1];
    }

    public bool IsEmpty() => _size == 0;

    private void EnsureCapacity()
    {
        if (_size == _items.Length)
        {
            Array.Resize(ref _items, _items.Length * 2);
        }
    }
}
