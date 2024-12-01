namespace OnlineStore.Factories
{
    using OnlineStore.Models;

    public class ConcreteProductFactory : ProductFactory
    {
        public override IProduct CreateProduct(string name, decimal price)
        {
            return new Product(name, price);
        }
    }
}
