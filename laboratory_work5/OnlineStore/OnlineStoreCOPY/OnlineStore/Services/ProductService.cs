using OnlineStore.Interfaces;
using OnlineStore.Models;

namespace OnlineStore.Services
{
    public class ProductService : IProductService
    {
        private List<IProduct> _products;

        public ProductService()
        {
            _products = [];
        }

        public void AddProduct(IProduct product)
        {
            _products.Add(product);
        }

        public List<IProduct> GetAllProducts()
        {
            return _products;
        }

        public IProduct? GetProductByName(string name)
        {
            return _products.FirstOrDefault(p => p.Name == name);
        }
    }
}
