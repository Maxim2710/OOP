using OnlineStore.Interfaces;

namespace OnlineStore.Models
{
    public abstract class Product : IProduct
    {
        private static int _idCounter = 0; // Статический счетчик для уникальных ID
        private int _id; // ID продукта
        private string _name;
        private decimal _price;
        private string _description;

        public int Id
        {
            get => _id;
            private set => _id = value;
        }

        public string Name
        {
            get => _name;
            protected set => _name = value;
        }

        public decimal Price
        {
            get => _price;
            protected set => _price = value;
        }

        public string Description
        {
            get => _description;
            protected set => _description = value;
        }

        protected Product(string name, decimal price, string description)
        {
            _id = ++_idCounter; // Увеличиваем счетчик и присваиваем ID
            _name = name;
            _price = price;
            _description = description;
        }

        public abstract string GetProductDetails();
    }
}
