using OnlineStore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.Models
{
    public class Cart : ICart
    {
        private IUser _user;
        private List<IProduct> _products;

        public IUser User => _user;
        public List<IProduct> Products => _products;

        public Cart(IUser user)
        {
            _user = user;
            _products = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            _products.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            _products.Remove(product);
        }

        public decimal GetTotalPrice()
        {
            return _products.Sum(p => p.Price);
        }
    }
}
