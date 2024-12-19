namespace CollectionsProject.Services;

using System;

// Реализация очереди
public class CustomQueue<T>
{
    private T[] _items;
    private int _head;
    private int _tail;
    private int _size;

    public CustomQueue()
    {
        _items = new T[4];
        _head = 0;
        _tail = 0;
        _size = 0;
    }

    public void Enqueue(T item)
    {
        EnsureCapacity();
        _items[_tail] = item;
        _tail = (_tail + 1) % _items.Length;
        _size++;
    }

    public T Dequeue()
    {
        if (_size == 0)
            throw new InvalidOperationException("Очередь пуста.");

        T item = _items[_head];
        _items[_head] = default!;
        _head = (_head + 1) % _items.Length;
        _size--;
        return item;
    }

    public T Peek()
    {
        if (_size == 0)
            throw new InvalidOperationException("Очередь пуста.");

        return _items[_head];
    }

    public bool IsEmpty() => _size == 0;

    private void EnsureCapacity()
    {
        if (_size == _items.Length)
        {
            T[] newItems = new T[_items.Length * 2];
            for (int i = 0; i < _size; i++)
            {
                newItems[i] = _items[(_head + i) % _items.Length];
            }
            _items = newItems;
            _head = 0;
            _tail = _size;
        }
    }
}
