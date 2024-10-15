using OnlineStore.Interfaces;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    public class ProductController
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public void AddProduct(string name, decimal price, string description, string processor, int ram)
        {
            var product = new Computer(name, price, description, processor, ram);
            _productService.AddProduct(product);
        }

        public List<IProduct> GetAllProducts()
        {
            return _productService.GetAllProducts();
        }
    }
}
