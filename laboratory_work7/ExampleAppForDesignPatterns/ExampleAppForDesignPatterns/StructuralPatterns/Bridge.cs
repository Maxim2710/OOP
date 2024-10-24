using System;

namespace ExampleAppForDesignPatterns.StructuralPatterns
{
    // Интерфейс для реализации
    public interface IImplementation
    {
        void OperationImplementation();
    }

    // Конкретная реализация 1
    public class ConcreteImplementationA : IImplementation
    {
        public void OperationImplementation() => Console.WriteLine("ConcreteImplementationA: Operation Implementation.");
    }

    // Конкретная реализация 2
    public class ConcreteImplementationB : IImplementation
    {
        public void OperationImplementation() => Console.WriteLine("ConcreteImplementationB: Operation Implementation.");
    }

    // Абстракция
    public abstract class Abstraction
    {
        protected IImplementation _implementation;

        protected Abstraction(IImplementation implementation)
        {
            _implementation = implementation;
        }

        public abstract void Operation();
    }

    // Конкретная абстракция
    public class RefinedAbstraction : Abstraction
    {
        public RefinedAbstraction(IImplementation implementation) : base(implementation) { }

        public override void Operation()
        {
            Console.WriteLine("RefinedAbstraction: Operation.");
            _implementation.OperationImplementation();
        }
    }
}