namespace OnlineStore.Services
{
    using OnlineStore.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingCart
    {
        private readonly List<IProduct> _products = new();

        public void AddProduct(IProduct product)
        {
            _products.Add(product);
            OnCartChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RemoveProduct(IProduct product)
        {
            _products.Remove(product);
            OnCartChanged?.Invoke(this, EventArgs.Empty);
        }

        public decimal Total => _products.Sum(p => p.Price);

        public IEnumerable<IProduct> Products => _products;

        public event EventHandler? OnCartChanged;
    }
}
