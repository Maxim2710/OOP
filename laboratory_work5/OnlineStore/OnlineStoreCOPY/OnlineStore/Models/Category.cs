using OnlineStore.Interfaces;

namespace OnlineStore.Models
{
    public class Category(string categoryName) : ICategory
    {
        private string _categoryName = categoryName;
        private List<IProduct> _products = [];

        public string CategoryName
        {
            get => _categoryName;
            private set => _categoryName = value;
        }

        public List<IProduct> Products
        {
            get => _products;
            private set => _products = value;
        }

        public void AddProduct(IProduct product)
        {
            _products.Add(product);
        }
    }
}
