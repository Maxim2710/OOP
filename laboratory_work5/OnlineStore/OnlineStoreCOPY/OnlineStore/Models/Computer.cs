namespace OnlineStore.Models
{
    public class Computer(string name, decimal price, string description, string processor, int ram) : Product(name, price, description)
    {
        private string _processor = processor;
        private int _ram = ram;

        public string Processor
        {
            get => _processor;
            private set => _processor = value;
        }

        public int RAM
        {
            get => _ram;
            private set => _ram = value;
        }

        // Реализация абстрактного метода
        public override string GetProductDetails()
        {
            return $"{Name} - {Price} USD - {Processor}, {RAM} GB RAM";
        }
    }
}
