namespace CollectionsProject.Models;

using System;
using System.Collections;
using System.Collections.Generic;

public class CustomCollection<T> : ICollection<T>
{
    private List<T> _items = new();

    public int Count => _items.Count;
    public bool IsReadOnly => false;

    public void Add(T item) => _items.Add(item);

    public void Clear() => _items.Clear();

    public bool Contains(T item) => _items.Contains(item);

    public void CopyTo(T[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);

    public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public int IndexOf(T item) => _items.IndexOf(item);

    public void Insert(int index, T item) => _items.Insert(index, item);

    public bool Remove(T item) => _items.Remove(item);

    public void RemoveAt(int index) => _items.RemoveAt(index);

    public void Reverse() => _items.Reverse();

    // Используем кастомный компаратор для сортировки разнородных объектов
    public void Sort()
    {
        _items.Sort((x, y) => CompareObjects(x, y));
    }

    private int CompareObjects(T x, T y)
    {
        // Сравниваем объекты различных типов
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;

        // Сравнение типов
        Type typeX = x.GetType();
        Type typeY = y.GetType();

        if (typeX == typeY)
        {
            // Если типы одинаковые, пробуем сравнить значения
            if (x is IComparable comparableX && y is IComparable comparableY)
            {
                return comparableX.CompareTo(comparableY);
            }
            else
            {
                throw new ArgumentException("Элементы не могут быть сравнены.");
            }
        }

        // Если типы разные, применяем произвольную логику, например, сравниваем по строковому представлению
        return x.ToString().CompareTo(y.ToString());
    }
}
