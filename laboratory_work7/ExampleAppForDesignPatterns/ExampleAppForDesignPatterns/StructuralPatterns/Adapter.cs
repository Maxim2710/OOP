using System;

namespace ExampleAppForDesignPatterns.StructuralPatterns
{
    // Интерфейс, ожидаемый клиентом
    public interface ITarget
    {
        void Request();
    }

    // Класс-адаптер, который реализует интерфейс ITarget
    public class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            _adaptee = adaptee;
        }

        public void Request()
        {
            // Преобразуем вызов
            _adaptee.SpecificRequest();
        }
    }

    // Класс с несовместимым интерфейсом
    public class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Called SpecificRequest from Adaptee.");
        }
    }
}