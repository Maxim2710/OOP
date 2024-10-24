using System;
using System.Collections.Generic;

namespace ExampleAppForDesignPatterns.StructuralPatterns
{
    // Компонент
    public abstract class Component
    {
        public abstract void Operation();
    }

    // Лист
    public class Leaf : Component
    {
        private string _name;

        public Leaf(string name)
        {
            _name = name;
        }

        public override void Operation() => Console.WriteLine($"Leaf: {_name} operation.");
    }

    // Композит
    public class Composite : Component
    {
        private List<Component> _children = new List<Component>();
        private string _name;

        public Composite(string name)
        {
            _name = name;
        }

        public void Add(Component component) => _children.Add(component);
        public void Remove(Component component) => _children.Remove(component);

        public override void Operation()
        {
            Console.WriteLine($"Composite: {_name} operation.");
            foreach (var child in _children)
            {
                child.Operation();
            }
        }
    }
}
