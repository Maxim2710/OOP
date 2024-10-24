using System;

namespace ExampleAppForDesignPatterns.GeneratingPatterns
{
    // Продукт — объект, который будет строиться
    public class Computer
    {
        public string Processor { get; set; }
        public string Memory { get; set; }
        public string Storage { get; set; }

        public override string ToString()
        {
            return $"Computer [Processor: {Processor}, Memory: {Memory}, Storage: {Storage}]";
        }
    }

    // Абстрактный интерфейс строителя
    public interface IComputerBuilder
    {
        void SetProcessor();
        void SetMemory();
        void SetStorage();
        Computer GetComputer();
    }

    // Конкретный строитель для офисного компьютера
    public class OfficeComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        public void SetProcessor() => _computer.Processor = "Intel i5";
        public void SetMemory() => _computer.Memory = "8GB";
        public void SetStorage() => _computer.Storage = "256GB SSD";
        public Computer GetComputer() => _computer;
    }

    // Конкретный строитель для игрового компьютера
    public class GamingComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        public void SetProcessor() => _computer.Processor = "Intel i9";
        public void SetMemory() => _computer.Memory = "32GB";
        public void SetStorage() => _computer.Storage = "1TB SSD";
        public Computer GetComputer() => _computer;
    }

    // Директор, который управляет строителем
    public class Director
    {
        private IComputerBuilder _builder;

        public Director(IComputerBuilder builder)
        {
            _builder = builder;
        }

        public void ConstructComputer()
        {
            _builder.SetProcessor();
            _builder.SetMemory();
            _builder.SetStorage();
        }

        public Computer GetComputer() => _builder.GetComputer();
    }
}
