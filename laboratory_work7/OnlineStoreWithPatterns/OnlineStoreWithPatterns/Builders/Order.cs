namespace OnlineStore.Builders
{
    using OnlineStore.Models;
    using System.Collections.Generic;

    public class Order
    {
        public List<IProduct> Products { get; private set; }
        public decimal Total { get; private set; }

        public Order(List<IProduct> products)
        {
            Products = products;
            Total = 0;
            foreach (var product in products)
            {
                Total += product.Price;
            }
        }
    }
}
