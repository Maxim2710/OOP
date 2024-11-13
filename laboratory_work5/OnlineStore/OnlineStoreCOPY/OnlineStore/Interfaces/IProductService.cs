namespace OnlineStore.Interfaces
{
    public interface IProductService
    {
        void AddProduct(IProduct product);
        List<IProduct> GetAllProducts();
        IProduct? GetProductByName(string name);
    }
}
