using System.Collections.Generic;
using OnlineStore.Interfaces;

namespace OnlineStore.Interfaces
{
    public interface IDiscountService
    {
        void AddDiscount(IDiscount discount);
        decimal ApplyDiscount(IProduct product);
        List<IDiscount> GetAllDiscounts();
    }
}
