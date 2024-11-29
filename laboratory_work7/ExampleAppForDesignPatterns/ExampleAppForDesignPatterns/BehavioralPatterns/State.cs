using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleAppForDesignPatterns.BehavioralPatterns
{
    // Интерфейс состояния
    public interface IState
    {
        void Handle(Context context);
    }

    // Конкретное состояние 1
    public class ConcreteStateA : IState
    {
        public void Handle(Context context)
        {
            Console.WriteLine("Обработка в состоянии A");
            context.SetState(new ConcreteStateB()); // Переключаем состояние на B
        }
    }

    // Конкретное состояние 2
    public class ConcreteStateB : IState
    {
        public void Handle(Context context)
        {
            Console.WriteLine("Обработка в состоянии B");
            context.SetState(new ConcreteStateA()); // Переключаем состояние на A
        }
    }

    // Контекст
    public class Context
    {
        private IState _state;

        // Инициализация с начальным состоянием
        public Context(IState state)
        {
            SetState(state);
        }

        public void SetState(IState state)
        {
            _state = state;
        }

        public void Request()
        {
            _state.Handle(this);
        }
    }

    // Клиент
    public class Client8
    {
        public static void ExecuteStatePattern()
        {
            // Инициализация контекста с начальным состоянием
            Context context = new Context(new ConcreteStateA());

            // Выполнение запроса, что приводит к изменению состояния
            context.Request();
            context.Request();
            context.Request();
        }
    }
}
