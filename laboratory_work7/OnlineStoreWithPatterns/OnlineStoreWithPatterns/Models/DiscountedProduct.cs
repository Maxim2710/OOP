using System;

namespace OnlineStore.Models
{
    /*
     * Шаблон "Декоратор" позволяет добавлять новое поведение объекту динамически, обертывая его. 
     * В вашем случае можно использовать декоратор для добавления скидки товарам.
     */
    public class DiscountedProduct : IProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public decimal GetDiscountedPrice()
        {
            return Price * (1 - Discount);
        }
    }
}
