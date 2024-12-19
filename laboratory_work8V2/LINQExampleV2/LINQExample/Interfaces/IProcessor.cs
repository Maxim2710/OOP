using LINQExample.Models;

namespace LINQExample.Interfaces
{
    public interface IProcessor
    {
        IEnumerable<Person> GetAdults(IEnumerable<Person> people);
        IEnumerable<Product> GetExpensiveProducts(IEnumerable<Product> products, decimal minPrice);
        IEnumerable<string> GetProductNamesSorted(IEnumerable<Product> products);
    }
}
