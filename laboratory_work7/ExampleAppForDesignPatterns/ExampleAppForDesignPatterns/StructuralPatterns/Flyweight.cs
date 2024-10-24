using System;

namespace ExampleAppForDesignPatterns.StructuralPatterns
{
    // Flyweight
    public interface IFlyweight
    {
        void Operation(string externalState);
    }

    // ConcreteFlyweight
    public class ConcreteFlyweight : IFlyweight
    {
        private readonly string _intrinsicState;

        public ConcreteFlyweight(string intrinsicState)
        {
            _intrinsicState = intrinsicState;
        }

        public void Operation(string externalState)
        {
            Console.WriteLine($"ConcreteFlyweight: {_intrinsicState}, External State: {externalState}");
        }
    }

    // FlyweightFactory
    public class FlyweightFactory
    {
        private readonly Dictionary<string, IFlyweight> _flyweights = new();

        public IFlyweight GetFlyweight(string intrinsicState)
        {
            if (!_flyweights.ContainsKey(intrinsicState))
            {
                _flyweights[intrinsicState] = new ConcreteFlyweight(intrinsicState);
            }
            return _flyweights[intrinsicState];
        }

        public int GetFlyweightCount()
        {
            return _flyweights.Count;
        }
    }

    // Client
    public class DesignPatternClient
    {
        private readonly FlyweightFactory _factory = new();

        public void Execute()
        {
            var flyweight1 = _factory.GetFlyweight("State1");
            flyweight1.Operation("ExternalStateA");

            var flyweight2 = _factory.GetFlyweight("State1");
            flyweight2.Operation("ExternalStateB");

            var flyweight3 = _factory.GetFlyweight("State2");
            flyweight3.Operation("ExternalStateC");

            Console.WriteLine($"Total Flyweights: {_factory.GetFlyweightCount()}");
        }
    }

}
