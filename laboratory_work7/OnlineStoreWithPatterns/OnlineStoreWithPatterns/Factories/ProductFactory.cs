namespace OnlineStore.Factories
{
    using OnlineStore.Models;


    /*
     * Фабричный метод предоставляет интерфейс для создания объектов, но позволяет подклассам изменить тип создаваемых объектов. 
     * В вашем случае можно использовать фабричный метод для создания товаров (например, с разными свойствами или скидками).
     */
    public abstract class ProductFactory
    {
        public abstract IProduct CreateProduct(string name, decimal price);
    }
}
