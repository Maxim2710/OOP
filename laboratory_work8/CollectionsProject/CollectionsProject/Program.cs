namespace CollectionsProject;

using System;
using CollectionsProject.Models;
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
        collection.Sort(); // Для сортировки разнородных объектов потребуется кастомный Comparer
        Console.WriteLine($"Количество элементов в коллекции: {collection.Count}");

        // Пример работы с CustomEnumerable
        Console.WriteLine("\nРабота с CustomEnumerable:");
        var enumerable = new CustomEnumerable(new[] { 1, 2, 3, 4, 5 });
        foreach (var item in enumerable)
        {
            Console.WriteLine($"Элемент: {item}");
        }

        // Пример работы с стеком
        Console.WriteLine("\nРабота со стеком:");
        var stackExample = new StackExample();
        stackExample.Push(10);
        stackExample.Push(20);
        stackExample.Peek();
        stackExample.Pop();
        stackExample.IsEmpty();

        // Пример работы с очередью
        Console.WriteLine("\nРабота с очередью:");
        var queueExample = new QueueExample();
        queueExample.Enqueue(30);
        queueExample.Enqueue(40);
        queueExample.Peek();
        queueExample.Dequeue();
        queueExample.IsEmpty();
    }
}
