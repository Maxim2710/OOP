using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleAppForDesignPatterns.BehavioralPatterns
{
    // Абстрактный класс, содержащий шаблонный метод
    public abstract class AbstractClass
    {
        // Шаблонный метод, определяет общий алгоритм
        public void TemplateMethod()
        {
            Step1();
            Step2();
            Step3();
        }

        // Шаг 1: фиксированная реализация
        public void Step1()
        {
            Console.WriteLine("Шаг 1: Инициализация");
        }

        // Шаг 2: метод, который можно изменить в подклассе
        public abstract void Step2();

        // Шаг 3: фиксированная реализация
        public void Step3()
        {
            Console.WriteLine("Шаг 3: Завершение");
        }
    }

    // Конкретный класс, изменяющий реализацию шага 2
    public class ConcreteClassA : AbstractClass
    {
        public override void Step2()
        {
            Console.WriteLine("Шаг 2 (ConcreteClassA): Обработка данных");
        }
    }

    // Другой конкретный класс с изменённой реализацией шага 2
    public class ConcreteClassB : AbstractClass
    {
        public override void Step2()
        {
            Console.WriteLine("Шаг 2 (ConcreteClassB): Анализ данных");
        }
    }

    // Клиентский класс
    public class Client10
    {
        public static void ExecuteTemplateMethod()
        {
            // Создаем объекты конкретных классов
            AbstractClass classA = new ConcreteClassA();
            AbstractClass classB = new ConcreteClassB();

            // Вызываем шаблонный метод
            Console.WriteLine("Алгоритм для ConcreteClassA:");
            classA.TemplateMethod();

            Console.WriteLine("\nАлгоритм для ConcreteClassB:");
            classB.TemplateMethod();
        }
    }
}
