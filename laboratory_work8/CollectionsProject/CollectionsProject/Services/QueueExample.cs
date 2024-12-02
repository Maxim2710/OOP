namespace CollectionsProject.Services;

using System;
using System.Collections.Generic;

public class QueueExample
{
    private Queue<int> _queue = new();

    public void Enqueue(int item)
    {
        _queue.Enqueue(item);
        Console.WriteLine($"Добавлено в очередь: {item}");
    }

    public int Dequeue()
    {
        var item = _queue.Dequeue();
        Console.WriteLine($"Извлечено из очереди: {item}");
        return item;
    }

    public int Peek()
    {
        var item = _queue.Peek();
        Console.WriteLine($"Первый элемент очереди: {item}");
        return item;
    }

    public bool IsEmpty()
    {
        var isEmpty = _queue.Count == 0;
        Console.WriteLine($"Очередь пуста: {isEmpty}");
        return isEmpty;
    }
}
