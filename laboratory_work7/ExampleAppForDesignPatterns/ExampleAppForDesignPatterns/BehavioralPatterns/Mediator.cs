using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleAppForDesignPatterns.BehavioralPatterns
{
    // Интерфейс Посредника
    public interface IMediator
    {
        void Send(string message, Colleague colleague);
    }

    // Абстрактный класс Коллеги
    public abstract class Colleague
    {
        public IMediator mediator;

        public Colleague(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public abstract void Receive(string message);
        public abstract void Send(string message);
    }

    // Конкретная реализация Коллеги
    public class ConcreteColleague1 : Colleague
    {
        public ConcreteColleague1(IMediator mediator) : base(mediator) { }

        public override void Receive(string message)
        {
            Console.WriteLine("Colleague 1 received: " + message);
        }

        public override void Send(string message)
        {
            Console.WriteLine("Colleague 1 sends: " + message);
            mediator.Send(message, this);
        }
    }

    // Конкретная реализация Коллеги
    public class ConcreteColleague2 : Colleague
    {
        public ConcreteColleague2(IMediator mediator) : base(mediator) { }

        public override void Receive(string message)
        {
            Console.WriteLine("Colleague 2 received: " + message);
        }

        public override void Send(string message)
        {
            Console.WriteLine("Colleague 2 sends: " + message);
            mediator.Send(message, this);
        }
    }

    // Конкретный посредник
    public class ConcreteMediator : IMediator
    {
        private ConcreteColleague1 colleague1;
        private ConcreteColleague2 colleague2;

        public ConcreteMediator(ConcreteColleague1 colleague1, ConcreteColleague2 colleague2)
        {
            this.colleague1 = colleague1;
            this.colleague2 = colleague2;
        }

        public void Send(string message, Colleague colleague)
        {
            if (colleague == colleague1)
            {
                colleague2.Receive(message);
            }
            else
            {
                colleague1.Receive(message);
            }
        }
    }

    // Клиент
    public class Client5
    {
        public static void ExecuteMediatorPattern()
        {
            var colleague1 = new ConcreteColleague1(null);
            var colleague2 = new ConcreteColleague2(null);
            var mediator = new ConcreteMediator(colleague1, colleague2);

            // Устанавливаем посредника для коллег
            colleague1.mediator = mediator;
            colleague2.mediator = mediator;

            // Коллеги отправляют сообщения через посредника
            colleague1.Send("Привет от коллеги 1");
            colleague2.Send("Привет от коллеги 2");
        }
    }
}
