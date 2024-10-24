using ExampleAppForDesignPatterns.SingletonPattern;
using System;

namespace ExampleAppForDesignPatterns.SingletonPattern
{
    // Класс-одиночка
    public class Singleton
    {
        // Приватный статический экземпляр класса
        private static Singleton _instance;

        // Приватный конструктор, чтобы предотвратить создание экземпляров класса
        private Singleton()
        {
            // Инициализация ресурсов
        }

        // Публичный статический метод для доступа к экземпляру
        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }

        public void DoSomething()
        {
            Console.WriteLine("Singleton is doing something!");
        }
    }
}
