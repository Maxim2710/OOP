using LINQExample.Interfaces;
using LINQExample.Models;
using System.Linq;

namespace LINQExample.Services
{
    public class DataProcessor : IProcessor
    {
        public IEnumerable<Person> GetAdults(IEnumerable<Person> people)
        {
            return people.Where(p => p.Age >= 18);
        }

        public IEnumerable<Product> GetExpensiveProducts(IEnumerable<Product> products, decimal minPrice)
        {
            return products.Where(p => p.Price >= minPrice);
        }

        public IEnumerable<string> GetProductNamesSorted(IEnumerable<Product> products)
        {
            return products.OrderBy(p => p.Name).Select(p => p.Name);
        }
    }
}
