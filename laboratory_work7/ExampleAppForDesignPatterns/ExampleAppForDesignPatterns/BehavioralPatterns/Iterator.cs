using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleAppForDesignPatterns.BehavioralPatterns
{
    // Интерфейс Итератора
    public interface IIterator
    {
        bool HasNext();
        object Next();
    }

    // Интерфейс Агрегата
    public interface IAggregate
    {
        IIterator CreateIterator();
    }

    // Конкретный Итератор
    public class ConcreteIterator : IIterator
    {
        private readonly List<string> _items;
        private int _position = 0;

        public ConcreteIterator(List<string> items)
        {
            _items = items;
        }

        public bool HasNext()
        {
            return _position < _items.Count;
        }

        public object Next()
        {
            return HasNext() ? _items[_position++] : null;
        }
    }

    // Конкретный Агрегат
    public class ConcreteAggregate : IAggregate
    {
        private readonly List<string> _items = new List<string>();

        public void AddItem(string item)
        {
            _items.Add(item);
        }

        public IIterator CreateIterator()
        {
            return new ConcreteIterator(_items);
        }
    }

    // Клиент
    public class Client4
    {
        public static void ExecuteIteratorPattern()
        {
            var aggregate = new ConcreteAggregate();
            aggregate.AddItem("Элемент 1");
            aggregate.AddItem("Элемент 2");
            aggregate.AddItem("Элемент 3");

            var iterator = aggregate.CreateIterator();

            Console.WriteLine("Обход элементов коллекции:");
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }
        }
    }
}
