using System;
using System.Collections.Generic;
using OnlineStore.Interfaces;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    public class ProductController
    {
        private IProductService _productService;
        private IDiscountService _discountService;

        public ProductController(IProductService productService, IDiscountService discountService)
        {
            _productService = productService;
            _discountService = discountService;
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

        public decimal GetDiscountedPrice(IProduct product)
        {
            return _discountService.ApplyDiscount(product);
        }
    }
}
