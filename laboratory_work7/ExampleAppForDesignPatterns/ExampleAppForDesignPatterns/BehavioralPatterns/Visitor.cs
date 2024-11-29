using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleAppForDesignPatterns.BehavioralPatterns
{
    // Интерфейс для посетителей
    public interface IVisitor
    {
        void Visit(ConcreteElementA element);
        void Visit(ConcreteElementB element);
    }

    // Конкретный посетитель, выполняющий операции
    public class ConcreteVisitor : IVisitor
    {
        public void Visit(ConcreteElementA element)
        {
            Console.WriteLine("Операция для ConcreteElementA");
        }

        public void Visit(ConcreteElementB element)
        {
            Console.WriteLine("Операция для ConcreteElementB");
        }
    }

    // Интерфейс для элементов, которые могут быть посещены
    public interface IElement
    {
        void Accept(IVisitor visitor);
    }

    // Конкретный элемент A
    public class ConcreteElementA : IElement
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    // Конкретный элемент B
    public class ConcreteElementB : IElement
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    // Структура, содержащая элементы
    public class ObjectStructure
    {
        private List<IElement> _elements = new List<IElement>();

        public void AddElement(IElement element)
        {
            _elements.Add(element);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (var element in _elements)
            {
                element.Accept(visitor);
            }
        }
    }

    // Клиентский код
    public class Client11
    {
        public static void ExecuteVisitorPattern()
        {
            // Создаём структуру
            var structure = new ObjectStructure();
            structure.AddElement(new ConcreteElementA());
            structure.AddElement(new ConcreteElementB());

            // Создаём посетителя
            IVisitor visitor = new ConcreteVisitor();

            // Применяем посетителя ко всем элементам структуры
            structure.Accept(visitor);
        }
    }
}
