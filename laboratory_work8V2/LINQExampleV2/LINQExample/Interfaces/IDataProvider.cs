using LINQExample.Models;

namespace LINQExample.Interfaces
{
    public interface IDataProvider
    {
        IEnumerable<Person> GetPeople();
        IEnumerable<Product> GetProducts();
    }
}
