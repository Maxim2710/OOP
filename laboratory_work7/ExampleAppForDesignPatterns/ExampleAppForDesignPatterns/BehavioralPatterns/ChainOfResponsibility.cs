using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleAppForDesignPatterns.BehavioralPatterns
{
    // Handler
    public abstract class Handler
    {
        protected Handler _nextHandler;

        public void SetNext(Handler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public abstract void HandleRequest(string request);
    }

    // ConcreteHandler1
    public class ConcreteHandlerA : Handler
    {
        public override void HandleRequest(string request)
        {
            if (request == "A")
            {
                Console.WriteLine("ConcreteHandlerA обработал запрос.");
            }
            else
            {
                Console.WriteLine("ConcreteHandlerA передал запрос дальше.");
                _nextHandler?.HandleRequest(request);
            }
        }
    }

    // ConcreteHandler2
    public class ConcreteHandlerB : Handler
    {
        public override void HandleRequest(string request)
        {
            if (request == "B")
            {
                Console.WriteLine("ConcreteHandlerB обработал запрос.");
            }
            else
            {
                Console.WriteLine("ConcreteHandlerB передал запрос дальше.");
                _nextHandler?.HandleRequest(request);
            }
        }
    }

    // ConcreteHandler3
    public class ConcreteHandlerC : Handler
    {
        public override void HandleRequest(string request)
        {
            if (request == "C")
            {
                Console.WriteLine("ConcreteHandlerC обработал запрос.");
            }
            else
            {
                Console.WriteLine("ConcreteHandlerC не смог обработать запрос.");
            }
        }
    }

    // Client
    public class Client1
    {
        public static void ExecuteChain()
        {
            // Создаем обработчиков
            var handlerA = new ConcreteHandlerA();
            var handlerB = new ConcreteHandlerB();
            var handlerC = new ConcreteHandlerC();

            // Формируем цепочку
            handlerA.SetNext(handlerB);
            handlerB.SetNext(handlerC);

            // Отправляем запросы
            string[] requests = { "A", "B", "C", "D" };

            foreach (var request in requests)
            {
                Console.WriteLine($"\nОбрабатываем запрос: {request}");
                handlerA.HandleRequest(request);
            }
        }
    }
}
