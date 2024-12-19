namespace CollectionsProject;

using System;
using CollectionsProject.Models; // Подключаем пространство имен с CustomStack и CustomQueue
using CollectionsProject.Services;

class Program
{
    static void Main(string[] args)
    {
        // Пример работы с CustomCollection
        Console.WriteLine("Работа с CustomCollection:");
        var collection = new CustomCollection<object>();
        collection.Add(10);
        collection.Add("Hello");
        collection.Add(3.14);

        try
        {
            collection.Sort();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при сортировке: {ex.Message}");
        }

        Console.WriteLine($"Количество элементов в коллекции: {collection.Count}");

        // Пример работы с CopyTo
        Console.WriteLine("\nПример работы с CopyTo:");
        var targetArray = new object[10];
        collection.CopyTo(targetArray, 2);

        Console.WriteLine("Элементы целевого массива после CopyTo:");
        foreach (var item in targetArray)
        {
            Console.WriteLine(item ?? "null");
        }

        // Пример работы с CustomEnumerable
        Console.WriteLine("\nРабота с CustomEnumerable:");
        var enumerable = new CustomEnumerable(new[] { 1, 2, 3, 4, 5 });
        foreach (var item in enumerable)
        {
            Console.WriteLine($"Элемент: {item}");
        }

        // Пример работы с CustomStack
        Console.WriteLine("\nРабота со стеком:");
        var customStack = new CustomStack<int>();
        customStack.Push(10);
        customStack.Push(20);
        Console.WriteLine($"Верхний элемент стека: {customStack.Peek()}");
        Console.WriteLine($"Извлечено из стека: {customStack.Pop()}");
        Console.WriteLine($"Стек пуст: {customStack.IsEmpty()}");

        // Пример работы с CustomQueue
        Console.WriteLine("\nРабота с очередью:");
        var customQueue = new CustomQueue<int>();
        customQueue.Enqueue(30);
        customQueue.Enqueue(40);
        Console.WriteLine($"Первый элемент в очереди: {customQueue.Peek()}");
        Console.WriteLine($"Извлечено из очереди: {customQueue.Dequeue()}");
        Console.WriteLine($"Очередь пуста: {customQueue.IsEmpty()}");
    }
}
