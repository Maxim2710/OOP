using System;

namespace ExampleAppForDesignPatterns.StructuralPatterns
{
    // Базовый компонент
    abstract class BaseComponent
    {
        public abstract string PerformOperation();
    }

    // Конкретный базовый компонент
    class BasicComponent : BaseComponent
    {
        public override string PerformOperation()
        {
            return "BasicComponent";
        }
    }

    // Абстрактный декоратор
    abstract class AbstractDecorator : BaseComponent
    {
        protected BaseComponent _baseComponent;

        public AbstractDecorator(BaseComponent baseComponent)
        {
            _baseComponent = baseComponent;
        }

        public override string PerformOperation()
        {
            return _baseComponent.PerformOperation();
        }
    }

    // Конкретный декоратор A
    class ExtraFunctionalityA : AbstractDecorator
    {
        public ExtraFunctionalityA(BaseComponent baseComponent) : base(baseComponent) { }

        public override string PerformOperation()
        {
            return $"ExtraFunctionalityA({_baseComponent.PerformOperation()})";
        }
    }

    // Конкретный декоратор B
    class ExtraFunctionalityB : AbstractDecorator
    {
        public ExtraFunctionalityB(BaseComponent baseComponent) : base(baseComponent) { }

        public override string PerformOperation()
        {
            return $"ExtraFunctionalityB({_baseComponent.PerformOperation()})";
        }
    }
}
