using OnlineStore.Interfaces;

namespace OnlineStore.Models
{
    public class Order(IUser user) : IOrder
    {
        private IUser _user = user;
        private List<IProduct> _products = [];

        public IUser User
        {
            get => _user;
            private set => _user = value;
        }

        public List<IProduct> Products
        {
            get => _products;
            private set => _products = value;
        }

        public decimal TotalPrice
        {
            get { return Products.Sum(p => p.Price); }
        }

        public void AddProduct(IProduct product)
        {
            _products.Add(product);
        }

        public void PlaceOrder()
        {
            Console.WriteLine($"Order placed by {User.Username} for {TotalPrice}.");
        }
    }
}
