namespace CollectionsProject.Services;

using System;
using System.Collections.Generic;

public class StackExample
{
    private Stack<int> _stack = new();

    public void Push(int item)
    {
        _stack.Push(item);
        Console.WriteLine($"Добавлено в стек: {item}");
    }

    public int Pop()
    {
        var item = _stack.Pop();
        Console.WriteLine($"Извлечено из стека: {item}");
        return item;
    }

    public int Peek()
    {
        var item = _stack.Peek();
        Console.WriteLine($"Верхний элемент стека: {item}");
        return item;
    }

    public bool IsEmpty()
    {
        var isEmpty = _stack.Count == 0;
        Console.WriteLine($"Стек пуст: {isEmpty}");
        return isEmpty;
    }
}
