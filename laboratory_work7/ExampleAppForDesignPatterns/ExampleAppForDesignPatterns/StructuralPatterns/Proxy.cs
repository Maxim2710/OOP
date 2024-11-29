using System;

namespace ExampleAppForDesignPatterns.StructuralPatterns
{
    using System;

    // Интерфейс для субъекта
    public interface ISubject
    {
        void Request();
    }

    // Реальный субъект
    public class RealSubject : ISubject
    {
        public void Request()
        {
            Console.WriteLine("Request processed by RealSubject.");
        }
    }

    // Заместитель
    public class Proxy : ISubject
    {
        private RealSubject? _realSubject;

        public void Request()
        {
            // Логика доступа
            if (_realSubject == null)
            {
                _realSubject = new RealSubject();
            }
            Console.WriteLine("Proxy: Checking access before processing request.");
            _realSubject.Request();
            Console.WriteLine("Proxy: Request processed.");
        }
    }
}
