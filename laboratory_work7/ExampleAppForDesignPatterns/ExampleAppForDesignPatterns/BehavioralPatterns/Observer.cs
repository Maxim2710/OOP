using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleAppForDesignPatterns.BehavioralPatterns
{
    // Интерфейс Наблюдателя
    public interface IObserver
    {
        void Update(string message);
    }

    // Интерфейс Издателя
    public interface ISubject1
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    // Конкретный Издатель
    public class ConcreteSubject : ISubject1
    {
        private List<IObserver> observers = new List<IObserver>();
        private string state;

        public string State
        {
            get { return state; }
            set
            {
                state = value;
                NotifyObservers();  // Уведомляем наблюдателей о изменении состояния
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(state);
            }
        }
    }

    // Конкретный Наблюдатель
    public class ConcreteObserver : IObserver
    {
        private string observerName;

        public ConcreteObserver(string name)
        {
            observerName = name;
        }

        public void Update(string message)
        {
            Console.WriteLine($"{observerName} получил обновление: {message}");
        }
    }

    // Клиент
    public class Client7
    {
        public static void ExecuteObserverPattern()
        {
            var subject = new ConcreteSubject();

            // Создаем наблюдателей
            var observer1 = new ConcreteObserver("Наблюдатель 1");
            var observer2 = new ConcreteObserver("Наблюдатель 2");

            // Регистрируем наблюдателей
            subject.RegisterObserver(observer1);
            subject.RegisterObserver(observer2);

            // Изменяем состояние издателя, что вызывает уведомление наблюдателей
            subject.State = "Состояние изменено!";
        }
    }
}
