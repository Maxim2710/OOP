namespace OnlineStore.Builders
{
    using OnlineStore.Models;
    using System.Collections.Generic;


    /*
     * Шаблон "Строитель" позволяет создать сложный объект по частям. В вашем проекте это может быть полезно для создания сложных объектов заказов, 
     * которые могут включать несколько товаров, способы оплаты и доставки.
     */
    public class OrderBuilder
    {
        private readonly List<IProduct> _products = new();

        public OrderBuilder AddProduct(IProduct product)
        {
            _products.Add(product);
            return this;
        }

        public Order Build()
        {
            return new Order(_products);
        }
    }
}
