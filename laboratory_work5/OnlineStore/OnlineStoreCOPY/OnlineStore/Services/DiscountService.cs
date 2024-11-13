using System.Collections.Generic;
using OnlineStore.Interfaces;

namespace OnlineStore.Services
{
    public class DiscountService : IDiscountService
    {
        private List<IDiscount> _discounts = new();

        public void AddDiscount(IDiscount discount)
        {
            _discounts.Add(discount);
        }

        public decimal ApplyDiscount(IProduct product)
        {
            decimal finalPrice = product.Price;
            foreach (var discount in _discounts)
            {
                finalPrice = discount.Apply(finalPrice);
            }
            return finalPrice;
        }

        public List<IDiscount> GetAllDiscounts()
        {
            return _discounts;
        }
    }
}
