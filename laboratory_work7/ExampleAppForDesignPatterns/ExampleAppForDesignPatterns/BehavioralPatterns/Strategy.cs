using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleAppForDesignPatterns.BehavioralPatterns
{
    // Интерфейс стратегии
    public interface IStrategy
    {
        void Execute();
    }

    // Конкретная стратегия 1
    public class ConcreteStrategyA : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Выполнение алгоритма A");
        }
    }

    // Конкретная стратегия 2
    public class ConcreteStrategyB : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Выполнение алгоритма B");
        }
    }

    // Конкретная стратегия 3
    public class ConcreteStrategyC : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Выполнение алгоритма C");
        }
    }

    // Контекст, использующий стратегию
    public class Context1
    {
        private IStrategy _strategy;

        // Конструктор, принимающий стратегию
        public Context1(IStrategy strategy)
        {
            _strategy = strategy;
        }

        // Метод для установки новой стратегии
        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        // Выполнение алгоритма через стратегию
        public void ExecuteStrategy()
        {
            _strategy.Execute();
        }
    }

    // Клиент
    public class Client9
    {
        public static void ExecuteStrategyPattern()
        {
            // Создаем контекст и задаем стратегию A
            Context1 context = new Context1(new ConcreteStrategyA());
            context.ExecuteStrategy();

            // Меняем стратегию на B
            context.SetStrategy(new ConcreteStrategyB());
            context.ExecuteStrategy();

            // Меняем стратегию на C
            context.SetStrategy(new ConcreteStrategyC());
            context.ExecuteStrategy();
        }
    }
}
