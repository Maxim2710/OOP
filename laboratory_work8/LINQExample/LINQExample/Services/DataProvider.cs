using LINQExample.Interfaces;
using LINQExample.Models;

namespace LINQExample.Services
{
    public class DataProvider : IDataProvider
    {
        public IEnumerable<Person> GetPeople()
        {
            return new List<Person>
            {
                new Person { Name = "Alice", Age = 25 },
                new Person { Name = "Bob", Age = 17 },
                new Person { Name = "Charlie", Age = 30 },
                new Person { Name = "Diana", Age = 15 }
            };
        }

        public IEnumerable<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Name = "Laptop", Price = 1200 },
                new Product { Name = "Phone", Price = 800 },
                new Product { Name = "Headphones", Price = 150 },
                new Product { Name = "Monitor", Price = 300 }
            };
        }
    }
}
